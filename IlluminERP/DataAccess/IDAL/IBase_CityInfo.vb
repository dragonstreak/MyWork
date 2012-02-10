Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_CityInfo

        Function GetCityInfo() As DataSet

        Function GetCityInfoByID(ByVal ID As Integer) As Base_CityInfo

    End Interface

End Namespace

