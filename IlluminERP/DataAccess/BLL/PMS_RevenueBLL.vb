Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL


    Public Class PMS_RevenueBLL
        Private factory As New DALFactory
        Private PMSRevenueDAL As IPMS_Revenue = factory.GetProduct("PMS_RevenueDAO")

        Public Sub New()

        End Sub

        Public Function GetRevenueByProId(ByVal ProId As Integer) As Model.PMS_Revenue
            Return PMSRevenueDAL.GetRevenueByProId(ProId)
        End Function

        Public Function AddProjectRevenue(ByVal info As Model.PMS_Revenue) As Integer
            Return PMSRevenueDAL.AddProjectRevenue(info)
        End Function

        Public Function UpdateProjectRevenue(ByVal Info As Model.PMS_Revenue) As Boolean
            Return PMSRevenueDAL.UpdateProjectRevenue(Info)
        End Function

        Public Function IsExitRecord(ByVal ProId As Integer) As Boolean
            Return PMSRevenueDAL.IsExitRecord(ProId)
        End Function
    End Class
End Namespace
