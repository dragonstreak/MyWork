Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_ProjectType
        Function GetProjectTypeInfo() As DataSet

        Function GetProjectTypeInfoByID(ByVal ID As Integer) As Base_ProjectType
    End Interface
End Namespace
