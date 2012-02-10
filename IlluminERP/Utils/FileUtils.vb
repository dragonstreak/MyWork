Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI.HtmlControls
Imports System.IO


Public Class FileUtils
    Public Sub New()
    End Sub

    Public Overloads Shared Function UpLoadFile(ByVal inputFile As HtmlInputFile, ByVal virtualPath As String) As String
        Return UpLoadFile(inputFile, virtualPath, "UserUpLoadFiles")
    End Function



    Public Overloads Shared Function UpLoadFile(ByVal inputFile As HtmlInputFile, ByVal path As String, ByVal folder As String) As String
        Dim fileName, fileExtension, saveName, absoluteUrl As String
        saveName = Nothing
        Dim postedFile As HttpPostedFile = inputFile.PostedFile
        If Not (postedFile Is Nothing) And postedFile.ContentLength > 0 Then
            If postedFile.ContentLength > 1024 * 1024 * 20 Then
                Throw New Exception("附件文件过大，无法保存！")
            End If
            '文件名长度超过200
            If System.IO.Path.GetFileName(postedFile.FileName).Length > 400 Then
                Throw New Exception("附件文件名过长，无法保存！")
            End If
            fileName = System.IO.Path.GetFileName(postedFile.FileName)
            fileExtension = System.IO.Path.GetExtension(fileName)

            Dim objRand As New Random
            Dim [date] As System.DateTime = DateTime.Now
            '生成随机文件名
            ' saveName = String.Format("{0}（{1}{2}{3}{4}{5}{6}{7}）{8}", fileName.Substring(0, fileName.Length - fileExtension.Length), [date].Year.ToString(), [date].Month.ToString(), [date].Day.ToString(), [date].Hour.ToString(), [date].Minute.ToString(), [date].Second.ToString(), Convert.ToString(objRand.Next(99)), fileExtension)

            If folder.Length > 0 Then
                path = System.IO.Path.Combine(path, folder)
            End If

            If path.EndsWith("\") Then
                path.Substring(0, path.Length - 1)
            End If

            Dim tempPath1, tempPath2, tempFolder As String
            Dim index As Integer
            tempPath1 = path
            tempPath2 = tempPath1.Substring(0, tempPath1.IndexOf("\"c) + 1)
            tempPath1 = tempPath1.Substring(tempPath1.IndexOf("\"c) + 1)
            index = tempPath1.IndexOf("\"c)
            If index > -1 Then
                tempFolder = tempPath1.Substring(0, tempPath1.IndexOf("\"c))
            Else
                tempFolder = tempPath1
            End If

            tempPath2 = tempPath2 + "\" + tempFolder

            Dim dir As DirectoryInfo
            While index > -1
                dir = New DirectoryInfo(tempPath2)
                If Not dir.Exists() Then
                    dir.Create()
                End If
                tempPath1 = tempPath1.Substring(tempPath1.IndexOf("\"c) + 1)
                index = tempPath1.IndexOf("\"c)
                If index > -1 Then
                    tempFolder = tempPath1.Substring(0, index)
                Else
                    tempFolder = tempPath1
                End If
                tempPath2 = tempPath2 + "\" + tempFolder
            End While
            dir = New DirectoryInfo(tempPath2)
            If Not dir.Exists() Then
                dir.Create()
            End If



            If (System.IO.File.Exists(path & "\" & fileName)) Then
                '如果已经存在同名文件，则在文件名后追加数字2
                saveName = String.Format("{0}2{1}", fileName.Substring(0, fileName.Length - fileExtension.Length), fileExtension)
            Else
                saveName = fileName
            End If

            absoluteUrl = path + "\" + saveName

            Try
                postedFile.SaveAs(absoluteUrl)

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End If
        Return saveName
    End Function

    Public Shared Function CheckFile(ByVal file As HttpPostedFile) As Boolean
        If file Is Nothing Then
            Return False
        End If
        If file.ContentLength = 0 Then
            Return False
        End If
        Return True
    End Function

    Public Shared Sub DeleteFile(ByVal phyAppPath As String, ByVal filePath As String)
        Dim path As String = System.IO.Path.Combine(phyAppPath, filePath)
        If System.IO.File.Exists(path) Then
            File.Delete(path)

        Else
            Throw New Exception("未能找到要删除的文件")
        End If
    End Sub

    Public Shared Function DownLoadFile(ByVal SFilename As String, ByVal strFolder As String) As Boolean

        Dim iStream As System.IO.Stream

        Dim Sfile As New System.IO.FileInfo(SFilename)
        System.Web.HttpContext.Current.Response.Clear()
        Dim buffer(10485760) As Byte
        Try
            iStream = New System.IO.FileStream(SFilename, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            Dim dataToRead As Long = iStream.Length
            System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream"
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename = " + HttpUtility.UrlEncode(Sfile.Name).ToString)
            System.Web.HttpContext.Current.Response.WriteFile(Sfile.FullName)
            Return True
        Catch ex As Exception
            Return False
            If IsNothing(iStream) = False Then iStream.Close()
        End Try
        System.Web.HttpContext.Current.Response.Charset = "UTF-8"
        System.Web.HttpContext.Current.Response.Buffer = True
        System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8

        System.Web.HttpContext.Current.Response.Flush()
        System.Web.HttpContext.Current.Response.Close()








    End Function

End Class
