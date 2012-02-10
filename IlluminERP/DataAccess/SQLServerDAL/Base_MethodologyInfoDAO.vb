
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL


    Friend Class Base_MethodologyInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.Ibase_MethodologyInfo



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_MethodologyInfo
            Dim info As New Base_MethodologyInfo
            info.ID = Convert.ToInt32(dr("ID"))
            info.Methodology = dr("Methodology").ToString()
            info.MethodologyType = Convert.ToInt32(dr("MethodologyType"))
            info.Tag = dr("Tag").ToString()
            Return info

        End Function


        Private Function GetParameters(ByVal info As Base_MethodologyInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@Methodology", SqlDbType.VarChar), _
                                                                    New SqlParameter("@MethodologyType", SqlDbType.Int), _
                                                                    New SqlParameter("@Tag", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.Methodology
            parameters(2).Value = info.MethodologyType
            parameters(3).Value = info.Tag



            Return parameters
        End Function



        Public Function GetMethodologyInfo(ByVal Id As Integer) As Model.Base_MethodologyInfo Implements IDAL.Ibase_MethodologyInfo.GetMethodologyInfo
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = Id
            Dim sql As String = "select * from [t_Base_Methodology] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_MethodologyInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetMethodologyInfoByType(ByVal MethType As Integer) As System.Data.DataSet Implements IDAL.Ibase_MethodologyInfo.GetMethodologyInfoByType

            Dim paramMethType As New SqlParameter("@MethType", SqlDbType.Int)
            paramMethType.Value = MethType
            Dim sql As String = "select * from [t_Base_Methodology] where MethodologyType = @MethType"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramMethType)
            Dim info As Base_MethodologyInfo = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function
    End Class
End Namespace
