
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL
    Public Class PMS_ProposalUserInfoBLL

        Private factory As New DALFactory
        Private ProposalUserInfoDAL As IPMS_ProposalUserInfo = factory.GetProduct("PMS_ProposalUserInfoDAO")

        Public Sub New()

        End Sub


        Public Function GetProposalUserinfoById(ByVal Id As Integer) As PMS_ProposalUserInfo
            Return ProposalUserInfoDAL.GetProposalUserinfoById(Id)
        End Function

        Public Function GetProposalUserinfoByTypeId(ByVal TypeId As Integer) As DataSet
            Return ProposalUserInfoDAL.GetProposalUserinfoByTypeId(TypeId)
        End Function

        Public Function GetProposalUserinfoByProId(ByVal ProId As Integer) As DataSet
            Return ProposalUserInfoDAL.GetProposalUserinfoByProId(ProId)
        End Function

        Public Function GetProposalUserinfoByProIdTypeId(ByVal Proid As Integer, ByVal TypeId As Integer) As DataSet
            Return ProposalUserInfoDAL.GetProposalUserinfoByProIdTypeId(Proid, TypeId)
        End Function

        Public Function AddProposalUserinfo(ByVal Info As PMS_ProposalUserInfo) As Boolean
            Return ProposalUserInfoDAL.AddProposalUserinfo(Info)
        End Function

        Public Function DeleteProposalUserInfo(ByVal Info As PMS_ProposalUserInfo) As Boolean
            Return ProposalUserInfoDAL.DeleteProposalUserInfo(Info)
        End Function

        Public Function UpdateProposaluserInfo(ByVal Info As PMS_ProposalUserInfo) As Boolean
            Return ProposalUserInfoDAL.UpdatePropoSaluserInfo(Info)
        End Function

        Public Function IsExistUserInfo(ByVal UserId As Integer, ByVal ProId As Integer) As Boolean
            Return ProposalUserInfoDAL.IsExistUserInfo(UserId, ProId)
        End Function

    End Class
End Namespace
