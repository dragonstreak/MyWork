Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Base_ClientInfoWayTypeBLL
        Private factory As New DALFactory
        Private ClientWayInfoDAL As IBase_ClientInfoWayType = factory.GetProduct(" Base_ClientInfoWayTypeDAO")

        Public Sub New()

        End Sub

        Public Function GetClientUploadFileTypeInfo() As DataSet
            Return ClientWayInfoDAL.GetClientInfoWayTypeInfo()
        End Function

        Public Function GetClientUploadFileTypeById(ByVal Id As Integer) As Model.Base_ClientInfoWayType
            Return ClientWayInfoDAL.GetClientInfoWayTypeById(Id)
        End Function

    End Class
End Namespace
