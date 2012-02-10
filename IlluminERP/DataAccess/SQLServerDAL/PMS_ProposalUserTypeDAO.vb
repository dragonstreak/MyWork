
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL

    Friend Class PMS_ProposalUserTypeDAO

        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_ProposalUserType


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetProposalUserTypeInfo() As System.Data.DataSet Implements IDAL.IPMS_ProposalUserType.GetProposalUserTypeInfo
            Dim sql As String = "select * from [t_PMS_ProposalUserType] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetProposalUserTypeInfoByID(ByVal ID As Integer) As Model.PMS_ProposalUserType Implements IDAL.IPMS_ProposalUserType.GetProposalUserTypeInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_PMS_ProposalUserType] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Model.PMS_ProposalUserType = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToSectorInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function


        Private Function MapRowToSectorInfo(ByVal dr As DataRow) As Model.PMS_ProposalUserType
            Dim info As New Model.PMS_ProposalUserType
            info.ID = Convert.ToInt32(dr("ID"))
            info.ProposalUserType = dr("ProposalUserType").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.PMS_ProposalUserType) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProposalUserType", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.ProposalUserType


            Return parameters
        End Function
    End Class
End Namespace
