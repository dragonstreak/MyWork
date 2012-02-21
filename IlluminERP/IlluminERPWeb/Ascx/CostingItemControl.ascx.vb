
Imports DataAccess.Model
Imports Aspose.Cells
Partial Class Ascx_CostingItemControl
    Inherits System.Web.UI.UserControl

    Private _costDataSource As List(Of PMS_OperationCost)
    Public Property CostDataSource() As List(Of PMS_OperationCost)
        Set(ByVal value As List(Of PMS_OperationCost))
            _costDataSource = value
        End Set
        Get
            Return _costDataSource
        End Get
    End Property

    Public Overrides Sub DataBind()
        MyBase.DataBind()
        Me.RadGrid1.DataSource = CostDataSource
        Me.RadGrid1.DataBind()
    End Sub
    Public Sub ControlByCostType(ByVal costType As String, ByVal tabType As String, ByVal percentage As Decimal)
        divEmail.Visible = False
        If costType = "Actual" Then
            Me.RadGrid1.MasterTableView.Columns(4).Visible = True
            Me.RadGrid1.MasterTableView.Columns(5).Visible = True
            If tabType = "Summary" And percentage > 5 Then
                divEmail.Visible = True
            End If
        End If
    End Sub
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
    End Sub
    ''' <summary>
    ''' Tony
    ''' This mehod is used to email to partner
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnEmailPartner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmailPartner.Click
       
    End Sub
End Class
