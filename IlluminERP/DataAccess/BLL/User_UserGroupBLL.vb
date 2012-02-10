Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class User_UserGroupBLL
        Private factory As New DALFactory
        Private UserGroupDAL As IUser_UserGroup = factory.GetProduct("User_UserGroupDAO")

        Public Function GetUserGroupByGroupId(ByVal GroupId As Integer) As DataSet
            Return UserGroupDAL.GetUserGroupByGroupId(GroupId)
        End Function

        Public Function GetUserGroupById(ByVal intId As Integer) As User_UserGroup
            Return UserGroupDAL.GetUserGroupById(intId)
        End Function

        Public Function DeleteGroupUser(ByVal Info As User_UserGroup) As Boolean
            Return UserGroupDAL.DeleteGroupUser(Info)
        End Function
        Public Function AddUserInGroup(ByVal info As User_UserGroup) As Boolean
            Return UserGroupDAL.AddUserInGroup(info)
        End Function

    End Class
End Namespace
