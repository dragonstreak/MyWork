Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class User_RoleDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_Role


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function GetRoleInfo() As System.Data.DataSet Implements IDAL.IUser_Role.GetRoleInfo
            Dim sql As String = "select * from [t_User_Role] where IsDeleted = 0 "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetRoleInfoById(ByVal Id As Integer) As Model.User_Role Implements IDAL.IUser_Role.GetRoleInfoById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = Id
            Dim sql As String = "select * from [t_User_Role] where IsDeleted = 0 And ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As User_Role = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToRoleInfo(ds.Tables(0).Rows(0))
            End If
            'Permission
            Dim getRolePermissionSql As String
            getRolePermissionSql = "select * from t_user_RolePermission where role_id =" + Id.ToString
            Dim dsRolePermission As DataSet = ExecuteDataSet(CommandType.Text, getRolePermissionSql)
            If dsRolePermission IsNot Nothing AndAlso dsRolePermission.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In dsRolePermission.Tables(0).Rows
                    info.PermissionIDs.Add(Convert.ToInt32(dr("Permission_ID")))
                Next
            End If

            Return info
        End Function


        Private Function MapRowToRoleInfo(ByVal dr As DataRow) As User_Role
            Dim info As New User_Role
            info.ID = Convert.ToInt32(dr("ID"))


            If Not Convert.IsDBNull(dr("RoleName")) Then
                info.RoleName = Convert.ToString(dr("RoleName"))
            End If

            If Not Convert.IsDBNull(dr("Status")) Then
                info.Status = Convert.ToInt32(dr("Status"))
            End If

            If Not Convert.IsDBNull(dr("Remark")) Then
                info.Remark = Convert.ToString(dr("Remark"))
            End If

            If Not Convert.IsDBNull(dr("IsDeleted")) Then
                info.IsDeleted = Convert.ToBoolean(dr("IsDeleted"))

            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As User_Role) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@RoleName", SqlDbType.Char), _
                                                                     New SqlParameter("@Remark", SqlDbType.Char), _
                                                                    New SqlParameter("@Status", SqlDbType.Int)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.RoleName
            parameters(2).Value = info.Remark
            parameters(3).Value = info.Status

            Return parameters
        End Function

        Public Function AddRoleInfo(ByVal info As Model.User_Role) As Boolean Implements IDAL.IUser_Role.AddRoleInfo
            Dim sql As String
            Try
                sql = "select MAX(ID) AS Expr1 from t_User_Role"
                Dim newid As Integer
                Dim o As Object
                o = ExecuteScalar(sql)
                If IsDBNull(o) Then
                    newid = 1
                Else
                    newid = Convert.ToInt32(o) + 1
                End If
                info.ID = newid

                Dim strSql As String
                strSql = "Insert into t_user_Role(Id,RoleName,Status,Remark,IsDeleted) Values("
                strSql += "'" + info.ID.ToString + "',"
                strSql += "'" + info.RoleName.ToString + "',"
                strSql += "'" + info.Status.ToString + "',"
                strSql += "'" + info.Remark.ToString + "',0)"

                ExecuteNonQuery(CommandType.Text, strSql)

                If info.PermissionIDs.Count > 0 Then
                    Dim assignPermissSql As String = String.Empty
                    For Each permissionId As Integer In info.PermissionIDs
                        assignPermissSql += "insert into t_user_RolePermission(Role_ID,Permission_ID) " _
                                        + String.Format("Values({0},{1}) {2}", newid, permissionId, vbNewLine)

                    Next
                    ExecuteNonQuery(CommandType.Text, assignPermissSql)
                End If
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetRoleInfobyRoleName(ByVal RoleName As String) As Model.User_Role Implements IDAL.IUser_Role.GetRoleInfobyRoleName
            Dim paramRoleName As New SqlParameter("@RoleName", SqlDbType.Char)
            paramRoleName.Value = RoleName
            Dim sql As String = "select * from [t_User_Role] where IsDeleted = 0 And RoleName = @RoleName"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramRoleName)
            Dim info As User_Role = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToRoleInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function ModifyRoleById(ByVal Info As Model.User_Role) As Boolean Implements IDAL.IUser_Role.ModifyRoleById
            Dim strSql As String

            strSql = " Update t_User_Role set "
            strSql += "RoleName='" + Info.RoleName.ToString + "'"
            strSql += ",Status='" + Info.Status.ToString + "'"
            strSql += ",Remark='" + Info.Remark.ToString + "'"
            strSql += " Where Id ='" + Info.ID.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)

                'modify permission
                Dim deletePermissionSql As String
                deletePermissionSql = "delete from t_user_RolePermission where role_id = " + Info.ID.ToString
                ExecuteNonQuery(CommandType.Text, deletePermissionSql)

                If Info.PermissionIDs.Count > 0 Then
                    Dim assignPermissSql As String = String.Empty
                    For Each permissionId As Integer In Info.PermissionIDs
                        assignPermissSql += "insert into t_user_RolePermission(Role_ID,Permission_ID) " _
                                        + String.Format("Values({0},{1}) {2}", Info.ID, permissionId, vbNewLine)

                    Next
                    ExecuteNonQuery(CommandType.Text, assignPermissSql)

                End If

                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetRoleListByFilter(ByVal filter As RoleQueryFilter) As DataSet Implements IUser_Role.GetRoleListByFilter

            Dim strSql As String = "select role.* from dbo.t_User_Role role where IsDeleted = 0  "
            
            'add name condtion,check ename and cname 
            strSql += " and (@name = '' or role.rolename like '%'+@name+'%' )"
            'add department condition
            strSql += " and (@Status=-1 or @Status=role.Status)"

            'set parameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@name", filter.Name),
                 New SqlParameter("@Status", filter.Status)}


            Dim dsUserList As DataSet = Me.ExecuteDataSet(strSql, parameters)
            Return dsUserList
        End Function

        Public Function GetRolePermissionIdsByRoleIds(ByVal roleIds As List(Of Integer)) As List(Of Integer) Implements IUser_Role.GetRolePermissionIdsByRoleIds
            If roleIds Is Nothing OrElse roleIds.Count = 0 Then
                Return Nothing
            End If
            Dim strSql As String
            Dim srtRoleIds As String = String.Join(",", roleIds)

            strSql = "select distinct Permission_ID from t_user_rolePermission where role_id in (" + srtRoleIds + ")"

            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, strSql)

            If ds IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                Dim permissionIdList As New List(Of Integer)
                For Each row As DataRow In ds.Tables(0).Rows
                    permissionIdList.Add(Integer.Parse(row("Permission_ID")))
                Next

                Return permissionIdList
            Else
                Return Nothing
            End If

        End Function
    End Class
End Namespace
