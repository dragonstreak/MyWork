Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils.PageUtils
Imports Utils
Imports DataAccess
Imports System.Collections
Imports System.Collections.Generic
Imports Telerik.Web.UI
Partial Class PMS_ProposalStatus
    Inherits System.Web.UI.Page
    Private ProjectTypeBLL As New BLL.Base_ProjectTypeBLL
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private SectorBLL As New BLL.Base_SectorBLL
    Private ProductCategory As New BLL.Base_ProductCategoryBLL
    Private StudyType As New BLL.Base_StudyTypeBLL


    Private BusinessUnitBLL As New BLL.Base_busiessUnitBLL
    Private MyUserInfoBLL As New BLL.UserInfoBLL
    Private StudyTypeBLL As New BLL.Base_StudyTypeBLL
    Private MyUserinfo As New Model.User_UserInfo
    Private UserInfoBLL As New BLL.UserInfoBLL
    Private ProposalUserInfo As New Model.PMS_ProposalUserInfo

    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private ProjectStatusBLL As New BLL.Base_ProjectStatusBLL
    Private ProposalUserinfoBll As New BLL.PMS_ProposalUserInfoBLL
    Private colUser As New Collection


    Dim info As New Model.PMS_ProposalInfo
    Dim ClientInfo As New Model.Client_ClientInfo
    Dim userinfo As New Model.User_UserInfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not Page.IsPostBack Then
            Dim strProId As String

            If Not Request.QueryString("proid") Is Nothing Then
                strProId = Request.QueryString("proid")
                Call InitForm()
                InitComboBox()
                Call GetproposalInfobyId(strProId)
            End If

        End If

    End Sub

    Private Sub InitForm()
        Me.txtJobnumber.ReadOnly = True
        Me.txtJobName.ReadOnly = True
        Me.cbBusinessUnit.Enabled = False
        Me.txtProbablity.ReadOnly = False
        Me.cbClient.Enabled = False
        Me.cbSector.Enabled = False
        Me.cbProductCategory.Enabled = False
        Me.cbStudytype.Enabled = False
        Me.txtPrepared.ReadOnly = True
        Me.txtCreateDate.ReadOnly = True
        Me.cbProjectOwner.Enabled = False
        Me.txtDescription.ReadOnly = True
        Me.txtKeywords.ReadOnly = True

    End Sub

    Private Sub InitComboBox()
        Dim ds As DataSet
        Dim strId As String = Request.QueryString("Proid")
        If Not Session("LoginUserInfo") Is Nothing Then
            MyUserinfo = Session("LoginUserInfo")
        End If

        ds = ProjectTypeBLL.GetProjectTypeInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbBusinessUnit, ds, "id", "ProjectType", 2)
            Me.cbBusinessUnit.SelectedValue = 1

        End If

        ds = Me.BusinessUnitBLL.GetBusinessUnitInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbBusinessUnit, ds, "id", "BusinessUnit", 2)

        End If

        ds = Me.ClientInfoBLL.GetClientInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbClient, ds, "id", "Fullname", 2)
            cbClient.SelectedValue = 0
        End If



        ds = SectorBLL.GetSectorInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbSector, ds, "id", "Sector", 2)
        End If


        ds = ProductCategory.GetProductCategoryInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProductCategory, ds, "id", "ProductCategory", 2)

        End If

        ds = Me.UserInfoBLL.GetProjectOwnerList()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProjectOwner, ds, "id", "E_name", 2)
            Me.cbProjectOwner.SelectedValue = MyUserinfo.LineManager
        End If


        ds = StudyTypeBLL.GetStudyTypeInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbStudytype, ds, "id", "StudyType", 2)
        End If


        Dim dv As DataView = Me.UserInfoBLL.GetUserList("Onduty=1")
        If Not dv Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProposalStatus, dv, "Id", "E_name", 2)
        End If

        ds = ProjectStatusBLL.GetProjectStatusInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProposalStatus, ds, "id", "ProjectStatus", 2)
            Me.cbProposalStatus.SelectedValue = 1
        End If

    End Sub

    Private Sub GetproposalInfobyId(ByVal StrId As String)

        Dim dv As New DataView
        Try
            info = ProposalInfoBLL.GetProposalInfoByID(CInt(StrId))
            ViewState("info") = info
            If info Is Nothing Then
                Exit Sub
            End If


            Me.txtJobnumber.Text = info.JobNumber
            Me.txtJobName.Text = info.JobName
            Me.cbBusinessUnit.SelectedValue = info.BusinessUnitId

            Me.cbClient.SelectedValue = info.ClientId
            Me.cbSector.SelectedValue = info.SectorId
            Me.cbProductCategory.SelectedValue = info.ProductCategoryId

            Me.cbStudytype.SelectedValue = info.StudyTypeId

            Me.txtProbablity.Value = info.Probability
            Me.txtCreateDate.Text = info.CreateDate
            Me.txtDescription.Text = info.Description
            Me.txtKeywords.Text = info.KeyWords
            Me.cbProposalStatus.SelectedValue = info.Status
            Me.txtStatusNote.Text = info.StatusNote
            If info.Status > 1 Then
                Me.lblStatus.Text = Me.cbProposalStatus.SelectedItem.Text & "  on " & info.StatusDate
            End If
            Dim ds As DataSet = Me.ProposalUserinfoBll.GetProposalUserinfoByProId(StrId)

            If Not ds Is Nothing Then
                Dim dt As DataTable = ds.Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        If dr("ProposalUserTypeId") = 1 Then
                            Dim info = Me.UserInfoBLL.GetUserInfoById(dr("ProposalUserTypeId"))
                            Me.txtPrepared.Text = info.E_Name
                        End If

                        If dr("ProposalUserTypeId") = 2 Then
                            Dim info = Me.UserInfoBLL.GetUserInfoById(dr("ProposalUserTypeId"))
                            Me.cbProjectOwner.SelectedValue = dr("UserId")
                        End If
                    Next
                End If
            End If

        Catch ex As Exception

        End Try



    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim info As New Model.PMS_ProposalInfo


        info.Status = Me.cbProposalStatus.SelectedValue
        info.StatusNote = Me.txtStatusNote.Text.Trim
        info.StatusDate = Now.Date
        info.Id = Request.QueryString("proid")

        If ProposalInfoBLL.UpdateProjectStatus(info) = True Then
            Me.RadAjaxManager1.Alert("Update Success!")
            Dim StatusInfo As Model.Base_ProjectStatus = ProjectStatusBLL.GetProjectStatusInfoById(Me.cbProposalStatus.SelectedValue)
            lblStatus.Text = StatusInfo.ProjctStatus & "   On  " & Now.Date
        End If
    End Sub
End Class
