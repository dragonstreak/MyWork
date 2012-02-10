
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class User_RoleModelFunctionBLL
        Private factory As New DALFactory
        Private RoleModelFunctionDAL As IUser_RoelModelFunction = factory.GetProduct("User_RoleModelFunctionDAO")
        Public Sub New()

        End Sub

        Public Function GetRoleModelFunctionInfoById(ByVal Id As Integer) As User_RoleModelFunction
            Return RoleModelFunctionDAL.GetRoleModelFunctionInfoById(Id)
        End Function

        Public Function GetRoleModelFunctionInfoByRoleId(ByVal RoleId As Integer) As DataSet
            Return RoleModelFunctionDAL.GetRoleModelFunctionInfoByRoleId(RoleId)
        End Function

        Public Function GetRoleModelFunctionInfoByModelFunctionId(ByVal ModelFunctionId As Integer) As DataSet
            Return RoleModelFunctionDAL.GetRoleModelFunctionInfoByModelFunctionId(ModelFunctionId)
        End Function

        Public Function AddRoleModelFunction(ByVal info As Model.User_RoleModelFunction) As Boolean
            Return RoleModelFunctionDAL.AddRoleModelFunction(info)
        End Function

        Public Function DeleteRoleModelFunctionById(ByVal Id As Integer) As Boolean
            Return RoleModelFunctionDAL.DeleteRoleModelFunctionById(Id)
        End Function
    End Class

End Namespace
