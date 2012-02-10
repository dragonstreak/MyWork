
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_ProductCategory

        Function GetProductCategoryInfo() As DataSet

        Function GetSectorInfoByID(ByVal ID As Integer) As Base_ProductCategory

        Function GetSectorInfoBySectorId(ByVal SectorId As Integer) As DataSet


    End Interface
End Namespace

