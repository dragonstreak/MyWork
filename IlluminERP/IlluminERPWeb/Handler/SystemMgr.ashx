<%@ WebHandler Language="VB" Class="SystemMgr" %>

Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Runtime.Serialization.Json
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Text.RegularExpressions
Imports Utils

'<WebService(Namespace:="http://tempuri.org/")>
'<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
Public Class SystemMgr : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        
        If context.Request.InputStream.Length = 0 Then
            Exit Sub
        End If
        
        Dim aaa As String = context.Request.Form("Method")
        
        Dim reader = New StreamReader(context.Request.InputStream, System.Text.Encoding.UTF8)
        
        Dim rsb As New StringBuilder
        Dim read(1024) As Char
        
        Dim count = reader.Read(read, 0, 1024)
        While count > 0
            Dim str = New String(read, 0, count)
            rsb.Append(str)
            count = reader.Read(read, 0, 1024)
                    
            reader.Close()
            reader.Dispose()
            context.Request.InputStream.Close()
            context.Request.InputStream.Dispose()
        End While
        
        Dim jsonString As String = rsb.ToString()
        
        Dim jsonAnalysis As Regex = New Regex("^{""Method"":""(\w{1,50})"",""Args"":({.+})}$")
        Dim dataMatch As Match = jsonAnalysis.Match(jsonString)
        If dataMatch Is Nothing orelse dataMatch.Groups.Count < 3 Then
            Exit Sub
        End If
        
        Dim methodName As String = dataMatch.Groups(1).Value
        Dim argsString As String = dataMatch.Groups(2).Value
        Dim returnString As String = String.Empty
                        
        If methodName.Equals("GetPageModule", StringComparison.OrdinalIgnoreCase) Then
            Dim getPageModuleParam As GetPageModuleParam = argsString.FromJsonToObj(Of GetPageModuleParam)()
            If getPageModuleParam IsNot Nothing Then
                Dim getPageModuleResult As GetPageModuleResult = SystemMgrService.Instance.GetPageModule(getPageModuleParam)
                returnString = getPageModuleResult.FromObjToJson()
            End If
        End If
        
        context.Response.Write(returnString)
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

        
    
End Class