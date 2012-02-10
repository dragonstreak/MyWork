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

Partial Class PMS_ProjectContract
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
    Dim info As New Model.PMS_ProposalInfo
    Dim ClientInfo As New Model.Client_ClientInfo
    Dim Myuserinfo As New Model.User_UserInfo

   
    Private Sub AddDeleteDependencyForFile(ByVal uploadedFileCollection As UploadedFileCollection)
        Dim uploadedFile As UploadedFile
        For Each uploadedFile In uploadedFileCollection
            Dim timeOut As TimeSpan = TimeSpan.FromMinutes(5)

            callBack = New CacheItemRemovedCallback(AddressOf DeleteFile)

            Dim fullPath As String = Path.Combine(Server.MapPath(RadUpload.TargetFolder), uploadedFile.GetName())

            Context.Cache.Insert(uploadedFile.FileName, fullPath, Nothing, DateTime.Now.Add(timeOut), TimeSpan.Zero, CacheItemPriority.Default, callBack)
        Next
    End Sub

    Private Sub DeleteFile(ByVal key As String, ByVal path As Object, ByVal reason As CacheItemRemovedReason)
        File.Delete(DirectCast(path, String))
    End Sub


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim Contractinfo As New PMS_ProjectContractInfo
        Dim counter As Integer = 0
        Dim strId As String = Request.QueryString("Proid")
        If Not Session("LoginUserInfo") Is Nothing Then
            MyUserinfo = Session("LoginUserInfo")
        End If


        'For Each file As UploadedFile In Me.RadUpload.UploadedFiles

        '    Dim targetFolder As String = Server.MapPath(RadUpload.TargetFolder)

        '    Dim targetFileName As String = Path.Combine(targetFolder, file.GetNameWithoutExtension() + file.GetExtension())

        '    While System.IO.File.Exists(targetFileName)
        '        counter += 1
        '        targetFileName = Path.Combine(targetFolder, file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension())
        '    End While

        'Next

        Contractinfo.AdditionalAmount = Me.txtAdditionalAmount.Value
        Contractinfo.Amount = Me.txtAmount.Value
        Contractinfo.Contact = Me.txtContact.Text.Trim.ToString
        Contractinfo.Telephone = Me.txtTel.Text.Trim
        Contractinfo.ContractDate = Me.txtContractDate.SelectedDate.Value
        Contractinfo.Memo = Me.txtMemo.Text.Trim
        Contractinfo.ProjectId = strID
        Contractinfo.CreateUser = Me.Myuserinfo.ID
        Contractinfo.CreateDate = Now.Date


        Dim dt As DataTable = Me.CreateTable
        Dim dr As DataRow


        For i = 0 To Me.RadUpload.UploadedFiles.Count - 1
            dr = dt.NewRow
            dr("ProId") = strId
            dr("FileName") = RadUpload.UploadedFiles(i).GetNameWithoutExtension() + RadUpload.UploadedFiles(i).GetExtension()
            dr("FileFolder") = RadUpload.TargetPhysicalFolder.ToString
            dt.Rows.Add(dr)
            dt.AcceptChanges()
        Next


        If ProjectContractInfoBLL.IsExistProjectContract(strId) = False Then
            'new
            If ProjectContractInfoBLL.NewContractInfo(Contractinfo, dt) > 0 Then

            End If
        Else
            'Modify
            If ProjectContractInfoBLL.ModifyContractInfo(Contractinfo, dt) > 0 Then

            End If

        End If


        Dim dv As Data.DataView = ProjectContractFileBLL.GetProjectContractFileInfoByProId(strId)
        Me.RadGrid.DataSource = dv
        Me.RadGrid.DataBind()

        'Remove this line if you do not want to delete the files
        'in the targetfolder after they have been saved there
        ' AddDeleteDependencyForFile(RadUpload.UploadedFiles)

    End Sub

    Private Function CreateTable() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("ProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("FileName", GetType(System.String)))
        dt.Columns.Add(New DataColumn("FileFolder", GetType(System.String)))
        Return dt

    End Function

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            InitForm()
        End If
    End Sub

    Private Sub InitForm()

        Dim ClientId As String
        Dim strUploadProjectFilePath As String

       
        Me.txtJobNumber.Enabled = False
        Me.txtProjectOwner.Enabled = False
        Me.txtClient.Enabled = False
        Me.txtJobName.Enabled = False

        Dim strId As String = Request.QueryString("Proid")
        Dim dv As New DataView
        Try
            info = ProposalInfoBLL.GetProposalInfoByID(CInt(StrId))
            ViewState("info") = info
            If info Is Nothing Then
                Exit Sub
            End If


            Me.txtJobNumber.Text = info.JobNumber
            Me.txtJobName.Text = info.JobName


            ClientId = info.ClientId
            Me.ClientInfo = Me.ClientInfoBLL.GetClientInfoByID(ClientId)
            Me.txtClient.Text = ClientInfo.FullName
            strUploadProjectFilePath = System.Web.Configuration.WebConfigurationManager.AppSettings("UploadProjectFilePath").ToString
            strUploadProjectFilePath = strUploadProjectFilePath & Me.txtJobNumber.Text.Trim
            strUploadProjectFilePath = strUploadProjectFilePath & "\Contract\"

            Me.RadUpload.TargetPhysicalFolder = strUploadProjectFilePath

            Dim ds As DataSet = Me.ProposalUserinfoBLl.GetProposalUserinfoByProId(StrId)

            If Not ds Is Nothing Then
                Dim dt As DataTable = ds.Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        If dr("ProposalUserTypeId") = 1 Then
                            Dim info = Me.MyUserInfoBLL.GetUserInfoById(dr("UserId"))
                            ' Me.txt.Text = info.E_Name
                        End If

                        If dr("ProposalUserTypeId") = 2 Then
                            Dim info = Me.MyUserInfoBLL.GetUserInfoById(dr("UserId"))
                            Me.txtProjectOwner.Text = info.E_Name
                        End If
                    Next

                End If
            End If

            Dim ContractInfo As New PMS_ProjectContractInfo

            ContractInfo = Me.ProjectContractInfoBLL.GetProjectContractInfobyProId(strId)
            Me.txtContractDate.SelectedDate = CType(ContractInfo.ContractDate, Date)
            Me.txtAmount.Value = ContractInfo.Amount
            Me.txtAdditionalAmount.Value = ContractInfo.AdditionalAmount
            Me.txtMemo.Text = ContractInfo.Memo
            Me.txtContact.Text = ContractInfo.Contact
            Me.txtTel.Text = ContractInfo.Telephone


            dv = ProjectContractFileBLL.GetProjectContractFileInfoByProId(strId)
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
            Dim info As New PMS_ProjectContractFileInfo
            info.ID = strId
            ProjectContractFileBLL.DeleteProjectContractFileInfo(info)

            File.Delete(DirectCast(System.IO.Path.Combine(filePath, fileName), String))
        End If
    End Sub

    Protected Sub RadGrid_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid.NeedDataSource
        Dim strId As String = Request.QueryString("Proid")
        Dim dv As Data.DataView = ProjectContractFileBLL.GetProjectContractFileInfoByProId(strId)
        Me.RadGrid.DataSource = dv
    End Sub

End Class
