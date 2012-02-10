
Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class System_NewsBLL
        Private factory As New DALFactory
        Private NewsDAL As ISystem_News = factory.GetProduct("System_NewsDAO")
        Private UploadFileDAL As ISystem_UploadFile = factory.GetProduct("System_UploadFileDAO")

        Public Sub New()

        End Sub

        Public Function AddNews(ByVal news As System_NewsInfo) As Integer
            Dim newsId As Integer = NewsDAL.AddNews(news)
            UploadFileDAL.UpdateFileMainEntityId(news.FileList, newsId)
            Return newsId
        End Function

        Public Function UpdateNews(ByVal news As System_NewsInfo) As Boolean

            UploadFileDAL.UpdateFileMainEntityId(news.FileList, news.NewsID)
            Return NewsDAL.UpdateNews(news)
        End Function

        Public Function GetNewsByID(ByVal Id As Integer) As System_NewsInfo
            Dim news As System_NewsInfo
            news = NewsDAL.GetNewsByID(Id)
            If news IsNot Nothing Then
                news.FileList = UploadFileDAL.GetUploadFileIdListByMainEntityId(news.NewsID)
            End If

            Return news
        End Function

        Public Function GetEntityList(ByVal filter As NewsQueryFilter) As DataTable
            Return NewsDAL.GetEntityList(filter)
        End Function
    End Class
End Namespace

