Imports Microsoft.VisualBasic
Imports DataAccess.BLL
Imports DataAccess.Model
Imports Utils

Public Class UserMgrService
    Private UserBLL As New UserInfoBLL

    Public Shared ReadOnly Instance As New UserMgrService

    Public Function GetUserInfo(ByVal param As GetUserInfoParam) As GetUserInfoResult
        Dim result As New GetUserInfoResult
        If param Is Nothing OrElse param.UserId < 1 Then
            result.IsSuccess = False
            result.ErrorMessage = "Cannot get user information due to invalid parameter!"
            Return result
        End If
        Try
            Dim userInfo As User_UserInfo = UserBLL.GetUserInfoById(param.UserId)

            If userInfo IsNot Nothing Then
                result.IsSuccess = True
                result.UserInfo = userInfo
            Else
                result.IsSuccess = False
                result.ErrorMessage = "Can not find the user!"
            End If
            Return result
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorMessage = "There some exception occur when load user information!"
            Return result
        End Try
    End Function
End Class
