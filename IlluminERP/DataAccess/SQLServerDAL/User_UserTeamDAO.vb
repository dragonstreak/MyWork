Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class User_UserTeamDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_UserTeam



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function AddUserInTeam(ByVal info As Model.User_UserTeam) As Boolean Implements IDAL.IUser_UserTeam.AddUserInTeam

            Try


                Dim strSql As String
                strSql = "Insert into t_user_UserTeam (TeamId,UserID,IsTeamLeader,TeamLevel) Values("
                strSql += "'" + info.TeamID.ToString + "',"
                strSql += "'" + info.UserID.ToString + "',"
                strSql += "'" + "0" + "',"
                strSql += "'" + info.TeamLevel.ToString + "')"
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

        Public Function GetUserTeamByTeamId(ByVal TeamId As Integer) As System.Data.DataSet Implements IDAL.IUser_UserTeam.GetUserTeamByTeamId
            Dim paramTeamId As New SqlParameter("@teamID", SqlDbType.Int)
            paramTeamId.Value = TeamId
            Dim sql As String = "select a.id as Id,a.IsTeamLeader as IsTamLeader,a.UserId as UserID,a.teamID as TeamID,(b.code + ','+ C_Name) as E_Name from [t_User_UserTeam] a, t_User_UserInfo b " & _
                                " where a.UserId=b.id  and a.TeamId = @teamID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramTeamId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Private Function MapRowToUserInfo(ByVal dr As DataRow) As User_UserTeam
            Dim info As New User_UserTeam

            info.ID = Convert.ToInt32(dr("ID"))
            info.TeamID = Convert.ToInt32(dr("TeamId"))
            info.TeamID = Convert.ToInt32(dr("UserId"))
            If Not Convert.IsDBNull(dr("TeamLevel")) Then
                info.TeamLevel = Convert.ToInt32(dr("TeamLevel"))
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As User_UserTeam) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@UserId", SqlDbType.Int), _
                                                                    New SqlParameter("@TeamId", SqlDbType.Int), _
                                                                    New SqlParameter("@IsTeamLeader", SqlDbType.Int), _
                                                                    New SqlParameter("@TeamLevel", SqlDbType.Int)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.UserID
            parameters(2).Value = info.TeamID
            parameters(3).Value = info.IsTeamLeader
            parameters(4).Value = info.TeamLevel

            Return parameters
        End Function

        Public Function DeleteTeamUser(ByVal info As User_UserTeam) As Boolean Implements IDAL.IUser_UserTeam.DeleteTeamUser
            Dim strSql As String

            strSql = " Delete t_User_UserTeam  "
            strSql += " Where Teamid ='" + info.TeamID.ToString + "' and  UserId='" + info.UserID.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function UpdateTeamLeader(ByVal Info As User_UserTeam) As Boolean Implements IDAL.IUser_UserTeam.UpdateTeamLeader
            Dim factory As New SqlServerFactory
            Dim strSql As String
            factory.BeginTransaction()

           

            Try


                strSql = " Update t_User_UserTeam set "
                strSql += "IsTeamLeader='" + "0" + "'"
                strSql += " Where TeamId ='" + Info.TeamID.ToString + "' "

                ExecuteNonQuery(CommandType.Text, strSql)

                strSql = " Update t_User_UserTeam set "
                strSql += "IsTeamLeader='" + "1" + "'"
                strSql += " Where Userid ='" + Info.UserID.ToString + "' and TeamId='" + Info.TeamID.ToString + "'"

                ExecuteNonQuery(CommandType.Text, strSql)



                factory.Commit()

                Return True
            Catch ex As Exception
                factory.Rollback()
                Return False

            End Try
        End Function

        Public Function GetTeamMemberIdListbyTeamId(ByVal teamId As Integer) As List(Of Integer) Implements IUser_UserTeam.GetTeamMemberIdListbyTeamId
            Dim strSql As String
            strSql = "Select UserID from t_user_userteam where teamid = " + teamId.ToString()
            Dim dsUserID As DataSet
            dsUserID = ExecuteDataSet(CommandType.Text, strSql)
            If dsUserID IsNot Nothing AndAlso dsUserID.Tables(0).Rows.Count > 0 Then
                Dim userIDList As New List(Of Integer)
                For Each dr As DataRow In dsUserID.Tables(0).Rows
                    userIDList.Add(Integer.Parse(dr("UserID")))
                Next
                Return userIDList
            Else
                Return Nothing
            End If

        End Function


    End Class
End Namespace

