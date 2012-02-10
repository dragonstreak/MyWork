
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_ProjectTypeBLL
        Private factory As New DALFactory
        Private ProjectTypeDAL As IBase_ProjectType = factory.GetProduct("Base_ProjectTypeDAO")

        Public Sub New()

        End Sub

        Public Function GetProjectTypeInfo() As DataSet
            Return ProjectTypeDAL.GetProjectTypeInfo()
        End Function

        Public Function GetProjectTypeInfoByID(ByVal Id As Integer) As Model.Base_ProjectType
            Return ProjectTypeDAL.GetProjectTypeInfoByID(Id)
        End Function

    End Class
End Namespace
