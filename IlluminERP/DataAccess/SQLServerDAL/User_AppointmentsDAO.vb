Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components
Imports Utils

Namespace SQLServerDAL
    Friend Class User_AppointmentsDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_Appointments

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub
        ''' <summary>
        ''' Scheduler Info need add the information of 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSchedulerInfo() As System.Data.DataSet Implements IDAL.IUser_Appointments.GetSchedulerInfo
            Dim sql As String = "select * from [t_User_Appointments] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)
            Return ds
        End Function


        Public Function InsertUserAppointment(ByVal userAppointment As User_Appointments) As Boolean Implements IDAL.IUser_Appointments.InsertUserAppointment
            Try
                Dim sql As String = "INSERT INTO [t_User_Appointments] ([Subject], [Description], [Start], [End], [RecurrenceRule], [RecurrenceParentID], [Reminder],[UserID]) "
                sql += " VALUES ('{0}', '{1}', '{2}', '{3}' ,{4}, {5}, {6},{7})"
                sql = String.Format(sql, userAppointment.Subject, userAppointment.Description, userAppointment.StartDate, userAppointment.EndDate, vbNull, vbNull, vbNull, userAppointment.UserID)
                Me.ExecuteNonQuery(CommandType.Text, sql)
                Return True
            Catch ex As Exception
                Return False
            Finally
            End Try

        End Function



        Public Function DeleteUserAppointment(ByVal userAppointment As User_Appointments) As Boolean Implements IDAL.IUser_Appointments.DeleteUserAppointment
            Try
                Dim sql As String = "DELETE FROM [t_User_Appointments] WHERE ID={0}"
                sql = String.Format(sql, userAppointment.ID)
                Me.ExecuteNonQuery(CommandType.Text, sql)
                Return True
            Catch ex As Exception
                Return False
            Finally
            End Try

        End Function

        Public Function DeleteUserAppointmentByID(ByVal ID As String) As Boolean Implements IDAL.IUser_Appointments.DeleteUserAppointmentByID
            Try
                Dim sql As String = "DELETE FROM [t_User_Appointments] WHERE ID={0}"
                sql = String.Format(sql, ID)
                Me.ExecuteNonQuery(CommandType.Text, sql)
                Return True
            Catch ex As Exception
                Return False
            Finally
            End Try

        End Function


        Public Function UpdateUserAppointment(ByVal userAppointment As User_Appointments) As Boolean Implements IDAL.IUser_Appointments.UpdateUserAppointment
            Try
                Dim startDateParameter As SqlParameter = New SqlParameter("@Start", SqlDbType.DateTime)
                startDateParameter.Value = userAppointment.StartDate
                Dim endDateParameter As SqlParameter = New SqlParameter("@End", SqlDbType.DateTime)
                endDateParameter.Value = userAppointment.EndDate
                Dim idParameter As SqlParameter = New SqlParameter("@ID", SqlDbType.Int)
                idParameter.Value = userAppointment.ID
                Dim subjectParameter As New SqlParameter
                subjectParameter.ParameterName = "@Subject"
                subjectParameter.Value = userAppointment.Subject
                Dim descriptionParameter As New SqlParameter
                descriptionParameter.ParameterName = "@Description"
                descriptionParameter.Value = userAppointment.Description
                Dim sql As String = "Update [t_User_Appointments] SET [Subject]=@Subject, [Description]=@Description ,[Start] = @Start,[End] = @End where ID =@ID "
                sql = String.Format(sql, userAppointment.Subject, userAppointment.Description)
                Me.ExecuteNonQuery(CommandType.Text, sql, subjectParameter, descriptionParameter, startDateParameter, endDateParameter, idParameter)
                Return True
            Catch ex As Exception
                Return False
            Finally
            End Try

        End Function


        Public Function GetUserAppointmentByID(ByVal ID As String) As User_Appointments Implements IDAL.IUser_Appointments.GetUserAppointmentByID
            Dim userAppointment As New User_Appointments()
            Dim sql As String = "SELECT * FROM [t_User_Appointments] WHERE ID = {0}"
            sql = String.Format(sql, ID)
            Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, sql)
            If dr.Read Then
                'Info.Id = Convert.ToInt32(dr("Id"))
                userAppointment.ID = Int32.Parse(dr("ID"))
                userAppointment.Subject = dr("Subject").ToString()
                userAppointment.Description = dr("Description").ToString()
                userAppointment.UserID = dr("UserID").ToString()
                userAppointment.StartDate = Date.Parse(dr("StartDate").ToString())
                userAppointment.EndDate = Date.Parse(dr("EndDate").ToString())
                dr.Close()
                dr = Nothing
                Return userAppointment
            Else
                Return Nothing
            End If
        End Function

        Public Function GetScheduleList() As List(Of User_Appointments) Implements IUser_Appointments.GetScheduleList
            'Get appoinetments
            Dim strSQL = "select * from [t_User_Appointments] "


            Dim dr As SqlClient.SqlDataReader
            Try
                dr = Me.ExecuteReader(CommandType.Text, strSQL)
                Dim entityList As New List(Of User_Appointments)
                ColumnMappingManage.MappingListByDataReader(entityList, dr)
                Return entityList
            Catch ex As Exception
                Return Nothing
            Finally
                If (Not dr.IsClosed) Then
                    dr.Close()
                End If
            End Try
        End Function

    End Class
End Namespace
