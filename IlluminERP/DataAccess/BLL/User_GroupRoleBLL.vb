Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class User_GroupRoleBLL
        Private factory As New DALFactory
        Private GroupRoleDAL As IUser_GroupRole = factory.GetProduct("User_GroupRoleDAO")

        Public Function GetGroupRoleInfoByGroupId(ByVal GroupId As Integer) As DataSet
            Return GroupRoleDAL.GetGroupRoleInfoByGroupId(GroupId)
        End Function

        Public Function GetGroupRoleInfoByRoleId(ByVal RoleId As Integer) As DataSet
            Return GroupRoleDAL.GetGroupRoleInfoByRoleId(RoleId)
        End Function

        Public Function GetGroupRoleInfoById(ByVal Id As Integer) As User_GroupRole
            Return GroupRoleDAL.GetGroupRoleInfoById(Id)
        End Function


        Public Function DeleteRoleGroup(ByVal Info As User_GroupRole) As Boolean

            Return GroupRoleDAL.DeleteRoleGroup(Info)
        End Function
        Public Function AddGroupInRole(ByVal info As User_GroupRole) As Boolean
            Return GroupRoleDAL.AddGroupInRole(info)
        End Function

    End Class
End Namespace
