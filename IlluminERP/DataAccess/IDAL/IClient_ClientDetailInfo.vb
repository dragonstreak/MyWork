Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IClient_ClientDetailInfo

        Function GetClientDetailInfoByID(ByVal ID As Integer) As Client_ClientDetailInfo

        'Function GetClientDetailInfoByClientId(ByVal ClientId As Integer) As Client_ClientDetailInfo

        Function AddClientDetailInfo(ByVal Info As Model.Client_ClientDetailInfo) As Integer

        Function UpdateClientDetailInfo(ByVal Info As Model.Client_ClientDetailInfo) As Boolean

        Function GetClientDetailInfo() As DataSet

        Function GetClientDetailInfoByClientId(ByVal ClientId As Integer) As DataSet

        Function DeleteClientDetailInfo(ByVal Id As Integer) As Boolean

    End Interface
End Namespace
