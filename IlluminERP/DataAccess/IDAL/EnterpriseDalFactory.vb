Imports Utils
Imports Microsoft.Practices.Unity
Namespace IDAL
    Friend Class EnterpriseDalFactory
        Public Function GetProduct(Of pInterface, pClass)() As pInterface
            If Not ERPContainer.container.IsRegistered(GetType(pInterface)) Then
                ERPContainer.container.RegisterType(GetType(pInterface), GetType(pClass))
            End If
            Return ERPContainer.container.Resolve(GetType(pInterface))
        End Function
    End Class
End Namespace
