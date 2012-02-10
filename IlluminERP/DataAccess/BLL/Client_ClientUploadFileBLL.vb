Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Client_ClientUploadFileBLL
        Private factory As New DALFactory
        Private ClientUploadInfoDAL As IClient_ClientUploadFile = factory.GetProduct("Client_ClientUploadFileDAO")

        Public Sub New()

        End Sub

        Public Function GetClientUploadFileInfoByID(ByVal ID As Integer) As Client_ClientUploadFile
            Return ClientUploadInfoDAL.GetClientUploadFileInfoByID(ID)
        End Function

        Public Function GetClientUploadFileInfoByClientId(ByVal ClientId As Integer) As DataSet
            Return ClientUploadInfoDAL.GetClientUploadFileInfoByClientId(ClientId)

        End Function

        Public Function AddClientUploadFileInfo(ByVal Info As Model.Client_ClientUploadFile) As Integer
            Return ClientUploadInfoDAL.AddClientUploadFileInfo(Info)
        End Function

        Public Function UpdateClientUploadFileInfo(ByVal Info As Model.Client_ClientUploadFile) As Boolean
            Return ClientUploadInfoDAL.UpdateClientUploadFileInfo(Info)
        End Function

        Public Function DeleteClintUploadFile(ByVal Id As Integer) As Boolean
            ClientUploadInfoDAL.DeleteClintUploadFile(Id)
        End Function
    End Class

End Namespace
