Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Base_MBPQuestionBLL
        Private factory As New DALFactory
        Private MBPQuestionDAL As IBase_MBPQuestion = factory.GetProduct("Base_MBPQuestionDAO")

        Public Sub New()

        End Sub

        Public Function GetMBPQuestion() As DataSet
            Return MBPQuestionDAL.GetMBPQuestion()
        End Function

        Public Function GetMBPQuestionByID(ByVal ID As Integer) As Base_MBPQuestion
            Return MBPQuestionDAL.GetMBPQuestionByID(ID)
        End Function


    End Class
End Namespace
