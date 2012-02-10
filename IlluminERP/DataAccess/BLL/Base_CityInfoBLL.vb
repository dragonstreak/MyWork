Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Base_CityInfoBLL

        Private factory As New DALFactory
        Private CityInfoDAL As IBase_CityInfo = factory.GetProduct("Base_CityInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetCityInfo() As DataSet
            Return CityInfoDAL.GetCityInfo()
        End Function

        Public Function GetCityInfoByID(ByVal Id As Integer) As Model.Base_CityInfo
            Return CityInfoDAL.GetCityInfoByID(Id)
        End Function


    End Class
End Namespace
