Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_PositionInfoDAO


        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_PositionInfo

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetPositionInfo() As System.Data.DataSet Implements IDAL.IBase_PositionInfo.GetPositionInfo
            Dim sql As String = "select * from [t_base_Position] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetPositionInfoByID(ByVal ID As Integer) As Model.Base_PositionInfo Implements IDAL.IBase_PositionInfo.GetPositionInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_Position] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_PositionInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToPositionInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToPositionInfo(ByVal dr As DataRow) As Base_PositionInfo
            Dim info As New Base_PositionInfo
            info.ID = Convert.ToInt32(dr("ID"))
            info.Position = dr("Position").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_PositionInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@Position", SqlDbType.Char)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.Position


            Return parameters
        End Function

    End Class
End Namespace

