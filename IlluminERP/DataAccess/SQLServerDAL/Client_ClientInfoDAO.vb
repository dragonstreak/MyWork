

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class Client_ClientInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IClient_ClientInfo





        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetClientInfo() As System.Data.DataSet Implements IDAL.IClient_ClientInfo.GetClientInfo
            Dim sql As String = "select * from [t_Client_ClientInfo] Where Status <> 9 Order by SortType,E_Name"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetClientInfoByClientType(ByVal ClientType As Integer) As System.Data.DataView Implements IDAL.IClient_ClientInfo.GetClientInfoByClientType
            Dim paramClientType As New SqlParameter("@ClientType", SqlDbType.Char)
            paramClientType.Value = ClientType

            Dim sql As String = "select * from [t_Client_ClientInfo] where Status <> 9 And ClientType  = @ClientType  Order by E_name,C_Name "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramClientType)

            If Not ds.Tables(0) Is Nothing Then
                Return ds.Tables(0).DefaultView

            Else
                Return Nothing
            End If
        End Function

        Public Function GetClientInfoByID(ByVal ID As Integer) As Model.Client_ClientInfo Implements IDAL.IClient_ClientInfo.GetClientInfoByID
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_Client_ClientInfo] where Status <> 9 And ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As Client_ClientInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToClientInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToClientInfo(ByVal dr As DataRow) As Client_ClientInfo
            Dim info As New Client_ClientInfo
            info.ID = Convert.ToInt32(dr("ID"))

            info.ClientCode = dr("ClientCode").ToString()

            If Not Convert.IsDBNull(dr("FullName")) Then
                info.FullName = dr("FullName").ToString()
            End If


            If Not Convert.IsDBNull(dr("C_Name")) Then
                info.C_Name = dr("C_Name").ToString()
            End If

            If Not Convert.IsDBNull(dr("E_Name")) Then
                info.E_Name = dr("E_Name").ToString()
            End If


            If Not Convert.IsDBNull(dr("ClientType")) Then
                info.ClientType = Convert.ToInt32(dr("ClientType"))
            End If

            If Not Convert.IsDBNull(dr("Status")) Then
                info.Status = Convert.ToInt32(dr("Status"))
            End If

            If Not Convert.IsDBNull(dr("SortType")) Then
                info.SortType = Convert.ToInt32(dr("SortType"))
            End If


            Return info

        End Function

        Private Function GetParameters(ByVal info As Client_ClientInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ClientCode", SqlDbType.Char), _
                                                                    New SqlParameter("@FullName", SqlDbType.Char), _
                                                                    New SqlParameter("@C_Name", SqlDbType.Char), _
                                                                    New SqlParameter("@E_Name", SqlDbType.Char), _
                                                                    New SqlParameter("@ClientType", SqlDbType.Int), _
                                                                    New SqlParameter("@Status", SqlDbType.Int), _
                                                                    New SqlParameter("@SortType", SqlDbType.Int)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.ClientCode
            parameters(2).Value = info.FullName
            parameters(3).Value = info.C_Name
            parameters(4).Value = info.E_Name
            parameters(5).Value = info.ClientType
            parameters(6).Value = info.Status
            parameters(7).Value = info.SortType

            Return parameters
        End Function

        Public Function AddClientInfo(ByVal info As Model.Client_ClientInfo) As Integer Implements IDAL.IClient_ClientInfo.AddClientInfo

            Dim strSql As String
            strSql = "Insert into t_Client_ClientInfo (ClientCode,FullName,E_Name,C_Name,KeyAccount,ClientType,sortType,Status) Values("
            strSql += "'" + info.ClientCode.ToString + "',"
            strSql += "'" + info.FullName.ToString + "',"
            strSql += "'" + info.E_Name.ToString + "',"
            strSql += "'" + info.C_Name.ToString + "',"
            strSql += "'" + info.KeyAccount.ToString + "',"
            strSql += "'" + info.ClientType.ToString + "',"
            strSql += "'" + info.SortType.ToString + "',"
            strSql += "'" + info.Status.ToString + "')"
            strSql += " Select Id =@@Identity"


            Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, strSql)
            If dr.Read Then
                info.ID = Convert.ToInt32(dr("Id"))
                dr.Close()
                dr = Nothing
                Return info.ID
            Else
                Return 0
            End If


        End Function

        Public Function UpdateClientInfo(ByVal Info As Model.Client_ClientInfo) As Boolean Implements IDAL.IClient_ClientInfo.UpdateClientInfo
            Dim strSql As String

            strSql = " Update t_Client_ClientInfo set "
            strSql += "ClientCode='" + Info.ClientCode.ToString + "'"
            strSql += ",FullName='" + Info.FullName.ToString + "'"
            strSql += ",E_Name='" + Info.E_Name.ToString + "'"
            strSql += ",C_Name='" + Info.C_Name.ToString + "'"
            strSql += ",KeyAccount='" + Info.KeyAccount.ToString + "'"
            strSql += ",ClientType='" + Info.ClientType.ToString + "'"
            strSql += ",SortType='" + Info.SortType.ToString + "'"
            strSql += ",Status='" + Info.Status.ToString + "'"
            strSql += " Where Id ='" + Info.ID.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function IsExistClientByCode(ByVal ClientCode As String) As Boolean Implements IDAL.IClient_ClientInfo.IsExistClientByCode
            Dim paramClientCode As SqlParameter = New SqlParameter("@ClientCode", SqlDbType.Char)
            paramClientCode.Value = ClientCode
            Dim sql As String = "select count(0) from [t_Client_ClientInfo] where Status <> 9 and ClientCode = @ClientCode "
            Dim count As Integer = 0
            count = ExecuteScalar(CommandType.Text, sql, paramClientCode)
            If count = 1 Then
                Return True
            Else
                Return False
            End If
        End Function


        Public Function IsExistClient(ByVal info As Model.Client_ClientInfo) As Boolean Implements IDAL.IClient_ClientInfo.IsExistClient
            Dim strEName As String
            Dim strCName As String
            strEName = info.E_Name
            strCName = info.C_Name
            Dim paramE_Name As SqlParameter = New SqlParameter("@E_Name", SqlDbType.Char)
            paramE_Name.Value = strEName
            Dim paramC_Name As SqlParameter = New SqlParameter("@C_Name", SqlDbType.Char)
            paramC_Name.Value = strCName


            Dim sql As String = "select count(0) from [t_Client_ClientInfo] where Status<>9 And E_Name = @E_Name or C_Name = @C_Name"
            Dim count As Integer = 0
            count = ExecuteScalar(CommandType.Text, sql, paramE_Name, paramC_Name)
            If count > 1 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function UpdateClientStatus(ByVal Id As Integer) As Boolean Implements IDAL.IClient_ClientInfo.UpdateClientStatus
            Dim strSql As String

            strSql = " Update t_Client_ClientInfo set "
            strSql += " Status=1"
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
    End Class
End Namespace
