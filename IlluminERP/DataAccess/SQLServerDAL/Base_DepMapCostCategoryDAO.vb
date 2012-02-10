
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL

    Friend Class Base_DepMapCostCategoryDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_DepMapCostCategory


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetCostCategoryByDepID(ByVal DepId As Integer) As System.Data.DataSet Implements IDAL.IBase_DepMapCostCategory.GetCostCategoryByDepID
            Dim sql As String = "select a.DepId as DepId,b.Id as CostCategoryId,b.CostCategoryEn as CostCagetory " & _
                                " from t_Base_DepMapCostCategory a,t_Base_CostCategory b Where a.CostId=b.Id and a.DepId='" + CStr(DepId) + "' Order by b.CostCategoryEn"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function
    End Class
End Namespace
