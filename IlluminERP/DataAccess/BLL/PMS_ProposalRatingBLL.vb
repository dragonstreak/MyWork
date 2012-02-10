
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class PMS_ProposalRatingBLL
        Private factory As New DALFactory
        Private ProRatingBLL As IPMS_ProposalRating = factory.GetProduct("PMS_ProposalRatingDAO")

        Public Sub New()

        End Sub

        Public Function GetProposalRatingInfoById(ByVal Id As Integer) As PMS_ProposalRatingInfo
            Return ProRatingBLL.GetProposalRatingInfoById(Id)
        End Function

        Public Function GetProposalRatingInfoByProId(ByVal ProId As Integer) As DataView
            Return ProRatingBLL.GetProposalRatingInfoByProId(ProId)
        End Function



        Public Function AddProposalRatinginfo(ByVal Info As PMS_ProposalRatingInfo) As Boolean
            Return ProRatingBLL.AddProposalRatinginfo(Info)
        End Function

        Public Function DeleteProposalRatinginfo(ByVal Info As PMS_ProposalRatingInfo) As Boolean
            Return ProRatingBLL.DeleteProposalRatinginfo(Info)
        End Function

        Public Function UpdateProposalRatinginfo(ByVal Info As PMS_ProposalRatingInfo) As Boolean
            Return ProRatingBLL.UpdateProposalRatinginfo(Info)
        End Function
        Public Function GetProposalRatingInfoByProidUserId(ByVal Proid As Integer, ByVal UserId As Integer) As Boolean
            Return ProRatingBLL.GetProposalRatingInfoByProidUserId(Proid, UserId)
        End Function
    End Class
End Namespace
