Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_MBPAnswerBLL
        Private factory As New DALFactory
        Private MBPAnswerDAL As IBase_MBPAnswer = factory.GetProduct("Base_MBPAnswerDAO")

        Public Sub New()

        End Sub

        Public Function GetMBPAnswerById(ByVal Id As Integer) As Model.Base_MBPAnswer
            Return MBPAnswerDAL.GetMBPAnswerById(Id)
        End Function

        Public Function GetMBPAnswerByQuestionId(ByVal QuestionId As Integer) As DataSet
            Return MBPAnswerDAL.GetMBPAnswerByQuestionId(QuestionId)
        End Function

    End Class
End Namespace