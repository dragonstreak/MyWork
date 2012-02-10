Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Text
Imports System.Text.RegularExpressions

Imports System.ServiceModel
Imports System.ServiceModel.Activation

Imports Illumin.Services.DataContracts

' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.

<ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Multiple, InstanceContextMode:=InstanceContextMode.Single)>
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)>
Public Class SystemManage
    Implements ISystemManage

    Public Sub New()
    End Sub

    Public permissionBLL As New System_PermissionBLL

    Public Function GetPageModule(ByVal param As GetPageModuleParam) As GetPageModuleResult Implements ISystemManage.GetPageModule

        Dim pageNamePattern As New Regex("/(\\w{1,30}.aspx)")
        Dim pageMacth As Match
        pageMacth = pageNamePattern.Match(param.PageUrl)
        Dim pageName As String = Nothing
        If pageMacth.Groups IsNot Nothing AndAlso pageMacth.Groups.Count = 2 Then
            pageName = pageMacth.Groups(1).Value
        End If
        Dim modelName As String = Nothing
        If Not String.IsNullOrEmpty(pageName) Then
            Dim permissionInfo As System_PermissionInfo = permissionBLL.GetUserPermissionsByPage(pageName)
            If permissionInfo IsNot Nothing Then
                modelName = permissionInfo.SystemModule
            End If
        End If
        Dim result As New GetPageModuleResult
        result.ModuleName = modelName

        Return result
    End Function

    Public Function GetPageModule2(ByVal pageUrl As String) As String Implements ISystemManage.GetPageModule2

        Dim pageNamePattern As New Regex("/(\\w{1,30}.aspx)")
        Dim pageMacth As Match
        pageMacth = pageNamePattern.Match(pageUrl)
        Dim pageName As String = Nothing
        If pageMacth.Groups IsNot Nothing AndAlso pageMacth.Groups.Count = 2 Then
            pageName = pageMacth.Groups(1).Value
        End If
        Dim modelName As String = Nothing
        If Not String.IsNullOrEmpty(pageName) Then
            Dim permissionInfo As System_PermissionInfo = permissionBLL.GetUserPermissionsByPage(pageName)
            If permissionInfo IsNot Nothing Then
                modelName = permissionInfo.SystemModule
            End If
        End If

        Return modelName
    End Function

End Class
