Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_Sector

        Function GetSectorInfo() As DataSet

        Function GetSectorInfoByID(ByVal ID As Integer) As Base_Sector

        Function GetSectorInfoByBusinessUnitId(ByVal BUId As Integer) As DataSet



    End Interface
End Namespace
