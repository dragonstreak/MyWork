Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL

    Friend Class Base_BusinessSolutionDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_BusinessSolution

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetBSByID(ByVal ID As Integer) As Model.Base_BusinessSolution Implements IDAL.IBase_BusinessSolution.GetBSByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_base_BusinessSolution] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_BusinessSolution = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToBSInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetBSInfo() As System.Data.DataSet Implements IDAL.IBase_BusinessSolution.GetBSInfo
            Dim sql As String = "select * from [t_base_BusinessSolution] Order by BusinessSolution"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Private Function MapRowToBSInfo(ByVal dr As DataRow) As Base_BusinessSolution
            Dim info As New Base_BusinessSolution
            info.ID = Convert.ToInt32(dr("ID"))
            info.BusinessSolution = dr("BusinessSolution").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_BusinessSolution) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@BusinessSolution", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.BusinessSolution


            Return parameters
        End Function
    End Class
End Namespace
