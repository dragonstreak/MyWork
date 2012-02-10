Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class User_GroupDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IUser_Group



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetGroupInfo() As System.Data.DataSet Implements IDAL.IUser_Group.GetGroupInfo
            Dim sql As String = "select * from [t_User_Group] Where status=0 order by GroupName"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetGroupInfoById(ByVal Id As Integer) As Model.User_Group Implements IDAL.IUser_Group.GetGroupInfoById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = Id
            Dim sql As String = "select * from [t_User_Group] where Status=0 and ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As User_Group = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToGroupInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function


        Private Function MapRowToGroupInfo(ByVal dr As DataRow) As User_Group
            Dim info As New User_Group
            info.ID = Convert.ToInt32(dr("ID"))


            If Not Convert.IsDBNull(dr("GroupName")) Then
                info.GroupName = Convert.ToString(dr("GroupName"))
            End If

            If Not Convert.IsDBNull(dr("Status")) Then
                info.Status = Convert.ToInt32(dr("Status"))
            End If

            If Not Convert.IsDBNull(dr("Remark")) Then
                info.Remark = Convert.ToString(dr("Remark"))
            End If


            Return info

        End Function

        Private Function GetParameters(ByVal info As User_Group) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@GroupName", SqlDbType.Char), _
                                                                    New SqlParameter("@Status", SqlDbType.Int), _
                                                                    New SqlParameter("@Remark", SqlDbType.VarChar)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.GroupName
            parameters(2).Value = info.Status
            parameters(3).Value = info.Remark



            Return parameters
        End Function

        Public Function AddGroupInfo(ByVal info As Model.User_Group) As Boolean Implements IDAL.IUser_Group.AddGroupInfo
            Dim sql As String
            Try
                sql = "select MAX(ID) AS Expr1 from t_User_Group"
                Dim newid As Integer
                Dim o As Object
                o = ExecuteScalar(sql)
                If IsDBNull(o) Then
                    newid = 1
                Else
                    newid = Convert.ToInt32(o) + 1
                End If
                info.ID = newid

                Dim strSql As String
                strSql = "Insert into t_user_Group (Id,GroupName,Status,Remark) Values("
                strSql += "'" + info.ID.ToString + "',"
                strSql += "'" + info.GroupName.ToString + "',"
                strSql += "'" + info.Status.ToString + "',"
                strSql += "'" + info.Remark.ToString + "')"

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function ModifyGroupById(ByVal Info As User_Group) As Boolean Implements IDAL.IUser_Group.ModifyGroupById
            Dim strSql As String

            strSql = " Update t_User_Group set "
            strSql += "GroupName='" + Info.GroupName.ToString + "'"
            strSql += ",Status='" + Info.Status.ToString + "'"
            strSql += ",Remark='" + Info.Remark.ToString + "'"
            strSql += " Where Id ='" + Info.ID.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetGroupInfobyGroupName(ByVal GroupName As String) As Model.User_Group Implements IDAL.IUser_Group.GetGroupInfobyGroupName
            Dim paramGroupName As New SqlParameter("@GroupName", SqlDbType.Char)
            paramGroupName.Value = GroupName
            Dim sql As String = "select * from [t_User_Group] where  Status=0 And GroupName = @GroupName"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramGroupName)
            Dim info As User_Group = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToGroupInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function
    End Class
End Namespace

