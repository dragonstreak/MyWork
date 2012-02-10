<%@ WebHandler Language="VB" Class="UserMgr" %>

Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Runtime.Serialization.Json
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Text.RegularExpressions
Imports Utils


Public Class UserMgr : Implements IHttpHandler
    
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If context.Request.InputStream.Length = 0 Then
            Exit Sub
        End If
        
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
        If dataMatch Is Nothing OrElse dataMatch.Groups.Count < 3 Then
            Exit Sub
        End If
        
        Dim methodName As String = dataMatch.Groups(1).Value
        Dim argsString As String = dataMatch.Groups(2).Value
        Dim returnString As String = String.Empty
                        
        If methodName.Equals("GetUserInfo", StringComparison.OrdinalIgnoreCase) Then
            Dim getUserInfoParam As GetUserInfoParam = argsString.FromJsonToObj(Of GetUserInfoParam)()
            If getUserInfoParam IsNot Nothing Then
                Dim getUserInfoResult As GetUserInfoResult = UserMgrService.Instance.GetUserInfo(getUserInfoParam)
                returnString = getUserInfoResult.FromObjToJson()
            End If
        End If
        context.Response.ContentType = "json"
        context.Response.Write(returnString)
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class