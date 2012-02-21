Imports Telerik.Web.UI
Imports System.IO
Imports DataAccess
Imports DataAccess.Model

Partial Class CostingFileUploadPage
    Inherits OperatePageBase
    Private CostingFileBLL As New PMS_ComponentCostingFileBLL
    Protected Overrides Sub SetForm()
        MyBase.SetForm()
        'get user id from url
        Dim currentFile As PMS_ComponentCostingFile
        If OperateType = "Modify" Then
            Dim id As String = Page.Request.QueryString("FileId")
            currentFile = CostingFileBLL.GetEntityById(Convert.ToInt32(id))

        Else
            currentFile = New PMS_ComponentCostingFile()
            currentFile.Id = -1
        End If
        Dim fileType As String = Page.Request.QueryString("FileType")
        labelStatus.Text = "Upload " + fileType + " file(only for excel file)"
        ViewState("CurrentFile") = currentFile
    End Sub

    Protected Sub btnSubmitFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitFile.Click
        'Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        Dim currentFile As PMS_ComponentCostingFile = CType(ViewState("CurrentFile"), PMS_ComponentCostingFile)
        'fileType should be 'estimate' or 'actual'
        Dim fileType As String = Page.Request.QueryString("FileType")
        Dim componentId As Integer = CType(Page.Request.QueryString("ComponentId"), Integer)
        Dim fileId As Integer? = -1
        If Not String.IsNullOrEmpty(Page.Request.QueryString("FileId")) Then
            fileId = CType(Page.Request.QueryString("FileId"), Integer)
        End If

        Dim baseFolder As String = MapPath("~\\" + ConfigurationManager.AppSettings.Item("CostingUploadFolder").ToString())
        'Dim templateFile As String = ""
        Dim templateFile As String = MapPath("~\\" + ConfigurationManager.AppSettings.Item("CostingTemplateFile").ToString())
        Dim fileMaster As New CostingFileMaster
        Try
            For Each f As UploadedFile In RadUpload1.UploadedFiles
                'As one component will only has one costing file, so they can have the same name, the latest one will replace the old one
                'naming convertion for saving name will be like realname_14.xls,14 is the component id.
                Dim extension As String = f.GetExtension()
                If Not extension = ".xls" And Not extension = ".xlsx" Then
                    ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "alert", "alert('Only excel file will be processed!')", True)
                    Return
                End If
                Dim saveName As String = f.GetNameWithoutExtension + "_" + componentId.ToString + "_" + fileType + extension
                Dim showName As String = f.GetName()
                Dim fileName As String = Path.Combine(baseFolder, saveName) 'baseFolder + "\" + saveName
                If Not Directory.Exists(baseFolder) Then
                    Directory.CreateDirectory(baseFolder)
                End If
                f.SaveAs(fileName, True)

                If currentFile.Id = -1 Then
                    currentFile.CreatedDate = DateTime.Now
                    currentFile.CreatedBy = CurrentLoginUser.ID
                Else
                    currentFile.UpdatedBy = CurrentLoginUser.ID
                    currentFile.UpdatedDate = DateTime.Now
                End If
                currentFile.ComponentId = componentId
                If fileType = "Actual" Then
                    currentFile.ShowName_Actual = showName
                    currentFile.SaveName_Actual = saveName
                Else
                    currentFile.ShowName = showName
                    currentFile.SaveName = saveName
                End If
                
                'persist the compoennt costing file to database 
                CostingFileBLL.SaveEntity(currentFile)

                Dim estimateFileName As String = ""
                If fileType = "Actual" Then
                    'looking for the estimate file                   
                    If Not String.IsNullOrEmpty(currentFile.SaveName) Then
                        Dim estimatePath As String = Path.Combine(baseFolder, currentFile.SaveName)
                        If File.Exists(estimatePath) Then
                            estimateFileName = estimatePath
                        End If
                    End If
                End If

                Dim costDictionary As New Dictionary(Of String, PMS_OperationCost)
                fileMaster.InitComponentOperationCostDictionary(costDictionary, componentId, fileType, currentFile.Id)
                fileMaster.ProcessEstimatedOrActualCostingFile(fileName, templateFile, costDictionary, fileType, estimateFileName)
                'tomorrow need save the file name to database.
                ' fileMaster.ProcessCostingFile(fileName, Me.Response, templateFile)
            Next

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "alert", "alert('Some error occur, please check the file!')", True)
            Return
        End Try
        Response.Write("<script language=javascript>")
        Response.Write("alert('success!');window.returnValue='success';window.close();")
        Response.Write("</script>")

    End Sub
End Class
