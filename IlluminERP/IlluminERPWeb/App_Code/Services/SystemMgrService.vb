Imports Microsoft.VisualBasic
Imports DataAccess.BLL
Imports DataAccess.Model
Imports Utils

Public Class SystemMgrService
    Public permissionBLL As New System_PermissionBLL

    Public Shared ReadOnly Instance As SystemMgrService = New SystemMgrService

    Public Function GetPageModule(ByVal param As GetPageModuleParam) As GetPageModuleResult
        Dim result As New GetPageModuleResult
        
        Dim pageName As String = PageUtils.GetPageName(param.PageUrl)

        If String.IsNullOrEmpty(pageName) Then
            result.IsSuccess = False
            result.ErrorMessage = "Can not pick page url"
            Return result
        End If
        Dim modelName As String = Nothing
        If Not String.IsNullOrEmpty(pageName) Then
            Dim permissionInfo As System_PermissionInfo = permissionBLL.GetUserPermissionsByPage(pageName)
            If permissionInfo IsNot Nothing Then
                modelName = permissionInfo.SystemModule
            End If
        End If

        result.IsSuccess = True
        result.ModuleName = modelName

        Return result
    End Function
End Class
