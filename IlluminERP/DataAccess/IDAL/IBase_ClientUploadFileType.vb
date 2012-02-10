
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_ClientUploadFileType
        Function GetClientUploadFileTypeInfo() As DataSet

        Function GetClientUploadFileTypeById(ByVal ID As Integer) As Base_ClientUploadFileType
    End Interface
End Namespace
