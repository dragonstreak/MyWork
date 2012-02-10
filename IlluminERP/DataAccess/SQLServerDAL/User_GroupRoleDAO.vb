
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class User_GroupRoleDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_GroupRole

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetGroupRoleInfoByGroupId(ByVal GroupId As Integer) As System.Data.DataSet Implements IDAL.IUser_GroupRole.GetGroupRoleInfoByGroupId
            Dim paramGroupId As New SqlParameter("@GroupId", SqlDbType.Int)
            paramGroupId.Value = GroupId
            Dim sql As String = "select * from [t_User_GroupRole] " & _
                                " where GroupId = @GroupId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramGroupId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetGroupRoleInfoById(ByVal Id As Integer) As Model.User_GroupRole Implements IDAL.IUser_GroupRole.GetGroupRoleInfoById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = Id
            Dim sql As String = "select * from [t_User_GroupRole] where ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As User_GroupRole = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToGroupRoleInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetGroupRoleInfoByRoleId(ByVal RoleId As Integer) As System.Data.DataSet Implements IDAL.IUser_GroupRole.GetGroupRoleInfoByRoleId
            Dim paramRoleId As New SqlParameter("@RoleId", SqlDbType.Int)
            paramRoleId.Value = RoleId
            Dim sql As String = "select * from [t_User_GroupRole] " & _
                                " where RoleId = @RoleId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramRoleId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Private Function MapRowToGroupRoleInfo(ByVal dr As DataRow) As User_GroupRole
            Dim info As New User_GroupRole

            info.ID = Convert.ToInt32(dr("ID"))
            info.RoleId = Convert.ToInt32(dr("RoleId"))
            info.GroupId = Convert.ToInt32(dr("GroupId"))

            Return info

        End Function

        Private Function GetParameters(ByVal info As User_GroupRole) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@RoleId", SqlDbType.Int), _
                                                                    New SqlParameter("@GroupId", SqlDbType.Int)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.RoleId
            parameters(2).Value = info.GroupId

            Return parameters
        End Function

        Public Function AddGroupInRole(ByVal info As Model.User_GroupRole) As Boolean Implements IDAL.IUser_GroupRole.AddGroupInRole
            Try


                Dim strSql As String
                strSql = "Insert into t_user_GroupRole (GroupId,RoleId) Values("
                strSql += "'" + info.GroupId.ToString + "',"
                strSql += "'" + info.RoleId.ToString + "')"
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

        Public Function DeleteRoleGroup(ByVal Info As Model.User_GroupRole) As Boolean Implements IDAL.IUser_GroupRole.DeleteRoleGroup
            Dim strSql As String

            strSql = " Delete t_user_GroupRole  "
            strSql += " Where RoleId ='" + Info.RoleId.ToString + "' and  GroupId='" + Info.GroupId.ToString + "'"

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

