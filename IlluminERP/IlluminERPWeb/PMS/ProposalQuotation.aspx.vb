Imports Telerik.Web.UI
Imports System.Xml
Imports DataAccess
Imports System.Data
Imports DataAccess.Model
Partial Class PMS_ProposalQuotation
    Inherits OperatePageBase
    Dim quotationBLL As New PMS_QuotationBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

          
        End If
        'If EditStatus.Value = "Edit" Then
        '    'clear format
        '    Dim i As Integer = RadGrid1.MasterTableView.Items.Count - 1
        '    Dim tc1 As TableCell = RadGrid1.MasterTableView.Items(i)("StageName")
        '    tc1.BackColor = Drawing.Color.White
        'Else
        '    'reset format
        'End If
    End Sub
  
    ''' <summary>
    ''' This method is used to set form 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub SetForm()
        MyBase.SetForm()
        'get user id from url
        'Dim componentId As String = Page.Request.QueryString("ComponentId")
        'HardCode
        Dim proposalId As Integer = 0
        Dim jobNumber As String = Page.Request.QueryString("JobNumber")
        Dim quotationList As List(Of PMS_Quotation)
        'quotationList = quotationBLL.GetEntityList()
        'quotationList = quotationBLL.GetProposalQuotationList(0)
        quotationList = quotationBLL.GetQuotationListByJobNumber(jobNumber)

        
        ViewState("QuotationList") = quotationList
        CalcTotal(quotationList, "OptionalFee")
        CalcTotal(quotationList, "ActuralFee")


    End Sub

    Protected Sub RadGrid1_ItemUpdated(ByVal source As Object, ByVal e As GridUpdatedEventArgs) Handles RadGrid1.ItemUpdated
        If Not e.Exception Is Nothing Then
            e.KeepInEditMode = True
            e.ExceptionHandled = True
            'SetMessage(Server.HtmlEncode("Unable to update Products. Reason: " + e.Exception.Message).Replace("'", "&#39;").Replace(vbCrLf, "<br />"))
        Else
            Dim dataItem As GridDataItem = e.Item
            'SetMessage("ProductID " & dataItem.GetDataKeyValue("ProductID") & " updated")
        End If

    End Sub

    Protected Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        Dim quotationList As List(Of PMS_Quotation) = CType(ViewState("QuotationList"), List(Of PMS_Quotation))
        RadGrid1.DataSource = quotationList

    End Sub
  
    Protected Sub RadGrid1_UpdateCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.UpdateCommand
        Dim quotationList As List(Of PMS_Quotation) = CType(ViewState("QuotationList"), List(Of PMS_Quotation))
        Dim editedItem As GridEditableItem = CType(e.Item, GridEditableItem)
        Dim editMan As GridEditManager = editedItem.EditManager
        Dim currowRow As Integer = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).ItemIndex 'e.Item.RowIndex - 2
        Dim currentQuotation As PMS_Quotation = quotationList(currowRow)
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

                    'tony,check with origin value, if equal, then need do updation

                    If currowRow < 0 Then
                        Continue For
                    End If
                    Dim originText As String = ""
                    If (column.UniqueName = "Option1Fee") Then
                        originText = currentQuotation.Option1Fee.ToString
                        If String.Equals(editorText, originText) Then
                            Continue For
                        End If
                        currentQuotation.Option1Fee = CType(editorText, Decimal)
                    ElseIf column.UniqueName = "ActualColumn" Then
                        originText = currentQuotation.ActuralFee.ToString
                        If String.Equals(editorText, originText) Then
                            Continue For
                        End If
                        currentQuotation.ActuralFee = CType(editorText, Decimal)
                    End If
                End If
            End If
        Next
        Try
            currentQuotation.UpdatedBy = CurrentLoginUser.ID
            currentQuotation.UpdatedDate = DateTime.Now
            quotationBLL.SaveEntity(currentQuotation)
            RadGrid1.Rebind()

            CalcTotal(quotationList, "OptionalFee")
            CalcTotal(quotationList, "ActuralFee")
        Catch ex As Exception
            e.Canceled = True
        End Try
    End Sub

    'Protected Sub RadGrid1_CustomAggregate(ByVal sender As Object, ByVal e As GridCustomAggregateEventArgs) Handles RadGrid1.CustomAggregate
    '    Dim columnName = e.Column.UniqueName
    '    Dim quotationList As List(Of PMS_Quotation) = DirectCast(DirectCast(sender, RadGrid).DataSource, List(Of PMS_Quotation))
    '    Dim value As Double = 0
    '    For Each quotation As PMS_Quotation In quotationList
    '        Dim cellValue As String = ""
    '        If (columnName = "Option1Fee") Then
    '            cellValue = quotation.Option1Fee.ToString
    '        ElseIf columnName = "Option2Fee" Then
    '            cellValue = quotation.Option2Fee.ToString
    '        End If
    '        If String.IsNullOrEmpty(cellValue) Then
    '            Continue For
    '        End If

    '        value += CDbl(cellValue)
    '    Next
    '    e.Result = "Total:" + value.ToString
    'End Sub

    Protected Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
       
        'Dim columnName As String = "StageName"
        'Dim columnNameList As New List(Of String)
        'columnNameList.Add("StageName")
        ''columnNameList.Add("ComponentColumn")
        'Dim t As Integer = 0
        'For Each columnName As String In columnNameList
        '    If e.Item.ItemType <> GridItemType.AlternatingItem And e.Item.ItemType <> GridItemType.Item And e.Item.ItemType <> GridItemType.Footer And e.Item.ItemType <> GridItemType.Header Then
        '        Exit Sub
        '    End If
        '    If RadGrid1.MasterTableView.Items.Count < 2 Then
        '        Exit Sub
        '    End If
        '    Dim i As Integer = RadGrid1.MasterTableView.Items.Count - 1
        '    Dim tc1 As TableCell = RadGrid1.MasterTableView.Items(i)(columnName)
        '    Dim tc2 As TableCell = RadGrid1.MasterTableView.Items(i - 1)(columnName)
        '    If (tc1.Text <> tc2.Text) Then
        '        Exit Sub
        '    End If
        '    Dim k As Integer = 1
        '    While (tc2.Visible = False)
        '        k = k + 1
        '        tc2 = RadGrid1.MasterTableView.Items(i - k)(columnName)
        '    End While
        '    tc2.RowSpan = k + 1
        '    tc2.VerticalAlign = VerticalAlign.Middle
        '    tc2.HorizontalAlign = HorizontalAlign.Center
        '    'tc2.BackColor = Drawing.Color.LightGray
        '    If t = 0 Then
        '        tc2.BackColor = Drawing.Color.LightGray
        '    Else
        '        tc2.BackColor = Drawing.Color.BlanchedAlmond

        '    End If
        '    tc1.Visible = False
        '    t = t + 1
        'Next
        
    End Sub
 

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        RadGrid1.MasterTableView.GetColumn("EditColumn").Visible = False
        Me.RadGrid1.ExportSettings.FileName = "Quotation_" + Page.Request.QueryString("JobNumber")
        Me.RadGrid1.MasterTableView.ExportToExcel()
    End Sub

    Private Sub CalcTotal(ByVal quotationList As List(Of PMS_Quotation), ByVal feeType As String)

        Dim descriptionList As List(Of String)
        If feeType = "ActuralFee" Then
            descriptionList = GetActuralQuotationDescription(quotationList)
        Else
            descriptionList = GetQuotationDescription(quotationList)
        End If

        If descriptionList Is Nothing Then
            Return
        End If
        Dim totalStr As String = ""
        For Each description As String In descriptionList
            totalStr += "<div class='itemDiv'>" + description + "</div>"
        Next
        'If feeType = "ActuralFee" Then
        '    spanActuralTtal.InnerHtml = totalStr
        'Else
        '    spanTotal.InnerHtml = totalStr
        'End If

    End Sub
    Private Function GetQuotationDescription(ByVal quotationList As List(Of PMS_Quotation)) As List(Of String)
        'Dim quotationList As List(Of PMS_Quotation) = CType(ViewState("QuotationList"), List(Of PMS_Quotation))
        If quotationList Is Nothing Then
            Return Nothing
        End If
        If quotationList.Count = 0 Then
            Return Nothing
        End If
        Dim descriptionList As New List(Of String)
        Dim totalQutation As Decimal = (From quotation In quotationList Select quotation.Option1Fee).Sum()
        descriptionList.Add("Total quotation is:" + totalQutation.ToString())
        Dim totalQuotationWithoutOptional As Decimal = (From quotation In quotationList Where quotation.QuotationType <> TaskType.OptionalTask.ToString() Select quotation.Option1Fee).Sum()
        descriptionList.Add("Qutation without optional quotaion is:" + totalQuotationWithoutOptional.ToString())
        Dim subList As List(Of List(Of PMS_Quotation)) = GetOptionalQuotationCollection(quotationList)
        If subList Is Nothing Then
            Return descriptionList
        End If
        Dim subListWithOrder = From list In subList Order By list.Count Ascending Select list
        For Each optionalQuotationList As List(Of PMS_Quotation) In subListWithOrder
            Dim taskDescription As String = "Qutation contain "
            Dim fee As Decimal = totalQuotationWithoutOptional
            For Each optionalQuotation As PMS_Quotation In optionalQuotationList
                taskDescription += " " + optionalQuotation.Task + "(" + optionalQuotation.Option1Fee.ToString + ")" + " and"
                fee += optionalQuotation.Option1Fee
            Next
            taskDescription = taskDescription.Substring(0, taskDescription.Length - 3) + " will be:" + fee.ToString
            descriptionList.Add(taskDescription)
        Next
        Return descriptionList
    End Function
    Private Function GetActuralQuotationDescription(ByVal quotationList As List(Of PMS_Quotation)) As List(Of String)
        'Dim quotationList As List(Of PMS_Quotation) = CType(ViewState("QuotationList"), List(Of PMS_Quotation))
        If quotationList Is Nothing Then
            Return Nothing
        End If
        If quotationList.Count = 0 Then
            Return Nothing
        End If
        Dim descriptionList As New List(Of String)
        Dim totalQutation As Decimal = (From quotation In quotationList Select quotation.ActuralFee).Sum()
        descriptionList.Add("Total actural quotation is:" + totalQutation.ToString())
        Dim totalQuotationWithoutOptional As Decimal = (From quotation In quotationList Where quotation.QuotationType <> TaskType.OptionalTask.ToString() Select quotation.ActuralFee).Sum()
        descriptionList.Add("Actural qutation without optional quotaion is:" + totalQuotationWithoutOptional.ToString())
        Dim subList As List(Of List(Of PMS_Quotation)) = GetOptionalQuotationCollection(quotationList)
        If subList Is Nothing Then
            Return descriptionList
        End If
        Dim subListWithOrder = From list In subList Order By list.Count Ascending Select list
        For Each optionalQuotationList As List(Of PMS_Quotation) In subListWithOrder
            Dim taskDescription As String = "Actural Qutation contain "
            Dim fee As Decimal = totalQuotationWithoutOptional
            For Each optionalQuotation As PMS_Quotation In optionalQuotationList
                taskDescription += " " + optionalQuotation.Task + "(" + optionalQuotation.ActuralFee.ToString + ")" + " and"
                fee += optionalQuotation.ActuralFee
            Next
            taskDescription = taskDescription.Substring(0, taskDescription.Length - 3) + " will be:" + fee.ToString
            descriptionList.Add(taskDescription)
        Next
        Return descriptionList
    End Function
    Private Function GetOptionalQuotationCollection(ByVal quotationList As List(Of PMS_Quotation)) As List(Of List(Of PMS_Quotation))
        
            Dim subList As New List(Of List(Of PMS_Quotation))
            Dim optionalList As PMS_Quotation() = (From quotation In quotationList Where quotation.QuotationType = TaskType.OptionalTask.ToString() Select quotation).ToArray()
            If optionalList.Length = 0 Then
                Return Nothing
            End If
            Dim setArr(optionalList.Length) As Integer
            Dim i As Integer = 0
            Dim n As Integer = 0
            Dim position As Integer = 0
            setArr(position) = 1
            subList.Add(New List(Of PMS_Quotation))
            While (True)
                subList(subList.Count - 1).Add(optionalList(setArr(0) - 1))
                For i = 1 To position
                    subList(subList.Count - 1).Add(optionalList(setArr(i) - 1))
                Next
                If setArr(position) < setArr.Length - 1 Then
                    setArr(position + 1) = setArr(position) + 1
                    subList.Add(New List(Of PMS_Quotation))
                    position = position + 1
                ElseIf position <> 0 Then
                    position = position - 1
                    setArr(position) += 1
                    subList.Add(New List(Of PMS_Quotation))
                Else
                    Exit While
                End If
            End While

            Return subList
    End Function

   
    Protected Sub RadGrid1_EditCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.EditCommand

        Dim tc1 As TableCell = RadGrid1.MasterTableView.Items(e.Item.ItemIndex)("StageName")
        tc1.Visible = True
    End Sub

    Protected Sub RadGrid1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.PreRender
        'Dim columnName As String = "StageName"
        Dim columnNameList As New List(Of String)
        columnNameList.Add("StageName")
        columnNameList.Add("ComponentColumn")
        For Each columnName As String In columnNameList
            For Each dataItem As GridDataItem In RadGrid1.Items
                Dim tv As GridTableView = DirectCast(dataItem.OwnerTableView, GridTableView)


                For rowIndex As Integer = tv.Items.Count - 2 To 0 Step -1

                    Dim row = tv.Items(rowIndex)
                    Dim previousRow = tv.Items(rowIndex + 1)
                    If row(columnName).Text = "&nbsp;" And previousRow(columnName).Text = "&nbsp;" Then
                        Continue For
                    End If
                    If row(columnName).Text = previousRow(columnName).Text Then
                        'row("StageName").RowSpan = previousRow("StageName").RowSpan <2?2:previousRow("StageName").RowSpan+1
                        If previousRow(columnName).RowSpan < 2 Then
                            row(columnName).RowSpan = 2
                        Else
                            row(columnName).RowSpan = previousRow(columnName).RowSpan + 1
                        End If
                        previousRow(columnName).Visible = False
                        'previousRow(columnName).Text = rowIndex.ToString
                        If columnName = "StageName" Then
                            row(columnName).BackColor = Drawing.Color.LightGray
                        Else
                            row(columnName).BackColor = Drawing.Color.BlanchedAlmond
                        End If

                    End If


                Next
            Next
        Next
        
    End Sub

    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("StageForm.aspx?JobNumber=" + Page.Request.QueryString("JobNumber"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("Proposaltiming.aspx?JobNumber=" + Page.Request.QueryString("JobNumber"))
    End Sub

End Class
