Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils

Partial Class User_User
    Inherits OperatePageBase

    Private DepartBLL As New Base_DepartmentBLL
    Private UserBLL As New UserInfoBLL
    Private CityBLL As New Base_CityInfoBLL
    Private PosBLL As New Base_PositionInfoBLL
    Dim CurrentUserInfo As New User_UserInfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'get operate type from url.
        End If
    End Sub
    ''' <summary>
    ''' This method is used to init this form page.
    ''' here will get the user info object.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub InitForm()
        MyBase.InitForm()
        Me.diCommDate.SelectedDate = Date.Now
        Dim ds As DataSet
        Dim dt As New DataTable
        Dim dv As DataView
        'ds = CityBLL.GetCityInfo()
        'If Not ds Is Nothing Then
        '    'PageUtils.BindComboBoxList(Me.cbCity, ds, "ID", "City", 2)
        '    PageUtils.BindDropDownList(Me.cbCity, ds, "ID", "City", 2)
        'End If

        ds = PosBLL.GetPositionInfo()
        If Not ds Is Nothing Then
            'PageUtils.BindComboBoxList(Me.cbPosition, ds, "ID", "Position", 2)
            PageUtils.BindDropDownList(Me.cbPosition, ds, "ID", "Position", 2)
        End If

        'ds = DepartBLL.GetDepartmentInfo()
        'If Not ds Is Nothing Then
        '    'PageUtils.BindComboBoxList(Me.cbDepartment, ds, "ID", "Department", 2)
        '    PageUtils.BindDropDownList(Me.cbDepartment, ds, "ID", "Department", 2)
        'End If

        dv = UserBLL.GetUserList("")
        If Not dv Is Nothing Then
            'PageUtils.BindComboBoxList(Me.cbManager, dv, "ID", "Code", 2)
            PageUtils.BindDropDownList(Me.cbManager, dv, "ID", "Code", 2)
        End If
        
    End Sub
    ''' <summary>
    ''' This method is used to set form 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub SetForm()
        MyBase.SetForm()
        'get user id from url
        Dim id As String = Page.Request.QueryString("id")
        If OperateType = "Modify" Then
            CurrentUserInfo = UserBLL.GetUserInfoById(Convert.ToInt32(id))
            ViewState("currentUserInfo") = CurrentUserInfo
            'set the form.
            Me.tbCode.Text = CurrentUserInfo.Code
            Me.tbEName.Text = CurrentUserInfo.E_Name.Trim
            Me.tbCName.Text = CurrentUserInfo.C_Name.Trim
            Me.tbEmail.Text = CurrentUserInfo.Email.Trim
            Me.tbExtension.Text = CurrentUserInfo.WorkPhone
            Me.tbPassword.Text = CurrentUserInfo.Password
            Me.tbPinCode.Text = CurrentUserInfo.PIN
            Me.diCommDate.SelectedDate = CurrentUserInfo.CommencementDate
            Me.tbRemark.Text = CurrentUserInfo.Remark
            Me.tbExtension.Text = CurrentUserInfo.WorkPhone

            'change telerik combobox to asp.net dropdownlist
            'SetComboboxSelectedValue(Me.cbCity, CurrentUserInfo.CityId)
            'SetComboboxSelectedValue(Me.cbDepartment, CurrentUserInfo.DepId)
            'SetComboboxSelectedValue(Me.cbDuty, CurrentUserInfo.Onduty)
            'SetComboboxSelectedValue(Me.cbManager, CurrentUserInfo.LineManager)
            'SetComboboxSelectedValue(Me.cbPosition, CurrentUserInfo.PositionID)
            'Me.cbCity.SelectedValue = CurrentUserInfo.CityId
            'Me.cbDepartment.SelectedValue = CurrentUserInfo.DepId
            Me.cbDuty.SelectedValue = CurrentUserInfo.Onduty
            Me.cbManager.SelectedValue = CurrentUserInfo.LineManager
            Me.cbPosition.SelectedValue = CurrentUserInfo.PositionID
        End If
    End Sub
    ''' <summary>
    ''' This method is used to set selected index by selected value.
    ''' </summary>
    ''' <param name="combobox">Pass the combobox.</param>
    ''' <param name="selectedValue">Pass the selected value.</param>
    ''' <remarks></remarks>
    Private Sub SetComboboxSelectedValue(ByVal combobox As Telerik.Web.UI.RadComboBox, ByVal selectedValue As String)
        Dim index As Integer = combobox.FindItemIndexByValue(selectedValue)
        combobox.SelectedIndex = index
    End Sub
    ''' <summary>
    ''' This is the event when user click save button.
    ''' save event will check two type, one is new, another is modify.
    ''' </summary>
    ''' <param name="sender">Pass the event sender:button.</param>
    ''' <param name="e">Pass the event args.</param>
    ''' <remarks></remarks>
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'check data
        If Not CheckData() Then
            Return
        End If
        'set UserInfo object
        SetUserInfo()
        Try
            'check if user exists
            Dim isExists As String = UserBLL.IsUserExist(CurrentUserInfo.Code, CurrentUserInfo.Password)
            Dim operatedResult As Boolean
            If OperateType = "New" Then
                operatedResult = UserBLL.AddUserInfo(CurrentUserInfo)
            End If
            If OperateType = "Modify" Then
                operatedResult = UserBLL.ModifyUserInfo(CurrentUserInfo)
            End If
            'if operate success, then should return,else should remind user that operate failed.
            If operatedResult Then
                'remind
                Response.Write("<script language=javascript>")
                Response.Write("alert('success!');window.returnValue='success';window.close();")
                Response.Write("</script>")
                'close current page
            Else
                'remind
                Response.Write("<script language=javascript>")
                Response.Write("alert('failed!');window.returnValue='failed';window.close();")
                Response.Write("</script>")
                'close current page
            End If
        Catch ex As Exception
            Throw ex
        End Try


    End Sub
    ''' <summary>
    ''' This method is used to get the user info from control and set them to CurrentUserInfo object. 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetUserInfo()
        If Not ViewState("currentUserInfo") Is Nothing Then
            CurrentUserInfo = ViewState("currentUserInfo")
        End If
        CurrentUserInfo.C_Name = Me.tbCName.Text.Trim()
        '   CurrentUserInfo.CityId = Me.cbCity.SelectedValue
        CurrentUserInfo.Code = Me.tbCode.Text.Trim()
        CurrentUserInfo.CommencementDate = Me.diCommDate.SelectedDate
        CurrentUserInfo.CompanyType = 0 '0 is the company type for TNS
        ' CurrentUserInfo.DepId = Me.cbDepartment.SelectedValue
        CurrentUserInfo.E_Name = Me.tbEName.Text.Trim()
        CurrentUserInfo.Email = Me.tbEmail.Text.Trim()
        CurrentUserInfo.LineManager = Me.cbManager.SelectedValue
        CurrentUserInfo.Onduty = Me.cbDuty.SelectedValue
        CurrentUserInfo.Password = Me.tbPassword.Text.Trim()
        CurrentUserInfo.PIN = Me.tbPinCode.Text.Trim()
        CurrentUserInfo.PositionID = Me.cbPosition.SelectedValue
        CurrentUserInfo.Remark = Me.tbRemark.Text.Trim()
        CurrentUserInfo.WorkPhone = Me.tbExtension.Text.Trim()

    End Sub

    ''' <summary>
    ''' This is the method to validate data.
    ''' this logic copied from old system, but i think we can move this check to client side
    ''' we can check the data by javascript.
    ''' </summary>
    ''' <returns>Return if the data is valid or not.</returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean

        If Me.tbCode.Text = "" Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('User Code not null！');")
            Response.Write("</script>")
            Return False
        End If

        If Me.tbEName.Text = "" Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('E_Name not null！');")
            Response.Write("</script>")
            Return False
        End If

        If Me.tbCName.Text = "" Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('C_Name not null！');")
            Response.Write("</script>")
            Return False
        End If

        If Me.tbEmail.Text = "" Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Email not null！');")
            Response.Write("</script>")
            Return False
        End If


        'If Me.cbCity.SelectedValue = 0 Then
        '    Response.Write("<script language=javascript>")
        '    Response.Write("window.alert('City not null！');")
        '    Response.Write("</script>")
        '    Return False
        'End If

        'If Me.cbDepartment.SelectedValue = 0 Then
        '    Response.Write("<script language=javascript>")
        '    Response.Write("window.alert('Department not null！');")
        '    Response.Write("</script>")
        '    Return False
        'End If

        If Me.cbPosition.SelectedValue = 0 Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Position not null！');")
            Response.Write("</script>")
            Return False
        End If

        'If Me.ddlManager.SelectedValue = 0 Then
        '    Response.Write("<script language=javascript>")
        '    Response.Write("window.alert('Line manager not null！');")
        '    Response.Write("</script>")
        '    Return False
        'End If

        If Not Me.diCommDate.SelectedDate.HasValue Then
            Response.Write("<script language=javascript>")
            Response.Write("window.alert('Commencement Date not null！');")
            Response.Write("</script>")
            Return False
        End If
        Return True
    End Function
End Class
