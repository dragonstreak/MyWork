Imports System.Data

Imports DataAccess.BLL
Imports DataAccess.Model
Imports Utils

Partial Class UploadFile
    Inherits PageBase

    Private imageUrl As String

    Private UFBLL As New System_UploadFileBLL

    ''' <summary>
    ''' 已上传的图片的ID列表
    ''' </summary>
    Private uploadedList As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        imageUrl = String.Empty
        '将已上传的图片ID列表保存在页面的隐含域 uploadedList 当中
        uploadedList = Page.Request("uploadedList")

        If uploadedList Is Nothing OrElse uploadedList.Length = 0 Then
            uploadedList = "0"
        End If

        If IsPostBack Then
            ' 检测文件是否合法
            If Not CheckFile(File1.PostedFile) Then
                LabelMsg.Text = "upload file failed"
                Return
            End If

            ' 得到上传的文件的扩展名
            Dim ext As String = System.IO.Path.GetExtension(File1.FileName)

            Dim saveforlder, strReferModule As String
            strReferModule = Page.Request("ReferModule")
            saveforlder = "UserUploadFiles/"
            If strReferModule IsNot Nothing Then
                saveforlder = "UserUpLoadFiles/" + strReferModule + "/"
            Else
                saveforlder = "UserUpLoadFiles/Others/"
            End If
            ' 获取图片的虚拟相对路径
            Dim vUrl As String = GetNewFileName(System.IO.Path.GetFileNameWithoutExtension(File1.FileName), saveforlder) + ext

            ' 将虚拟相对路径转化为物理路径
            Dim filename As String = System.IO.Path.Combine(Request.PhysicalApplicationPath, vUrl)
            Dim path As String = System.IO.Path.Combine(Request.PhysicalApplicationPath, saveforlder)

            If Not System.IO.Directory.Exists(path) Then

                System.IO.Directory.CreateDirectory(path)
            End If
            ' 保存图片文件
            File1.PostedFile.SaveAs(filename)

            Dim imageId As Integer = -1
            ' 在数据库中添加记录
            Dim fileInfo As New System_UploadFile
            fileInfo.Comment = Request.Form("fileDescription")
            fileInfo.RelativePath = vUrl
            fileInfo.FileName = System.IO.Path.GetFileName(vUrl)
            fileInfo.ReferModule = strReferModule
            If CurrentLoginUser IsNot Nothing Then
                fileInfo.CreatedBy = CurrentLoginUser.ID
            End If
            fileInfo.CreatedTime = DateTime.Now

            imageId = UFBLL.AddEntity(fileInfo)

            ' 在页面上显示已上传的图片的URL
            Dim appUrl As Uri = Request.Url
            imageUrl = appUrl.GetLeftPart(UriPartial.Authority) + "/" + Request.ApplicationPath + "/" + vUrl

            ' 添加一个新的ID
            uploadedList += "," + imageId.ToString()
        End If
    End Sub

    ''' <summary>
    ''' 检测上传的文件是否正确
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns></returns>
    Private Function CheckFile(ByVal file As HttpPostedFile) As Boolean

        If file Is Nothing Then
            Return False
        End If
        If file.ContentLength = 0 Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 获取新上传的文件的可用名称
    ''' 应当使用虚拟路径
    ''' </summary>
    ''' <returns></returns>
    Private Function GetNewFileName(ByVal fileName As String, ByVal folder As String) As String
        Dim currentTime As DateTime = DateTime.Now
        Dim objRand As Random = New Random()
        Dim newName As String = String.Format("{0}({1}{2}{3}{4}{5}{6}{7})", fileName, currentTime.Year.ToString(),
         currentTime.Month.ToString(), currentTime.Day.ToString(), currentTime.Hour.ToString(), currentTime.Minute.ToString(), currentTime.Second.ToString(), Convert.ToString(objRand.Next(99)))
        Dim saveFolder As String = "UserUpLoadFile/"
        If folder IsNot Nothing AndAlso folder.Length > 0 Then
            saveFolder = folder
        End If
        Return saveFolder + newName
    End Function

    ''' <summary>
    ''' 获取新上传的文件的URL
    ''' </summary>
    ''' <returns></returns>
    Protected Function GetImageUrl() As String
        If imageUrl.Length = 0 Then
            Return Server.HtmlEncode(" ")
        Else
            Return imageUrl
        End If
    End Function

    Protected Function GetUploadedList() As String
        Return uploadedList
    End Function

End Class
