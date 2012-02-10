
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL


    Friend Interface IPMS_PricingSampleCityInfo

        Function GetPricingSampleCityInfoById(ByVal Id As Integer) As PMS_PricingSampleCityInfo

        Function GetPricingSampleCityInfoByType(ByVal Type As Integer) As DataSet

        Function GetPricingSampleCityInfoByParentId(ByVal ParentId As Integer) As DataSet

    End Interface
End Namespace
