Imports DataAccess
Imports System.Data

Partial Class PMS_UpdateProposal
    Inherits System.Web.UI.Page

    Private ProjectTypeBLL As New BLL.Base_ProjectTypeBLL
    Private CityBLL As New BLL.Base_CityInfoBLL
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private SectorBLL As New BLL.Base_SectorBLL
    Private ProductCategory As New BLL.Base_ProductCategoryBLL
    Private AOEBLL As New BLL.Base_AOEBLL
    Private BSBLL As New BLL.Base_BusinessSolutionBLL
    Private MyUserinfo As New Model.User_UserInfo
    Private UserInfoBLL As New BLL.UserInfoBLL
    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private ProjectStatusBLL As New BLL.Base_ProjectStatusBLL
    Private DigitalProductsIdBLL As New BLL.Base_DigitalProductsBLL
    Private ProposalUserinfoBLl As New BLL.PMS_ProposalUserInfoBLL
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
            Call InitForm()
            InitComboBox()
            If Not Request.QueryString("Proid") Is Nothing Then
                Dim strId As String = Request.QueryString("Proid")
                Call Me.GetproposalInfobyId(strId)
            End If
        Else
            If Not Session("ProposalUser") Is Nothing Then
                colUser = Session("ProposalUser")
                Call SetUserList()
            End If
        End If
    End Sub

    Private Sub InitForm()
        If Not Session("LoginUserInfo") Is Nothing Then
            MyUserinfo = Session("LoginUserInfo")
        End If
        Me.txtJobNumber.ReadOnly = True
        Me.txtCreateDate.ReadOnly = True
        Me.txtCreateDate.Text = Now.Date
        Me.txtClientDescription.ReadOnly = True
        Me.txtTotalRevenue.Value = 0
        Me.txtTotalRevenue.ReadOnly = True
        Me.txtTotalRevenue.BackColor = Drawing.Color.Silver
        Me.txtPrepared.ReadOnly = True
        Me.txtPrepared.BackColor = Drawing.Color.Silver
        Me.txtPrepared.Text = MyUserinfo.Code
        'Me.txtAlert.Visible = False

        Me.txtQualiRevenue.Value = 0
        Me.txtQuantiRevenue.Value = 0
        Me.txtGM.Value = 0


        'Me.cbSector.Enabled = False
        'Me.cbCity.Enabled = False
    End Sub

    Private Sub InitComboBox()
        Dim ds As DataSet
        Dim dv As DataView
        Dim i As Integer

        If Not Session("LoginUserInfo") Is Nothing Then
            MyUserinfo = Session("LoginUserInfo")
        End If

        ds = ProjectTypeBLL.GetProjectTypeInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProjectType, ds, "id", "ProjectType", 2)
        End If

        ds = CityBLL.GetCityInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbCity, ds, "id", "City", 2)
            Me.cbCity.SelectedValue = MyUserinfo.CityId
        End If

        ds = SectorBLL.GetSectorInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbSector, ds, "id", "Sector", 2)
        End If

        ds = ProductCategory.GetProductCategoryInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbProductCategory, ds, "id", "ProductCategory", 2)
        End If

        ds = AOEBLL.GetAOEInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbAOE, ds, "id", "AOE", 0)
            Me.cbAOE.SelectedValue = 6
        End If

        ds = BSBLL.GetBSInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbBS, ds, "id", "BusinessSolution", 0)
            Utils.PageUtils.BindComboBoxList(Me.cbOtherBS, ds, "id", "BusinessSolution", 0)
            Me.cbBS.SelectedValue = 17
            Me.cbOtherBS.SelectedValue = 17
        End If

        ds = Me.DigitalProductsIdBLL.GetDigitalProductsInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbDigital, ds, "id", "DigitalProducts", 0)
            Me.cbDigital.SelectedValue = 10
        End If

        'PM
        dv = UserInfoBLL.GetUserList("Level>=2 and DepID=1")
        If Not dv Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbManager, dv, "id", "Code", 2)
        End If

        'director
        'PM
        dv = UserInfoBLL.GetUserList("Level>=4 and DepID=1")
        If Not dv Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbDirector, dv, "id", "Code", 2)
        End If



        '***********绑定Status
        ds = ProjectStatusBLL.GetProjectStatusInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbStatus, ds, "id", "ProjectStatus", 2)
        End If

        If Me.cbStatus.Items.Count > 0 Then
            For i = 0 To Me.cbStatus.Items.Count - 1
                If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.Project Then
                    Me.cbStatus.Items(i).Enabled = False
                End If

                If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.Closed Then
                    Me.cbStatus.Items(i).Enabled = False
                End If
            Next
        End If



    End Sub

    Protected Sub cbClientType_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbClientType.SelectedIndexChanged
        Dim dv As DataView
        Dim i As Integer
        Select Case cbClientType.SelectedValue
            Case 1 'Internal
                Me.cbInternalClient.Enabled = True
                Me.cbEndClient.Items.Clear()

                dv = ClientInfoBLL.GetClientInfoByClientType(Utils.ConstantsUtils.ClientType.ExternalClientForInternal)
                If Not dv Is Nothing Then
                    Utils.PageUtils.BindComboBoxList(Me.cbEndClient, dv, "id", "FullName", 2)
                End If


                For i = 0 To Me.cbInternalClient.Items.Count - 1
                    cbInternalClient.Items(i).Enabled = True
                Next

            Case 2 'External

                Me.cbInternalClient.SelectedValue = 0
                Me.cbInternalClient.Enabled = False
                dv = ClientInfoBLL.GetClientInfoByClientType(Utils.ConstantsUtils.ClientType.ExternalClient)
                If Not dv Is Nothing Then
                    Utils.PageUtils.BindComboBoxList(Me.cbEndClient, dv, "id", "FullName", 2)
                End If

        End Select
    End Sub

    Protected Sub cbEndClient_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbEndClient.SelectedIndexChanged
        If Me.cbEndClient.SelectedValue = 880 Or (Me.cbEndClient.SelectedValue = 805 And Me.cbClientType.SelectedValue = 1) Then ' Others
            Me.txtClientDescription.ReadOnly = False
            Me.txtClientDescription.BackColor = Drawing.Color.White
        Else
            Me.txtClientDescription.ReadOnly = True
            Me.txtClientDescription.Text = String.Empty
            Me.txtClientDescription.BackColor = Drawing.Color.Silver
        End If
    End Sub

    Protected Sub cbSector_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbSector.SelectedIndexChanged
        Dim ds As DataSet
        If Me.cbSector.SelectedValue <> 0 Then
            ds = ProductCategory.GetSectorInfoBySectorId(Me.cbSector.SelectedValue)
            If Not ds Is Nothing Then
                Utils.PageUtils.BindComboBoxList(Me.cbProductCategory, ds, "id", "ProductCategory", 2)
            End If

        End If
    End Sub

    Protected Sub txtQuantiRevenue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantiRevenue.TextChanged
        Me.txtTotalRevenue.Value = CDbl(Me.txtQuantiRevenue.Value) + CDbl(Me.txtQualiRevenue.Value)
        Me.txtGM.Value = CDbl(Me.txtTotalRevenue.Value) * Me.cbGMPercent.SelectedValue / 100
    End Sub

    Protected Sub txtQualiRevenue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQualiRevenue.TextChanged
        Me.txtTotalRevenue.Value = CDbl(Me.txtQuantiRevenue.Value) + CDbl(Me.txtQualiRevenue.Value)
        Me.txtGM.Value = CDbl(Me.txtTotalRevenue.Value) * Me.cbGMPercent.SelectedValue / 100
    End Sub

    Protected Sub cbGMPercent_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbGMPercent.SelectedIndexChanged
        Me.txtGM.Value = CDbl(Me.txtTotalRevenue.Value) * Me.cbGMPercent.SelectedValue / 100
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim info As New Model.PMS_ProposalInfo
        Dim strFilePath As String = System.Web.Configuration.WebConfigurationManager.AppSettings("UploadProjectFilePath").ToString

        If Me.txtJobNumber.Text = String.Empty Then
            Exit Sub
        Else
            If CheckData() = True Then
                info.Id = Request.QueryString("Proid")
                info.JobNumber = Me.txtJobNumber.Text.ToString
                info.JobName = txtJobName.Text.Trim.ToString.Replace("'", "''")

                info.Status = Me.cbStatus.SelectedValue
              
                info.SectorId = Me.cbSector.SelectedValue
                info.ProductCategoryId = Me.cbProductCategory.SelectedValue


                info.Probability = Me.txtProbablity.Value

                info.Description = Me.txtDescription.Text.Trim.ToString.Replace("'", "''")
                info.CreateDate = Me.txtCreateDate.Text.ToString

                '*****************************************************************************

                'Team Member
                Dim dt As DataTable = Me.CreateUserTable
                Dim dr As DataRow
                Dim i As Integer

                If colUser.Count > 0 Then
                    For i = 1 To colUser.Count
                        dr = dt.NewRow()
                        dr("UserId") = colUser(i)
                        dr("ProposalUserTypeId") = 4
                        dt.Rows.Add(dr)
                        dt.AcceptChanges()
                    Next
                End If

                'PM
                dr = dt.NewRow
                dr("UserId") = Me.cbManager.SelectedValue
                dr("ProposalUserTypeId") = 2
                dt.Rows.Add(dr)
                dt.AcceptChanges()

                'Director
                dr = dt.NewRow
                dr("UserId") = Me.cbDirector.SelectedValue
                dr("ProposalUserTypeId") = 3
                dt.Rows.Add(dr)
                dt.AcceptChanges()

                'Director
                dr = dt.NewRow
                dr("UserId") = MyUserinfo.ID
                dr("ProposalUserTypeId") = 1
                dt.Rows.Add(dr)
                dt.AcceptChanges()

                If ProposalInfoBLL.ModifyProposalInfo(info, dt) = True Then

                    Me.RadAjaxManager1.Alert("Save Success")

                Else
                    Me.RadAjaxManager1.Alert("Save Fault")
                End If
            End If
        End If
    End Sub

    Private Sub GetproposalInfobyId(ByVal StrId As String)

        Dim info As New Model.PMS_ProposalInfo
        Dim ClientInfo As New Model.Client_ClientInfo
        Dim userinfo As New Model.User_UserInfo
        Dim dv As DataView

        Try
            info = ProposalInfoBLL.GetProposalInfoByID(CInt(StrId))

            If info Is Nothing Then
                Exit Sub
            End If

          


            Me.txtJobNumber.Text = info.JobNumber
            Me.txtJobName.Text = info.JobName
          
            Me.cbSector.SelectedValue = info.SectorId
            Me.cbProductCategory.SelectedValue = info.ProductCategoryId
         

            Me.txtProbablity.Value = info.Probability
          

            Me.txtCreateDate.Text = info.CreateDate
            Me.txtDescription.Text = info.Description
          

            Dim i As Integer

            For i = 0 To cbSector.Items.Count - 1
                Dim str As String
                cbSector.Items(i).Enabled = False
                str = cbSector.Items(i).Text
            Next

            For i = 0 To Me.cbCity.Items.Count - 1
                cbCity.Items(i).Enabled = False
            Next

        

            '**************************************************
            '**************************************************

            Dim iInternalClientStatus As Integer
            Dim inExternalClientStatus As Integer
            Dim intStatus As Integer

            If Me.cbClientType.SelectedValue = 1 Then 'Internal Client
                ClientInfo = ClientInfoBLL.GetClientInfoByID(Me.cbInternalClient.SelectedValue)
                If Me.cbInternalClient.SelectedValue <> 0 Then
                    If ClientInfo.Status = 0 Then '新增客户还没有确认()
                        iInternalClientStatus = 0 'Pending 状态
                    Else
                        iInternalClientStatus = 1
                    End If
                End If

                ClientInfo = ClientInfoBLL.GetClientInfoByID(Me.cbEndClient.SelectedValue)

                If Me.cbEndClient.SelectedValue <> 0 Then
                    If ClientInfo.Status = 0 Then '新增客户还没有确认()
                        inExternalClientStatus = 0 'Pending 状态
                    Else
                        inExternalClientStatus = 1
                    End If
                End If
                intStatus = iInternalClientStatus * inExternalClientStatus
            End If



            '只判断Ending Client
            If Me.cbClientType.SelectedValue = 2 Then 'Internal Client

                ClientInfo = ClientInfoBLL.GetClientInfoByID(Me.cbEndClient.SelectedValue)

                If Me.cbEndClient.SelectedValue <> 0 Then
                    If ClientInfo.Status = 0 Then '新增客户还没有确认()
                        inExternalClientStatus = 0 'Pending 状态
                    Else
                        inExternalClientStatus = 1
                    End If
                End If

                intStatus = inExternalClientStatus
            End If



            '***************************************************************
            '已经是Proposal状态的
            '***************************************************************
            If intStatus = 1 And info.Status = 2 Then
                Me.cbStatus.SelectedValue = Utils.ConstantsUtils.ProjectStatus.Proposal

                For i = 0 To Me.cbStatus.Items.Count - 1
                    If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.pending Then
                        Me.cbStatus.Items(i).Enabled = False
                    End If

                    If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.Proposal Then
                        Me.cbStatus.Items(i).Enabled = True
                    End If

                    If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.Cancellaiton Then
                        Me.cbStatus.Items(i).Enabled = True
                    End If

                    If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.Reject Then
                        Me.cbStatus.Items(i).Enabled = True
                    End If
                Next
            End If



            If intStatus = 0 Then  '新增客户还没有确定
                For i = 0 To Me.cbStatus.Items.Count - 1
                    If i <> 1 Then
                        Me.cbStatus.Items(i).Enabled = False
                    End If
                Next
                Me.cbStatus.SelectedValue = Utils.ConstantsUtils.ProjectStatus.pending
            End If



            'If intStatus = 1 And info.Status = 1 Then '客户状态为确认，项目状态为Pending 。则更改为Proposal

            '    If ProposalInfoBLL.UpdateProjectStatus(info.Id) = True Then

            '        For i = 0 To Me.cbStatus.Items.Count - 1
            '            If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.pending Then
            '                Me.cbStatus.Items(i).Enabled = False
            '            End If

            '            If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.Proposal Then
            '                Me.cbStatus.Items(i).Enabled = True
            '            End If

            '            If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.Cancellaiton Then
            '                Me.cbStatus.Items(i).Enabled = True
            '            End If

            '            If Me.cbStatus.Items(i).Value = Utils.ConstantsUtils.ProjectStatus.Reject Then
            '                Me.cbStatus.Items(i).Enabled = True
            '            End If
            '        Next
            '    End If
            '    Me.cbStatus.SelectedValue = Utils.ConstantsUtils.ProjectStatus.Proposal
            'End If

            '*************************************************************************************************
            'Get Proposal User List

            Dim ds As DataSet = ProposalUserinfoBLl.GetProposalUserinfoByProId(info.Id)
            If Not ds Is Nothing Then
                Dim dt As DataTable = ds.Tables(0)
                For Each dr As DataRow In dt.Rows
                    If dr("ProposaluserTypeId") = 1 Then '创建者
                        userinfo = UserInfoBLL.GetUserInfoById(dr("UserId"))
                        If Not userinfo Is Nothing Then
                            Me.txtPrepared.Text = userinfo.E_Name
                        End If
                    End If

                    If dr("ProposaluserTypeId") = 2 Then 'PM
                        Me.cbManager.SelectedValue = dr("UserId")
                    End If

                    If dr("ProposaluserTypeId") = 3 Then '总监
                        Me.cbDirector.SelectedValue = dr("UserId")
                    End If


                    If dr("ProposaluserTypeId") = 4 Then 'team Member

                        userinfo = UserInfoBLL.GetUserInfoById(dr("UserId"))
                        If Not userinfo Is Nothing Then
                            colUser.Add(dr("UserId"))
                        End If
                    End If

                Next

                If colUser.Count > 0 Then
                    Me.SetUserList()
                    Session("ProposalUser") = colUser
                End If

            End If





            If info.Status > 2 Then '已经转成项目
                For i = 0 To Me.cbStatus.Items.Count - 1
                    Me.cbStatus.Items(i).Enabled = False

                Next
                Me.cbStatus.Items(Utils.ConstantsUtils.ProjectStatus.Project).Enabled = True
                Me.cbStatus.SelectedValue = Utils.ConstantsUtils.ProjectStatus.Project
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Function CheckData() As Boolean
        If Me.txtJobName.Text = "" Then
            Me.RadAjaxManager1.Alert("Save fault!Please Inupt Job Nuame!")
            'Me.txtAlert.Text = "Save fault!Please Inupt Job Nuame! "
            Return False
            Exit Function
        End If

        If Me.cbProjectType.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select project type!")
            'Me.txtAlert.Text = "Save fault! Please select project type!"
            Return False
            Exit Function
        End If


        If Me.cbClientType.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select client type!")
            'Me.txtAlert.Text = "Save fault! Please select client type!"
            Return False
            Exit Function
        End If

        If Me.cbDigital.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select Digital Products !")
            ' Me.txtAlert.Text = "Save fault! Please select AOE !"
            Return False
            Exit Function
        End If

        If Me.cbClientType.SelectedValue = 1 And Me.cbInternalClient.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select internal client !")
            'Me.txtAlert.Text = "Save fault! Please select internal client !"
            Return False
            Exit Function
        End If

        If Me.cbEndClient.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select ending client !")
            ' Me.txtAlert.Text = "Save fault! Please select ending client !"
            Return False
            Exit Function
        End If

        If Me.cbSector.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select sector !")
            'Me.txtAlert.Text = "Save fault! Please select sector !"
            Return False
            Exit Function
        End If

        If Me.cbProductCategory.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select product category !")
            ' Me.txtAlert.Text = "Save fault! Please select product category !"
            Return False
            Exit Function
        End If

        If Me.cbBS.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select business solution !")
            ' Me.txtAlert.Text = "Save fault! Please select business solution !"
            Return False
            Exit Function
        End If

        If Me.cbAOE.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select AOE !")
            ' Me.txtAlert.Text = "Save fault! Please select AOE !"
            Return False
            Exit Function
        End If

        If Me.txtProbablity.Text = "" Then
            Me.RadAjaxManager1.Alert("Save fault! Please Input probability !")
            ' Me.txtAlert.Text = "Save fault! Please Input probability !"
            Return False
            Exit Function
        End If

        If Me.cbManager.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select project manager !")
            ' Me.txtAlert.Text = "Save fault! Please select project manager !"
            Return False
            Exit Function
        End If

        If Me.cbDirector.SelectedValue = 0 Then
            Me.RadAjaxManager1.Alert("Save fault! Please select project director !")
            ' Me.txtAlert.Text = "Save fault! Please select project director !"
            Return False
            Exit Function
        End If

        Return True

    End Function

    Protected Sub txtJobName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJobName.TextChanged
        Dim strString As String

        If Me.txtJobName.Text = String.Empty Then
            Exit Sub
        End If
        strString = Me.txtJobName.Text.Trim


        If Utils.DataCheckUtils.IsChineseCh(strString) = True Then
            Me.txtJobName.Text = String.Empty
            Me.RadAjaxManager1.Alert("Job Name can't input CHN character")
        End If
    End Sub


    Private Sub SetUserList()
        Dim strUserList As String
        Dim UserInfo As New Model.User_UserInfo
        Dim i As Integer

        strUserList = String.Empty
        If colUser.Count > 0 Then
            For i = 1 To colUser.Count
                UserInfo = UserInfoBLL.GetUserInfoById(colUser.Item(i))
                If Not UserInfo Is Nothing Then
                    strUserList = UserInfo.E_Name + ":" & strUserList
                End If
            Next

        End If

        Me.txtUserList.Text = strUserList

    End Sub

    Protected Sub btnSelectUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectUser.Click
        Me.Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>javascript:openWindow('../CommonPage/SelectUser.aspx','selectuser','SelectUser',true);</script>")

    End Sub
    Private Function CreateUserTable() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Id", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("UserId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("ProId", GetType(System.Int32)))
        dt.Columns.Add(New DataColumn("ProposalUserTypeId", GetType(System.Int32)))
        Return dt
    End Function

End Class
