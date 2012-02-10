Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_PricingSampleCityInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_PricingSampleCityInfo


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetPricingSampleCityInfoById(ByVal Id As Integer) As Model.PMS_PricingSampleCityInfo Implements IDAL.IPMS_PricingSampleCityInfo.GetPricingSampleCityInfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_PricingSampleCity] where  ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_PricingSampleCityInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetPricingSampleCityInfoByType(ByVal Type As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingSampleCityInfo.GetPricingSampleCityInfoByType
            Dim paramType As New SqlParameter("@Type", SqlDbType.Char)
            paramType.Value = Type

            Dim sql As String = "select * from [t_PMS_PricingSampleCity] where Type  = @Type  Order by CityName_CN"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramType)

            If Not ds Is Nothing Then
                Return ds

            Else
                Return Nothing
            End If
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_PricingSampleCityInfo

            Dim info As New PMS_PricingSampleCityInfo
            info.Id = Convert.ToInt32(dr("ID"))
            info.ParentId = Convert.ToInt32(dr("ParentId"))


            If Not Convert.IsDBNull(dr("CityName_CN")) Then
                info.CityName_CN = Convert.ToString(dr("CityName_CN"))
            End If

            If Not Convert.IsDBNull(dr("CityName_EN")) Then
                info.CityName_EN = Convert.ToString(dr("CityName_EN"))
            End If


            If Not Convert.IsDBNull(dr("Type")) Then
                info.Type = Convert.ToInt32(dr("Type"))
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_PricingSampleCityInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ParentId", SqlDbType.Char), _
                                                                    New SqlParameter("@CityName_CN", SqlDbType.Char), _
                                                                    New SqlParameter("@CityName_EN", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Type", SqlDbType.Int)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.ParentId
            parameters(2).Value = info.CityName_CN
            parameters(3).Value = info.CityName_EN
            parameters(4).Value = info.Type


            Return parameters
        End Function


        Public Function GetPricingSampleCityInfoByParentId(ByVal ParentId As Integer) As System.Data.DataSet Implements IDAL.IPMS_PricingSampleCityInfo.GetPricingSampleCityInfoByParentId
            Dim paramParentId As New SqlParameter("@ParentId", SqlDbType.Char)
            paramParentId.Value = ParentId

            Dim sql As String = "select * from [t_PMS_PricingSampleCity] where ParentId  = @ParentId  Order by CityName_CN"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramParentId)

            If Not ds Is Nothing Then
                Return ds

            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace
