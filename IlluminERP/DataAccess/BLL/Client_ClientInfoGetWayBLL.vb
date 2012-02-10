Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Client_ClientInfoGetWayBLL
        Private factory As New DALFactory
        Private ClientInfoGetWayDAL As IClient_ClientInfoGetWay = factory.GetProduct("Client_ClientInfoGetWayDAO")

        Public Sub New()

        End Sub

        Public Function GetClientInfoGetWayInfoByID(ByVal ID As Integer) As Client_ClientInfoGetWay
            Return ClientInfoGetWayDAL.GetClientInfoGetWayInfoByID(ID)
        End Function

        Public Function GetClientInfoGetWayByClientId(ByVal ClientId As Integer) As DataSet
            Return ClientInfoGetWayDAL.GetClientInfoGetWayByClientId(ClientId)
        End Function

        Public Function AddClientInfoGetWayInfo(ByVal Info As Model.Client_ClientInfoGetWay) As Integer
            Return ClientInfoGetWayDAL.AddClientInfoGetWayInfo(Info)
        End Function

        Public Function UpdateClientInfoGetWayInfo(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean
            Return ClientInfoGetWayDAL.UpdateClientInfoGetWayInfo(Info)
        End Function

        Public Function DeleteClientINfoGetWay(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean
            Return ClientInfoGetWayDAL.DeleteClientINfoGetWay(Info)
        End Function

        Public Function IsExistRecord(ByVal Info As Model.Client_ClientInfoGetWay) As Boolean
            Return ClientInfoGetWayDAL.IsExistRecord(Info)
        End Function
    End Class
End Namespace


