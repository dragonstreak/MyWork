Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_RevenueDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_Revenue


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddProjectRevenue(ByVal info As Model.PMS_Revenue) As Integer Implements IDAL.IPMS_Revenue.AddProjectRevenue
            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_Revenue (ProId,Revenue,Profit,MBP,MBPReason) Values ("
                strSql += "'" + info.ProId.ToString + "',"
                strSql += "'" + info.Revenue.ToString + "',"
                strSql += "'" + info.Profit.ToString + "',"
                strSql += "'" + info.MBP.ToString + "',"
                strSql += "'" + info.MBPReason.ToString + "')"
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

        Public Function GetRevenueByProId(ByVal ProId As Integer) As Model.PMS_Revenue Implements IDAL.IPMS_Revenue.GetRevenueByProId
            Dim paramProId As New SqlParameter("@ProId", SqlDbType.Char)
            paramProId.Value = ProId
            Dim sql As String = "select * from [t_PMS_Revenue] where  ProId = @ProId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramProId)
            Dim info As PMS_Revenue = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function IsExitRecord(ByVal ProId As Integer) As Boolean Implements IDAL.IPMS_Revenue.IsExitRecord
            Dim sql As String
            sql = "select * from [t_PMS_Revenue] where ProId  = '" + CStr(ProId) + "'" 

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

        Public Function UpdateProjectRevenue(ByVal Info As Model.PMS_Revenue) As Boolean Implements IDAL.IPMS_Revenue.UpdateProjectRevenue
            Dim factory As New SqlServerFactory
            Dim strSql As String
            factory.BeginTransaction()

            Try
                strSql = " Update t_PMS_Revenue set "
                strSql += "Profit='" + Info.Profit.ToString + "'"
                strSql += ",Revenue='" + Info.Revenue.ToString + "'"
                strSql += ",MBP='" + Info.MBP.ToString + "'"
                strSql += ",MBPReason='" + Info.MBPReason.ToString + "'"
                strSql += " Where ProId ='" + Info.ProId.ToString + "'"

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

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_Revenue

            Dim info As New PMS_Revenue
            info.Id = Convert.ToInt32(dr("ID"))
            info.ProId = Convert.ToInt32(dr("ProId"))
         

            If Not Convert.IsDBNull(dr("Revenue")) Then
                info.Revenue = Convert.ToDecimal(dr("Revenue"))
            End If

            If Not Convert.IsDBNull(dr("Profit")) Then
                info.Profit = Convert.ToDecimal(dr("Profit"))
            End If

            If Not Convert.IsDBNull(dr("MBP")) Then
                info.MBP = Convert.ToDecimal(dr("MBP"))
            End If

            If Not Convert.IsDBNull(dr("MBPReason")) Then
                info.MBPReason = Convert.ToString(dr("MBPReason"))
            End If


            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_Revenue) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProId", SqlDbType.Int), _
                                                                    New SqlParameter("@Revenue", SqlDbType.Decimal), _
                                                                    New SqlParameter("@Profit", SqlDbType.Decimal), _
                                                                    New SqlParameter("@MBP", SqlDbType.Decimal), _
                                                                    New SqlParameter("@MBPReason", SqlDbType.Decimal)}

            parameters(0).Value = info.Id
            parameters(1).Value = info.ProId
            parameters(2).Value = info.Revenue
            parameters(3).Value = info.Profit
            parameters(4).Value = info.MBP
            parameters(5).Value = info.MBPReason



            Return parameters
        End Function
    End Class
End Namespace
