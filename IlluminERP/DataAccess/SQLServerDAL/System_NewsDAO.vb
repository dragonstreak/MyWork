Imports System.Data
Imports System.Data.SqlClient

Imports DataAccess.Model
Imports DataAccess.IDAL
Imports Utils

Namespace SQLServerDAL

    Friend Class System_NewsDAO
        Inherits BaseSqlServerDAO
        Implements ISystem_News

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddNews(ByVal news As System_NewsInfo) As Integer Implements ISystem_News.AddNews
            ExecuteNonQuery(news.SqlScript_Insert, news.GetSqlParameters())
            Return news.NewIdentifyId
        End Function

        Public Function UpdateNews(ByVal news As System_NewsInfo) As Boolean Implements ISystem_News.UpdateNews

            Dim referCount As Integer
            referCount = ExecuteNonQuery(news.SqlScript_Update, news.GetSqlParameters())
            Return referCount > 0
        End Function

        Public Function GetNewsByID(ByVal Id As Integer) As System_NewsInfo Implements ISystem_News.GetNewsByID
            Dim strSql As String
            strSql = "select News.*, uCreate.E_Name as CreatedByName, uModify.E_Name as ModifiedByName from t_System_News News "
            strSql += "left Join t_User_UserInfo uCreate on News.CreatedBy = uCreate.ID "
            strSql += "left Join t_User_UserInfo uModify on News.ModifiedBy = uModify.ID "
            strSql += "where News.IsDeleted = 0 and News.NewsId = " + Id.ToString()

            Dim newsInfo As System_NewsInfo = Nothing
            Dim dsNews As DataSet = ExecuteDataSet(strSql)
            If dsNews IsNot Nothing AndAlso dsNews.Tables(0).Rows.Count > 0 Then
                newsInfo = MapRowToNewsInfo(dsNews.Tables(0).Rows(0))
            Else
                newsInfo = Nothing
            End If

            Return newsInfo
        End Function

        Public Function GetEntityList(ByVal filter As NewsQueryFilter) As DataTable Implements ISystem_News.GetEntityList
            Dim sql As String = "select "
            If filter.ResultAmountLimit > 0 Then
                sql += "top " + filter.ResultAmountLimit.ToString() + " "
            End If
            sql += "News.*, listItem.ContentText as NewsTypeName, uCreate.E_Name as CreatedByName, uMod.E_Name as ModifiedByName from [t_System_News] News "
            sql += "left join [t_Base_ListItem] ListItem on News.NewsType = ListItem.ListItemID and ListItem.IsDeleted=0 "
            sql += "left join [t_User_UserInfo] uCreate on News.CreatedBy = uCreate.ID "
            sql += "left join [t_User_UserInfo] uMod on News.ModifiedBy = uMod.ID "
            sql += " where News.IsDeleted = 0 "
            sql += FilterManager.GetFilterCondition(Of NewsQueryFilter)(filter)
            sql += " Order by News.NewsID desc"
            Dim parameters() As SqlParameter = {
              New SqlParameter("@Title", filter.Title),
               New SqlParameter("@NewsType", filter.NewsType),
              New SqlParameter("@SeverityLevel", filter.SeverityLevel),
              New SqlParameter("@Published", filter.PublishedType)
            }
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, parameters)

            Return ds.Tables(0)
        End Function

        Public Function MapRowToNewsInfo(ByVal dr As DataRow) As System_NewsInfo
            Dim newsInfo As New System_NewsInfo
            newsInfo.NewsID = Convert.ToInt32(dr("NewsID"))
            newsInfo.Title = Convert.ToString(dr("Title"))

            If Not Convert.IsDBNull(dr("NewsType")) Then
                newsInfo.NewsType = Convert.ToInt32(dr("NewsType"))
            End If

            If Not Convert.IsDBNull(dr("SeverityLevel")) Then
                newsInfo.SeverityLevel = Convert.ToInt32(dr("SeverityLevel"))
            End If

            newsInfo.Content = dr("Content").ToString()

            If Not Convert.IsDBNull(dr("ReadRate")) Then
                newsInfo.ReadRate = Convert.ToInt32(dr("ReadRate"))
            End If

            If Not Convert.IsDBNull(dr("Published")) Then
                newsInfo.Published = Convert.ToInt32(dr("Published"))
            End If

            If Not Convert.IsDBNull(dr("IsDeleted")) Then
                newsInfo.IsDeleted = Convert.ToBoolean(dr("IsDeleted"))
            End If

            If Not Convert.IsDBNull(dr("CreatedBy")) Then
                newsInfo.CreatedBy = Convert.ToInt32(dr("CreatedBy"))
            End If

            If Not Convert.IsDBNull(dr("CreatedTime")) Then
                newsInfo.CreatedTime = Convert.ToDateTime(dr("CreatedTime"))
            End If

            If Not Convert.IsDBNull(dr("ModifiedBy")) Then
                newsInfo.ModifiedBy = Convert.ToInt32(dr("ModifiedBy"))
            End If

            If Not Convert.IsDBNull(dr("ModifiedTime")) Then
                newsInfo.ModifiedTime = Convert.ToDateTime(dr("ModifiedTime"))
            End If

            If dr.Table.Columns.Contains("CreatedByName") AndAlso Not Convert.IsDBNull(dr("CreatedByName")) Then
                newsInfo.CreatedByName = Convert.ToString(dr("CreatedByName"))
            End If

            If dr.Table.Columns.Contains("ModifiedByName") AndAlso Not Convert.IsDBNull(dr("ModifiedByName")) Then
                newsInfo.ModifiedByName = Convert.ToString(dr("ModifiedByName"))
            End If

            Return newsInfo
        End Function

    End Class

End Namespace