Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_BusinessUnit

        Function GetBusinessUnitInfo() As DataSet

        Function GetBusinessUnitInfoByID(ByVal ID As Integer) As Base_BusinessUnit


    End Interface

End Namespace

