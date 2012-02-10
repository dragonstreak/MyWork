Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL

    Friend Interface IPMS_Revenue
        Function GetRevenueByProId(ByVal ProId As Integer) As Model.PMS_Revenue

        Function AddProjectRevenue(ByVal info As Model.PMS_Revenue) As Integer

        Function UpdateProjectRevenue(ByVal Info As Model.PMS_Revenue) As Boolean

        Function IsExitRecord(ByVal ProId As Integer) As Boolean

    End Interface
End Namespace
