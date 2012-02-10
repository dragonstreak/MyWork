

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class PMS_ProposalUserTypeBLL

        Private factory As New DALFactory
        Private ProposalUserTypeBLl As IPMS_ProposalUserType = factory.GetProduct("PMS_ProposalUserTypeDAO")

        Public Sub New()

        End Sub

        Public Function GetProposalUserTypeInfo() As DataSet
            Return ProposalUserTypeBLl.GetProposalUserTypeInfo()
        End Function

        Public Function GetProposalUserTypeInfoByID(ByVal Id As Integer) As Model.PMS_ProposalUserType
            Return ProposalUserTypeBLl.GetProposalUserTypeInfoByID(Id)
        End Function


    End Class
End Namespace
