Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IUser_RoelModelFunction

        Function GetRoleModelFunctionInfoById(ByVal Id As Integer) As User_RoleModelFunction

        Function GetRoleModelFunctionInfoByRoleId(ByVal RoleId As Integer) As DataSet

        Function GetRoleModelFunctionInfoByModelFunctionId(ByVal ModelFunctionId As Integer) As DataSet

        Function AddRoleModelFunction(ByVal info As Model.User_RoleModelFunction) As Boolean

        Function DeleteRoleModelFunctionById(ByVal Id As Integer) As Boolean



    End Interface
End Namespace

