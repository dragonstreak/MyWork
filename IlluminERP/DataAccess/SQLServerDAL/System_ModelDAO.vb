
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class System_ModelDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.ISystem_Model



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub



        Private Function MapRowToModelInfo(ByVal dr As DataRow) As Model.System_Model
            Dim info As New Model.System_Model
            info.ID = Convert.ToInt32(dr("ID"))


            If Not Convert.IsDBNull(dr("Code")) Then
                info.Code = Convert.ToString(dr("Code"))
            End If

            If Not Convert.IsDBNull(dr("parentId")) Then
                info.ParentID = Convert.ToInt32(dr("parentId"))
            End If

            If Not Convert.IsDBNull(dr("ModelName")) Then
                info.ModelName = Convert.ToString(dr("ModelName"))
            End If

            If Not Convert.IsDBNull(dr("parentId")) Then
                info.ParentID = Convert.ToInt32(dr("parentId"))
            End If

            If Not Convert.IsDBNull(dr("level")) Then
                info.Level = Convert.ToInt32(dr("level"))
            End If

            If Not Convert.IsDBNull(dr("status")) Then
                info.Status = Convert.ToInt32(dr("status"))
            End If


            If Not Convert.IsDBNull(dr("linkpage")) Then
                info.Linkpage = Convert.ToString(dr("linkpage"))
            End If


            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.System_Model) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@parentId", SqlDbType.Int), _
                                                                    New SqlParameter("@Code", SqlDbType.Char), _
                                                                    New SqlParameter("@ModelName", SqlDbType.Char), _
                                                                    New SqlParameter("@level", SqlDbType.Int), _
                                                                    New SqlParameter("@status", SqlDbType.Int), _
                                                                    New SqlParameter("@linkpage", SqlDbType.Char)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.ParentID
            parameters(2).Value = info.Code
            parameters(3).Value = info.ModelName
            parameters(4).Value = info.Level
            parameters(5).Value = info.Status
            parameters(6).Value = info.Linkpage


            Return parameters
        End Function

        Public Function GetModelInfoById(ByVal Id As Integer) As Model.System_Model Implements IDAL.ISystem_Model.GetModelInfoById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = Id
            Dim sql As String = "select * from [t_System_Model] where  ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As System_Model = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToModelInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetMenuItemByParent(ByVal parentID As Integer) As System.Data.DataSet Implements IDAL.ISystem_Model.GetMenuItemByParent
            Dim paramparentID As New SqlParameter("@parentId", SqlDbType.Int)
            paramparentID.Value = parentID
            Dim sql As String = "select * from [t_System_Model] where Status=0 and level<>0 and parentId = @parentID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramparentID)

            Return ds
        End Function

        Public Function GetSystemMenuBylevel(ByVal level As Integer) As System.Data.DataSet Implements IDAL.ISystem_Model.GetSystemMenuBylevel
            Dim paramlevel As New SqlParameter("@level", SqlDbType.Int)
            paramlevel.Value = level
            Dim sql As String = "select * from [t_System_Model] where Status=0 and  level= @level"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramlevel)

            Return ds

        End Function

        Public Function GetModelInfo() As System.Data.DataSet Implements IDAL.ISystem_Model.GetModelInfo
            Dim sql As String = "select * from [t_System_Model] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function AddmodelInfo(ByVal info As Model.System_Model) As Boolean Implements IDAL.ISystem_Model.AddmodelInfo
            Dim sql As String
            Try
                sql = "select MAX(ID) AS Expr1 from t_System_Model"
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
                strSql = "Insert into t_System_Model (Id,ParentID,Code,ModelName,Level,Status,LinkPage) Values("
                strSql += "'" + info.ID.ToString + "',"
                strSql += "'" + info.ParentID.ToString + "',"
                strSql += "'" + info.Code.ToString + "',"
                strSql += "'" + info.ModelName.ToString + "',"
                strSql += "'" + info.Level.ToString + "',"
                strSql += "'" + info.Status.ToString + "',"
                strSql += "'" + info.Linkpage.ToString + "')"

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function ModifyModelInfoById(ByVal Info As Model.System_Model) As Boolean Implements IDAL.ISystem_Model.ModifyModelInfoById
            Dim strSql As String

            strSql = " Update t_System_Model set "
            strSql += "ParentID='" + Info.ParentID.ToString + "'"
            strSql += ",Code='" + Info.Code.ToString + "'"
            strSql += ",ModelName='" + Info.ModelName.ToString + "'"
            strSql += ",Level='" + Info.Level.ToString + "'"
            strSql += ",Status='" + Info.Status.ToString + "'"
            strSql += ",LinkPage='" + Info.Linkpage.ToString + "'"
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

        Public Function GetModelInfoByCode(ByVal Code As String) As Model.System_Model Implements IDAL.ISystem_Model.GetModelInfoByCode
            Dim paramCode As New SqlParameter("@Code", SqlDbType.Char)
            paramCode.Value = Code
            Dim sql As String = "select * from [t_System_Model] where  Status=0 And Code = @Code"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramCode)
            Dim info As System_Model = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToModelInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

    End Class
End Namespace
