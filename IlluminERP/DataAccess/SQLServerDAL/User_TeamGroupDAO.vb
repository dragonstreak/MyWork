
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class User_TeamGroupDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_TeamGroup






        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub



        Public Function GetTeamGroupByGroupId(ByVal GroupId As Integer) As System.Data.DataSet Implements IDAL.IUser_TeamGroup.GetTeamGroupByGroupId
            Dim paramGroupId As New SqlParameter("@GroupId", SqlDbType.Int)
            paramGroupId.Value = GroupId
            Dim sql As String = "select * from [t_User_TeamGroup] " & _
                                " where GroupId = @GroupId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramGroupId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetTeamGroupById(ByVal intId As Integer) As Model.User_TeamGroup Implements IDAL.IUser_TeamGroup.GetTeamGroupById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = intId
            Dim sql As String = "select * from [t_User_UserGroup] where ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As User_TeamGroup = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToTeamGroupInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetTeamGroupByTeamId(ByVal TeamId As Integer) As System.Data.DataSet Implements IDAL.IUser_TeamGroup.GetTeamGroupByTeamId
            Dim paramTeamId As New SqlParameter("@TeamId", SqlDbType.Int)
            paramTeamId.Value = TeamId
            Dim sql As String = "select * from [t_User_TeamGroup] " & _
                                " where TeamId = @TeamId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramTeamId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Private Function MapRowToTeamGroupInfo(ByVal dr As DataRow) As User_TeamGroup
            Dim info As New User_TeamGroup

            info.ID = Convert.ToInt32(dr("ID"))
            info.TeamId = Convert.ToInt32(dr("TeamID"))
            info.GroupId = Convert.ToInt32(dr("GroupId"))

            Return info

        End Function

        Private Function GetParameters(ByVal info As User_TeamGroup) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@TeamID", SqlDbType.Int), _
                                                                    New SqlParameter("@GroupId", SqlDbType.Int)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.TeamId
            parameters(2).Value = info.GroupId

            Return parameters
        End Function

        Public Function AddTeamInGroup(ByVal info As Model.User_TeamGroup) As Boolean Implements IDAL.IUser_TeamGroup.AddTeamInGroup
            Try


                Dim strSql As String
                strSql = "Insert into t_user_teamGroup (TeamId,GroupId) Values("
                strSql += "'" + info.TeamId.ToString + "',"
                strSql += "'" + info.GroupId.ToString + "')"
                strSql += " Select Id =@@Identity"
                Dim count As Integer
                count = ExecuteNonQuery(CommandType.Text, strSql)
                If count = 1 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try

        End Function

        Public Function DeleteGroupTeam(ByVal Info As Model.User_TeamGroup) As Boolean Implements IDAL.IUser_TeamGroup.DeleteGroupTeam
            Dim strSql As String

            strSql = " Delete t_user_teamGroup  "
            strSql += " Where GroupId ='" + Info.GroupId.ToString + "' and  TeamID='" + Info.TeamId.ToString + "'"

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
