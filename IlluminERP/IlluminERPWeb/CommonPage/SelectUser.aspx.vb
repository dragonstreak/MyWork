Imports System
Imports System.Data
Imports DataAccess
Imports Telerik.Web.UI

Partial Class CommonPage_SelectUser
    Inherits System.Web.UI.Page
    Private departmentBLL As New BLL.Base_DepartmentBLL
    Private UserInfoBLL As New BLL.UserInfoBLL
    Private TeamInfoBLL As New BLL.User_TeamInfoBLL
    Private TeamUserBLL As New BLL.User_UserTeamBLL
    Private dt As New DataTable
    Private colUser As New Collection

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim objError As Exception
        objError = Server.GetLastError.GetBaseException
        If clsWarningHandle.GetPageError(objError) = True Then
            Server.ClearError()
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Not Session("ProposalUser") Is Nothing Then
                colUser = Session("ProposalUser")
            End If
            Call GenerateTeamTree()
          
        End If
    End Sub

    Private Sub GenerateTeamTree()
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim dv As DataView
        Dim i As Integer

        '根节点

     
        ds = TeamInfoBLL.GetTeamInfoByParentId(0)
        If ds Is Nothing Then
            Exit Sub
        Else
            dv = ds.Tables(0).DefaultView
            For i = 0 To dv.Count - 1
                dr = dv.Table.Rows(i)
                Dim node As New RadTreeNode()
                node.Text = dr("TeamName")
                node.Value = dr("Id")
                node.ToolTip = "Team"
                node.Expanded = True
                Me.radTeamUserTree.Nodes.Add(node)
                GenerateSubTeamTree(node, node.Value)

            Next
        End If
    End Sub


    Private Sub GenerateSubTeamTree(ByVal Node As RadTreeNode, ByVal strParentID As String)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dv As DataView
        Dim dr As DataRow
        Dim i As Integer

        ds = TeamInfoBLL.GetTeamInfoByParentId(strParentID)
        If ds Is Nothing Then
            Exit Sub
        Else
            dv = ds.Tables(0).DefaultView
            For i = 0 To dv.Count - 1
                dr = dv.Table.Rows(i)
                Dim subNode As New RadTreeNode
                subNode.Text = dr("TeamName")
                subNode.Value = dr("Id")
                subNode.ToolTip = "Team"
                If dr("ParentId") = 1 Then
                    subNode.Expanded = True
                End If

                Node.Nodes.Add(subNode)
                GenerateTeamUser(subNode, subNode.Value)
                GenerateSubTeamTree(subNode, subNode.Value)
            Next
        End If

    End Sub


    Private Sub GenerateTeamUser(ByVal Node As RadTreeNode, ByVal strTeamID As String)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dv As DataView
        Dim dr As DataRow
        Dim i As Integer
        Dim strId As String

        ds = TeamUserBLL.GetTeamInfoByTeamId(strTeamID)
        If ds Is Nothing Then
            Exit Sub
        Else
            dv = ds.Tables(0).DefaultView
            For i = 0 To dv.Count - 1
                dr = dv.Table.Rows(i)
                Dim subNode As New RadTreeNode

              
                subNode.Text = dr("E_Name")
                subNode.Value = dr("UserID")
                subNode.ToolTip = "User"
                If colUser.Count > 0 Then
                    For Each strId In colUser
                        If strId = dr("UserID") Then
                            subNode.Checked = True
                        End If
                    Next

                End If
                Node.Nodes.Add(subNode)

            Next
        End If

    End Sub

 
  
    Private Sub UpdateTreeNodes(ByVal node As RadTreeNode, ByVal IsChecked As Boolean)

        Dim i As Integer
        For i = 0 To node.Nodes.Count - 1
            If IsChecked Then
                node.Nodes(i).Checked = True
            Else
                node.Nodes(i).Checked = False
            End If
            If node.Nodes(i).Nodes.Count > 0 Then
                UpdateTreeNodes(node.Nodes(i), IsChecked)
            End If
        Next i
    End Sub 'UpdateTreeNodes


    Protected Sub RadTeamUesrTree_NodeCheck(ByVal o As Object, ByVal e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles radTeamUserTree.NodeCheck
        Dim node As RadTreeNode = e.Node
        UpdateTreeNodes(node, node.Checked)
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim Node As New RadTreeNode

        If Me.radTeamUserTree.CheckedNodes.Count > 0 Then
            For Each Node In Me.radTeamUserTree.CheckedNodes
                If Node.ToolTip = "User" Then
                    If Node.Checked = True Then
                        colUser.Add(Node.Value)
                    End If
                End If

            Next
            Session("ProposalUser") = colUser
        End If
        colUser = Nothing
        Me.Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>window.close();</script>")
    End Sub

   
End Class
