Imports System.Data

Imports Telerik.Web.UI
Imports Utils
Imports DataAccess.BLL
Imports DataAccess.Model

Partial Class Role
    Inherits OperatePageBase

    Private PermissionBLL As New System_PermissionBLL
    Private RoleBLL As New User_RoleBLL
    Private Current_Role As User_Role

    Protected Overrides Sub InitForm()
        If OperateType = "New" Then
            Me.lblTitle.Text = "Add Role"
        ElseIf OperateType = "Modify" Then
            Me.lblTitle.Text = "Update Role"
        End If

        PageUtils.BindDropDownList(ddlStatus, EnumTextHelper.GetEnumTextList(GetType(ConstantsUtils.IsEnableEnum)), "ID", "TEXT", 0)
        PageUtils.InitDropDownListSelectedIndex(ddlStatus, Convert.ToInt32(ConstantsUtils.IsEnableEnum.Enable).ToString())
        InitPermissionTree()
    End Sub

    Protected Overrides Sub SetForm()
        If OperateType = "Modify" Then
            Dim RoleID As Integer = Convert.ToInt32(Page.Request.QueryString("id"))
            Current_Role = RoleBLL.GetRoleInfoById(Convert.ToInt32(RoleID))
            txtName.Text = Current_Role.RoleName
            PageUtils.InitDropDownListSelectedIndex(ddlStatus, Current_Role.Status.ToString)
            txtRemark.Text = Current_Role.Remark
            treePermission.CheckChildNodes = False
            For Each node As RadTreeNode In treePermission.Nodes
                SetTreeCheckBox(node, Current_Role.PermissionIDs)
            Next
            treePermission.CheckChildNodes = True
        End If

    End Sub

    Private Sub SetTreeCheckBox(ByVal node As RadTreeNode, ByVal valueList As List(Of Integer))
        If valueList.Contains(node.Value) Then
            node.Checked = True
        End If

        For Each child As RadTreeNode In node.Nodes
            SetTreeCheckBox(child, valueList)
        Next
    End Sub

    Private Sub InitPermissionTree()
        Dim dsPermission As DataSet
        dsPermission = PermissionBLL.GetAllPermissions()
        If dsPermission Is Nothing OrElse dsPermission.Tables(0) Is Nothing Then
            Exit Sub
        End If

        treePermission.Nodes.Add(New RadTreeNode(ConstantsUtils.PermissionRootName, ConstantsUtils.PermissionRootValue))
        AddPermissionNode(treePermission.Nodes(0), dsPermission.Tables(0))
        treePermission.ExpandAllNodes()
    End Sub

    Private Sub AddPermissionNode(ByVal node As RadTreeNode, ByVal dtPermission As DataTable)
        Dim dvPermission As DataView
        Dim query = From permission In dtPermission.AsEnumerable() _
                    Where permission.Field(Of Integer)("ParentID") = Convert.ToInt32(node.Value) _
                          AndAlso (permission.Field(Of Integer)("Kind") = ConstantsUtils.PermissionKindEnum.Menu _
                          OrElse permission.Field(Of Integer)("Kind") = ConstantsUtils.PermissionKindEnum.FunctionPoint) _
                    Order By permission.Field(Of Integer)("Sort") _
                    Select permission

        dvPermission = query.AsDataView()
        If dvPermission Is Nothing OrElse dvPermission.Count < 1 Then
            Exit Sub
        End If

        For Each dvrPer As DataRowView In dvPermission
            node.Nodes.Add(New RadTreeNode(dvrPer("Name"), dvrPer("ID")))
        Next

        For Each childNode As RadTreeNode In node.Nodes
            AddPermissionNode(childNode, dtPermission)
        Next
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
                Dim isExists As String = RoleBLL.IsRoleExist(Current_Role.RoleName)
                If isExists Then
                    Response.Write("<script language=javascript>")
                    Response.Write(String.Format("alert('{0} has existed!');", Current_Role.RoleName))
                    Response.Write("</script>")
                    Exit Sub
                End If
                operatedResult = RoleBLL.AddRoleInfo(Current_Role)
            End If
            If OperateType = "Modify" Then
                operatedResult = RoleBLL.ModifyRoleById(Current_Role)
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
        Return True
    End Function

    Private Sub SetEditItemInfo()
        Current_Role = New User_Role

        If OperateType = "Modify" Then
            Current_Role.ID = Convert.ToInt32(Page.Request.QueryString("id"))
        End If

        Current_Role.RoleName = txtName.Text.Trim()
        Current_Role.Status = Convert.ToInt32(ddlStatus.SelectedValue)
        Current_Role.Remark = txtRemark.Text.Trim()
        For Each node As RadTreeNode In treePermission.CheckedNodes
            If node.Value <> ConstantsUtils.PermissionRootValue Then
                Current_Role.PermissionIDs.Add(node.Value)
            End If

        Next

    End Sub

End Class
