Imports System.Linq
Imports System.Collections.Generic

Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils.PageUtils
Imports Utils
Imports DataAccess

Imports Telerik.Web.UI

Partial Class User_Team
    Inherits OperatePageBase

    Private UserInfoBLL As New DataAccess.BLL.UserInfoBLL
    Private CityInfoBLL As New DataAccess.BLL.Base_CityInfoBLL
    Private TeamInfoBLL As New DataAccess.BLL.User_TeamInfoBLL
    Private UserTeamInfoBLL As New DataAccess.BLL.User_UserTeamBLL
    Private SectorBLL As New BLL.Base_SectorBLL
    Dim CurrentTeamInfo As New User_TeamInfo

     

    Protected Overrides Sub InitForm()
        MyBase.InitForm()
        Dim ds As DataSet
        Dim dt As New DataTable

        dt = UserInfoBLL.GetAllUser()
        If Not dt Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.ddlTeamleader, dt, "ID", "E_Name", 2)
        End If

        ds = TeamInfoBLL.GetTeamInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.ddlParent, ds, "ID", "TeamName", 2)
        End If

        ds = SectorBLL.GetSectorInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.ddlSector, ds, "ID", "Sector", 2)
        End If

        dlbUser.IsSelectedCheckBoxEnable = True
    End Sub

    Protected Overrides Sub SetForm()
        MyBase.SetForm()

        Dim id As String = Page.Request.QueryString("Teamid")

        Dim dtAllUser As DataTable = UserInfoBLL.GetAllUser()
        Dim dvSelected As DataView = Nothing
        Dim dvUnSelected As DataView = Nothing
        'get user id from url

        If OperateType = "Modify" Then

            CurrentTeamInfo = TeamInfoBLL.GetTeamInfoById(CInt(id))

            Me.txtTeamName.Text = CurrentTeamInfo.TeamName.Trim

            Me.ddlTeamleader.SelectedValue = CurrentTeamInfo.TeamLeaderID

            Me.ddlParent.SelectedValue = CurrentTeamInfo.ParentID
            Me.ddlSector.SelectedValue = CurrentTeamInfo.SectorID
            If CurrentTeamInfo.TeamMemberIdList IsNot Nothing Then
                Dim unSelected = From user In dtAllUser.AsEnumerable _
                             Where Not CurrentTeamInfo.TeamMemberIdList.Contains(Integer.Parse(user("ID"))) _
                             Order By user("E_Name").ToString() _
                             Select user


                dvUnSelected = unSelected.AsDataView

                Dim selected = From user In dtAllUser.AsEnumerable _
                               Where CurrentTeamInfo.TeamMemberIdList.Contains(user("ID")) _
                               Order By user("E_Name").ToString() _
                               Select user


                dvSelected = selected.AsDataView
            Else
                dvUnSelected = dtAllUser.DefaultView
            End If

            Dim checkItemsList As New List(Of String)
            If CurrentTeamInfo.TeamLeader IsNot Nothing Then
                checkItemsList.Add(CurrentTeamInfo.TeamLeader.ID.ToString())
                dlbUser.SelectedCheckItemList = checkItemsList
            End If
        ElseIf OperateType = "New" Then
            dvUnSelected = dtAllUser.DefaultView
        End If

        dlbUser.UnSelectedDataSource = dvUnSelected
        dlbUser.SelectedDataSource = dvSelected
        dlbUser.DataTextField = "E_Name"
        dlbUser.DataValueField = "ID"


    End Sub


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'check data
        If Not CheckData() Then
            Return
        End If
        'set TeamInfo object
        SetTeamInfo()
        Try

            Dim operatedResult As Boolean
            If OperateType = "New" Then
                operatedResult = TeamInfoBLL.AddTeamInfo(CurrentTeamInfo)
            End If
            If OperateType = "Modify" Then
                operatedResult = TeamInfoBLL.ModifyTeamInfo(CurrentTeamInfo)
            End If

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
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Sub SetTeamInfo()
        If OperateType = "Modify" Then
            Dim id As String = Page.Request.QueryString("Teamid")
            CurrentTeamInfo = TeamInfoBLL.GetTeamInfoById(Integer.Parse(id))
        End If

        CurrentTeamInfo.TeamName = Me.txtTeamName.Text.Trim()
        ' CurrentTeamInfo.CityID = Me.ddlTeamleader.SelectedValue

        CurrentTeamInfo.ParentID = Me.ddlParent.SelectedValue
        CurrentTeamInfo.SectorID = Me.ddlSector.SelectedValue
        Dim checkItemList As List(Of String) = dlbUser.GetFinalCheckedValue()
        If checkItemList IsNot Nothing AndAlso checkItemList.Count > 0 Then
            CurrentTeamInfo.TeamLeaderID = Integer.Parse(checkItemList(0))
        End If
        Dim selectedList As List(Of String) = dlbUser.GetFinalSelectedValue()
        If selectedList IsNot Nothing Then

            CurrentTeamInfo.TeamMemberIdList = New List(Of Integer)
            For Each value As String In selectedList
                CurrentTeamInfo.TeamMemberIdList.Add(Integer.Parse(value))
            Next
        End If

    End Sub


    Private Function CheckData() As Boolean

        If Me.txtTeamName.Text = "" Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Team Name not null！');")
            Response.Write("</script>")
            Return False
        End If

        If Me.ddlTeamleader.SelectedValue = 0 Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('TeamLeader not null！');")
            Response.Write("</script>")
            Return False
        End If

        If Me.ddlParent.SelectedValue = 0 Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Parent Team not null！');")
            Response.Write("</script>")
            Return False
        End If

        If Me.ddlSector.SelectedValue = 0 Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Sector not null！');")
            Response.Write("</script>")
            Return False
        End If

        Dim isTeamNameExist As Boolean
        If OperateType = "New" Then
            isTeamNameExist = TeamInfoBLL.isTeamNameExist(Me.txtTeamName.Text.Trim)
        ElseIf OperateType = "Modify" Then
            Dim teamId As Integer = Integer.Parse(Page.Request.QueryString("Teamid"))
            isTeamNameExist = TeamInfoBLL.isTeamNameExist(Me.txtTeamName.Text.Trim, teamId)
        End If
        If isTeamNameExist Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('This Team Name is exist！');")
            Response.Write("</script>")
            Return False
        End If

        Dim teamLeaderList As List(Of String)
        teamLeaderList = dlbUser.GetFinalCheckedValue()
        If teamLeaderList IsNot Nothing AndAlso teamLeaderList.Count > 1 Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Can not set more than one leader！');")
            Response.Write("</script>")
            Return False
        End If

        Return True
    End Function


    Protected Sub ddlTeamleader_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTeamleader.SelectedIndexChanged

    End Sub
End Class
