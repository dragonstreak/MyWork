Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class Base_PricingProjectStageDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_PricingProjectStage


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetPricingStageByDepId(ByVal DepId As Integer) As System.Data.DataSet Implements IDAL.IBase_PricingProjectStage.GetPricingStageByDepId
            Dim paramDepId As New SqlParameter("@DepId", SqlDbType.Char)
            paramDepId.Value = DepId
            Dim sql As String = "select * from [t_Base_PricingProjectStage] where DepId = @DepId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramDepId)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetPricingStageById(ByVal ID As Integer) As Model.Base_PricingProjectStage Implements IDAL.IBase_PricingProjectStage.GetPricingStageById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_Base_PricingProjectStage] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As Base_PricingProjectStage = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_PricingProjectStage
            Dim info As New Base_PricingProjectStage
            info.ID = Convert.ToInt32(dr("ID"))

            info.DepId = Convert.ToInt32(dr("DepId"))

            info.Stage = dr("Stage").ToString()


            Return info

        End Function

        Private Function GetParameters(ByVal info As Base_PricingProjectStage) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                New SqlParameter("@DepId", SqlDbType.Int), _
                                                                New SqlParameter("@Stage", SqlDbType.VarChar)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.DepId
            parameters(2).Value = info.Stage



            Return parameters
        End Function
    End Class
End Namespace
