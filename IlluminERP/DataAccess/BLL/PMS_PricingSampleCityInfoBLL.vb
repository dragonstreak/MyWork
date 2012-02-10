
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL
    Public Class PMS_PricingSampleCityInfoBLL
        Private factory As New DALFactory
        Private PricingSampleCityInfoDAL As IPMS_PricingSampleCityInfo = factory.GetProduct("PMS_PricingSampleCityInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetPricingSampleCityInfoById(ByVal Id As Integer) As PMS_PricingSampleCityInfo
            Return PricingSampleCityInfoDAL.GetPricingSampleCityInfoById(Id)
        End Function

        Public Function GetPricingSampleCityInfoByType(ByVal Type As Integer) As DataSet
            Return PricingSampleCityInfoDAL.GetPricingSampleCityInfoByType(Type)
        End Function

        Public Function GetPricingSampleCityInfoByParentId(ByVal ParentId As Integer) As DataSet
            Return PricingSampleCityInfoDAL.GetPricingSampleCityInfoByParentId(ParentId)
        End Function
    End Class
End Namespace
