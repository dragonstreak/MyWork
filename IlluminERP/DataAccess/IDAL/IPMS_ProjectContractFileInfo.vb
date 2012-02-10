Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IPMS_ProjectContractFileInfo

        Function GetProjectContractFileInfoById(ByVal Id As Integer) As Model.PMS_ProjectContractFileInfo

        Function GetProjectContractFileInfoByProId(ByVal ProId As Integer) As DataView

        Function AddProjectContractFileInfo(ByVal info As Model.PMS_ProjectContractFileInfo) As Integer

        Function DeleteProjectContractFileInfo(ByVal Info As Model.PMS_ProjectContractFileInfo) As Boolean

    End Interface
End Namespace
