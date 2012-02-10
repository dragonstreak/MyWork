

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL

    Friend Interface IUser_UserTeam

        Function AddUserInTeam(ByVal info As User_UserTeam) As Boolean


        Function GetUserTeamByTeamId(ByVal TeamId As Integer) As DataSet

        Function UpdateTeamLeader(ByVal Info As User_UserTeam) As Boolean

        Function DeleteTeamUser(ByVal Info As User_UserTeam) As Boolean

        Function GetTeamMemberIdListbyTeamId(ByVal teamId As Integer) As List(Of Integer)

    End Interface


End Namespace
