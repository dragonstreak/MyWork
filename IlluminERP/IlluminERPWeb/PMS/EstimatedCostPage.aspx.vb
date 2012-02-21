Imports DataAccess.Model
Imports Telerik.Web.UI
Imports System.Data
Imports DataAccess
Imports Utils

Partial Class PMS_EstimatedCostPage
    Inherits System.Web.UI.Page
    Dim operationCostBLL As New PMS_OperationCostBLL
    ''' <summary>
    ''' Default cost type will be estimate.
    ''' </summary>
    ''' <remarks></remarks>
    Private costType As String = "Estimate"
    ''' <summary>
    ''' This is the page load event.
    ''' Please mind that JobNumber and Cost will get from querystring.
    ''' if Cost type is Estimate, then this page will be the page for estimate
    ''' if Cost type is Actual, then this page will be the page for Actua.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim jobNumber As String
        jobNumber = Page.Request.QueryString("JobNUmber")
        costType = Page.Request.QueryString("CostType")
        If Not Page.IsPostBack Then
            Dim projectCostDetail As DataSet = operationCostBLL.GetProjectAndCostDetail(costType, jobNumber)
            ViewState("ProjectAndCostDetail") = projectCostDetail
            InitJobInformation(projectCostDetail)
            InitTab(projectCostDetail)
        End If

    End Sub
    ''' <summary>
    ''' This method is used to init the job information.
    ''' calc the amount percentage also.
    ''' </summary>
    ''' <param name="projectCostDetail"></param>
    ''' <remarks></remarks>
    Private Sub InitJobInformation(ByVal projectCostDetail As DataSet)
        If projectCostDetail Is Nothing Then
            Return
        End If
        If projectCostDetail.Tables.Count < 1 Then
            Return
        End If
        If projectCostDetail.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim jobNumber As String = projectCostDetail.Tables(0).Rows(0)("JobNumber").ToString
        Dim jobName As String = projectCostDetail.Tables(0).Rows(0)("JobName").ToString
        Dim contractAmountStr As String = projectCostDetail.Tables(0).Rows(0)("ContractAmount").ToString
        Dim clientName As String = projectCostDetail.Tables(0).Rows(0)("C_Name").ToString

        Me.txtJobNumber.Text = jobNumber
        Me.txtJobName.Text = jobName
        Me.txtContractAmount.Text = contractAmountStr
        Me.txtClient.Text = clientName
        '计算占合同金额
        If contractAmountStr = "" Then
            Return
        End If
        If projectCostDetail.Tables.Count < 3 Then
            Return
        End If
        If projectCostDetail.Tables(2).Rows.Count = 0 Then
            Return
        End If
       
        Dim costPercentage As Decimal = 0
        Try
            Dim costTotal As Decimal = 0
            For Each costRow As DataRow In projectCostDetail.Tables(2).Rows
                If costRow("ComponentId").ToString = "-1" Then
                    costTotal += CType(costRow("TotalCost"), Decimal)
                End If
            Next
            Dim contractAmount As Decimal = CType(contractAmountStr, Decimal)

            If costTotal > 0 Then
                costPercentage = costTotal * 100 / contractAmount
            End If
        Catch ex As Exception

        End Try
        
        Me.txtAmountPercentage.Text = costPercentage.ToString("#.##")

        'Need do control to others 
        Me.btnEmail.Enabled = costPercentage > 5
        Me.btnApprove.Enabled = costPercentage > 5
       
    End Sub
    ''' <summary>
    ''' This method is used to init the tab,
    ''' The first datatable will be the information of this job
    ''' The second table will be the information of the every component, it will be used to create tab
    ''' The third table will be the costing detail of every component, it will be the datasource of every cost user control.
    ''' </summary>
    ''' <param name="projectCostDetail"></param>
    ''' <remarks></remarks>
    Private Sub InitTab(ByVal projectCostDetail As DataSet)
        If projectCostDetail Is Nothing Then
            Return
        End If
        If projectCostDetail.Tables.Count < 2 Then
            Return
        End If
        If projectCostDetail.Tables(1).Rows.Count = 0 Then
            Return
        End If
        Dim i As Integer = 0
        For Each costRow As DataRow In projectCostDetail.Tables(1).Rows
            Dim componentName As String = costRow("ComponentName").ToString
            Dim componentId As String = costRow("ComponentId").ToString
            Dim tab As New RadTab
            tab.Text = componentName
            tab.Value = componentId

            'After creating the tab, add page view to this tab.
            CostTabStrip.Tabs.Add(tab)
            Dim pageView As New RadPageView()
            'Set the id of page view to component id, becuase we will use it to get data from data source.
            pageView.ID = componentId
            pageView.TabIndex = i
            CostMultiplePage.PageViews.Add(pageView)
            i = i + 1
        Next
       
    End Sub
    ''' <summary>
    ''' As of now, we don't use this event, because we create the page view in PageViewCreated event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub CostTabStrip_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles CostTabStrip.TabClick
        'Dim projectcostdetail As DataSet = ViewState("ProjectAndCostDetail")
        'Dim componentid As String = e.Tab.Value
        'Dim usercontrol As Control = Nothing
        'Dim usercontrolname As String = "../ascx/costingitemcontrol.ascx"
        'usercontrol = Page.LoadControl(usercontrolname)
        'usercontrol.ID = componentid + "_usercontrol"
        'Dim pageview As RadPageView = Nothing
        'For Each temppage As RadPageView In CostMultiplePage.PageViews
        '    If temppage.ID = componentid Then
        '        pageview = temppage
        '        Exit For
        '    End If
        'Next
        'If pageview Is Nothing Then
        '    Return
        'End If
        'pageview.Controls.Add(usercontrol)
        ''means doesn't has cost detail table
        'If projectcostdetail.Tables.Count < 3 Then
        '    Return
        'End If
        ''means detail table doesn't has any cost 
        'If projectcostdetail.Tables(2).Rows.Count = 0 Then
        '    Return
        'End If
        ''means already load this datasource
        'If Not DirectCast(usercontrol, Ascx_CostingItemControl).CostDataSource Is Nothing Then
        '    DirectCast(usercontrol, Ascx_CostingItemControl).DataBind()
        '    Return
        'End If
        'Dim costdetaillist As New List(Of PMS_OperationCost)
        'Dim costrowcollection As DataRow() = projectcostdetail.Tables(2).Select("componentid=" + componentid)
        'ColumnMappingManage.MappingListByDataRowArr(costdetaillist, costrowcollection)
        'DirectCast(usercontrol, Ascx_CostingItemControl).CostDataSource = costdetaillist
        'DirectCast(usercontrol, Ascx_CostingItemControl).DataBind()
    End Sub
    ''' <summary>
    ''' This is the page view created event.
    ''' every time we click the tab, it will be called
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub CostMultiplePage_PageViewCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMultiPageEventArgs) Handles CostMultiplePage.PageViewCreated

        Dim userControl As Control = Nothing  'e.PageView.FindControl(e.PageView.ID)
        For Each subControl As Control In e.PageView.Controls
            If subControl.ID = e.PageView.ID Then
                userControl = subControl
                Exit For
            End If
        Next
        If userControl Is Nothing Then
            Dim userControlName As String = "../Ascx/CostingItemControl.ascx"
            userControl = Page.LoadControl(userControlName)
            userControl.ID = e.PageView.ID + "_userControl"
            e.PageView.Controls.Add(userControl)
        End If

        Dim projectCostDetail As DataSet = ViewState("ProjectAndCostDetail")
        'means doesn't has cost detail table
        If projectCostDetail.Tables.Count < 3 Then
            Return
        End If
        'means detail table doesn't has any cost 
        If projectCostDetail.Tables(2).Rows.Count = 0 Then
            Return
        End If
        'means already load this datasource
        If Not DirectCast(userControl, Ascx_CostingItemControl).CostDataSource Is Nothing Then
            DirectCast(userControl, Ascx_CostingItemControl).DataBind()
            Return
        End If
        Dim costDetailList As New List(Of PMS_OperationCost)
        Dim costRowCollection As DataRow() = projectCostDetail.Tables(2).Select("ComponentId=" + e.PageView.ID)
        'create the list from data set
        ColumnMappingManage.MappingListByDataRowArr(costDetailList, costRowCollection)
        DirectCast(userControl, Ascx_CostingItemControl).CostDataSource = costDetailList
        Dim tabName As String = CostTabStrip.Tabs(e.PageView.TabIndex).Text
        Dim percentage As Decimal = 0
        If Not String.IsNullOrEmpty(Me.txtAmountPercentage.Text) Then
            percentage = CType(Me.txtAmountPercentage.Text, Decimal)
        End If
        'ControlByCostType method is used to contol whether to display the estimatecost and diff column in grid, whether to show the email button
        DirectCast(userControl, Ascx_CostingItemControl).ControlByCostType(costType, tabName, percentage)
        'Data bind method is used to bind the datagrid.
        DirectCast(userControl, Ascx_CostingItemControl).DataBind()

    End Sub

    ''' <summary>
    ''' Tony: this method is used to send email
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click

    End Sub
    ''' <summary>
    ''' Tony: this method is use to approve cost
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click

    End Sub
End Class
