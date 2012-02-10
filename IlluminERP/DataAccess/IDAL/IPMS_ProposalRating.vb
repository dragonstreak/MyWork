
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IPMS_ProposalRating
        Function GetProposalRatingInfoById(ByVal Id As Integer) As PMS_ProposalRatingInfo

        Function GetProposalRatingInfoByProId(ByVal ProId As Integer) As DataView

        Function AddProposalRatinginfo(ByVal Info As PMS_ProposalRatingInfo) As Boolean

        Function DeleteProposalRatinginfo(ByVal Info As PMS_ProposalRatingInfo) As Boolean

        Function UpdateProposalRatinginfo(ByVal Info As PMS_ProposalRatingInfo) As Boolean

        Function GetProposalRatingInfoByProidUserId(ByVal Proid As Integer, ByVal UserId As Integer) As Boolean
    End Interface
End Namespace

