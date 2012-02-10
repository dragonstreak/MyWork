Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_ProposalRatingDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_ProposalRating



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function GetProposalRatingInfo() As System.Data.DataSet Implements IDAL.IBase_ProposalRating.GetProposalRatingInfo
            Dim sql As String = "select * from [t_base_ProposalRating] Order by ProposalRating"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetProposalRatingInfoById(ByVal ID As Integer) As Model.Base_ProposalRating Implements IDAL.IBase_ProposalRating.GetProposalRatingInfoById
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_ProposalRating] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_ProposalRating = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToSectorInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToSectorInfo(ByVal dr As DataRow) As Base_ProposalRating
            Dim info As New Base_ProposalRating
            info.ID = Convert.ToInt32(dr("ID"))
            info.ProposalRating = dr("ProposalRating").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_ProposalRating) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                       New SqlParameter("@ProposalRating", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.ProposalRating



            Return parameters
        End Function
    End Class
End Namespace
