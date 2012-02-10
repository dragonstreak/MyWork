
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class User_UserGroupDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_UserGroup





        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function GetUserGroupByGroupId(ByVal GroupId As Integer) As System.Data.DataSet Implements IDAL.IUser_UserGroup.GetUserGroupByGroupId
            Dim paramGroupId As New SqlParameter("@GroupId", SqlDbType.Int)
            paramGroupId.Value = GroupId
            Dim sql As String = "select * from [t_User_UserGroup] " & _
                                " where GroupId = @GroupId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramGroupId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetUserGroupById(ByVal intId As Integer) As Model.User_UserGroup Implements IDAL.IUser_UserGroup.GetUserGroupById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = intId
            Dim sql As String = "select * from [t_User_UserGroup] where ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As User_UserGroup = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToUserGroupInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToUserGroupInfo(ByVal dr As DataRow) As User_UserGroup
            Dim info As New User_UserGroup

            info.ID = Convert.ToInt32(dr("ID"))
            info.UserID = Convert.ToInt32(dr("UserID"))
            info.GroupId = Convert.ToInt32(dr("GroupId"))

            Return info

        End Function

        Private Function GetParameters(ByVal info As User_UserGroup) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@UserID", SqlDbType.Int), _
                                                                    New SqlParameter("@GroupId", SqlDbType.Int)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.UserID
            parameters(2).Value = info.GroupId

            Return parameters
        End Function

        Public Function AddUserInGroup(ByVal info As Model.User_UserGroup) As Boolean Implements IDAL.IUser_UserGroup.AddUserInGroup
            Try


                Dim strSql As String
                strSql = "Insert into t_user_UserGroup (UserId,GroupId) Values("
                strSql += "'" + info.UserID.ToString + "',"
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

        Public Function DeleteGroupUser(ByVal Info As Model.User_UserGroup) As Boolean Implements IDAL.IUser_UserGroup.DeleteGroupUser
            Dim strSql As String

            strSql = " Delete t_user_UserGroup  "
            strSql += " Where GroupId ='" + Info.GroupId.ToString + "' and  UserId='" + Info.UserID.ToString + "'"

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

