Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class Base_StudyTypeBLL
        Private factory As New DALFactory
        Private StudyTypeDAL As IBase_StudyType = factory.GetProduct("Base_StudyTypeDAO")

        Public Sub New()

        End Sub

        Public Function GetStudyTypeInfo() As DataSet
            Return StudyTypeDAL.GetStudyTypeInfo()
        End Function

        Public Function GetStudyTypeByID(ByVal Id As Integer) As Model.Base_StudyType
            Return StudyTypeDAL.GetStudyTypeByID(Id)
        End Function


    End Class
End Namespace

