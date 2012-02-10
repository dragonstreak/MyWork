

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IUser_GroupRole

        Function GetGroupRoleInfoByGroupId(ByVal GroupId As Integer) As DataSet

        Function GetGroupRoleInfoByRoleId(ByVal RoleId As Integer) As DataSet

        Function GetGroupRoleInfoById(ByVal Id As Integer) As User_GroupRole

        Function DeleteRoleGroup(ByVal Info As User_GroupRole) As Boolean
        Function AddGroupInRole(ByVal info As User_GroupRole) As Boolean

    End Interface
End Namespace
