
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL
Public Class PMS_ProposalInfoBLL
        Private factory As New DALFactory
        Private ProposalInfoDAL As IPMS_ProposalInfo = factory.GetProduct("PMS_ProposalInfoDAO")

        Public Sub New()

        End Sub

        'Public Function GetProposalInfo() As DataSet
        '    Return ProposalInfoDAL.GetProposalInfo
        'End Function

        Public Function GetProposalInfoByID(ByVal ID As Integer) As PMS_ProposalInfo
            Return ProposalInfoDAL.GetProposalInfoByID(ID)
        End Function

        'Public Function GetProposalInfobyJobNumber(ByVal strJobNumber As String) As PMS_ProposalInfo
        '    Return ProposalInfoDAL.GetProposalInfobyJobNumber(strJobNumber)
        'End Function

        Public Function GetProposallistByStatus(ByVal Status As String) As DataView
            Return ProposalInfoDAL.GetProposallistByStatus(Status)
        End Function

        Public Function AddProposalInfo(ByVal info As Model.PMS_ProposalInfo) As Integer
            Return ProposalInfoDAL.AddProposalInfo(info)
        End Function

        Public Function AddProposaladdonInfo(ByVal info As Model.PMS_ProposalInfo) As Integer
            Return ProposalInfoDAL.AddProposaladdonInfo(info)
        End Function

        Public Function UpdateProposalInfo(ByVal info As Model.PMS_ProposalInfo) As Boolean
            Return ProposalInfoDAL.UpdateProposalInfo(info)
        End Function

        Public Function GetJobNumber(ByVal info As Model.PMS_ProposalInfo) As String
            Return ProposalInfoDAL.GetJobNumber(info)
        End Function

        Public Function UpdateProjectStatus(ByVal info As PMS_ProposalInfo) As Boolean
            Return ProposalInfoDAL.UpdateProjectStatus(info)
        End Function

        Public Function GetProRelationList(ByVal ProId As String) As System.Data.DataView
            Return ProposalInfoDAL.GetProRelationList(ProId)
        End Function

        Public Function NewProposalInfo(ByVal Info As PMS_ProposalInfo, ByVal dt As DataTable, ByVal type As String) As Integer
            Dim factory As New DALFactory
            Dim strJobNumber As String
            Dim strUploadProjectFilePath As String
            Dim ProposalInfoDAL As IPMS_ProposalInfo = factory.GetProduct("PMS_ProposalInfoDAO")
            Dim ProposalUserInfoDAL As IPMS_ProposalUserInfo = factory.GetProduct("PMS_ProposalUserInfoDAO")
            Dim ProrelationInfoDAL As IPMS_ProRelationInfo = factory.GetProduct("PMS_ProRelationInfoDAO")
            Dim ProposalUserinfo As New Model.PMS_ProposalUserInfo
            Dim ProreleationInfo As New Model.PMS_ProRelationInfo
            Dim strProId As String

            factory.BeginTransaction()
            Try




                Dim strOldId As String = Info.Id.ToString

                If type = "addon" Then
                    Dim ds As DataSet = ProrelationInfoDAL.GetRelationProInfoByProId(Info.Id)
                    If ds.Tables(0).Rows.Count <= 0 Then
                        strJobNumber = Info.JobNumber.Trim + "a"
                        Info.JobNumber = strJobNumber
                    Else
                        Dim i As Integer = ds.Tables(0).Rows.Count + 97
                        strJobNumber = Info.JobNumber.Trim + Chr(i)
                        Info.JobNumber = strJobNumber
                        Info.JobIndex = Chr(i)
                    End If

                  
                End If



                If type = "new" Then
                    strJobNumber = ProposalInfoDAL.GetJobNumber(Info)
                    If Not strJobNumber Is Nothing Then
                        Info.JobNumber = strJobNumber
                    End If

                End If


                strUploadProjectFilePath = System.Web.Configuration.WebConfigurationManager.AppSettings("UploadProjectFilePath").ToString
                strUploadProjectFilePath = strUploadProjectFilePath & Info.JobNumber

                Info.UploadFilePath = strUploadProjectFilePath

                CreateServerFolder(Info.UploadFilePath)

                strProId = ProposalInfoDAL.AddProposalInfo(Info)

                '增加相关人员
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        dr("proId") = strProId
                        dt.AcceptChanges()
                    Next
                End If


                For Each drRow As DataRow In dt.Rows
                    ProposalUserinfo.ProId = drRow("ProId")
                    ProposalUserinfo.UserId = drRow("UserId")
                    ProposalUserinfo.ProposalUserTypeId = drRow("ProposalUserTypeId")
                    ProposalUserInfoDAL.AddProposalUserinfo(ProposalUserinfo)
                Next


                ProreleationInfo.ProId = strOldId
                ProreleationInfo.RelationProId = strProId
                ProreleationInfo.RelationType = Info.JobIndex

                ProrelationInfoDAL.InsertProRelationInfo(ProreleationInfo)

                factory.Commit()
                Return strProId
            Catch ex As Exception
                factory.Rollback()
                Return 0
            End Try


        End Function

        Public Function ModifyProposalInfo(ByVal info As Model.PMS_ProposalInfo, ByVal dtUser As DataTable) As Boolean

            Dim factory As New DALFactory
            Dim ProposalInfoDAL As IPMS_ProposalInfo = factory.GetProduct("PMS_ProposalInfoDAO")
            Dim ProposalUserInfoDAL As IPMS_ProposalUserInfo = factory.GetProduct("PMS_ProposalUserInfoDAO")
            Dim ProposalUserinfo As New Model.PMS_ProposalUserInfo
           
            factory.BeginTransaction()
            Try
                ProposalInfoDAL.UpdateProposalInfo(info)

                If dtUser.Rows.Count > 0 Then
                    For Each dr As DataRow In dtUser.Rows

                        If dr("ProposalUserTypeId") = 2 Then
                            ProposalUserinfo.ProId = info.Id
                            ProposalUserinfo.ProposalUserTypeId = 2
                            ProposalUserinfo.UserId = dr("UserId")
                            ProposalUserInfoDAL.UpdateProposaluserInfo(ProposalUserinfo)


                        End If
                    Next
                End If

                factory.Commit()
                Return True
            Catch ex As Exception
                factory.Rollback()
                Return False
            End Try





        End Function

        Public Function AddProposalInfo(ByVal info As Model.PMS_ProposalInfo, ByVal dtUser As DataTable, ByVal type As String) As Integer
            Dim intId As Integer
            intId = NewProposalInfo(info, dtUser, type)

            Return intId

       
        End Function


        Private Sub CreateServerFolder(ByVal strFolder As String)
            Dim strChildFolder As String
            Try
                If Directory.Exists(strFolder) = False Then
                    Directory.CreateDirectory(strFolder)

                    strChildFolder = strFolder + "\" + "DG"
                    CreateServerChildFolder(strChildFolder)

                    strChildFolder = strFolder + "\" + "Proposal&Quotation"
                    CreateServerChildFolder(strChildFolder)

                    strChildFolder = strFolder + "\" + "Report"
                    CreateServerChildFolder(strChildFolder)

                    strChildFolder = strFolder + "\" + "Contract"
                    CreateServerChildFolder(strChildFolder)

                    strChildFolder = strFolder + "\" + "Qnr"
                    CreateServerChildFolder(strChildFolder)

                    strChildFolder = strFolder + "\" + "Data Set"
                    CreateServerChildFolder(strChildFolder)

                    strChildFolder = strFolder + "\" + "Simulus"
                    CreateServerChildFolder(strChildFolder)

                    strChildFolder = strFolder + "\" + "Others"
                    CreateServerChildFolder(strChildFolder)

                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub CreateServerChildFolder(ByVal strFolder As String)
            If Directory.Exists(strFolder) = False Then
                Directory.CreateDirectory(strFolder)
            End If

        End Sub

        Public Function GetProposallistByQueryInfo(ByVal QueryInfo As Model.PMS_ProposalInfo) As DataView
            Return ProposalInfoDAL.GetProposallistByQueryInfo(QueryInfo)
        End Function

        Public Function GetProposalList(ByVal proposalQueryFilter As ProposalQueryFilter) As DataSet
            Return ProposalInfoDAL.GetProposalList(proposalQueryFilter)
        End Function

        Public Function GetProposallistByQueryString(ByVal QueryString As String) As DataView
            Return ProposalInfoDAL.GetProposallistByQueryString(QueryString)
        End Function

        Public Function GetMyProposallistByUserId(ByVal UserID As String) As DataView
            Return ProposalInfoDAL.GetMyProposallistByUserId(UserID)
        End Function

    End Class
End Namespace

