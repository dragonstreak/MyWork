Imports Microsoft.ApplicationBlocks.Data
Imports System.Web.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess
Imports System.Threading


<System.Serializable()> Partial Class Login
    Inherits System.Web.UI.Page
    Private UserInfoBLL As New DataAccess.BLL.UserInfoBLL
    Private UserInfo As New DataAccess.Model.User_UserInfo

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim objError As Exception
        objError = Server.GetLastError.GetBaseException
        If clsWarningHandle.GetPageError(objError) = True Then
            Server.ClearError()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strPassword As String

        If Not Page.IsPostBack Then
            If Not Request.Cookies("UserCookie") Is Nothing Then
                Me.txtUserName.Text = Server.HtmlEncode(Request.Cookies("UserCookie")("UserName"))
                strPassword = Server.HtmlEncode(Request.Cookies("UserCookie")("UserPassword"))
                Me.txtPassword.Attributes("Value") = strPassword
                chkSavePassword.Checked = True
            Else
                chkSavePassword.Checked = False
            End If

        End If

     
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim IsExitUser As Boolean
        Dim strCode As String
        Dim strPwd As String
        Dim MyUserInfo As New Model.User_UserInfo
        Dim strParm As String

        strCode = Me.txtUserName.Text.Trim
        strPwd = Me.txtPassword.Text.Trim

        'strPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Me.txtPassword.Text.Trim, "MD5")



        IsExitUser = UserInfoBLL.IsUserExist(strCode, strPwd)


        If IsExitUser = True Then

            Dim aCookie As New HttpCookie("UserCookie")
            If chkSavePassword.Checked = True Then
                aCookie.Values("UserName") = Me.txtUserName.Text
                aCookie.Values("UserPassword") = Me.txtPassword.Text.Trim
                aCookie.Values("Status") = 1
                aCookie.Expires = DateTime.Now.AddDays(360)
                Response.Cookies.Add(aCookie)
            Else
                If Not Request.Cookies("UserCookie") Is Nothing Then
                    aCookie = Request.Cookies("UserCookie")
                    aCookie.Expires = DateTime.Now.AddDays(-1)
                    Response.Cookies.Add(aCookie)
                End If
            End If

            MyUserInfo = UserInfoBLL.GetUserInfoByUserCode(strCode)

            If MyUserInfo Is Nothing Then
                Response.Write("<script language=javascript>")
                Response.Write("window.alert('System can not get  user infomation!');")
                Response.Write("window.location='login.aspx';")
                Response.Write("</script>")
            Else
                Session("LoginUserInfo") = MyUserInfo
                FormsAuthentication.RedirectFromLoginPage(MyUserInfo.Code, False)
            End If

            'strParm = "?userCode=" + strCode

            'Response.Redirect("Index/ModuleNavigate.aspx")
        Else
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Invaild name or password！');")
            Response.Write("window.location='login.aspx';")
            Response.Write("</script>")
        End If




    End Sub

    
End Class
