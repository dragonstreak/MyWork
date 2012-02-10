Imports Utils
Public Class ProposalQueryFilter
    Private _projectStatus As String
    Private _jobNumber As String
    Private _jobName As String
    Private _clientName As String
    Private _researchName As String
    Private _managerName As String
    <Filter("Proposalinfo.Status", "@Status", "", "-1", ColumnType.IntColumn, MatchType.Equals)>
    Public Property ProjectStatus() As String
        Get
            Return _projectStatus
        End Get
        Set(ByVal Value As String)
            _projectStatus = Value
        End Set
    End Property
    <Filter("Proposalinfo.JobName", "@JobNumber", "", MatchType.Likes)>
    Public Property JobNumber() As String
        Get
            Return _jobNumber

        End Get
        Set(ByVal value As String)
            _jobNumber = value
        End Set
    End Property
    <Filter("Proposalinfo.JobNumber", "@JobName", "", MatchType.Likes)>
    Public Property JobName() As String
        Get
            Return _jobName
        End Get
        Set(ByVal value As String)
            _jobName = value
        End Set
    End Property
    <Filter("ClientInfo.C_Name,ClientInfo.E_Name", "@ClientName", "", MatchType.Likes)>
    Public Property ClientName() As String
        Get
            Return _clientName
        End Get
        Set(ByVal value As String)
            _clientName = value
        End Set
    End Property

    Public Property ResearchName() As String
        Get
            Return _researchName
        End Get
        Set(ByVal value As String)
            _researchName = value
        End Set
    End Property
    Public Property ManagerName() As String
        Get
            Return _managerName
        End Get
        Set(ByVal value As String)
            _managerName = value
        End Set
    End Property

End Class
