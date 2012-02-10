Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class User_UserRoleBLL
        Private factory As New DALFactory
        Private UserRoleDAL As IUser_UserRole = factory.GetProduct("User_UserRoleDAO")

        Public Function GetGroupRoleInfoByUserId(ByVal UserId As Integer) As DataSet
            Return UserRoleDAL.GetUserRoleInfoByUserId(UserId)
        End Function

        Public Function GetGroupRoleInfoByRoleId(ByVal RoleId As Integer) As DataSet
            Return UserRoleDAL.GetUserRoleInfoByRoleId(RoleId)
        End Function

        Public Function GetGroupRoleInfoById(ByVal Id As Integer) As User_UserRole
            Return UserRoleDAL.GetUserRoleInfoById(Id)
        End Function
        Public Function DeleteRoleUser(ByVal Info As User_UserRole) As Boolean
            Return UserRoleDAL.DeleteRoleUser(Info)
        End Function

        Public Function AddUserInRole(ByVal info As User_UserRole) As Boolean
            Return UserRoleDAL.AddUserInRole(info)
        End Function

        Public Function GetUserRoleIdsByUserId(ByVal userId As Integer) As List(Of Integer)
            Return UserRoleDAL.GetUserRoleIdsByUserId(userId)
        End Function

        Public Function AssignRolesToUser(ByVal userId As Integer, ByVal roleIds As List(Of Integer)) As Boolean
            Return UserRoleDAL.AssignRolesToUser(userId, roleIds)
        End Function
       
    End Class
End Namespace
