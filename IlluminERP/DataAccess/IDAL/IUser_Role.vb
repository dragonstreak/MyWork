

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IUser_Role

        Function GetRoleInfo() As DataSet

        Function GetRoleInfoById(ByVal Id As Integer) As User_Role

        Function AddRoleInfo(ByVal info As Model.User_Role) As Boolean

        Function ModifyRoleById(ByVal Info As Model.User_Role) As Boolean

        Function GetRoleInfobyRoleName(ByVal RoleName As String) As Model.User_Role

        Function GetRoleListByFilter(ByVal filter As RoleQueryFilter) As DataSet

        Function GetRolePermissionIdsByRoleIds(ByVal roleIds As List(Of Integer)) As List(Of Integer)

    End Interface
End Namespace
