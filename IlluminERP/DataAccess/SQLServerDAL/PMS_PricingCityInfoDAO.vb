Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class PMS_PricingCityInfoDAO

        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_PricingCityInfo


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetPricingCityInfo() As System.Data.DataSet Implements IDAL.IPMS_PricingCityInfo.GetPricingCityInfo
            Dim sql As String = "select * from [t_PMS_PricingCity] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetPricingCityInfoById(ByVal ID As Integer) As Model.PMS_PricingCityInfo Implements IDAL.IPMS_PricingCityInfo.GetPricingCityInfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_PMS_PricingCity] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_PricingCityInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_PricingCityInfo
            Dim info As New PMS_PricingCityInfo
            info.Id = Convert.ToInt32(dr("ID"))

            info.PricingCity = dr("PricingCity").ToString()

            info.Description = dr("Description").ToString()


            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_PricingCityInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                New SqlParameter("@Description", SqlDbType.VarChar), _
                                                                New SqlParameter("@PricingCity", SqlDbType.VarChar)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.Description
            parameters(2).Value = info.PricingCity

            Return parameters
        End Function
    End Class
End Namespace
