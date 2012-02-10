Imports System.Data

Imports Telerik.Web.UI

Imports DataAccess.BLL
Imports DataAccess.Model

Partial Class AssignRoleToTeam
    Inherits PageBase
    Private TeamID As Integer
    Private RoleBLL As New User_RoleBLL
    Private UserBLL As New UserInfoBLL
    Private TeamBLL As New User_TeamInfoBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Page.Request.QueryString("id") Is Nothing Or Not Integer.TryParse(Page.Request.QueryString("id"), TeamID) Then
                Throw New NotSupportedException("Invalid Operation")
            End If

            ViewState("TeamID") = Page.Request.QueryString("id")
            SetForm()
        Else
            TeamID = Convert.ToInt32(ViewState("TeamID"))
        End If


    End Sub

    Private Sub SetForm()
        Dim dsRole As DataSet
        Dim roleFilter As New RoleQueryFilter
        roleFilter.Name = String.Empty
        roleFilter.Status = -1
        dsRole = RoleBLL.GetRoleListByFilter(roleFilter)
        If dsRole Is Nothing Then
            Return
        End If
        Dim dtRole As DataTable = dsRole.Tables(0)

        Dim loginUser As User_UserInfo = CType(Session("LoginUserInfo"), User_UserInfo)
        Dim thisTeam As User_TeamInfo = TeamBLL.GetTeamInfoById(TeamID)

        lblTeamName.Text = thisTeam.TeamName
        If thisTeam.TeamLeader IsNot Nothing Then
            lblTeamLeader.Text = thisTeam.TeamLeader.E_Name
        End If
        lblSector.Text = thisTeam.Sector

        If loginUser.RoleIds Is Nothing Then
            loginUser.RoleIds = New List(Of Integer)

        End If

        If thisTeam.RoleIdList Is Nothing Then
            thisTeam.RoleIdList = New List(Of Integer)
        End If

        Dim varUnSelected = From row In dtRole.AsEnumerable _
                  Where loginUser.RoleIds.Contains(Integer.Parse(row("ID"))) _
                        AndAlso Not thisTeam.RoleIdList.Contains(Integer.Parse(row("ID"))) _
                  Order By row("RoleName").ToString() _
                  Select row

        Dim unSelectedRole As DataView = varUnSelected.AsDataView()

        Dim varSelected = From row In dtRole.AsEnumerable _
                          Where loginUser.RoleIds.Contains(Integer.Parse(row("ID"))) _
                                AndAlso thisTeam.RoleIdList.Contains(Integer.Parse(row("ID"))) _
                          Order By row("RoleName").ToString() _
                          Select row

        Dim selectedRole As DataView = varSelected.AsDataView()

        dlbRole.UnSelectedDataSource = unSelectedRole
        dlbRole.SelectedDataSource = selectedRole

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim roleIDs As List(Of String)
        roleIDs = dlbRole.GetFinalSelectedValue()

        Dim roleIDList As New List(Of Integer)
        If roleIDs IsNot Nothing Then
            For Each roleID As String In roleIDs
                roleIDList.Add(Integer.Parse(roleID))
            Next
        End If
        Dim operatedResult As Boolean = TeamBLL.AssignRolesToTeam(TeamID, roleIDList)

        If operatedResult Then
            'remind
            Response.Write("<script language=javascript>")
            Response.Write("alert('success!');window.returnValue='success';window.close();")
            Response.Write("</script>")
            'close current page
        Else
            'remind
            Response.Write("<script language=javascript>")
            Response.Write("alert('failed!');window.returnValue='failed';window.close();")
            Response.Write("</script>")
            'close current page
        End If
    End Sub

End Class
