Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components

Namespace SQLServerDAL

    Friend Class Base_CityInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_CityInfo


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function GetCityInfo() As System.Data.DataSet Implements IDAL.IBase_CityInfo.GetCityInfo
            Dim sql As String = "select * from [t_base_City] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetCityInfoByID(ByVal ID As Integer) As Model.Base_CityInfo Implements IDAL.IBase_CityInfo.GetCityInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_City] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_CityInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToCityInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function


        Private Function MapRowToCityInfo(ByVal dr As DataRow) As Base_CityInfo
            Dim info As New Base_CityInfo
            info.ID = Convert.ToInt32(dr("ID"))
            info.City = dr("City").ToString()
            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_CityInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@City", SqlDbType.Char)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.City


            Return parameters
        End Function

    End Class
End Namespace
