Namespace IDAL

    Public Interface IAppointments
        Property Id() As Integer
        Property Subject() As String
        Property StartDateTime() As Date?
        Property EndDateTime() As Date?
        Property Description() As String
        ReadOnly Property AppointmentType() As String
        ''' <summary>
        ''' Different module may has same id, so combined id will combine type+id, then it will be unique
        ''' So id of pms_projecttiming will like 'Timing_1'
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property CombinedId As String
    End Interface
End Namespace

