Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_AOE

        Function GetAOEInfo() As DataSet

        Function GetAOEInfoByID(ByVal ID As Integer) As Base_AOE

    End Interface
End Namespace
