Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IPMS_UploadFileType
        Function GetFileTypeInfo() As DataSet

        Function GetFileTypeByID(ByVal ID As Integer) As PMS_UploadFileType
    End Interface
End Namespace
