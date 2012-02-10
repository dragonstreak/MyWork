Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL

    Public Interface ISystem_News
        Function AddNews(ByVal news As System_NewsInfo) As Integer

        Function UpdateNews(ByVal news As System_NewsInfo) As Boolean

        Function GetNewsByID(ByVal id As Integer) As System_NewsInfo

        Function GetEntityList(ByVal filter As NewsQueryFilter) As DataTable

    End Interface
End Namespace
