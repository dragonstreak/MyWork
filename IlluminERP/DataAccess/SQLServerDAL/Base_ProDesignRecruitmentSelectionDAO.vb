

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_ProDesignRecruitmentSelectionDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_ProDesignRecruitmentSelection


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetRecruitmentSelectionInfoByID(ByVal ID As Integer) As Model.Base_ProDesignRecruitmentSelection Implements IDAL.IBase_ProDesignRecruitmentSelection.GetRecruitmentSelectionInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_Base_ProDesignRecruitmentSelection] where Id = @id "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As IBase_ProDesignRecruitmentSelection = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetRecruitmentSelectionInfoByRecruitmentId(ByVal RecruitmentId As Integer) As System.Data.DataSet Implements IDAL.IBase_ProDesignRecruitmentSelection.GetRecruitmentSelectionInfoByRecruitmentId
            Dim paramRecruitmentId As New SqlParameter("@RecruitmentId", SqlDbType.Int)
            paramRecruitmentId.Value = RecruitmentId
            Dim sql As String = "select * from [t_Base_ProDesignRecruitmentSelection] where RecruitmentId = @RecruitmentId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramRecruitmentId)
            Dim info As IBase_ProDesignRecruitmentSelection = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_ProDesignRecruitmentSelection
            Dim info As New Base_ProDesignRecruitmentSelection
            info.ID = Convert.ToInt32(dr("ID"))
            info.RecruitmentSelection = dr("RecruitmentSelection").ToString()
            info.RecruitmentId = Convert.ToInt32(dr("RecruitmentId"))

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_ProDesignRecruitmentSelection) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@RecruitmentSelection", SqlDbType.VarChar), _
                                                                    New SqlParameter("@RecruitmentId", SqlDbType.Int)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.RecruitmentSelection
            parameters(2).Value = info.RecruitmentId


            Return parameters
        End Function

        
    End Class
End Namespace
