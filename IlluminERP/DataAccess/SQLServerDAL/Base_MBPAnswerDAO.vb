Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_MBPAnswerDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_MBPAnswer

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetMBPAnswerById(ByVal Id As Integer) As Model.Base_MBPAnswer Implements IDAL.IBase_MBPAnswer.GetMBPAnswerById
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = Id
            Dim sql As String = "select * from [t_Base_MBPAnswer] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_MBPAnswer = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetMBPAnswerByQuestionId(ByVal QuestionId As Integer) As System.Data.DataSet Implements IDAL.IBase_MBPAnswer.GetMBPAnswerByQuestionId
            Dim paramQuestionId As New SqlParameter("@QuestionId", SqlDbType.Int)
            paramQuestionId.Value = QuestionId
            Dim sql As String = "select * from [t_Base_MBPAnswer] where MBPQuestionId = @QuestionId"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramQuestionId)
            Dim info As Base_MBPAnswer = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_MBPAnswer
            Dim info As New Base_MBPAnswer
            info.ID = Convert.ToInt32(dr("ID"))
            info.MBPQuestionId = Convert.ToInt32(dr("MBPQuestionId"))
            info.Answer = Convert.ToString(dr("Answer"))
            info.Value = Convert.ToDecimal(dr("Value"))


            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_MBPAnswer) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                New SqlParameter("@MBPQuestionId", SqlDbType.Int), _
                                                New SqlParameter("@Answer", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Value", SqlDbType.Decimal)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.MBPQuestionId
            parameters(2).Value = info.Answer
            parameters(3).Value = info.Value



            Return parameters
        End Function
    End Class
End Namespace