Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class Client_ClientInfoGetWayDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IClient_ClientInfoGetWay






        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddClientInfoGetWayInfo(ByVal Info As Model.Client_ClientInfoGetWay) As Integer Implements IDAL.IClient_ClientInfoGetWay.AddClientInfoGetWayInfo
            Try

                Dim strSql As String

                strSql = "Insert into t_Client_ClientInfoGetWay(ClientId,WayTypeId,Description) Values("
                strSql += "'" + Info.ClientId.ToString + "',"
                strSql += "'" + Info.WayTypeId.ToString + "',"
                strSql += "'" + Info.Description.ToString + "')"
                strSql += " Select Id =@@Identity"

                Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(CommandType.Text, strSql)
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
                Return False

            Finally
            End Try
        End Function

        Public Function GetClientInfoGetWayByClientId(ByVal ClientId As Integer) As DataSet Implements IDAL.IClient_ClientInfoGetWay.GetClientInfoGetWayByClientId
            Dim paramClientId As New SqlParameter("@ClientId", SqlDbType.Char)
            paramClientId.Value = ClientId
            Dim sql As String = "select * from [t_Client_ClientInfoGetWay] where ClientId = @ClientId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramClientId)

            Return ds
        End Function

        Public Function GetClientInfoGetWayInfoByID(ByVal ID As Integer) As Model.Client_ClientInfoGetWay Implements IDAL.IClient_ClientInfoGetWay.GetClientInfoGetWayInfoByID
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_Client_ClientInfoGetWay] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As Client_ClientInfoGetWay = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function UpdateClientInfoGetWayInfo(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean Implements IDAL.IClient_ClientInfoGetWay.UpdateClientInfoGetWayInfo
            Dim strSql As String

            strSql = " Update t_Client_ClientInfoGetWay set "
            strSql += "ClientId='" + Info.ClientId.ToString + "'"
            strSql += ",WayTypeId='" + Info.WayTypeId.ToString + "'"
            strSql += ",Description='" + Info.Description.ToString + "'"
            strSql += " Where ClientId ='" + Info.ClientId.ToString + "'" + " and WayTypeId='" + CStr(Info.WayTypeId) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Client_ClientInfoGetWay
            Dim info As New Client_ClientInfoGetWay
            info.Id = Convert.ToInt32(dr("ID"))

            info.ClientId = Convert.ToInt32(dr("ClientId"))

            If Not Convert.IsDBNull(dr("WayTypeId")) Then
                info.WayTypeId = Convert.ToInt32(dr("WayTypeId"))
            End If


            If Not Convert.IsDBNull(dr("Description")) Then
                info.Description = dr("Description").ToString()
            End If


            Return info

        End Function

        Private Function GetParameters(ByVal info As Client_ClientInfoGetWay) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ClientId", SqlDbType.Int), _
                                                                    New SqlParameter("@WayTypeId", SqlDbType.Int), _
                                                                    New SqlParameter("@Description", SqlDbType.Char)}

            parameters(0).Value = info.Id
            parameters(1).Value = info.ClientId
            parameters(2).Value = info.WayTypeId
            parameters(3).Value = info.Description

            Return parameters
        End Function

        Public Function DeleteClientINfoGetWay(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean Implements IDAL.IClient_ClientInfoGetWay.DeleteClientINfoGetWay
            Dim strSql As String

            strSql = " Delete From t_Client_ClientInfoGetWay "
            strSql += " Where id ='" + CStr(Info.Id) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function IsExistRecord(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean Implements IDAL.IClient_ClientInfoGetWay.IsExistRecord

           
            Dim strSql As String = "select count(0) from  t_Client_ClientInfoGetWay where ClientId='" + Info.ClientId.ToString + "'" + " And WaytpyId = " '" + Info.WayTypeId + "'"""
            Dim count As Integer = 0
            count = Me.ExecuteScalar(CommandType.Text, strSql)
            If count = 1 Then
                Return True
            Else
                Return False
            End If

        End Function
    End Class
End Namespace


