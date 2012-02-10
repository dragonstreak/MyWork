Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_BusinessUnitDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_BusinessUnit


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetBusinessUnitInfo() As System.Data.DataSet Implements IDAL.IBase_BusinessUnit.GetBusinessUnitInfo
            Dim sql As String = "select * from [t_base_businessUnit] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetBusinessUnitInfoByID(ByVal ID As Integer) As Model.Base_BusinessUnit Implements IDAL.IBase_BusinessUnit.GetBusinessUnitInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_businessUnit] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_BusinessUnit = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToBSInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToBSInfo(ByVal dr As DataRow) As Base_BusinessUnit
            Dim info As New Base_BusinessUnit
            info.ID = Convert.ToInt32(dr("ID"))
            info.Businessunit = dr("BusinessUnit").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_BusinessUnit) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@BusinessUnit", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.Businessunit


            Return parameters
        End Function

    End Class
End Namespace

