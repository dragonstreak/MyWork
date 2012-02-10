

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IUser_TeamGroup

        Function GetTeamGroupByGroupId(ByVal GroupId As Integer) As DataSet

        Function GetTeamGroupByTeamId(ByVal TeamId As Integer) As DataSet

        Function GetTeamGroupById(ByVal intId As Integer) As User_TeamGroup

        Function DeleteGroupTeam(ByVal Info As User_TeamGroup) As Boolean

        Function AddTeamInGroup(ByVal info As User_TeamGroup) As Boolean

    End Interface
End Namespace
