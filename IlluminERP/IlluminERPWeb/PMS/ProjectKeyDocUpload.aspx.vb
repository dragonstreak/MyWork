Imports System.Runtime.Serialization.Json
Imports System.IO
Imports System.Web.Services
Imports System.Runtime.Serialization
Imports System.Collections.Generic
Imports Telerik.Web.UI
Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils.PageUtils
Imports Utils
Imports DataAccess
Partial Class PMS_ProjectKeyDocUpload
    Inherits System.Web.UI.Page
    Private callBack As CacheItemRemovedCallback
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private ProjectStatusBLL As New BLL.Base_ProjectStatusBLL
    Private ProposalUserinfoBLl As New BLL.PMS_ProposalUserInfoBLL
    Private ProjectContractFileBLL As New BLL.PMS_ProjectContractFileInfoBLL
    Private colUser As New Collection
    Private MyUserInfoBLL As New BLL.UserInfoBLL
    Private ProjectContractInfoBLL As New BLL.PMS_ProjectContractInfoBLL
    Private FileUploadFileTypeBLL As New BLL.PMS_UploadFileTypeBLL
    Private UploadFileInfoBLL As New BLL.PMS_UploadFileInfoBLL
    Dim info As New Model.PMS_ProposalInfo
    Dim ClientInfo As New Model.Client_ClientInfo
    Dim Myuserinfo As New Model.User_UserInfo

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim strUploadProjectFilePath As String
        Dim uploadfileinfo As New Model.PMS_UploadFileInfo
        Dim counter As Integer = 0
        Dim strId As String = Request.QueryString("Proid")

        If Not Session("LoginUserInfo") Is Nothing Then
            Myuserinfo = Session("LoginUserInfo")
        End If

        If Me.cbFileType.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Please select  the File Type !")
            Exit Sub
        End If

        strUploadProjectFilePath = System.Web.Configuration.WebConfigurationManager.AppSettings("UploadProjectFilePath").ToString
        strUploadProjectFilePath = strUploadProjectFilePath & Me.txtJobNumber.Text.Trim
        strUploadProjectFilePath = strUploadProjectFilePath & "\" & cbFileType.SelectedItem.Text.Trim & "\"
        Me.RadUpload.TargetPhysicalFolder = strUploadProjectFilePath

     

        For i = 0 To Me.RadUpload.UploadedFiles.Count - 1
            uploadfileinfo.ProId = strId
            uploadfileinfo.FileName = RadUpload.UploadedFiles(i).GetNameWithoutExtension() + RadUpload.UploadedFiles(i).GetExtension()
            uploadfileinfo.FileFolder = RadUpload.TargetPhysicalFolder.ToString
            uploadfileinfo.FileType = Me.cbFileType.SelectedValue
            UploadFileInfoBLL.AddUploadFileInfo(uploadfileinfo)
        Next

        Dim dv As DataView = Me.UploadFileInfoBLL.GetUploadFileInfoByProId(strId)
        Me.RadGrid.DataSource = dv
        Me.RadGrid.DataBind()

    End Sub

    Private Function CreateTable() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("ProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("FileName", GetType(System.String)))
        dt.Columns.Add(New DataColumn("FileFolder", GetType(System.String)))
        dt.Columns.Add(New DataColumn("FileType", GetType(System.String)))
        Return dt
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            InitForm()
        End If
    End Sub
    Protected Sub RadUpload_FileExists(ByVal sender As Object, ByVal e As Telerik.Web.UI.Upload.UploadedFileEventArgs) Handles RadUpload.FileExists

        Dim counter As Integer = 1

        Dim file As UploadedFile = e.UploadedFile

        Dim targetFolder As String = Server.MapPath(RadUpload.TargetFolder)

        Dim targetFileName As String = Path.Combine(targetFolder, file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension())

        While System.IO.File.Exists(targetFileName)
            counter += 1
            targetFileName = Path.Combine(targetFolder, file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension())
        End While

        file.SaveAs(targetFileName)


    End Sub

    Private Sub InitForm()

        Dim ClientId As String
        Me.txtJobNumber.Enabled = False
        Me.txtClient.Enabled = False
        Me.txtJobName.Enabled = False

        Dim strId As String = Request.QueryString("Proid")
        Dim dv As New DataView
        Try


            info = ProposalInfoBLL.GetProposalInfoByID(CInt(strId))
            ViewState("info") = info
            If info Is Nothing Then
                Exit Sub
            End If


            Me.txtJobNumber.Text = info.JobNumber
            Me.txtJobName.Text = info.JobName


            ClientId = info.ClientId
            Me.ClientInfo = Me.ClientInfoBLL.GetClientInfoByID(ClientId)
            Me.txtClient.Text = ClientInfo.FullName

            Dim ds As DataSet = FileUploadFileTypeBLL.GetFileTypeInfo
            If Not ds Is Nothing Then
                Utils.PageUtils.BindComboBoxList(Me.cbFileType, ds, "id", "FileType", 2)
            End If


            dv = Me.UploadFileInfoBLL.GetUploadFileInfoByProId(strId)
            Me.RadGrid.DataSource = dv
            Me.RadGrid.DataBind()


        Catch ex As Exception

        End Try
       

    End Sub

    Protected Sub RadGrid_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid.ItemCommand
        If e.CommandName = "Download" Then


            Dim fileName As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnFileName").Text
            If fileName <> Nothing AndAlso fileName.Trim() <> "" Then
                Dim filePath As String = System.Configuration.ConfigurationManager.AppSettings("ArticleUploadPath")
                If filePath = Nothing OrElse filePath.Trim() = "" Then
                    filePath = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnFileFolder").Text
                End If
                filePath = System.IO.Path.Combine(filePath, fileName)

                Response.Clear()
                Response.ContentType = "application/octet-stream"
                ' Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(Server.MapPath(filePath)))
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filePath))
                Response.WriteFile(filePath)
                Response.[End]()
            End If
        End If

        If e.CommandName = "Delete" Then
            Dim strId As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnId").Text
            Dim fileName As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnFileName").Text
            Dim filePath As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnFileFolder").Text
            Dim info As New PMS_UploadFileInfo
            info.ID = strId
            UploadFileInfoBLL.DeleteUploadFileInfo(info)

            File.Delete(DirectCast(System.IO.Path.Combine(filePath, fileName), String))
        End If
    End Sub
    Protected Sub RadGrid_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid.NeedDataSource
        Dim strId As String = Request.QueryString("Proid")
        Dim dv As Data.DataView = UploadFileInfoBLL.GetUploadFileInfoByProId(strId)
        Me.RadGrid.DataSource = dv
    End Sub

    Protected Sub RadUpload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadUpload.Load

    End Sub

    Protected Sub cbFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbFileType.SelectedIndexChanged
        Dim strUploadProjectFilePath As String
        strUploadProjectFilePath = System.Web.Configuration.WebConfigurationManager.AppSettings("UploadProjectFilePath").ToString
        strUploadProjectFilePath = strUploadProjectFilePath & Me.txtJobNumber.Text.Trim
        strUploadProjectFilePath = strUploadProjectFilePath & "\" & cbFileType.SelectedItem.Text.Trim & "\"
        Me.RadUpload.TargetPhysicalFolder = strUploadProjectFilePath
    End Sub
End Class
