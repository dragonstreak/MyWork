Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils.PageUtils
Imports Utils
Imports DataAccess
Imports System.Collections
Imports System.Collections.Generic
Imports Telerik.Web.UI
Partial Class User_ChangePassword
    Inherits System.Web.UI.Page
    Dim userinfo As New Model.User_UserInfo
    Private Myuserinfo As New Model.User_UserInfo
    Private MyuserinfoBLL As New BLL.UserInfoBLL

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("LoginUserInfo") Is Nothing Then
                MyUserinfo = Session("LoginUserInfo")
            End If
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click


        Myuserinfo = Session("LoginUserInfo")


        If Me.txtPassword.Text = "" Then
            Me.RadAjaxManager1.Alert("Please Input a password!")
            Exit Sub
        End If

        If Me.txtConfirmPassword.Text.Trim <> Me.txtPassword.Text.Trim Then
            Me.RadAjaxManager1.Alert("The passwords you entered do not match!")
            Exit Sub
        End If

        Myuserinfo.Password = Me.txtPassword.Text.Trim
        If MyuserinfoBLL.ModifyUserInfo(Myuserinfo) = True Then
            Me.RadAjaxManager1.Alert("Save success!")
        End If

    End Sub


End Class
