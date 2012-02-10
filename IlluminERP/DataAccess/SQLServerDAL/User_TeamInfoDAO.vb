Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class User_TeamInfoDAO

        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_TeamInfo



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub



        Private Function MapRowToUserInfo(ByVal dr As DataRow) As User_TeamInfo
            Dim info As New User_TeamInfo
            info.ID = Convert.ToInt32(dr("ID"))
            info.Code = dr("Code").ToString()

            If Not Convert.IsDBNull(dr("ParentID")) Then
                info.ParentID = Convert.ToInt32(dr("ParentID"))
            End If

            If Not Convert.IsDBNull(dr("SectorID")) Then
                info.SectorID = Convert.ToInt32(dr("SectorID"))
            End If

            If Not Convert.IsDBNull(dr("CityID")) Then
                info.CityID = Convert.ToInt32(dr("CityID"))
            End If


            If Not Convert.IsDBNull(dr("TeamName")) Then
                info.TeamName = dr("TeamName").ToString()
            End If

            If Not Convert.IsDBNull(dr("ParentTeamName")) Then
                info.ParentTeamName = dr("ParentTeamName").ToString()
            End If


            If Not Convert.IsDBNull(dr("TeamLeaderId")) Then
                info.TeamLeaderID = dr("TeamLeaderId").ToString()
            End If


            If Not Convert.IsDBNull(dr("City")) Then
                info.City = dr("City").ToString()
            End If

            If Not Convert.IsDBNull(dr("Sector")) Then
                info.Sector = dr("Sector").ToString()
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As User_TeamInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@Code", SqlDbType.Char), _
                                                                    New SqlParameter("@ParentID", SqlDbType.Int), _
                                                                    New SqlParameter("@CityID", SqlDbType.Int), _
                                                                    New SqlParameter("@SectorID", SqlDbType.Int), _
                                                                    New SqlParameter("@TeamLeaderID", SqlDbType.Int), _
                                                                    New SqlParameter("@TeamName", SqlDbType.VarChar)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.Code
            parameters(2).Value = info.ParentID
            parameters(3).Value = info.CityID
            parameters(4).Value = info.SectorID
            parameters(5).Value = info.TeamLeaderID
            parameters(6).Value = info.TeamName

            Return parameters
        End Function

        Public Function GetTeamInfoById(ByVal Id As Integer) As Model.User_TeamInfo Implements IDAL.IUser_TeamInfo.GetTeamInfoById
            Dim paramTeamID As New SqlParameter("@ID", SqlDbType.Char)
            paramTeamID.Value = Id
            Dim sql As String = "select t.*, pt.TeamName as ParentTeamName,u.E_Name as TeamLeaderName,city.City, sector.Sector,t.teamleaderid as teamleaderid  from [t_User_Team] t "
            sql += "left Join t_user_team pt on pt.ID = t.parentID "
            sql += "left Join t_user_userinfo u on u.ID = t.teamleaderID "
            sql += "left Join t_base_city city on city.ID = t.cityID "
            sql += "Join t_base_Sector sector on sector.ID = t.sectorID "
            sql += " where t.ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramTeamID)
            Dim info As User_TeamInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToUserInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetTeamInfoByParentId(ByVal ParentId As Integer) As System.Data.DataSet Implements IDAL.IUser_TeamInfo.GetTeamInfoByParentId
            Dim paramParentId As New SqlParameter("@ParentID", SqlDbType.Int)
            paramParentId.Value = ParentId
            Dim sql As String = "select * from [t_User_Team] where ParentID = @ParentID Order by TeamName"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramParentId)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function ModifyTeamInfo(ByVal info As Model.User_TeamInfo) As Boolean Implements IDAL.IUser_TeamInfo.ModifyTeamInfo
            Dim strSql As String

            strSql = " Update t_User_Team set "
            strSql += "Code='" + info.Code.ToString + "'"
            strSql += ",ParentID='" + info.ParentID.ToString + "'"
            strSql += ",CityID='" + info.CityID.ToString + "'"
            strSql += ",SectorID='" + info.SectorID.ToString + "'"
            strSql += ",TeamLeaderID='" + info.TeamLeaderID.ToString + "'"
            strSql += ",TeamName='" + info.TeamName.ToString + "'"
            strSql += " Where Id ='" + info.ID.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)

                If info.TeamMemberIdList IsNot Nothing AndAlso info.TeamMemberIdList.Count > 0 Then
                    strSql = "delete from t_user_userteam where teamID = " + info.ID.ToString
                    ExecuteNonQuery(CommandType.Text, strSql)

                    strSql = "Insert into t_user_userteam(UserID,TeamID,IsTeamLeader) Values({0},{1},0)"
                    For Each memberId As Integer In info.TeamMemberIdList
                        ExecuteNonQuery(String.Format(strSql, memberId, info.ID))
                    Next

                    'set team leader
                    If info.TeamLeaderID > 0 Then
                        strSql = "update t_user_userteam set IsTeamLeader = 1 where userID = {0} and teamID = {1}"
                        ExecuteNonQuery(String.Format(strSql, info.TeamLeaderID, info.ID))
                    End If
                End If

                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function AddTeamInfo(ByVal info As Model.User_TeamInfo) As Boolean Implements IDAL.IUser_TeamInfo.AddTeamInfo
            Dim sql As String
            Try
                sql = "select MAX(ID) AS Expr1 from t_User_Team"
                Dim newid As Integer
                Dim o As Object
                o = ExecuteScalar(sql)
                If IsDBNull(o) Then
                    newid = 1
                Else
                    newid = Convert.ToInt32(o) + 1
                End If
                info.ID = newid

                Dim strSql As String
                strSql = "Insert into t_user_Team (Id,Code,ParentID,CityID,SectorID,TeamleaderId,TeamName) Values("
                strSql += "'" + info.ID.ToString + "',"
                strSql += "'" + info.Code.ToString + "',"
                strSql += "'" + info.ParentID.ToString + "',"
                strSql += "'" + info.CityID.ToString + "',"
                strSql += "'" + info.SectorID.ToString + "',"
                strSql += "'" + info.TeamLeaderID.ToString + "',"
                strSql += "'" + info.TeamName.ToString + "')"

                ExecuteNonQuery(CommandType.Text, strSql)

                If info.TeamMemberIdList IsNot Nothing AndAlso info.TeamMemberIdList.Count > 0 Then
                    strSql = "Insert into t_user_userteam(UserID,TeamID,IsTeamLeader) Values({0},{1},0)"
                    For Each memberId As Integer In info.TeamMemberIdList
                        ExecuteNonQuery(String.Format(strSql, memberId, info.ID))
                    Next

                    'set team leader
                    If info.TeamLeaderID > 0 Then
                        strSql = "update t_user_userteam set IsTeamLeader = 1 where userID = {0} and teamID = {1}"
                        ExecuteNonQuery(String.Format(strSql, info.TeamLeaderID, info.ID))
                    End If
                End If

                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetTeamInfo() As System.Data.DataSet Implements IDAL.IUser_TeamInfo.GetTeamInfo

            Dim sql As String = "select t.*, pt.TeamName as ParentTeamName,u.E_Name as TeamLeaderName,city.City, sector.Sector from [t_User_Team] t "
            sql += "left Join t_user_team pt on pt.ID = t.parentID "
            sql += "left Join t_user_userinfo u on u.ID = t.teamleaderID "
            sql += "left Join t_base_city city on city.ID = t.cityID "
            sql += "Join t_base_Sector sector on sector.ID = t.sectorID "
            sql += " Order by t.TeamName"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Public Function GetTeamInfoByTeamName(ByVal strTeamName As String) As Model.User_TeamInfo Implements IDAL.IUser_TeamInfo.GetTeamInfoByTeamName
            Dim paramTeamName As New SqlParameter("@TeamName", SqlDbType.Char)
            paramTeamName.Value = strTeamName
            Dim sql As String = "select t.*, pt.TeamName as ParentTeamName,u.E_Name as TeamLeaderName,city.City, sector.Sector from [t_User_Team] t "
            sql += "left Join t_user_team pt on pt.ID = t.parentID "
            sql += "left Join t_user_userinfo u on u.ID = t.teamleaderID "
            sql += "left Join t_base_city city on city.ID = t.cityID "
            sql += "Join t_base_Sector sector on sector.ID = t.sectorID "
            sql += "Where t.TeamName = @TeamName"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramTeamName)
            Dim info As User_TeamInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToUserInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        
        Public Function isTeamNameExist(ByVal TeamName As String, Optional ByVal excludeTeamId As Integer = -1) As Boolean Implements IDAL.IUser_TeamInfo.isTeamNameExist

            Dim paramTeamName As SqlParameter = New SqlParameter("@TeamName", SqlDbType.Char)
            paramTeamName.Value = TeamName

            Dim strSql As String = "select * from [t_User_Team] where teamName = @TeamName"
            If excludeTeamId <> -1 Then
                strSql += " and ID != " + excludeTeamId.ToString()
            End If
            Dim count As Integer = 0
            count = Me.ExecuteScalar(CommandType.Text, strSql, paramTeamName)
            If count = 1 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function GetTeamListByFilter(ByVal teamQueryFilter As TeamQueryFilter) As System.Data.DataSet Implements IDAL.IUser_TeamInfo.GetTeamListByFilter
            Dim strSql As String = "select t.*,pt.TeamName as ParentTeamName,u.E_Name as TeamLeaderName, sector.Sector from [t_User_Team] t "
            strSql += "left Join t_user_team pt on pt.ID = t.parentID "
            strSql += "left Join t_user_userinfo u on u.ID = t.teamleaderID "
            strSql += "Join t_base_Sector sector on sector.ID = t.sectorID "
            strSql += " where 1 = 1 "
            'strSql += " and (@TeamName = '' or t.TeamName like '%'+@TeamName+'%')"
            ' strSql += " and (@ParentId=0 or @ParentId=t.ParentId)"
            ' strSql += " and (@SectorId=0 or @SectorId=t.SectorId)"

            Dim parameters() As SqlParameter = {
           New SqlParameter("@TeamName", teamQueryFilter.TeamName),
           New SqlParameter("@ParentId", teamQueryFilter.ParentID),
           New SqlParameter("@SectorId", teamQueryFilter.SectorID)}

            Dim dsTeamList As DataSet = Me.ExecuteDataSet(strSql, parameters)
            Return dsTeamList
        End Function

        Public Function GetTeamLeaderId(ByVal teamId As Integer) As Integer Implements IUser_TeamInfo.GetTeamLeaderId
            Dim strSql As String = "select UserID from t_user_userteam where IsTeamLeader = 1 and teamId =" + teamId.ToString()

            Dim dsLeader As DataSet
            dsLeader = ExecuteDataSet(strSql)

            If dsLeader IsNot Nothing AndAlso dsLeader.Tables(0).Rows.Count > 0 Then
                Return Integer.Parse(dsLeader.Tables(0).Rows(0)("UserID"))
            Else
                Return Utils.ConstantsUtils.NullInteger
            End If

        End Function

        Public Function GetTeamRoleByTeamId(ByVal teamId As Integer) As List(Of Integer) Implements IUser_TeamInfo.GetTeamRoleByTeamId
            Dim strSql As String
            strSql = "select RoleID from t_user_teamrole where TeamID = " + teamId.ToString()
            Dim dsRole As DataSet
            dsRole = ExecuteDataSet(strSql)

            If dsRole IsNot Nothing AndAlso dsRole.Tables(0).Rows.Count > 0 Then
                Dim roleIdList As New List(Of Integer)
                For Each dr As DataRow In dsRole.Tables(0).Rows
                    roleIdList.Add(Integer.Parse(dr("RoleID")))
                Next
                Return roleIdList
            Else
                Return Nothing
            End If
        End Function

        Public Function AssignRolesToTeam(ByVal teamId As Integer, ByVal roleList As List(Of Integer)) As Boolean Implements IUser_TeamInfo.AssignRolesToTeam
            If roleList Is Nothing OrElse roleList.Count = 0 Then
                Return True
            End If
            Dim strSqlTemp As String
            strSqlTemp = "insert into t_user_teamrole(TeamID,RoleID) values({0},{1}) {2}"
            Dim strSql As String = String.Empty
            For Each roleId As Integer In roleList
                strSql += String.Format(strSqlTemp, teamId, roleId, vbNewLine)
            Next

            Dim strDel As String = "delete from t_user_teamrole where TeamID = " + teamId.ToString()
            Try

                ExecuteNonQuery(strDel)
                ExecuteNonQuery(strSql)
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

    End Class
End Namespace
