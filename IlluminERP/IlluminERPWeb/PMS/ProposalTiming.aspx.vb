Imports Telerik.Web.UI
Imports System.Xml
Imports DataAccess
Imports System.Data
Imports DataAccess.Model
Partial Class PMS_ProposalTiming
    Inherits OperatePageBase
    Dim timingBLL As New PMS_TimingBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            'GetStageList()
            'RefreshStageDiv()

        End If

    End Sub

    Protected Overrides Sub InitForm()
        MyBase.InitForm()

    End Sub
    
    ''' <summary>
    ''' This method is used to set form 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub SetForm()
        MyBase.SetForm()
        'get user id from url
        'Dim componentId As String = Page.Request.QueryString("ComponentId")
        Dim proposalID As Integer = 0
        Dim jobNumber As String = Page.Request.QueryString("JobNumber")
        Me.RadGrid1.ExportSettings.FileName = jobNumber + "_Timing"
        Dim timingList As List(Of PMS_Timing)
        'timingList = timingBLL.GetEntityList()
        timingList = timingBLL.GetTimingListByJobNumber(jobNumber)

      

        ViewState("TimingList") = timingList

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
        Dim timingList As List(Of PMS_Timing) = CType(ViewState("TimingList"), List(Of PMS_Timing))
        RadGrid1.DataSource = timingList
    End Sub
    Protected Sub RadGrid1_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles RadGrid1.DataBound
        'If Not String.IsNullOrEmpty(gridMessage) Then
        'DisplayMessage(gridMessage)
        'End If

    End Sub
    Protected Sub RadGrid1_UpdateCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.UpdateCommand
        Dim timingList As List(Of PMS_Timing) = CType(ViewState("TimingList"), List(Of PMS_Timing))
        Dim editedItem As GridEditableItem = CType(e.Item, GridEditableItem)
        Dim editMan As GridEditManager = editedItem.EditManager
        Dim currowRow As Integer = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).ItemIndex 'e.Item.RowIndex - 2
        Dim currentTiming As PMS_Timing = timingList(currowRow)
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
                    If (column.UniqueName = "DayCount") Then
                        originText = currentTiming.DayCount.ToString
                        If String.Equals(editorText, originText) Then
                            Continue For
                        End If
                        currentTiming.DayCount = CType(editorText, Integer)
                    ElseIf column.UniqueName = "WeekCount" Then
                        originText = currentTiming.WeekCount.ToString
                        If String.Equals(editorText, originText) Then
                            Continue For
                        End If
                        currentTiming.WeekCount = CType(editorText, Decimal)
                    End If
                End If
            End If
        Next
        Try
            'Just for test
            'For Each timing As PMS_Timing In timingList
            '    If timing.StartDate.HasValue And timing.EndDate.HasValue Then
            '        GetDays(timing)
            '    End If
            'Next
            currentTiming.UpdatedBy = CurrentLoginUser.ID
            currentTiming.UpdatedDate = DateTime.Now
            timingBLL.SaveEntity(currentTiming)
            
            ViewState("TimingList") = timingList
            RadGrid1.Rebind()
        Catch ex As Exception
            e.Canceled = True
        End Try
    End Sub
    Public Sub GetDays(ByVal timing As PMS_Timing)
        Dim ts As TimeSpan = timing.EndDate.Value.Subtract(timing.StartDate.Value)
        timing.DayCount = ts.Days
        Dim weekDay As Integer = 0
        '下次再把工作日，休息日的扩展加进来
        For i = 0 To timing.DayCount
            Dim tempDate As DateTime = timing.StartDate.Value.AddDays(i)
            If tempDate.DayOfWeek = System.DayOfWeek.Saturday Or tempDate.DayOfWeek = System.DayOfWeek.Sunday Then
                Continue For
            End If
            weekDay = weekDay + 1
        Next
        timing.DayCount = weekDay
        timing.WeekCount = weekDay / 5
    End Sub
    Protected Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound

        'Dim columnName As String = "StageName"
        'Dim columnNameList As New List(Of String)
        'columnNameList.Add("StageName")
        'columnNameList.Add("ComponentColumn")
        'Dim t As Integer = 0
        'For Each columnName As String In columnNameList
        '    If e.Item.ItemType <> GridItemType.AlternatingItem And e.Item.ItemType <> GridItemType.Item And e.Item.ItemType <> GridItemType.Footer Then
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
        '    'Dim gridDecorder As GridAlternatingItemDecorator
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
    'Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExport.Click

    '    RadGrid1.MasterTableView.GetColumn("EditColumn").Visible = False
    '    Me.RadGrid1.ExportSettings.FileName = "Timing_" + Page.Request.QueryString("JobNumber")
    '    Me.RadGrid1.MasterTableView.ExportToExcel()
    'End Sub
    
   
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        RadGrid1.MasterTableView.GetColumn("EditColumn").Visible = False
        Me.RadGrid1.ExportSettings.FileName = "Timing_" + Page.Request.QueryString("JobNumber")
        Me.RadGrid1.MasterTableView.ExportToExcel()
    End Sub

    Protected Sub RadGrid1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.PreRender
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
        Response.Redirect("ProposalQuotation.aspx?JobNumber=" + Page.Request.QueryString("JobNumber"))
    End Sub

    Protected Sub btnReturnStage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturnStage.Click
        Response.Redirect("StageForm.aspx?JobNumber=" + Page.Request.QueryString("JobNumber"))
    End Sub
End Class

