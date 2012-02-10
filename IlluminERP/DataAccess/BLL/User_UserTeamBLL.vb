Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class User_UserTeamBLL
        Private factory As New DALFactory
        Private UserTeamDal As IUser_UserTeam = factory.GetProduct("User_UserTeamDAO")

        Public Sub New()

        End Sub

        Public Function AddUserInTeam(ByVal info As User_UserTeam) As Boolean
            Return UserTeamDal.AddUserInTeam(info)
        End Function


        Public Function GetTeamInfoByTeamId(ByVal TeamId As Integer) As DataSet
            Return UserTeamDal.GetUserTeamByTeamId(TeamId)
        End Function


        Public Function UpdateTeamLeader(ByVal Info As User_UserTeam) As Boolean
            Return UserTeamDal.UpdateTeamLeader(Info)
        End Function

        Public Function DeleteTeamUser(ByVal info As User_UserTeam) As Boolean
            Return UserTeamDal.DeleteTeamUser(info)
        End Function

        Public Function GetTeamMemberIdListbyTeamId(ByVal teamId As Integer) As List(Of Integer)
            Return UserTeamDal.GetTeamMemberIdListbyTeamId(teamId)
        End Function

    End Class
End Namespace
