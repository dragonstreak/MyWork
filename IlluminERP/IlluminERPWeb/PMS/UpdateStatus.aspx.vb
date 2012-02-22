Imports System.Runtime.Serialization.Json
Imports System.IO
Imports System.Web.Services
Imports System.Runtime.Serialization
Imports System.Collections.Generic
Imports Telerik.Web.UI
Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils.PageUtils
Imports Utils
Imports DataAccess

Partial Class PMS_UpdatStatus
    Inherits System.Web.UI.Page

    Private callBack As CacheItemRemovedCallback
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private ProjectStatusBLL As New BLL.Base_ProjectStatusBLL
    Private ProposalUserinfoBLl As New BLL.PMS_ProposalUserInfoBLL
    Private ProjectContractFileBLL As New BLL.PMS_ProjectContractFileInfoBLL
    Private colUser As New Collection
    Private MyUserInfoBLL As New BLL.UserInfoBLL
    Private ProjectContractInfoBLL As New BLL.PMS_ProjectContractInfoBLL
    Private FileUploadFileTypeBLL As New BLL.PMS_UploadFileTypeBLL
    Private UploadFileInfoBLL As New BLL.PMS_UploadFileInfoBLL

    Dim info As New Model.PMS_ProposalInfo
    Dim ClientInfo As New Model.Client_ClientInfo
    Dim Myuserinfo As New Model.User_UserInfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            InitForm()
        End If
    End Sub

    Private Sub InitForm()

        Dim ClientId As String
        Me.txtJobNumber.Enabled = False
        Me.txtClient.Enabled = False
        Me.txtJobName.Enabled = False

        Dim strId As String = Request.QueryString("Proid")
        Dim dv As New DataView
        Try


            info = ProposalInfoBLL.GetProposalInfoByID(CInt(strId))
            ViewState("info") = info
            If info Is Nothing Then
                Exit Sub
            End If


            Me.txtJobNumber.Text = info.JobNumber
            Me.txtJobName.Text = info.JobName


            ClientId = info.ClientId
            Me.ClientInfo = Me.ClientInfoBLL.GetClientInfoByID(ClientId)
            Me.txtClient.Text = ClientInfo.FullName

            Dim ds As DataSet = ProjectStatusBLL.GetProjectOngoingStatusInfo
            If Not ds Is Nothing Then
                Utils.PageUtils.BindComboBoxList(Me.cbStatus, ds, "id", "ProjectStatus", 2)
            End If

            cbStatus.SelectedValue = info.Status

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strId As String = Request.QueryString("Proid")
        Dim info As New Model.PMS_ProposalInfo

        info.Id = strId
        info.Status = Me.cbStatus.SelectedValue
        info.StatusNote = Me.txtmemo.Text.Trim
        info.StatusDate = Now.Date
        If ProposalInfoBLL.UpdateProjectStatus(info) = True Then
            Me.RadAjaxManager1.Alert("Update project status success!")
        End If
    End Sub
End Class
