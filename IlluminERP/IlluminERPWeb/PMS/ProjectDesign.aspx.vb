Imports DataAccess
Imports System.Data

Partial Class PMS_ProjectDesign
    Inherits System.Web.UI.Page
    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private UserinfoBLL As New BLL.UserInfoBLL
    Private ProposalUserInfoBLL As New BLL.PMS_ProposalUserInfoBLL
    Private MethodologyInfoBLL As New BLL.Base_MethodologyInfoBLL
    Private SubProjectInfoBLL As New BLL.PMS_SubProjectInfoBLL
    Private PricingDirectCostBLL As New BLL.PMS_PricingDirectCostInfoBLL
    Private PricingTimeCostBLL As New BLL.PMS_PricingTimeCostBLL
    Private PricingSubCOntractBLL As New BLL.PMS_PricingSubContractBLL
    Private PMSRevenueBLL As New BLL.PMS_RevenueBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            InitForm()
            If Not Request.QueryString("ProId") Is Nothing Then
                ViewState("ProId") = Request.QueryString("ProId")
                GetProposalInfo(Request.QueryString("ProId").ToString)
            End If
        Else
            If Not Session("MBPValue") Is Nothing Then
                'Me.txtMBP.Value = Session("MBPValue")
            End If
        End If
    End Sub
    Private Sub InitForm()
        Me.gridResult.DataSource = Me.CreateSubProjectTable
        Me.DataBind()
    End Sub
    Private Sub GetProposalInfo(ByVal StrProId As String)
        Dim ProposalInfo As New Model.PMS_ProposalInfo
        Dim ClientInfo As New Model.Client_ClientInfo
        Dim ProposalUserInfo As New Model.PMS_ProposalUserInfo
        Dim Userinfo As New Model.User_UserInfo


        Dim ds As DataSet
        Dim dt As DataTable = Nothing

        ProposalInfo = ProposalInfoBLL.GetProposalInfoByID(CInt(StrProId))

     
            BindGrid(ProposalInfo.Id)

            ds = MethodologyInfoBLL.GetMethodologyInfoByType(Utils.ConstantsUtils.MethodologyType.Quanti)

            If Not ds Is Nothing Then
                Utils.PageUtils.BindDropDownList(Me.ddlMethodology, ds, "id", "Methodology", 2)
            End If



        ' modify begin, remove btnMBP on the ui
        '如果是外部客户可以点击MBP
        'If ProposalInfo.ClientType = 1 Then
        '    Me.btnMBP.Enabled = False
        'Else
        '    Me.btnMBP.Enabled = True
        'End If
        ' modify end
        Call GetSimulationData()
    End Sub
    Private Sub BindGrid(ByVal strProid As String)
        Dim ds As DataSet
        Dim dt As DataTable
        ds = SubProjectInfoBLL.GetSubProjectInfoByProId(CInt(strProid))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            Me.gridResult.DataSource = dt
            Me.gridResult.DataBind()
        Else
            dt = Me.CreateSubProjectTable
            Me.gridResult.DataSource = dt
            Me.gridResult.DataBind()
        End If
    End Sub
    Private Function CreateSubProjectTable() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("ProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("SubJobNumber", GetType(System.String)))
        dt.Columns.Add(New DataColumn("MethodologyType", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("MethodologyId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("Description", GetType(System.String)))
        Return dt

    End Function

    Protected Sub ddlMethType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMethType.SelectedIndexChanged
        Dim ds As DataSet

        If Me.ddlMethType.SelectedItem.Value = 1 Then ' 定量
            ds = MethodologyInfoBLL.GetMethodologyInfoByType(Utils.ConstantsUtils.MethodologyType.Quanti)

            If Not ds Is Nothing Then
                Utils.PageUtils.BindDropDownList(Me.ddlMethodology, ds, "id", "Methodology", 2)
            End If
        End If

        If Me.ddlMethType.SelectedItem.Value = 2 Then ' 定量
            ds = MethodologyInfoBLL.GetMethodologyInfoByType(Utils.ConstantsUtils.MethodologyType.Quali)

            If Not ds Is Nothing Then
                Utils.PageUtils.BindDropDownList(Me.ddlMethodology, ds, "id", "Methodology", 2)
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim ProposalInfo As New Model.PMS_ProposalInfo
        Dim strProId As String
        Dim strJobNumber As String
        Dim strSubJobNumber As String


        If Request.QueryString("ProId") Is Nothing Then
            Exit Sub
        End If

        If Me.ddlMethodology.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Methodology is not null")
            Exit Sub
        End If

        strProId = Request.QueryString("ProId")

        ProposalInfo = ProposalInfoBLL.GetProposalInfoByID(CInt(strProId))
        strJobNumber = ProposalInfo.JobNumber.ToString
        strSubJobNumber = GetSubJobNumber(strJobNumber)

        SubProjectInfo.ProId = CInt(strProId)
        SubProjectInfo.MethodologyType = Me.ddlMethType.SelectedValue
        SubProjectInfo.MethodologyId = Me.ddlMethodology.SelectedValue
        SubProjectInfo.SubJobNumber = strSubJobNumber.ToString.Trim
        SubProjectInfo.Description = Utils.DataConvert.ConvertStringAsSqlString(txtDescription.Text.ToString.Trim)
        SubProjectInfo.Status = 0

        If SubProjectInfoBLL.AddSubProjectInfo(SubProjectInfo) > 0 Then
            BindGrid(ProposalInfo.Id)
            Me.txtDescription.Text = String.Empty
        End If
    End Sub
    Private Function GetSubJobNumber(ByVal StrJobNumber As String) As String
        Dim strTag As String
        Dim strSubJobNumber As String
        Dim SubProjectInfo As New Model.PMS_SubProjectInfo

        Dim MethodologyInfo As New Model.Base_MethodologyInfo

        MethodologyInfo = MethodologyInfoBLL.GetMethodologyInfo(Me.ddlMethodology.SelectedValue)
        strTag = MethodologyInfo.Tag

        strSubJobNumber = SubProjectInfoBLL.GetSubJobNumberByJobNumberMethTag(StrJobNumber, strTag)

        Return strSubJobNumber


    End Function

    Protected Sub gridResult_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles gridResult.ItemDataBound

        Dim MethodologyInfo As New Model.Base_MethodologyInfo
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim strMethId As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("MethodologyIdColumn").Text

            MethodologyInfo = MethodologyInfoBLL.GetMethodologyInfo(CInt(strMethId))
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("MethodologyIdColumn").Text = MethodologyInfo.Methodology


            'MethodologyTypeColumn
            If DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("MethodologyTypeColumn").Text = "1" Then
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("MethodologyTypeColumn").Text = "Quanti"
            Else
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("MethodologyTypeColumn").Text = "Quali"
            End If

            ' add design column
            Dim subProId As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("Id").Text
            'e.Item.Cells(2).Text = "<a href='#' onclick=javascript:OpenModifyPage('" + id + "') >aaa</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("designColumn").Text = "<a href='#' onclick=javascript:OpenProjectDesignCostingPage('" + subProId + "') >Design</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("costColumn").Text = "<a href='#' onclick=javascript:OpenProjectCostPage('" + subProId + "') >Cost</a>"
        End If
    End Sub
    ''' <summary>
    ''' Delete command.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub gridResult_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles gridResult.DeleteCommand
        Dim strId As String
        Dim strProid As String
        Dim info As New Model.PMS_SubProjectInfo
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            strId = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("Id").Text
            strProid = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("ProId").Text
            info.Id = strId
            info.Status = 9

            If SubProjectInfoBLL.UpdateSubProjectStatus(info) = True Then
                Call BindGrid(strProid)
            End If
        End If
    End Sub
    Protected Sub txtProfit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProfit.TextChanged
        Dim DecDirectCost As Decimal
        Dim DecTimeCost As Decimal
        Dim DecTotalCost As Decimal
        Dim DecPricetoClient As Decimal

        If Me.txtDirectCost.Text = String.Empty Then
            DecDirectCost = 0
        Else
            DecDirectCost = Me.txtDirectCost.Value
        End If

        If Me.txtTimeCost.Text = String.Empty Then
            DecTimeCost = 0
        Else
            DecTimeCost = Me.txtTimeCost.Value
        End If
        DecTotalCost = DecTimeCost + DecDirectCost
        ''''''''''
        If Me.txtProfit.Text = String.Empty Then
            Exit Sub
        End If

        DecPricetoClient = DecTotalCost * (1 + Convert.ToDecimal(Me.txtProfit.Value) / 100) / 0.95

        Me.txtPricetoClient.Value = DecPricetoClient

        Call GetAboutPriceClientValue(DecPricetoClient)
    End Sub

    '获取Simulation 数据
    Private Sub GetSimulationData()
        Dim decdirectCost As Decimal
        Dim decTimeCost As Decimal
        Dim decSubContractCost As Decimal
        Dim decTotalCost As Decimal

        Dim ds As DataSet
        Dim dt As DataTable

        Dim pmsRevenueInfo As New Model.PMS_Revenue



        '获取Direct Cost
        ds = Me.PricingDirectCostBLL.GetSumTotalCostByProId(ViewState("ProId"))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    decdirectCost = dr("TotalCost")
                Next
            Else
                decdirectCost = 0
            End If

        Else
            decdirectCost = 0
        End If

        '获取Time Cost
        ds = Me.PricingTimeCostBLL.GetSumTotalCostByProId(ViewState("ProId"))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    decTimeCost = dr("TotalCost")
                Next
            Else
                decTimeCost = 0
            End If

        Else
            decTimeCost = 0
        End If


        '获取Direct Cost
        ds = Me.PricingSubCOntractBLL.GetSumTotalCostByProId(ViewState("ProId"))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    decSubContractCost = dr("TotalCost")
                Next
            Else
                decSubContractCost = 0
            End If

        Else
            decSubContractCost = 0
        End If

        Me.txtDirectCost.Value = decdirectCost + decSubContractCost
        Me.txtTimeCost.Value = decTimeCost

        decTotalCost = decdirectCost + decSubContractCost + decTimeCost

        Me.txtTotalCost.Value = decTotalCost

        If decTotalCost > 0 Then
            Me.txtDirectCostPer.Value = (decdirectCost + decSubContractCost) / decTotalCost * 100
            Me.txtTimeCostPer.Value = decTimeCost / decTotalCost * 100
        Else
            Me.txtDirectCostPer.Value = 0
            Me.txtDirectCostPer.Value = 0
        End If


        pmsRevenueInfo = Me.PMSRevenueBLL.GetRevenueByProId(ViewState("ProId"))
        If Not pmsRevenueInfo Is Nothing Then
            Me.txtProfit.Value = pmsRevenueInfo.Profit
            Me.txtPricetoClient.Value = pmsRevenueInfo.Revenue
            ' modify begin
            'Me.txtMBP.Value = pmsRevenueInfo.MBP
            'Me.txtMBPReason.Text = pmsRevenueInfo.MBPReason.ToString
            ' modify end
        End If

        Call GetAboutPriceClientValue(Convert.ToDecimal(Me.txtPricetoClient.Value))
    End Sub

    Protected Sub txtPricetoClient_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPricetoClient.TextChanged
        Dim DecDirectCost As Decimal
        Dim DecTimeCost As Decimal
        Dim DecTotalCost As Decimal
        Dim DecProfit As Decimal
        Dim DecPricetoClient As Decimal

        If Me.txtDirectCost.Text = String.Empty Then
            DecDirectCost = 0
        Else
            DecDirectCost = Me.txtDirectCost.Value
        End If

        If Me.txtTimeCost.Text = String.Empty Then
            DecTimeCost = 0
        Else
            DecTimeCost = Me.txtTimeCost.Value
        End If
        DecTotalCost = DecTimeCost + DecDirectCost
        ''''''''''
        If Me.txtPricetoClient.Text = String.Empty Then
            Exit Sub
        End If
        DecPricetoClient = Convert.ToDecimal(Me.txtPricetoClient.Value)
        DecProfit = (DecPricetoClient * 0.95 / DecTotalCost - 1) * 100

        Me.txtProfit.Value = DecProfit
        Call GetAboutPriceClientValue(DecPricetoClient)
    End Sub

    Private Sub GetAboutPriceClientValue(ByVal decPriceClient As Decimal)

        Me.txtTax.Value = decPriceClient * 0.05
        Me.txtRevenue.Value = decPriceClient - decPriceClient * 0.05
        ' modify begin
        'Me.txtDirectCost1.Value = Me.txtDirectCost.Value
        'If Convert.ToDecimal(Me.txtRevenue.Value) = 0 Then
        'Me.txtDirectCostPer1.Value = 0
        'Else
        '    Me.txtDirectCostPer1.Value = Convert.ToDecimal(Me.txtDirectCost1.Value) / Convert.ToDecimal(Me.txtRevenue.Value) * 100
        'End If

        'Me.txtGM.Value = Convert.ToDecimal(Me.txtRevenue.Value) - Convert.ToDecimal(Me.txtDirectCost1.Value)

        'If Convert.ToDecimal(Me.txtRevenue.Value) = 0 Then
        '    Me.txtGMPer.Value = 0
        'Else
        '    Me.txtGMPer.Value = Convert.ToDecimal(Me.txtGM.Value) / Convert.ToDecimal(Me.txtRevenue.Value) * 100
        'End If

        'Me.txtTimeCost1.Value = Me.txtTimeCost.Value
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim info As New Model.PMS_Revenue

        If Me.txtProfit.Text = String.Empty Or Me.txtPricetoClient.Text = String.Empty Then
            Exit Sub
        End If

        info.ProId = ViewState("ProId")
        info.Revenue = Me.txtPricetoClient.Value
        info.Profit = Me.txtProfit.Value
        ' modify begin,remove Mpb suggest
        'info.MBP = Me.txtMBP.Value
        'info.MBPReason = Me.txtMBP.Text.ToString
        ' modify end
        If PMSRevenueBLL.IsExitRecord(ViewState("ProId")) = True Then
            'Update
            If PMSRevenueBLL.UpdateProjectRevenue(info) = True Then
                Me.RadAjaxManager1.Alert("Save Success!")
            Else
                Me.RadAjaxManager1.Alert("Save Fault!")
            End If
        Else
            If PMSRevenueBLL.AddProjectRevenue(info) > 0 Then
                Me.RadAjaxManager1.Alert("Save Success!")
            Else
                Me.RadAjaxManager1.Alert("Save Fault!")
            End If
        End If

    End Sub


    ' modify begin, remove btnMBP on the page
    'Protected Sub btnMBP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMBP.Click
    '    Dim info As New Model.PMS_ProposalInfo
    '    info = Me.ProposalInfoBLL.GetProposalInfoByID(ViewState("ProId"))
    '    Dim strProId As String = ViewState("ProId")
    '    Dim strSectorId As String = info.SectorId
    '    ' remove
    '    'Me.Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>javascript:openWindow('PricingMBP.aspx?Proid=" + strProId.ToString + "&SectorId=" + strSectorId.ToString + "','middle2','middle2',true);</script>")

    'End Sub
    ' modify end

    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Server.Transfer("ProjectQuery.aspx")
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Server.Transfer("ProjectQuery.aspx")
    End Sub
End Class
