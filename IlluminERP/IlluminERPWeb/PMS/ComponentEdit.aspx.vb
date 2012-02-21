Imports System.Xml
Imports DataAccess
Imports System.Data
Imports DataAccess.Model
Imports DataAccess.BLL
Imports Telerik.Web.UI
Imports System.IO

Partial Class PMS_ComponentEdit
    Inherits OperatePageBase
    Private PricingSampleCityBLL As New BLL.PMS_PricingSampleCityInfoBLL
    Private MethodologyBLL As New PMS_MethodologyBLL
    Private ComponentBLL As New PMS_ComponentBLL
    Private CityCoverageBLL As New PMS_CityCoverageBLL
    Private CriterialBLL As New PMS_RespondentCriteriaBLL
    Private StageBLL As New PMS_ProposalStageBLL
    Private TimingBLL As New PMS_TimingBLL
    Private QuotationBLL As New PMS_QuotationBLL
    Private CostingFileBLL As New PMS_ComponentCostingFileBLL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            'GetStageList()
            'RefreshStageDiv()


        End If

    End Sub
    Private Sub InitMethodology()

    End Sub
    Private Sub InitCombobox()

    End Sub
    Protected Overrides Sub InitForm()
        MyBase.InitForm()
        Dim ds As DataSet
        Dim dsMethodology As DataSet
        ''Init methodology
        dsMethodology = MethodologyBLL.GetMethodologyTypeDataSet()
        ViewState("dsMethodologyType") = dsMethodology
        Utils.PageUtils.BindDropDownList(Me.cbMethdology, dsMethodology.Tables(0), "id", "MethodologyType", 0)
        hiddenMethdologyType.Value = Me.cbMethdology.Items(0).Value
        Dim methodologyTypeTable As DataTable = GetMethodologyTypeView(CInt(Me.cbMethdology.Items(0).Value))
        Utils.PageUtils.BindDropDownList(Me.cbMethdologyValue, methodologyTypeTable, "id", "Methodology", 0)
        If methodologyTypeTable.Rows.Count > 0 Then
            hiddenMethdology.Value = Me.cbMethdologyValue.SelectedItem.Value
        End If



        ''Init city 

        ds = PricingSampleCityBLL.GetPricingSampleCityInfoByType(1)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.cbDistrict, ds, "id", "CityName_CN", 2)
            ViewState("dsDistrict") = ds
        End If

        ds = PricingSampleCityBLL.GetPricingSampleCityInfoByType(2)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.cbProvince, ds, "id", "CityName_CN", 2)
            ViewState("dsProvince") = ds
        End If

        ds = PricingSampleCityBLL.GetPricingSampleCityInfoByType(3)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.cbCity, ds, "id", "CityName_CN", 2)
            ViewState("dsCity") = ds
        End If


    End Sub
    Private Function GetMethodologyTypeView(ByVal methodologyTypeId As Integer) As DataTable
        Dim dsMethodology As DataSet = CType(ViewState("dsMethodologyType"), DataSet)
        If dsMethodology Is Nothing Then
            Return Nothing
        End If
        If dsMethodology.Tables.Count < 2 Then
            Return Nothing
        End If
        dsMethodology.Tables(1).DefaultView.RowFilter = "MethodologyType=" + methodologyTypeId.ToString()
        Return dsMethodology.Tables(1).DefaultView.ToTable().Copy()
    End Function
    ''' <summary>
    ''' This method is used to set form 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub SetForm()
        MyBase.SetForm()
        'get user id from url
        Dim id As String = Page.Request.QueryString("id")
        Dim stageId As String = Page.Request.QueryString("StageId")
        Dim stage As PMS_ProposalStage = StageBLL.GetEntityById(stageId)

        Me.labelStage.Text = stage.StageName
        Dim component As New PMS_Component
        'this is for new 
        component.id = -1
        
        If OperateType = "Modify" Then
            'Just for test
            'id = 1
            component = ComponentBLL.GetComponentById(id)
            Me.txtKeyWord.Text = component.KeyWords
            Me.txtComponentName.Text = component.ComponentName
            Me.reSampleSize.Content = component.SampleSize
            '  Me.reSampleDesign.Content = component.SampleDesign
            'Set the combobox
            Me.cbMethdology.SelectedValue = component.MethdologyType
            If (Me.cbMethdologyValue.Items.Count > 0) Then
                Me.cbMethdologyValue.SelectedValue = component.Methodology
            End If


        Else
            'methodology id should be the first item of the mehtodology dropdown list
            Dim selectedMethodologyId As String = ""
            If (Me.cbMethdologyValue.Items.Count > 0) Then
                selectedMethodologyId = Me.cbMethdologyValue.SelectedValue
            End If
            'when user adding new component, need init the init component task by methodology
            Dim timingTaskList As List(Of PMS_Timing) = TimingBLL.GetInitTimingListByMethodology(selectedMethodologyId)
            Dim quotationTaskList As List(Of PMS_Quotation) = QuotationBLL.GetInitQuotationListByMethodology(selectedMethodologyId)
            component.TimingTaskList = timingTaskList
            component.QuotationTaskList = quotationTaskList
        End If
        

        ViewState("Component") = component
        
        BindCriteria()
    End Sub
    Private Sub BindCriteria()
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)


        Me.lbCriteria.DataSource = component.CriteriaList
        Me.lbCriteria.DataBind()
    End Sub


    Protected Sub cbMethdology_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMethdology.SelectedIndexChanged
        

    End Sub
    Protected Sub cbDistrict_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDistrict.SelectedIndexChanged
        Dim ds As DataSet

        If Me.cbDistrict.SelectedValue > 0 Then
            ds = PricingSampleCityBLL.GetPricingSampleCityInfoByParentId(Me.cbDistrict.SelectedValue)
            If Not ds Is Nothing Then
                Utils.PageUtils.BindDropDownList(Me.cbProvince, ds, "id", "CityName_CN", 2)
            End If
        End If
    End Sub
    Protected Sub cbProvince_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProvince.SelectedIndexChanged
        Dim ds As DataSet

        If Me.cbProvince.SelectedValue > 0 Then
            ds = PricingSampleCityBLL.GetPricingSampleCityInfoByParentId(Me.cbProvince.SelectedValue)
            If Not ds Is Nothing Then
                Utils.PageUtils.BindDropDownList(Me.cbCity, ds, "id", "CityName_CN", 2)
            End If
        End If
    End Sub

  

    Protected Sub btnSaveComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveComponent.Click

        If Me.txtComponentName.Text = "" Then
            radajax.Alert("Please input component name!")
            Exit Sub
        End If
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        'get the information
        component.StageId = Page.Request.QueryString("StageId")
        component.MethdologyType = Me.cbMethdology.SelectedValue
        component.MethodologyDescription = Me.txtComponentName.Text.Trim & "-" & Me.cbMethdologyValue.SelectedItem.Text
        If (Me.cbMethdologyValue.Items.Count > 0) Then
            component.Methodology = Me.cbMethdologyValue.SelectedValue
        End If
        component.KeyWords = Me.txtKeyWord.Text.Trim
        component.ComponentName = Me.txtComponentName.Text.Trim
        '  component.SampleDesign = Me.reSampleDesign.Content
        component.SampleSize = Me.reSampleSize.Content
        If OperateType = "Modify" Then
            'component.UpdatedBy = CType(Session("LoginUserInfo"), User_UserInfo).ID
            component.UpdatedBy = CurrentLoginUser.ID
            component.UpdatedDate = DateTime.Now
        Else
            'component.CreatedBy = CType(Session("LoginUserInfo"), User_UserInfo).ID
            component.CreatedBy = CurrentLoginUser.ID
            component.CreatedDate = DateTime.Now
            component.UpdatedDate = DateTime.MinValue
            Dim jobNumber As String = Page.Request.QueryString("JobNumber")
            component.Jobnumber = jobNumber
        End If

        ComponentBLL.SaveComponent(component)
    End Sub

   

    Protected Sub rgStageList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgStageList.NeedDataSource
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        rgStageList.DataSource = component.CityCovergyList
    End Sub
    ''' <summary>
    ''' This is the command when user click delete.
    ''' </summary>
    ''' <param name="source">Pass the event source:datagrid.</param>
    ''' <param name="e">Pass the event args.</param>
    ''' <remarks></remarks>
    Protected Sub rgStageList_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgStageList.DeleteCommand
        Dim rowIndex As Integer = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).ItemIndex
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        Dim cityCoverage As PMS_CityCoverage = component.CityCovergyList(rowIndex)
        component.CityCovergyList.RemoveAt(rowIndex)
        If (cityCoverage.id > 0) Then
            CityCoverageBLL.DeleteEntity(cityCoverage.id)
        End If
        rgStageList.Rebind()
    End Sub
    Protected Sub lbCriteria_Deleted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles lbCriteria.Deleted
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        Dim selectedCriteria As New PMS_RespondentCriteria
        Dim selectValue As String = e.Items(0).Value

        For Each criteria As PMS_RespondentCriteria In component.CriteriaList
            If (criteria.Criteria = selectValue) Then
                selectedCriteria = criteria
                Exit For
            End If

        Next
        If selectedCriteria Is Nothing Then
            Return
        End If
        component.CriteriaList.Remove(selectedCriteria)
        If (selectedCriteria.id > 0) Then
            CriterialBLL.DeleteEntity(selectedCriteria.id)
        End If
    End Sub

    Protected Sub rgStageList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles rgStageList.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim id As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("City").Text
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("City").Text = PricingSampleCityBLL.GetPricingSampleCityInfoById(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("City").Text).CityName_CN


        End If
    End Sub

    Protected Sub rgQuotationTask_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgQuotationTask.NeedDataSource
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        rgQuotationTask.DataSource = component.QuotationTaskList
    End Sub
    Protected Sub rgTimingTask_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgTimingTask.NeedDataSource
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        rgTimingTask.DataSource = component.TimingTaskList
    End Sub
   
    Protected Sub btnAddTiming_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddTiming.Click
        Dim taskName As String = Me.txtTimingName.Text
        If String.IsNullOrEmpty(taskName) Then
            Return
        End If
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        For Each task As PMS_Timing In component.TimingTaskList
            If task.Task = taskName Then
                'need inform user that this task is existed
                Exit Sub
            End If
        Next
        Dim timingSelfTask As New PMS_Timing
        timingSelfTask.Id = -1
        timingSelfTask.Task = taskName
        timingSelfTask.componentId = component.id
        timingSelfTask.Jobnumber = component.Jobnumber
        timingSelfTask.StageId = component.StageId
        timingSelfTask.Status = "Active"
        timingSelfTask.TaskType = TaskType.SelfDefinedTask.ToString
        component.TimingTaskList.Add(timingSelfTask)
        Me.rgTimingTask.Rebind()
    End Sub
    Protected Sub btnAddQuotation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddQuotation.Click
        Dim taskName As String = Me.txtQuotationName.Text
        If String.IsNullOrEmpty(taskName) Then
            Return
        End If
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        For Each task As PMS_Quotation In component.QuotationTaskList
           
            If task.Task = taskName Then
                'need inform user that this task is existed
                Exit Sub
            End If
        Next
        Dim quotationSelfTask As New PMS_Quotation
        quotationSelfTask.Id = -1
        quotationSelfTask.Task = taskName
        quotationSelfTask.componentId = component.id
        quotationSelfTask.componentId = component.id
        quotationSelfTask.Jobnumber = component.Jobnumber
        quotationSelfTask.StageId = component.StageId
        quotationSelfTask.Status = "Active"
        quotationSelfTask.QuotationType = TaskType.SelfDefinedTask.ToString
        component.QuotationTaskList.Add(quotationSelfTask)
        Me.rgQuotationTask.Rebind()
    End Sub

    Private Sub ClearTask()
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        TimingBLL.SetTimingListStatus(component.TimingTaskList, TaskStatus.Deleted.ToString())
        QuotationBLL.SetQuotationListStatus(component.QuotationTaskList, TaskStatus.Deleted.ToString())
        component.TimingTaskList.Clear()
        component.QuotationTaskList.Clear()
    End Sub

    Private Sub RefreshTask()
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        'second init the timing and quotation by methodology
        If (Me.cbMethdologyValue.Items.Count > 0) Then
            Dim selectedMethodologyId As String = Me.cbMethdologyValue.SelectedValue
            'when user adding new component, need init the init component task by methodology
            Dim timingTaskList As List(Of PMS_Timing) = TimingBLL.GetInitTimingListByMethodology(selectedMethodologyId)
            Dim quotationTaskList As List(Of PMS_Quotation) = QuotationBLL.GetInitQuotationListByMethodology(selectedMethodologyId)
            component.TimingTaskList = timingTaskList
            component.QuotationTaskList = quotationTaskList
        End If
        Me.rgTimingTask.Rebind()
        Me.rgQuotationTask.Rebind()
    End Sub
   
    Protected Sub btnMethodologyChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMethodologyChange.Click
        'first remove all the existing timing and quotation
        ClearTask()
        RefreshTask()
        
    End Sub

    Protected Sub btnMethodologyTypeChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMethodologyTypeChange.Click
        ClearTask()

        'need event for methology type changing
        Dim methodologyTypeTable As DataTable = GetMethodologyTypeView(CInt(Me.cbMethdology.SelectedItem.Value))
        If methodologyTypeTable Is Nothing Then
            Me.cbMethdology.Items.Clear()
            Return
        End If
        Utils.PageUtils.BindDropDownList(Me.cbMethdologyValue, methodologyTypeTable, "id", "Methodology", 0)
         RefreshTask()
    End Sub
    ''' <summary>
    ''' This is the command when user click delete.
    ''' </summary>
    ''' <param name="source">Pass the event source:datagrid.</param>
    ''' <param name="e">Pass the event args.</param>
    ''' <remarks></remarks>
    Protected Sub rgQuotationTask_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgQuotationTask.DeleteCommand
        Dim rowIndex As Integer = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).ItemIndex
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        Dim quotation As PMS_Quotation = component.QuotationTaskList(rowIndex)
        component.QuotationTaskList.RemoveAt(rowIndex)
        If (quotation.Id > 0) Then
            QuotationBLL.DeleteEntity(quotation.Id)
        End If
        rgQuotationTask.Rebind()
    End Sub
    Protected Sub rgTimingTask_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgTimingTask.DeleteCommand
        Dim rowIndex As Integer = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).ItemIndex
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        Dim timing As PMS_Timing = component.TimingTaskList(rowIndex)
        component.TimingTaskList.RemoveAt(rowIndex)
        If (timing.Id > 0) Then
            TimingBLL.DeleteEntity(timing.Id)
        End If
        rgTimingTask.Rebind()
    End Sub

   
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("StageForm.aspx?JobNumber=" + Page.Request.QueryString("JobNumber"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("ProposalQuotation.aspx?JobNumber=" + Page.Request.QueryString("JobNumber"))
    End Sub

    Protected Sub btnAddCriteria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCriteria.Click
        Dim criteria As New PMS_RespondentCriteria
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        criteria.ComponentId = component.id
        criteria.Criteria = Me.txtAddCriteria.Text.Trim
        component.CriteriaList.Add(criteria)
        BindCriteria()
    End Sub

    Protected Sub btnAddCityCoverage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCityCoverage.Click
        Dim cityCoverage As New PMS_CityCoverage
        Dim component As PMS_Component = CType(ViewState("Component"), PMS_Component)
        cityCoverage.ComponentId = component.id
        cityCoverage.District = Me.cbDistrict.SelectedValue
        cityCoverage.Province = Me.cbProvince.SelectedValue
        cityCoverage.City = Me.cbCity.SelectedValue
        cityCoverage.CitySize = Decimal.Parse(Me.txtCitySize.Text.Trim)
        cityCoverage.AddedSize = Decimal.Parse(Me.txtAddedSize.Text.Trim)
        cityCoverage.IncidenceRate = Decimal.Parse(Me.txtIncidenceRate.Text.Trim)
        component.CityCovergyList.Add(cityCoverage)
        rgStageList.Rebind()
    End Sub
End Class
