

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class PMS_UploadFileTypeBLL
        Private factory As New DALFactory
        Private FileTypeDAL As IPMS_UploadFileType = factory.GetProduct("PMS_UploadFileTypeDAO")

        Public Sub New()

        End Sub

        Public Function GetFileTypeInfo() As DataSet
            Return FileTypeDAL.GetFileTypeInfo()
        End Function

        Public Function GetFileTypeByID(ByVal Id As Integer) As Model.PMS_UploadFileType
            Return FileTypeDAL.GetFileTypeByID(Id)
        End Function

    End Class
End Namespace
