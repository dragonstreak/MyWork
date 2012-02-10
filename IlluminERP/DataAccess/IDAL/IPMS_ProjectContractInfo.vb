Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IPMS_ProjectContractInfo

        Function GetProjectContractInfoById(ByVal Id As Integer) As Model.PMS_ProjectContractInfo

        Function GetProjectContractInfobyProId(ByVal ProId As Integer) As Model.PMS_ProjectContractInfo

        Function AddProjectContractInfo(ByVal info As Model.PMS_ProjectContractInfo) As Integer

        Function UpdateProjectContractInfo(ByVal Info As PMS_ProjectContractInfo) As Boolean

        Function IsExistProjectContract(ByVal ProId As Integer) As Boolean

       

    End Interface
End Namespace
