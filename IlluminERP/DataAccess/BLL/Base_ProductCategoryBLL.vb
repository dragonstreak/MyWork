
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class Base_ProductCategoryBLL
        Private factory As New DALFactory
        Private ProductCategoryDAL As IBase_ProductCategory = factory.GetProduct("Base_ProductCategoryDAO")

        Public Sub New()

        End Sub

        Public Function GetProductCategoryInfo() As DataSet
            Return ProductCategoryDAL.GetProductCategoryInfo()
        End Function

        Public Function GetSectorInfoByID(ByVal Id As Integer) As Model.Base_ProductCategory
            Return ProductCategoryDAL.GetSectorInfoByID(Id)
        End Function

        Public Function GetSectorInfoBySectorId(ByVal SectorId As Integer) As DataSet
            Return ProductCategoryDAL.GetSectorInfoBySectorId(SectorId)
        End Function
    End Class
End Namespace
