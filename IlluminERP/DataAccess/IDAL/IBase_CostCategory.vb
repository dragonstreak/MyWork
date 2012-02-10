Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_CostCategory

        Function GetCostCategoryById(ByVal Id As Integer) As Model.Base_CostCategory

    End Interface
End Namespace
