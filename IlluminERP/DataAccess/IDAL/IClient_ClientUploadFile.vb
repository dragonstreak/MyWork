
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IClient_ClientUploadFile

        Function GetClientUploadFileInfoByID(ByVal ID As Integer) As Client_ClientUploadFile

        Function GetClientUploadFileInfoByClientId(ByVal ClientId As Integer) As DataSet

        Function AddClientUploadFileInfo(ByVal Info As Model.Client_ClientUploadFile) As Integer

        Function UpdateClientUploadFileInfo(ByVal Info As Model.Client_ClientUploadFile) As Boolean

        Function DeleteClintUploadFile(ByVal Id As Integer) As Boolean


    End Interface
End Namespace
