

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL
    Public Class PMS_PricingCityInfoBLL
        Private factory As New DALFactory
        Private PricingCityInfoDAL As IPMS_PricingCityInfo = factory.GetProduct("PMS_PricingCityInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetPricingCityInfoById(ByVal ID As Integer) As Model.PMS_PricingCityInfo
            Return PricingCityInfoDAL.GetPricingCityInfoById(ID)
        End Function

        Public Function GetPricingCityInfo() As DataSet
            Return PricingCityInfoDAL.GetPricingCityInfo
        End Function

    End Class
End Namespace
