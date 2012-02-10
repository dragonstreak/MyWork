
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL

    Public Class PMS_PricingDirectCostInfoBLL

        Private factory As New DALFactory
        Private PMS_PricingDirectCostInfoDAL As IPMS_PricingDirectCostInfo = factory.GetProduct("PMS_PricingDirectCostInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetDirectCostInfoById(ByVal Id As Integer) As Model.PMS_PricingDirectCostInfo
            Return PMS_PricingDirectCostInfoDAL.GetDirectCostInfoById(Id)
        End Function

        Public Function GetDirectCostInfoByCityIdDepIdSubProId(ByVal CityId As Integer, ByVal DepId As Integer, ByVal SubProId As Integer) As DataSet
            Return PMS_PricingDirectCostInfoDAL.GetDirectCostInfoByCityIdDepIdSubProId(CityId, DepId, SubProId)
        End Function

        Public Function AddDirectCostInfo(ByVal info As Model.PMS_PricingDirectCostInfo) As Integer
            Return PMS_PricingDirectCostInfoDAL.AddDirectCostInfo(info)
        End Function

        Public Function DeleteDirectCostInfo(ByVal Id As Integer) As Boolean
            Return PMS_PricingDirectCostInfoDAL.DeleteDirectCostInfo(Id)
        End Function

        Public Function GetSumTotalCostByProId(ByVal ProId As Integer) As DataSet
            Return PMS_PricingDirectCostInfoDAL.GetSumTotalCostByProId(ProId)
        End Function
    End Class
End Namespace
