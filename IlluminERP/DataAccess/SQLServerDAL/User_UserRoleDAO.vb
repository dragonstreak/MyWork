Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class User_UserRoleDAO
        Inherits BaseSqlServerDAO

        Implements DataAccess.IDAL.IUser_UserRole




        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub



        Public Function GetUserRoleInfoById(ByVal Id As Integer) As Model.User_UserRole Implements IDAL.IUser_UserRole.GetUserRoleInfoById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = Id
            Dim sql As String = "select * from [t_User_GroupRole] where ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As User_UserRole = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToUserRoleInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetUserRoleInfoByRoleId(ByVal RoleId As Integer) As System.Data.DataSet Implements IDAL.IUser_UserRole.GetUserRoleInfoByRoleId
            Dim paramRoleId As New SqlParameter("@RoleId", SqlDbType.Int)
            paramRoleId.Value = RoleId
            Dim sql As String = "select * from [t_User_UserRole] " & _
                                " where RoleId = @RoleId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramRoleId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Private Function MapRowToUserRoleInfo(ByVal dr As DataRow) As User_UserRole
            Dim info As New User_UserRole

            info.ID = Convert.ToInt32(dr("ID"))
            info.RoleId = Convert.ToInt32(dr("RoleId"))
            info.Userid = Convert.ToInt32(dr("Userid"))

            Return info

        End Function

        Private Function GetParameters(ByVal info As User_UserRole) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@RoleId", SqlDbType.Int), _
                                                                    New SqlParameter("@Userid", SqlDbType.Int)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.RoleId
            parameters(2).Value = info.Userid

            Return parameters
        End Function

        Public Function GetUserRoleInfoByUserId(ByVal UserId As Integer) As System.Data.DataSet Implements IDAL.IUser_UserRole.GetUserRoleInfoByUserId
            Dim paramUserId As New SqlParameter("@UserId", SqlDbType.Int)
            paramUserId.Value = UserId
            Dim sql As String = "select * from [t_User_GroupRole] " & _
                                " where UserId = @UserId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramUserId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function AddUserInRole(ByVal info As Model.User_UserRole) As Boolean Implements IDAL.IUser_UserRole.AddUserInRole
            Try


                Dim strSql As String
                strSql = "Insert into t_user_UserRole (UserId,RoleId) Values("
                strSql += "'" + info.Userid.ToString + "',"
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

        Public Function DeleteRoleUser(ByVal Info As Model.User_UserRole) As Boolean Implements IDAL.IUser_UserRole.DeleteRoleUser
            Dim strSql As String

            strSql = " Delete t_user_UserRole  "
            strSql += " Where RoleId ='" + Info.RoleId.ToString + "' and  UserId='" + Info.Userid.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetUserRoleIdsByUserId(ByVal userId As Integer) As List(Of Integer) Implements IUser_UserRole.GetUserRoleIdsByUserId
            Dim strSql As String

            strSql = " Select RoleID from t_user_UserRole  where UserID = " + userId.ToString()

            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, strSql)
            If ds IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                Dim roleIdList As New List(Of Integer)
                For Each row As DataRow In ds.Tables(0).Rows
                    roleIdList.Add(Integer.Parse(row("RoleID")))
                Next
                Return roleIdList
            Else
                Return Nothing
            End If
 
        End Function

        Public Function AssignRolesToUser(ByVal userId As Integer, ByVal roleIds As List(Of Integer)) As Boolean Implements IUser_UserRole.AssignRolesToUser

            Dim strSql As String
            strSql = "delete from t_user_userrole where userid= " + userId.ToString()
            ExecuteNonQuery(strSql)
            If roleIds Is Nothing Then
                Return True
            End If

            For Each roleId As Integer In roleIds
                strSql = String.Format("insert t_user_userrole(roleid,userid) values({0},{1})", roleId, userId)
                ExecuteNonQuery(strSql)
            Next

            Return True


        End Function
    End Class
End Namespace
