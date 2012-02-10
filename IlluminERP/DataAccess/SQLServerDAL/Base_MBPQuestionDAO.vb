Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_MBPQuestionDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_MBPQuestion


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetMBPQuestion() As System.Data.DataSet Implements IDAL.IBase_MBPQuestion.GetMBPQuestion
            Dim sql As String = "select * from [t_Base_MBPQuestion] Order by Id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetMBPQuestionByID(ByVal ID As Integer) As Model.Base_MBPQuestion Implements IDAL.IBase_MBPQuestion.GetMBPQuestionByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_Base_MBPQuestion] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_MBPQuestion = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_MBPQuestion
            Dim info As New Base_MBPQuestion
            info.ID = Convert.ToInt32(dr("ID"))
            info.MBPQuestion = dr("MBPQuestion").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_MBPQuestion) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@MBPQuestion", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.MBPQuestion


            Return parameters
        End Function
    End Class
End Namespace
