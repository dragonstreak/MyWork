
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL

    Friend Interface IPMS_PricingCityInfo


        Function GetPricingCityInfoById(ByVal ID As Integer) As Model.PMS_PricingCityInfo

        Function GetPricingCityInfo() As DataSet


    End Interface
End Namespace
