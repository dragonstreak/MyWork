
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL

    Friend Class Base_ProjectTypeDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_ProjectType


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetProjectTypeInfo() As System.Data.DataSet Implements IDAL.IBase_ProjectType.GetProjectTypeInfo
            Dim sql As String = "select * from [t_base_ProjectType] Order by ProjectType"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetProjectTypeInfoByID(ByVal ID As Integer) As Model.Base_ProjectType Implements IDAL.IBase_ProjectType.GetProjectTypeInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_ProjectType] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_ProjectType = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToProjectTypeInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToProjectTypeInfo(ByVal dr As DataRow) As Base_ProjectType
            Dim info As New Base_ProjectType
            info.ID = Convert.ToInt32(dr("ID"))
            info.ProjectType = dr("ProjectType").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_ProjectType) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProjectType", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.ProjectType


            Return parameters
        End Function

    End Class
End Namespace
