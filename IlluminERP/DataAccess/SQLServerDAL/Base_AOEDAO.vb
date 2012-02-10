Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_AOEDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_AOE


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Private Function MapRowToAOEInfo(ByVal dr As DataRow) As Base_AOE
            Dim info As New Base_AOE
            info.ID = Convert.ToInt32(dr("ID"))
            info.AOE = dr("AOE").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_AOE) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@AOE", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.AOE


            Return parameters
        End Function

        Public Function GetAOEInfo() As System.Data.DataSet Implements IDAL.IBase_AOE.GetAOEInfo
            Dim sql As String = "select * from [t_base_AOE] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetAOEInfoByID(ByVal ID As Integer) As Model.Base_AOE Implements IDAL.IBase_AOE.GetAOEInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_AOE] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_AOE = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToAOEInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function
    End Class

End Namespace

