Imports System
Imports System.Text.RegularExpressions

Public Class DataCheckUtils

    '/ 判断输入的字符串只包含汉字
    Public Shared Function IsChineseCh(ByVal strInput As String) As Boolean
        Dim i As Integer
        Dim strChar As String
        Dim regex As Regex = New Regex("^[\u4e00-\u9fa5]+$")
        For i = 1 To strInput.Length
            strChar = Mid(strInput, i, 1)
            If regex.IsMatch(strChar) = True Then
                Return True
                Exit For
            End If
        Next i
        Return False
    End Function

    '/ 判断输入的字符串只包含数字
    Public Shared Function IsNumericCh(ByVal strInput As String) As Boolean

        Dim i As Integer
        Dim strChar As String
        Dim regex As Regex = New Regex("^[0-9]+$")
        For i = 1 To strInput.Length
            strChar = Mid(strInput, i, 1)
            If regex.IsMatch(strChar) = True Then
                Return True
                Exit For
            End If
        Next i
        Return False
    End Function

    '/ 判断输入的字符串只包含字母
    Public Shared Function IsEnglishCh(ByVal strInput As String) As Boolean
  
        Dim i As Integer
        Dim strChar As String
        Dim regex As Regex = New Regex("^[A-Za-z]+$")
        For i = 1 To strInput.Length
            strChar = Mid(strInput, i, 1)
            If regex.IsMatch(strChar) = True Then
                Return True
                Exit For
            End If
        Next i
        Return False
    End Function

   

End Class
