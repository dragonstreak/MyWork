Public Class EnumTextAttribute
    Inherits Attribute
    Private texts() As String

    Public Sub New(ByVal ParamArray enumTexts() As String)
        Me.texts = enumTexts
    End Sub

    Default Public ReadOnly Property DefaultProperty(ByVal i As Integer) As String
        Get
            Return texts(i)
        End Get
    End Property
End Class

Public Class EnumTextHelper
    Public Shared Function GetEnumTextList(ByVal enumType As Type) As IEnumerable
#If DEBUG Then
        If enumType Is Nothing Then
            Throw New ArgumentNullException("enumType", "EnumType can not be null")
        End If
        If Not enumType.IsEnum Then
            Throw New ArithmeticException("the parameter should be a enum")
        End If
#End If
        Dim table As New DataTable
        table.Columns.Add("ID", GetType(Integer))
        table.Columns.Add("TEXT", GetType(String))

        Dim attr As EnumTextAttribute = Attribute.GetCustomAttribute(enumType, GetType(EnumTextAttribute), False)

        Dim values As Array = [Enum].GetValues(enumType)


        For i As Integer = 0 To values.Length - 1
            Dim v As Integer
            v = Convert.ToInt32(values(i))
            If v = -1 Then
                Continue For
            End If
            Dim dr As DataRow = table.NewRow()
            dr("ID") = v
            dr("TEXT") = attr(i)
            table.Rows.Add(dr)
        Next

        table.AcceptChanges()

        Return table.DefaultView

    End Function

    Public Shared Function GetEnumText(ByVal value As Object) As String
        Dim tp As Type = value.GetType()
        If Convert.ToInt32(value) = -1 Then
            Return String.Empty
        End If
        Dim attr As EnumTextAttribute = Attribute.GetCustomAttribute(tp, GetType(EnumTextAttribute), False)
        Dim values As Array = [Enum].GetValues(tp)
        For i As Integer = 0 To values.Length - 1
            If Convert.ToInt32(values.GetValue(i)) = Convert.ToInt32(value) Then
                Return attr(i)
            End If
        Next
        Throw New ArgumentException("Invalid Enum value")
    End Function

    Public Shared Function GetTextEnum(ByVal text As String, ByVal enumType As Type) As Object
        Dim attr As EnumTextAttribute = Attribute.GetCustomAttribute(enumType, GetType(EnumTextAttribute), False)
        Dim values As Array = [Enum].GetValues(enumType)

        For i As Integer = 0 To values.Length - 1
            Dim v As Integer = Convert.ToInt32(values.GetValue(i))
            If v = -1 Then
                Continue For
            End If
            If text.Equals(attr(i)) Then
                Return values.GetValue(i)
            End If
        Next
        Return Nothing
    End Function

End Class

