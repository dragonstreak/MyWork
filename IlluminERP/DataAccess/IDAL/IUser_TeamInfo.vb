
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IUser_TeamInfo

        Function AddTeamInfo(ByVal info As User_TeamInfo) As Boolean

        Function ModifyTeamInfo(ByVal info As User_TeamInfo) As Boolean


        Function GetTeamInfoById(ByVal Id As Integer) As User_TeamInfo

        Function GetTeamInfo() As DataSet

        Function GetTeamInfoByParentId(ByVal ParentId As Integer) As DataSet


        Function GetTeamInfoByTeamName(ByVal TeamName As String) As User_TeamInfo

        Function isTeamNameExist(ByVal TeamName As String, Optional ByVal excludeTeamId As Integer = -1) As Boolean

        Function GetTeamListByFilter(ByVal teamQueryFilter As TeamQueryFilter) As DataSet

        Function GetTeamLeaderId(ByVal teamId As Integer) As Integer

        Function GetTeamRoleByTeamId(ByVal teamId As Integer) As List(Of Integer)

        Function AssignRolesToTeam(ByVal teamId As Integer, ByVal roleList As List(Of Integer)) As Boolean

    End Interface


End Namespace
