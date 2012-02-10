
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL

    Friend Interface IPMS_SubProjectInfo

        Function GetSubProjectInfoById(ByVal ID As Integer) As Model.PMS_SubProjectInfo

        Function GetSubProjectInfoByProId(ByVal ProId As Integer) As DataSet

        Function AddSubProjectInfo(ByVal info As Model.PMS_SubProjectInfo) As Integer

        Function UpdateSubProjectStatus(ByVal info As PMS_SubProjectInfo) As Boolean

        Function GetSubJobNumberByJobNumberMethTag(ByVal JobNumber As String, ByVal MethTag As String) As String
       

    End Interface
End Namespace

