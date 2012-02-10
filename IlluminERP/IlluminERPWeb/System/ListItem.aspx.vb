Imports System.Data

Imports Telerik.Web.UI
Imports Utils
Imports DataAccess.BLL
Imports DataAccess.Model

Partial Class ListItem
    Inherits OperatePageBase

    Private EntityId As Integer
    Private ListItemBLL As New Base_ListItemBLL
    Private EditEntity As Base_ListItem

    Protected Overrides Sub InitForm()
        If OperateType = "New" Then
            lblTitle.Text = "Add Common Category"
        ElseIf OperateType = "Modify" Then
            lblTitle.Text = "Modify Common Category"
        End If
        PageUtils.BindDropDownList(ddlType, EnumTextHelper.GetEnumTextList(GetType(ConstantsUtils.ListItemTypeEnum)), "ID", "TEXT", 0)
        PageUtils.BindDropDownList(ddlParent, Nothing, "ID", "TEXT", 2)
    End Sub

    Protected Overrides Sub SetForm()
        If OperateType = "Modify" Then
            EntityId = Page.Request.QueryString("Id")

            EditEntity = ListItemBLL.GetEntityByID(EntityId)
            txtName.Text = EditEntity.ContentText
            PageUtils.InitDropDownListSelectedIndex(ddlType, EditEntity.Type.ToString())
            ddlType.Enabled = False
            Dim filter As New ListItemQueryFilter
            filter.Content = String.Empty
            filter.Type = EditEntity.Type
            Dim dtListItem As DataTable = ListItemBLL.GetEntityList(filter)
            Dim var = From item In dtListItem.AsEnumerable
                      Where Convert.ToInt32(item("ListItemID")) <> EditEntity.ListItemID
                      Select item

            Dim dvParentCandidate As DataView = var.AsDataView
            If dvParentCandidate.Count > 0 Then
                PageUtils.BindDropDownList(ddlParent, dvParentCandidate, "ListItemID", "ContentText", 2)

                If EditEntity.ParentID > 0 Then
                    PageUtils.InitDropDownListSelectedIndex(ddlParent, EditEntity.ParentID.ToString())
                End If
            End If

        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'check data
        If Not CheckData() Then
            Return
        End If
        'set RoleInfo object
        SetEditItemInfo()
        Try

            Dim operatedResult As Boolean
            If OperateType Is Nothing OrElse OperateType = "New" Then
                'check if role exists
                Dim isExists As String = ListItemBLL.IsEntityExist(EditEntity)
                If isExists Then
                    Response.Write("<script language=javascript>")
                    Response.Write(String.Format("alert('{0} has existed!');", EditEntity.ContentText))
                    Response.Write("</script>")
                    Exit Sub
                End If
                operatedResult = ListItemBLL.AddEntity(EditEntity)
            End If
            If OperateType = "Modify" Then
                operatedResult = ListItemBLL.UpdateEntity(EditEntity)
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CheckData() As Boolean
        If txtName.Text.Trim().Length = 0 Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Category Name can not be empty£¡');")
            Response.Write("</script>")
            Return False
        End If

        Return True
    End Function

    Private Sub SetEditItemInfo()
        If OperateType = "New" Then
            EditEntity = New Base_ListItem
        ElseIf OperateType = "Modify" Then
            EntityId = Page.Request.QueryString("Id")

            EditEntity = ListItemBLL.GetEntityByID(EntityId)
        End If
        EditEntity.ContentText = txtName.Text.Trim()
        EditEntity.Type = Convert.ToInt32(ddlType.SelectedValue)
        If ddlParent.Items IsNot Nothing AndAlso ddlParent.Items.Count > 0 AndAlso ddlParent.SelectedIndex > 0 Then
            EditEntity.ParentID = Convert.ToInt32(ddlParent.SelectedValue)
        End If
        EditEntity.IsDeleted = 0

    End Sub

    Protected Sub ddlType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        Dim filter As New ListItemQueryFilter
        filter.Content = String.Empty
        filter.Type = Convert.ToInt32(ddlType.SelectedValue)
        Dim dtListItem As DataTable = ListItemBLL.GetEntityList(filter)
        PageUtils.BindDropDownList(ddlParent, dtListItem, "ListItemID", "ContentText", 2)
    End Sub
End Class
