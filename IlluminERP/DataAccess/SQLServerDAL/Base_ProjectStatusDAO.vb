Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL

    Friend Class Base_ProjectStatusDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_ProjectStatus




        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_ProjectStatus
            Dim info As New Base_ProjectStatus
            info.ID = Convert.ToInt32(dr("ID"))
            info.ProjctStatus = dr("ProjectStatus").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_ProjectStatus) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProjectStatus", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.ProjctStatus


            Return parameters
        End Function

        Public Function GetProjectStatusInfo() As System.Data.DataSet Implements IDAL.IBase_ProjectStatus.GetProjectStatusInfo
            Dim sql As String = "select * from [t_base_ProjectStatus] Where id<=4 order by Id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetProjectStatusInfoById(ByVal ID As Integer) As Model.Base_ProjectStatus Implements IDAL.IBase_ProjectStatus.GetProjectStatusInfoById
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_ProjectStatus] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_ProjectStatus = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetProjectOngoingStatusInfo() As System.Data.DataSet Implements IDAL.IBase_ProjectStatus.GetProjectOngoingStatusInfo
            Dim sql As String = "select * from [t_base_ProjectStatus] Where id>=4 order by Id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function
    End Class
End Namespace
