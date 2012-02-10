Imports System.ServiceModel.Configuration
Imports System.Reflection
Imports System.Threading
Imports System.Configuration
Imports System.ServiceModel.Description
Imports System.Xml
Imports System.IO
Imports System.Collections

Imports DataAccess.BLL
Imports DataAccess.Model

Namespace Illumin.Services
    Public Class WcfConfigurationHelper

        Private Shared ReadOnly _methodDeserializeElement As MethodInfo
        Private Shared ReadOnly _methodCreateBehavior As MethodInfo
        Private Shared ReadOnly _methodLoadIdentity As MethodInfo
        Private Shared ReadOnly _fieldReadOnly As FieldInfo
        Private Shared ReadOnly _readOnlyLock As New ReaderWriterLockSlim()

#Region "Constructors"

        Shared Sub New()

            _methodDeserializeElement = GetType(ConfigurationElement).GetMethod(
                "DeserializeElement", BindingFlags.NonPublic Or BindingFlags.Instance)

            _methodCreateBehavior = GetType(BehaviorExtensionElement).GetMethod(
                "CreateBehavior", BindingFlags.NonPublic Or BindingFlags.Instance)

            Dim type = GetType(ContractDescription).Assembly.GetType("System.ServiceModel.Description.ConfigLoader")

            _methodLoadIdentity = type.GetMethod(
                "LoadIdentity", BindingFlags.Instance Or BindingFlags.Static Or BindingFlags.NonPublic)

            _fieldReadOnly = GetType(ConfigurationElementCollection).GetField(
                "bReadOnly", BindingFlags.NonPublic Or BindingFlags.Instance)
        End Sub

#End Region

        Public Shared Function GetQualifiedTypeName(ByVal type As Type) As String
            If type Is Nothing Then
                Return Nothing
            End If
            Dim typeName As String
            typeName = type.AssemblyQualifiedName
            If typeName.EndsWith("PublicKeyToken=null") Then
                Return type.FullName + ", " + type.Assembly.GetName().Name
            End If

            Return typeName
        End Function

        Public Shared Function ParseHostElement(ByRef baseAddresses As Uri(), ByVal service As WCF_ServiceInfo) As HostElement
            If Not String.IsNullOrEmpty(service.ServiceHostXml) Then
                Dim hostElement As New HostElement
                DeserializeConfigurationElement(hostElement, service.ServiceHostXml)
                If baseAddresses Is Nothing OrElse baseAddresses.Length = 0 Then
                    baseAddresses = GetBaseAddressesFromHostElement(hostElement)
                End If
                Return hostElement
            End If

            Return Nothing
        End Function

        Private Shared Function GetBaseAddressesFromHostElement(ByVal hostElement As HostElement) As Uri()

            Dim list As New List(Of Uri)

            If hostElement IsNot Nothing AndAlso hostElement.BaseAddresses IsNot Nothing Then
                For i As Integer = 0 To hostElement.BaseAddresses.Count
                    list.Add(New Uri(hostElement.BaseAddresses(i).BaseAddress))
                Next

            End If
            
            Return list.ToArray()
        End Function

        Public Shared Sub DeserializeConfigurationElement(ByVal element As ConfigurationElement, ByVal serializedXML As String)
            If element Is Nothing Then
                Return
            End If

            If (String.IsNullOrEmpty(serializedXML)) Then
                Return
            End If

            Dim rdr As New XmlTextReader(New StringReader(serializedXML))
            rdr.Read()
            rdr.ReadSubtree()
            _methodDeserializeElement.Invoke(element, New Object() {rdr, False})

        End Sub

        'Public Shared Function FilterCustomBehaviorElements(ByVal doc As XmlDocument, ByVal appCode As String)
        '    Dim customBehaviorElements As List(Of BehaviorExtensionElement)
        '    Dim coustomBehaviorNodes As List(Of XmlNode)

        '    For Each node As XmlNode In doc.FirstChild.ChildNodes

        '    Next

        'End Function
    End Class
End Namespace