Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components
Imports System.Linq

Imports System.Collections.Generic


Namespace SQLServerDAL
    Friend Class UserInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_UserInfo



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function IsUserExist(ByVal userCode As String, ByVal pwd As String) As Boolean Implements IUser_UserInfo.IsUserExist
            Dim paramUserCode As SqlParameter = New SqlParameter("@Code", SqlDbType.Char)
            paramUserCode.Value = userCode
            Dim paramPwd As SqlParameter = New SqlParameter("@Password", SqlDbType.Char)
            paramPwd.Value = pwd
            Dim strSql As String = "select count(0) from  t_User_UserInfo where Code= @Code and Password = @Password "
            Dim count As Integer = 0
            count = Me.ExecuteScalar(CommandType.Text, strSql, paramUserCode, paramPwd)
            If count = 1 Then
                Return True
            Else
                Return False
            End If

        End Function

        Public Function GetUserInfoByUserCode(ByVal strUSerCode As String) As User_UserInfo Implements IUser_UserInfo.GetUserInfoByUserCode

            Dim paramUserCode As New SqlParameter("@Code", SqlDbType.Char)
            paramUserCode.Value = strUSerCode
            Dim sql As String = "select * from [t_User_UserInfo] where Code = @Code order by Code"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramUserCode)
            Dim info As User_UserInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToUserInfo(ds.Tables(0).Rows(0))
            End If
            Return info

        End Function


        Public Function GetUserInfoById(ByVal Id As Integer) As Model.User_UserInfo Implements IDAL.IUser_UserInfo.GetUserInfoById
            Dim paramUserCode As New SqlParameter("@ID", SqlDbType.Char)
            paramUserCode.Value = Id
            Dim sql As String = "select * from [t_User_UserInfo] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramUserCode)
            Dim info As User_UserInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToUserInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function


        Public Function GetUserInfoByDepId(ByVal intDepID As Integer) As DataSet Implements IDAL.IUser_UserInfo.GetUserInfoByDepId

            Dim paramlevel As New SqlParameter("@DepID", SqlDbType.Int)
            paramlevel.Value = intDepID
            Dim sql As String = "select * from [t_User_UserInfo] where DepID = @DepID order by Code"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramlevel)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If

        End Function


        Private Function MapRowToUserInfo(ByVal dr As DataRow) As User_UserInfo
            Dim info As New User_UserInfo
            info.ID = Convert.ToInt32(dr("ID"))
            info.Code = dr("Code").ToString()
            info.C_Name = dr("C_Name").ToString()
            info.E_Name = dr("E_Name").ToString()

            If Not Convert.IsDBNull(dr("Email")) Then
                info.Email = dr("Email").ToString()
            End If

            info.Password = dr("Password").ToString()

            If Not Convert.IsDBNull(dr("CityID")) Then
                info.CityId = Convert.ToInt32(dr("CityID"))
            End If
            If Not Convert.IsDBNull(dr("DEPID")) Then
                info.DepId = Convert.ToInt32(dr("DEPID"))
            End If
            If Not Convert.IsDBNull(dr("Pin")) Then
                info.PIN = dr("Pin").ToString()
            End If

            If Not Convert.IsDBNull(dr("TeamID")) Then
                info.TeamId = Convert.ToInt32(dr("TeamID"))
            End If


            If Not Convert.IsDBNull(dr("PositionID")) Then
                info.PositionID = Convert.ToInt32(dr("PositionID"))
            End If

            If Not Convert.IsDBNull(dr("LineManager")) Then
                info.LineManager = Convert.ToInt32(dr("LineManager"))
            End If

            If Not Convert.IsDBNull(dr("Director")) Then
                info.Director = Convert.ToInt32(dr("Director"))
                'info.LineManager = Convert.ToInt32(dr("Director"))
            End If
            'modify
            If Not Convert.IsDBNull(dr("Level")) Then
                info.Level = Convert.ToInt32(dr("Level"))
                'info.LineManager = Convert.ToInt32(dr("Level"))
            End If

            If Not Convert.IsDBNull(dr("CompanyType")) Then
                info.CompanyType = Convert.ToInt32(dr("CompanyType"))
            End If

            If Not Convert.IsDBNull(dr("Remark")) Then
                info.Remark = dr("Remark").ToString()
            End If

            If Not Convert.IsDBNull(dr("WorkPhone")) Then
                info.WorkPhone = dr("WorkPhone").ToString()
            End If


            If Not Convert.IsDBNull(dr("Onduty")) Then
                info.Onduty = Convert.ToInt32(dr("Onduty"))
            End If

            If Not Convert.IsDBNull(dr("CommencementDate")) Then
                info.CommencementDate = Convert.ToDateTime(dr("CommencementDate"))
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As User_UserInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@Code", SqlDbType.Char), _
                                                                    New SqlParameter("@C_Name", SqlDbType.Char), _
                                                                    New SqlParameter("@E_Name", SqlDbType.Char), _
                                                                    New SqlParameter("@Email", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Password", SqlDbType.Char), _
                                                                    New SqlParameter("@Pin", SqlDbType.Char), _
                                                                    New SqlParameter("@CityID", SqlDbType.Int), _
                                                                    New SqlParameter("@DepID", SqlDbType.Int), _
                                                                    New SqlParameter("@CompanyType", SqlDbType.Int), _
                                                                    New SqlParameter("@PositionID", SqlDbType.Int), _
                                                                    New SqlParameter("@Remark", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Onduty", SqlDbType.Int), _
                                                                    New SqlParameter("@WorkPhone", SqlDbType.VarChar), _
                                                                    New SqlParameter("@TeamID", SqlDbType.Int), _
                                                                    New SqlParameter("@LineManager", SqlDbType.Int), _
                                                                    New SqlParameter("@Director", SqlDbType.Int), _
                                                                    New SqlParameter("@Level", SqlDbType.Int), _
                                                                    New SqlParameter("@CommencementDate", SqlDbType.DateTime)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.Code
            parameters(2).Value = info.C_Name
            parameters(3).Value = info.E_Name
            parameters(4).Value = info.Email
            parameters(5).Value = info.Password
            parameters(6).Value = info.PIN
            parameters(7).Value = info.CityId
            parameters(8).Value = info.DepId
            parameters(9).Value = info.CompanyType
            parameters(10).Value = info.PositionID
            parameters(11).Value = info.Remark
            parameters(12).Value = info.Onduty
            parameters(13).Value = info.WorkPhone
            parameters(14).Value = info.TeamId
            parameters(15).Value = info.LineManager
            parameters(16).Value = info.Director
            parameters(17).Value = info.Level
            parameters(18).Value = info.CommencementDate
            Return parameters
        End Function



        Public Function AddUserInfo(ByVal info As User_UserInfo) As Boolean Implements IUser_UserInfo.AddUserInfo
            Dim sql As String
            Try
                sql = "select MAX(ID) AS Expr1 from t_User_userinfo"
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
                strSql = "Insert into t_user_userInfo (Id,Code,E_Name,C_Name,Email,Password,PIN,PositionID,CityID,DEPID,TeamID,LineManager,Director,level, "
                strSql = strSql & " Onduty,CompanyType,WorkPhone,CommencementDate,Remark) Values ("
                strSql += "'" + info.ID.ToString + "',"
                strSql += "'" + info.Code.ToString + "',"
                strSql += "'" + info.E_Name.ToString + "',"
                strSql += "'" + info.C_Name.ToString + "',"
                strSql += "'" + info.Email.ToString + "',"
                strSql += "'" + info.Password.ToString + "',"
                strSql += "'" + info.PIN.ToString + "',"
                strSql += "'" + info.PositionID.ToString + "',"
                strSql += "'" + info.CityId.ToString + "',"
                strSql += "'" + info.DepId.ToString + "',"
                strSql += "'" + info.TeamId.ToString + "',"
                strSql += "'" + info.LineManager.ToString + "',"
                strSql += "'" + info.Director.ToString + "',"
                strSql += "'" + info.Level.ToString + "',"
                strSql += "'" + info.Onduty.ToString + "',"
                strSql += "'" + info.CompanyType.ToString + "',"
                strSql += "'" + info.WorkPhone.ToString + "',"
                strSql += "'" + info.CommencementDate.ToString + "',"
                strSql += "'" + info.Remark.ToString + "')"

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function


        Public Function GetUserList(ByVal strFilter As String) As System.Data.DataView Implements IDAL.IUser_UserInfo.GetUserList
            Dim strSqlWhere As String
            Dim strSql As String
            strSqlWhere = " Where 1=1 "
            If strFilter <> "" Then
                strSqlWhere = strSqlWhere + " And " + strFilter
            End If

            strSql = "Select * From t_User_UserInfo "

            strSql = strSql + strSqlWhere
            strSql = strSql + " Order by Code"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, strSql)

            If Not ds.Tables(0) Is Nothing Then
                Return ds.Tables(0).DefaultView

            Else
                Return Nothing
            End If

        End Function

        Public Function ModifyUserInfo(ByVal info As Model.User_UserInfo) As Boolean Implements IDAL.IUser_UserInfo.ModifyUserInfo
            Dim strSql As String

            strSql = " Update t_User_Userinfo set "
            strSql += "Code='" + info.Code.ToString + "'"
            strSql += ",E_Name='" + info.E_Name.ToString + "'"
            strSql += ",C_Name='" + info.C_Name.ToString + "'"
            strSql += ",Password='" + info.Password.ToString + "'"
            strSql += ",PIN='" + info.PIN.ToString + "'"
            strSql += ",PositionID='" + info.PositionID.ToString + "'"
            strSql += ",CityID='" + info.CityId.ToString + "'"
            strSql += ",DEPID='" + info.DepId.ToString + "'"
            strSql += ",TeamID='" + info.TeamId.ToString + "'"
            strSql += ",LineManager='" + info.LineManager.ToString + "'"
            strSql += ",Director='" + info.Director.ToString + "'"
            strSql += ",Level='" + info.Level.ToString + "'"
            strSql += ",Onduty='" + info.Onduty.ToString + "'"
            strSql += ",CompanyType='" + info.CompanyType.ToString + "'"
            strSql += ",WorkPhone='" + info.WorkPhone.ToString + "'"
            strSql += ",CommencementDate='" + info.CommencementDate.ToString + "'"
            strSql += ",Remark='" + info.Remark.ToString + "'"
            strSql += " Where Id ='" + info.ID.ToString + "'"


            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function IsUserCodeExist(ByVal UserCode As String) As Boolean Implements IDAL.IUser_UserInfo.IsUserCodeExist
            Dim paramUserCode As SqlParameter = New SqlParameter("@Code", SqlDbType.Char)
            paramUserCode.Value = UserCode

            Dim strSql As String = "select count(0) from  t_User_UserInfo where Code= @Code "
            Dim count As Integer = 0
            count = Me.ExecuteScalar(CommandType.Text, strSql, paramUserCode)
            If count = 1 Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' This method is used to get user list by filter.
        ''' </summary>
        ''' <param name="userQueryFilter">Pass the user query filter.</param>
        ''' <returns>Return user dataset which match the condition.</returns>
        ''' <remarks></remarks>
        Public Function GetUserListByFilter(ByVal userQueryFilter As UserQueryFilter) As System.Data.DataSet Implements IDAL.IUser_UserInfo.GetUserListByFilter

            Dim strSql As String = "select userinfo.*,dep.department,city.city,position.position,manager.e_name as managerename,manager.c_name as managercname from dbo.t_User_UserInfo userinfo "
            'left join department table
            strSql += " left join t_Base_Department dep on userinfo.depid=dep.id"
            'left join city table
            strSql += " left join dbo.t_Base_City city on userinfo.cityid = city.id"
            'left join position table
            strSql += " left join dbo.t_Base_Position position on userinfo.positionid = position.id"
            'left join user info table to get line manager
            strSql += " left join dbo.t_User_UserInfo manager on userinfo.linemanager=manager.id"
            'initial condition
            strSql += "  where 1 = 1 "
            'add name condtion,check ename and cname 
            strSql += " and (@Ename = '' or userinfo.E_name like '%'+@Ename+'%' or userinfo.C_name like '%'+@Ename+'%')"
            ''add department condition
            'strSql += " and (@DepartmentId=-1 or @DepartmentId=userinfo.depid)"
            'add position condition
            strSql += " and (@PositionId=-1 or @PositionId=userinfo.positionid)"
            ''add city condition
            'strSql += " and (@CityId=-1 or @CityId=userinfo.cityid)"

            'set parameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@Ename", userQueryFilter.Name),
                 New SqlParameter("@DepartmentId", userQueryFilter.DepartmentID),
                New SqlParameter("@PositionId", userQueryFilter.PositionID),
                New SqlParameter("@CityId", userQueryFilter.CityID)}


            Dim dsUserList As DataSet = Me.ExecuteDataSet(strSql, parameters)
            Return dsUserList
        End Function
        Public Sub DeleteUser(ByVal UserId As Integer) Implements IDAL.IUser_UserInfo.DeleteUser
            Dim strSql As String = "delete from dbo.t_User_UserInfo where id= @ID"


            'set parameter           
            Dim parameter As New SqlParameter
            parameter.ParameterName = "@ID"
            parameter.Value = UserId

            Me.ExecuteNonQuery(strSql, parameter)
            Return
        End Sub

        Public Function GetUserRoleIdList(ByVal userId As Integer) As List(Of Integer) Implements IDAL.IUser_UserInfo.GetUserRoleIdList
            Dim strSql As String = "select RoleID from t_user_userrole where UserId = " + userId.ToString()
            Dim dsRoleIdList As DataSet = Me.ExecuteDataSet(strSql)
            If dsRoleIdList Is Nothing OrElse dsRoleIdList.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim roleIdList As New List(Of Integer)
                For Each row As DataRow In dsRoleIdList.Tables(0).Rows
                    roleIdList.Add(Integer.Parse(row("RoleID")))
                Next
                Return roleIdList
            End If

        End Function

        Public Function GetAllUser() As DataTable Implements IUser_UserInfo.GetAllUser
            Dim strSql As String = "select * from t_user_userinfo order by E_Name"
            Dim dsUsers As DataSet = ExecuteDataSet(strSql)
            If dsUsers IsNot Nothing AndAlso dsUsers.Tables(0).Rows.Count > 0 Then
                Return dsUsers.Tables(0)
            Else
                Return Nothing
            End If

        End Function

        Public Function GetUserTeamsPermissionIdList(ByVal userId) As List(Of Integer) Implements IUser_UserInfo.GetUserTeamsPermissionIdList
            Dim strSql As String
            strSql = "select distinct rp.Permission_ID from t_User_RolePermission rp join t_User_TeamRole tr on rp.Role_ID = tr.RoleID join t_User_UserTeam ut on tr.TeamID = ut.TeamID where ut.UserID = " + userId.ToString()

            Dim dsPermission As DataSet = ExecuteDataSet(strSql)

            If dsPermission IsNot Nothing AndAlso dsPermission.Tables(0).Rows.Count > 0 Then
                Dim permissionId = (From p In dsPermission.Tables(0).AsEnumerable _
                                   Select Integer.Parse(p("Permission_ID"))).ToList()

                Return permissionId
            Else

                Return Nothing
            End If

        End Function


        Public Function GetProjectOwnerList() As System.Data.DataSet Implements IDAL.IUser_UserInfo.GetProjectOwnerList
            Dim strSql As String = "select * from t_user_userinfo Where isprojectowner=1 order by E_Name"
            Dim dsUsers As DataSet = ExecuteDataSet(strSql)
            If dsUsers IsNot Nothing AndAlso dsUsers.Tables(0).Rows.Count > 0 Then
                Return dsUsers
            Else
                Return Nothing
            End If

        End Function

        Public Function GetTemUserList(ByVal Proid As String) As System.Data.DataView Implements IDAL.IUser_UserInfo.GetTemUserList
            Try
                Dim strSql As String = "Select  a.id as Id,b.E_name as e_name, b.C_name as c_name , b.positionId as positionid , a.ProposalUSerTypeId as usertype " & _
                                            " From t_PMS_ProposalUserInfo a join t_user_userinfo b on a.userid =b. id  " & _
                                            " where  a.Proid ='" + Proid + "'"
                Dim ds As DataSet = ExecuteDataSet(strSql)
                If Not ds.Tables(0) Is Nothing Then
                    Return ds.Tables(0).DefaultView

                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing

            End Try

        End Function
    End Class


End Namespace
