
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IUser_Group

        Function GetGroupInfoById(ByVal Id As Integer) As User_Group

        Function GetGroupInfo() As DataSet

        Function AddGroupInfo(ByVal info As Model.User_Group) As Boolean

        Function ModifyGroupById(ByVal Info As Model.User_Group) As Boolean

        Function GetGroupInfobyGroupName(ByVal GroupName As String) As Model.User_Group


    End Interface
End Namespace
