Imports DataAccess.Model

Namespace IDAL
    Friend Interface ISystem_Permission

        Function GetAllPermissions() As DataSet

        Function GetHierarchicalPermissions() As DataSet

        Function GetUserHierarchicalPermissions(ByVal userInfo As Model.User_UserInfo) As DataSet

        Function GetUserPermissionsByPage(ByVal pageName As String) As System_PermissionInfo

        Function GetPerMissionInfoById(ByVal Id As Integer) As System_PermissionInfo
    End Interface

End Namespace

