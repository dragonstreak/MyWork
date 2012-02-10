Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IClient_ClientInfo

        Function GetClientInfo() As DataSet

        Function GetClientInfoByID(ByVal ID As Integer) As Client_ClientInfo

        Function GetClientInfoByClientType(ByVal ClientType As Integer) As DataView

        Function AddClientInfo(ByVal info As Client_ClientInfo) As Integer

        Function UpdateClientInfo(ByVal Info As Client_ClientInfo) As Boolean

        Function IsExistClient(ByVal info As Model.Client_ClientInfo) As Boolean

        Function IsExistClientByCode(ByVal ClientCode As String) As Boolean

        Function UpdateClientStatus(ByVal Id As Integer) As Boolean


    End Interface
End Namespace

