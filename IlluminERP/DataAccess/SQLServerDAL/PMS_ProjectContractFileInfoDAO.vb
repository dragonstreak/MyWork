Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_ProjectContractFileInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_ProjectContractFileInfo
        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddProjectContractFileInfo(ByVal info As Model.PMS_ProjectContractFileInfo) As Integer Implements IDAL.IPMS_ProjectContractFileInfo.AddProjectContractFileInfo
            Dim strSql As String
            strSql = "Insert into t_PMS_ProjectContractFileInfo (ProId,FileName,FileFolder) Values("
            strSql += "'" + info.ProId.ToString + "',"
            strSql += "'" + info.FileName.ToString + "',"
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

        Public Function DeleteProjectContractFileInfo(ByVal Info As Model.PMS_ProjectContractFileInfo) As Boolean Implements IDAL.IPMS_ProjectContractFileInfo.DeleteProjectContractFileInfo
            Dim strSql As String

            strSql = " Delete From t_PMS_ProjectContractFileInfo "
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

        Public Function GetProjectContractFileInfoByProId(ByVal ProId As Integer) As System.Data.DataView Implements IDAL.IPMS_ProjectContractFileInfo.GetProjectContractFileInfoByProId
            Dim paramId As New SqlParameter("@ProId", SqlDbType.Char)
            paramId.Value = ProId
            Dim sql As String = "select * from [t_PMS_ProjectContractFileInfo] where  ProID = @ProId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_ProjectContractFileInfo = Nothing

            If Not ds.Tables(0) Is Nothing Then
                Return ds.Tables(0).DefaultView

            Else
                Return Nothing
            End If


        End Function

        Public Function GetProjectContractFileInfoById(ByVal Id As Integer) As Model.PMS_ProjectContractFileInfo Implements IDAL.IPMS_ProjectContractFileInfo.GetProjectContractFileInfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_ProjectContractFileInfo] where  ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_ProjectContractFileInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToClientInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToClientInfo(ByVal dr As DataRow) As PMS_ProjectContractFileInfo

            Dim info As New PMS_ProjectContractFileInfo
            info.ID = Convert.ToInt32(dr("ID"))

            info.ProId = dr("ProId").ToString()

         
            If Not Convert.IsDBNull(dr("FileFolder")) Then
                info.FileFolder = dr("FileFolder").ToString()
            End If


            If Not Convert.IsDBNull(dr("FileName")) Then
                info.FileName = dr("FileName").ToString()
            End If

          


            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_ProjectContractFileInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProId", SqlDbType.Int), _
                                                                    New SqlParameter("@FileName", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Filefolder", SqlDbType.VarChar)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.ProId
            parameters(2).Value = info.FileName
            parameters(3).Value = info.FileFolder


            Return parameters
        End Function
    End Class
End Namespace
