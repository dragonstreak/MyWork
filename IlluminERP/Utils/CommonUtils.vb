Public Class CommonUtils

    ' �ж���ʣ�๤���յĺ���   
    '�����գ�������������   
    '�ڼ��գ����������ա�1��1-3��5��1-7��10��1-7   
    Public Shared Function GetRemainingMonthWorkdays(ByVal p_dTime As DateTime) As Integer
        Dim intYear As Integer = p_dTime.Year     '���
        Dim intMonth As Integer = p_dTime.Month    '�·�
        Dim intDays As Integer = p_dTime.Day    '����
        Dim intDaysInMonth As Integer = DateTime.DaysInMonth(intYear, intMonth)   '������µ�����
        Dim intNum As Integer = 0
        Select Case intMonth
            Case 1           '1�·�
                If intDays <= 3 Then
                    intDaysInMonth = intDaysInMonth - 3
                    p_dTime = p_dTime.AddDays((3 - intDays))
                Else
                    intDaysInMonth = intDaysInMonth - intDays
                End If
            Case 5, 10      '5,10�·�
                If intDays <= 7 Then
                    intDaysInMonth = intDaysInMonth - 7
                    p_dTime = p_dTime.AddDays((7 - intDays))
                Else
                    intDaysInMonth = intDaysInMonth - intDays
                End If
            Case Else      '�����·�
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
        '�����
        Dim dt1 As DateTime = New DateTime(Now.Year, 10, 1)
        Dim dt2 As DateTime = New DateTime(Now.Year, 10, 7)
        '�����Ͷ���
        Dim dt3 As DateTime = New DateTime(Now.Year, 5, 1)
        Dim dt4 As DateTime = New DateTime(Now.Year, 5, 7)
        'Ԫ��
        Dim dt5 As DateTime = New DateTime(Now.Year, 1, 1)
        Dim dt6 As DateTime = New DateTime(Now.Year, 1, 3)

        Dim intReturn As Integer = 0         '����ֵ����endTime��beginTime֮��Ĺ�������
        Dim tsDiffer As System.TimeSpan
        tsDiffer = endTime.Subtract(beginTime)        '����endTime��beginTime֮����������
        Dim intDiffer As Integer = tsDiffer.Days        '���������intֵ
        '��beginTime��ʼһ����ӣ��ж���ʱ������ֵ�ǲ����������������죬����Ȳ�����������Ҳ���������죬����Ҳ����dt3��dt4֮�䣬�����Ϊ�����գ�intReturn��1
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
    ''' ���ڸ�ʽ��yyyy-mm-dd dddd
    ''' eg:2011-5-8 Sunday
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DateFormatString As String = "yyyy-MM-dd dddd"
End Class
