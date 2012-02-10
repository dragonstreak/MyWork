
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IPMS_ProposalInfo

        ' Function GetProposalInfo() As DataSet

        Function GetProposalInfoByID(ByVal ID As Integer) As PMS_ProposalInfo

        'Function GetProposalInfobyJobNumber(ByVal strJobNumber As String) As PMS_ProposalInfo

        Function AddProposalInfo(ByVal info As Model.PMS_ProposalInfo) As Integer

        Function AddProposaladdonInfo(ByVal info As Model.PMS_ProposalInfo) As Integer

        Function GetProposallistByStatus(ByVal Status As String) As DataView

        Function UpdateProposalInfo(ByVal info As Model.PMS_ProposalInfo) As Boolean

        Function GetJobNumber(ByVal Info As Model.PMS_ProposalInfo) As String

        Function UpdateProjectStatus(ByVal info As Model.PMS_ProposalInfo) As Boolean

        Function GetProposallistByQueryInfo(ByVal QueryInfo As Model.PMS_ProposalInfo) As DataView

        Function GetProposallistByQueryString(ByVal QueryString As String) As DataView

        Function GetMyProposallistByUserId(ByVal UserId As String) As DataView

        ''' <summary>
        ''' this is the function for user to get proposal list by query filter.
        ''' </summary>
        ''' <param name="proposalQueryFilter">Pass the proposal query filter.</param>
        ''' <returns>Return proposal list dataset.</returns>
        ''' <remarks></remarks>
        Function GetProposalList(ByVal proposalQueryFilter As ProposalQueryFilter) As DataSet

        Function GetProRelationList(ByVal ProId As String) As DataView

    End Interface
End Namespace


