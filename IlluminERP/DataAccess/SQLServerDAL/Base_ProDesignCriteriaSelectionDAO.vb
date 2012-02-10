
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_ProDesignCriteriaSelectionDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_ProDesignCriteriaSelection



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetCriteriaSelectionInfoByCriteriaId(ByVal CriteriaId As Integer) As System.Data.DataSet Implements IDAL.IBase_ProDesignCriteriaSelection.GetCriteriaSelectionInfoByCriteriaId
            Dim paramCriteriaId As New SqlParameter("@CriteriaId", SqlDbType.Int)
            paramCriteriaId.Value = CriteriaId
            Dim sql As String = "select * from [t_Base_ProDesignCriteriaSelection] where CriteriaId = @CriteriaId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramCriteriaId)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetCriteriaSelectionInfoByID(ByVal ID As Integer) As Model.Base_ProDesignCriteriaSelection Implements IDAL.IBase_ProDesignCriteriaSelection.GetCriteriaSelectionInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_Base_ProDesignCriteriaSelection] where Id = @id "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_ProDesignCriteriaSelection = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_ProDesignCriteriaSelection
            Dim info As New Base_ProDesignCriteriaSelection
            info.ID = Convert.ToInt32(dr("ID"))
            info.CriteriaSelection = dr("CriteriaSelection").ToString()
            info.CriteriaId = Convert.ToInt32(dr("CriteriaId"))

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_ProDesignCriteriaSelection) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@CriteriaSelection", SqlDbType.VarChar), _
                                                                    New SqlParameter("@CriteriaId", SqlDbType.Int)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.CriteriaSelection
            parameters(2).Value = info.CriteriaId


            Return parameters
        End Function
    End Class
End Namespace
