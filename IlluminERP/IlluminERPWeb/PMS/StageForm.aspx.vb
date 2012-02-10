Imports DataAccess.BLL
Imports DataAccess.Model
Imports DataAccess
Imports Telerik.Web.UI

Partial Class PMS_StageForm
    Inherits System.Web.UI.Page
    Private stageBLL As New PMS_ProposalStageBLL
    Private componentBLL As New PMS_ComponentBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim needSetImage As Boolean = True

        If Not IsPostBack Then
            'GetStageList()
            'RefreshStageDiv()

            Dim componentList As New List(Of PMS_Component)
            rgComponentList.DataSource = componentList
            rgComponentList.DataBind()
            needSetImage = False
            If Page.Request.QueryString.GetValues("JobNumber") IsNot Nothing Then
                Me.tbJobNumber.Text = Page.Request.QueryString("JobNumber")
                GetStageList()
                RefreshStageDiv()
            End If
        End If
        'btnAdd.Disabled = True
        If needSetImage = True Then

        End If

    End Sub

    Private Sub GetStageList()
        Dim jobNumber As String = Me.tbJobNumber.Text.Trim
        Dim stageList As List(Of PMS_ProposalStage)
        stageList = stageBLL.GetStageByProposalId(jobNumber)
        If (stageList.Count > 0) Then
            'btnAdd.Disabled = False
            hiddenCurrentProposal.Value = stageList(0).Jobnumber
            hiddenMaxStageId.Value = stageList.Count

        Else
            'btnAdd.Disabled = True
            'Tony
            'need add check if job number exists or not.
            'if job number exists, then enable the btnAddStage
            'else disable btnAddStage
            hiddenCurrentProposal.Value = jobNumber
            hiddenMaxStageId.Value = 0
        End If
        ViewState("StageList") = stageList
    End Sub


    Private Sub RefreshStageDiv()
        Dim stageList As List(Of PMS_ProposalStage)
        stageList = DirectCast(ViewState("StageList"), List(Of PMS_ProposalStage))
        Dim divStr As String = ""
        Dim index As Integer = 0
        Dim maxNumber As Integer = 0
        For Each stage As PMS_ProposalStage In stageList
            divStr += "<div onclick=javascript:changeStage(this,'" + stage.StageNumber.ToString + "'," + index.ToString + "," + stage.Id.ToString + ")>"
            divStr += "<table class='tableDiv'><tr><td>"
            divStr += "Stage" + stage.StageNumber.ToString + "<br/>"
            divStr += stage.StageName
            divStr += "</td></tr></table>"
            divStr += "</div>"
            index = index + 1
            If stage.StageNumber > maxNumber Then
                maxNumber = stage.StageNumber
            End If
        Next
        stageDiv.InnerHtml = divStr
        Me.hiddenMaxStageId.Value = maxNumber
    End Sub

   
    Protected Sub BtnSearchComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchComponent.Click
        Dim stageId As String = Me.hiddenCurrentStageId.Value
        Dim componentList As List(Of PMS_Component) = componentBLL.GetStageComponentList(stageId)
        Dim Stageinfo As New Model.PMS_ProposalStage
       
        rgComponentList.DataSource = componentList
        rgComponentList.DataBind()
        'Response.Write("<script>SetStageImage(0)</script>")
        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "SetImage", "<script>SetStageImage(0)</script>")
        Dim index As String = Me.hiddenCurrentStageIndex.Value
        ClientScript.RegisterStartupScript(Me.GetType(), "SetImage", "<script>SetStageImage(" + index + ")</script>")
        Stageinfo = stageBLL.GetEntityById(stageId)
        Me.lblDescription.Text = Stageinfo.Description
    End Sub

    Protected Sub btnDeleteStage_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDeleteStage.Click
        Dim stageId As String = Me.hiddenCurrentStageId.Value
        stageBLL.DeleteEntity(stageId)
        GetStageList()
        RefreshStageDiv()
    End Sub


    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        GetStageList()
        RefreshStageDiv()
    End Sub

End Class
