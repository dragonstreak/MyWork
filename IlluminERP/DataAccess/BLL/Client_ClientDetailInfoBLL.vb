

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Client_ClientDetailInfoBLL
        Private factory As New DALFactory
        Private ClientDetailInfoDAL As IClient_ClientDetailInfo = factory.GetProduct("Client_ClientDetailInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetClientDetailInfoByID(ByVal ID As Integer) As Client_ClientDetailInfo
            Return ClientDetailInfoDAL.GetClientDetailInfoByID(ID)
        End Function

        'Public Function GetClientDetailInfoByClientId(ByVal ClientId As Integer) As Client_ClientDetailInfo
        '    Return ClientDetailInfoDAL.GetClientDetailInfoByClientId(ClientId)
        'End Function

        Public Function AddClientDetailInfo(ByVal Info As Model.Client_ClientDetailInfo) As Integer
            Return ClientDetailInfoDAL.AddClientDetailInfo(Info)
        End Function

        Public Function UpdateClientDetailInfo(ByVal Info As Model.Client_ClientDetailInfo) As Boolean
            Return ClientDetailInfoDAL.UpdateClientDetailInfo(Info)
        End Function

        Public Function GetClientDetailInfo() As DataSet
            Return ClientDetailInfoDAL.GetClientDetailInfo
        End Function

        Public Function GetClientDetailInfoByClientId(ByVal ClientId As Integer) As DataSet
            Return ClientDetailInfoDAL.GetClientDetailInfoByClientId(ClientId)
        End Function


        Public Function DeleteClientDetailInfo(ByVal Id As Integer) As Boolean
            Return ClientDetailInfoDAL.DeleteClientDetailInfo(Id)
        End Function

    End Class
End Namespace
