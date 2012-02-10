

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IClient_ClientInfoGetWay
        Function GetClientInfoGetWayInfoByID(ByVal ID As Integer) As Client_ClientInfoGetWay

        Function GetClientInfoGetWayByClientId(ByVal ClientId As Integer) As DataSet

        Function AddClientInfoGetWayInfo(ByVal Info As Model.Client_ClientInfoGetWay) As Integer

        Function UpdateClientInfoGetWayInfo(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean

        Function DeleteClientINfoGetWay(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean

        Function IsExistRecord(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean


    End Interface
End Namespace

