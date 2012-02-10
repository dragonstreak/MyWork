Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Base_ProposalRatingBLL
        Private factory As New DALFactory
        Private ProposalRatingDAL As IBase_ProposalRating = factory.GetProduct("Base_ProposalRatingDAO")
        Public Sub New()

        End Sub

        Public Function GetProposalRatingInfo() As DataSet
            Return ProposalRatingDAL.GetProposalRatingInfo()
        End Function

        Public Function GetProposalRatingInfoById(ByVal Id As Integer) As Model.Base_ProposalRating
            Return ProposalRatingDAL.GetProposalRatingInfoById(Id)
        End Function
    End Class
End Namespace
