Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class User_AppointmentsBLL

        Private factory As New DALFactory
        Private User_AppointmentsDAL As IUser_Appointments = factory.GetProduct("User_AppointmentsDAO")
        Private timingBLL As New PMS_ProjectTimingBLL
        Public Sub New()

        End Sub

        Public Function GetSchedulerInfo() As DataSet
            Return User_AppointmentsDAL.GetSchedulerInfo()
        End Function

        Public Function InsertUserAppointment(ByVal userAppointment As User_Appointments) As Boolean
            Return User_AppointmentsDAL.InsertUserAppointment(userAppointment)
        End Function

        Public Function DeleteUserAppointment(ByVal userAppointment As User_Appointments) As Boolean
            Return User_AppointmentsDAL.DeleteUserAppointment(userAppointment)
        End Function

        Public Function UpdateUserAppointment(ByVal userAppointment As User_Appointments) As Boolean
            Return User_AppointmentsDAL.UpdateUserAppointment(userAppointment)
        End Function

        Public Function GetUserAppointmentByID(ByVal ID As String) As User_Appointments
            Return User_AppointmentsDAL.GetUserAppointmentByID(ID)
        End Function

        Public Function DeleteUserAppointmentByID(ByVal ID As String) As Boolean
            Return User_AppointmentsDAL.DeleteUserAppointmentByID(ID)
        End Function

        Public Function GetAllScheduleFromAllModule(ByVal userId As Integer, ByVal beginDate As Date?, ByVal endDate As Date?) As List(Of IAppointments)
            Dim scheduleList As New List(Of IAppointments)
            'Add userAppoinents
            Dim userAppointments As List(Of User_Appointments) = User_AppointmentsDAL.GetScheduleList()
            If Not userAppointments Is Nothing Then
                For Each appointment As User_Appointments In userAppointments
                    scheduleList.Add(appointment)
                Next
            End If
            
            'ProjectTiming
            Dim userProjectTimings As List(Of PMS_ProjectTiming) = timingBLL.GetUserPriodProjectTiming(userId, beginDate, endDate)
            If Not userProjectTimings Is Nothing Then
                For Each timing As PMS_ProjectTiming In userProjectTimings
                    scheduleList.Add(timing)
                Next
            End If
            Return scheduleList
        End Function
    End Class
End Namespace
