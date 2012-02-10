Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL

    Friend Interface IPMS_PricingDirectCostInfo

        Function GetDirectCostInfoById(ByVal Id As Integer) As Model.PMS_PricingDirectCostInfo

        Function GetDirectCostInfoByCityIdDepIdSubProId(ByVal CityId As Integer, ByVal DepId As Integer, ByVal SubProId As Integer) As DataSet

        Function AddDirectCostInfo(ByVal info As Model.PMS_PricingDirectCostInfo) As Integer

        Function DeleteDirectCostInfo(ByVal Id As Integer) As Boolean

        Function GetSumTotalCostByProId(ByVal ProId As Integer) As DataSet

    End Interface

End Namespace
