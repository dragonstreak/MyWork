Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_ProposalRating
        Function GetProposalRatingInfo() As DataSet

        Function GetProposalRatingInfoById(ByVal ID As Integer) As Base_ProposalRating


    End Interface
End Namespace
