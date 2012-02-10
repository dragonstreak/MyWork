Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class System_PermissionBLL

        Private factory As New DALFactory
        Private PermissionDAL As ISystem_Permission = factory.GetProduct("System_PermissionDAO")


        Public Sub New()

        End Sub

        Public Function GetAllPermissions() As DataSet

            Return PermissionDAL.GetAllPermissions
        End Function

        Public Function GetHierarchicalPermissions() As DataSet

            Return PermissionDAL.GetHierarchicalPermissions
        End Function

        Public Function GetUserHierarchicalPermissions(ByVal userInfo As Model.User_UserInfo) As DataSet

            Return PermissionDAL.GetUserHierarchicalPermissions(userInfo)
        End Function

        Public Function GetUserPermissionsByPage(ByVal pageName As String) As System_PermissionInfo
            Return PermissionDAL.GetUserPermissionsByPage(pageName)
        End Function

        Public Function GetPerMissionInfoById(ByVal Id As Integer) As System_PermissionInfo
            Return PermissionDAL.GetPerMissionInfoById(Id)
        End Function

    End Class
End Namespace

