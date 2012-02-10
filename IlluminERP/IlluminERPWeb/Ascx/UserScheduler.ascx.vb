Imports System
Imports System.Data
Imports DataAccess.BLL
Imports DataAccess.Model
Imports DataAccess.IDAL
Partial Class Ascx_UserScheduler
    Inherits System.Web.UI.UserControl
    Private UserAppointmentsBLL As New User_AppointmentsBLL
    Dim userInfo As New User_UserInfo


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("LoginUserInfo") Is Nothing Then
            userInfo = Session("LoginUserInfo")
        End If

        If Not IsPostBack Then
            BindScheduler()
        End If
    End Sub

    Protected Sub BindScheduler()
        'Dim ds As DataSet
        'ds = UserAppointmentsBLL.GetSchedulerInfo()
        'If Not ds Is Nothing Then
        '    Utils.PageUtils.BindScheduler(ds, Me.RadScheduler1)
        'End If
        Dim appointmentList As List(Of IAppointments) = UserAppointmentsBLL.GetAllScheduleFromAllModule(userInfo.ID, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(7))
        Me.RadScheduler1.DataSource = appointmentList
        Me.RadScheduler1.DataBind()
        ViewState("AppointmentList") = appointmentList
        For Each app As Telerik.Web.UI.Appointment In Me.RadScheduler1.Appointments
            Dim combinedId As String = app.ID
            For Each appointment As IAppointments In appointmentList
                If appointment.CombinedId = combinedId Then
                    If appointment.AppointmentType <> "UserAppointment" Then
                        app.AllowDelete = False
                        app.AllowEdit = False
                    End If
                    Exit For
                End If
            Next
        Next
    End Sub

    Protected Sub RadScheduler1_AppointmentInsert(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerCancelEventArgs) Handles RadScheduler1.AppointmentInsert
        Dim userAppointment As New User_Appointments(e.Appointment.Subject, e.Appointment.Description, userInfo.ID, _
                                                     e.Appointment.Start, e.Appointment.End)
        If (UserAppointmentsBLL.InsertUserAppointment(userAppointment)) Then
            Me.RadScheduler1.Rebind()
        End If

    End Sub

    Protected Sub RadScheduler1_AppointmentDelete(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerCancelEventArgs) Handles RadScheduler1.AppointmentDelete
        Dim combinedId As String = e.Appointment.ID.ToString
        Dim appointmentList As List(Of IAppointments) = CType(ViewState("AppointmentList"), List(Of IAppointments))
        For Each appointment As IAppointments In appointmentList
            If appointment.CombinedId = combinedId Then
                If (UserAppointmentsBLL.DeleteUserAppointmentByID(appointment.Id.ToString)) Then
                    Me.RadScheduler1.Rebind()
                End If
                Exit For
            End If
        Next
        'If (UserAppointmentsBLL.DeleteUserAppointmentByID(e.Appointment.ID.ToString())) Then
        '    Me.RadScheduler1.Rebind()
        'End If

    End Sub

    Protected Sub RadScheduler1_AppointmentUpdate(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentUpdateEventArgs) Handles RadScheduler1.AppointmentUpdate
        Dim combinedId As String = e.Appointment.ID.ToString
        Dim appointmentList As List(Of IAppointments) = CType(ViewState("AppointmentList"), List(Of IAppointments))
        For Each appointment As IAppointments In appointmentList
            If appointment.CombinedId = combinedId Then
                Dim modifiedAppointment As Telerik.Web.UI.Appointment = e.ModifiedAppointment
                'Dim userAppointment As New User_Appointments(modifiedAppointment.Subject, modifiedAppointment.Description, appointment.Id.ToString, _
                '                                             modifiedAppointment.Start, modifiedAppointment.End)
                Dim userAppointment As User_Appointments = CType(appointment, User_Appointments)
                userAppointment.StartDate = modifiedAppointment.Start
                userAppointment.EndDate = modifiedAppointment.End
                userAppointment.Subject = modifiedAppointment.Subject
                userAppointment.Description = modifiedAppointment.Description
                If (UserAppointmentsBLL.UpdateUserAppointment(userAppointment)) Then
                    Me.RadScheduler1.DataSource = appointmentList
                    'Me.RadScheduler1.Rebind()
                End If
                Exit For
            End If
        Next
        'Dim userAppointment As New User_Appointments(e.Appointment.Subject, e.Appointment.Description, userInfo.ID, _
        '                                             e.Appointment.Start, e.Appointment.End)
        'If (UserAppointmentsBLL.UpdateUserAppointment(userAppointment)) Then
        '    Me.RadScheduler1.Rebind()
        'End If
    End Sub
End Class
