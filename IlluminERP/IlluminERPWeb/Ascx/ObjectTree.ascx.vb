Imports Telerik.Web.UI
Imports DataAccess
Imports Utils
Imports System.Data
Partial Class Ascx_ObjectTree
    Inherits System.Web.UI.UserControl
    Private departmentBLL As New BLL.Base_DepartmentBLL
    Private UserInfoBLL As New BLL.UserInfoBLL
    Private TeamInfoBLL As New BLL.User_TeamInfoBLL




    Private Sub GenerateSourceTree()
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim dv As DataView
        Dim i As Integer

        ds = departmentBLL.GetDepartmentInfo
        If ds Is Nothing Then
            Exit Sub
        Else
            dv = ds.Tables(0).DefaultView
            For i = 0 To dv.Count - 1
                dr = dv.Table.Rows(i)
                Dim node As New RadTreeNode
                node.Text = dr("Department")
                node.Value = dr("Id")

                Me.rtvSourceTree.Nodes.Add(node)
                GenerateSubSourceTree(node, node.Value)
            Next
        End If
    End Sub

    Private Sub GenerateSubSourceTree(ByVal Node As RadTreeNode, ByVal strDepID As String)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dv As DataView
        Dim dr As DataRow
        Dim i As Integer

        ds = UserInfoBLL.GetUserInfoByDepId(strDepID)
        If ds Is Nothing Then
            Exit Sub
        Else
            dv = ds.Tables(0).DefaultView
            For i = 0 To dv.Count - 1
                dr = dv.Table.Rows(i)
                Dim subNode As New RadTreeNode
                subNode.Text = dr("Code") & "," & dr("C_Name")
                subNode.Value = dr("Id")
                If dr("Onduty") = 0 Then

                End If

                Node.Nodes.Add(subNode)

            Next
        End If

        Me.rtvSourceTree.SingleExpandPath = True
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
                Dim node As New RadTreeNode
                node.Text = dr("TeamName")
                node.Value = dr("Id")
                node.Expanded = True
                Me.rtvTarget.Nodes.Add(node)
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
                If dr("ParentId") = 1 Then
                    subNode.Expanded = True
                End If
                Node.Nodes.Add(subNode)
                GenerateSubTeamTree(subNode, subNode.Value)
            Next
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitTrees()
        End If

    End Sub

    Protected Sub InitTrees()
        GenerateSourceTree()
        GenerateTeamTree()
    End Sub

   
End Class
