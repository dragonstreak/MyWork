Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class Client_ClientUploadFileDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IClient_ClientUploadFile




        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddClientUploadFileInfo(ByVal Info As Model.Client_ClientUploadFile) As Integer Implements IDAL.IClient_ClientUploadFile.AddClientUploadFileInfo
            Try

                Dim strSql As String

                strSql = "Insert into t_Client_ClientUploadFile(ClientId,FileTypeId,FileName,FilePath) Values("
                strSql += "'" + Info.ClientId.ToString + "',"
                strSql += "'" + Info.FileTypeId.ToString + "',"
                strSql += "'" + Info.FileName.ToString + "',"
                strSql += "'" + Info.FilePath.ToString + "')"
                strSql += " Select Id =@@Identity"

                Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(CommandType.Text, strSql)
                If dr.Read Then
                    Info.Id = Convert.ToInt32(dr("Id"))
                    dr.Close()
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

        Public Function GetClientUploadFileInfoByClientId(ByVal ClientId As Integer) As DataSet Implements IDAL.IClient_ClientUploadFile.GetClientUploadFileInfoByClientId
            Dim paramClientId As New SqlParameter("@ClientId", SqlDbType.Char)
            paramClientId.Value = ClientId
            Dim sql As String = "select * from [t_Client_ClientUploadFile] where ClientId = @ClientId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramClientId)
            Dim info As Client_ClientUploadFile = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Public Function GetClientUploadFileInfoByID(ByVal ID As Integer) As Model.Client_ClientUploadFile Implements IDAL.IClient_ClientUploadFile.GetClientUploadFileInfoByID
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_Client_ClientUploadFile] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As Client_ClientUploadFile = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function UpdateClientUploadFileInfo(ByVal Info As Model.Client_ClientUploadFile) As Boolean Implements IDAL.IClient_ClientUploadFile.UpdateClientUploadFileInfo
            Dim strSql As String

            strSql = " Update t_Client_ClientUploadFile set "
            strSql += "ClientId='" + Info.ClientId.ToString + "'"
            strSql += ",FileTypeId='" + Info.FileTypeId.ToString + "'"
            strSql += ",FileName='" + Info.FileName.ToString + "'"
            strSql += ",FilePath='" + Info.FilePath.ToString + "'"
            strSql += " Where Id ='" + Info.Id.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Client_ClientUploadFile
            Dim info As New Client_ClientUploadFile
            info.Id = Convert.ToInt32(dr("ID"))

            info.ClientId = Convert.ToInt32(dr("ClientId"))

            If Not Convert.IsDBNull(dr("FileTypeId")) Then
                info.FileTypeId = Convert.ToInt32(dr("FileTypeId"))
            End If


            If Not Convert.IsDBNull(dr("FileName")) Then
                info.FileName = dr("FileName").ToString()
            End If

            If Not Convert.IsDBNull(dr("FilePath")) Then
                info.FilePath = dr("FilePath").ToString()
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As Client_ClientUploadFile) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ClientId", SqlDbType.Int), _
                                                                    New SqlParameter("@FileTypeId", SqlDbType.Int), _
                                                                    New SqlParameter("@FileName", SqlDbType.Char), _
                                                                    New SqlParameter("@FilePath", SqlDbType.Char)}

            parameters(0).Value = info.Id
            parameters(1).Value = info.ClientId
            parameters(2).Value = info.FileTypeId
            parameters(3).Value = info.FileName
            parameters(4).Value = info.FilePath



            Return parameters
        End Function

        Public Function DeleteClintUploadFile(ByVal Id As Integer) As Boolean Implements IDAL.IClient_ClientUploadFile.DeleteClintUploadFile
            Dim strSql As String

            strSql = " Delete From Client_ClientUploadFileDAO "
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
