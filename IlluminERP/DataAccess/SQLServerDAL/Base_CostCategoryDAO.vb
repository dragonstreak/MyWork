
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class Base_CostCategoryDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_CostCategory


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetCostCategoryById(ByVal Id As Integer) As Model.Base_CostCategory Implements IDAL.IBase_CostCategory.GetCostCategoryById

            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = Id
            Dim sql As String = "select * from [t_Base_CostCategory] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_CostCategory = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function


        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_CostCategory
            Dim info As New Base_CostCategory
            info.ID = Convert.ToInt32(dr("ID"))

            If Not Convert.IsDBNull(dr("Code")) Then
                info.Code = dr("Code").ToString()
            End If

            If Not Convert.IsDBNull(dr("CostCategoryEn")) Then
                info.CostCategoryEn = dr("CostCategoryEn").ToString()
            End If

            If Not Convert.IsDBNull(dr("CostCategoryCN")) Then
                info.CostCategoryCN = dr("CostCategoryCN").ToString()
            End If
            If Not Convert.IsDBNull(dr("Description")) Then
                info.Description = dr("Description").ToString()
            End If


            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_CostCategory) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                New SqlParameter("@Code", SqlDbType.Char), _
                                                New SqlParameter("@CostCategoryEn", SqlDbType.Char), _
                                                New SqlParameter("@CostCategoryCN", SqlDbType.Char), _
                                                New SqlParameter("@Description", SqlDbType.Char)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.Code
            parameters(2).Value = info.CostCategoryEn
            parameters(3).Value = info.CostCategoryCN
            parameters(4).Value = info.Description



            Return parameters
        End Function
    End Class
End Namespace
