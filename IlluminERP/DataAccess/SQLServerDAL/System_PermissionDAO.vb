Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace SQLServerDAL
    Friend Class System_PermissionDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.ISystem_Permission


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetAllPermissions() As DataSet Implements IDAL.ISystem_Permission.GetAllPermissions
            Dim sql As String = "select * from [t_System_Permission] where IsDeleted = 0"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetHierarchicalPermissions() As DataSet Implements IDAL.ISystem_Permission.GetHierarchicalPermissions
            Dim sql As String = "SELECT ID,'ParentID'=CASE WHEN [PerLevel]=1 THEN NULL ELSE ParentID END,Name,LinkURL FROM [t_System_Permission] WHERE kind<3"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetUserPermissionsByPage(ByVal pageName As String) As System_PermissionInfo Implements IDAL.ISystem_Permission.GetUserPermissionsByPage
            Dim sql As String = "select top 1 * from t_System_Permission where linkUrl like '%'+@linkUrl+'%' "
            Dim urlParam As New SqlParameter("@linkUrl", SqlDbType.VarChar)
            urlParam.Value = pageName

            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, urlParam)
            If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return MapRowToEntityInfo(ds.Tables(0).Rows(0))
            Else
                Return Nothing
            End If

        End Function

        Public Function MapRowToEntityInfo(ByVal dr As DataRow) As System_PermissionInfo
            Dim entityInfo As New System_PermissionInfo

            entityInfo.ID = Convert.ToInt32(dr("ID"))

            If Not Convert.IsDBNull(dr("Name")) Then
                entityInfo.Name = dr("Name").ToString()
            End If

            If Not Convert.IsDBNull(dr("Description")) Then
                entityInfo.Description = dr("Description").ToString()
            End If

            If Not Convert.IsDBNull(dr("Memo")) Then
                entityInfo.Memo = dr("Memo").ToString()
            End If

            If Not Convert.IsDBNull(dr("Kind")) Then
                entityInfo.Kind = Convert.ToInt32(dr("Kind"))
            End If

            If Not Convert.IsDBNull(dr("PerLevel")) Then
                entityInfo.PerLevel = Convert.ToInt32(dr("PerLevel"))
            End If

            If Not Convert.IsDBNull(dr("ParentID")) Then
                entityInfo.ParentID = Convert.ToInt32(dr("ParentID"))
            End If

            If Not Convert.IsDBNull(dr("Sort")) Then
                entityInfo.PerLevel = Convert.ToInt32(dr("Sort"))
            End If

            If Not Convert.IsDBNull(dr("IsLink")) Then
                entityInfo.IsLink = Convert.ToBoolean(dr("IsLink"))
            End If

            If Not Convert.IsDBNull(dr("LinkURL")) Then
                entityInfo.LinkURL = dr("LinkURL").ToString()
            End If

            If Not Convert.IsDBNull(dr("IsDeleted")) Then
                entityInfo.IsDeleted = Convert.ToBoolean(dr("IsDeleted"))
            End If

            If Not Convert.IsDBNull(dr("SystemModule")) Then
                entityInfo.SystemModule = dr("SystemModule").ToString()
            End If

            Return entityInfo
        End Function
        Public Function GetUserHierarchicalPermissions(ByVal userInfo As Model.User_UserInfo) As DataSet Implements IDAL.ISystem_Permission.GetUserHierarchicalPermissions
            Dim sSql As String = ""
            sSql += "select n.ID,'ParentID'=CASE WHEN n.PerLevel=1 THEN NULL ELSE n.ParentID END,n.Name,n.LinkURL,n.PerLevel, n.SystemModule  from "
            sSql += "( "
            sSql += "select distinct permission_id from t_User_RolePermission "
            sSql += "where Role_Id in "
            sSql += "( "
            sSql += "select a.RoleId  from t_User_UserRole a,t_User_Role b "
            sSql += "where a.userid = (select ID from t_User_UserInfo where id='{0}') "
            sSql += "and b.Status='1' and a.Roleid = b.id "
            sSql += "union "
            sSql += "select t.RoleID from t_User_TeamRole t "
            sSql += "where t.TeamID in (select TeamID from t_User_UserTeam where UserID='{0}'"
            sSql += ") "
            sSql += ")) m left join t_System_Permission n on m.Permission_ID  = n.id "
            sSql += "where(n.Kind = 1) order by n.sort"

            sSql = String.Format(sSql, userInfo.ID)
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sSql)
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetPerMissionInfoById(ByVal Id As Integer) As Model.System_PermissionInfo Implements IDAL.ISystem_Permission.GetPerMissionInfoById
            Dim sql As String = "select *  from t_System_Permission where id  = @Id"
            Dim urlParam As New SqlParameter("@Id", SqlDbType.VarChar)
            urlParam.Value = Id

            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, urlParam)
            If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return MapRowToEntityInfo(ds.Tables(0).Rows(0))
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace

