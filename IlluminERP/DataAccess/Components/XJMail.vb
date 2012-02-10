Imports System
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace Components
    Public Class XJMail
        Dim m_strMailServer As String    '�����ʼ�������			����
        Dim m_strFromEmail As String     '������Email��ַ			����
        Dim m_strToEmail() As String     '�ռ���Email��ַ����		    ����
        Dim m_strSubject As String       '����
        Dim m_strBody As String          '����
        Dim m_strFromUserName As String  '�������û���			����
        Dim m_strFromUserPwd As String   '����������			    ����
        Dim m_strJpgPath As String       '��ǶͼƬ��������·��
        Dim m_strCcEmail() As String     'CC Email��ַ����
        Dim m_strBccEmail() As String    'Bcc Email��ַ����
        Dim m_strPicType As String        '��ǶͼƬ����

        Dim m_strErrInfo As String       '������Ϣ

        'Properties
        ''�����ʼ�������
        Public Property MailServer() As String
            Get
                Return m_strMailServer
            End Get
            Set(ByVal Value As String)
                m_strMailServer = Value
            End Set
        End Property

        '������Email��ַ
        Public Property FromEmail() As String
            Get
                Return m_strFromEmail
            End Get
            Set(ByVal Value As String)
                m_strFromEmail = Value
            End Set
        End Property

        '�ռ���Email��ַ����
        Public Property ToEmail() As String()
            Get
                Return m_strToEmail
            End Get
            Set(ByVal Value() As String)
                m_strToEmail = Value
            End Set
        End Property

        '����
        Public Property Subject() As String
            Get
                Return m_strSubject
            End Get
            Set(ByVal Value As String)
                m_strSubject = Value
            End Set
        End Property

        '����
        Public Property Body() As String
            Get
                Return m_strBody
            End Get
            Set(ByVal Value As String)
                m_strBody = Value
            End Set
        End Property

        '�������û���
        Public Property FromUserName() As String
            Get
                Return m_strFromUserName
            End Get
            Set(ByVal Value As String)
                m_strFromUserName = Value
            End Set
        End Property

        '����������
        Public Property FromUserPwd() As String
            Get
                Return m_strFromUserPwd
            End Get
            Set(ByVal Value As String)
                m_strFromUserPwd = Value
            End Set
        End Property

        '��ǶͼƬ��������·��
        Public Property JpgPath() As String
            Get
                Return m_strJpgPath
            End Get
            Set(ByVal Value As String)
                m_strJpgPath = Value
            End Set
        End Property

        '����Email��ַ����
        Public Property CcEmail() As String()
            Get
                Return m_strCcEmail
            End Get
            Set(ByVal Value() As String)
                m_strCcEmail = Value
            End Set
        End Property

        'BCCEmail��ַ����
        Public Property BccEmail() As String()
            Get
                Return m_strBccEmail
            End Get
            Set(ByVal Value() As String)
                m_strBccEmail = Value
            End Set
        End Property

        '������Ϣ����
        Public Property ErrInfo() As String
            Get
                Return m_strErrInfo
            End Get
            Set(ByVal Value As String)
                m_strErrInfo = Value
            End Set
        End Property
        'ͼƬ����
        Public Property PicType() As String
            Get
                Return m_strPicType
            End Get
            Set(ByVal Value As String)
                m_strPicType = Value
            End Set
        End Property


        '�ʼ����ͺ���
        Public Function SendMail() As Boolean
            Dim bReturn As Boolean
            Try
                Dim jMail As New jmail.Message
                With jMail
                    'Silent���ԣ��������Ϊtrue,JMail�����׳��������. JMail. Send() ����ݲ����������true��false		
                    .Silent = False
                    'Jmail��������־��ǰ��loging��������Ϊtrue
                    .Logging = True
                    '�ַ�����ȱʡΪ"US-ASCII"
                    .Charset = "GB2312"
                    '�ż���contentype. ȱʡ��"text/plain"�� : �ַ����������HTML��ʽ�����ʼ�, ��Ϊ"text/html"���ɡ�
                    'jMail.ContentType="text/html";
                    '����ռ���
                    Dim i As Int16
                    Dim emailSub As String
                    Dim intFlag As Integer = 0   ' �ж��Ƿ�˾�����־

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
                    '�������ʼ��û���
                    .MailServerUserName = m_strFromUserName
                    '�������ʼ�����
                    .MailServerPassWord = m_strFromUserPwd
                    '�����ʼ�����
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

                    '�ʼ���Ӹ���,(�฽���Ļ��������ټ�һ��Jmail.AddAttachment( "c:\\test.jpg",true,null);)�Ϳ��Ը㶨�ˡ�
                    '��ע�ݣ����˸��������������Jmail.ContentType="text/html";ɾ������������ʼ���������롣
                    '			Jmail.AddAttachment( "c:\\log.jpg",true,null);
                    'If m_strJpgPath <> "" Then
                    Dim contentID As String = .AddAttachment(m_strJpgPath, False, "")
                    '  End If

                    'ֻ��HTML��ʽ֧��Ƕ��ͼƬ���������ǲ���HTML��ʽ���ʼ����� 
                    ' As only HTML formatted emails can contain inline images 
                    ' we use HTMLBody and appendHTML  <font color=red>Hi, here is a nice picture:</font>
                    jMail.HTMLBody = "<html><body><font style='FONT-SIZE: 9pt; FONT-FAMILY: Arial'><br>"
                    jMail.AppendHTML("<img src=cid:" + contentID + "><br><br>")
                    jMail.AppendHTML(m_strBody + "<br>") '����
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

