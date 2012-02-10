Imports DataAccess
Imports System
Imports System.Data
Imports Utils
Imports Utils.ConstantsUtils
Imports Telerik.Web.UI

Partial Class PMS_ProjectDesignCosting
    Inherits PageBase

    'Inherits System.Web.UI.Page

    Private PricingSampleCityBLL As New BLL.PMS_PricingSampleCityInfoBLL
    Private SubProjectSamplesizeBLL As New BLL.PMS_SubProjectSampleSizeBLL
    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private RecruitemntSelectionBLL As New BLL.Base_ProDesignRecruitmentSelectionBLL
    Private CriteriaSelectionBLL As New BLL.Base_ProDesignCriteriaSelectionBLL
    Private SectorInfoBLL As New BLL.Base_SectorBLL
    Private SubProjectInfoBLL As New BLL.PMS_SubProjectInfoBLL
    Private ProDesignCriteriaBLL As New BLL.PMS_ProDesginCriteriaBLL
    Private ProdesignRecritment As New BLL.PMS_ProDesignRecruitmentBLL
    ' add
    Private MethodologyInfoBLl As New BLL.Base_MethodologyInfoBLL

    Private Enum SampleSizeGridColumn
        Id = 2
        SubProId = 3
        CityId = 4
        SampleSize = 5
        Description = 6
    End Enum

    Private Enum DescriptionType
        Criteria = 1
        Recruitment = 2
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Call InitForm()
            If Not Request.QueryString("SubProId") Is Nothing Then
                ViewState("SubProId") = Request.QueryString("SubProId")
                GetSubProjectDesignInfo(Request.QueryString("SubProId").ToString)

            End If
        End If
        'Me.AutomotiveRow.Attributes("style") = "display:block"
    End Sub
    Private Sub InitForm()


        InitCombobox()
        InitRecruitment()
        InitCriteria()
    End Sub

    Private Sub InitCombobox()
        Dim ds As DataSet

        ds = PricingSampleCityBLL.GetPricingSampleCityInfoByType(1)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbDistrict, ds, "id", "CityName_CN", 2)
        End If

        ds = PricingSampleCityBLL.GetPricingSampleCityInfoByType(2)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProvince, ds, "id", "CityName_CN", 2)
        End If

        ds = PricingSampleCityBLL.GetPricingSampleCityInfoByType(3)
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbCity, ds, "id", "CityName_CN", 2)
        End If

        Me.rdCiySampleSize.DataSource = Me.CreateCitySampleSizeTable
        Me.rdCiySampleSize.DataBind()


    End Sub
    Private Sub InitCriteria()
        Dim ds As DataSet



        ''Consumer
        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.CAge)
        Call Me.initCheckList(Me.chklCAge, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.CGender)
        Call Me.initCheckList(Me.chklCGender, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.CMonthHHIncome)
        Call Me.initCheckList(Me.chklCMonthlyIncome, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.CProductusagefrequency)
        Call Me.initCheckList(Me.chklCFrequency, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.CRole)
        Call Me.initCheckList(Me.chklCRole, ds, DescriptionType.Criteria)

        'Auto
        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.ACarOwnerShip)
        Call Me.initCheckList(Me.chklACarOwnership, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.ACarSegment)
        Call Me.initCheckList(Me.chklACarSegment, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.APricinglevel)
        Call Me.initCheckList(Me.chklAPricingLevel, ds, DescriptionType.Criteria)


        'Business
        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.BNumberofEmployee)
        Call Me.initCheckList(Me.chklBEmployeeNO, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.BPosition)
        Call Me.initCheckList(Me.chklBPosition, ds, DescriptionType.Criteria)

        'Fin
        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.FMarket)
        Call Me.initCheckList(Me.chklFMarket, ds, DescriptionType.Criteria)


        'Hel
        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.HDegree)
        Call Me.initCheckList(Me.chklHDegree, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.HJobTitle)
        Call Me.initCheckList(Me.chklHJobTitle, ds, DescriptionType.Criteria)

        'T
        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.TNumberofemployee)
        Call Me.initCheckList(Me.chklTEmployeeNO, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.TJobTitle)
        Call Me.initCheckList(Me.chklTJobTitle, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.TOwnership)
        Call Me.initCheckList(Me.chklTOwnership, ds, DescriptionType.Criteria)

        ds = CriteriaSelectionBLL.GetCriteriaSelectionInfoByCriteriaId(Utils.ConstantsUtils.CriteriaType.TRole)
        Call Me.initCheckList(Me.chklTRole, ds, DescriptionType.Criteria)


    End Sub
    Private Sub InitRecruitment()
        Dim ds As DataSet
        Dim dt As DataTable


        '定量的Recuitment
        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QuantiRecruitmentType.SamplingMethod)
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            With radblSamplingMethod
                .DataTextField = "RecruitmentSelection"
                .DataValueField = "Id"
                .DataSource = dt
                .DataBind()
            End With

        End If

        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QuantiRecruitmentType.NOofOEQ)
        If Not ds Is Nothing Then
            dt = ds.Tables(0)

            With Me.radblNOofOEQ
                .DataTextField = "RecruitmentSelection"
                .DataValueField = "Id"
                .DataSource = dt
                .DataBind()
            End With

        End If

        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QuantiRecruitmentType.ProjectScope)
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            With Me.radblProjectscope
                .DataTextField = "RecruitmentSelection"
                .DataValueField = "Id"
                .DataSource = dt
                .DataBind()
            End With

        End If

        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QuantiRecruitmentType.DataFormat)
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            With Me.radblDataformat
                .DataTextField = "RecruitmentSelection"
                .DataValueField = "Id"
                .DataSource = dt
                .DataBind()
            End With


        End If

        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QuantiRecruitmentType.DataMap)
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            With Me.radblDatamap
                .DataTextField = "RecruitmentSelection"
                .DataValueField = "Id"
                .DataSource = dt
                .DataBind()
            End With

        End If

        '定性的Recruitment

        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QualiRecruitmentType.Clientlist)
        Call Me.initCheckList(Me.chklClientList, ds, DescriptionType.Recruitment)

        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QualiRecruitmentType.Transcriptneeded)
        Call Me.initCheckList(Me.chklTranscript, ds, DescriptionType.Recruitment)


        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QualiRecruitmentType.Audiotaperecordingneeded)
        Call Me.initCheckList(Me.chklAudio, ds, DescriptionType.Recruitment)


        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QualiRecruitmentType.Videotaperecordingneeded)
        Call Me.initCheckList(Me.chklVideo, ds, DescriptionType.Recruitment)

        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QualiRecruitmentType.Videoformat)
        Call Me.initCheckList(Me.chklTranslator, ds, DescriptionType.Recruitment)

        ds = RecruitemntSelectionBLL.GetRecruitmentSelectionInfoByRecruitmentId(Utils.ConstantsUtils.QualiRecruitmentType.Videoformat)
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            With Me.radblVideoformat
                .DataTextField = "RecruitmentSelection"
                .DataValueField = "Id"
                .DataSource = dt
                .DataBind()
            End With
        End If



    End Sub
    Private Sub GetSubProjectDesignInfo(ByVal strSubProid As String)
        ' add,here can improve
        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim MethodologyInfo As New Model.Base_MethodologyInfo
        SubProjectInfo = SubProjectInfoBLL.GetSubProjectInfoById(strSubProid)
        Me.txtSubJobNumber.Text = SubProjectInfo.SubJobNumber.ToString
        Me.txtCityDescription.Text = SubProjectInfo.Description.ToString
        MethodologyInfo = MethodologyInfoBLl.GetMethodologyInfo(SubProjectInfo.MethodologyId)
        If Not MethodologyInfo Is Nothing Then
            Me.txtMethodology.Text = MethodologyInfo.Methodology
        End If

        Call GridBind(strSubProid)

        Call IniRecruimentInfo(strSubProid)

        Call iniCriteriaInfo(strSubProid)

        GetProjectCriteriaInfo(strSubProid)

        GetProjectRecruitmentInfo(strSubProid)

    End Sub

    Private Sub GetProjectRecruitmentInfo(ByVal StrSubProId As String)
        Dim ds As DataSet
        Dim dt As DataTable
        Dim strRecruitmentFiledName As String = "RecruitmentSelectionId"
        Dim strCeriteriaFiledName As String = "CeriteriaSelectionId"

        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim ProjectInfo As New Model.PMS_ProposalInfo
        Dim SectorInfo As New Model.Base_Sector

        SubProjectInfo = Me.SubProjectInfoBLL.GetSubProjectInfoById(ViewState("SubProId"))
        ProjectInfo = ProposalInfoBLL.GetProposalInfoByID(SubProjectInfo.ProId)
        SectorInfo = SectorInfoBLL.GetSectorInfoByID(ProjectInfo.SectorId)

        ds = Me.ProdesignRecritment.GetProDesignRecruitmentBySubProId(StrSubProId)
        dt = ds.Tables(0)
        If Not ds Is Nothing Then
            Select Case SubProjectInfo.MethodologyType
                Case 1
                    SetRdblBox(Me.radblSamplingMethod, dt, strRecruitmentFiledName)
                    SetRdblBox(Me.radblNOofOEQ, dt, strRecruitmentFiledName)
                    '  SetRdblBox(Me.radblNOofOEQ, dt, strRecruitmentFiledName)
                    SetRdblBox(Me.radblProjectscope, dt, strRecruitmentFiledName)
                    SetRdblBox(Me.radblDataformat, dt, strRecruitmentFiledName)
                    SetRdblBox(Me.radblDatamap, dt, strRecruitmentFiledName)
                Case 2
                    SetRdblBox(Me.radblVideoformat, dt, strRecruitmentFiledName)
                    SetchklBox(Me.chklAudio, dt, strRecruitmentFiledName)
                    SetchklBox(Me.chklVideo, dt, strRecruitmentFiledName)
                    SetchklBox(Me.chklClientList, dt, strRecruitmentFiledName)
                    SetchklBox(Me.chklTranscript, dt, strRecruitmentFiledName)
                    SetchklBox(Me.chklTranslator, dt, strRecruitmentFiledName)
            End Select
        End If
    End Sub

    Private Sub GetProjectCriteriaInfo(ByVal strSubProId As String)
        Dim ds As DataSet
        Dim dt As DataTable
        Dim strCeriteriaFiledName As String = "CeriteriaSelectionId"

        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim ProjectInfo As New Model.PMS_ProposalInfo
        Dim SectorInfo As New Model.Base_Sector

        SubProjectInfo = Me.SubProjectInfoBLL.GetSubProjectInfoById(ViewState("SubProId"))
        ProjectInfo = ProposalInfoBLL.GetProposalInfoByID(SubProjectInfo.ProId)
        SectorInfo = SectorInfoBLL.GetSectorInfoByID(ProjectInfo.SectorId)

        ds = Me.ProDesignCriteriaBLL.GetProDesignCriteriaBySubProId(strSubProId)
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            SetchklBox(Me.chklCAge, dt, strCeriteriaFiledName)
            SetchklBox(Me.chklCGender, dt, strCeriteriaFiledName)
            SetchklBox(Me.chklCFrequency, dt, strCeriteriaFiledName)
            SetchklBox(Me.chklCMonthlyIncome, dt, strCeriteriaFiledName)
            SetchklBox(Me.chklCRole, dt, strCeriteriaFiledName)

            Select Case ProjectInfo.SectorId

                Case Utils.ConstantsUtils.Sector.Automotive
                    SetchklBox(Me.chklAPricingLevel, dt, strCeriteriaFiledName)
                    SetchklBox(Me.chklACarSegment, dt, strCeriteriaFiledName)
                    SetchklBox(Me.chklACarOwnership, dt, strCeriteriaFiledName)
                Case Utils.ConstantsUtils.Sector.Business
                    SetchklBox(Me.chklBPosition, dt, strCeriteriaFiledName)
                    SetchklBox(Me.chklBEmployeeNO, dt, strCeriteriaFiledName)
                Case Utils.ConstantsUtils.Sector.Finance
                    SetchklBox(Me.chklFMarket, dt, strCeriteriaFiledName)
                Case Utils.ConstantsUtils.Sector.Healthcare
                    SetchklBox(Me.chklHDegree, dt, strCeriteriaFiledName)
                    SetchklBox(Me.chklHJobTitle, dt, strCeriteriaFiledName)
                Case Utils.ConstantsUtils.Sector.Technology
                    SetchklBox(Me.chklTOwnership, dt, strCeriteriaFiledName)
                    SetchklBox(Me.chklTJobTitle, dt, strCeriteriaFiledName)
                    SetchklBox(Me.chklTEmployeeNO, dt, strCeriteriaFiledName)
                    SetchklBox(Me.chklTRole, dt, strCeriteriaFiledName)

            End Select
        End If


    End Sub

    Private Sub SetRdblBox(ByVal rdblBox As RadioButtonList, ByVal dt As DataTable, ByVal strFiledName As String)

        Dim i As Integer
        For Each dr As DataRow In dt.Rows
            For i = 0 To rdblBox.Items.Count - 1
                If rdblBox.Items(i).Value = dr(strFiledName) Then
                    rdblBox.Items(i).Selected = True
                    If rdblBox.ID = "radblNOofOEQ" Then
                        Me.txtNoofOEQ.Text = dr("Description")
                    End If

                    If rdblBox.ID = "radblVideoformat" Then
                        Me.txtVideoformat.Text = dr("Description")
                    End If
                End If
            Next
            If dr(strFiledName) = 0 Then
                Me.txtLenofQues.Text = dr("Description")
            End If

        Next
    End Sub


    Private Sub SetchklBox(ByVal chklBox As CheckBoxList, ByVal dt As DataTable, ByVal strFiledName As String)

        Dim i As Integer
        For Each dr As DataRow In dt.Rows
            For i = 0 To chklBox.Items.Count - 1
                If chklBox.Items(i).Value = dr(strFiledName) Then
                    chklBox.Items(i).Selected = True
                    If chklBox.ID = "chklTranslator" Then
                        Me.txtTranslator.Text = dr("Description")
                    End If
                End If
            Next
        Next
    End Sub


    Private Sub GridBind(ByVal strSubProid As String)
        Dim ds As DataSet
        Dim dt As DataTable
        Dim lngSampleSize As Long

        ds = Me.SubProjectSamplesizeBLL.GetSubProjectSampleSizeBySubProId(CInt(strSubProid))
        If Not ds Is Nothing Then
            dt = ds.Tables(0)
            Me.rdCiySampleSize.DataSource = dt
            Me.rdCiySampleSize.DataBind()

            For Each dr As DataRow In dt.Rows
                lngSampleSize = lngSampleSize + dr("sampleSize")
            Next
            Me.txtTotalSampleSize.Text = lngSampleSize
        End If

    End Sub

    Private Sub iniCriteriaInfo(ByVal strSubProId As String)
        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim ProjectInfo As New Model.PMS_ProposalInfo
        Dim SectorInfo As New Model.Base_Sector

        SubProjectInfo = Me.SubProjectInfoBLL.GetSubProjectInfoById(ViewState("SubProId"))
        ProjectInfo = ProposalInfoBLL.GetProposalInfoByID(SubProjectInfo.ProId)
        SectorInfo = SectorInfoBLL.GetSectorInfoByID(ProjectInfo.SectorId)

        ' modify


        Select Case ProjectInfo.SectorId
            Case Utils.ConstantsUtils.Sector.Automotive
                Me.AutomotiveRow.Attributes("style") = "display:block"
                'Me.wpAutomotive.Visible = True
            Case Utils.ConstantsUtils.Sector.Business
                Me.BusinessRow.Attributes("style") = "display:block"
                'Me.wpBusiness.Visible = True
            Case Utils.ConstantsUtils.Sector.Finance
                Me.FinanceRow.Attributes("style") = "display:block"
                'Me.wpFinance.Visible = True
            Case Utils.ConstantsUtils.Sector.Healthcare
                Me.FinanceRow.Attributes("style") = "display:block"
                'Me.wpFinance.Visible = True
            Case Utils.ConstantsUtils.Sector.Technology
                Me.TechnologyRow.Attributes("style") = "display:block"
                'Me.wpTechnology.Visible = True
            Case Else
                Me.CriteriaRow.Attributes("style") = "display:block"
                'Me.wpConsumer.Visible = True
        End Select
    End Sub



    Private Sub IniRecruimentInfo(ByVal strSubProId As String)
        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        SubProjectInfo = SubProjectInfoBLL.GetSubProjectInfoById(strSubProId)
        ' modify
        If Not SubProjectInfo Is Nothing Then
            If SubProjectInfo.MethodologyType = 1 Then 'Quanti
                Me.QualiRow.Attributes("style") = "display:none"
                'Me.wpQuali.Visible = False
            Else
                Me.QuantiRow.Attributes("style") = "display:none"
                'Me.wpQuanti.Visible = False
            End If
        End If

    End Sub

    Protected Sub cbProvince_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles cbProvince.SelectedIndexChanged
        Dim ds As DataSet

        If Me.cbProvince.SelectedValue > 0 Then
            ds = PricingSampleCityBLL.GetPricingSampleCityInfoByParentId(Me.cbProvince.SelectedValue)
            If Not ds Is Nothing Then
                Utils.PageUtils.BindComboBoxList(Me.cbCity, ds, "id", "CityName_CN", 2)
            End If
        End If
    End Sub

    Protected Sub cbDistrict_SelectedIndexChanged1(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles cbDistrict.SelectedIndexChanged
        Dim ds As DataSet

        If Me.cbDistrict.SelectedValue > 0 Then
            ds = PricingSampleCityBLL.GetPricingSampleCityInfoByParentId(Me.cbDistrict.SelectedValue)
            If Not ds Is Nothing Then
                Utils.PageUtils.BindComboBoxList(Me.cbProvince, ds, "id", "CityName_CN", 2)
            End If
        End If
    End Sub

    Private Function CreateCitySampleSizeTable() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("SubProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("CityId", GetType(System.String)))
        dt.Columns.Add(New DataColumn("SampleSize", GetType(System.Decimal)))
        dt.Columns.Add(New DataColumn("Description", GetType(System.String)))
        Return dt

    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim info As New Model.PMS_SubProjectSampleSize

        If CheckSampleSizeData() = False Then
            Exit Sub
        Else
            info.SubProId = ViewState("SubProId")
            info.CityId = Me.cbCity.SelectedValue
            info.Description = Utils.DataConvert.ConvertStringAsSqlString(Me.txtDescription.Text.Trim)
            info.Samplesize = Me.txtSampleSize.Text.Trim
            ' modify
            If SubProjectSamplesizeBLL.AddSubProjectSampleSizeInfo(info) = False Then
                'Me.RadAjaxManager1.Alert("Save Samplesize Fault!")
            End If
            Call GridBind(ViewState("SubProId"))
        End If
    End Sub

    Private Function CheckSampleSizeData() As Boolean
        If Me.cbCity.SelectedValue = 0 Then
            'Me.RequiredFieldValidator1.ErrorMessage = "Please input samplesize!"
            'Response.Write("window.alert('You failed to approve the record(s) !');")
            'Me.RadAjaxManager1.Alert("Please select city!")
            Return False
            Exit Function
        End If

        If Me.txtSampleSize.Text = String.Empty Then

            ' Me.RequiredFieldValidator1.ErrorMessage = "Please input samplesize!"
            ' Response.Write("window.alert('You failed to approve the record(s) !');")
            'Me.RadAjaxManager1.Alert("Please input samplesize!")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Protected Sub rdCiySampleSize_DeleteCommand(ByVal source As Object, ByVal e As GridCommandEventArgs) Handles rdCiySampleSize.DeleteCommand
        Dim strId As String

        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            strId = e.Item.Cells(SampleSizeGridColumn.Id).Text

            If Me.SubProjectSamplesizeBLL.DeleteSubProjectSampleSizeInfoById(strId) = True Then
                Call GridBind(ViewState("SubProId"))

            End If
        End If
    End Sub

    Protected Sub rdCiySampleSize_ItemDataBound(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles rdCiySampleSize.ItemDataBound
        Dim strCityId As String
        Dim SampleCityInfo As New Model.PMS_PricingSampleCityInfo

        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            strCityId = e.Item.Cells(SampleSizeGridColumn.CityId).Text
            SampleCityInfo = Me.PricingSampleCityBLL.GetPricingSampleCityInfoById(CInt(strCityId))
            If Not SampleCityInfo Is Nothing Then
                e.Item.Cells(SampleSizeGridColumn.CityId).Text = SampleCityInfo.CityName_CN
            End If
        End If
    End Sub

    Protected Sub rdCiySampleSize_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles rdCiySampleSize.NeedDataSource
        If Not ViewState("SubProId") Is Nothing Then
            Dim ds As DataSet
            Dim dt As DataTable

            ds = Me.SubProjectSamplesizeBLL.GetSubProjectSampleSizeBySubProId(ViewState("SubProId"))
            If Not ds Is Nothing Then
                dt = ds.Tables(0)
                Me.rdCiySampleSize.DataSource = dt
            End If
        End If

    End Sub

    Private Sub initCheckList(ByVal chkList As CheckBoxList, ByVal ds As DataSet, ByVal type As Integer)
        Dim dt As DataTable

        If type = 1 Then '初始化 Criteria
            If Not ds Is Nothing Then
                dt = ds.Tables(0)
                With chkList
                    .DataTextField = "CriteriaSelection"
                    .DataValueField = "Id"
                    .DataSource = dt
                    .DataBind()
                End With
            End If
        End If

        If type = 2 Then
            If Not ds Is Nothing Then
                dt = ds.Tables(0)
                With chkList
                    .DataTextField = "RecruitmentSelection"
                    .DataValueField = "Id"
                    .DataSource = dt
                    .DataBind()
                End With
            End If
        End If
    End Sub


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

      
        Dim dtCriteria As DataTable
        Dim dtRecruitment As DataTable

        dtCriteria = GetCriteria()
        dtRecruitment = GetRecruitment()
        If dtCriteria.Rows.Count > 0 Or dtRecruitment.Rows.Count > 0 Then

            If ProDesignCriteriaBLL.SaveCriteriaRecruitment(dtCriteria, dtRecruitment, ViewState("SubProId")) = True Then

                'Response.Write("<script language = javascript>alert('Save Success！');</script>")
                Me.Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>javascript:alert('Save Success！');</script>")
                iniCriteriaInfo(ViewState("SubProId"))

            End If
        End If

    End Sub


    Private Function GetRecruitment() As DataTable

        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim ProjectInfo As New Model.PMS_ProposalInfo
        Dim SectorInfo As New Model.Base_Sector
        Dim dr As DataRow

        SubProjectInfo = Me.SubProjectInfoBLL.GetSubProjectInfoById(ViewState("SubProId"))
        Dim dtRecruitment As DataTable

        dtRecruitment = Me.CreateDtRecruitment

        Select Case SubProjectInfo.MethodologyType
            Case 1
                'Sample method
                If Me.radblSamplingMethod.SelectedValue <> "" Then
                    If Me.radblSamplingMethod.SelectedValue <> 0 Then
                        dr = dtRecruitment.NewRow
                        dr("subProId") = SubProjectInfo.Id
                        dr("RecruitmentSelectionId") = radblSamplingMethod.SelectedValue
                        dr("Description") = String.Empty
                        dtRecruitment.Rows.Add(dr)
                    End If
                End If

                'LEN of  questionnair:
                If Me.txtLenofQues.Text <> String.Empty Then
                    dr = dtRecruitment.NewRow
                    dr("subProId") = SubProjectInfo.Id
                    dr("RecruitmentSelectionId") = 0
                    dr("Description") = Me.txtLenofQues.Text
                    dtRecruitment.Rows.Add(dr)
                End If

                'No.of question
                If Me.radblNOofOEQ.SelectedValue <> "" Then
                    If Me.radblNOofOEQ.SelectedValue <> 0 Then
                        dr = dtRecruitment.NewRow
                        dr("subProId") = SubProjectInfo.Id
                        dr("RecruitmentSelectionId") = radblNOofOEQ.SelectedValue
                        dr("Description") = Me.txtNoofOEQ.Text
                        dtRecruitment.Rows.Add(dr)
                    End If
                End If

                'ProjectScope
                If Me.radblProjectscope.SelectedValue <> "" Then
                    If Me.radblProjectscope.SelectedValue <> 0 Then
                        dr = dtRecruitment.NewRow
                        dr("subProId") = SubProjectInfo.Id
                        dr("RecruitmentSelectionId") = radblProjectscope.SelectedValue
                        dr("Description") = String.Empty
                        dtRecruitment.Rows.Add(dr)
                    End If
                End If

                'DataFormat
                If Me.radblDataformat.SelectedValue <> "" Then
                    If Me.radblDataformat.SelectedValue <> 0 Then
                        dr = dtRecruitment.NewRow
                        dr("subProId") = SubProjectInfo.Id
                        dr("RecruitmentSelectionId") = radblDataformat.SelectedValue
                        dr("Description") = String.Empty
                        dtRecruitment.Rows.Add(dr)
                    End If
                End If

                'dtatmap
                If Me.radblDatamap.SelectedValue <> "" Then
                    If Me.radblDatamap.SelectedValue <> 0 Then
                        dr = dtRecruitment.NewRow
                        dr("subProId") = SubProjectInfo.Id
                        dr("RecruitmentSelectionId") = radblDatamap.SelectedValue
                        dr("Description") = String.Empty
                        dtRecruitment.Rows.Add(dr)
                    End If
                End If

            Case 2
                'ClientList
                If Me.chklClientList.Items.Count > 0 Then
                    dtRecruitment = AddDtRecruitment(Me.chklClientList, dtRecruitment)
                End If
                'Transcript needed:
                If Me.chklTranscript.Items.Count > 0 Then
                    dtRecruitment = AddDtRecruitment(Me.chklTranscript, dtRecruitment)
                End If

                'Audio tape recording needed
                If Me.chklAudio.Items.Count > 0 Then
                    dtRecruitment = AddDtRecruitment(Me.chklAudio, dtRecruitment)
                End If

                'Video
                If Me.chklVideo.Items.Count > 0 Then
                    dtRecruitment = AddDtRecruitment(Me.chklVideo, dtRecruitment)
                End If

                'Video format:

                If Me.radblVideoformat.SelectedValue <> "" Then
                    If Me.radblVideoformat.SelectedValue <> 0 Then
                        dr = dtRecruitment.NewRow
                        dr("subProId") = SubProjectInfo.Id
                        dr("RecruitmentSelectionId") = radblVideoformat.SelectedValue
                        dtRecruitment.Rows.Add(dr)
                        dr("Description") = Me.txtVideoformat.Text
                    End If
                End If

                'Translator require:
                If Me.chklTranslator.Items.Count > 0 Then
                    dtRecruitment = AddDtRecruitment(Me.chklTranslator, dtRecruitment)
                End If

        End Select

        Return dtRecruitment


    End Function

    Private Function AddDtRecruitment(ByVal ChkboxList As CheckBoxList, ByVal dt As DataTable) As DataTable

        Dim dr As DataRow
        Dim i As Integer
        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim ProjectInfo As New Model.PMS_ProposalInfo
        Dim SectorInfo As New Model.Base_Sector



        SubProjectInfo = Me.SubProjectInfoBLL.GetSubProjectInfoById(ViewState("SubProId"))
        ProjectInfo = ProposalInfoBLL.GetProposalInfoByID(SubProjectInfo.ProId)
        SectorInfo = SectorInfoBLL.GetSectorInfoByID(ProjectInfo.SectorId)



        For i = 0 To ChkboxList.Items.Count - 1
            If ChkboxList.Items(i).Selected = True Then
                dr = dt.NewRow
                dr("subProId") = SubProjectInfo.Id
                dr("RecruitmentSelectionId") = ChkboxList.Items(i).Value
                If ChkboxList.ID = "chklTranslator" Then
                    dr("Description") = Me.txtTranslator.Text
                Else
                    dr("Description") = String.Empty
                End If
                dt.Rows.Add(dr)
            End If
        Next


        Return dt
    End Function


    Private Function GetCriteria() As DataTable
        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim ProjectInfo As New Model.PMS_ProposalInfo
        Dim SectorInfo As New Model.Base_Sector

        SubProjectInfo = Me.SubProjectInfoBLL.GetSubProjectInfoById(ViewState("SubProId"))
        ProjectInfo = ProposalInfoBLL.GetProposalInfoByID(SubProjectInfo.ProId)
        SectorInfo = SectorInfoBLL.GetSectorInfoByID(ProjectInfo.SectorId)

        Dim dtCriteria As DataTable

        dtCriteria = Me.CreateDtCeriteria

        'Ceriteria consumer
        'age
        If Me.chklCAge.Items.Count > 0 Then
            dtCriteria = AddDtCriteria(Me.chklCAge, dtCriteria)
        End If

        'Gender
        If Me.chklCGender.Items.Count > 0 Then
            dtCriteria = AddDtCriteria(Me.chklCGender, dtCriteria)
        End If

        'MondlyIncome
        If Me.chklCMonthlyIncome.Items.Count > 0 Then
            dtCriteria = AddDtCriteria(Me.chklCMonthlyIncome, dtCriteria)
        End If

        'Frequency
        If Me.chklCFrequency.Items.Count > 0 Then
            dtCriteria = AddDtCriteria(Me.chklCFrequency, dtCriteria)
        End If

        'Role
        If Me.chklCRole.Items.Count > 0 Then
            dtCriteria = AddDtCriteria(Me.chklCRole, dtCriteria)
        End If

        Select Case ProjectInfo.SectorId

            Case Utils.ConstantsUtils.Sector.Automotive

                'Auto
                'Car ownership
                If Me.chklACarOwnership.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklACarOwnership, dtCriteria)
                End If


                If Me.chklACarSegment.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklACarSegment, dtCriteria)
                End If

                If Me.chklAPricingLevel.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklAPricingLevel, dtCriteria)
                End If
            Case Utils.ConstantsUtils.Sector.Business

                'Business
                If Me.chklBEmployeeNO.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklBEmployeeNO, dtCriteria)
                End If

                If Me.chklBPosition.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklBPosition, dtCriteria)
                End If
            Case Utils.ConstantsUtils.Sector.Finance

                If Me.chklFMarket.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklFMarket, dtCriteria)
                End If

            Case Utils.ConstantsUtils.Sector.Healthcare

                If Me.chklHDegree.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklHDegree, dtCriteria)
                End If

                If Me.chklHJobTitle.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklHJobTitle, dtCriteria)
                End If
            Case Utils.ConstantsUtils.Sector.Technology

                If Me.chklTEmployeeNO.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklTEmployeeNO, dtCriteria)
                End If

                If Me.chklTJobTitle.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklTJobTitle, dtCriteria)
                End If

                If Me.chklTOwnership.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklTOwnership, dtCriteria)
                End If

                If Me.chklTRole.Items.Count > 0 Then
                    dtCriteria = AddDtCriteria(Me.chklTRole, dtCriteria)
                End If

        End Select

        Return dtCriteria

    End Function

    Private Function AddDtCriteria(ByVal ChkboxList As CheckBoxList, ByVal dt As DataTable) As DataTable

        Dim dr As DataRow
        Dim i As Integer
        Dim SubProjectInfo As New Model.PMS_SubProjectInfo
        Dim ProjectInfo As New Model.PMS_ProposalInfo
        Dim SectorInfo As New Model.Base_Sector



        SubProjectInfo = Me.SubProjectInfoBLL.GetSubProjectInfoById(ViewState("SubProId"))
        ProjectInfo = ProposalInfoBLL.GetProposalInfoByID(SubProjectInfo.ProId)
        SectorInfo = SectorInfoBLL.GetSectorInfoByID(ProjectInfo.SectorId)



        For i = 0 To ChkboxList.Items.Count - 1
            If ChkboxList.Items(i).Selected = True Then
                dr = dt.NewRow
                dr("subProId") = SubProjectInfo.Id
                dr("CeriteriaSelectionId") = ChkboxList.Items(i).Value
                dr("Description") = String.Empty
                dt.Rows.Add(dr)
            End If
        Next


        Return dt
    End Function

    Private Function CreateDtCeriteria() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("SubProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("CeriteriaSelectionId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("Description", GetType(System.String)))
        Return dt
    End Function

    Private Function CreateDtRecruitment() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("SubProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("RecruitmentSelectionId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("Description", GetType(System.String)))
        Return dt
    End Function

    Protected Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click

    End Sub
End Class
