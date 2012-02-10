Imports System
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace Components
    Public Class Components
        Private Shared connString As String
        Private Shared connSubcontractString As String
        Private Shared StrMailerConnect As String
        Private Shared MailerDBConn As SqlConnection

        Shared Sub New()
            Components.connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("DataAccess.SQLServerConnString").ConnectionString
            Components.connSubcontractString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("DataAccess.SubcontractString").ConnectionString
            Components.StrMailerConnect = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MailerDBString").ConnectionString
            MailerDBConn = New SqlConnection(Components.StrMailerConnect)

        End Sub

        Public Shared Function RunProc(ByVal procName As String, ByVal commandParams() As SqlParameter) As System.Data.SqlClient.SqlDataReader

            Dim dr As IDataReader = Nothing

            dr = SqlHelper.ExecuteReader(connString, CommandType.StoredProcedure, procName, commandParams)

            Return dr

        End Function

        Public Shared Function RunProcDataView(ByVal procName As String, ByVal commandParams() As SqlParameter) As System.Data.DataView

            Dim ds As DataSet = Nothing

            ds = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, procName, commandParams)
            If Not ds Is Nothing Then
                Return ds.Tables(0).DefaultView
            Else
                Return Nothing
            End If

        End Function

        Public Shared Function RunSQLDataView(ByVal sqlName As String) As System.Data.DataView
            Dim ds As DataSet = Nothing
            ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, sqlName)
            If Not ds Is Nothing Then
                Return ds.Tables(0).DefaultView
            Else
                Return Nothing
            End If
        End Function

        Public Shared Function RunSQLDataSet(ByVal sqlName As String) As System.Data.DataSet
            Dim ds As DataSet = Nothing
            ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, sqlName)
            If Not ds Is Nothing Then
                Return ds
            Else
                Return Nothing
            End If
        End Function


        '插入到邮件发送列表中，ToMail 可以是多人，可以是单人

        Public Shared Function InsertMailTask(ByVal strTomail As String, ByVal strCCMail As String, _
                    ByVal strBCCName As String, ByVal strSubject As String, ByVal strBody As String, ByVal Attachment As String) As Boolean

            Dim strServerAdd As String
            Dim strSender As String
            Dim SenderName As String
            Dim strRecipient As String
            Dim strRecipientCC As String
            Dim strRecipientBCC As String
            Dim strSql As String


            strServerAdd = "172.20.96.28"
            strSender = "Mailer.ChinaERP@tns-global.com"
            SenderName = "Mailer ChinaERP"

            strRecipient = strTomail
            strRecipientCC = strCCMail
            strRecipientBCC = strBCCName


            strSql = "INSERT INTO t_Mailer_Task (ServerAddress,SenderEmail,SenderName,Recipient,RecipientCC,RecipientBCC,Subject,Body,Attachment)"
            strSql += " VALUES ('" + strServerAdd + "'"
            strSql += ",'" + strSender.Trim + "'"
            strSql += ",'" + SenderName.Trim + "'"
            strSql += ",'" + strRecipient.Trim + "'"
            strSql += ",'" + strRecipientCC.Trim + "'"
            strSql += ",'" + strRecipientBCC.Trim + "'"
            strSql += ",'" + strSubject.Trim + "'"
            strSql += ",'" + strBody + "'"
            strSql += ",'" + Attachment + "')"

            MailerDBConn.Open()
            Dim SqlTran As SqlTransaction = MailerDBConn.BeginTransaction

            Try
                SqlHelper.ExecuteNonQuery(SqlTran, CommandType.Text, strSql)
                SqlTran.Commit()
                Return True
            Catch ex As Exception
                Return False
                SqlTran.Rollback()

            Finally
                MailerDBConn.Close()
            End Try



        End Function


        '插入到邮件发送列表中，ToMail 可以是多人，可以是单人

        Public Shared Function InsertMailTaskByToMailCOl(ByVal strTomail As String, ByVal strCCMail As String, _
                    ByVal strBCCName As String, ByVal strSubject As String, ByVal strBody As String, ByVal Attachment As String) As Boolean

            Dim strServerAdd As String
            Dim strSender As String
            Dim SenderName As String
            Dim strRecipient() As String
            Dim strRecipientCC As String
            Dim strRecipientBCC As String
            Dim strSql As String
            Dim i As Integer

            strServerAdd = "172.20.96.28"
            strSender = "Mailer.ChinaERP@tns-global.com"
            SenderName = "Mailer.ChinaERP"


            strRecipientCC = strCCMail
            strRecipientBCC = strBCCName




            MailerDBConn.Open()
            Dim SqlTran As SqlTransaction = MailerDBConn.BeginTransaction

            Try


                strRecipient = Split(strTomail, ",")

                For i = 0 To strRecipient.Length - 1
                    strSql = "INSERT INTO t_Mailer_Task (ServerAddress,SenderEmail,SenderName,Recipient,RecipientCC,RecipientBCC,Subject,Body,Attachment)"
                    strSql += " VALUES ('" + strServerAdd + "'"
                    strSql += ",'" + strSender.Trim + "'"
                    strSql += ",'" + SenderName.Trim + "'"
                    strSql += ",'" + strRecipient(i).Trim + "'"
                    strSql += ",'" + strRecipientCC.Trim + "'"
                    strSql += ",'" + strRecipientBCC.Trim + "'"
                    strSql += ",'" + strSubject.Trim + "'"
                    strSql += ",'" + strBody + "'"
                    strSql += ",'" + Attachment + "')"

                    SqlHelper.ExecuteNonQuery(SqlTran, CommandType.Text, strSql)
                Next

                SqlTran.Commit()
                Return True
            Catch ex As Exception
                Return False
                SqlTran.Rollback()

            Finally
                MailerDBConn.Close()
            End Try



        End Function

    End Class
End Namespace
