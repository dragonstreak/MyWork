Imports Dimac.JMail
Imports System.Text

Public Class Jmail

    Public Function SendEmail(ByVal Tbody As String, ByVal intType As Integer, ByVal ToUser As String, ByVal CCUser As String, ByVal strSubject As String) As Boolean

        Dim message As New Message()
        Dim strSMTP As String = "Mail.Illuminera.Com"
        Dim strPort As String = "25"
        Dim strSystemUser As String = "David.Dong@illuminera.com"
        Dim strSystemPassword As String = "q1w2e3r4"
        Dim strDomain As String = "Illuminera.com"
        message.From.Email = strSystemUser
        message.To.Add(ToUser, "")
        message.Subject = strSubject
        message.Cc.Add(CCUser, "")

        message.Charset = Encoding.GetEncoding("GB2312")



        If intType = 0 Then
            message.BodyHtml = Tbody
        Else
            message.BodyText = Tbody
        End If


        Try


            If SmtpAuthentication.None Then
                Smtp.Send(message, strSMTP, Short.Parse(strPort), GetDomain(message.From.Email))
            Else
                Smtp.Send(message, strSMTP, Short.Parse(strPort), strDomain, SmtpAuthentication.Login, strSystemUser, strSystemPassword)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    ' Get the domain part of an email address.
    Private Function GetDomain(ByVal email As String) As String
        Dim index = email.IndexOf("@")
        Return email.Substring(index + 1)
    End Function

End Class
