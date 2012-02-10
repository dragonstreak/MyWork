Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_StudyTypeDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_StudyType

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetStudyTypeByID(ByVal ID As Integer) As Model.Base_StudyType Implements IDAL.IBase_StudyType.GetStudyTypeByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from t_base_studytype where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_StudyType = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToBSInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetStudyTypeInfo() As System.Data.DataSet Implements IDAL.IBase_StudyType.GetStudyTypeInfo
            Dim sql As String = "select * from [t_base_studytype] Order by StudyType"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Private Function MapRowToBSInfo(ByVal dr As DataRow) As Base_StudyType
            Dim info As New Base_StudyType
            info.ID = Convert.ToInt32(dr("ID"))
            info.StudyType = dr("studytype").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_StudyType) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@studytype", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.StudyType


            Return parameters
        End Function

    End Class
End Namespace

