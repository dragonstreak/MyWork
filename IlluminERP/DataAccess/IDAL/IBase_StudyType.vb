Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_StudyType
        Function GetStudyTypeInfo() As DataSet

        Function GetStudyTypeByID(ByVal ID As Integer) As Base_StudyType


    End Interface

End Namespace

