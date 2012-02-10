Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL

    Friend Class PMS_UploadFileTypeDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_UploadFileType

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetFileTypeByID(ByVal ID As Integer) As Model.PMS_UploadFileType Implements IDAL.IPMS_UploadFileType.GetFileTypeByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_PMS_UploadFileType] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As PMS_UploadFileType = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToAOEInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetFileTypeInfo() As System.Data.DataSet Implements IDAL.IPMS_UploadFileType.GetFileTypeInfo
            Dim sql As String = "select * from [t_PMS_UploadFileType] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Private Function MapRowToAOEInfo(ByVal dr As DataRow) As PMS_UploadFileType
            Dim info As New PMS_UploadFileType
            info.ID = Convert.ToInt32(dr("ID"))
            info.FileType = dr("FileType").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.PMS_UploadFileType) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@FileType", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.FileType


            Return parameters
        End Function

    End Class
End Namespace

