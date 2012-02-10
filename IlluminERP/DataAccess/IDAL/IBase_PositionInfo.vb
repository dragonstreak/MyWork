Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_PositionInfo

        Function GetPositionInfo() As DataSet

        Function GetPositionInfoByID(ByVal ID As Integer) As Base_PositionInfo

    End Interface
End Namespace
