
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports Utils



Namespace BLL
    Public Class PMS_ProjectContractFileInfoBLL
        Private factory As New DALFactory
        Private ProjectContractFileInfoDAL As IPMS_ProjectContractFileInfo = factory.GetProduct("PMS_ProjectContractFileInfoDAO")
        Public Sub New()

        End Sub
        Public Function GetProjectContractFileInfoById(ByVal Id As Integer) As Model.PMS_ProjectContractFileInfo
            Return Me.ProjectContractFileInfoDAL.GetProjectContractFileInfoById(Id)
        End Function

        Public Function GetProjectContractFileInfoByProId(ByVal ProId As Integer) As DataView
            Return Me.ProjectContractFileInfoDAL.GetProjectContractFileInfoByProId(ProId)
        End Function

        Public Function AddProjectContractFileInfo(ByVal info As Model.PMS_ProjectContractFileInfo) As Integer
            Return Me.ProjectContractFileInfoDAL.AddProjectContractFileInfo(info)
        End Function

        Public Function DeleteProjectContractFileInfo(ByVal Info As Model.PMS_ProjectContractFileInfo) As Boolean
            Return Me.ProjectContractFileInfoDAL.DeleteProjectContractFileInfo(Info)
        End Function
    End Class
End Namespace
