
Namespace Model.Enum

    ' this enum match the value of DB table t_Base_ProjectStatus
    ' if change it , need also change DB record, otherwise if DB change this enum also need change
    Public Enum ProjectStatus
        UnKnow = 0
        Proposal = 1
        OnHold = 2
        Dead = 3
        Confirmed = 4
        Pending = 6
        Setup = 7
        FW = 8
        DP = 9
        Reporting = 10
        Presentation = 11
        Completion = 12
        Closed = 13
    End Enum
End Namespace
