

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class PMS_ProDesginCriteriaDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_ProDesginCriteria

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddProDesignCriteria(ByVal Info As Model.PMS_ProDesginCriteria) As Integer Implements IDAL.IPMS_ProDesginCriteria.AddProDesignCriteria
            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_ProDesginCriteria (SubProId,CeriteriaSelectionId,Description) Values("
                strSql += "'" + Info.SubProId.ToString + "',"
                strSql += "'" + Info.CeriteriaSelectionId.ToString + "',"
                strSql += "'" + Info.Description.ToString + "')"
                strSql += " select ID=@@Identity"


                Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, strSql)
                If dr.Read Then
                    Info.Id = Convert.ToInt32(dr("Id"))
                    dr.Close()
                    dr = Nothing
                    Return Info.Id
                Else
                    Return 0
                End If

            Catch ex As Exception
                Dim str As String = ex.Message
            End Try
        End Function

        Public Function DeleteProDesignCriteria(ByVal Info As Model.PMS_ProDesginCriteria) As Integer Implements IDAL.IPMS_ProDesginCriteria.DeleteProDesignCriteria
            Dim strSql As String

            strSql = " Delete From t_PMS_ProDesginCriteria "
            strSql += " Where Id ='" + CStr(Info.Id) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetProDesignCriteriaById(ByVal Id As Integer) As Model.PMS_ProDesginCriteria Implements IDAL.IPMS_ProDesginCriteria.GetProDesignCriteriaById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_ProDesginCriteria] where  ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_ProDesginCriteria = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetProDesignCriteriaBySubProId(ByVal SubProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_ProDesginCriteria.GetProDesignCriteriaBySubProId
            Dim paramProId As New SqlParameter("@SubProId", SqlDbType.Char)
            paramProId.Value = SubProId

            Dim sql As String = "select * from [t_PMS_ProDesginCriteria] where  SubProId  = @SubProId  "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramProId)

            If Not ds Is Nothing Then
                Return ds

            Else
                Return Nothing
            End If
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_ProDesginCriteria
            Dim info As New PMS_ProDesginCriteria
            info.Id = Convert.ToInt32(dr("ID"))
            info.SubProId = Convert.ToInt32(dr("SubProId"))
            info.CeriteriaSelectionId = Convert.ToInt32(dr("CeriteriaSelectionId"))


            If Not Convert.IsDBNull(dr("Description")) Then
                info.Description = Convert.ToInt32(dr("Description"))
            End If


            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_ProDesginCriteria) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@SubProId", SqlDbType.Int), _
                                                                    New SqlParameter("@CeriteriaSelectionId", SqlDbType.Int), _
                                                                    New SqlParameter("@Description", SqlDbType.Char)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.SubProId
            parameters(2).Value = info.CeriteriaSelectionId
            parameters(3).Value = info.Description

            Return parameters
        End Function
    End Class
End Namespace
