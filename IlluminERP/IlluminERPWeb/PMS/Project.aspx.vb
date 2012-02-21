Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils.PageUtils
Imports Utils
Imports DataAccess
Imports System.Collections
Imports System.Collections.Generic
Imports Telerik.Web.UI
Partial Class PMS_Project
    Inherits OperatePageBase

    Private ProjectTypeBLL As New BLL.Base_ProjectTypeBLL
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private SectorBLL As New BLL.Base_SectorBLL
    Private ProductCategory As New BLL.Base_ProductCategoryBLL
    Private StudyType As New BLL.Base_StudyTypeBLL
    Private Proposalrating As New BLL.Base_ProposalRatingBLL

    Private BusinessUnitBLL As New BLL.Base_busiessUnitBLL
    Private MyUserInfoBLL As New BLL.UserInfoBLL
    Private StudyTypeBLL As New BLL.Base_StudyTypeBLL
    Private MyUserinfo As New Model.User_UserInfo
    Private UserInfoBLL As New BLL.UserInfoBLL

    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private ProjectStatusBLL As New BLL.Base_ProjectStatusBLL
    Private ProposalUserinfoBLl As New BLL.PMS_ProposalUserInfoBLL
    Private colUser As New Collection


    Dim info As New Model.PMS_ProposalInfo
    Dim ClientInfo As New Model.Client_ClientInfo
    Dim userinfo As New Model.User_UserInfo



    Protected Overrides Sub InitForm()

        MyBase.InitForm()
        If Not Session("LoginUserInfo") Is Nothing Then
            MyUserinfo = Session("LoginUserInfo")
        End If

        Me.txtJobnumber.ReadOnly = True
        Me.txtCreateDate.ReadOnly = True
        Me.txtCreateDate.Text = Now.Date
        Me.txtPrepared.ReadOnly = True
        Me.txtPrepared.Text = MyUserinfo.E_Name
        Dim type As String = Request("type")
        Dim addonproid As String = Request("sproid")

        If type = "addon" Then
            Me.btnAddon.Visible = False
        End If

        Call InitComboBox()

    End Sub

    Protected Overrides Sub SetForm()
        MyBase.SetForm()
        'get Proposal id from url

        If OperateType = "Modify" Then
            If Not Request.QueryString("Proid") Is Nothing Then
                Dim strId As String = Request.QueryString("Proid")
                '  Me.btnAddon.OnClientClick = "openWin(" + strId + ");return false;"
                Me.btnAddon.Visible = True
                Me.btnDesign.Visible = True
                Me.btnQuotation.Visible = True
                Me.btnSchedule.Visible = True
                Me.btnTeamAssignment.Visible = True
                Me.btnStatus.Visible = True
                Me.txtJobName.Enabled = False
                Me.cbClient.Enabled = False
                Me.btnAddClient.Visible = False
                Me.cbBusinessUnit.Enabled = False

                Call Me.GetproposalInfobyId(strId)
                Me.btnDesign.OnClientClick = "openStageWin(" + info.JobNumber.ToString + ");return false;"
                Me.btnQuotation.OnClientClick = "openQuotationWin(" + info.JobNumber.ToString + ");return false;"
                Me.btnSchedule.OnClientClick = "openScheduleWin(" + info.JobNumber.ToString + ");return false;"
                Me.btnUploadCost.OnClientClick = "openStageComponentCostingFileWin(" + info.JobNumber.ToString + ");return false;"
                Me.btnEstimateCost.OnClientClick = "openEstimateCostWin(" + info.JobNumber.ToString + ");return false;"
                Me.btnActualCost.OnClientClick = "openActualCostWin(" + info.JobNumber.ToString + ");return false;"
                Me.btnCostAnalysis.OnClientClick = "openCostAnalysisWin(" + info.JobNumber.ToString + ");return false;"
                Me.btnTeamAssignment.OnClientClick = "openTeamWin(" + info.Id.ToString + ");return false;"
                Me.btnStatus.OnClientClick = "openUpdateStatusWin(" + info.Id.ToString + ");return false;"

                If ProposalUserinfoBLl.IsExistUserInfo(MyUserinfo.ID, strId) = False Then
                    Call Me.DisableForm()
                End If
            End If
        Else
            Dim type = Request("type")
            If type = "addon" Then
                Dim strId As String = Request.QueryString("Proid")
                Dim addonproid As String = Request("sproid")
                Me.divaddon.Visible = False
                Me.divpanel.Visible = False
                Me.btnAddon.Visible = False
                Me.btnDesign.Visible = False
                Me.btnQuotation.Visible = False
                Me.btnSchedule.Visible = False
                Me.btnTeamAssignment.Visible = False
                Me.btnStatus.Visible = False
                Call Me.GetproposalInfobyId(addonproid)

            Else

                Me.divaddon.Visible = False
                Me.divpanel.Visible = False
                Me.btnAddon.Visible = False
                Me.btnDesign.Visible = False
                Me.btnQuotation.Visible = False
                Me.btnSchedule.Visible = False
                Me.btnTeamAssignment.Visible = False
                Me.btnStatus.Visible = False
            End If

        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'get operate type from url.
        Else
            If Not Session("ProposalUser") Is Nothing Then
                colUser = Session("ProposalUser")


            End If
        End If

    End Sub

    Private Sub DisableForm()
        Me.txtJobName.Enabled = False
        Me.cbBusinessUnit.Enabled = False
        Me.txtProbablity.Enabled = False
        Me.cbClient.Enabled = False
        Me.cbSector.Enabled = False
        Me.cbProductCategory.Enabled = False
        Me.cbStudytype.Enabled = False
        Me.cbProjectOwner.Enabled = False
        Me.txtKeywords.Enabled = False
        Me.cbRating.Enabled = False
        Me.txtDescription.Enabled = False
        Me.btnAddon.Enabled = False
        Me.btnSave.Enabled = False
        Me.btnClose.Enabled = False
        Me.txtPrepared.Enabled = False
        Me.txtCreateDate.Enabled = False
        Me.cbConfidential.Enabled = False
        Me.btnAddClient.Enabled = False

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

        ds = Proposalrating.GetProposalRatingInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbRating, ds, "id", "ProposalRating", 2)
        End If


        Dim dv As DataView
        dv = ProposalInfoBLL.GetProRelationList(strId)
        Me.radGridAddon.DataSource = dv
        Me.radGridAddon.DataBind()



    End Sub

    Private Sub LoadSector()
        Dim ds As DataSet
        ds = SectorBLL.GetSectorInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbSector, ds, "id", "Sector", 2)
        End If
    End Sub

    Private Sub loadProductCategoryBySector(ByVal SectorId As String)
        Dim ds As DataSet

        ds = ProductCategory.GetSectorInfoBySectorId(SectorId)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProductCategory, ds, "id", "ProductCategory", 2)
        End If


    End Sub


    ''' <summary>
    ''' check the pagedate required
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean

        If Me.txtJobName.Text = "" Then
            Me.RadAjaxManager1.Alert("Please input job name !")
            '  strmessage = "Please input job name !"

            Return False
            Exit Function
        End If

        If Me.cbBusinessUnit.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Please select Business Unit!")

            Return False
            Exit Function
        End If



        If cbClient.SelectedValue.Length <= 0 Then
            Me.RadAjaxManager1.Alert("Please select a client !")

            Return False
            Exit Function
        End If



        If Me.cbSector.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert(" Please select sector !")
            Return False
            Exit Function
        End If

        If Me.cbProductCategory.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert(" Please select Product Category !")
            Return False
            Exit Function
        End If

        If Me.cbStudytype.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Please select Study Type !")
            Return False
            Exit Function
        End If

        If Me.txtProbablity.Text = "" Then
            Me.RadAjaxManager1.Alert("Please input probability !")
            Return False
            Exit Function
        End If

        Return True

    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        MyUserinfo = Session("LoginUserInfo")
        If Me.CheckData = True Then

            SetProposalInfo()
            'Team Member
            Dim UserDt As DataTable = GetTeamDt()

            Try
                Dim operatedResult As New Boolean
                Dim intId As Integer
                If OperateType = "New" Then
                    intId = ProposalInfoBLL.AddProposalInfo(info, UserDt, "new")
                    If intId > 0 Then
                        operatedResult = True
                        Dim Proinfo As Model.PMS_ProposalInfo = ProposalInfoBLL.GetProposalInfoByID(intId)
                    Else
                        operatedResult = False
                    End If
                End If

                If OperateType = "Modify" Then

                    info.JobNumber = Me.txtJobnumber.Text.Trim()
                    operatedResult = ProposalInfoBLL.ModifyProposalInfo(info, UserDt)
                    Dim Proinfo As Model.PMS_ProposalInfo = ProposalInfoBLL.GetProposalInfoByID(info.Id)

                End If

                If Request("type") = "addon" Then
                    info.JobNumber = Me.txtJobnumber.Text.Trim()
                    operatedResult = ProposalInfoBLL.AddProposalInfo(info, UserDt, "addon")
                End If


                If operatedResult Then
                    'remind
                    If OperateType = "New" Then
                        Response.Write("<script language=javascript>")
                        Response.Write("alert('success!');window.returnValue='success';")
                        Response.Write("</script>")
                        Dim url As String
                        url = "Proposal.aspx?OperateType=Modify&Proid= " + intId.ToString
                        Response.Redirect(url)
                    Else
                        Response.Write("<script language=javascript>")
                        Response.Write("alert('success!');window.returnValue='success';")
                        Response.Write("</script>")
                        Dim url As String
                        url = "Proposal.aspx?OperateType=Modify&Proid= " & info.Id
                        Response.Redirect(url)
                    End If

                    'close current page
                Else
                    'remind
                    Response.Write("<script language=javascript>")
                    Response.Write("alert('failed!');window.returnValue='failed';")
                    Response.Write("</script>")

                    'close current page
                End If
            Catch ex As Exception
                Throw ex
            End Try

        Else
            ' Me.RadAjaxManager1.Alert("Save fault!")
            Exit Sub

        End If





    End Sub


    Private Function GetTeamDt() As DataTable
        Dim dt As DataTable = Me.CreateUserTable
        Dim dr As DataRow

        'ProjectOwner
        dr = dt.NewRow
        dr("UserId") = Me.cbProjectOwner.SelectedValue
        dr("ProposalUserTypeId") = 2
        dt.Rows.Add(dr)
        dt.AcceptChanges()


        'creater
        dr = dt.NewRow
        dr("UserId") = MyUserinfo.ID
        dr("ProposalUserTypeId") = 1
        dt.Rows.Add(dr)
        dt.AcceptChanges()
        Return dt

    End Function


    Private Sub SetProposalInfo()
        If OperateType = "New" Then

            info.JobName = txtJobName.Text.Trim.ToString.Replace("'", "''")
            info.BusinessUnitId = Me.cbBusinessUnit.SelectedValue


            info.ClientId = Me.cbClient.SelectedValue
            info.ProposalRating = Me.cbRating.SelectedValue
            info.SectorId = Me.cbSector.SelectedValue
            info.ProductCategoryId = Me.cbProductCategory.SelectedValue
            ' info.StudyTypeId = Me.cbStudytype.SelectedValue
            info.Isconfidential = Me.cbConfidential.SelectedValue

            info.Probability = Me.txtProbablity.Value

            info.Description = Me.txtDescription.Text.Trim.ToString.Replace("'", "''")
            info.CreateDate = Me.txtCreateDate.Text.ToString
            info.KeyWords = Me.txtKeywords.Text.Trim

            If Me.cbStudytype.CheckedItems.Count > 0 Then
                Dim sb As New StringBuilder()
                Dim collection As IList(Of RadComboBoxItem) = cbStudytype.CheckedItems

                If collection.Count > 0 Then
                    For Each item As RadComboBoxItem In collection
                        sb.Append(item.Value + ",")
                    Next
                    info.StudyTypeId += Left(sb.ToString(), Len(sb.ToString) - 1)

                    sb.Clear()
                End If
            End If

        Else

            If Request.QueryString("Proid") = 0 Or Request.QueryString("Proid") = "" Then
                info.Id = Request("sproid")
            Else
                info.Id = Request.QueryString("Proid")
            End If


            info.JobNumber = Me.txtJobnumber.Text.ToString

            info.JobName = txtJobName.Text.Trim.ToString.Replace("'", "''")
            info.BusinessUnitId = Me.cbBusinessUnit.SelectedValue

            info.ClientId = Me.cbClient.SelectedValue
            info.SectorId = Me.cbSector.SelectedValue



            info.ProductCategoryId = Me.cbProductCategory.SelectedValue
            ' info.StudyTypeId = Me.cbStudytype.SelectedValue

            info.Probability = Me.txtProbablity.Value

            info.Description = Me.txtDescription.Text.Trim.ToString.Replace("'", "''")
            info.CreateDate = Me.txtCreateDate.Text.ToString

            info.ProposalRating = Me.cbRating.SelectedValue
            info.KeyWords = Me.txtKeywords.Text.Trim

            If Me.cbStudytype.CheckedItems.Count > 0 Then
                Dim sb As New StringBuilder()
                Dim collection As IList(Of RadComboBoxItem) = cbStudytype.CheckedItems

                If collection.Count > 0 Then
                    For Each item As RadComboBoxItem In collection
                        sb.Append(item.Value + ",")
                    Next
                    info.StudyTypeId += Left(sb.ToString(), Len(sb.ToString) - 1)

                    sb.Clear()
                End If
            End If

        End If


    End Sub


    Private Function CreateUserTable() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("UserId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("ProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("ProposalUserTypeId", GetType(System.Int32)))
        Return dt

    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="StrId"></param>
    ''' <remarks></remarks>
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
            Me.cbRating.SelectedValue = info.ProposalRating
            Me.cbSector.SelectedValue = info.SectorId

            Dim ds As DataSet
            ds = ProductCategory.GetSectorInfoBySectorId(info.SectorId)
            If Not ds Is Nothing Then
                Utils.PageUtils.BindComboBoxList(Me.cbProductCategory, ds, "id", "ProductCategory", 2)
            End If

            Me.cbProductCategory.SelectedValue = info.ProductCategoryId

            'Me.cbStudytype.SelectedValue = info.StudyTypeId

            Dim str() As String = info.StudyTypeId.Split(",")

            'If str.Count > 0 Then
            '    For i = 0 To str.Count - 1
            '        Me.cbStudytype.CheckedItemsTexts = True
            '    Next


            'End If

            Dim item As RadComboBoxItem
            For Each item In Me.cbStudytype.Items

                If str.Contains(item.Value) Then
                    item.Checked = True
                End If


            Next

            Me.cbConfidential.SelectedValue = info.Isconfidential
            Me.txtProbablity.Value = info.Probability
            Me.txtCreateDate.Text = info.CreateDate
            Me.txtDescription.Text = info.Description
            Me.txtKeywords.Text = info.KeyWords

            If info.JobIndex <> "-" Then
                Me.divaddon.Visible = False
                Me.divpanel.Visible = False
                Me.btnAddon.Visible = False
            End If

            ds = Me.ProposalUserinfoBLl.GetProposalUserinfoByProId(StrId)

            If Not ds Is Nothing Then
                Dim dt As DataTable = ds.Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        If dr("ProposalUserTypeId") = 1 Then
                            Dim info = Me.UserInfoBLL.GetUserInfoById(dr("UserId"))
                            Me.txtPrepared.Text = info.E_Name
                        End If

                        If dr("ProposalUserTypeId") = 2 Then
                            Dim info = Me.UserInfoBLL.GetUserInfoById(dr("UserId"))
                            Me.cbProjectOwner.SelectedValue = dr("UserId")
                        End If
                    Next
                End If
            End If

        Catch ex As Exception


        End Try



    End Sub

    Protected Sub cbSector_ItemsRequested(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles cbSector.ItemsRequested
        Me.LoadSector()

    End Sub


    Protected Sub cbProductCategory_ItemsRequested(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles cbProductCategory.ItemsRequested
        Me.loadProductCategoryBySector(e.Text)
    End Sub



    Protected Sub radGridAddon_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radGridAddon.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            'e.Item.Cells(2).Text = "<a href='#' onclick=javascript:OpenModifyPage('" + id + "') >aaa</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnClientID").Text = ClientInfoBLL.GetClientInfoByID(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnClientID").Text).FullName

        End If
    End Sub

    Protected Sub cbSector_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbSector.SelectedIndexChanged
        If Me.cbSector.SelectedValue > 0 Then
            loadProductCategoryBySector(Me.cbSector.SelectedValue)
        End If
    End Sub

    Protected Sub cbBusinessUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbBusinessUnit.SelectedIndexChanged
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

    Protected Sub btnAddon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddon.Click
        Dim strUrl As String
        Dim strId As String = Request.QueryString("Proid")
        strUrl = "proposal.aspx?type=addon&sproid=" + strId
        Response.Redirect(strUrl)
    End Sub

    
End Class

