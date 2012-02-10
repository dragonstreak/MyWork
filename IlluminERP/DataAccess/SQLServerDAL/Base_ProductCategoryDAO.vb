
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_ProductCategoryDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_ProductCategory



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetProductCategoryInfo() As System.Data.DataSet Implements IDAL.IBase_ProductCategory.GetProductCategoryInfo
            Dim sql As String = "select * from [t_base_ProductCategory]  Order by sort ,ProductCategory "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetSectorInfoByID(ByVal ID As Integer) As Model.Base_ProductCategory Implements IDAL.IBase_ProductCategory.GetSectorInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_ProductCategory] where Id = @id "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_ProductCategory = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToProductCategoryInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetSectorInfoBySectorId(ByVal SectorId As Integer) As System.Data.DataSet Implements IDAL.IBase_ProductCategory.GetSectorInfoBySectorId
            Dim paramSectorID As New SqlParameter("@SectorId", SqlDbType.Int)
            paramSectorID.Value = SectorId
            Dim sql As String = "select * from [t_base_ProductCategory] where SectorId = @SectorId Order by sort ,ProductCategory"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramSectorID)

            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Private Function MapRowToProductCategoryInfo(ByVal dr As DataRow) As Base_ProductCategory
            Dim info As New Base_ProductCategory
            info.ID = Convert.ToInt32(dr("ID"))
            info.ProductCategory = dr("ProductCategory").ToString()
            info.SectorId = Convert.ToInt32(dr("SectorId"))

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_ProductCategory) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProductCategory", SqlDbType.VarChar), _
                                                                    New SqlParameter("@SectorId", SqlDbType.Int)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.ProductCategory
            parameters(2).Value = info.SectorId


            Return parameters
        End Function

    End Class
End Namespace
