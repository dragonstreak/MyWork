Public Class ConstantsUtils
    Public Shared MinDate As New DateTime(1800, 1, 1)

    Public Shared MaxDate As New DateTime(2999, 12, 31)

    Public Shared INITSickLeaveEntitle As Integer = 10

    Public Shared DMRole As String = "Line Manager"

    Public Shared DirectorRole As String = "Director"

    Public Shared FinanDirectorRole As String = "Finance Director"

    Public Shared AccManagerRole As String = "Accountant Manager"

    Public Shared AccountantRole As String = "Accountant"

    Public Shared CMRManagerRole As String = "CMR PM/RM"

    Public Shared CMRDirectorRole As String = "CMR Director"

    Public Shared PermissionRootName As String = "Illumin ERP"

    Public Shared PermissionRootValue As String = "0"

    Public Shared NullInteger As Integer = -1

    Public Shared NullDateTime As DateTime = New DateTime(1900, 1, 1, 0, 0, 0)

    Public Enum CompanyCode
        TNS = 78
        RI = 80
    End Enum

    Public Enum ClientType
        InternalClient = 1
        ExternalClient = 2
        ExternalClientForInternal = 3
    End Enum

    Public Enum ProjectStatus
        pending = 1
        Proposal = 2
        Project = 3
        Cancellaiton = 4
        Reject = 5
        Closed = 9
    End Enum

    Public Enum MethodologyType
        Quanti = 1
        Quali = 2
    End Enum

    Public Enum QuantiRecruitmentType
        SamplingMethod = 7
        Lengthofquestionnaire = 8
        NOofOEQ = 9
        ProjectScope = 10
        DataFormat = 11
        DataMap = 12

    End Enum

    Public Enum QualiRecruitmentType
        Clientlist = 1
        Transcriptneeded = 2
        Audiotaperecordingneeded = 3
        Videotaperecordingneeded = 4
        Videoformat = 5
        Translatorrequire = 6
    End Enum

    Public Enum CriteriaType
        ACarOwnerShip = 1
        ACarSegment = 2
        APricinglevel = 3
        BNumberofEmployee = 4
        BPosition = 5
        CAge = 6
        CGender = 7
        CMonthHHIncome = 8
        CProductusagefrequency = 9
        CRole = 10
        FMarket = 11
        HDegree = 12
        HJobTitle = 13
        TNumberofemployee = 14
        TJobTitle = 15
        TRole = 16
        TOwnership = 17
    End Enum

    Public Enum Sector
        Automotive = 1
        Business = 2
        Consumer = 3
        Finance = 4
        Healthcare = 5
        Technology = 6
    End Enum

    Public Enum Department
        CMR = 1
        EDP = 2
        FLW = 3
        QC = 4
        FIN = 5
        CATI = 6
        ADMIN = 7
        HR = 8
    End Enum

    <EnumText("Invalid", "Valid")>
    Public Enum IsValidEnum
        None = -1
        NotIsValid = 0
        IsValid = 1
    End Enum

    <EnumText("Disable", "Enable")>
    Public Enum IsEnableEnum
        None = -1
        Disable = 0
        Enable = 1
    End Enum

    <EnumText("No", "Yes")>
    Public Enum YesNoEnum
        None = -1
        No = 0
        Yes = 1
    End Enum

    Public Enum PageOperationEnum
        None = -1
        Unknow = 0
        Add = 1
        Update = 2
        Query = 3
    End Enum


    Public Enum PermissionKindEnum
        None = -1
        Menu = 1
        DividingLine = 2
        FunctionPoint = 3
    End Enum

    <EnumText("News Type", "News Range")>
    Public Enum ListItemTypeEnum
        None = -1
        NewsType = 1
        NewsRange = 2
    End Enum

    <EnumText("Common", "Urgent")>
    Public Enum NewsSeverityEnum
        None = -1
        Common = 1
        Urgent = 2
    End Enum

    Public Enum UploadFileModuleEnum
        None = -1
        News = 1
    End Enum

End Class

