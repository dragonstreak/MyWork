Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Json
Imports System.IO

Public Module JSONExtension
    <Extension()>
    Public Function FromJsonToObj(Of T)(ByVal jsonString As String) As T
        Dim serializer As New DataContractJsonSerializer(GetType(T))
        Dim ms As New MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonString))

        Dim obj As T
        obj = serializer.ReadObject(ms)
        ms.Close()
        Return obj
    End Function

    <Extension()>
    Public Function FromObjToJson(Of T)(ByVal obj As T) As String
        Dim serializer As New DataContractJsonSerializer(GetType(T))
        Dim ms As New MemoryStream()
        serializer.WriteObject(ms, obj)
        ms.Position = 0
        Dim json As String
        json = System.Text.Encoding.UTF8.GetString(ms.GetBuffer())
        ms.Close()
        Return json

    End Function



End Module
