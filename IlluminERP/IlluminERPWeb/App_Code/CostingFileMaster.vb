Imports Microsoft.VisualBasic
Imports Aspose.Cells
Imports DataAccess.Model
Imports DataAccess.BLL
Imports DataAccess

Public Class CostingFileMaster
    Private costSheetIndex As Integer = 4
    Dim operationCostBLL As New PMS_OperationCostBLL
    Dim costNameArr As New List(Of String)
    Private estimateTemplateIndex As Integer = 2
    Private actualTemplateIndex As Integer = 3
    Private erpCostAnalysisTemplateIndex As Integer = 4

    Public Sub New()
        ''Init the cost name list
        costNameArr.Add("SH-FW")
        costNameArr.Add("SH-QC")
        costNameArr.Add("SH-DP")
        costNameArr.Add("SH-Management")
        costNameArr.Add("Subcontract-FW")
        costNameArr.Add("Subcontract-QC")
        costNameArr.Add("Subcontract-DP")
    End Sub

    ''' <summary>
    ''' This method is used to process costing file.
    ''' calculate the costing analysis.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="response"></param>
    ''' <remarks></remarks>
    Public Sub ProcessCostingFile(ByVal fileName As String, ByVal response As HttpResponse, ByVal templateFileName As String)
        Try
            Dim workbook As Workbook = New Workbook()
            workbook.Open(fileName)
            'need check with clinent whether need calculate the total cell in costing sheet
            'ProcessCostingAnalysisSheet(workbook)


            Dim workbookTemplate As Workbook = New Workbook()
            'need use template and add the template file path to web.config.
            'Dim baseFolder As String = SiteMapPath("~\\" + ConfigurationManager.AppSettings.Item("CostingUploadFolder").ToString())
            workbookTemplate.Open(templateFileName)
            'check copied sheet exist in real excel file or not.
            Dim templateSheetName As String = workbookTemplate.Worksheets(costSheetIndex).Name
            Dim isExisted As Boolean = False
            For Each sheet As Worksheet In workbookTemplate.Worksheets
                If sheet.Name = templateSheetName Then
                    isExisted = True
                    Exit For
                End If
            Next
            'if the sheet does not exist, need add new sheet
            'if the sheet exists, then move the sheet to the fourth sheet
            If Not isExisted Then
                workbook.Worksheets.Add()
                workbook.Worksheets(costSheetIndex).Copy(workbookTemplate.Worksheets(costSheetIndex))
                workbook.Worksheets(costSheetIndex).Name = templateSheetName
            Else
                workbook.Worksheets(templateSheetName).Move(costSheetIndex)
            End If
            ProcessFormularForCostingAnalysisSheet(workbook)
            workbook.Save(fileName)
        Catch ex As Exception
            Throw ex
        End Try


    End Sub
    Private Function GetCellValue(Of T)(ByVal cell As Cell, ByVal defaultValue As T) As T
        If cell.Value Is Nothing Then
            Return defaultValue
        End If
        Try
            Return CType(cell.Value, T)
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function
    ''' <summary>
    ''' Calc costing analysis.
    ''' costing ayalysis will be the 4
    ''' </summary>
    ''' <param name="workbook"></param>
    ''' <remarks></remarks>
    Private Sub ProcessCostingAnalysisSheet(ByVal workbook As Workbook)
        'index of quotation sheet index is 2
        'index of costing analysis sheet is 4
        'index of costing sheet is 5
        Dim quotationSheetIndex As Integer = 2
        Dim costingAnalysisSheetIndex As Integer = 4
        Dim costingSheetIndex As Integer = 5
        'get the costing sheet and costing analysis sheet
        Dim quotationSheet As Worksheet = workbook.Worksheets(quotationSheetIndex)
        Dim costingSheet As Worksheet = workbook.Worksheets(costingSheetIndex)
        Dim costingAnalysisSheet As Worksheet = workbook.Worksheets(costingAnalysisSheetIndex)
        'get data from costing sheet
        'Get sample size
        Dim fwSize As Integer = GetCellValue(Of Integer)(costingSheet.Cells(5, 6), 0) 'costingSheet.Cells(6, 5).IntValue
        Dim fwSubcontractSize As Integer = GetCellValue(Of Integer)(costingSheet.Cells(5, 15), 0) 'costingSheet.Cells(15, 5).IntValue - fwSize

        'Get Total cost
        Dim fwTotalCost As Double = GetCellValue(Of Double)(costingSheet.Cells(67, 0), 0) 'costingSheet.Cells(67, 0).DoubleValue
        Dim qcTotalCost As Double = GetCellValue(Of Double)(costingSheet.Cells(67, 3), 0) 'costingSheet.Cells(67, 3).DoubleValue
        Dim dpTotalCost As Double = GetCellValue(Of Double)(costingSheet.Cells(67, 7), 0) 'costingSheet.Cells(67, 7).DoubleValue

        Dim subcontractFWCost As Double = GetCellValue(Of Double)(costingSheet.Cells(62, 13), 0) 'costingSheet.Cells(62, 13).DoubleValue
        Dim subcontractQCCost As Double = GetCellValue(Of Double)(costingSheet.Cells(45, 13), 0) 'costingSheet.Cells(45, 13).DoubleValue

        'set data to quotationcost sheet
        quotationSheet.Cells(4, 1).PutValue(fwSize)
        quotationSheet.Cells(8, 1).PutValue(fwSubcontractSize)

        quotationSheet.Cells(4, 2).PutValue(fwTotalCost)
        quotationSheet.Cells(5, 2).PutValue(qcTotalCost)
        quotationSheet.Cells(6, 2).PutValue(dpTotalCost)
        quotationSheet.Cells(8, 2).PutValue(subcontractFWCost)
        quotationSheet.Cells(9, 2).PutValue(subcontractQCCost)

        'set data to costing analysis sheet
        'set estimated cost
        Dim alayisisCells As Cells = costingAnalysisSheet.Cells
        alayisisCells(3, 1).PutValue(fwTotalCost)
        alayisisCells(4, 1).PutValue(qcTotalCost)
        alayisisCells(5, 1).PutValue(dpTotalCost)
        alayisisCells(6, 1).PutValue(GetCellValue(Of Double)(quotationSheet.Cells(7, 2), 0)) 'quotationSheet.Cells(7, 2).DoubleValue)
        alayisisCells(7, 1).PutValue(subcontractFWCost)
        alayisisCells(8, 1).PutValue(subcontractQCCost)
        alayisisCells(9, 1).PutValue(GetCellValue(Of Double)(quotationSheet.Cells(10, 2), 0)) 'quotationSheet.Cells(10, 2).DoubleValue)
        'set actual cost, as use the same data with estimated cost, need check with client.

        'set Project Income Statement table
        alayisisCells(14, 1).PutValue(GetCellValue(Of Double)(alayisisCells(13, 1), 0) * 0.06)

        alayisisCells(16, 1).PutValue(GetCellValue(Of Double)(alayisisCells(3, 2), 0)) 'alayisisCells(3, 2).DoubleValue)
        alayisisCells(19, 1).PutValue(GetCellValue(Of Double)(alayisisCells(6, 2), 0)) 'alayisisCells(6, 2).DoubleValue)
        alayisisCells(20, 1).PutValue(GetCellValue(Of Double)(alayisisCells(7, 2), 0)) 'alayisisCells(7, 2).DoubleValue)
        alayisisCells(15, 1).PutValue(GetCellValue(Of Double)(alayisisCells(16, 1), 0) + GetCellValue(Of Double)(alayisisCells(17, 1), 0) + GetCellValue(Of Double)(alayisisCells(18, 1), 0) + GetCellValue(Of Double)(alayisisCells(19, 1), 0) + GetCellValue(Of Double)(alayisisCells(20, 1), 0) + GetCellValue(Of Double)(alayisisCells(21, 1), 0) + GetCellValue(Of Double)(alayisisCells(22, 1), 0))

        alayisisCells(23, 1).PutValue(GetCellValue(Of Double)(alayisisCells(24, 1), 0) + GetCellValue(Of Double)(alayisisCells(25, 1), 0))
        alayisisCells(26, 1).PutValue(GetCellValue(Of Double)(alayisisCells(27, 1), 0) + GetCellValue(Of Double)(alayisisCells(28, 1), 0))

        alayisisCells(30, 1).PutValue(GetCellValue(Of Double)(alayisisCells(13, 1), 0) - (GetCellValue(Of Double)(alayisisCells(14, 1), 0) + GetCellValue(Of Double)(alayisisCells(15, 1), 0) + GetCellValue(Of Double)(alayisisCells(23, 1), 0) + GetCellValue(Of Double)(alayisisCells(26, 1), 0) + GetCellValue(Of Double)(alayisisCells(29, 1), 0)))


        alayisisCells(3, 1).Style.Font.Color = Drawing.Color.Red
        alayisisCells(4, 1).Style.Font.Color = Drawing.Color.Red
        alayisisCells(5, 1).Style.Font.Color = Drawing.Color.Red
        alayisisCells(6, 1).Style.Font.Color = Drawing.Color.Red
        alayisisCells(7, 1).Style.Font.Color = Drawing.Color.Red
        alayisisCells(8, 1).Style.Font.Color = Drawing.Color.Red
        alayisisCells(9, 1).Style.Font.Color = Drawing.Color.Red

    End Sub
    ''' <summary>
    ''' This method is used to set formular for costing analysis sheet
    ''' sheet index should be const
    ''' </summary>
    ''' <param name="workbook"></param>
    ''' <remarks></remarks>
    Private Sub ProcessFormularForCostingAnalysisSheet(ByVal workbook As Workbook)
        'index of quotation sheet index is 2
        'index of costing analysis sheet is 4
        'index of costing sheet is 5
        Dim quotationSheetIndex As Integer = 2
        Dim costingAnalysisSheetIndex As Integer = 4
        Dim costingSheetIndex As Integer = 5
        'get the costing sheet and costing analysis sheet
        Dim quotationSheet As Worksheet = workbook.Worksheets(quotationSheetIndex)
        Dim costingSheet As Worksheet = workbook.Worksheets(costingSheetIndex)
        Dim costingAnalysisSheet As Worksheet = workbook.Worksheets(costingAnalysisSheetIndex)

        'Estimated Total Cost   
        Dim costingFormName As String = "ERP-FW CostingForm（quotation阶段）"
        costingAnalysisSheet.Cells("B4").Formula = "='" + costingFormName + "'!C5"
        costingAnalysisSheet.Cells("B5").Formula = "='" + costingFormName + "'!C6"
        costingAnalysisSheet.Cells("B6").Formula = "='" + costingFormName + "'!C7"
        costingAnalysisSheet.Cells("B7").Formula = "='" + costingFormName + "'!C8"
        costingAnalysisSheet.Cells("B8").Formula = "='" + costingFormName + "'!C9"
        costingAnalysisSheet.Cells("B9").Formula = "='" + costingFormName + "'!C10"
        costingAnalysisSheet.Cells("B10").Formula = "='" + costingFormName + "'!C11"
        costingAnalysisSheet.Cells("B11").Formula = "=SUM(B4:B10)"

        'Actural Total Cost
        Dim costingCompletionName As String = "ERP-FW CostingFormcompletion阶段）"
        costingAnalysisSheet.Cells("C4").Formula = "='" + costingCompletionName + "'!C5"
        costingAnalysisSheet.Cells("C5").Formula = "='" + costingCompletionName + "'!C6"
        costingAnalysisSheet.Cells("C6").Formula = "='" + costingCompletionName + "'!C7"
        costingAnalysisSheet.Cells("C7").Formula = "='" + costingCompletionName + "'!C8"
        costingAnalysisSheet.Cells("C8").Formula = "='" + costingCompletionName + "'!C9"
        costingAnalysisSheet.Cells("C9").Formula = "='" + costingCompletionName + "'!C10"
        costingAnalysisSheet.Cells("C10").Formula = "='" + costingCompletionName + "'!C11"
        costingAnalysisSheet.Cells("B11").Formula = "=SUM(C4:C10)"

        'Dif
        costingAnalysisSheet.Cells("D4").Formula = "=C4/B4-1"
        costingAnalysisSheet.Cells("D5").Formula = "=C5/B5-1"
        costingAnalysisSheet.Cells("D6").Formula = "=C6/B6-1"
        costingAnalysisSheet.Cells("D7").Formula = "=C7/B7-1"
        costingAnalysisSheet.Cells("D8").Formula = "=C8/B8-1"
        costingAnalysisSheet.Cells("D9").Formula = "=C9/B9-1"
        costingAnalysisSheet.Cells("D10").Formula = "=C10/B10-1"
        costingAnalysisSheet.Cells("D11").Formula = "=C11/B11-1"

        'Project Income Statement
        costingAnalysisSheet.Cells("B15").Formula = "=B14*6%"

        costingAnalysisSheet.Cells("B16").Formula = "=SUM(B17:B23)"
        costingAnalysisSheet.Cells("B17").Formula = "=C4"
        costingAnalysisSheet.Cells("B18").Formula = "=C5"
        costingAnalysisSheet.Cells("B19").Formula = "=C6"
        costingAnalysisSheet.Cells("B20").Formula = "=C7"
        costingAnalysisSheet.Cells("B21").Formula = "=C8"
        costingAnalysisSheet.Cells("B22").Formula = "=C9"
        costingAnalysisSheet.Cells("B23").Formula = "=C10"

        costingAnalysisSheet.Cells("B24").Formula = "=SUM(B25:B26)"

        costingAnalysisSheet.Cells("B27").Formula = "=SUM(B28:B29)"

        costingAnalysisSheet.Cells("B31").Formula = "=B14-SUM(B15,B16,B24,B27,B30)"
        costingAnalysisSheet.Cells("B32").Formula = "=B31/B14"
    End Sub
    ''' <summary>
    ''' This method is used to process estimated or actual costing file
    ''' </summary>
    ''' <param name="fileName">File name.</param>
    ''' <param name="templateFileName"></param>
    ''' <param name="costList"></param>
    ''' <param name="costType">Actual,Estimate</param>
    ''' <param name="estimateFilePath"></param>
    ''' <remarks></remarks>
    Public Sub ProcessEstimatedOrActualCostingFile(ByVal fileName As String, ByVal templateFileName As String, ByVal costList As Dictionary(Of String, PMS_OperationCost), ByVal costType As String, ByVal estimateFilePath As String)
        Try
            Dim workbook As Workbook = New Workbook()
            workbook.Open(fileName)
            Dim workbookTemplate As Workbook = New Workbook()
            'need use template and add the template file path to web.config.
            workbookTemplate.Open(templateFileName)
            'Get data from excel, the excel will only has one sheet
            Dim currentUsingCostingSheet As Worksheet = workbook.Worksheets(0)
            workbook.Worksheets.Add()
            Dim costSheetIndex As Integer = 1
            Dim analysisSheetIndex As Integer = 3
            'Dim costSheetIndexTemplate As Integer = 2
            'index = 2 is used for estimate template sheet 
            'index = 3 is used for actual template sheet
            Dim templateCostSheet As Worksheet
            Dim templateErpCostingAnalysisSheet As Worksheet
            If costType = "Estimate" Then
                templateCostSheet = workbookTemplate.Worksheets(estimateTemplateIndex)
            Else

                ' actual sheet, need create the erp cost analysis sheet
                templateCostSheet = workbookTemplate.Worksheets(actualTemplateIndex)
                templateErpCostingAnalysisSheet = workbookTemplate.Worksheets(erpCostAnalysisTemplateIndex)

            End If
            workbook.Worksheets(costSheetIndex).Copy(templateCostSheet)
            workbook.Worksheets(costSheetIndex).Name = templateCostSheet.Name
            If costType = "Actual" Then
                If Not String.IsNullOrEmpty(estimateFilePath) Then
                    Dim estimateWorkBook As Workbook = New Workbook()
                    estimateWorkBook.Open(estimateFilePath)
                    workbook.Worksheets.Add()
                    workbook.Worksheets(2).Copy(estimateWorkBook.Worksheets(1))
                    workbook.Worksheets(2).Name = estimateWorkBook.Worksheets(1).Name
                End If
                workbook.Worksheets.Add()
                workbook.Worksheets(analysisSheetIndex).Copy(templateErpCostingAnalysisSheet)
                workbook.Worksheets(analysisSheetIndex).Name = templateErpCostingAnalysisSheet.Name
            End If
            workbook.CalculateFormula()


            'Deal With every cost object
            For Each costNameStr As String In costNameArr
                SetValueFromSheet(workbook, currentUsingCostingSheet, workbook.Worksheets(templateCostSheet.Name), costList(costNameStr))
                If costType = "Actual" Then
                    'SetValueFromSheet(workbook, currentUsingCostingSheet, workbook.Worksheets(templateCostSheet.Name), costList(costNameStr))
                    'set value for diff in erp costing analysis sheet
                    costList(costNameStr).CostDiff = GetCellValue(Of Decimal)(workbook.Worksheets(templateErpCostingAnalysisSheet.Name).Cells(costList(costNameStr).PropertyCellDictionary(costList(costNameStr).CostName + "_Diff")), Nothing)
                    'costList(costNameStr).CostDiff = workbook.Worksheets(templateErpCostingAnalysisSheet.Name).Cells(costList(costNameStr).PropertyCellDictionary(costList(costNameStr).CostName + "_Diff")).Value
                End If
            Next
            
            'clear formula
            If costType = "Estimate" Then
                For Each costNameStr As String In costNameArr
                    ClearEstimatFormula(workbook, currentUsingCostingSheet, workbook.Worksheets(templateCostSheet.Name), costList(costNameStr))
                Next
            End If


            workbook.Save(fileName)
            'Save every cost object
            operationCostBLL.SaveEntityDictionary(costList)

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Set vlaue from sheet to cost object
    ''' </summary>
    ''' <param name="workbook"></param>
    ''' <param name="currentUsingCostingSheet"></param>
    ''' <param name="CurrentCostingSheet"></param>
    ''' <param name="pMS_OperationCost"></param>
    ''' <remarks></remarks>
    Private Sub SetValueFromSheet(ByVal workbook As Workbook, ByVal currentUsingCostingSheet As Worksheet, ByVal CurrentCostingSheet As Worksheet, ByVal pMS_OperationCost As PMS_OperationCost)
        pMS_OperationCost.SampleSize = GetCellValue(Of Decimal)(CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_SampleSize")), Nothing)
        pMS_OperationCost.TotalCost = GetCellValue(Of Decimal)(CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_TotalCost")), Nothing)
        pMS_OperationCost.AverageCostPerSample = GetCellValue(Of Decimal)(CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_AverageCostPerSample")), Nothing)
    End Sub
    ''' <summary>
    ''' First step: save value to temp object
    ''' Second step:remove formula
    ''' Third step: put the value to excel cell from temp object.
    ''' </summary>
    ''' <param name="workbook"></param>
    ''' <param name="currentUsingCostingSheet"></param>
    ''' <param name="CurrentCostingSheet"></param>
    ''' <param name="pMS_OperationCost"></param>
    ''' <remarks></remarks>
    Private Sub ClearEstimatFormula(ByVal workbook As Workbook, ByVal currentUsingCostingSheet As Worksheet, ByVal CurrentCostingSheet As Worksheet, ByVal pMS_OperationCost As PMS_OperationCost)
        Dim originObject As Object
        originObject = CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_SampleSize")).Value
        CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_SampleSize")).Formula = ""
        CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_SampleSize")).PutValue(originObject)
        originObject = CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_TotalCost")).Value
        CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_TotalCost")).Formula = ""
        CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_TotalCost")).PutValue(originObject)
        originObject = CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_AverageCostPerSample")).Value
        CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_AverageCostPerSample")).Formula = ""
        CurrentCostingSheet.Cells(pMS_OperationCost.PropertyCellDictionary(pMS_OperationCost.CostName + "_AverageCostPerSample")).PutValue(originObject)
    End Sub
    ''' <summary>
    ''' This method is used to init the component operation Cost
    ''' </summary>
    ''' <param name="operationCostDictionary"></param>
    ''' <param name="componentId"></param>
    ''' <param name="costType"></param>
    ''' <remarks></remarks>
    Public Sub InitComponentOperationCostDictionary(ByVal operationCostDictionary As Dictionary(Of String, PMS_OperationCost), ByVal componentId As Integer, ByVal costType As String, ByVal fileId As Integer)
        Dim costList As List(Of PMS_OperationCost) = operationCostBLL.GetComponentCostList(costType, componentId)

        If costList.Count > 0 Then
            For Each cost As PMS_OperationCost In costList
                operationCostDictionary.Add(cost.CostName, cost)
            Next
        Else
            'need init the operation
            For Each costNameStr As String In costNameArr
                Dim cost As New PMS_OperationCost
                cost.Id = -1
                cost.CostName = costNameStr
                operationCostDictionary.Add(costNameStr, cost)
                cost.ComponentId = componentId
                cost.CostingFileId = fileId
                cost.CostType = costType
            Next
        End If

        For Each costPair As KeyValuePair(Of String, PMS_OperationCost) In operationCostDictionary
            SetCellNameForCost(costPair.Value)
        Next
    End Sub

    ''' <summary>
    ''' This method is used to set the relationship between property and cell name
    ''' </summary>
    ''' <param name="operationCost"></param>
    ''' <remarks></remarks>
    Private Sub SetCellNameForCost(ByVal operationCost As PMS_OperationCost)
        operationCost.PropertyCellDictionary.Clear()
        If operationCost.CostName = "SH-FW" Then
            operationCost.PropertyCellDictionary.Add("SH-FW_SampleSize", "B5")
            operationCost.PropertyCellDictionary.Add("SH-FW_TotalCost", "C5")
            operationCost.PropertyCellDictionary.Add("SH-FW_AverageCostPerSample", "D5")
            operationCost.PropertyCellDictionary.Add("SH-FW_Diff", "D4")
        ElseIf operationCost.CostName = "SH-QC" Then
            operationCost.PropertyCellDictionary.Add("SH-QC_SampleSize", "B6")
            operationCost.PropertyCellDictionary.Add("SH-QC_TotalCost", "C6")
            operationCost.PropertyCellDictionary.Add("SH-QC_AverageCostPerSample", "D6")
            operationCost.PropertyCellDictionary.Add("SH-QC_Diff", "D5")
        ElseIf operationCost.CostName = "SH-DP" Then
            operationCost.PropertyCellDictionary.Add("SH-DP_SampleSize", "B7")
            operationCost.PropertyCellDictionary.Add("SH-DP_TotalCost", "C7")
            operationCost.PropertyCellDictionary.Add("SH-DP_AverageCostPerSample", "D7")
            operationCost.PropertyCellDictionary.Add("SH-DP_Diff", "D6")
        ElseIf operationCost.CostName = "SH-Management" Then
            operationCost.PropertyCellDictionary.Add("SH-Management_SampleSize", "B8")
            operationCost.PropertyCellDictionary.Add("SH-Management_TotalCost", "C8")
            operationCost.PropertyCellDictionary.Add("SH-Management_AverageCostPerSample", "D8")
            operationCost.PropertyCellDictionary.Add("SH-Management_Diff", "D7")
        ElseIf operationCost.CostName = "Subcontract-FW" Then
            operationCost.PropertyCellDictionary.Add("Subcontract-FW_SampleSize", "B9")
            operationCost.PropertyCellDictionary.Add("Subcontract-FW_TotalCost", "C9")
            operationCost.PropertyCellDictionary.Add("Subcontract-FW_AverageCostPerSample", "D9")
            operationCost.PropertyCellDictionary.Add("Subcontract-FW_Diff", "D8")
        ElseIf operationCost.CostName = "Subcontract-QC" Then
            operationCost.PropertyCellDictionary.Add("Subcontract-QC_SampleSize", "B10")
            operationCost.PropertyCellDictionary.Add("Subcontract-QC_TotalCost", "C10")
            operationCost.PropertyCellDictionary.Add("Subcontract-QC_AverageCostPerSample", "D10")
            operationCost.PropertyCellDictionary.Add("Subcontract-QC_Diff", "D9")
        ElseIf operationCost.CostName = "Subcontract-DP" Then
            operationCost.PropertyCellDictionary.Add("Subcontract-DP_SampleSize", "B11")
            operationCost.PropertyCellDictionary.Add("Subcontract-DP_TotalCost", "C11")
            operationCost.PropertyCellDictionary.Add("Subcontract-DP_AverageCostPerSample", "D11")
            operationCost.PropertyCellDictionary.Add("Subcontract-DP_Diff", "D10")
        End If


    End Sub

End Class
