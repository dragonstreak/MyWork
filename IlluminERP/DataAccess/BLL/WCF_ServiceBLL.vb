Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class WCF_ServiceBLL
        Private factory As New DALFactory
        Private serviceDAL As IWCF_Service = factory.GetProduct("WCF_ServiceDAO")

        Public Sub New()

        End Sub

        Function GetEntityById(ByVal Id As Integer) As WCF_ServiceInfo
            Return serviceDAL.GetEntityById(Id)
        End Function

        Function GetEntityDataSet() As DataSet
            Return serviceDAL.GetEntityDataSet()
        End Function

        Sub DeleteEntityById(ByVal Id As Integer)
            serviceDAL.DeleteEntityById(Id)
        End Sub

        Function GetAllWCFService() As List(Of WCF_ServiceInfo)
            Return serviceDAL.GetAllWCFService()
        End Function

        Function GetWCFServiceByType(ByVal serviceType As String) As WCF_ServiceInfo
            Return serviceDAL.GetWCFServiceByType(serviceType)
        End Function
    End Class
End Namespace
