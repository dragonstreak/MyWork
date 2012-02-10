Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_PricingSubContractDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_PricingSubContract


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddPricingSubContract(ByVal info As Model.PMS_PricingSubContract) As Integer Implements IDAL.IPMS_PricingSubContract.AddPricingSubContract
            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_PricingSubContract (SubProId,DepId,PricingCityId,SubCity,SubName,UnitPrice,Amount,TotalCost) Values ("
                strSql += "'" + info.SubProId.ToString + "',"
                strSql += "'" + info.DepId.ToString + "',"
                strSql += "'" + info.PricingCityId.ToString + "',"
                strSql += "'" + info.SubCity.ToString + "',"
                strSql += "'" + info.SubName.ToString + "',"
                strSql += "'" + info.UnitPrice.ToString + "',"
                strSql += "'" + info.Amount.ToString + "',"
                strSql += "'" + info.TotalCost.ToString + "')"
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

        Public Function DeletePricingSubContract(ByVal Id As Integer) As Boolean Implements IDAL.IPMS_PricingSubContract.DeletePricingSubContract
            Dim strSql As String

            strSql = " Delete From t_PMS_PricingSubContract "
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

        Public Function GetPricingSubContractById(ByVal Id As Integer) As Model.PMS_PricingSubContract Implements IDAL.IPMS_PricingSubContract.GetPricingSubContractById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_PricingSubContract] where  ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_PricingSubContract = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetPricingSubContractBySubProid(ByVal SubProid As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingSubContract.GetPricingSubContractBySubProid
            Dim paramSubProid As New SqlParameter("@SubProid", SqlDbType.Char)
            paramSubProid.Value = SubProid

            Dim sql As String = "select * from [t_PMS_PricingSubContract] where SubProId  = @SubProid order by DepId,PricingCityId"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramSubProid)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetPricingSubContractBySubProidDepId(ByVal SubProid As Integer, ByVal DepId As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingSubContract.GetPricingSubContractBySubProidDepId
            Dim paramSubProid As New SqlParameter("@SubProid", SqlDbType.Char)
            paramSubProid.Value = SubProid

            Dim paramDepId As New SqlParameter("@DepId", SqlDbType.Char)
            paramDepId.Value = DepId

            Dim sql As String = "select * from [t_PMS_PricingSubContract] where SubProId  = @SubProid  and DepID=@DepId"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramSubProid, paramDepId)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_PricingSubContract

            Dim info As New PMS_PricingSubContract
            info.Id = Convert.ToInt32(dr("ID"))
            info.SubProId = Convert.ToInt32(dr("SubProId"))
            info.PricingCityId = Convert.ToInt32(dr("PricingCityId"))
            info.DepId = Convert.ToInt32(dr("DepId"))
            info.SubCity = Convert.ToString(dr("SubCity"))
            info.SubName = Convert.ToString(dr("SubName"))




            If Not Convert.IsDBNull(dr("UnitPrice")) Then
                info.UnitPrice = Convert.ToDecimal(dr("UnitPrice"))
            End If

            If Not Convert.IsDBNull(dr("Amount")) Then
                info.Amount = Convert.ToDecimal(dr("Amount"))
            End If


            If Not Convert.IsDBNull(dr("TotalCost")) Then
                info.TotalCost = Convert.ToDecimal(dr("TotalCost"))
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_PricingSubContract) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@SubProId", SqlDbType.Int), _
                                                                    New SqlParameter("@PricingCityId", SqlDbType.Int), _
                                                                    New SqlParameter("@DepId", SqlDbType.Int), _
                                                                    New SqlParameter("@SubCity", SqlDbType.VarChar), _
                                                                    New SqlParameter("@SubName", SqlDbType.VarChar), _
                                                                    New SqlParameter("@UnitPrice", SqlDbType.Decimal), _
                                                                    New SqlParameter("@Amount", SqlDbType.Decimal), _
                                                                    New SqlParameter("@TotalCost", SqlDbType.Decimal)}

            parameters(0).Value = info.Id
            parameters(1).Value = info.SubProId
            parameters(2).Value = info.PricingCityId
            parameters(3).Value = info.DepId
            parameters(4).Value = info.SubCity
            parameters(5).Value = info.SubName
            parameters(6).Value = info.UnitPrice
            parameters(7).Value = info.Amount
            parameters(8).Value = info.TotalCost


            Return parameters
        End Function

        Public Function GetSumTotalCostByProId(ByVal ProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingSubContract.GetSumTotalCostByProId
            Dim strSql As String

            strSql = " Select Sum(TotalCost) as TotalCost ,b.ProId AS proid from   t_PMS_PricingSubContract a join t_pms_SubProjectInfo b " & _
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
