Public Class CommonUtils

    ' 判断月剩余工作日的函数   
    '工作日：除周六、周日   
    '节假日：周六、周日、1月1-3、5月1-7、10月1-7   
    Public Shared Function GetRemainingMonthWorkdays(ByVal p_dTime As DateTime) As Integer
        Dim intYear As Integer = p_dTime.Year     '年份
        Dim intMonth As Integer = p_dTime.Month    '月份
        Dim intDays As Integer = p_dTime.Day    '哪天
        Dim intDaysInMonth As Integer = DateTime.DaysInMonth(intYear, intMonth)   '该年该月的天数
        Dim intNum As Integer = 0
        Select Case intMonth
            Case 1           '1月份
                If intDays <= 3 Then
                    intDaysInMonth = intDaysInMonth - 3
                    p_dTime = p_dTime.AddDays((3 - intDays))
                Else
                    intDaysInMonth = intDaysInMonth - intDays
                End If
            Case 5, 10      '5,10月份
                If intDays <= 7 Then
                    intDaysInMonth = intDaysInMonth - 7
                    p_dTime = p_dTime.AddDays((7 - intDays))
                Else
                    intDaysInMonth = intDaysInMonth - intDays
                End If
            Case Else      '其他月份
                intDaysInMonth = intDaysInMonth - intDays
        End Select
        p_dTime = p_dTime.AddDays(-1)
        Dim i As Integer
        For i = 0 To intDaysInMonth
            p_dTime = p_dTime.AddDays(1)
            If p_dTime.DayOfWeek = DayOfWeek.Saturday Or p_dTime.DayOfWeek = DayOfWeek.Sunday Then
                intNum += 1
            End If
        Next i
        Return intDaysInMonth + 1 - intNum
    End Function

    Public Shared Function GetSpanWorkdays(ByVal beginTime As DateTime, ByVal endTime As DateTime) As Integer
        '国庆节
        Dim dt1 As DateTime = New DateTime(Now.Year, 10, 1)
        Dim dt2 As DateTime = New DateTime(Now.Year, 10, 7)
        '国际劳动节
        Dim dt3 As DateTime = New DateTime(Now.Year, 5, 1)
        Dim dt4 As DateTime = New DateTime(Now.Year, 5, 7)
        '元旦
        Dim dt5 As DateTime = New DateTime(Now.Year, 1, 1)
        Dim dt6 As DateTime = New DateTime(Now.Year, 1, 3)

        Dim intReturn As Integer = 0         '返回值，即endTime和beginTime之间的工作日数
        Dim tsDiffer As System.TimeSpan
        tsDiffer = endTime.Subtract(beginTime)        '计算endTime和beginTime之间相差多少天
        Dim intDiffer As Integer = tsDiffer.Days        '相差天数的int值
        '从beginTime开始一天天加，判断临时的日期值是不是星期六或星期天，如果既不是星期六，也不是星期天，而且也不在dt3和dt4之间，则该天为工作日，intReturn加1
        Dim i As Integer
        For i = 0 To intDiffer
            Dim dtTemp As DateTime = beginTime.Date.AddDays(i)
            If dtTemp.DayOfWeek <> System.DayOfWeek.Sunday And dtTemp.DayOfWeek <> System.DayOfWeek.Saturday Then
                If dtTemp.Date < dt1.Date Or dtTemp.Date > dt2.Date Then
                    If dtTemp.Date < dt3.Date Or dtTemp.Date > dt4.Date Then
                        If dtTemp.Date < dt5.Date Or dtTemp.Date > dt6.Date Then
                            intReturn += 1
                        End If
                    End If
                End If
            End If

        Next i
        Return intReturn

    End Function
    'Public Shared Function EvalExpression(ByVal strExpression As String) As Object
    '    Dim engine As Microsoft.JScript.Vsa.VsaEngine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine()
    '    Return Microsoft.JScript.Eval.JScriptEvaluate(strExpression, engine)
    'End Function
    ''' <summary>
    ''' 日期格式：yyyy-mm-dd dddd
    ''' eg:2011-5-8 Sunday
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DateFormatString As String = "yyyy-MM-dd dddd"
End Class
