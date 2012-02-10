
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IUser_UserGroup


        Function GetUserGroupByGroupId(ByVal GroupId As Integer) As DataSet

        Function GetUserGroupById(ByVal intId As Integer) As User_UserGroup

        Function DeleteGroupUser(ByVal Info As User_UserGroup) As Boolean
        Function AddUserInGroup(ByVal info As User_UserGroup) As Boolean


    End Interface
End Namespace
