Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model
Imports System.Collections


Namespace IDAL


    Friend Interface IUser_UserInfo

        Function AddUserInfo(ByVal info As User_UserInfo) As Boolean

        Function ModifyUserInfo(ByVal info As User_UserInfo) As Boolean

        Function IsUserExist(ByVal userCode As String, ByVal pwd As String) As Boolean

        Function GetUserInfoByUserCode(ByVal userCode As String) As User_UserInfo

        Function GetUserInfoByDepId(ByVal DepId As Integer) As DataSet

        Function GetUserInfoById(ByVal Id As Integer) As Model.User_UserInfo

        Function GetUserList(ByVal strFilter As String) As DataView

        Function IsUserCodeExist(ByVal UserCode As String) As Boolean

        'new add
        Function GetUserListByFilter(ByVal userQueryFilter As UserQueryFilter) As System.Data.DataSet

        Sub DeleteUser(ByVal UserId As Integer)

        Function GetUserRoleIdList(ByVal userId As Integer) As List(Of Integer)

        Function GetAllUser() As DataTable

        Function GetProjectOwnerList() As DataSet

        Function GetUserTeamsPermissionIdList(ByVal userId) As List(Of Integer)

        Function GetTemUserList(ByVal Proid As String) As DataView

        'Function ModifyUserInfo(ByVal info As UserInfo) As Boolean

        'Function IsUserExist(ByVal userCode As String, ByVal pwd As String) As Boolean

        '

        'Function IsUserPinCorrect(ByVal userCode As String, ByVal pin As String) As Boolean


        'Function ModifyUserPin(ByVal userCode As String, ByVal pin As String) As Boolean


        'Function ModifyUserPassword(ByVal userCode As String, ByVal password As String) As Boolean

        'Function GetAuthorizeeByAuthorizerID(ByVal authorizerID As Integer) As DataView

        'Function GetValidAuthorizeeByAuthorizerID(ByVal authorizerID As Integer) As DataView

        ''  Function GetUserList(ByVal filter As MyUserFilter) As ResultBlock

        ''Function GetUserListByFilter(ByVal filter As MyUserFilter) As DataView

        ''  Function AddAuthorization(ByVal info As AuthorizationInfo) As Boolean

        'Function IsUserAuthorized(ByVal authorizerID As Integer, ByVal userID As Integer) As Boolean

        'Function SetIsAuthorizedById(ByVal id As Integer, ByVal b As Boolean) As Boolean

        'Function GetPosition() As DataView

        'Function GetTeam() As DataView

        'Function GetDepartment() As DataView

        'Function GetDeptNameByDeptID(ByVal deptID As Integer) As String

        'Function GetManagerNameByUserCode(ByVal userCode As String) As String

        'Function GetPositionByPositionID(ByVal positionID As Integer) As String

        'Function GetManager() As DataView

        'Function GetPositionLevel(ByVal positionID As Integer) As Integer

        'Function GetUserInfoByID(ByVal userID As Integer) As Model.UserInfo

        'Function GetDirector() As DataView

        'Function GetDirectorNameByUserCode(ByVal userCode As String) As String

        'Function GetUserInfoByName(ByVal UserName As String) As Model.UserInfo

        'Function GetManagerByTeam(ByVal team As Integer) As DataView

        'Function GetCMRManagerByTeam(ByVal team As Integer) As DataView

        'Function GetAuthorizerByAuthorizee(ByVal authorizeeID As Integer) As DataView

        'Function IsTeamLeader(ByVal userID As Integer) As Boolean

        'Function GetTeamLeader() As DataView

        'Function IsManager(ByVal userID) As Boolean


    End Interface

End Namespace
