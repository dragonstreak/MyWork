Imports System.Data

Imports DataAccess.BLL
Imports DataAccess.Model
Imports Utils


Partial Class News
    Inherits OperatePageBase

    Private EntityId As Integer
    Private NewsBLL As New System_NewsBLL
    Private EditEntity As System_NewsInfo
    Private ListItemBLL As New Base_ListItemBLL

    Public FileModeID As Integer = ConstantsUtils.UploadFileModuleEnum.News

    Protected Overrides Sub InitForm()
        If OperateType = "New" Then
            lblTitle.Text = "Add News"
        ElseIf OperateType = "Modify" Then
            lblTitle.Text = "Modify News"
        End If
        Dim listItemFilter As New ListItemQueryFilter
        listItemFilter.Content = String.Empty
        listItemFilter.Type = Convert.ToInt32(ConstantsUtils.ListItemTypeEnum.NewsType)
        Dim dtNewsType As DataTable = ListItemBLL.GetEntityList(listItemFilter)
        PageUtils.BindDropDownList(ddlType, dtNewsType, "ListItemID", "ContentText", 2)
        PageUtils.BindDropDownList(ddlSeverityLevel, EnumTextHelper.GetEnumTextList(GetType(ConstantsUtils.NewsSeverityEnum)), "ID", "Text", 0)
        PageUtils.BindDropDownList(ddlPublish, EnumTextHelper.GetEnumTextList(GetType(ConstantsUtils.YesNoEnum)), "ID", "Text", 0)

    End Sub

    Protected Overrides Sub SetForm()
        If OperateType = "Modify" Then
            EntityId = Page.Request.QueryString("Id")

            EditEntity = NewsBLL.GetNewsByID(EntityId)
            txtTitle.Text = EditEntity.Title
            ckeNewsContent.Text = EditEntity.Content
            If EditEntity.NewsType > 0 Then
                PageUtils.InitDropDownListSelectedIndex(ddlType, EditEntity.NewsType.ToString())
            End If
            If EditEntity.SeverityLevel > 0 Then
                PageUtils.InitDropDownListSelectedIndex(ddlSeverityLevel, EditEntity.SeverityLevel.ToString())
            End If
            PageUtils.InitDropDownListSelectedIndex(ddlPublish, EditEntity.Published.ToString())
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not CheckData() Then
            Return
        End If

        SetEntity()

        Dim operatedResult As Boolean

        If OperateType = "New" Then
            operatedResult = NewsBLL.AddNews(EditEntity)
        ElseIf OperateType = "Modify" Then
            operatedResult = NewsBLL.UpdateNews(EditEntity)
        End If

        'if operate success, then should return,else should remind user that operate failed.
        If operatedResult Then
            'remind
            Response.Write("<script language=javascript>")
            Response.Write("alert('success!');window.returnValue='success';window.close();")
            Response.Write("</script>")
            'close current page
        Else
            'remind
            Response.Write("<script language=javascript>")
            Response.Write("alert('failed!');window.returnValue='failed';window.close();")
            Response.Write("</script>")
            'close current page
        End If

    End Sub

    Private Sub SetEntity()
        Dim fileIds As String = String.Empty
        If OperateType = "New" Then
            EditEntity = New System_NewsInfo
            fileIds = Request.Form("uploadedList")
            If fileIds.Trim().Length > 0 Then
                EditEntity.FileList = New List(Of Integer)
                For Each file As String In fileIds.Split(","c)
                    EditEntity.FileList.Add(Integer.Parse(file))
                Next
            End If
            If CurrentLoginUser IsNot Nothing Then
                EditEntity.CreatedBy = CurrentLoginUser.ID
            End If
            EditEntity.CreatedTime = DateTime.Now
        Else
            EntityId = Page.Request.QueryString("Id")
            EditEntity = NewsBLL.GetNewsByID(EntityId)
            fileIds = Request.Form("uploadedList")
            If fileIds.Trim().Length > 0 Then
                If EditEntity.FileList Is Nothing Then
                    EditEntity.FileList = New List(Of Integer)
                End If
                For Each file As String In fileIds.Split(","c)
                    EditEntity.FileList.Add(Integer.Parse(file))
                Next
            End If
            If CurrentLoginUser IsNot Nothing Then
                EditEntity.ModifiedBy = CurrentLoginUser.ID
            End If
            EditEntity.ModifiedTime = DateTime.Now
        End If
        'if selected a news type and the type is not null, then save it to DB
        If ddlType.SelectedIndex > 0 Then
            EditEntity.NewsType = Convert.ToInt32(ddlType.SelectedValue)
        End If

        EditEntity.Published = Convert.ToInt32(ddlPublish.SelectedValue)
        EditEntity.SeverityLevel = Convert.ToInt32(ddlSeverityLevel.SelectedValue)

        EditEntity.Title = txtTitle.Text
        EditEntity.Content = ckeNewsContent.Text

    End Sub

    Private Function CheckData() As Boolean

        If txtTitle.Text.Trim().Length = 0 Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('News Title can not be empty！');")
            Response.Write("</script>")
            Return False
        End If

        Return True
    End Function

End Class
