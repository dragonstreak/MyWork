Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL


    Friend Class Base_SectorDAO

        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_Sector


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function GetSectorInfo() As System.Data.DataSet Implements IDAL.IBase_Sector.GetSectorInfo
            Dim sql As String = "select * from [t_base_Sector] Order by Sector"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetSectorInfoByID(ByVal ID As Integer) As Model.Base_Sector Implements IDAL.IBase_Sector.GetSectorInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_Sector] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_Sector = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToSectorInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function


        Private Function MapRowToSectorInfo(ByVal dr As DataRow) As Base_Sector
            Dim info As New Base_Sector
            info.ID = Convert.ToInt32(dr("ID"))
            info.BusinessUnitId = Convert.ToInt32(dr("BusinessUnitId"))
            info.Sector = dr("Sector").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_Sector) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@BusinessUnitID", SqlDbType.Int), _
                                                                    New SqlParameter("@Sector", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.BusinessUnitId
            parameters(2).Value = info.Sector



            Return parameters
        End Function

        Public Function GetSectorInfoByBusinessUnitId(ByVal BUId As Integer) As System.Data.DataSet Implements IDAL.IBase_Sector.GetSectorInfoByBusinessUnitId
            Dim sql As String = "select * from [t_base_Sector] Where BusinessUnitId ='" + BUId.ToString + "'" + "   Order by Sector"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function
    End Class

End Namespace
