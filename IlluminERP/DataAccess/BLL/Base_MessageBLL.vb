Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.SQLServerDAL
Namespace BLL
    Public Class Base_MessageBLL
        Dim dalFactory As EnterpriseDalFactory
        Dim iMessage As IBase_Message
        Public Sub New()
            dalFactory = New EnterpriseDalFactory()

            iMessage = dalFactory.GetProduct(Of IBase_Message, Base_MessageDAO)()
        End Sub
        Public Function GetEntityById(ByVal id As Integer) As Object
            Return iMessage.GetEntityById(id)
        End Function
        Public Function GetEntityDataSet() As DataSet
            Return iMessage.GetEntityDataSet()
        End Function
        Public Overridable Function SaveMessage(ByVal message As Base_Message) As Integer
            Return iMessage.SaveMessage(message)
        End Function
        Public Function GetUnremindMessage(ByVal userId As Integer) As DataSet
            Return iMessage.GetUnremindMessage(userId)
        End Function
        Public Function SetMessageRead(ByVal messageId As Integer) As Boolean
            Return iMessage.SetMessageRead(messageId)
        End Function
        Public Function GetUserMessageList(ByVal userId As Integer) As DataSet
            Return iMessage.GetUserMessageList(userId)
        End Function
        Public Function GetMessageListByFilter(ByVal filter As MessageQueryFilter) As DataSet
            Return iMessage.GetMessageListByFilter(filter)
        End Function
        Public Sub DeleteEntity(ByVal Id As Integer)
            iMessage.DeleteEntity(Id)
        End Sub
        Public Function GetUserMessage(ByVal userId As Integer) As List(Of Base_Message)
            Return iMessage.GetUserMessage(userId)
        End Function
        Public Sub SetReceiverMessageReaded(ByVal receiverId As Integer, ByVal messageId As Integer)
            iMessage.SetReceiverMessageReaded(receiverId, messageId)
        End Sub
    End Class
End Namespace
