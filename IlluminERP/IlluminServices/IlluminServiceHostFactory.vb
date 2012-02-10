' IlluminServiceHostFactory
Imports System.ServiceModel.Activation
Imports System.EnterpriseServices
Imports System
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration
Imports System.Threading
Imports System.Xml

Imports DataAccess.Model
Imports DataAccess.BLL

' The Transaction attribute makes your class transaction aware.  Your class can set the transactional type of your 
' object to one of the following:
' 
' Required
' Required New
' Supported
' Not Supported
' Disabled

Namespace Illumin.Services

    <Transaction(TransactionOption.Supported)> _
    Public Class IlluminServiceHostFactory
        Inherits ServiceHostFactory

        Private Shared ReadOnly _bindingCache As Dictionary(Of String, Binding)

        Private Shared ReadOnly _bindingLock As ReaderWriterLockSlim

        Shared Sub New()
            _bindingCache = New Dictionary(Of String, Binding)()
            _bindingLock = New ReaderWriterLockSlim()
        End Sub

        Public Overloads Function CreateServiceHost(ByVal serviceType As Type) As ServiceHost
            Dim uris(0) As Uri
            Return CreateServiceHost(serviceType, uris)
        End Function

        Protected Overrides Function CreateServiceHost(ByVal serviceType As Type, ByVal baseAddress As Uri()) As ServiceHost
            If serviceType Is Nothing Then
                Throw New ArgumentNullException("serviceType")
            End If

            Try
                Dim service As WCF_ServiceInfo
                Dim hostElement As HostElement
                Dim serviceHost As ServiceHost
                Dim serviceTypeName As String

                serviceTypeName = WcfConfigurationHelper.GetQualifiedTypeName(serviceType)
                If String.IsNullOrEmpty(serviceTypeName) Then
                    Throw New InvalidOperationException("serviceTypeName is null for type: " + serviceType.Name)
                End If
                Dim serviceBLL As New WCF_ServiceBLL
                service = serviceBLL.GetWCFServiceByType(serviceTypeName)
                hostElement = WcfConfigurationHelper.ParseHostElement(baseAddress, service)
                serviceHost = IlluminServiceHostFactory.CreateServiceHost(service, serviceType, Nothing, baseAddress)

                Return serviceHost

            Catch ex As Exception
                Throw New Exception("Exception Occured")
            End Try

        End Function

        Private Overloads Shared Function CreateServiceHost(ByVal serviceConfig As WCF_ServiceInfo, ByVal serviceImplType As Type, ByVal singleton As Object, ByVal baseAddresses As Uri()) As ServiceHost
            If serviceConfig Is Nothing Then
                Throw New ArgumentNullException("serviceConfig")
            End If
            If serviceImplType Is Nothing Then
                Throw New ArgumentNullException("serviceImplType")
            End If

            Dim serviceHost As ServiceHost
            If String.IsNullOrEmpty(serviceConfig.CustomServiceHostType) Then
                serviceHost = New ServiceHost(serviceImplType, baseAddresses)
            Else
                Dim serviceHostType As Type
                serviceHostType = Type.GetType(serviceConfig.CustomServiceHostType)
                If serviceHostType Is Nothing Then
                    Throw New ConfigurationErrorsException(String.Format("Specified service host type - {0} could not be loaded!", serviceConfig.CustomServiceHostType))
                End If
                serviceHost = IIf(singleton = Nothing, _
                                  Activator.CreateInstance(serviceHostType, New Object() {serviceImplType, baseAddresses}), _
                                  Activator.CreateInstance(serviceHostType, New Object() {singleton, baseAddresses}))
            End If

            If serviceHost Is Nothing Then
                Throw New ConfigurationErrorsException(String.Format("Specified service host type - {0} could not be initialized!", serviceConfig.CustomServiceHostType))
            End If

            Return serviceHost
        End Function

        Private Shared Sub ApplyServiceHostConfiguration(ByVal serviceHost As ServiceHost, ByVal hostElement As HostElement)
            If hostElement IsNot Nothing AndAlso hostElement.Timeouts IsNot Nothing Then
                serviceHost.OpenTimeout = hostElement.Timeouts.OpenTimeout
                serviceHost.CloseTimeout = hostElement.Timeouts.CloseTimeout
            End If
        End Sub

        Private Shared Sub ApplyServiceBehaviorConfiguration(ByVal serviceHost As ServiceHost, ByVal config As WCF_ServiceInfo)
            If Not String.IsNullOrEmpty(config.ServiceBehaviorXml) Then
                Dim doc As XmlDocument
                Dim customBehaviorElements As List(Of BehaviorExtensionElement)
                Dim serviceBehaviorElement As ServiceBehaviorElement

                doc = New XmlDocument()
                doc.LoadXml(config.ServiceBehaviorXml)

            End If

        End Sub
    End Class
End Namespace