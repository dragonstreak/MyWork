Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_DepMapCostCategoryBLL
        Private factory As New DALFactory
        Private DepMapCostCategoryDAL As IBase_DepMapCostCategory = factory.GetProduct("Base_DepMapCostCategoryDAO")

        Public Sub New()

        End Sub

        Public Function GetCostCategoryByDepID(ByVal DepId As Integer) As DataSet
            Return DepMapCostCategoryDAL.GetCostCategoryByDepID(DepId)
        End Function
    End Class
End Namespace
