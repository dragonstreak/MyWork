
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class PMS_SubProjectSampleSizeDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_SubProjectSampleSize

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddSubProjectSampleSizeInfo(ByVal info As Model.PMS_SubProjectSampleSize) As Integer Implements IDAL.IPMS_SubProjectSampleSize.AddSubProjectSampleSizeInfo
            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_SubProjectSampleSize (SubProId,CityId,SampleSize,Description) Values ("
                strSql += "'" + info.SubProId.ToString + "',"
                strSql += "'" + info.CityId.ToString + "',"
                strSql += "'" + info.Samplesize.ToString + "',"
                strSql += "'" + info.Description.ToString + "')"
                strSql += " select ID=@@Identity"


                Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, strSql)
                If dr.Read Then
                    info.Id = Convert.ToInt32(dr("Id"))
                    dr.Close()
                    dr = Nothing
                    Return info.Id
                Else
                    Return 0
                End If

            Catch ex As Exception
                Dim str As String = ex.Message
            End Try
        End Function

        Public Function DeleteSubProjectSampleSizeInfoById(ByVal Id As Integer) As Boolean Implements IDAL.IPMS_SubProjectSampleSize.DeleteSubProjectSampleSizeInfoById
            Dim strSql As String

            strSql = " Delete From t_PMS_SubProjectSampleSize "
            strSql += " Where Id ='" + CStr(Id) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetSubProjectSampleSizeById(ByVal ID As Integer) As Model.PMS_SubProjectSampleSize Implements IDAL.IPMS_SubProjectSampleSize.GetSubProjectSampleSizeById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_PMS_SubProjectSampleSize] where  ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_SubProjectSampleSize = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetSubProjectSampleSizeBySubProId(ByVal SubProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_SubProjectSampleSize.GetSubProjectSampleSizeBySubProId
            Dim paramSubProId As New SqlParameter("@SubProId", SqlDbType.Char)
            paramSubProId.Value = SubProId
            Dim sql As String = "select a.* from [t_PMS_SubProjectSampleSize] a , t_PMS_PricingSampleCity b where  a.cityId =b.id and a.SubProID = @SubProId Order by b.CityName_CN"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramSubProId)
            Dim info As PMS_SubProjectSampleSize = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_SubProjectSampleSize
            Dim info As New PMS_SubProjectSampleSize
            info.SubProId = Convert.ToInt32(dr("SubProId"))
            info.CityId = Convert.ToInt32(dr("CityId"))

            If Not Convert.IsDBNull(dr("Samplesize")) Then
                info.Samplesize = Convert.ToDecimal(dr("Samplesize"))
            End If

            If Not Convert.IsDBNull(dr("Description")) Then
                info.Description = Convert.ToString(dr("Description"))
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_SubProjectSampleSize) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@SubProId", SqlDbType.Char), _
                                                                    New SqlParameter("@CityId", SqlDbType.Int), _
                                                                    New SqlParameter("@SampleSize", SqlDbType.Decimal), _
                                                                    New SqlParameter("@Description", SqlDbType.VarChar)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.SubProId
            parameters(2).Value = info.CityId
            parameters(3).Value = info.Samplesize
            parameters(4).Value = info.Description
     

            Return parameters
        End Function


    End Class
End Namespace
