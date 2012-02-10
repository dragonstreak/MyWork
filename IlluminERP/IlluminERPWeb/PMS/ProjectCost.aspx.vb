Imports DataAccess
Imports System
Imports System.Data
Imports Utils
Imports Utils.ConstantsUtils
Imports Telerik.Web.UI
Imports DataAccess.Model

Partial Class PMS_ProjectCost
    'Inherits System.Web.UI.Page
    Inherits PageBase
    Private DepCostCategoryBLL As New BLL.Base_DepMapCostCategoryBLL
    Private CostCategoryBLL As New BLL.Base_CostCategoryBLL
    Private PricingDirectCostBLL As New BLL.PMS_PricingDirectCostInfoBLL
    Private PricingPositionBLL As New BLL.Base_PricingPositionBLL
    Private PricingStageBLL As New BLL.Base_PricingProjectStageBLL
    Private PricingTimeCostBLL As New BLL.PMS_PricingTimeCostBLL
    Private PricingCityInfo As New BLL.PMS_PricingCityInfoBLL
    ''' <summary>
    ''' As the column of the time grid are added dynamicly, we should add the column in preinit event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPreInit(ByVal e As System.EventArgs)
        MyBase.OnPreInit(e)
        ViewState("SubProId") = Request.QueryString("SubProId") '6
        InitCity()
        ViewState("CityId") = Me.ddlCity.SelectedValue
        InitTempGrid()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            InitCombobox()
            'tony remove init datagrid function, the datasource will be set in need datasource event.
            'InitDataGrid()
            'GetSubProjectDesignInfo(ViewState("SubProId"))
        End If
    End Sub
#Region "useless function,have been removed"

    ''' <summary>
    ''' This method is useless.
    ''' </summary>
    ''' <param name="strProid"></param>
    ''' <remarks></remarks>
    Private Sub GetSubProjectDesignInfo(ByVal strProid As String)
        Call BindGrid(Utils.ConstantsUtils.Department.FLW)
        Call BindGrid(Utils.ConstantsUtils.Department.EDP)
        Call BindGrid(Utils.ConstantsUtils.Department.QC)
        Call BindGrid(Utils.ConstantsUtils.Department.CMR)
        Call BindGrid(Utils.ConstantsUtils.Department.CATI)

    End Sub
    'tony remove this function, the datasource will be set in need datasource event
    Private Function GetTimeCostGridData(ByVal DepId As Integer) As DataTable
        Dim dsTimeCost As DataSet
        Dim dtTimeCost As DataTable
        Dim dsStage As DataSet
        Dim dtStage As DataTable
        Dim colColumn As New Collection
        Dim dtNew As New DataTable
        Dim drNew As DataRow
        Dim i As Integer

        'tony modify,use viewstate instead of session
        Select Case DepId
            Case Utils.ConstantsUtils.Department.FLW
                colColumn = ViewState("FWTimeCostColumn")
                'dtNew = Session("FwTimeCostGrid")
                dtNew = ViewState("FwTimeCostGrid")
            Case Utils.ConstantsUtils.Department.EDP
                colColumn = ViewState("EDPTimeCostColumn")
                'dtNew = Session("EDPTimeCostGrid")
                dtNew = ViewState("EDPTimeCostGrid")
            Case Utils.ConstantsUtils.Department.CATI
                colColumn = ViewState("CATITimeCostColumn")
                'dtNew = Session("CATITimeCostGrid")
                dtNew = ViewState("CATITimeCostGrid")
            Case Utils.ConstantsUtils.Department.QC
                colColumn = ViewState("QCTimeCostColumn")
                'dtNew = Session("QCTimeCostGrid")
                dtNew = ViewState("QCTimeCostGrid")
            Case Utils.ConstantsUtils.Department.CMR
                colColumn = ViewState("CMRTimeCostColumn")
                'dtNew = Session("CMRTimeCostGrid")
                dtNew = ViewState("CMRTimeCostGrid")
        End Select
        If Not colColumn Is Nothing Then

            dsStage = Me.PricingStageBLL.GetPricingStageByDepId(DepId)
            If Not dsStage Is Nothing Then
                dtStage = dsStage.Tables(0)
                For Each drStage As DataRow In dtStage.Rows
                    drNew = dtNew.NewRow
                    drNew(0) = drStage("ID")
                    drNew(1) = drStage("Stage")
                    For i = 1 To colColumn.Count
                        dsTimeCost = Me.PricingTimeCostBLL.GetPricingTimeCostBySubProidCityIdDepIdStageId(ViewState("SubProId"), ViewState("CityId"), DepId, drStage("ID"), colColumn(i))
                        If dsTimeCost Is Nothing Then
                            drNew(i + 1) = 0
                        Else
                            dtTimeCost = dsTimeCost.Tables(0)
                            For Each drTimeCost As DataRow In dtTimeCost.Rows
                                drNew(i + 1) = drTimeCost("Amount")
                            Next
                        End If
                    Next

                    dtNew.Rows.Add(drNew)

                Next
            End If


        End If

        Return dtNew
    End Function
    Private Sub InitDataGrid()
        'Me.rdFWDirectCost.DataSource = Me.CreateTempGrid
        'Me.rdFWDirectCost.DataBind()

        'Me.rdEDPDirectCost.DataSource = Me.CreateTempGrid
        'Me.rdEDPDirectCost.DataBind()

        'Me.rdQCDirectCost.DataSource = Me.CreateTempGrid
        'Me.rdQCDirectCost.DataBind()

        'Me.rdCMRDirectCost.DataSource = Me.CreateTempGrid
        'Me.rdCMRDirectCost.DataBind()

        'Me.rdCATIDirectCost.DataSource = Me.CreateTempGrid
        'Me.rdCATIDirectCost.DataBind()




    End Sub
    Private Function CreateTempGrid() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("SubProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("DepId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("CityId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("CostCategoryId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("UnitPrice", GetType(System.Decimal)))
        dt.Columns.Add(New DataColumn("Quantity", GetType(System.Decimal)))
        dt.Columns.Add(New DataColumn("TotalCost", GetType(System.Decimal)))
        dt.Columns.Add(New DataColumn("Description", GetType(System.String)))
        Return dt
    End Function
    Private Sub InitTimeGridLayout(ByVal Grid As RadGrid, ByVal DepId As Integer)

        Dim i As Integer
        Dim base_PricingPositionInfo As New Model.Base_PricingPosition
        'Tony modify
        'Grid.Bands(0).Columns(0).Hidden = True
        'Grid.Bands(0).ColFootersVisible = ShowMarginInfo.Yes
        'Grid.Bands(0).Columns(1).FooterText = "Total:"
        'Grid.Columns(1).Width = 150
        'Grid.DisplayLayout.RowStyleDefault.Wrap = False
        'Grid.DisplayLayout.RowStyleDefault.TextOverflow = TextOverflow.Ellipsis
        'Grid.Bands(0).ColFootersVisible = ShowMarginInfo.Yes
        'Grid.Bands(0).Columns(1).AllowUpdate = AllowUpdate.No
        Grid.Columns(0).Visible = False

        For i = 0 To Grid.Columns.Count - 1

            If DepId = Utils.ConstantsUtils.Department.CMR Then
                'Grid.Columns(i).AllowResize = AllowSizing.Free
                'Grid.Columns(i).Width = 50
                Grid.Columns(i).Resizable = True
                Grid.Columns(i).HeaderStyle.Width = 50
            Else
                'Grid.Columns(i).AllowResize = AllowSizing.Free
                'Grid.Columns(i).Width = 80
                Grid.Columns(i).Resizable = True
                Grid.Columns(i).HeaderStyle.Width = 80
            End If
        Next
        'tony set first column readonly
        CType(Grid.Columns(0), GridBoundColumn).ReadOnly = True

        If DepId = Utils.ConstantsUtils.Department.CMR Then

            'Grid.Columns(1).Width = 120
            Grid.Columns(1).HeaderStyle.Width = 120
        Else
            'Grid.Columns(1).Width = 150
            Grid.Columns(1).HeaderStyle.Width = 150
        End If

        For i = 2 To Grid.Columns.Count - 1
            Grid.Columns(i).HeaderStyle.HorizontalAlign = HorizontalAlign.Right


            'With Grid.Bands(0).Columns(i)
            '    .Format = "###,###"
            '    .CellStyle.HorizontalAlign = HorizontalAlign.Right
            '    .FooterTotal = Infragistics.WebUI.UltraWebGrid.SummaryInfo.Sum
            '    .FooterStyle.HorizontalAlign = HorizontalAlign.Right
            '    .Format = "###,###"
            '    .CellStyle.HorizontalAlign = HorizontalAlign.Right
            'End With
            'Dim intKey As Integer = Grid.Columns(i).Header.Key
            Dim intKey As Integer = Grid.Columns(i).HeaderText
            base_PricingPositionInfo = Me.PricingPositionBLL.GetPricingPositionById(intKey)
            If Not base_PricingPositionInfo Is Nothing Then
                'Grid.Columns(i).Header.Caption = base_PricingPositionInfo.ShortName & "/" & base_PricingPositionInfo.Rate
                Grid.Columns(i).HeaderText = base_PricingPositionInfo.ShortName & "/" & base_PricingPositionInfo.Rate
            End If
        Next
    End Sub
    ''' <summary>
    ''' This method is used to bind every grid after add event.
    ''' now is useless.
    ''' </summary>
    ''' <param name="DepId">Pass the depid.</param>
    ''' <remarks></remarks>
    Private Sub BindGrid(ByVal DepId As Integer)
        Dim ds As DataSet
        Dim dt As DataTable = Nothing
        Dim decTotalCost As Decimal = Nothing


        ds = Me.PricingDirectCostBLL.GetDirectCostInfoByCityIdDepIdSubProId(ViewState("CityId"), DepId, ViewState("SubProId"))
        'Select Case DepId
        'Case Utils.ConstantsUtils.Department.FLW  'FLW
        '    If Not ds Is Nothing Then
        '        dt = ds.Tables(0)
        '        'Me.rdFWDirectCost.DataSource = dt
        '        'Me.rdFWDirectCost.DataBind()
        '        rdFWDirectCost.Rebind()

        '    End If

        '    dt = ds.Tables(0)
        '    For Each dr As DataRow In dt.Rows
        '        decTotalCost = decTotalCost + dr("TotalCost")
        '    Next
        '    'tony modify
        '    'Me.wpFWDirectCost.Header.Text = "FLW Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        '    Me.RadTabStrip3.Tabs(0).Text = "FLW Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"

        'Case Utils.ConstantsUtils.Department.EDP 'EDP
        '    If Not ds Is Nothing Then
        '        dt = ds.Tables(0)
        '        'Me.rdEDPDirectCost.DataSource = dt
        '        'Me.rdEDPDirectCost.DataBind()
        '        rdEDPDirectCost.Rebind()

        '    End If

        '    dt = ds.Tables(0)
        '    For Each dr As DataRow In dt.Rows
        '        decTotalCost = decTotalCost + dr("TotalCost")
        '    Next
        '    'Me.wpEdpDirectCost.Header.Text = "EDP Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        '    Me.RadTabStrip3.Tabs(4).Text = "EDP Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"

        'Case Utils.ConstantsUtils.Department.CMR 'EDP
        '    If Not ds Is Nothing Then
        '        dt = ds.Tables(0)
        '        'Me.rdCMRDirectCost.DataSource = dt
        '        'Me.rdCMRDirectCost.DataBind()
        '        rdCMRDirectCost.Rebind()

        '    End If

        '    dt = ds.Tables(0)
        '    For Each dr As DataRow In dt.Rows
        '        decTotalCost = decTotalCost + dr("TotalCost")
        '    Next
        '    'Me.wpCMRDirectCost.Header.Text = "CMR Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        '    Me.RadTabStrip3.Tabs(8).Text = "CMR Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"

        'Case Utils.ConstantsUtils.Department.QC  'qc
        '    If Not ds Is Nothing Then
        '        dt = ds.Tables(0)
        '        'Me.rdQCDirectCost.DataSource = dt
        '        'Me.rdQCDirectCost.DataBind()
        '        rdQCDirectCost.Rebind()
        '    End If

        '    dt = ds.Tables(0)
        '    For Each dr As DataRow In dt.Rows
        '        decTotalCost = decTotalCost + dr("TotalCost")
        '    Next
        '    'Me.wpQCdirectCost.Header.Text = "QC Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        '    Me.RadTabStrip3.Tabs(6).Text = "QC Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        'Case Utils.ConstantsUtils.Department.CATI
        '    If Not ds Is Nothing Then
        '        dt = ds.Tables(0)
        '        'Me.rdCATIDirectCost.DataSource = dt
        '        'Me.rdCATIDirectCost.DataBind()
        '        rdCATIDirectCost.Rebind()
        '    End If

        '    dt = ds.Tables(0)
        '    For Each dr As DataRow In dt.Rows
        '        decTotalCost = decTotalCost + dr("TotalCost")
        '    Next
        '    'Me.wpCATIDirectCost.Header.Text = "CATI Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        '    Me.RadTabStrip3.Tabs(2).Text = "CATI Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        'End Select


    End Sub
#End Region
#Region "Init functions."
    Private Sub InitCity()
        Dim ds As DataSet
        'tony add
        'get city list and bind to dropdownlist ddlCity
        ddlCity.Attributes.Add("style", "visibility:hidden")
        ds = PricingCityInfo.GetPricingCityInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.ddlCity, ds, "Id", "PricingCity", 0)
        End If

    End Sub
    ''' <summary>
    ''' This function is used to init combobox,
    ''' tony modify, use dropdownlist instead of combobox.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitCombobox()
        Dim ds As DataSet

        ds = Me.DepCostCategoryBLL.GetCostCategoryByDepID(Utils.ConstantsUtils.Department.FLW)
        'tony modify,use dropdownlist instead of combobox
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.cbFWCostCategory, ds, "CostCategoryId", "CostCagetory", 2)
        End If

        ds = Me.DepCostCategoryBLL.GetCostCategoryByDepID(Utils.ConstantsUtils.Department.EDP)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.cbEDPCostCategory, ds, "CostCategoryId", "CostCagetory", 2)
        End If

        ds = Me.DepCostCategoryBLL.GetCostCategoryByDepID(Utils.ConstantsUtils.Department.QC)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.cbQCCostCategory, ds, "CostCategoryId", "CostCagetory", 2)
        End If

        ds = Me.DepCostCategoryBLL.GetCostCategoryByDepID(Utils.ConstantsUtils.Department.CMR)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.cbCMRCostCategory, ds, "CostCategoryId", "CostCagetory", 2)
        End If
    End Sub
    ''' <summary>
    ''' Init 5 time cost grid,
    ''' this method will be called in OnPreInit event
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitTempGrid()
        Dim flwTable As DataTable = Me.CreateTimeGrid(Utils.ConstantsUtils.Department.FLW)
        Me.AddColumnToDataGrid(wgdFWTimeCost, Utils.ConstantsUtils.Department.FLW, flwTable)
        Dim timeTable As DataTable = Me.CreateTimeGrid(Utils.ConstantsUtils.Department.CATI)
        Me.AddColumnToDataGrid(wgdCATITimeCost, Utils.ConstantsUtils.Department.CATI, timeTable)
        Dim edpTable As DataTable = Me.CreateTimeGrid(Utils.ConstantsUtils.Department.EDP)
        Me.AddColumnToDataGrid(wgdEDPTimeCost, Utils.ConstantsUtils.Department.EDP, edpTable)
        Dim qcTable As DataTable = Me.CreateTimeGrid(Utils.ConstantsUtils.Department.QC)
        Me.AddColumnToDataGrid(wgdQCTimeCost, Utils.ConstantsUtils.Department.QC, qcTable)
        Dim cmrTable As DataTable = Me.CreateTimeGrid(Utils.ConstantsUtils.Department.CMR)
        Me.AddColumnToDataGrid(wgdCMRTimeCost, Utils.ConstantsUtils.Department.CMR, cmrTable)

    End Sub
    ''' <summary>
    ''' This function is used to create the datasource table for time grid,
    ''' the table will be saved in viewstate.
    ''' </summary>
    ''' <param name="DepId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTimeGrid(ByVal DepId As Integer) As DataTable
        Dim ds As DataSet
        Dim dtCol As DataTable
        Dim i As Integer
        Dim colCol As New Collection
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("StageId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("Stage", GetType(System.String)))

        ds = Me.PricingPositionBLL.GetPricingPositionByDepId(DepId)
        If Not ds Is Nothing Then
            dtCol = ds.Tables(0)

            For i = 0 To dtCol.Rows.Count - 1
                Dim dr As DataRow = dtCol.Rows(i)
                dt.Columns.Add(New DataColumn(dr("Id"), GetType(System.Int32)))
                colCol.Add(dr("Id"))
            Next
        End If

        If Not colCol Is Nothing Then

            Dim dsStage As DataSet = Me.PricingStageBLL.GetPricingStageByDepId(DepId)
            If Not dsStage Is Nothing Then
                Dim dtStage As DataTable = dsStage.Tables(0)
                For Each drStage As DataRow In dtStage.Rows
                    Dim drNew As DataRow = dt.NewRow
                    drNew(0) = drStage("ID")
                    drNew(1) = drStage("Stage")
                    For i = 1 To colCol.Count
                        Dim dsTimeCost As DataSet = Me.PricingTimeCostBLL.GetPricingTimeCostBySubProidCityIdDepIdStageId(ViewState("SubProId"), ViewState("CityId"), DepId, drStage("ID"), colCol(i))
                        If dsTimeCost Is Nothing Then
                            drNew(i + 1) = 0
                        Else
                            For Each drTimeCost As DataRow In dsTimeCost.Tables(0).Rows
                                drNew(i + 1) = drTimeCost("Amount")
                            Next
                        End If
                    Next

                    dt.Rows.Add(drNew)

                Next
            End If


        End If
        Select Case DepId
            Case Utils.ConstantsUtils.Department.FLW
                ViewState("FWTimeCostColumn") = colCol
                ViewState("FwTimeCostGrid") = dt
            Case Utils.ConstantsUtils.Department.EDP
                ViewState("EDPTimeCostColumn") = colCol
                ViewState("EDPTimeCostGrid") = dt
            Case Utils.ConstantsUtils.Department.CATI
                ViewState("CATITimeCostColumn") = colCol
                ViewState("CATITimeCostGrid") = dt
            Case Utils.ConstantsUtils.Department.QC
                ViewState("QCTimeCostColumn") = colCol
                ViewState("QCTimeCostGrid") = dt
            Case Utils.ConstantsUtils.Department.CMR
                ViewState("CMRTimeCostColumn") = colCol
                ViewState("CMRTimeCostGrid") = dt
        End Select
        Return dt

    End Function
#End Region
    ''' <summary>
    ''' This function is used to add column to datagrid.
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <param name="department"></param>
    ''' <param name="dataSource"></param>
    ''' <remarks></remarks>
    Private Sub AddColumnToDataGrid(ByVal grid As RadGrid, ByVal department As Integer, ByVal dataSource As DataTable)
        If grid.Columns.Count > 0 Then
            Return
        End If
        For i = 0 To dataSource.Columns.Count - 1
            Dim dc As DataColumn = dataSource.Columns(i)
            Dim column As New GridBoundColumn
            column.DataField = dc.ColumnName

            If i >= 2 Then
                Dim intKey As Integer = dc.ColumnName
                Dim base_PricingPositionInfo As Base_PricingPosition = Me.PricingPositionBLL.GetPricingPositionById(intKey)
                If Not base_PricingPositionInfo Is Nothing Then

                    column.HeaderText = base_PricingPositionInfo.ShortName & "/" & base_PricingPositionInfo.Rate
                End If
                'tony, use the custom aggreage function to calculate the sum of the column.
                column.Aggregate = GridAggregateFunction.Custom
                column.FooterText = " "
            Else
                column.HeaderText = dc.ColumnName
                column.ReadOnly = True
            End If
            column.UniqueName = dc.ColumnName
            grid.Columns.Add(column)
        Next
        Dim editColumn As New GridEditCommandColumn
        editColumn.EditText = "Edit"
        grid.Columns.Add(editColumn)
        'tony hide stage column
        grid.Columns(0).Visible = False
    End Sub    '
    ''' <summary>
    ''' This function is used to time cost and show the information on the tab.
    ''' </summary>
    ''' <param name="depId">Pass the department id.</param>
    ''' <remarks></remarks>
    Private Sub SumTimeCostByDep(ByVal depId As Integer)
        Dim ds As DataSet
        Dim dt As DataTable
        Dim DecTotalValue As Decimal

        ds = Me.PricingTimeCostBLL.GetPricingTimeCostBySubProidCityIdDepId(ViewState("SubProId"), ViewState("CityId"), depId)
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            For Each dr As DataRow In dt.Rows
                DecTotalValue = DecTotalValue + dr("TotalCost")
            Next
        End If

        Select Case depId
            Case Utils.ConstantsUtils.Department.FLW
                Me.RadTabStrip3.Tabs(1).Text = "FLW1 time Cost (" + String.Format("{0:N}", DecTotalValue) + ")"
            Case Utils.ConstantsUtils.Department.CATI
                Me.RadTabStrip3.Tabs(3).Text = "CATI time Cost (" + String.Format("{0:N}", DecTotalValue) + ")"
            Case Utils.ConstantsUtils.Department.EDP
                Me.RadTabStrip3.Tabs(5).Text = "EDP time Cost (" + String.Format("{0:N}", DecTotalValue) + ")"

            Case Utils.ConstantsUtils.Department.QC
                Me.RadTabStrip3.Tabs(7).Text = "QC time Cost (" + String.Format("{0:N}", DecTotalValue) + ")"
            Case Utils.ConstantsUtils.Department.CMR
                Me.RadTabStrip3.Tabs(9).Text = "CMR time Cost (" + String.Format("{0:N}", DecTotalValue) + ")"
        End Select
    End Sub
    
#Region "delete comand for grid"
    ''' <summary>
    ''' This method get the id from grid and delete the direct cost, then refresh the grid
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="department"></param>
    ''' <remarks></remarks>
    Private Sub DeleteDirectCost(ByVal e As GridCommandEventArgs, ByVal department As Utils.ConstantsUtils.Department)
        Dim strId As String

        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            'use column unique name to get id
            'strId = e.Item.Cells(GridColumn.Id).Text
            strId = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("Id").Text
            If Me.PricingDirectCostBLL.DeleteDirectCostInfo(strId) = True Then
                'Call Me.BindGrid(Utils.ConstantsUtils.Department.FLW)
                'Me.BindGrid(department)
            End If
        End If
    End Sub
    Protected Sub rdFWDirectCost_DeleteCommand(ByVal source As Object, ByVal e As GridCommandEventArgs) Handles rdFWDirectCost.DeleteCommand
        DeleteDirectCost(e, Utils.ConstantsUtils.Department.FLW)
        rdFWDirectCost.Rebind()
    End Sub
    Protected Sub rdEDPDirectCost_DeleteCommand(ByVal source As Object, ByVal e As GridCommandEventArgs) Handles rdEDPDirectCost.DeleteCommand
        DeleteDirectCost(e, Utils.ConstantsUtils.Department.EDP)
    End Sub
    Protected Sub rdQCDirectCost_DeleteCommand(ByVal source As Object, ByVal e As GridCommandEventArgs) Handles rdQCDirectCost.DeleteCommand
        DeleteDirectCost(e, Utils.ConstantsUtils.Department.QC)
    End Sub
    Protected Sub rdCMRDirectCost_DeleteCommand(ByVal source As Object, ByVal e As GridCommandEventArgs) Handles rdCMRDirectCost.DeleteCommand
        DeleteDirectCost(e, Utils.ConstantsUtils.Department.CMR)
    End Sub
    Protected Sub rdCATIDirectCost_DeleteCommand(ByVal source As Object, ByVal e As GridCommandEventArgs) Handles rdCATIDirectCost.DeleteCommand
        DeleteDirectCost(e, Utils.ConstantsUtils.Department.CATI)
    End Sub
#End Region
#Region "item databound event for grid"
    ''' <summary>
    ''' This is the base method for item databound.
    ''' Get CostCategoryInfo and set text.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ItemDataBoundForGrid(ByVal e As GridItemEventArgs)
        Dim strCostCategoryId As String
        Dim CostCategoryInfo As New Model.Base_CostCategory

        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            'tony modify,use column unique name to get the data instead of using column index
            'strCostCategoryId = e.Item.Cells(GridColumn.CostCategoryId).Text
            strCostCategoryId = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("Samplesize").Text
            CostCategoryInfo = Me.CostCategoryBLL.GetCostCategoryById(CInt(strCostCategoryId))
            If Not CostCategoryInfo Is Nothing Then
                'e.Item.Cells(GridColumn.CostCategoryId).Text = CostCategoryInfo.CostCategoryEn
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("Samplesize").Text = CostCategoryInfo.CostCategoryEn
            End If
        End If
    End Sub
    Protected Sub rdFWDirectCost_ItemDataBound(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles rdFWDirectCost.ItemDataBound
        ItemDataBoundForGrid(e)
    End Sub
    Protected Sub rdEDPDirectCost_ItemDataBound(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles rdEDPDirectCost.ItemDataBound
        ItemDataBoundForGrid(e)
    End Sub
    Protected Sub rdQCDirectCost_ItemDataBound(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles rdQCDirectCost.ItemDataBound
        ItemDataBoundForGrid(e)
    End Sub
    Protected Sub rdCMRDirectCost_ItemDataBound(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles rdCMRDirectCost.ItemDataBound
        ItemDataBoundForGrid(e)
    End Sub
    Protected Sub rdCATIDirectCost_ItemDataBound(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles rdCATIDirectCost.ItemDataBound
        ItemDataBoundForGrid(e)
    End Sub
#End Region
#Region "need datasource event for grid"
    Protected Sub rdFWDirectCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles rdFWDirectCost.NeedDataSource
        Dim ds As DataSet
        Dim dt As DataTable
        ds = Me.PricingDirectCostBLL.GetDirectCostInfoByCityIdDepIdSubProId(ViewState("CityId"), Utils.ConstantsUtils.Department.FLW, ViewState("SubProId"))
        If Not ds Is Nothing Then

            dt = ds.Tables(0)
            Me.rdFWDirectCost.DataSource = dt
            Dim decTotalCost As Decimal
            For Each dr As DataRow In dt.Rows
                decTotalCost = decTotalCost + dr("TotalCost")
            Next
            'tony modify
            'Me.wpFWDirectCost.Header.Text = "FLW Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
            Me.RadTabStrip3.Tabs(0).Text = "FLW Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        End If
    End Sub
    Protected Sub rdEDPDirectCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles rdEDPDirectCost.NeedDataSource
        Dim ds As DataSet
        Dim dt As DataTable
        ds = Me.PricingDirectCostBLL.GetDirectCostInfoByCityIdDepIdSubProId(ViewState("CityId"), Utils.ConstantsUtils.Department.EDP, ViewState("SubProId"))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            Me.rdEDPDirectCost.DataSource = dt
            Dim decTotalCost As Decimal
            For Each dr As DataRow In dt.Rows
                decTotalCost = decTotalCost + dr("TotalCost")
            Next
            'Me.wpEdpDirectCost.Header.Text = "EDP Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
            Me.RadTabStrip3.Tabs(4).Text = "EDP Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"

        End If
    End Sub
    Protected Sub rdQCDirectCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles rdQCDirectCost.NeedDataSource
        Dim ds As DataSet
        Dim dt As DataTable
        ds = Me.PricingDirectCostBLL.GetDirectCostInfoByCityIdDepIdSubProId(ViewState("CityId"), Utils.ConstantsUtils.Department.QC, ViewState("SubProId"))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            Me.rdQCDirectCost.DataSource = dt
            Dim decTotalCost As Decimal
            For Each dr As DataRow In dt.Rows
                decTotalCost = decTotalCost + dr("TotalCost")
            Next
            'Me.wpQCdirectCost.Header.Text = "QC Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
            Me.RadTabStrip3.Tabs(6).Text = "QC Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        End If
    End Sub
    Protected Sub rdCMRDirectCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles rdCMRDirectCost.NeedDataSource
        Dim ds As DataSet
        Dim dt As DataTable
        ds = Me.PricingDirectCostBLL.GetDirectCostInfoByCityIdDepIdSubProId(ViewState("CityId"), Utils.ConstantsUtils.Department.CMR, ViewState("SubProId"))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            Me.rdCMRDirectCost.DataSource = dt
            Dim decTotalCost As Decimal
            For Each dr As DataRow In dt.Rows
                decTotalCost = decTotalCost + dr("TotalCost")
            Next
            'Me.wpCMRDirectCost.Header.Text = "CMR Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
            Me.RadTabStrip3.Tabs(8).Text = "CMR Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        End If
    End Sub
    Protected Sub rdCATIDirectCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles rdCATIDirectCost.NeedDataSource
        Dim ds As DataSet
        Dim dt As DataTable
        ds = Me.PricingDirectCostBLL.GetDirectCostInfoByCityIdDepIdSubProId(ViewState("CityId"), Utils.ConstantsUtils.Department.CATI, ViewState("SubProId"))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            Me.rdCATIDirectCost.DataSource = dt
            Dim decTotalCost As Decimal
            For Each dr As DataRow In dt.Rows
                decTotalCost = decTotalCost + dr("TotalCost")
            Next
            'Me.wpCATIDirectCost.Header.Text = "CATI Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
            Me.RadTabStrip3.Tabs(2).Text = "CATI Direct Cost (" + String.Format("{0:N}", decTotalCost) + ")"
        End If
    End Sub
    Protected Sub wgdFWTimeCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles wgdFWTimeCost.NeedDataSource
        wgdFWTimeCost.DataSource = ViewState("FwTimeCostGrid")
        Me.SumTimeCostByDep(Utils.ConstantsUtils.Department.FLW)
    End Sub

    Protected Sub wgdCMRTimeCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles wgdCMRTimeCost.NeedDataSource
        Me.wgdCMRTimeCost.DataSource = ViewState("CMRTimeCostGrid")
        Me.SumTimeCostByDep(Utils.ConstantsUtils.Department.CMR)
    End Sub

    Protected Sub wgdEDPTimeCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles wgdEDPTimeCost.NeedDataSource
        Me.wgdEDPTimeCost.DataSource = ViewState("EDPTimeCostGrid")
        Me.SumTimeCostByDep(Utils.ConstantsUtils.Department.EDP)
    End Sub

    Protected Sub wgdCATITimeCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles wgdCATITimeCost.NeedDataSource
        Me.wgdCATITimeCost.DataSource = ViewState("CATITimeCostGrid")
        Me.SumTimeCostByDep(Utils.ConstantsUtils.Department.CATI)

    End Sub
    Protected Sub wgdQCTimeCost_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles wgdQCTimeCost.NeedDataSource
        Me.wgdQCTimeCost.DataSource = ViewState("QCTimeCostGrid")

        Me.SumTimeCostByDep(Utils.ConstantsUtils.Department.QC)
    End Sub



#End Region
#Region "UpdateCommand of grids"
    ''' <summary>
    ''' This function is fired by updated comand event.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <param name="grid"></param>
    ''' <param name="department"></param>
    ''' <param name="dataSource"></param>
    ''' <remarks></remarks>
    Private Sub UpdateValue(ByVal source As System.Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs, ByVal grid As RadGrid, ByVal department As Utils.ConstantsUtils.Department, ByVal dataSource As DataTable)
        Dim editedItem As GridEditableItem = CType(e.Item, GridEditableItem)
        Dim editMan As GridEditManager = editedItem.EditManager

        Dim column As GridColumn
        Dim needRefresh As Boolean = False
        For Each column In e.Item.OwnerTableView.Columns
            If TypeOf column Is IGridEditableColumn Then
                Dim editableCol As IGridEditableColumn = CType(column, IGridEditableColumn)
                If (editableCol.IsEditable) Then
                    Dim editor As IGridColumnEditor = editMan.GetColumnEditor(editableCol)

                    Dim editorType As String = CType(editor, Object).ToString()
                    Dim editorText As String = "unknown"
                    Dim editorValue As Object = Nothing

                    If (TypeOf editor Is GridTextColumnEditor) Then
                        editorText = CType(editor, GridTextColumnEditor).Text
                        editorValue = CType(editor, GridTextColumnEditor).Text
                    End If

                    If (TypeOf editor Is GridBoolColumnEditor) Then
                        editorText = CType(editor, GridBoolColumnEditor).Value.ToString()
                        editorValue = CType(editor, GridBoolColumnEditor).Value
                    End If

                    If (TypeOf editor Is GridDropDownColumnEditor) Then
                        editorText = CType(editor, GridDropDownColumnEditor).SelectedText & "; " & CType(editor, GridDropDownColumnEditor).SelectedValue
                        editorValue = CType(editor, GridDropDownColumnEditor).SelectedValue
                    End If

                    'tony,check with origin value, if equal, then need do updation
                    Dim currowRow As Integer = e.Item.RowIndex - 2
                    If currowRow < 0 Then
                        Continue For
                    End If
                    Dim originText As String = dataSource.Rows(currowRow)(column.UniqueName).ToString()
                    If String.Equals(editorText, originText) Then
                        Continue For
                    End If
                    'Try
                    '    Dim changedRows As DataRow() = Me.EmployeesData.Tables("Employees").Select("ID = " & editedItem.OwnerTableView.DataKeyValues(editedItem.ItemIndex)("id"))
                    '    changedRows(0)(column.UniqueName) = editorValue
                    '    Me.EmployeesData.Tables("Employees").AcceptChanges()
                    'Catch ex As Exception
                    '    RadGrid1.Controls.Add(New LiteralControl("<strong>Unable to set value of column '" & column.UniqueName & "'</strong> - " + ex.Message))
                    '    e.Canceled = True
                    'End Try

                    Dim pricingTimeCostInfo As New Model.PMS_PricingTimeCost
                    Dim PricingPoisitonInfo As New Model.Base_PricingPosition

                    pricingTimeCostInfo.DepId = department
                    pricingTimeCostInfo.CityId = ViewState("CityId")
                    pricingTimeCostInfo.SubProId = ViewState("SubProId")
                    pricingTimeCostInfo.PositionId = column.UniqueName 'e.Cell.Column.Header.Key

                    pricingTimeCostInfo.StageId = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).GetDataKeyValue("StageId").ToString() 'e.Cell.Row.Cells(0).Value
                    PricingPoisitonInfo = Me.PricingPositionBLL.GetPricingPositionById(pricingTimeCostInfo.PositionId)
                    pricingTimeCostInfo.Amount = editorText 'e.Cell.Value
                    pricingTimeCostInfo.Rate = PricingPoisitonInfo.Rate
                    pricingTimeCostInfo.TotalCost = CDec(editorText) * pricingTimeCostInfo.Rate 'CDec(e.Cell.Value) * pricingTimeCostInfo.Rate
                    'test begin
                    Try
                        If Me.PricingTimeCostBLL.IsExistRecord(pricingTimeCostInfo) = True Then
                            Me.PricingTimeCostBLL.ModifyPricingTimeCost(pricingTimeCostInfo)
                        Else
                            Me.PricingTimeCostBLL.AddPricingTimeCost(pricingTimeCostInfo)
                        End If

                        Me.SumTimeCostByDep(department)

                        needRefresh = True
                    Catch ex As Exception
                        e.Canceled = True
                    End Try
                    'test end.
                End If
            End If
        Next
        If needRefresh Then
            'get the data again
            Me.CreateTimeGrid(department)
            'refresh the datasource
            grid.Rebind()
        End If
    End Sub

    ''' <summary>
    ''' This the update command for wgdFWTimeCost
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub wgdFWTimeCost_UpdateCommand(ByVal source As System.Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles wgdFWTimeCost.UpdateCommand
        UpdateValue(source, e, wgdFWTimeCost, Utils.ConstantsUtils.Department.FLW, DirectCast(ViewState("FwTimeCostGrid"), DataTable))

    End Sub
    Private Sub wgdCATITimeCost_UpdateCommand(ByVal source As System.Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles wgdCATITimeCost.UpdateCommand
        UpdateValue(source, e, wgdCATITimeCost, Utils.ConstantsUtils.Department.CATI, DirectCast(ViewState("CATITimeCostGrid"), DataTable))
    End Sub
    Private Sub wgdEDPTimeCost_UpdateCommand(ByVal source As System.Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles wgdEDPTimeCost.UpdateCommand
        UpdateValue(source, e, wgdEDPTimeCost, Utils.ConstantsUtils.Department.EDP, DirectCast(ViewState("EDPTimeCostGrid"), DataTable))
    End Sub
    Private Sub wgdQCTimeCost_UpdateCommand(ByVal source As System.Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles wgdQCTimeCost.UpdateCommand
        UpdateValue(source, e, wgdQCTimeCost, Utils.ConstantsUtils.Department.QC, DirectCast(ViewState("QCTimeCostGrid"), DataTable))
    End Sub
    Private Sub wgdCMRTimeCost_UpdateCommand(ByVal source As System.Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles wgdCMRTimeCost.UpdateCommand
        UpdateValue(source, e, wgdCMRTimeCost, Utils.ConstantsUtils.Department.CMR, DirectCast(ViewState("CMRTimeCostGrid"), DataTable))
    End Sub
#End Region
#Region "add button events"
#Region "check method for button event"
    Private Function CheckFWDirectCost() As Boolean
        If Me.cbFWCostCategory.SelectedValue = 0 Then
            Return False
            Exit Function
        End If

        If Me.txtFWUnitPrice.Text = String.Empty Then
            Return False
            Exit Function
        End If

        If Me.txtFWQuantity.Text = String.Empty Then
            Return False
            Exit Function
        End If

        Return True

    End Function
    Private Function CheckCATIDirectCost() As Boolean
        If Me.cbCATICostCategory.SelectedValue = 0 Then
            Return False
            Exit Function
        End If

        If Me.txtCATIUnitPrice.Text = String.Empty Then
            Return False
            Exit Function
        End If

        If Me.txtCATIQuantity.Text = String.Empty Then
            Return False
            Exit Function
        End If

        Return True

    End Function
    Private Function CheckEDPDirectCost() As Boolean
        If Me.cbEDPCostCategory.SelectedValue = 0 Then
            Return False
            Exit Function
        End If

        If Me.txtEDPUnitPrice.Text = String.Empty Then
            Return False
            Exit Function
        End If

        If Me.txtEDPQuantity.Text = String.Empty Then
            Return False
            Exit Function
        End If

        Return True

    End Function
    Private Function CheckQCDirectCost() As Boolean
        If Me.cbQCCostCategory.SelectedValue = 0 Then
            Return False
            Exit Function
        End If

        If Me.txtQcUnitPrice.Text = String.Empty Then
            Return False
            Exit Function
        End If

        If Me.txtQcQuantity.Text = String.Empty Then
            Return False
            Exit Function
        End If

        Return True

    End Function
    Private Function CheckCMRDirectCost() As Boolean
        If Me.cbCMRCostCategory.SelectedValue = 0 Then
            Return False
            Exit Function
        End If

        If Me.txtCMRUnitPrice.Text = String.Empty Then
            Return False
            Exit Function
        End If

        If Me.txtCMRQuantity.Text = String.Empty Then
            Return False
            Exit Function
        End If

        Return True

    End Function
#End Region


    Protected Sub btnAddFWDirectCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddFWDirectCost.Click
        Dim PricingDirectCostInfo As New Model.PMS_PricingDirectCostInfo
        If CheckFWDirectCost() = True Then
            PricingDirectCostInfo.SubProId = ViewState("SubProId")
            PricingDirectCostInfo.DepId = Utils.ConstantsUtils.Department.FLW
            PricingDirectCostInfo.CityId = ViewState("CityId")
            PricingDirectCostInfo.CostCategoryId = Me.cbFWCostCategory.SelectedValue
            'tony modify,should use value instead of text proprety
            'PricingDirectCostInfo.UnitPrice = Me.txtFWUnitPrice.Text.Trim
            PricingDirectCostInfo.UnitPrice = Me.txtFWUnitPrice.Value
            PricingDirectCostInfo.Quantity = Me.txtFWQuantity.Text.Trim
            PricingDirectCostInfo.TotalCost = Me.txtFWUnitPrice.Value * Me.txtFWQuantity.Value
            PricingDirectCostInfo.Description = Me.txtFWDescription.Text.Trim
            If Me.PricingDirectCostBLL.AddDirectCostInfo(PricingDirectCostInfo) > 0 Then
                'Call BindGrid(Utils.ConstantsUtils.Department.FLW)
                Me.rdFWDirectCost.Rebind()
                Me.cbFWCostCategory.SelectedValue = 0
                Me.txtFWUnitPrice.Text = String.Empty
                Me.txtFWQuantity.Text = String.Empty
                Me.txtFWDescription.Text = String.Empty
            End If
        End If
    End Sub
    Protected Sub btnAddCATIDirectCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCATIDirectCost.Click
        Dim PricingDirectCostInfo As New Model.PMS_PricingDirectCostInfo
        If CheckCATIDirectCost() = True Then
            PricingDirectCostInfo.SubProId = ViewState("SubProId")
            PricingDirectCostInfo.DepId = Utils.ConstantsUtils.Department.CATI
            PricingDirectCostInfo.CityId = ViewState("CityId")
            PricingDirectCostInfo.CostCategoryId = Me.cbCATICostCategory.SelectedValue
            PricingDirectCostInfo.UnitPrice = Me.txtCATIUnitPrice.Text.Trim
            PricingDirectCostInfo.Quantity = Me.txtCATIQuantity.Text.Trim
            PricingDirectCostInfo.TotalCost = Me.txtCATIUnitPrice.Value * Me.txtCATIQuantity.Value
            PricingDirectCostInfo.Description = Me.txtCATIDescription.Text.Trim
            If Me.PricingDirectCostBLL.AddDirectCostInfo(PricingDirectCostInfo) > 0 Then
                'Call BindGrid(Utils.ConstantsUtils.Department.CATI)
                Me.rdCATIDirectCost.Rebind()
                Me.cbCATICostCategory.SelectedValue = 0
                Me.txtCATIUnitPrice.Text = String.Empty
                Me.txtCATIQuantity.Text = String.Empty
                Me.txtCATIDescription.Text = String.Empty
            End If
        End If
    End Sub
    Protected Sub btnAddEDPDirectCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEDPDirectCost.Click
        Dim PricingDirectCostInfo As New Model.PMS_PricingDirectCostInfo
        If CheckEDPDirectCost() = True Then
            PricingDirectCostInfo.SubProId = ViewState("SubProId")
            PricingDirectCostInfo.DepId = Utils.ConstantsUtils.Department.EDP
            PricingDirectCostInfo.CityId = ViewState("CityId")
            PricingDirectCostInfo.CostCategoryId = Me.cbEDPCostCategory.SelectedValue
            PricingDirectCostInfo.UnitPrice = Me.txtEDPUnitPrice.Text.Trim
            PricingDirectCostInfo.Quantity = Me.txtEDPQuantity.Text.Trim
            PricingDirectCostInfo.TotalCost = Me.txtEDPUnitPrice.Value * Me.txtEDPQuantity.Value
            PricingDirectCostInfo.Description = Me.txtEDPDescription.Text.Trim
            If Me.PricingDirectCostBLL.AddDirectCostInfo(PricingDirectCostInfo) > 0 Then
                'Call BindGrid(Utils.ConstantsUtils.Department.EDP)
                Me.rdEDPDirectCost.Rebind()
                Me.cbEDPCostCategory.SelectedValue = 0
                Me.txtEDPUnitPrice.Text = String.Empty
                Me.txtEDPQuantity.Text = String.Empty
                Me.txtEDPDescription.Text = String.Empty
            End If
        End If
    End Sub
    Protected Sub btnAddQCDirectCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddQCDirectCost.Click
        Dim PricingDirectCostInfo As New Model.PMS_PricingDirectCostInfo
        If CheckQCDirectCost() = True Then
            PricingDirectCostInfo.SubProId = ViewState("SubProId")
            PricingDirectCostInfo.DepId = Utils.ConstantsUtils.Department.QC
            PricingDirectCostInfo.CityId = ViewState("CityId")
            PricingDirectCostInfo.CostCategoryId = Me.cbQCCostCategory.SelectedValue
            PricingDirectCostInfo.UnitPrice = Me.txtQcUnitPrice.Text.Trim
            PricingDirectCostInfo.Quantity = Me.txtQcQuantity.Text.Trim
            PricingDirectCostInfo.TotalCost = Me.txtQcUnitPrice.Value * Me.txtQcQuantity.Value
            PricingDirectCostInfo.Description = Me.txtQCDescription.Text.Trim
            If Me.PricingDirectCostBLL.AddDirectCostInfo(PricingDirectCostInfo) > 0 Then
                'Call BindGrid(Utils.ConstantsUtils.Department.QC)
                Me.rdQCDirectCost.Rebind()
                Me.cbQCCostCategory.SelectedValue = 0
                Me.txtQcUnitPrice.Text = String.Empty
                Me.txtQcQuantity.Text = String.Empty
                Me.txtQCDescription.Text = String.Empty
            End If
        End If
    End Sub
    Protected Sub btnAddCMRDirectCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCMRDirectCost.Click
        Dim PricingDirectCostInfo As New Model.PMS_PricingDirectCostInfo
        If CheckCMRDirectCost() = True Then
            PricingDirectCostInfo.SubProId = ViewState("SubProId")
            PricingDirectCostInfo.DepId = Utils.ConstantsUtils.Department.CMR
            PricingDirectCostInfo.CityId = ViewState("CityId")
            PricingDirectCostInfo.CostCategoryId = Me.cbCMRCostCategory.SelectedValue
            PricingDirectCostInfo.UnitPrice = Me.txtCMRUnitPrice.Text.Trim
            PricingDirectCostInfo.Quantity = Me.txtCMRQuantity.Text.Trim
            PricingDirectCostInfo.TotalCost = Me.txtCMRUnitPrice.Value * Me.txtCMRQuantity.Value
            PricingDirectCostInfo.Description = Me.txtCMRDescription.Text.Trim
            If Me.PricingDirectCostBLL.AddDirectCostInfo(PricingDirectCostInfo) > 0 Then
                'Call BindGrid(Utils.ConstantsUtils.Department.CMR)
                Me.rdCMRDirectCost.Rebind()
                Me.cbCMRCostCategory.SelectedValue = 0
                Me.txtCMRUnitPrice.Text = String.Empty
                Me.txtCMRQuantity.Text = String.Empty
                Me.txtCMRDescription.Text = String.Empty
            End If
        End If
    End Sub

#End Region
#Region "Aggregate"

    Private Sub CustomAggreate(ByVal sender As Object, ByVal e As GridCustomAggregateEventArgs)
        Dim columnName = e.Column.UniqueName
        Dim dataSource As DataTable = DirectCast(DirectCast(sender, RadGrid).DataSource, DataTable)
        Dim value As Double = 0
        For Each row As DataRow In dataSource.Rows
            Dim cellValue As String = row(columnName).ToString
            If String.IsNullOrEmpty(cellValue) Then
                Continue For
            End If
            value += CDbl(cellValue)
        Next
        e.Result = "Total:" + value.ToString
    End Sub
    Protected Sub wgdFWTimeCost_CustomAggregate(ByVal sender As Object, ByVal e As GridCustomAggregateEventArgs) Handles wgdFWTimeCost.CustomAggregate

        'Dim columnName = e.Column.UniqueName
        'Dim dataSource As DataTable = DirectCast(DirectCast(sender, RadGrid).DataSource, DataTable)
        'Dim value As Double = 0
        'For Each row As DataRow In dataSource.Rows
        '    Dim cellValue As String = row(columnName).ToString
        '    If String.IsNullOrEmpty(cellValue) Then
        '        Continue For
        '    End If
        '    value += CDbl(cellValue)
        'Next
        'e.Result = "total:" + value.ToString
        CustomAggreate(sender, e)
    End Sub
    Protected Sub wgdCATITimeCost_CustomAggregate(ByVal sender As Object, ByVal e As GridCustomAggregateEventArgs) Handles wgdCATITimeCost.CustomAggregate
        CustomAggreate(sender, e)
    End Sub
    Protected Sub wgdEDPTimeCost_CustomAggregate(ByVal sender As Object, ByVal e As GridCustomAggregateEventArgs) Handles wgdEDPTimeCost.CustomAggregate
        CustomAggreate(sender, e)
    End Sub
    Protected Sub wgdQCTimeCost_CustomAggregate(ByVal sender As Object, ByVal e As GridCustomAggregateEventArgs) Handles wgdQCTimeCost.CustomAggregate
        CustomAggreate(sender, e)
    End Sub
    Protected Sub wgdCMRTimeCost_CustomAggregate(ByVal sender As Object, ByVal e As GridCustomAggregateEventArgs) Handles wgdCMRTimeCost.CustomAggregate
        CustomAggreate(sender, e)
    End Sub

#End Region
End Class
