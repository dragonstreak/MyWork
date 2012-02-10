
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_MBPQuestion

        Function GetMBPQuestion() As DataSet

        Function GetMBPQuestionByID(ByVal ID As Integer) As Base_MBPQuestion

    End Interface
End Namespace
