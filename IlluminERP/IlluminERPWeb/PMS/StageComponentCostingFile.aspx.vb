
Imports System.Data
Imports DataAccess.BLL
Imports Telerik.Web.UI

Partial Class PMS_StageComponentCostingFile
    Inherits PageBase
    Private stageBLL As New PMS_ProposalStageBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim jobNumber As String = Request.QueryString("JobNumber")
            If String.IsNullOrEmpty(jobNumber) Then
                Return
            End If
            Dim list As DataSet = stageBLL.GetStageComponentCostingFileList(jobNumber)
            ViewState("StageComponent") = list
            RadGrid1.Rebind()
        End If

    End Sub
    Protected Sub BtnSearchComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchComponent.Click
        Dim jobNumber As String = Request.QueryString("JobNumber")
        If String.IsNullOrEmpty(jobNumber) Then
            Return
        End If
        Dim list As DataSet = stageBLL.GetStageComponentCostingFileList(jobNumber)
        ViewState("StageComponent") = list
        RadGrid1.Rebind()
    End Sub
    Protected Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource


        RadGrid1.DataSource = ViewState("StageComponent")

    End Sub
    Protected Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim costingFileId As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("CostingFileIdColumn").Text.Trim()
            Dim componentId As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("ComponentIdColumn").Text
            If costingFileId = "&nbsp;" Then
                costingFileId = ""
            End If
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("OpenEstimateColumn").Text = "<a href='#' onclick=javascript:ShowFileUploadPage('" + costingFileId + "','" + componentId + "','Estimate') >Upload Estimate</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("OpenActualColumn").Text = "<a href='#' onclick=javascript:ShowFileUploadPage('" + costingFileId + "','" + componentId + "','Actual') >Upload Actual</a>"

        End If

        'Dim columnName As String = "StageName"
        Dim columnNameList As New List(Of String)
        columnNameList.Add("StageName")
        columnNameList.Add("Component")
        Dim t As Integer = 0
        For Each columnName As String In columnNameList

            If e.Item.ItemType <> GridItemType.AlternatingItem And e.Item.ItemType <> GridItemType.Item And e.Item.ItemType <> GridItemType.Footer Then
                Exit Sub
            End If
            If RadGrid1.MasterTableView.Items.Count < 2 Then
                Exit Sub
            End If
            Dim i As Integer = RadGrid1.MasterTableView.Items.Count - 1
            Dim tc1 As TableCell = RadGrid1.MasterTableView.Items(i)(columnName)
            Dim tc2 As TableCell = RadGrid1.MasterTableView.Items(i - 1)(columnName)
            If (tc1.Text <> tc2.Text) Then
                Exit Sub
            End If
            Dim k As Integer = 1
            While (tc2.Visible = False)
                k = k + 1
                tc2 = RadGrid1.MasterTableView.Items(i - k)(columnName)
            End While
            tc2.RowSpan = k + 1
            tc2.VerticalAlign = VerticalAlign.Middle
            tc2.HorizontalAlign = HorizontalAlign.Center
            If t = 0 Then
                tc2.BackColor = Drawing.Color.LightGray
            Else
                tc2.BackColor = Drawing.Color.BlanchedAlmond

            End If

            tc1.Visible = False
            t = t + 1
        Next

        
    End Sub
    Protected Sub btnSubmitFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitFile.Click
        'Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        'If component Is Nothing Then
        '    Return
        'End If
        'Dim baseFolder As String = MapPath("~\\" + ConfigurationManager.AppSettings.Item("CostingUploadFolder").ToString())
        ''Dim templateFile As String = ""
        'Dim templateFile As String = MapPath("~\\" + ConfigurationManager.AppSettings.Item("CostingTemplateFile").ToString())
        'Dim fileMaster As New CostingFileMaster
        'Try
        '    For Each f As UploadedFile In RadUpload1.UploadedFiles
        '        'As one component will only has one costing file, so they can have the same name, the latest one will replace the old one
        '        'naming convertion for saving name will be like realname_14.xls,14 is the component id.
        '        Dim extension As String = f.GetExtension()
        '        If Not extension = ".xls" And Not extension = ".xlsx" Then
        '            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "alert", "alert('Only excel file will be processed!')", True)
        '            Return
        '        End If
        '        Dim saveName As String = f.GetNameWithoutExtension + "_" + component.id.ToString + extension
        '        Dim showName As String = f.GetName()
        '        Dim fileName As String = baseFolder + "\" + saveName
        '        If Not Directory.Exists(baseFolder) Then
        '            Directory.CreateDirectory(baseFolder)
        '        End If
        '        f.SaveAs(fileName, True)
        '        linkFile.Text = showName
        '        linkFile.NavigateUrl = "~/" + ConfigurationManager.AppSettings.Item("CostingUploadFolder").ToString() + "/" + saveName
        '        If component.ComponentCostingFile Is Nothing Then
        '            component.ComponentCostingFile = New PMS_ComponentCostingFile
        '            component.ComponentCostingFile.Id = -1
        '            component.ComponentCostingFile.CreatedDate = DateTime.Now
        '            component.ComponentCostingFile.CreatedBy = CurrentLoginUser.ID
        '        Else
        '            component.ComponentCostingFile.UpdatedBy = CurrentLoginUser.ID
        '            component.ComponentCostingFile.UpdatedDate = DateTime.Now
        '        End If
        '        component.ComponentCostingFile.ComponentId = component.id
        '        component.ComponentCostingFile.ShowName = showName
        '        component.ComponentCostingFile.SaveName = saveName
        '        'persist the compoennt costing file to database 
        '        CostingFileBLL.SaveEntity(component.ComponentCostingFile)
        '        'tomorrow need save the file name to database.
        '        fileMaster.ProcessCostingFile(fileName, Me.Response, templateFile)
        '    Next

        'Catch ex As Exception
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "alert", "alert('Some error occur, please check the file!')", True)
        '    Return
        'End Try
    End Sub
End Class
