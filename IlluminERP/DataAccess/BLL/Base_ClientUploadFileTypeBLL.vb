Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Base_ClientUploadFileTypeBLL

        Private factory As New DALFactory
        Private FileTypeDal As IBase_ClientUploadFileType = factory.GetProduct("Base_ClientUploadFileTypeDAO")

        Public Sub New()

        End Sub

        Public Function GetClientUploadFileTypeInfo() As DataSet
            Return FileTypeDal.GetClientUploadFileTypeInfo
        End Function

        Public Function GetClientUploadFileTypeById(ByVal ID As Integer) As Base_ClientUploadFileType
            Return FileTypeDal.GetClientUploadFileTypeById(ID)
        End Function
    End Class
End Namespace
