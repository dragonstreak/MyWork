Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL

    Friend Interface IBase_MBPAnswer

        Function GetMBPAnswerById(ByVal Id As Integer) As Model.Base_MBPAnswer

        Function GetMBPAnswerByQuestionId(ByVal QuestionId As Integer) As DataSet

    End Interface
End Namespace
