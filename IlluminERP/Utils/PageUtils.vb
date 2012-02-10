Imports System
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions

Imports Telerik.Web.UI


    Public Class PageUtils
      
      
      Public Shared Sub InitDropDownListSelectedIndex(ddl As System.Web.UI.WebControls.DropDownList, sValue As String)
         If ddl.Items.Count = 0 Then
            Return
        End If
        If Not (ddl.SelectedItem Is Nothing) Then
            ddl.SelectedItem.Selected = False
        End If
        If sValue = String.Empty Then
            ddl.Items(0).Selected = True
        Else
            Dim item As ListItem = Nothing
            item = ddl.Items.FindByValue(sValue)
            If Not (item Is Nothing) Then
                item.Selected = True
            End If
            'ddl.Items.FindByValue(sValue).Selected = True
        End If
      End Sub 'InitDropDownListSelectedIndex
       
      
      Overloads Public Shared Sub AddDropDownListSelectAll(ddl As System.Web.UI.WebControls.DropDownList, index As Integer)
        ddl.Items.Insert(index, New System.Web.UI.WebControls.ListItem("--ALL--", "-1"))
         Return
      End Sub 'AddDropDownListSelectAll
      
      
      
      Overloads Public Shared Sub AddDropDownListSelectAll(ddl As System.Web.UI.WebControls.DropDownList)
         AddDropDownListSelectAll(ddl, 0)
         Return
      End Sub 'AddDropDownListSelectAll
      
      
      
      Overloads Public Shared Sub AddDropDownListSelectNone(ddl As System.Web.UI.WebControls.DropDownList, index As Integer)
        ddl.Items.Insert(index, New System.Web.UI.WebControls.ListItem("--Null--", "0"))
         Return
      End Sub 'AddDropDownListSelectNone
      
      
      
      Overloads Public Shared Sub AddDropDownListSelectNone(ddl As System.Web.UI.WebControls.DropDownList)
         AddDropDownListSelectNone(ddl, 0)
         Return
      End Sub 'AddDropDownListSelectNone
      
      
      
      Public Shared Sub BindDropDownList(ddl As System.Web.UI.WebControls.DropDownList, dataSource As Object, valueField As String, textField As String, addedItemFlag As Integer)
         
         ddl.DataValueField = valueField
         ddl.DataTextField = textField
         ddl.DataSource = dataSource
         ddl.DataBind()
         
         If(addedItemFlag And 1) = 1 Then
            AddDropDownListSelectAll(ddl)
         End If
         If(addedItemFlag And 2) = 2 Then
            AddDropDownListSelectNone(ddl)
         End If 
         Return
      End Sub 'BindDropDownList
      
      
    Public Shared Sub InitDropDownListSelectedIndex(ByVal cb As RadComboBox, ByVal sValue As String)
        If cb.Items.Count = 0 Then
            Return
        End If
        If Not (cb.SelectedItem Is Nothing) Then
            cb.SelectedItem.Selected = False
        End If
        If sValue = String.Empty Then
            cb.Items(0).Selected = True
        Else
            Dim item As RadComboBoxItem = Nothing
            item = cb.FindItemByValue(sValue)
            If Not (item Is Nothing) Then
                item.Selected = True
            End If
            cb.FindItemByValue(sValue).Selected = True
        End If
    End Sub 'InitDropDownListSelectedIndex


    Public Overloads Shared Sub AddComboBoxListSelectAll(ByVal cb As RadComboBox, ByVal index As Integer)

        cb.Items.Insert(index, New RadComboBoxItem("--ALL--", "-1"))
        Return
    End Sub 'AddDropDownListSelectAll



    Public Overloads Shared Sub AddComboBoxSelectAll(ByVal cb As RadComboBox)
        AddComboBoxListSelectAll(cb, 0)
        Return
    End Sub 'AddDropDownListSelectAll



    Public Overloads Shared Sub AddComboBoxSelectNone(ByVal cb As RadComboBox, ByVal index As Integer)
        cb.Items.Insert(index, New RadComboBoxItem("--Null--", "0"))
        Return
    End Sub 'AddDropDownListSelectNone



    Public Overloads Shared Sub AddDropDownListSelectNone(ByVal cb As RadComboBox)
        AddComboBoxSelectNone(cb, 0)
        Return
    End Sub 'AddDropDownListSelectNone



    Public Shared Sub BindComboBoxList(ByVal cb As RadComboBox, ByVal dataSource As Object, ByVal valueField As String, ByVal textField As String, ByVal addedItemFlag As Integer)
        cb.DataValueField = valueField
        cb.DataTextField = textField
        cb.DataSource = dataSource
        cb.DataBind()

        If (addedItemFlag And 1) = 1 Then
            AddComboBoxSelectAll(cb)
        End If
        If (addedItemFlag And 2) = 2 Then
            AddDropDownListSelectNone(cb)
        End If
        Return
    End Sub 'BindDropDownList
    
      
      
    'Public Shared Sub FillDropList(drList As DropDownList, vObj As Object)
    '   If vObj Is Nothing Then
    '      Return
    '   Else
    '      Dim li As ListItem
    '      For Each li In  drList.Items
    '         li.Selected = False
    '      Next li 
    '      Dim li As ListItem
    '      For Each li In  drList.Items
    '         If li.Value = vObj.ToString() Then
    '            li.Selected = True
    '            Exit ForEach
    '         End If
    '      Next li
    '   End If
    'End Sub
      
      
      
      
      Overloads Public Shared Function GetMaxString(dv As DataView, dataField As String) As String
         If dv Is Nothing Then
            Return ""
         End If 
         Dim maxLength As Integer = 0
         Dim tempLength As Integer = 0
         Dim strMax As String = ""
         Dim i As Integer
         For i = 0 To dv.Count - 1
            tempLength = dv(i)(dataField).ToString().Length
            If tempLength > maxLength Then
               maxLength = tempLength
               strMax = dv(i)(dataField).ToString()
            End If
         Next i
         Return strMax
      End Function 'GetMaxString
      
      
      
      
      Overloads Public Shared Function GetMaxString(strArr() As String) As String
         If strArr.Length = 0 Then
            Return ""
         End If 
         Dim maxLength As Integer = 0
         Dim tempLength As Integer = 0
         Dim strMax As String = ""
         Dim i As Integer
         For i = 0 To strArr.Length - 1
            tempLength = strArr(i).Length
            If tempLength > maxLength Then
               maxLength = tempLength
               strMax = strArr(i)
            End If
         Next i
         Return strMax
      End Function 'GetMaxString
      
      
      
    'Public Shared Function FormatString(ByVal obj As Object, ByVal maxLength As Integer, ByVal bQuan As Boolean) As String
    '    Dim strOrigin As String = obj.ToString()
    '    Dim sb As New System.Text.StringBuilder

    '    If bQuan Then
    '        Dim i As Integer
    '        For i = 0 To strOrigin.Length - 1
    '            Dim c As Char = CChar(strOrigin(i))
    '            If c >= 0 And c <= 127 Then
    '                If c = CChar(32) Then
    '                    c = CChar(12288)
    '                Else
    '                    c = CChar(c + 65248)
    '                End If
    '            End If
    '            sb.Append(c)
    '        Next i
    '        Dim i As Integer
    '        For i = 0 To (maxLength - strOrigin.Length) - 1
    '            If bQuan Then
    '                sb.Append(CChar(12288))
    '            End If
    '        Next i
    '    Else
    '        Dim i As Integer
    '        For i = 0 To (maxLength - strOrigin.Length) - 1
    '            sb.Append(CChar(32))
    '        Next i
    '        sb.Append(strOrigin)
    '    End If

    '    Return sb.ToString()
    'End Function 'FormatString



    'Protected Overloads Function IsNull(ByVal na As System.Data.SqlTypes.INullable) As String
    '    Return IsNull(na, String.Empty)
    'End Function 'IsNull


    'Protected Overloads Function IsNull(ByVal na As System.Data.SqlTypes.INullable, ByVal def As String) As String
    '    If na.IsNull Then
    '        Return def
    '    Else
    '        If TypeOf na Is System.Data.SqlTypes.SqlDecimal Then
    '            Return CType(na, System.Data.SqlTypes.SqlDecimal).Value.ToString("#,##0.00")
    '        Else
    '            If TypeOf na Is System.Data.SqlTypes.SqlDateTime Then
    '                Return CType(na, System.Data.SqlTypes.SqlDateTime).Value.ToString("yyyy-MM-dd")
    '            Else
    '                Return na.ToString()
    '            End If
    '        End If
    '    End If
    'End Function 'IsNull

    Public Shared Function CreateExcelTable(ByVal columnstext() As String) As DataTable
        Dim dt As New DataTable
        Dim i As Integer
        For i = 0 To columnstext.Length - 1
            dt.Columns.Add(columnstext(i))
        Next i
        Return dt
    End Function 'CreateExcelTable

    Public Shared Function CalculateYearAndMonthSpan(ByVal beginDate As DateTime, ByVal endDate As DateTime) As String
        Dim year, month As Integer
        If (DateTime.Compare(beginDate, endDate) < 0) Then
            year = endDate.Year - beginDate.Year
            month = endDate.Month - beginDate.Month
            If (month < 0) Then
                year = year - 1
                month = month + 12
            End If
            Dim strResult As String
            If year > 1 Then
                If month > 1 Then
                    strResult = String.Format("{0} years and {1} months ", year, month)
                Else
                    strResult = String.Format("{0} years and {1} month ", year, month)
                End If
            Else
                If month > 1 Then
                    strResult = String.Format("{0} year and {1} months ", year, month)
                Else
                    strResult = String.Format("{0} year and {1} month ", year, month)
                End If
            End If
            Return strResult
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function CalculateYearAndMonthSpanList(ByVal beginDate As DateTime, ByVal endDate As DateTime) As Integer()
        Dim year, month As Integer

        year = endDate.Year - beginDate.Year
        month = endDate.Month - beginDate.Month
        If (DateTime.Compare(beginDate, endDate) < 0) Then
            If (month < 0) Then
                year = year - 1
                month = month + 12
            End If
        Else
            If (month > 0) Then
                year = year + 1
                month = month - 12
            End If
        End If
        Dim result(2) As Integer
        result(0) = System.Math.Abs(year)
        result(1) = System.Math.Abs(month)

        Return result
    End Function

    '通过添加前缀，格式化 正整数 或 0
    'prefix 前缀字符
    'length 返回的字符串总长度
    '需要格式化的整数
    Public Shared Function FormartIntegerPrefix(ByVal prefix As String, ByVal length As Integer, ByVal number As Integer)
        If prefix Is Nothing OrElse number < 0 Then
            Return String.Empty
        End If
        Dim temp As String = String.Empty

        Dim prefixLength As Integer = length - number.ToString.Length

        For i As Integer = 0 To prefixLength - 1
            temp &= prefix
        Next

        Return temp & number.ToString()

    End Function

    ''' <summary>
    ''' 初始化PanelBar导航信息
    ''' </summary>
    ''' <param name="_PanelBar">控件ID</param>
    ''' <param name="_ID">当前ID</param>
    ''' <param name="_DataFieldParentID">父层ID</param>
    ''' <param name="_DataTextField">显示字段</param>
    ''' <param name="_DataValueField">值字段</param>
    ''' <param name="_DataNavigateUrlField">导航字段</param>
    ''' <remarks></remarks>
    Public Shared Sub InitPanelBar(ByVal _PanelBar As Telerik.Web.UI.RadPanelBar, ByVal _ID As String, ByVal _DataFieldParentID As String, ByVal _DataTextField As String, ByVal _DataValueField As String, ByVal _DataNavigateUrlField As String)
        'Establish hierarchy:
        _PanelBar.DataFieldID = _ID
        _PanelBar.DataFieldParentID = _DataFieldParentID
        'Set Text, Value, and NavigateUrl:
        _PanelBar.DataTextField = _DataTextField
        _PanelBar.DataValueField = _DataValueField
        _PanelBar.DataNavigateUrlField = _DataNavigateUrlField
    End Sub

    ''' <summary>
    ''' 初始化PanelBar导航信息
    ''' </summary>
    ''' <param name="_dv" >数据源</param>
    ''' <param name="_PanelBar">控件ID</param>
    ''' <param name="_ID">当前ID</param>
    ''' <param name="_DataFieldParentID">父层ID</param>
    ''' <param name="_DataTextField">显示字段</param>
    ''' <param name="_DataValueField">值字段</param>
    ''' <param name="_DataNavigateUrlField">导航字段</param>
    ''' <remarks></remarks>
    Public Shared Sub InitPanelBar(ByVal _dv As DataView, ByVal _PanelBar As Telerik.Web.UI.RadPanelBar, ByVal _ID As String, ByVal _DataFieldParentID As String, ByVal _DataTextField As String, ByVal _DataValueField As String, ByVal _DataNavigateUrlField As String)

        _PanelBar.DataSource = _dv
        'Establish hierarchy:
        _PanelBar.DataFieldID = _ID
        _PanelBar.DataFieldParentID = _DataFieldParentID
        'Set Text, Value, and NavigateUrl:
        _PanelBar.DataTextField = _DataTextField
        _PanelBar.DataValueField = _DataValueField
        _PanelBar.DataNavigateUrlField = _DataNavigateUrlField
        _PanelBar.DataBind()
    End Sub
    Public Shared Sub BindScheduler(ByVal _ds As DataSet, ByVal _Scheduler As Telerik.Web.UI.RadScheduler)
        _Scheduler.DataSource = _ds
        _Scheduler.DataBind()
    End Sub

    Public Shared Function GetPageName(ByVal rawUrl As String) As String
        Dim pageNamePattern As New Regex("/(\w{1,30}.aspx)")
        Dim pageMacth As Match
        pageMacth = pageNamePattern.Match(rawUrl)
        Dim pageName As String = Nothing
        If pageMacth.Groups IsNot Nothing AndAlso pageMacth.Groups.Count = 2 Then
            pageName = pageMacth.Groups(1).Value
        Else
            pageName = String.Empty
        End If
        Return pageName
    End Function

    Public Shared Function GetPageQueryString(ByVal rawUrl As String) As String
        Dim position As Integer = rawUrl.IndexOf("?")
        If position < 0 Then
            Return String.Empty
        Else
            Return rawUrl.Substring(position + 1)
        End If
    End Function

End Class 'PageUtils 
