Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL

    Friend Interface IBase_DepMapCostCategory
        Function GetCostCategoryByDepID(ByVal DepId As Integer) As DataSet

    End Interface
End Namespace
