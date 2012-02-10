Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_CostCategoryBLL
        Private factory As New DALFactory
        Private CostCategoryDAL As IBase_CostCategory = factory.GetProduct("Base_CostCategoryDAO")

        Public Sub New()

        End Sub

        Public Function GetCostCategoryById(ByVal Id As Integer) As Model.Base_CostCategory
            Return CostCategoryDAL.GetCostCategoryById(Id)
        End Function

    End Class
End Namespace
