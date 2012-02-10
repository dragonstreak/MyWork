Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class User_RoleModelFunctionDAO
        Inherits BaseSqlServerDAO

        Implements DataAccess.IDAL.IUser_RoelModelFunction

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddRoleModelFunction(ByVal info As Model.User_RoleModelFunction) As Boolean Implements IDAL.IUser_RoelModelFunction.AddRoleModelFunction
            Try


                Dim strSql As String
                strSql = "Insert into t_User_RoleModelFunction (ModelFunctionId,isPermission,RoleId) Values("
                strSql += "'" + info.ModelFunctionID.ToString + "',"
                strSql += "'" + info.IsPermission.ToString + "',"
                strSql += "'" + info.RoleID.ToString + "')"
                strSql += " Select Id =@@Identity"
                Dim count As Integer
                count = ExecuteNonQuery(CommandType.Text, strSql)
                If count = 1 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function DeleteRoleModelFunctionById(ByVal Id As Integer) As Boolean Implements IDAL.IUser_RoelModelFunction.DeleteRoleModelFunctionById
            Dim strSql As String

            strSql = " Delete t_User_RoleModelFunction  "
            strSql += " Where Id ='" + CStr(Id) + "' "

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetRoleModelFunctionInfoById(ByVal Id As Integer) As Model.User_RoleModelFunction Implements IDAL.IUser_RoelModelFunction.GetRoleModelFunctionInfoById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = Id
            Dim sql As String = "select * from [t_User_RoleModelFunction] where ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As User_RoleModelFunction = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToRoleModelFunctionInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetRoleModelFunctionInfoByModelFunctionId(ByVal ModelFunctionId As Integer) As System.Data.DataSet Implements IDAL.IUser_RoelModelFunction.GetRoleModelFunctionInfoByModelFunctionId
            Dim paramModelFunctionId As New SqlParameter("@ModelFunctionId", SqlDbType.Int)
            paramModelFunctionId.Value = ModelFunctionId
            Dim sql As String = "select * from [t_User_RoleModelFunction] " & _
                                " where ModelFunctionId = @ModelFunctionId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramModelFunctionId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetRoleModelFunctionInfoByRoleId(ByVal RoleId As Integer) As System.Data.DataSet Implements IDAL.IUser_RoelModelFunction.GetRoleModelFunctionInfoByRoleId
            Dim paramRoleId As New SqlParameter("@RoleId", SqlDbType.Int)
            paramRoleId.Value = RoleId
            Dim sql As String = "select * from [t_User_RoleModelFunction] " & _
                                " where RoleId = @RoleId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramRoleId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function


        Private Function MapRowToRoleModelFunctionInfo(ByVal dr As DataRow) As User_RoleModelFunction
            Dim info As New User_RoleModelFunction

            info.ID = Convert.ToInt32(dr("ID"))
            info.RoleID = Convert.ToInt32(dr("RoleId"))
            info.ModelFunctionID = Convert.ToInt32(dr("ModelFunctionId"))
            info.IsPermission = Convert.ToInt32(dr("IsPermission"))
            Return info

        End Function

        Private Function GetParameters(ByVal info As User_RoleModelFunction) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@RoleId", SqlDbType.Int), _
                                                                    New SqlParameter("@ModelFunctionId", SqlDbType.Int), _
                                                                    New SqlParameter("@IsPermission", SqlDbType.Int)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.RoleId
            parameters(2).Value = info.ModelFunctionID
            parameters(3).Value = info.IsPermission

            Return parameters
        End Function

    End Class
End Namespace
