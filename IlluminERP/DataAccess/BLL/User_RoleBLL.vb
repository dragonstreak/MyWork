
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class User_RoleBLL
        Private factory As New DALFactory
        Private RoleInfoDAL As IUser_Role = factory.GetProduct("User_RoleDAO")
        Public Sub New()

        End Sub

        Public Function GetRoleInfoById(ByVal Id As Integer) As User_Role
            Return RoleInfoDAL.GetRoleInfoById(Id)
        End Function

        Public Function GetRoleInfo() As DataSet
            Return RoleInfoDAL.GetRoleInfo
        End Function

        Public Function AddRoleInfo(ByVal info As Model.User_Role) As Boolean
            Return RoleInfoDAL.AddRoleInfo(info)
        End Function

        Public Function ModifyRoleById(ByVal Info As Model.User_Role) As Boolean
            Return RoleInfoDAL.ModifyRoleById(Info)
        End Function

        Public Function GetRoleInfobyRoleName(ByVal RoleName As String) As Model.User_Role
            Return RoleInfoDAL.GetRoleInfobyRoleName(RoleName)
        End Function

        Public Function IsRoleExist(ByVal roleName As String) As Boolean
            Dim role As User_Role
            role = RoleInfoDAL.GetRoleInfobyRoleName(roleName)
            Return role IsNot Nothing
        End Function

        Public Function GetRoleListByFilter(ByVal filter As RoleQueryFilter) As DataSet
            Return RoleInfoDAL.GetRoleListByFilter(filter)
        End Function
    End Class

End Namespace

