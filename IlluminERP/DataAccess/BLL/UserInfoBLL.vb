Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model

Imports System.Linq


Namespace BLL
    
    Public Class UserInfoBLL

        Private factory As New DALFactory
        Private UserInfoDal As IUser_UserInfo = factory.GetProduct("UserInfoDAO")
        Private UserRoleDal As IUser_UserRole = factory.GetProduct("User_UserRoleDAO")
        Private RoleDal As IUser_Role = factory.GetProduct("User_RoleDAO")

        Public Sub New()

        End Sub

        Public Function IsUserExist(ByVal Code As String, ByVal Password As String) As Integer
            Return UserInfoDal.IsUserExist(Code, password)
        End Function


        Public Function AddUserInfo(ByVal info As Model.User_UserInfo) As Integer
            Return UserInfoDal.AddUserInfo(info)
        End Function

        Public Function GetUserInfoByUserCode(ByVal UserCode As String) As User_UserInfo

            Dim uInfo As User_UserInfo
            uInfo = UserInfoDal.GetUserInfoByUserCode(UserCode)
            uInfo = GetUserInfoById(uInfo.ID)
            Return uInfo
        End Function

        Public Function GetUserInfoByDepId(ByVal DepId As Integer) As DataSet
            Return UserInfoDal.GetUserInfoByDepId(DepId)
        End Function


        Public Function GetUserInfoById(ByVal Id As Integer) As Model.User_UserInfo
            Dim uInfo As User_UserInfo
            uInfo = UserInfoDal.GetUserInfoById(Id)
            uInfo.RoleIds = UserRoleDal.GetUserRoleIdsByUserId(Id)
            Dim rolePermission As List(Of Integer) = RoleDal.GetRolePermissionIdsByRoleIds(uInfo.RoleIds)
            Dim teamPermission As List(Of Integer) = UserInfoDal.GetUserTeamsPermissionIdList(uInfo.ID)
            rolePermission = IIf(rolePermission Is Nothing, New List(Of Integer), rolePermission)
            teamPermission = IIf(teamPermission Is Nothing, New List(Of Integer), teamPermission)
            rolePermission.AddRange(teamPermission)
            If rolePermission.Distinct().Count > 0 Then
                uInfo.PermissionIds = rolePermission.Distinct().ToList()
            End If

            Return uInfo
        End Function

        Public Function GetUserList(ByVal Filter As String) As DataView
            Return UserInfoDal.GetUserList(Filter)
        End Function


        Public Function ModifyUserInfo(ByVal info As User_UserInfo) As Boolean
            Return UserInfoDal.ModifyUserInfo(info)
        End Function

        Public Function IsUserCodeExist(ByVal UserCode As String) As Boolean
            Return UserInfoDal.IsUserCodeExist(UserCode)
        End Function
        Public Function GetUserListByFilter(ByVal userQueryFilter As UserQueryFilter) As System.Data.DataSet
            Return UserInfoDal.GetUserListByFilter(userQueryFilter)
        End Function
        Public Sub DeleteUser(ByVal UserId As Integer)
            UserInfoDal.DeleteUser(UserId)
        End Sub

        Public Function GetUserRoleIdList(ByVal userId As Integer) As List(Of Integer)
            Return UserInfoDal.GetUserRoleIdList(userId)
        End Function

        Public Function GetAllUser() As DataTable
            Return UserInfoDal.GetAllUser()
        End Function
        Public Function GetProjectOwnerList() As DataSet
            Return UserInfoDal.GetProjectOwnerList()
        End Function

        Public Function GetTemUserList(ByVal Proid As String) As DataView
            Return UserInfoDal.GetTemUserList(Proid)
        End Function

        'Public Function IsUserExist(ByVal userCode As String, ByVal pwd As String) As Boolean
        '    Return userDal.IsUserExist(userCode, pwd)
        'End Function


        'Public Function IsUserPinCorrect(ByVal userCode As String, ByVal pin As String) As Boolean
        '    Return userDal.IsUserPinCorrect(userCode, pin)
        'End Function

        'Public Function GetUserInfoByUserCode(ByVal userCode As String) As UserInfo
        '    Return userDal.GetUserInfoByUserCode(userCode)
        'End Function

        'Public Function GetUserInfoByName(ByVal UserName As String) As UserInfo
        '    Return userDal.GetUserInfoByName(UserName)
        'End Function


        'Public Function ModifyUserPin(ByVal userCode As String, ByVal pin As String) As Boolean
        '    Return userDal.ModifyUserPin(userCode, pin)
        'End Function

        'Public Function ModifyUserPassword(ByVal userCode As String, ByVal password As String) As Boolean
        '    Return userDal.ModifyUserPassword(userCode, password)
        'End Function


        'Public Function GetAuthorizeeByAuthorizerID(ByVal authorizerID As Integer) As DataView
        '    Return userDal.GetAuthorizeeByAuthorizerID(authorizerID)
        'End Function

        'Public Function GetValidAuthorizeeByAuthorizerID(ByVal authorizerID As Integer) As System.Data.DataView
        '    Return userDal.GetValidAuthorizeeByAuthorizerID(authorizerID)
        'End Function

        ' ''Public Function GetUserList(ByVal filter As MyUserFilter) As ResultBlock
        ''    Return userDal.GetUserList(filter)
        ''End Function


        ''Public Function AddAuthorization(ByVal info As AuthorizationInfo) As Boolean
        ''    Return userDal.AddAuthorization(info)
        ''End Function

        'Public Function IsUserAuthorized(ByVal authorizerID As Integer, ByVal userID As Integer) As Boolean
        '    Return userDal.IsUserAuthorized(authorizerID, userID)
        'End Function

        'Public Function SetIsAuthorizedById(ByVal id As Integer, ByVal b As Boolean) As Boolean
        '    Return userDal.SetIsAuthorizedById(id, b)
        'End Function

        'Public Function GetPosition() As DataView
        '    Return userDal.GetPosition()
        'End Function

        'Public Function GetDepartment() As DataView
        '    Return userDal.GetDepartment()
        'End Function

        'Public Function GetTeam() As DataView
        '    Return userDal.GetTeam()
        'End Function

        'Public Function GetDeptNameByDeptID(ByVal deptID As Integer) As String
        '    Return userDal.GetDeptNameByDeptID(deptID)
        'End Function
        'Public Function GetManagerNameByUserCode(ByVal userCode As String) As String
        '    Return userDal.GetManagerNameByUserCode(userCode)
        'End Function

        ''Public Function GetAllUser() As DataView

        ''End Function

        ''Public Function GetAllManager() As DataView
        ''    Dim dv As DataView
        ''    dv = GetAllUser()
        ''    dv.RowFilter = "level >= 2"
        ''    Return dv
        ''End Function

        'Public Function GetManager() As DataView
        '    Return userDal.GetManager()
        'End Function
        'Public Function GetDirector() As DataView
        '    Return userDal.GetDirector()
        'End Function

        'Public Function GetPositionLevel(ByVal positionID As Integer) As Integer
        '    Return userDal.GetPositionLevel(positionID)
        'End Function

        'Function GetUserInfoByID(ByVal userID As Integer) As UserInfo
        '    Return userDal.GetUserInfoByID(userID)
        'End Function

        'Public Function GetPositionByPositionID(ByVal positionID As Integer) As String
        '    Return userDal.GetPositionByPositionID(positionID)
        'End Function

        'Public Function GetDirectorNameByUserCode(ByVal userCode As String) As String
        '    Return userDal.GetDirectorNameByUserCode(userCode)
        'End Function

        ''Public Function GetUserListByFilter(ByVal filter As UserInfo) As DataView
        ''    Return userDal.GetUserListByFilter(filter)
        ''End Function

        'Public Function GetManagerByTeam(ByVal team As Integer) As System.Data.DataView
        '    Return userDal.GetManagerByTeam(team)
        'End Function

        'Public Function GetCMRManagerByTeam(ByVal team As Integer) As System.Data.DataView
        '    Return userDal.GetCMRManagerByTeam(team)
        'End Function

        'Public Function GetAuthorizerByAuthorizee(ByVal authorizeeID As Integer) As System.Data.DataView
        '    Return userDal.GetAuthorizerByAuthorizee(authorizeeID)
        'End Function

        'Public Function IsTeamLeader(ByVal userID As Integer) As Boolean
        '    Return userDal.IsTeamLeader(userID)
        'End Function

        'Public Function GetTeamLeader() As System.Data.DataView
        '    Return userDal.GetTeamLeader()
        'End Function

        'Public Function IsManager(ByVal userID As Object) As Boolean
        '    Return userDal.IsManager(userID)
        'End Function


        ''' <summary>   
        ''' AD帳戶。   
        ''' </summary>   
        ''' <param name="strUserName">帳戶名稱。</param>   
        ''' <param name="strUserPwd">帳戶密碼。</param>   
        ''' <param name="strDomainName">網域名稱或電腦名稱。</param>   
        Public Function CheckADByUserInfo(ByVal strUserName As String, ByVal strUserPwd As String, ByVal strDomainName As String) As Boolean

            Dim ds As New System.DirectoryServices.DirectoryEntry(strDomainName, strUserName, strUserPwd)

            Try
                ' 可讀取GUID，驗證成功。   
                If Not ds.Guid.ToString = "" Then Return True
            Catch ex As Exception
                ' 驗證失敗   
                Return False
            End Try
            ds.Close()
        End Function

    End Class
End Namespace
