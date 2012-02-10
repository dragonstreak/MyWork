
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports Utils



Namespace BLL
    Public Class PMS_ProjectContractInfoBLL
        Private factory As New DALFactory
        Private ProjectContractInfoDAL As IPMS_ProjectContractInfo = factory.GetProduct("PMS_ProjectContractInfoDAO")

        Public Sub New()

        End Sub


        Public Function GetProjectContractInfoById(ByVal Id As Integer) As Model.PMS_ProjectContractInfo
            Return ProjectContractInfoDAL.GetProjectContractInfoById(Id)
        End Function

        Public Function GetProjectContractInfobyProId(ByVal ProId As Integer) As Model.PMS_ProjectContractInfo
            Return ProjectContractInfoDAL.GetProjectContractInfobyProId(ProId)
        End Function

        Public Function AddProjectContractInfo(ByVal info As Model.PMS_ProjectContractInfo) As Integer
            Return ProjectContractInfoDAL.AddProjectContractInfo(info)
        End Function

        Public Function UpdateProjectContractInfo(ByVal Info As PMS_ProjectContractInfo) As Boolean
            Return ProjectContractInfoDAL.UpdateProjectContractInfo(Info)
        End Function

        Public Function IsExistProjectContract(ByVal ProId As Integer) As Boolean
            Return ProjectContractInfoDAL.IsExistProjectContract(ProId)
        End Function

        Public Function NewContractInfo(ByVal Info As PMS_ProjectContractInfo, ByVal dtFileInfo As DataTable) As Integer
            Dim factory As New DALFactory

            Dim ProId As Integer
            Dim ContractInfoDAL As IPMS_ProjectContractInfo = factory.GetProduct("PMS_ProjectContractInfoDAO")
            Dim ContractFileInfoDAL As IPMS_ProjectContractFileInfo = factory.GetProduct("PMS_ProjectContractFileInfoDAO")
            Dim ContractFileInfo As Model.PMS_ProjectContractFileInfo

            factory.BeginTransaction()
            Try
                ProId = Info.ProjectId

                ContractInfoDAL.AddProjectContractInfo(Info)

                For Each drNew As DataRow In dtFileInfo.Rows
                    Dim i As Integer
                    If i = 0 Then '新的
                        ContractFileInfo = New PMS_ProjectContractFileInfo
                        ContractFileInfo.ProId = drNew("ProId")
                        ContractFileInfo.FileName = drNew("FileName")
                        ContractFileInfo.FileFolder = drNew("FileFolder")
                        ContractFileInfoDAL.AddProjectContractFileInfo(ContractFileInfo)
                    End If
                Next



                factory.Commit()
                Return 1
            Catch ex As Exception
                factory.Rollback()
                Return 0
            End Try
        End Function

        Public Function ModifyContractInfo(ByVal Info As PMS_ProjectContractInfo, ByVal dtFileInfo As DataTable) As Integer
            Dim factory As New DALFactory

            Dim ProId As Integer
            Dim ContractInfoDAL As IPMS_ProjectContractInfo = factory.GetProduct("PMS_ProjectContractInfoDAO")
            Dim ContractFileInfoDAL As IPMS_ProjectContractFileInfo = factory.GetProduct("PMS_ProjectContractFileInfoDAO")
            Dim ContractFileInfo As Model.PMS_ProjectContractFileInfo

            factory.BeginTransaction()
            Try
                ProId = Info.ProjectId

                ContractInfoDAL.UpdateProjectContractInfo(Info)

                For Each drNew As DataRow In dtFileInfo.Rows
                    Dim i As Integer
                    If i = 0 Then '新的
                        ContractFileInfo = New PMS_ProjectContractFileInfo
                        ContractFileInfo.ProId = drNew("ProId")
                        ContractFileInfo.FileName = drNew("FileName")
                        ContractFileInfo.FileFolder = drNew("FileFolder")
                        ContractFileInfoDAL.AddProjectContractFileInfo(ContractFileInfo)
                    End If
                Next



                factory.Commit()
                Return 1
            Catch ex As Exception
                factory.Rollback()
                Return 0
            End Try
        End Function
    End Class
End Namespace

