
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL

    Friend Interface Ibase_MethodologyInfo

        Function GetMethodologyInfo(ByVal Id As Integer) As Base_MethodologyInfo

        Function GetMethodologyInfoByType(ByVal MethType As Integer) As DataSet



    End Interface
End Namespace
