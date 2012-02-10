Imports Telerik.Web.UI
Imports System.Data

Imports DataAccess.BLL
Imports DataAccess.Model
Imports Utils

Partial Class ViewNews
    Inherits PageBase

    Private NewsBLL As New System_NewsBLL
   
    Public NewsContent As String = String.Empty
    Public NewsBasicInfo As String = String.Empty
    Private newsID As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = Request.QueryString("id")
            If id IsNot Nothing Then
                newsID = Integer.Parse(id)
                SetView()
            End If
        End If
    End Sub

    Private Sub SetView()
        Dim newsEntity As System_NewsInfo
        newsEntity = NewsBLL.GetNewsByID(newsID)
        If newsEntity IsNot Nothing Then
            lblTitle.Text = newsEntity.Title
            NewsContent = newsEntity.Content

            '如果没有 修改过 则显示创建时间 否则 显示修改时间
            If newsEntity.ModifiedTime = DateTime.MinValue Then

                NewsBasicInfo = newsEntity.CreatedTime.ToLongDateString()
            Else
                NewsBasicInfo = newsEntity.ModifiedTime.ToLongDateString()
            End If

            '如果没有 修改过 则显示创建人 否则 显示人时间
            If newsEntity.ModifiedBy = 0 Then
                NewsBasicInfo += "    Publisher: " + newsEntity.CreatedByName
            Else
                NewsBasicInfo += "    Publisher: " + newsEntity.ModifiedByName
            End If

            newsEntity.ReadRate += 1
            NewsBLL.UpdateNews(newsEntity)
        End If
    End Sub

     

End Class
