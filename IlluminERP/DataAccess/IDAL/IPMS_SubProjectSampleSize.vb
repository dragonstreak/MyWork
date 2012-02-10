
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL

    Friend Interface IPMS_SubProjectSampleSize


        Function GetSubProjectSampleSizeById(ByVal ID As Integer) As Model.PMS_SubProjectSampleSize

        Function GetSubProjectSampleSizeBySubProId(ByVal SubProId As Integer) As DataSet

        Function AddSubProjectSampleSizeInfo(ByVal info As Model.PMS_SubProjectSampleSize) As Integer

        Function DeleteSubProjectSampleSizeInfoById(ByVal Id As Integer) As Boolean
    End Interface
End Namespace
