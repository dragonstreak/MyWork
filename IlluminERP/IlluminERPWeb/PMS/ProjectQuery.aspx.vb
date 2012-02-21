Imports DataAccess
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports Telerik.Web.UI
Partial Class PMS_ProjectQuery
    Inherits System.Web.UI.Page
    Private ProjectStatusBLL As New BLL.Base_ProjectStatusBLL
    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private StudyTypeBLL As New BLL.Base_StudyTypeBLL
    Private ProjectTypeBLL As New BLL.Base_ProjectTypeBLL
    Private CityBLL As New BLL.Base_CityInfoBLL
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private SectorBLL As New BLL.Base_SectorBLL
    Private ProductCategory As New BLL.Base_ProductCategoryBLL
    Private AOEBLL As New BLL.Base_AOEBLL
    Private MyUserInfoBLL As New BLL.UserInfoBLL
    Private BSBLL As New BLL.Base_BusinessSolutionBLL
    Private MyUserinfo As New Model.User_UserInfo
    Private UserInfoBLL As New BLL.UserInfoBLL
    Private DigitalProductsIdBLL As New BLL.Base_DigitalProductsBLL
    Private colUser As New Collection
    Private BusinessUnitBLL As New BLL.Base_busiessUnitBLL
    Private clsPMS_ProposalInfo As New Model.PMS_ProposalInfo


    Private Enum Gridcolumn
        id = 0
        Go = 1
        Contract = 2
        FileUpload = 3
        Timing = 4
        Quotation = 5
        stage = 6
        edit = 7
        jobnumber = 8
        jobname = 9
        client = 10
        sector = 11
        product = 12
        StudyType = 13
        status = 14
    End Enum
    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim objError As Exception
        objError = Server.GetLastError.GetBaseException
        If clsWarningHandle.GetPageError(objError) = True Then
            Server.ClearError()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Call initPageGrid()
            Call InitCombobox()
        End If


    End Sub

    Private Sub initPageGrid()
        Dim type As String = Request.QueryString("type")

        Select Case type.ToLower
            Case "query"
                Me.gridResult.Columns(Gridcolumn.edit).Visible = True
            Case "stage"
                Me.gridResult.Columns(Gridcolumn.stage).Visible = True
            Case "quot"
                Me.gridResult.Columns(Gridcolumn.Quotation).Visible = True
            Case "timing"
                Me.gridResult.Columns(Gridcolumn.Timing).Visible = True
            Case "fileupload"
                Me.gridResult.Columns(Gridcolumn.FileUpload).Visible = True
            Case "contract"
                Me.gridResult.Columns(Gridcolumn.Contract).Visible = True
            Case "go"
                Me.gridResult.Columns(Gridcolumn.Go).Visible = True
            Case Else

        End Select
    End Sub

    Private Sub InitCombobox()
        Dim ds As DataSet
        ds = Me.ClientInfoBLL.GetClientInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbClient, ds, "id", "Fullname", 1)
            cbClient.SelectedValue = 0
        End If

        ds = Me.BusinessUnitBLL.GetBusinessUnitInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbBusinessUnit, ds, "id", "BusinessUnit", 1)

        End If

        ds = SectorBLL.GetSectorInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbSector, ds, "id", "Sector", 1)
        End If


        ds = StudyTypeBLL.GetStudyTypeInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbStudytype, ds, "id", "StudyType", 1)
        End If

        ds = ProductCategory.GetProductCategoryInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProductCategory, ds, "id", "ProductCategory", 1)
        End If

        ds = Me.ProjectStatusBLL.GetProjectOngoingStatusInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbStatus, ds, "id", "projectstatus", 1)

            Me.cbStatus.SelectedValue = 4

        End If

    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click

        'clsPMS_ProposalInfo = GetQueryInfo()
        'Dim dv As DataView = ProposalInfoBLL.GetProposallistByQueryInfo(clsPMS_ProposalInfo)

        Dim strQuerystring As String = GetQuerystring()
        Dim dv As DataView = ProposalInfoBLL.GetProposallistByQueryString(strQuerystring)
        Me.gridResult.DataSource = dv.Table()
        Me.gridResult.DataBind()

    End Sub

    Protected Function GetQuerystring() As String
        Dim strQueryString As String

        strQueryString = "Status=2"

        If Me.cbClient.SelectedValue > 0 Then
            strQueryString += " AND ClientId='" + Me.cbClient.SelectedValue + "'"
        End If

        If Me.cbSector.SelectedValue > 0 Then
            strQueryString += " AND SectorId='" + Me.cbSector.SelectedValue + "'"
        End If

        If Me.cbStudytype.SelectedValue > 0 Then
            strQueryString += " AND StudyTypeId='" + Me.cbStudytype.SelectedValue + "'"
        End If

        If Me.cbStudytype.SelectedValue < 0 Then
            Dim sb As New StringBuilder()
            Dim collection As IList(Of RadComboBoxItem) = cbStudytype.CheckedItems

            If collection.Count > 0 Then
                For Each item As RadComboBoxItem In collection
                    sb.Append(item.Value + ",")
                Next
                strQueryString += " AND StudyTypeId IN(" + Left(sb.ToString(), Len(sb.ToString) - 1) + ")"
                sb.Clear()
            End If
        End If


        If Me.cbProductCategory.SelectedValue > 0 Then
            strQueryString += " AND ProductCategoryID='" + Me.cbProductCategory.SelectedValue + "'"
        End If

        If Me.cbProductCategory.SelectedValue < 0 Then
            Dim sb As New StringBuilder()
            Dim collection As IList(Of RadComboBoxItem) = cbProductCategory.CheckedItems

            If collection.Count > 0 Then
                For Each item As RadComboBoxItem In collection
                    sb.Append(item.Value + ",")
                Next
                strQueryString += " AND ProductCategoryID IN(" + Left(sb.ToString(), Len(sb.ToString) - 1) + ")"
                sb.Clear()
            End If
        End If


        If Me.cbBusinessUnit.SelectedValue > 0 Then
            strQueryString += " AND BusinessUnitId='" + Me.cbBusinessUnit.SelectedValue + "'"
        End If

        If Me.cbStatus.SelectedValue > 0 Then
            strQueryString += " AND Status='" + Me.cbStatus.SelectedValue + "'"
        End If

        If Me.cbRating.SelectedValue > 0 Then
            strQueryString += " AND Proposalrating='" + Me.cbRating.SelectedValue + "'"
        End If

        If Me.txtKeywords.Text <> "" Then
            strQueryString += " AND Keywords like '%" + Me.txtKeywords.Text.Trim + "%'"
        End If

        If Me.txtJobNumber.Text <> "" Then
            strQueryString += " AND JobNumber ='" + Me.txtJobNumber.Text.Trim + "'"
        End If

        If Me.txtJobName.Text <> "" Then
            strQueryString += " AND JobName ='" + Me.txtJobName.Text.Trim + "'"
        End If

        Return strQueryString

    End Function


    Protected Function GetQueryInfo() As Model.PMS_ProposalInfo

        Dim _JobNumber = Me.txtJobNumber.Text.Trim()
        Dim _JobName = Me.txtJobName.Text.Trim()
        Dim _Keywords = Me.txtKeywords.Text.Trim

        Dim _ClientId As Integer
        Dim _SectorId As Integer

        Dim _StudyTypeId As Integer
        Dim _ProductCategory As Integer
        Dim _BusinessUnit As Integer
        Dim _Status As Integer
        Dim _ProposalRating As Integer



        If Me.cbClient.SelectedValue <> 0 Then
            _ClientId = Utils.DataConvert.ConvertDataToInt32(Me.cbClient.SelectedValue)
        End If
        If Me.cbSector.SelectedValue <> 0 Then
            _SectorId = Utils.DataConvert.ConvertDataToInt32(Me.cbSector.SelectedValue)
        End If

        If Me.cbStudytype.SelectedValue <> 0 Then
            _StudyTypeId = Utils.DataConvert.ConvertDataToInt32(Me.cbStudytype.SelectedValue)
        End If

        If Me.cbProductCategory.SelectedValue > 0 Then
            _ProductCategory = Utils.DataConvert.ConvertDataToInt32(Me.cbProductCategory.SelectedValue)
        End If

        If Me.cbBusinessUnit.SelectedValue <> 0 Then
            _BusinessUnit = Utils.DataConvert.ConvertDataToInt32(Me.cbBusinessUnit.SelectedValue)
        End If

        If Me.cbStatus.SelectedValue <> 0 Then
            _Status = Utils.DataConvert.ConvertDataToInt32(Me.cbStatus.SelectedValue)
        End If

        If Me.cbRating.SelectedValue <> 0 Then
            _ProposalRating = Utils.DataConvert.ConvertDataToInt32(Me.cbRating.SelectedValue)
        End If


        Return New Model.PMS_ProposalInfo(_JobNumber, _JobName, _Keywords, _ClientId, _SectorId, _StudyTypeId, _ProductCategory, _BusinessUnit, _Status, _ProposalRating)
    End Function

    Protected Sub gridResult_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles gridResult.ItemDataBound

        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim id As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnID").Text
            Dim jobNumber As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnJobNumber").Text.Trim
            'e.Item.Cells(2).Text = "<a href='#' onclick=javascript:OpenModifyPage('" + id + "') >aaa</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnEdit").Text = "<a href='Project.aspx?OperateType=Modify&Proid=" & id & "'><B>Edit</B></a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnClientID").Text = ClientInfoBLL.GetClientInfoByID(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnClientID").Text).FullName
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnProductCategoryId").Text = ProductCategory.GetSectorInfoByID(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnProductCategoryId").Text).ProductCategory

            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnSectorID").Text = SectorBLL.GetSectorInfoByID(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnSectorID").Text).Sector
            ' DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnStudyType").Text = StudyTypeBLL.GetStudyTypeByID(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnStudyType").Text).StudyType

            Dim str() As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnStudyType").Text.Split(",")
            Dim strStudyType As String = ""
            If str.Count > 0 Then
                For i = 0 To str.Count - 1
                    strStudyType = strStudyType & StudyTypeBLL.GetStudyTypeByID(str(i).ToString).StudyType.ToString
                    DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnStudyType").Text = strStudyType
                Next


            End If


            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnStatus").Text = ProjectStatusBLL.GetProjectStatusInfoById(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnStatus").Text).ProjctStatus
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnStage").Text = "<a href='#' onclick=javascript:openStageWin('" + "StageForm.aspx?JobNumber=" + jobNumber + "') >Stage</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnQuotation").Text = "<a href='#' onclick=javascript:openWin('" + "ProposalQuotation.aspx?JobNumber=" + jobNumber + "') >Quotation</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnTiming").Text = "<a href='#' onclick=javascript:openWin('" + "ProposalTiming.aspx?JobNumber=" + jobNumber + "') >Timing</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnFileUpload").Text = "<a href='#' onclick=javascript:openWin('" + "ProjectKeyDocUpload.aspx?proid=" + id + "') ><B>File Upload</B></a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnContract").Text = "<a href='#' onclick=javascript:openWin('" + "Projectcontract.aspx?proid=" + id + "') ><B>Go to Contract</B></a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnGo").Text = "<a href='#' onclick=javascript:openWin('" + "ProposalStatus.aspx?proid=" + id + "') ><B>Go/No Go<B></a>"
        End If
    End Sub

    Protected Sub gridResult_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles gridResult.NeedDataSource


        Me.gridResult.DataSource = ProposalInfoBLL.GetProposallistByQueryInfo(GetQueryInfo)



    End Sub

    Private Sub LoadSector()
        Dim ds As DataSet
        ds = SectorBLL.GetSectorInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbSector, ds, "id", "Sector", 1)
        End If
    End Sub

    Private Sub loadProductCategoryBySector(ByVal SectorId As String)
        Dim ds As DataSet

        ds = ProductCategory.GetSectorInfoBySectorId(SectorId)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProductCategory, ds, "id", "ProductCategory", 1)
        End If


    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtJobNumber.Text = ""
        Me.txtJobName.Text = ""
        Me.txtKeywords.Text = ""
        Me.cbSector.SelectedValue = 0
        Me.cbProductCategory.SelectedValue = 0
        Me.cbStudytype.SelectedValue = 0
        Me.cbBusinessUnit.SelectedValue = 0
        Me.cbStatus.SelectedValue = 0
        Me.cbRating.SelectedValue = 0
        Me.cbClient.SelectedValue = 0
    End Sub


    Protected Sub cbSector_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)
        If Me.cbSector.SelectedValue > 0 Then
            loadProductCategoryBySector(Me.cbSector.SelectedValue)
        End If
    End Sub

    Protected Sub cbBusinessUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)
        If Me.cbBusinessUnit.SelectedValue > 0 Then

            If Me.cbBusinessUnit.SelectedValue > 2 Then
                Me.LoadSector()
            Else
                Dim ds As DataSet
                ds = SectorBLL.GetSectorInfoByBusinessUnitId(Me.cbBusinessUnit.SelectedValue)
                If Not ds Is Nothing Then
                    Utils.PageUtils.BindComboBoxList(Me.cbSector, ds, "id", "Sector", 1)
                End If
            End If
        End If
    End Sub


    Protected Sub btnMyProposal_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Session("LoginUserInfo") Is Nothing Then
            MyUserinfo = Session("LoginUserInfo")
        End If

        Dim dv As DataView = ProposalInfoBLL.GetMyProposallistByUserId(MyUserinfo.ID.ToString)
        Me.gridResult.DataSource = dv.Table()
        Me.gridResult.DataBind()
    End Sub
End Class
