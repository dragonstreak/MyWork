Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_ProRelationInfoDAO

        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_ProRelationInfo

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Private Function MapRowToBSInfo(ByVal dr As DataRow) As PMS_ProRelationInfo
            Dim info As New PMS_ProRelationInfo
            info.ID = Convert.ToInt32(dr("ID"))
            info.ProId = Convert.ToInt32(dr("Proid"))
            info.RelationType = Convert.ToString(dr("RelationType"))
            info.RelationProId = Convert.ToInt32(dr("RelationProId"))

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.PMS_ProRelationInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                New SqlParameter("@ProId", SqlDbType.Int), _
                                                New SqlParameter("@RelationType", SqlDbType.Char), _
                                                New SqlParameter("@RelationProId", SqlDbType.Int)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.ProId
            parameters(2).Value = info.RelationType
            parameters(3).Value = info.RelationProId


            Return parameters
        End Function

        Public Function GetRelationProInfoByProId(ByVal Proid As Integer) As System.Data.DataSet Implements IDAL.IPMS_ProRelationInfo.GetRelationProInfoByProId

            Dim sql As String = "select * from [t_PMS_ProRelationInfo] Where Proid= {0}"
            sql = String.Format(sql, Proid)
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetRelationProInfoByRelationProId(ByVal RelationProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_ProRelationInfo.GetRelationProInfoByRelationProId
            Dim sql As String = "select * from [t_PMS_ProRelationInfo] Where Proid in (select Proid from [t_Base_ProRelationInfo] RelationProId= {0})"
            sql = String.Format(sql, RelationProId)
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function DeleteProRelationInfo(ByVal ProRelationInfo As Model.PMS_ProRelationInfo) As Boolean Implements IDAL.IPMS_ProRelationInfo.DeleteProRelationInfo
            Try
                Dim sql As String = "DELETE FROM [t_PMS_ProRelationInfo] WHERE ID={0}"
                sql = String.Format(sql, ProRelationInfo.ID)
                Me.ExecuteNonQuery(CommandType.Text, sql)
                Return True
            Catch ex As Exception
                Return False
            Finally
            End Try

        End Function

        Public Function InsertProRelationInfo(ByVal ProRelationInfo As Model.PMS_ProRelationInfo) As Boolean Implements IDAL.IPMS_ProRelationInfo.InsertProRelationInfo

            Try
                Dim sql As String = "INSERT INTO [t_PMS_ProRelationInfo] ([ProId], [RelationType], [RelationProId]) "
                sql += " VALUES ('{0}', '{1}', '{2}')"
                sql = String.Format(sql, ProRelationInfo.ProId, ProRelationInfo.RelationType, ProRelationInfo.RelationProId)
                Me.ExecuteNonQuery(CommandType.Text, sql)
                Return True
            Catch ex As Exception
                Return False
            Finally
            End Try

        End Function


       
    End Class
End Namespace

