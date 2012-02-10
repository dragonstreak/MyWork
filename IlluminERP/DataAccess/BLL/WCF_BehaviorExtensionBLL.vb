Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL


    Public Class WCF_BehaviorExtensionBLL
        Private factory As New DALFactory
        Private behaviorDAL As IWcf_BehaviorExtension = factory.GetProduct("Wcf_BehaviorExtensionDAO")

        Public Sub New()

        End Sub

        Function GetEntityById(ByVal Id As Integer) As Wcf_BehaviorExtensionInfo
            Return behaviorDAL.GetEntityById(Id)
        End Function

        Function GetEntityDataSet() As DataSet
            Return behaviorDAL.GetEntityDataSet()
        End Function

        Sub DeleteEntityById(ByVal Id As Integer)
            behaviorDAL.DeleteEntityById(Id)
        End Sub

        Function GetWCFBehaviorExtensionByName(ByVal extensionName As String) As Wcf_BehaviorExtensionInfo
            Return behaviorDAL.GetWCFBehaviorExtensionByName(extensionName)
        End Function
    End Class
End Namespace
