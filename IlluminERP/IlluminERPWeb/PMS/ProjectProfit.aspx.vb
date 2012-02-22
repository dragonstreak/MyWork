Imports DataAccess
Imports DataAccess.Model
Imports Aspose.Cells
Imports System.IO

Partial Class PMS_ProjectProfit
    Inherits System.Web.UI.Page
    Dim operationCostBLL As New PMS_OperationCostBLL
    Dim projectRevenueBLL As New PMS_ProjectRevenueBLL
    Private jobNumber As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''the url should contain jobnumber
        jobNumber = Page.Request.QueryString("JobNumber")
        If Not IsPostBack Then
            GetData()
        End If
    End Sub
    Private Sub GetData()
        Dim costProfitList As List(Of PMS_OperationCost) = operationCostBLL.GetProjectProfit(jobNumber, "Actual")
        Dim projectRevenueList As List(Of PMS_ProjectRevenue) = projectRevenueBLL.GetProjectRevenueList(jobNumber, "")
        If projectRevenueList Is Nothing Or projectRevenueList.Count = 0 Then
            InitProjectRevenueList(projectRevenueList)
        End If
        'ViewState("CostProfit") = CostProfit
        ViewState("ProjectRevenueList") = projectRevenueList
        BindInfo(costProfitList, projectRevenueList)
    End Sub
    Private Sub BindInfo(ByVal costProfitList As List(Of PMS_OperationCost), ByVal projectRevenueList As List(Of PMS_ProjectRevenue))
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
        'Add on 2012/2/21
        'set project revenue part,till now, including:Illuminera analysts/consultants,Freelancer,Travel/Accommodation,Other
        Dim minusStaffing As Decimal = 0
        Dim minusOthers As Decimal = 0
        Dim minusManagement As Decimal = 0
        Dim consultants As Decimal = 0
        Dim freelancer As Decimal = 0
        Dim travel As Decimal = 0
        Dim other As Decimal = 0
        For Each revenue As PMS_ProjectRevenue In projectRevenueList
            If revenue.CostName = "Illuminera analysts/consultants" Then
                consultants = revenue.CostValue
            ElseIf revenue.CostName = "Freelancer" Then
                freelancer = revenue.CostValue
            ElseIf revenue.CostName = "Travel/Accommodation" Then
                travel = revenue.CostValue
            ElseIf revenue.CostName = "Other" Then
                other = revenue.CostValue
            End If
        Next
        txtConsultants.Text = consultants.ToString
        txtFreelancer.Text = freelancer.ToString
        txtTravel.Text = travel.ToString
        txtOther.Text = other.ToString
        minusStaffing = consultants + freelancer
        minusOthers = travel + other
        SetText("MinusStaffing", minusStaffing.ToString)
        SetText("MinusOthers", minusOthers.ToString)
        'need set text next time
        Dim projectProfit As Decimal = projectRevenue - (projectTexation + DirectCost + minusStaffing + minusOthers + minusManagement)
        SetText("ProjectProfit", projectProfit.ToString())
        Dim rate As Decimal = 0
        If projectRevenue <> 0 Then
            rate = projectProfit / projectRevenue
        End If
        SetText("ProjectProfitRate", rate.ToString("#.##"))
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
        'Add on 2012/2/22
        workSheet.Cells(startRow + (startColumnIndex + 11).ToString).PutValue(txtConsultants.Text)
        workSheet.Cells(startRow + (startColumnIndex + 12).ToString).PutValue(txtFreelancer.Text)
        workSheet.Cells(startRow + (startColumnIndex + 13).ToString).PutValue(labelMinusOthers.Text)
        'Add on 2012/2/22
        workSheet.Cells(startRow + (startColumnIndex + 14).ToString).PutValue(txtTravel.Text)
        workSheet.Cells(startRow + (startColumnIndex + 15).ToString).PutValue(txtOther.Text)
        workSheet.Cells(startRow + (startColumnIndex + 17).ToString).PutValue(labelProjectProfit.Text)
        workSheet.Cells(startRow + (startColumnIndex + 18).ToString).PutValue(labelProjectProfitRate.Text)
        workbook.Save(filePath, FileFormatType.Pdf)
        Me.Response.ContentType = "application/x-unknown"

        Me.Response.AddHeader("Content-Disposition", "attachment;filename=CostAnalysis.pdf")
        Response.TransmitFile(filePath)
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim projectRevenueList As List(Of PMS_ProjectRevenue) = CType(ViewState("ProjectRevenueList"), List(Of PMS_ProjectRevenue))
        If projectRevenueList Is Nothing Then
            Return
        End If
        Try
            For Each revenue As PMS_ProjectRevenue In projectRevenueList
                Dim value As Decimal = 0
                If revenue.CostName = "Illuminera analysts/consultants" Then
                    If Not String.IsNullOrEmpty(txtConsultants.Text) Then
                        value = CType(txtConsultants.Text, Decimal)
                    End If
                ElseIf revenue.CostName = "Freelancer" Then
                    If Not String.IsNullOrEmpty(txtFreelancer.Text) Then
                        value = CType(Me.txtFreelancer.Text, Decimal)
                    End If
                ElseIf revenue.CostName = "Travel/Accommodation" Then
                    If Not String.IsNullOrEmpty(txtTravel.Text) Then
                        value = CType(Me.txtTravel.Text, Decimal)
                    End If
                ElseIf revenue.CostName = "Other" Then
                    If Not String.IsNullOrEmpty(txtOther.Text) Then
                        value = CType(Me.txtOther.Text, Decimal)
                    End If

                End If
                If revenue.CostValue <> value Then
                    revenue.CostValue = value
                    projectRevenueBLL.SaveEntity(revenue)
                End If
                
            Next
            GetData()
        Catch ex As Exception
            Throw ex
        End Try
       
    End Sub

    Private Sub InitProjectRevenueList(ByVal projectRevenueList As List(Of PMS_ProjectRevenue))
        'Illuminera analysts/consultants
        Dim consultants As New PMS_ProjectRevenue
        consultants.Id = -1
        consultants.CostName = "Illuminera analysts/consultants"
        consultants.JobNumber = jobNumber
        consultants.CostValue = 0
        projectRevenueList.Add(consultants)
        'Freelancer
        Dim Freelancer As New PMS_ProjectRevenue
        Freelancer.Id = -1
        Freelancer.CostName = "Freelancer"
        Freelancer.JobNumber = jobNumber
        Freelancer.CostValue = 0
        projectRevenueList.Add(Freelancer)
        'Travel/Accommodation
        Dim Travel As New PMS_ProjectRevenue
        Travel.Id = -1
        Travel.CostName = "Travel/Accommodation"
        Travel.JobNumber = jobNumber
        Travel.CostValue = 0
        projectRevenueList.Add(Travel)
        'Other
        Dim Other As New PMS_ProjectRevenue
        Other.Id = -1
        Other.CostName = "Other"
        Other.JobNumber = jobNumber
        Other.CostValue = 0
        projectRevenueList.Add(Other)
    End Sub

End Class
