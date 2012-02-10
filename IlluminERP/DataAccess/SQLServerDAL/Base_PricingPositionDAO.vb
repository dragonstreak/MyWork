Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class Base_PricingPositionDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_PricingPosition

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetPricingPositionByDepId(ByVal DepId As Integer) As System.Data.DataSet Implements IDAL.IBase_PricingPosition.GetPricingPositionByDepId
            Dim paramDepId As New SqlParameter("@DepId", SqlDbType.Char)
            paramDepId.Value = DepId
            Dim sql As String = "select * from [t_Base_PricingPosition] where DepId = @DepId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramDepId)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Public Function GetPricingPositionById(ByVal ID As Integer) As Model.Base_PricingPosition Implements IDAL.IBase_PricingPosition.GetPricingPositionById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_Base_PricingPosition] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As Base_PricingPosition = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_PricingPosition
            Dim info As New Base_PricingPosition
            info.Id = Convert.ToInt32(dr("ID"))

            info.DepId = Convert.ToInt32(dr("DepId"))

            info.Position = dr("Position").ToString()

            info.ShortName = dr("ShortName").ToString()

            info.Rate = Convert.ToDecimal(dr("Rate"))


            Return info

        End Function

        Private Function GetParameters(ByVal info As Base_PricingPosition) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                New SqlParameter("@DepId", SqlDbType.Int), _
                                                                New SqlParameter("@Position", SqlDbType.VarChar), _
                                                                New SqlParameter("@ShortName", SqlDbType.VarChar), _
                                                                New SqlParameter("@Rate", SqlDbType.Decimal)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.DepId
            parameters(2).Value = info.Position
            parameters(3).Value = info.ShortName
            parameters(4).Value = info.Rate


            Return parameters
        End Function
    End Class
End Namespace
