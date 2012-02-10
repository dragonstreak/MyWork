Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils.PageUtils
Imports Utils
Imports DataAccess
Imports System.Collections
Imports System.Collections.Generic
Imports Telerik.Web.UI


Partial Class PMS_ProposalRating
    Inherits System.Web.UI.Page
    Private ProRatingBLL As New BLL.PMS_ProposalRatingBLL
    Private UserInfoBLL As New BLL.UserInfoBLL

    Private ProjectTypeBLL As New BLL.Base_ProjectTypeBLL
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private SectorBLL As New BLL.Base_SectorBLL
    Private ProductCategory As New BLL.Base_ProductCategoryBLL
    Private StudyType As New BLL.Base_StudyTypeBLL

    Private BusinessUnitBLL As New BLL.Base_busiessUnitBLL
    Private MyUserInfoBLL As New BLL.UserInfoBLL
    Private StudyTypeBLL As New BLL.Base_StudyTypeBLL
    Private MyUserinfo As New Model.User_UserInfo

    Private ProposalUserInfo As New Model.PMS_ProposalUserInfo

    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private ProjectStatusBLL As New BLL.Base_ProjectStatusBLL
    Private ProposalUserinfoBll As New BLL.PMS_ProposalUserInfoBLL
    Private colUser As New Collection


    Dim info As New Model.PMS_ProposalInfo
    Dim ClientInfo As New Model.Client_ClientInfo
    Dim userinfo As New Model.User_UserInfo

    Private Enum GridColum
        Id = 0
        Proid = 1
        UserId = 2
        Rating = 3
        Comments = 4
        Delete = 5

    End Enum




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim strProId As String

            If Not Session("LoginUserInfo") Is Nothing Then
                MyUserinfo = Session("LoginUserInfo")
            End If

            If Not Request.QueryString("proid") Is Nothing Then
                strProId = Request.QueryString("proid")
                Call InitForm()
                InitComboBox()
                Call GetproposalInfobyId(strProId)
                Call initPageGrid()
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

    End Sub

    Private Sub initPageGrid()

        Dim strId As String
        strId = Request.QueryString("proid")
        Dim dv As DataView = ProRatingBLL.GetProposalRatingInfoByProId(strId)
        Me.radGridRating.DataSource = dv
        Me.radGridRating.DataBind()


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

            Dim ds As DataSet = Me.ProposalUserinfoBLl.GetProposalUserinfoByProId(StrId)

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

    Private Property Rating() As Dictionary(Of String, Decimal)
        Get
            Dim varRating As Dictionary(Of String, Decimal) = DirectCast(ViewState("Rating"), Dictionary(Of String, Decimal))
            If [Object].Equals(varRating, Nothing) Then
                varRating = New Dictionary(Of String, Decimal)()
                varRating("sum") = 0
                varRating("counter") = 0
            End If
            Return varRating
        End Get
        Set(ByVal value As Dictionary(Of String, Decimal))
            ViewState("Rating") = value
        End Set
    End Property

    Protected Sub btnPostComment_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPostComment.Click
        Dim strId As String
        Dim info As New Model.PMS_ProposalRatingInfo
        MyUserinfo = Session("LoginUserInfo")
        strId = Request.QueryString("proid")

        info.ProId = strId
        info.UserId = MyUserinfo.ID
        info.Rating = Me.radRating.Value
        info.Comments = Me.txtComments.Text.Trim
        If txtComments.Text <> [String].Empty Then
            If ProRatingBLL.GetProposalRatingInfoByProidUserId(info.ProId, info.UserId) = True Then
                ' add
                Call ProRatingBLL.UpdateProposalRatinginfo(info)

            Else
                'update
                Call ProRatingBLL.AddProposalRatinginfo(info)
            End If

            Dim dv As DataView = ProRatingBLL.GetProposalRatingInfoByProId(strId)
            Me.radGridRating.DataSource = dv
            Me.radGridRating.DataBind()

        End If

        'Close tooltip
        '  Dim str As String = "CloseToolTip1();"
        'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "closeTooltip", str, True)
    End Sub

    Protected Sub radGridRating_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radGridRating.DeleteCommand
        Dim id As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnID").Text
        Dim strCreateduser As String
        Dim info As New Model.PMS_ProposalRatingInfo
        MyUserinfo = Session("LoginUserInfo")
        info.Id = id

        strCreateduser = Me.txtPrepared.Text.Trim
        If strCreateduser <> MyUserinfo.E_Name Then
            Me.RadAjaxManager2.Alert("You have not permition to delete this record!")

        Else
            Call ProRatingBLL.DeleteProposalRatinginfo(info)
        End If

        Dim strId As String
        strId = Request.QueryString("proid")
        Dim dv As DataView = ProRatingBLL.GetProposalRatingInfoByProId(strId)
        Me.radGridRating.DataSource = dv
        Me.radGridRating.DataBind()
    End Sub



    Protected Sub radGridRating_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radGridRating.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim id As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnID").Text
            Dim Proid As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnProid").Text
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnUserId").Text = UserInfoBLL.GetUserInfoById(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnUserID").Text).E_Name
        End If
    End Sub

    Protected Sub RadRating1_Rate(ByVal sender As Object, ByVal e As EventArgs)

       


    End Sub
End Class
