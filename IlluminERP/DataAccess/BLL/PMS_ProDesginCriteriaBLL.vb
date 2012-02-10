Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL
    Public Class PMS_ProDesginCriteriaBLL
        Private factory As New DALFactory
        Private ProDesginCriteriaDAL As IPMS_ProDesginCriteria = factory.GetProduct("PMS_ProDesginCriteriaDAO")

        Public Sub New()

        End Sub

        Public Function GetProDesignCriteriaById(ByVal Id As Integer) As Model.PMS_ProDesginCriteria
            Return ProDesginCriteriaDAL.GetProDesignCriteriaById(Id)
        End Function

        Public Function GetProDesignCriteriaBySubProId(ByVal SubProId As Integer) As DataSet
            Return ProDesginCriteriaDAL.GetProDesignCriteriaBySubProId(SubProId)
        End Function

        Public Function AddProDesignCriteria(ByVal Info As Model.PMS_ProDesginCriteria) As Integer
            Return ProDesginCriteriaDAL.AddProDesignCriteria(Info)
        End Function

        Public Function DeleteProDesignCriteria(ByVal Info As Model.PMS_ProDesginCriteria) As Integer
            Return ProDesginCriteriaDAL.DeleteProDesignCriteria(Info)
        End Function

        Public Function SaveCriteriaRecruitment(ByVal dtCriteria As DataTable, ByVal dtRecruitment As DataTable, ByVal strSubProId As String) As Boolean
            Dim factory As New DALFactory


            Dim ProDesignCriteriaDal As IPMS_ProDesginCriteria = factory.GetProduct("PMS_ProDesginCriteriaDAO")
            Dim ProDesignRecruitmentDal As IPMS_ProDesignRecruitment = factory.GetProduct("PMS_ProDesignRecruitmentDAO")

            Dim ProDesignCriteriaInfo As New Model.PMS_ProDesginCriteria
            Dim ProDesignRecruitmentInfo As New Model.PMS_ProDesignRecruitment

            factory.BeginTransaction()
            Try



                'Criteria
                Dim ds As DataSet = ProDesignCriteriaDal.GetProDesignCriteriaBySubProId(strSubProId)
                Dim dt As DataTable
                dt = ds.Tables(0)

                '第一次新选项在老选项的中间判断。 如果没有新增
                For Each drNew As DataRow In dtCriteria.Rows
                    Dim i As Integer = 0
                    For Each olddr As DataRow In dt.Rows
                        If drNew("CeriteriaSelectionId") = olddr("CeriteriaSelectionId") Then
                            i = 1
                            Exit For
                        End If
                    Next

                    If i = 0 Then '新的
                        ProDesignCriteriaInfo = New PMS_ProDesginCriteria
                        ProDesignCriteriaInfo.SubProId = strSubProId
                        ProDesignCriteriaInfo.CeriteriaSelectionId = drNew("CeriteriaSelectionId")
                        ProDesignCriteriaInfo.Description = drNew("Description")
                        ProDesignCriteriaDal.AddProDesignCriteria(ProDesignCriteriaInfo)
                    End If
                Next
                '第二次老选项在新选项的中间判断。 如果没有删除

                For Each olddr As DataRow In dt.Rows
                    Dim i As Integer = 0
                    For Each drNew As DataRow In dtCriteria.Rows
                        If drNew("CeriteriaSelectionId") = olddr("CeriteriaSelectionId") Then
                            i = 1
                            Exit For
                        End If
                    Next

                    If i = 0 Then
                        ProDesignCriteriaInfo = New PMS_ProDesginCriteria
                        ProDesignCriteriaInfo.Id = olddr("Id")
                        ProDesignCriteriaDal.DeleteProDesignCriteria(ProDesignCriteriaInfo)
                    End If
                Next


                'Recuitment
                ds = ProDesignRecruitmentDal.GetProDesignRecruitmentBySubProId(strSubProId)
                dt = ds.Tables(0)

                '第一次新选项在老选项的中间判断。 如果没有新增
                For Each drNew As DataRow In dtRecruitment.Rows
                    Dim i As Integer = 0
                    For Each olddr As DataRow In dt.Rows
                        If drNew("RecruitmentSelectionId") = olddr("RecruitmentSelectionId") Then
                            i = 1
                            If drNew("Description") <> "" Then
                                ProDesignRecruitmentInfo = New PMS_ProDesignRecruitment
                                ProDesignRecruitmentInfo.Id = olddr("ID")
                                ProDesignRecruitmentInfo.SubProId = strSubProId
                                ProDesignRecruitmentInfo.RecruitmentSelectionId = drNew("RecruitmentSelectionId")
                                ProDesignRecruitmentInfo.Description = drNew("Description")
                                ProDesignRecruitmentDal.UpdateRecruitmentDescription(ProDesignRecruitmentInfo)
                            End If
                            Exit For
                        End If
                    Next

                    If i = 0 Then '新的
                        ProDesignRecruitmentInfo = New PMS_ProDesignRecruitment
                        ProDesignRecruitmentInfo.SubProId = strSubProId
                        ProDesignRecruitmentInfo.RecruitmentSelectionId = drNew("RecruitmentSelectionId")
                        ProDesignRecruitmentInfo.Description = drNew("Description")
                        ProDesignRecruitmentDal.AddProDesignRecruitment(ProDesignRecruitmentInfo)
                    End If

                Next
                '第二次老选项在新选项的中间判断。 如果没有删除

                For Each olddr As DataRow In dt.Rows
                    Dim i As Integer = 0
                    For Each drNew As DataRow In dtRecruitment.Rows
                        If drNew("RecruitmentSelectionId") = olddr("RecruitmentSelectionId") Then
                            i = 1
                            Exit For
                        End If
                    Next

                    If i = 0 Then
                        ProDesignRecruitmentInfo = New PMS_ProDesignRecruitment
                        ProDesignRecruitmentInfo.Id = olddr("Id")
                        ProDesignRecruitmentDal.DeleteProDesignRecruitment(ProDesignRecruitmentInfo)
                    End If
                Next
                
                factory.Commit()
                Return True
            Catch ex As Exception
                factory.Rollback()
                Return False
            End Try
        End Function

    End Class
End Namespace
