Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class PMS_PricingTimeCostDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_PricingTimeCost




        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddPricingTimeCost(ByVal Info As Model.PMS_PricingTimeCost) As Integer Implements IDAL.IPMS_PricingTimeCost.AddPricingTimeCost
            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_PricingTimeCost (SubProId,DepId,CityId,PositionId,StageId,Rate,Amount,TotalCost) Values ("
                strSql += "'" + Info.SubProId.ToString + "',"
                strSql += "'" + Info.DepId.ToString + "',"
                strSql += "'" + Info.CityId.ToString + "',"
                strSql += "'" + Info.PositionId.ToString + "',"
                strSql += "'" + Info.StageId.ToString + "',"
                strSql += "'" + Info.Rate.ToString + "',"
                strSql += "'" + Info.Amount.ToString + "',"
                strSql += "'" + Info.TotalCost.ToString + "')"
                strSql += " select ID=@@Identity"


                Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, strSql)
                If dr.Read Then
                    Info.Id = Convert.ToInt32(dr("Id"))
                    dr.Close()
                    dr = Nothing
                    Return Info.Id
                Else
                    Return 0
                End If

            Catch ex As Exception
                Dim str As String = ex.Message
            End Try
        End Function

        Public Function DelPricingTimeCost(ByVal info As Model.PMS_PricingTimeCost) As Boolean Implements IDAL.IPMS_PricingTimeCost.DelPricingTimeCost
            Dim strSql As String

            strSql = " Delete From t_PMS_PricingTimeCost "
            strSql += " Where Id ='" + CStr(info.Id) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetPricingTimeCostById(ByVal Id As Integer) As Model.PMS_PricingTimeCost Implements IDAL.IPMS_PricingTimeCost.GetPricingTimeCostById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_PricingTimeCost] where  ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_PricingTimeCost = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetPricingTimeCostBySubProidCityIdDepId(ByVal SubProid As Integer, ByVal CityId As Integer, ByVal DepId As Integer) As DataSet Implements IDAL.IPMS_PricingTimeCost.GetPricingTimeCostBySubProidCityIdDepId
            Dim paramSubProid As New SqlParameter("@SubProid", SqlDbType.Char)
            paramSubProid.Value = SubProid

            Dim paramCityId As New SqlParameter("@CityId", SqlDbType.Char)
            paramCityId.Value = CityId

            Dim paramDepId As New SqlParameter("@DepId", SqlDbType.Char)
            paramDepId.Value = DepId

            Dim sql As String = "select * from [t_PMS_PricingTimeCost] where SubProId  = @SubProid and CityId=@CityId and DepID=@DepId"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramSubProid, paramCityId, paramDepId)
            Dim info As PMS_PricingTimeCost = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Public Function ModifyPricingTimeCost(ByVal info As Model.PMS_PricingTimeCost) As Boolean Implements IDAL.IPMS_PricingTimeCost.ModifyPricingTimeCost
            Dim factory As New SqlServerFactory
            Dim strSql As String
            factory.BeginTransaction()

            Try
                strSql = " Update t_PMS_PricingTimeCost set "
                strSql += "Amount='" + info.Amount.ToString + "'"
                strSql += ",TotalCost='" + info.TotalCost.ToString + "'"
                strSql += " Where SubProId ='" + info.SubProId.ToString + "'"
                strSql += " And DepId ='" + info.DepId.ToString + "'"
                strSql += " And CityId ='" + info.CityId.ToString + "'"
                strSql += " And PositionId ='" + info.PositionId.ToString + "'"
                strSql += " And stageId ='" + info.StageId.ToString + "'"

                Dim count As Integer = 0

                count = Me.ExecuteNonQuery(CommandType.Text, strSql)
                If count = 1 Then
                    Return True
                Else
                    Return False
                End If
                factory.Commit()
                Return True
            Catch ex As Exception
                factory.Rollback()
                Return False

            End Try
        End Function
        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_PricingTimeCost

            Dim info As New PMS_PricingTimeCost
            info.Id = Convert.ToInt32(dr("ID"))
            info.SubProId = Convert.ToInt32(dr("SubProId"))
            info.CityId = Convert.ToInt32(dr("CityId"))
            info.DepId = Convert.ToInt32(dr("DepId"))
            info.PositionId = Convert.ToInt32(dr("PositionId"))

            info.StageId = Convert.ToInt32(dr("StageId"))

            If Not Convert.IsDBNull(dr("Rate")) Then
                info.Rate = Convert.ToDecimal(dr("Rate"))
            End If

            If Not Convert.IsDBNull(dr("Amount")) Then
                info.Amount = Convert.ToDecimal(dr("Amount"))
            End If


            If Not Convert.IsDBNull(dr("TotalCost")) Then
                info.TotalCost = Convert.ToDecimal(dr("TotalCost"))
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_PricingTimeCost) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@SubProId", SqlDbType.Int), _
                                                                    New SqlParameter("@CityId", SqlDbType.Int), _
                                                                    New SqlParameter("@DepId", SqlDbType.Int), _
                                                                    New SqlParameter("@PositionId", SqlDbType.Int), _
                                                                    New SqlParameter("@StageId", SqlDbType.Int), _
                                                                    New SqlParameter("@Rate", SqlDbType.Decimal), _
                                                                    New SqlParameter("@Amount", SqlDbType.Decimal), _
                                                                    New SqlParameter("@TotalCost", SqlDbType.Decimal)}

            parameters(0).Value = info.Id
            parameters(1).Value = info.SubProId
            parameters(2).Value = info.CityId
            parameters(3).Value = info.DepId
            parameters(4).Value = info.PositionId
            parameters(5).Value = info.StageId
            parameters(6).Value = info.Rate
            parameters(7).Value = info.Amount
            parameters(8).Value = info.TotalCost


            Return parameters
        End Function

        Public Function GetPricingTimeCostBySubProidCityIdDepIdStageId(ByVal SubProid As Integer, ByVal CityId As Integer, ByVal DepId As Integer, ByVal StageId As Integer, ByVal PositionId As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingTimeCost.GetPricingTimeCostBySubProidCityIdDepIdStageId
            Dim paramSubProid As New SqlParameter("@SubProid", SqlDbType.Char)
            paramSubProid.Value = SubProid

            Dim paramCityId As New SqlParameter("@CityId", SqlDbType.Char)
            paramCityId.Value = CityId

            Dim paramDepId As New SqlParameter("@DepId", SqlDbType.Char)
            paramDepId.Value = DepId

            Dim paramStageId As New SqlParameter("@StageId", SqlDbType.Char)
            paramStageId.Value = StageId

            Dim paramPositionId As New SqlParameter("@PositionId", SqlDbType.Char)
            paramPositionId.Value = PositionId


            Dim sql As String = "select * from [t_PMS_PricingTimeCost] where SubProId  = @SubProid and CityId=@CityId and DepID=@DepId and StageId=@StageId and PositionId=@PositionId"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramSubProid, paramCityId, paramDepId, paramStageId, paramPositionId)
            Dim info As PMS_PricingTimeCost = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function IsExistRecord(ByVal Info As Model.PMS_PricingTimeCost) As Boolean Implements IDAL.IPMS_PricingTimeCost.IsExistRecord



            Dim sql As String
            sql = "select * from [t_PMS_PricingTimeCost] where SubProId  = '" + CStr(Info.SubProId) + "'" & _
                "  And  CityId = '" + Info.CityId.ToString + "'" & _
                "  And  DepID = '" + Info.DepId.ToString + "'" & _
                "  And  StageId = '" + Info.StageId.ToString + "'" & _
                "  And  PositionId = '" + Info.PositionId.ToString + "'"

            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            If Not (ds Is Nothing) Then
                Dim dt As DataTable = ds.Tables(0)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        End Function

        Public Function GetSumTotalCostByProId(ByVal ProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingTimeCost.GetSumTotalCostByProId
            Dim strSql As String

            strSql = " Select Sum(TotalCost) as TotalCost ,b.ProId AS proid from  t_PMS_PricingTimeCost a join t_pms_SubProjectInfo b " & _
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
