
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components

Namespace SQLServerDAL
    Friend Class Base_ClientInfoWayTypeDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_ClientInfoWayType




        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetClientInfoWayTypeById(ByVal ID As Integer) As Model.Base_ClientInfoWayType Implements IDAL.IBase_ClientInfoWayType.GetClientInfoWayTypeById
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_Base_ClientInfoWayType] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_ClientInfoWayType = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetClientInfoWayTypeInfo() As System.Data.DataSet Implements IDAL.IBase_ClientInfoWayType.GetClientInfoWayTypeInfo
            Dim sql As String = "select * from [t_Base_ClientInfoWayType] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_ClientInfoWayType
            Dim info As New Base_ClientInfoWayType
            info.ID = Convert.ToInt32(dr("ID"))
            info.InformationWay = dr("InformationWay").ToString()
            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_ClientInfoWayType) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@InformationWay", SqlDbType.Char)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.InformationWay


            Return parameters
        End Function

    End Class
End Namespace
