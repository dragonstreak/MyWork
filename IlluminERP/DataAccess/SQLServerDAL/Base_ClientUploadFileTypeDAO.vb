
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components

Namespace SQLServerDAL
    Friend Class Base_ClientUploadFileTypeDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_ClientUploadFileType



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetClientUploadFileTypeById(ByVal ID As Integer) As Model.Base_ClientUploadFileType Implements IDAL.IBase_ClientUploadFileType.GetClientUploadFileTypeById
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_Base_ClientUploadFileType] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_ClientUploadFileType = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetClientUploadFileTypeInfo() As System.Data.DataSet Implements IDAL.IBase_ClientUploadFileType.GetClientUploadFileTypeInfo
            Dim sql As String = "select * from [t_Base_ClientUploadFileType] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_ClientUploadFileType
            Dim info As New Base_ClientUploadFileType
            info.ID = Convert.ToInt32(dr("ID"))
            info.ClientFileType = dr("ClientFileType").ToString()
            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_ClientUploadFileType) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ClientFileType", SqlDbType.Char)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.ClientFileType


            Return parameters
        End Function
    End Class
End Namespace
