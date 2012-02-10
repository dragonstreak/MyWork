Imports Utils
Imports DataAccess.IDAL

Namespace Model

    <Serializable()>
    Public Class User_Appointments
        Implements IAppointments

        Private _ID As Integer
        Private _Subject As String
        Private _StartDate As Date
        Private _EndDate As Date
        Private _UserID As Integer
        Private _Ammotations As String
        Private _Description As String

        'ID
        <ColumnMapping("ID")> _
        Public Property ID() As Integer Implements IAppointments.Id
            Get
                Return _ID
            End Get
            Set(ByVal Value As Integer)
                _ID = Value
            End Set
        End Property
        'Subject
        <ColumnMapping("Subject")> _
        Public Property Subject() As String Implements IAppointments.Subject
            Get
                Return _Subject
            End Get
            Set(ByVal value As String)
                _Subject = value
            End Set
        End Property
        'StartDate
        <ColumnMapping("Start")> _
        Public Property StartDate() As Date
            Get
                Return _StartDate
            End Get
            Set(ByVal value As Date)
                _StartDate = value
            End Set
        End Property
        <ColumnMapping("End")> _
        Public Property EndDate() As Date
            Get
                Return _EndDate
            End Get
            Set(ByVal value As Date)
                _EndDate = value
            End Set
        End Property
        <ColumnMapping("UserID")> _
        Public Property UserID() As Integer
            Get
                Return _UserID
            End Get
            Set(ByVal value As Integer)
                _UserID = value
            End Set
        End Property
        <ColumnMapping("Annotations")> _
        Public Property Ammotations() As String
            Get
                Return _Ammotations
            End Get
            Set(ByVal value As String)
                _Ammotations = value
            End Set
        End Property
        <ColumnMapping("Description")> _
        Public Property Description() As String Implements IAppointments.Description
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property


        Public Sub New(ByVal strSubject As String, ByVal strDescription As String, ByVal strUserID As String, _
                       ByVal dStartDate As Date, ByVal dEndDate As Date)
            _Subject = strSubject
            _Description = strDescription
            _UserID = strUserID
            _StartDate = dStartDate
            _EndDate = dEndDate
        End Sub

        Public Sub New()

        End Sub

        Public Property StartDateTime() As Date? Implements IAppointments.StartDateTime
            Get
                Return CType(StartDate, Date?)
            End Get
            Set(ByVal value As Date?)
                StartDate = value.Value
            End Set
        End Property
        Public Property EndDateTime() As Date? Implements IAppointments.EndDateTime
            Get
                Return CType(EndDate, Date?)
            End Get
            Set(ByVal value As Date?)
                EndDate = value.Value
            End Set
        End Property
        Public ReadOnly Property AppointmentType() As String Implements IAppointments.AppointmentType
            Get
                Return "UserAppointment"
            End Get
        End Property
        Public ReadOnly Property CombinedId() As String Implements IAppointments.CombinedId
            Get
                Return "UserAppointment_" + ID.ToString
            End Get
        End Property
    End Class

End Namespace
