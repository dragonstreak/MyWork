Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class User_TeamInfoBLL
        Private factory As New DALFactory
        Private TeamInfoDal As IUser_TeamInfo = factory.GetProduct("User_TeamInfoDAO")
        Private UserInfoDal As IUser_UserInfo = factory.GetProduct("UserInfoDAO")
        Private UserTeamDal As IUser_UserTeam = factory.GetProduct("User_UserTeamDAO")

        Public Sub New()

        End Sub


        Public Function AddTeamInfo(ByVal info As User_TeamInfo) As Boolean
            Return TeamInfoDal.AddTeamInfo(info)
        End Function

        Public Function ModifyTeamInfo(ByVal info As User_TeamInfo) As Boolean
            Return TeamInfoDal.ModifyTeamInfo(info)
        End Function


        Public Function GetTeamInfoById(ByVal Id As Integer) As Model.User_TeamInfo
            Dim team As User_TeamInfo = Nothing
            team = TeamInfoDal.GetTeamInfoById(Id)
            If team IsNot Nothing Then
                team.TeamMemberIdList = UserTeamDal.GetTeamMemberIdListbyTeamId(Id)
                team.TeamLeader = GetTeamLeaderInfo(Id)
                team.RoleIdList = GetTeamRoleByTeamId(Id)
            End If
            Return team

        End Function


        Public Function GetTeamInfoByParentId(ByVal ParentId As Integer) As DataSet
            Return TeamInfoDal.GetTeamInfoByParentId(ParentId)
        End Function


        Public Function GetTeamInfo() As DataSet

            Return TeamInfoDal.GetTeamInfo
        End Function

        Public Function GetTeamInfoByTeamName(ByVal TeamName As String) As Model.User_TeamInfo
            Dim team As User_TeamInfo = Nothing
            team = TeamInfoDal.GetTeamInfoByTeamName(TeamName)
            If team IsNot Nothing Then
                team.TeamMemberIdList = UserTeamDal.GetTeamMemberIdListbyTeamId(team.ID)
                team.TeamLeader = GetTeamLeaderInfo(team.ID)
                team.RoleIdList = GetTeamRoleByTeamId(team.ID)
            End If
            Return team

        End Function

        Public Function isTeamNameExist(ByVal TeamName As String, Optional ByVal excludeTeamId As Integer = -1) As Boolean
            Return TeamInfoDal.isTeamNameExist(TeamName, excludeTeamId)
        End Function

        Public Function GetTeamListByFilter(ByVal teamQueryFilter As TeamQueryFilter) As DataSet
            Return TeamInfoDal.GetTeamListByFilter(teamQueryFilter)
        End Function

        Public Function GetTeamLeaderInfo(ByVal teamId As Integer) As User_UserInfo
            Dim leaderId As Integer = TeamInfoDal.GetTeamLeaderId(teamId)
            If leaderId <> Utils.ConstantsUtils.NullInteger Then
                Dim UserInfoBLL As New UserInfoBLL
                Return UserInfoBLL.GetUserInfoById(leaderId)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetTeamRoleByTeamId(ByVal teamId As Integer) As List(Of Integer)
            Return TeamInfoDal.GetTeamRoleByTeamId(teamId)
        End Function

        Public Function AssignRolesToTeam(ByVal teamId As Integer, ByVal roleList As List(Of Integer)) As Boolean
            Return TeamInfoDal.AssignRolesToTeam(teamId, roleList)
        End Function

    End Class
End Namespace
