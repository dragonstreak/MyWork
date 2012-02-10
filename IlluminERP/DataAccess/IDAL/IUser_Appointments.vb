Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Public Interface IUser_Appointments
        ''' <summary>
        ''' Get All UserScheduler Data Recorder
        ''' </summary>
        ''' <returns>DataSet</returns>
        ''' <remarks></remarks>
        Function GetSchedulerInfo() As DataSet

        Function InsertUserAppointment(ByVal userAppointment As User_Appointments) As Boolean

        Function DeleteUserAppointment(ByVal userAppointment As User_Appointments) As Boolean

        Function UpdateUserAppointment(ByVal userAppoingment As User_Appointments) As Boolean

        Function GetUserAppointmentByID(ByVal ID As String) As User_Appointments

        Function DeleteUserAppointmentByID(ByVal ID As String) As Boolean

        Function GetScheduleList() As List(Of User_Appointments)

    End Interface
End Namespace

