

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IUser_UserRole
        Function GetUserRoleInfoByUserId(ByVal UserId As Integer) As DataSet

        Function GetUserRoleInfoByRoleId(ByVal RoleId As Integer) As DataSet

        Function GetUserRoleInfoById(ByVal Id As Integer) As User_UserRole

        Function DeleteRoleUser(ByVal Info As User_UserRole) As Boolean

        Function AddUserInRole(ByVal info As User_UserRole) As Boolean

        Function GetUserRoleIdsByUserId(ByVal userId As Integer) As List(Of Integer)

        Function AssignRolesToUser(ByVal userId As Integer, ByVal roleIds As List(Of Integer)) As Boolean

    End Interface
End Namespace
