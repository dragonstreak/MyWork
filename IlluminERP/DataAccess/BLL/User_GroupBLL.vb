Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class User_GroupBLL
        Private factory As New DALFactory
        Private GroupDal As IUser_Group = factory.GetProduct("User_GroupDAO")

        Public Sub New()

        End Sub

        Public Function GetGroupInfoById(ByVal Id As Integer) As User_Group
            Return GroupDal.GetGroupInfoById(Id)
        End Function

        Public Function GetGroupInfo() As DataSet
            Return GroupDal.GetGroupInfo
        End Function

        Public Function AddGroupInfo(ByVal info As Model.User_Group) As Boolean
            Return GroupDal.AddGroupInfo(info)
        End Function

        Public Function ModifyGroupById(ByVal info As Model.User_Group) As Boolean
            Return GroupDal.ModifyGroupById(info)
        End Function

        Public Function GetGroupInfobyGroupName(ByVal GroupName As String) As Model.User_Group
            Return GroupDal.GetGroupInfobyGroupName(GroupName)
        End Function

    End Class
End Namespace
