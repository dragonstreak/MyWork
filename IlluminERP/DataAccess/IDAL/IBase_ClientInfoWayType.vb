Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_ClientInfoWayType
        Function GetClientInfoWayTypeInfo() As DataSet

        Function GetClientInfoWayTypeById(ByVal ID As Integer) As Base_ClientInfoWayType
    End Interface
End Namespace
