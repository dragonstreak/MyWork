Imports DataAccess
Imports DataAccess.Model
Imports Aspose.Cells
Imports System.IO

Partial Class PMS_ProjectProfit
    Inherits System.Web.UI.Page
    Dim operationCostBLL As New PMS_OperationCostBLL
    Private jobNumber As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''the url should contain jobnumber
        jobNumber = Page.Request.QueryString("JobNumber")
        If Not IsPostBack Then
            Dim costProfitList As List(Of PMS_OperationCost) = operationCostBLL.GetProjectProfit(jobNumber, "Actual")
            'ViewState("CostProfit") = CostProfit
            BindInfo(costProfitList)
        End If
    End Sub
    Private Sub BindInfo(ByVal costProfitList As List(Of PMS_OperationCost))
        If costProfitList Is Nothing Then
            Return
        End If
        If costProfitList.Count = 0 Then
            Return
        End If
        'need calc the directCost
        Dim DirectCost As Decimal = 0
        For Each costProfit As PMS_OperationCost In costProfitList
            SetText(costProfit.CostName.Replace("-", ""), costProfit.TotalCost.ToString)
            DirectCost += costProfit.TotalCost
        Next
        'DirectCost = costProfitList(0).EstimateCost
        SetText("DirectCosts", DirectCost.ToString())

        'estimate cost contain the value of project revenue
        Dim projectRevenue As Decimal = costProfitList(0).EstimateCost
        SetText("ProjectRevenue", projectRevenue.ToString)
        Dim projectTexation As Decimal = projectRevenue * 0.06
        SetText("MinusTax", projectTexation.ToString)
        Dim minusStaffing As Decimal = 0
        Dim minusOthers As Decimal = 0
        Dim minusManagement As Decimal = 0
        'need set text next time
        Dim projectProfit As Decimal = projectRevenue - (projectTexation + DirectCost + minusStaffing + minusOthers + minusManagement)
        SetText("ProjectProfit", projectProfit.ToString())

    End Sub
    Private Sub SetText(ByVal propertyName As String, ByVal propertyValue As String)
        Dim controlId As String = "label" + propertyName
        Dim control As Control = Me.FindControl(controlId)
        Dim labelControl As System.Web.UI.WebControls.Label = CType(control, System.Web.UI.WebControls.Label)
        If labelControl Is Nothing Then
            Return
        End If
        labelControl.Text = propertyValue
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim templateFile As String = MapPath("~\\" + ConfigurationManager.AppSettings.Item("CostingProfitFile").ToString())
        Dim fileName As String = Guid.NewGuid().ToString + ".pdf"
        Dim filePath As String = MapPath("~\\" + ConfigurationManager.AppSettings.Item("CostingUploadFolder").ToString() + "\\" + fileName)
        Dim workbook As Workbook = New Workbook()
        workbook.Open(templateFile)
        Dim RevenueCellInAnalysisTemplate As String = ConfigurationManager.AppSettings.Item("RevenueCellInAnalysisTemplate").ToString()
        Dim startRow As String = RevenueCellInAnalysisTemplate.Substring(0, 1)
        Dim startColumnIndex As Integer = CType(RevenueCellInAnalysisTemplate.Substring(1), Integer)
        Dim workSheet As Worksheet = workbook.Worksheets(0)
        workSheet.Cells(startRow + startColumnIndex.ToString).PutValue(labelProjectRevenue.Text)
        workSheet.Cells(startRow + (startColumnIndex + 1).ToString).PutValue(labelMinusTax.Text)
        workSheet.Cells(startRow + (startColumnIndex + 2).ToString).PutValue(labelDirectCosts.Text)
        workSheet.Cells(startRow + (startColumnIndex + 3).ToString).PutValue(labelSHFW.Text)
        workSheet.Cells(startRow + (startColumnIndex + 4).ToString).PutValue(labelSHQC.Text)
        workSheet.Cells(startRow + (startColumnIndex + 5).ToString).PutValue(labelSHDP.Text)
        workSheet.Cells(startRow + (startColumnIndex + 6).ToString).PutValue(labelSHManagement.Text)
        workSheet.Cells(startRow + (startColumnIndex + 7).ToString).PutValue(labelSubcontractFW.Text)
        workSheet.Cells(startRow + (startColumnIndex + 8).ToString).PutValue(labelSubcontractQC.Text)
        workSheet.Cells(startRow + (startColumnIndex + 9).ToString).PutValue(labelSubcontractDP.Text)
        workSheet.Cells(startRow + (startColumnIndex + 10).ToString).PutValue(labelMinusStaffing.Text)
        workSheet.Cells(startRow + (startColumnIndex + 13).ToString).PutValue(labelMinusOthers.Text)
        workSheet.Cells(startRow + (startColumnIndex + 17).ToString).PutValue(labelProjectProfit.Text)
        workbook.Save(filePath, FileFormatType.Pdf)
        Me.Response.ContentType = "application/x-unknown"

        Me.Response.AddHeader("Content-Disposition", "attachment;filename=CostAnalysis.pdf")
        Response.TransmitFile(filePath)
    End Sub
End Class
