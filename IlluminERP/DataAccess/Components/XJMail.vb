Imports System
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace Components
    Public Class XJMail
        Dim m_strMailServer As String    '发送邮件服务器			必须
        Dim m_strFromEmail As String     '发件人Email地址			必须
        Dim m_strToEmail() As String     '收件人Email地址数组		    必须
        Dim m_strSubject As String       '标题
        Dim m_strBody As String          '主体
        Dim m_strFromUserName As String  '发件人用户名			必须
        Dim m_strFromUserPwd As String   '发件人密码			    必须
        Dim m_strJpgPath As String       '内嵌图片绝对物理路径
        Dim m_strCcEmail() As String     'CC Email地址数组
        Dim m_strBccEmail() As String    'Bcc Email地址数组
        Dim m_strPicType As String        '内嵌图片类型

        Dim m_strErrInfo As String       '错误信息

        'Properties
        ''发送邮件服务器
        Public Property MailServer() As String
            Get
                Return m_strMailServer
            End Get
            Set(ByVal Value As String)
                m_strMailServer = Value
            End Set
        End Property

        '发件人Email地址
        Public Property FromEmail() As String
            Get
                Return m_strFromEmail
            End Get
            Set(ByVal Value As String)
                m_strFromEmail = Value
            End Set
        End Property

        '收件人Email地址数组
        Public Property ToEmail() As String()
            Get
                Return m_strToEmail
            End Get
            Set(ByVal Value() As String)
                m_strToEmail = Value
            End Set
        End Property

        '标题
        Public Property Subject() As String
            Get
                Return m_strSubject
            End Get
            Set(ByVal Value As String)
                m_strSubject = Value
            End Set
        End Property

        '主体
        Public Property Body() As String
            Get
                Return m_strBody
            End Get
            Set(ByVal Value As String)
                m_strBody = Value
            End Set
        End Property

        '发件人用户名
        Public Property FromUserName() As String
            Get
                Return m_strFromUserName
            End Get
            Set(ByVal Value As String)
                m_strFromUserName = Value
            End Set
        End Property

        '发件人密码
        Public Property FromUserPwd() As String
            Get
                Return m_strFromUserPwd
            End Get
            Set(ByVal Value As String)
                m_strFromUserPwd = Value
            End Set
        End Property

        '内嵌图片绝对物理路径
        Public Property JpgPath() As String
            Get
                Return m_strJpgPath
            End Get
            Set(ByVal Value As String)
                m_strJpgPath = Value
            End Set
        End Property

        '抄送Email地址数组
        Public Property CcEmail() As String()
            Get
                Return m_strCcEmail
            End Get
            Set(ByVal Value() As String)
                m_strCcEmail = Value
            End Set
        End Property

        'BCCEmail地址数组
        Public Property BccEmail() As String()
            Get
                Return m_strBccEmail
            End Get
            Set(ByVal Value() As String)
                m_strBccEmail = Value
            End Set
        End Property

        '错误信息传出
        Public Property ErrInfo() As String
            Get
                Return m_strErrInfo
            End Get
            Set(ByVal Value As String)
                m_strErrInfo = Value
            End Set
        End Property
        '图片类型
        Public Property PicType() As String
            Get
                Return m_strPicType
            End Get
            Set(ByVal Value As String)
                m_strPicType = Value
            End Set
        End Property


        '邮件发送函数
        Public Function SendMail() As Boolean
            Dim bReturn As Boolean
            Try
                Dim jMail As New jmail.Message
                With jMail
                    'Silent属性：如果设置为true,JMail不会抛出例外错误. JMail. Send() 会根据操作结果返回true或false		
                    .Silent = False
                    'Jmail创建的日志，前提loging属性设置为true
                    .Logging = True
                    '字符集，缺省为"US-ASCII"
                    .Charset = "GB2312"
                    '信件的contentype. 缺省是"text/plain"） : 字符串如果你以HTML格式发送邮件, 改为"text/html"即可。
                    'jMail.ContentType="text/html";
                    '添加收件人
                    Dim i As Int16
                    Dim emailSub As String
                    Dim intFlag As Integer = 0   ' 判断是否公司邮箱标志

                    m_strMailServer = "172.20.96.28"


                    For i = 0 To m_strToEmail.Length - 1
                        emailSub = m_strToEmail(i).ToString()

                        If InStr(emailSub, "tns-global") <= 0 Then
                            intFlag = 1
                        End If

                        If emailSub <> "" Then
                            .AddRecipient(emailSub)
                        Else
                            Exit For
                        End If
                    Next

                    If Not m_strCcEmail Is Nothing Then
                        For i = 0 To m_strCcEmail.Length - 1
                            emailSub = m_strCcEmail(i).ToString()

                            If InStr(emailSub, "tns-global") <= 0 Then
                                intFlag = 1
                            End If

                            If emailSub <> "" Then
                                .AddRecipientCC(emailSub)
                            Else
                                Exit For
                            End If
                        Next
                    End If

                    If intFlag = 1 Then
                        m_strMailServer = "192.168.100.11"
                    End If

                    'For i = 0 To m_strBccEmail.Length - 1
                    '    emailSub = m_strBccEmail(i).ToString()
                    '    If emailSub <> "" Then
                    '        .AddRecipientBCC(emailSub)
                    '    Else
                    '        Exit For
                    '    End If
                    'Next
                    '.From = FromEmail
                    .From = "Mailer.ChinaERP@tns-global.com"
                    '发件人邮件用户名
                    .MailServerUserName = m_strFromUserName
                    '发件人邮件密码
                    .MailServerPassWord = m_strFromUserPwd
                    '设置邮件标题
                    .Subject = m_strSubject


                    Select Case m_strPicType
                        Case 1
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\RevenueApproval.JPG"
                        Case 2
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\RFQ.JPG"
                        Case 3
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\Commission.JPG"
                        Case 4
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\RequestClose.JPG"
                        Case 5
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\ProjectClose.JPG"
                        Case 6
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\EmailLogin.JPG"
                        Case 7
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\Reminder.JPG"
                        Case 20
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\onleavevacation.JPG"
                        Case 21
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\onleavesick.JPG"
                        Case 22
                            m_strJpgPath = "D:\ChinaERP\Publish\Images\onleave.JPG"
                    End Select

                    '邮件添加附件,(多附件的话，可以再加一条Jmail.AddAttachment( "c:\\test.jpg",true,null);)就可以搞定了。
                    '［注］：加了附件，讲把上面的Jmail.ContentType="text/html";删掉。否则会在邮件里出现乱码。
                    '			Jmail.AddAttachment( "c:\\log.jpg",true,null);
                    'If m_strJpgPath <> "" Then
                    Dim contentID As String = .AddAttachment(m_strJpgPath, False, "")
                    '  End If

                    '只有HTML格式支持嵌入图片附件，我们采用HTML格式的邮件内容 
                    ' As only HTML formatted emails can contain inline images 
                    ' we use HTMLBody and appendHTML  <font color=red>Hi, here is a nice picture:</font>
                    jMail.HTMLBody = "<html><body><font style='FONT-SIZE: 9pt; FONT-FAMILY: Arial'><br>"
                    jMail.AppendHTML("<img src=cid:" + contentID + "><br><br>")
                    jMail.AppendHTML(m_strBody + "<br>") '主体
                    jMail.AppendHTML("<br>")
                    jMail.AppendHTML("<br></font></body></html>")
                    .Send(m_strMailServer, False)
                    .Close()
                End With
                bReturn = True
            Catch ex As Exception
                m_strErrInfo = ex.Message.ToString()
                bReturn = False
            End Try
            SendMail = bReturn
        End Function

    End Class
End Namespace

