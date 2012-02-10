Imports System

Partial Class Index_Top
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblCurrentDate.Text = Date.Now.ToString(Utils.CommonUtils.DateFormatString, System.Globalization.DateTimeFormatInfo.InvariantInfo)
    End Sub
End Class
