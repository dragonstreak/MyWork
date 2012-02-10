
Public Class DataConvert
    Public Shared Function ConvertDataToInt32(ByVal o As Object) As Int32
        If Convert.IsDBNull(o) Then
            Return 0
        Else
            Return Convert.ToInt32(o)
        End If
    End Function

    Public Shared Function ConvertDataToDateTime(ByVal o As Object) As DateTime
        If Convert.IsDBNull(o) Then
            Return ConstantsUtils.MinDate
        Else
            Return Convert.ToDateTime(o)
        End If
    End Function

    Public Shared Function ConvertDataToString(ByVal o As Object) As String
        If Convert.IsDBNull(o) Then
            Return String.Empty
        Else
            Return o.ToString()
        End If
    End Function

    Public Shared Function ConvertDataToDecimal(ByVal o As Object) As Decimal
        If Convert.IsDBNull(o) Then
            Return String.Empty
        Else
            Return o.ToString()
        End If
    End Function

    Public Shared Function ConvertStringAsSqlString(ByVal str As String) As String
        Dim strConvertString As String
        strConvertString = str.Replace("'", "''")
        Return strConvertString
    End Function
End Class
