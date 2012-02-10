
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IPMS_ProposalUserType

        Function GetProposalUserTypeInfo() As DataSet

        Function GetProposalUserTypeInfoByID(ByVal ID As Integer) As PMS_ProposalUserType


    End Interface
End Namespace
