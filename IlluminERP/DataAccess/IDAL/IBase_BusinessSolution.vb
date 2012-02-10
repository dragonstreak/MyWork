Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_BusinessSolution
        Function GetBSInfo() As DataSet

        Function GetBSByID(ByVal ID As Integer) As Base_BusinessSolution

    End Interface

End Namespace
