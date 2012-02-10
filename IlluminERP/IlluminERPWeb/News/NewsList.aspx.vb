Imports Telerik.Web.UI
Imports System.Data

Imports DataAccess.BLL
Imports DataAccess.Model
Imports Utils

Partial Class NewsList
    Inherits PageBase

    Private NewsBLL As New System_NewsBLL
    Public dvNews As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim filter As New NewsQueryFilter
        filter.ResultAmountLimit = 20
        filter.PublishedType = 1
        Dim dtNews As DataTable = NewsBLL.GetEntityList(filter)
        If dtNews IsNot Nothing Then
            dvNews = dtNews.DefaultView
        End If
        'HLMoreNews.NavigateUrl = "../News/"
    End Sub
End Class
