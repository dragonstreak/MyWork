
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class PMS_PricingDirectCostInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_PricingDirectCostInfo




        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddDirectCostInfo(ByVal info As Model.PMS_PricingDirectCostInfo) As Integer Implements IDAL.IPMS_PricingDirectCostInfo.AddDirectCostInfo
            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_PricingDirectCost (SubProId,DepId,CityId,CostCategoryId,UnitPrice,Quantity,TotalCost,Description) Values ("
                strSql += "'" + info.SubProId.ToString + "',"
                strSql += "'" + info.DepId.ToString + "',"
                strSql += "'" + info.CityId.ToString + "',"
                strSql += "'" + info.CostCategoryId.ToString + "',"
                strSql += "'" + info.UnitPrice.ToString + "',"
                strSql += "'" + info.Quantity.ToString + "',"
                strSql += "'" + info.TotalCost.ToString + "',"
                strSql += "'" + info.Description.ToString + "')"
                strSql += " select ID=@@Identity"


                Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, strSql)
                If dr.Read Then
                    info.Id = Convert.ToInt32(dr("Id"))
                    dr.Close()
                    dr = Nothing
                    Return info.Id
                Else
                    Return 0
                End If

            Catch ex As Exception
                Dim str As String = ex.Message
            End Try

        End Function

        Public Function DeleteDirectCostInfo(ByVal Id As Integer) As Boolean Implements IDAL.IPMS_PricingDirectCostInfo.DeleteDirectCostInfo
            Dim strSql As String

            strSql = " Delete From t_PMS_PricingDirectCost "
            strSql += " Where Id ='" + CStr(Id) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetDirectCostInfoById(ByVal Id As Integer) As Model.PMS_PricingDirectCostInfo Implements IDAL.IPMS_PricingDirectCostInfo.GetDirectCostInfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_PricingDirectCost] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_PricingDirectCostInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_PricingDirectCostInfo

            Dim info As New PMS_PricingDirectCostInfo
            info.Id = Convert.ToInt32(dr("ID"))

            If Not Convert.IsDBNull(dr("SubProId")) Then
                info.SubProId = Convert.ToInt32(dr("SubProId"))
            End If
            If Not Convert.IsDBNull(dr("DepId")) Then
                info.DepId = Convert.ToInt32(dr("DepId"))
            End If

            If Not Convert.IsDBNull(dr("CityId")) Then
                info.CityId = Convert.ToInt32(dr("CityId"))
            End If


            If Not Convert.IsDBNull(dr("CostCategoryId")) Then
                info.CostCategoryId = Convert.ToInt32(dr("CostCategoryId"))
            End If

            If Not Convert.IsDBNull(dr("UnitPrice")) Then
                info.UnitPrice = Convert.ToDecimal(dr("UnitPrice"))
            End If

            If Not Convert.IsDBNull(dr("Quantity")) Then
                info.Quantity = Convert.ToDecimal(dr("Quantity"))
            End If

            If Not Convert.IsDBNull(dr("TotalCost")) Then
                info.TotalCost = Convert.ToDecimal(dr("TotalCost"))
            End If


            If Not Convert.IsDBNull(dr("Description")) Then
                info.Description = dr("Description").ToString()
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_PricingDirectCostInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@SubProId", SqlDbType.Char), _
                                                                    New SqlParameter("@DepId", SqlDbType.Char), _
                                                                    New SqlParameter("@CityId", SqlDbType.Int), _
                                                                    New SqlParameter("@CostCategoryId", SqlDbType.Int), _
                                                                    New SqlParameter("@UnitPrice", SqlDbType.Decimal), _
                                                                    New SqlParameter("@Quantity", SqlDbType.Decimal), _
                                                                    New SqlParameter("@TotalCost", SqlDbType.Decimal), _
                                                                    New SqlParameter("@Description", SqlDbType.VarChar)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.SubProId
            parameters(2).Value = info.DepId
            parameters(3).Value = info.CityId
            parameters(4).Value = info.CostCategoryId
            parameters(5).Value = info.UnitPrice
            parameters(6).Value = info.Quantity
            parameters(7).Value = info.TotalCost
            parameters(8).Value = info.Description
            Return parameters
        End Function

        Public Function GetDirectCostInfoByCityIdDepIdSubProId(ByVal CityId As Integer, ByVal DepId As Integer, ByVal SubProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingDirectCostInfo.GetDirectCostInfoByCityIdDepIdSubProId
            Dim paramCityId As New SqlParameter("@CityId", SqlDbType.Char)
            paramCityId.Value = CityId

            Dim paramDepId As New SqlParameter("@DepId", SqlDbType.Char)
            paramDepId.Value = DepId

            Dim paramSubProId As New SqlParameter("@SubProId", SqlDbType.Char)
            paramSubProId.Value = SubProId

            Dim sql As String = "select * from [t_PMS_PricingDirectCost] where CityId = @CityId and DepId=@DepId and SubProId=@SubProId Order by CostCategoryId"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramCityId, paramDepId, paramSubProId)
            Dim info As PMS_PricingDirectCostInfo = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetSumTotalCostByProId(ByVal ProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingDirectCostInfo.GetSumTotalCostByProId
            Dim strSql As String

            strSql = " Select Sum(TotalCost) as TotalCost ,b.ProId AS proid from  t_PMS_PricingDirectCost a join t_pms_SubProjectInfo b " & _
                    " on a.subProId=b.Id and b.Status=0 where b.ProId='" + CStr(ProId) + "'" + "  Group by b.ProId"


            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, strSql)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace
