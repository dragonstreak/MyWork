Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class User_TeamGroupBLL
        Private factory As New DALFactory
        Private TeamGroupDAL As IUser_TeamGroup = factory.GetProduct("User_TeamGroupDAO")

        Public Function GetTeamGroupByGroupId(ByVal GroupId As Integer) As DataSet
            Return TeamGroupDAL.GetTeamGroupByGroupId(GroupId)
        End Function

        Public Function GetTeamGroupByTeamId(ByVal TeamId As Integer) As DataSet
            Return TeamGroupDAL.GetTeamGroupByTeamId(TeamId)
        End Function

        Public Function GetTeamGroupById(ByVal intId As Integer) As User_TeamGroup
            Return TeamGroupDAL.GetTeamGroupById(intId)
        End Function

        Public Function DeleteGroupTeam(ByVal Info As User_TeamGroup) As Boolean
            Return TeamGroupDAL.DeleteGroupTeam(Info)
        End Function

        Public Function AddTeamInGroup(ByVal info As User_TeamGroup) As Boolean
            Return TeamGroupDAL.AddTeamInGroup(info)
        End Function


    End Class
End Namespace
