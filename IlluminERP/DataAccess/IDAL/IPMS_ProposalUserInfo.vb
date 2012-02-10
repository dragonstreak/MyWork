
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL

    Friend Interface IPMS_ProposalUserInfo

        Function GetProposalUserinfoById(ByVal Id As Integer) As PMS_ProposalUserInfo

        Function GetProposalUserinfoByTypeId(ByVal TypeId As Integer) As DataSet

        Function GetProposalUserinfoByProId(ByVal ProId As Integer) As DataSet

        Function GetProposalUserinfoByProIdTypeId(ByVal Proid As Integer, ByVal TypeId As Integer) As DataSet

        Function AddProposalUserinfo(ByVal Info As PMS_ProposalUserInfo) As Boolean

        Function DeleteProposalUserInfo(ByVal Info As PMS_ProposalUserInfo) As Boolean

        Function UpdateProposaluserInfo(ByVal Info As PMS_ProposalUserInfo) As Boolean

        Function IsExistUserInfo(ByVal UserId As Integer, ByVal ProId As Integer) As Boolean

    End Interface
End Namespace
