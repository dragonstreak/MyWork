Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_UploadFileInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_UploadFileInfo

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddUploadFileInfo(ByVal info As Model.PMS_UploadFileInfo) As Integer Implements IDAL.IPMS_UploadFileInfo.AddUploadFileInfo
            Dim strSql As String
            strSql = "Insert into t_PMS_UploadFileInfo (ProId,FileName,FileType,FileFolder) Values("
            strSql += "'" + info.ProId.ToString + "',"
            strSql += "'" + info.FileName.ToString + "',"
            strSql += "'" + info.FileType.ToString + "',"
            strSql += "'" + info.FileFolder.ToString + "')"
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

        Public Function DeleteUploadFileInfo(ByVal Info As Model.PMS_UploadFileInfo) As Boolean Implements IDAL.IPMS_UploadFileInfo.DeleteUploadFileInfo
            Dim strSql As String

            strSql = " Delete From t_PMS_UploadFileInfo "
            strSql += " Where id ='" + CStr(Info.ID) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetUploadFileInfoById(ByVal Id As Integer) As Model.PMS_UploadFileInfo Implements IDAL.IPMS_UploadFileInfo.GetUploadFileInfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_UploadFileInfo] where  ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_UploadFileInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToClientInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetUploadFileInfoByProId(ByVal ProId As Integer) As System.Data.DataView Implements IDAL.IPMS_UploadFileInfo.GetUploadFileInfoByProId
            Dim paramId As New SqlParameter("@ProId", SqlDbType.Char)
            paramId.Value = ProId
            Dim sql As String = "select * from [t_PMS_UploadFileInfo] where  ProID = @ProId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_UploadFileInfo = Nothing

            If Not ds.Tables(0) Is Nothing Then
                Return ds.Tables(0).DefaultView

            Else
                Return Nothing
            End If

        End Function

        Private Function MapRowToClientInfo(ByVal dr As DataRow) As PMS_UploadFileInfo

            Dim info As New PMS_UploadFileInfo
            info.ID = Convert.ToInt32(dr("ID"))

            info.ProId = dr("ProId").ToString()


            If Not Convert.IsDBNull(dr("FileFolder")) Then
                info.FileFolder = dr("FileFolder").ToString()
            End If


            If Not Convert.IsDBNull(dr("FileName")) Then
                info.FileName = dr("FileName").ToString()
            End If

            If Not Convert.IsDBNull(dr("FileType")) Then
                info.FileName = Convert.ToInt32(dr("FileType"))
            End If


            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_UploadFileInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProId", SqlDbType.Int), _
                                                                    New SqlParameter("@FileName", SqlDbType.VarChar), _
                                                                    New SqlParameter("@FileType", SqlDbType.Int), _
                                                                    New SqlParameter("@Filefolder", SqlDbType.VarChar)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.ProId
            parameters(2).Value = info.FileName
            parameters(3).Value = info.FileType
            parameters(4).Value = info.FileFolder


            Return parameters
        End Function
    End Class
End Namespace
