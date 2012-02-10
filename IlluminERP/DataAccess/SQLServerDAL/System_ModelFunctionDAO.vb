

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL


    Friend Class System_ModelFunctionDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.ISystem_ModelFunction





        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function AddModelFunction(ByVal Info As Model.System_ModelFunction) As Boolean Implements IDAL.ISystem_ModelFunction.AddModelFunction
            Dim sql As String
            Try
                sql = "select MAX(ID) AS Expr1 from t_System_ModelFunction"
                Dim newid As Integer
                Dim o As Object
                o = ExecuteScalar(sql)
                If IsDBNull(o) Then
                    newid = 1
                Else
                    newid = Convert.ToInt32(o) + 1
                End If
                Info.ID = newid

                Dim strSql As String
                strSql = "Insert into t_System_ModelFunction (Id,SystemModelID,Code,ModelFunction,Description) Values("
                strSql += "'" + Info.ID.ToString + "',"
                strSql += "'" + Info.SystemModelID.ToString + "',"
                strSql += "'" + Info.Code.ToString + "',"
                strSql += "'" + Info.ModelFunction.ToString + "',"
                strSql += "'" + Info.Description.ToString + "')"

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetModelFunctionById(ByVal Id As Integer) As Model.System_ModelFunction Implements IDAL.ISystem_ModelFunction.GetModelFunctionById
            Dim paramID As New SqlParameter("@ID", SqlDbType.Char)
            paramID.Value = Id
            Dim sql As String = "select * from [t_System_ModelFunction] where  ID = @ID"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As System_ModelFunction = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToModelFunctionInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetModelFunctionByModelId(ByVal ModelId As Integer) As System.Data.DataSet Implements IDAL.ISystem_ModelFunction.GetModelFunctionByModelId
            Dim paramModelId As New SqlParameter("@ModelId", SqlDbType.Int)
            paramModelId.Value = ModelId
            Dim sql As String = "select * from [t_System_ModelFunction] where  SystemModelID = @ModelId"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramModelId)

            Return ds
        End Function

        Private Function MapRowToModelFunctionInfo(ByVal dr As DataRow) As Model.System_ModelFunction
            Dim info As New Model.System_ModelFunction
            info.ID = Convert.ToInt32(dr("ID"))


            If Not Convert.IsDBNull(dr("Code")) Then
                info.Code = Convert.ToString(dr("Code"))
            End If

            If Not Convert.IsDBNull(dr("SystemModelID")) Then
                info.SystemModelID = Convert.ToInt32(dr("SystemModelID"))
            End If

            If Not Convert.IsDBNull(dr("ModelFunction")) Then
                info.ModelFunction = Convert.ToString(dr("ModelFunction"))
            End If

            If Not Convert.IsDBNull(dr("Description")) Then
                info.Description = Convert.ToString(dr("Description"))
            End If

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.System_ModelFunction) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@SystemModelID", SqlDbType.Int), _
                                                                    New SqlParameter("@Code", SqlDbType.Char), _
                                                                    New SqlParameter("@ModelFunction", SqlDbType.Char), _
                                                                    New SqlParameter("@Description", SqlDbType.Char)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.SystemModelID
            parameters(2).Value = info.Code
            parameters(3).Value = info.ModelFunction
            parameters(4).Value = info.Description



            Return parameters
        End Function

        Public Function DeleteModelFunctionbyId(ByVal Id As String) As Boolean Implements IDAL.ISystem_ModelFunction.DeleteModelFunctionbyId
            Dim strSql As String

            strSql = " Delete From t_System_ModelFunction
            strSql += " Where Id ='" + Id.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function
    End Class
End Namespace
