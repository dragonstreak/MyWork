

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL

    Friend Class PMS_SubProjectInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_SubProjectInfo



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function AddSubProjectInfo(ByVal info As Model.PMS_SubProjectInfo) As Integer Implements IDAL.IPMS_SubProjectInfo.AddSubProjectInfo
            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_SubProjectInfo (ProId,SubJobNumber,MethodologyType,MethodologyId,Description,Status) Values ("
                strSql += "'" + info.ProId.ToString + "',"
                strSql += "'" + info.SubJobNumber.ToString + "',"
                strSql += "'" + info.MethodologyType.ToString + "',"
                strSql += "'" + info.MethodologyId.ToString + "',"
                strSql += "'" + info.Description.ToString + "',"
                strSql += "'" + info.Status.ToString + "')"
                strSql += " select ID=@@Identity"


                Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, strSql)
                If dr.Read Then
                    info.Id = Convert.ToInt32(dr("Id"))
                    dr.Close()
                    dr = Nothing
                    Return info.Id
                Else
                    Return 0
                End If

            Catch ex As Exception
                Dim str As String = ex.Message
            End Try

        End Function

        Public Function GetSubProjectInfoById(ByVal ID As Integer) As Model.PMS_SubProjectInfo Implements IDAL.IPMS_SubProjectInfo.GetSubProjectInfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_PMS_SubProjectInfo] where Status=0 And ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_SubProjectInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetSubProjectInfoByProId(ByVal ProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_SubProjectInfo.GetSubProjectInfoByProId
            Dim paramProId As New SqlParameter("@ProId", SqlDbType.Char)
            paramProId.Value = ProId

            Dim sql As String = "select * from [t_PMS_SubProjectInfo] where Status=0 and ProId  = @ProId  Order by SubJobNumber DESC"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramProId)

            If Not ds Is Nothing Then
                Return ds

            Else
                Return Nothing
            End If
        End Function

        Public Function UpdateSubProjectStatus(ByVal info As Model.PMS_SubProjectInfo) As Boolean Implements IDAL.IPMS_SubProjectInfo.UpdateSubProjectStatus
            Dim factory As New SqlServerFactory
            Dim strSql As String
            factory.BeginTransaction()
            Try
                strSql = " Update t_PMS_SubProjectInfo Set Status='" + info.Status.ToString + "'" + "  Where Id ='" + info.Id.ToString + "'"
                Dim count As Integer = 0

                count = Me.ExecuteNonQuery(CommandType.Text, strSql)
                If count = 1 Then
                    Return True
                Else
                    Return False
                End If
                factory.Commit()
                Return True
            Catch ex As Exception
                factory.Rollback()
                Return False

            End Try
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_SubProjectInfo
            Dim info As New PMS_SubProjectInfo
            info.Id = Convert.ToInt32(dr("ID"))
            info.ProId = Convert.ToInt32(dr("ProId"))
            info.SubJobNumber = dr("SubJobNumber").ToString()


            If Not Convert.IsDBNull(dr("MethodologyType")) Then
                info.MethodologyType = Convert.ToInt32(dr("MethodologyType"))
            End If

            If Not Convert.IsDBNull(dr("MethodologyId")) Then
                info.MethodologyId = Convert.ToInt32(dr("MethodologyId"))
            End If

            If Not Convert.IsDBNull(dr("Description")) Then
                info.Description = Convert.ToString(dr("Description"))
            End If


            If Not Convert.IsDBNull(dr("Status")) Then
                info.Status = Convert.ToInt32(dr("Status"))
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_SubProjectInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProId", SqlDbType.Char), _
                                                                    New SqlParameter("@SubJobNumber", SqlDbType.Char), _
                                                                    New SqlParameter("@MethodologyType", SqlDbType.Int), _
                                                                    New SqlParameter("@MethodologyId", SqlDbType.Int), _
                                                                    New SqlParameter("@Description", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Status", SqlDbType.Int)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.ProId
            parameters(2).Value = info.SubJobNumber
            parameters(3).Value = info.MethodologyType
            parameters(4).Value = info.MethodologyId
            parameters(5).Value = info.Description
            parameters(6).Value = info.Status

            Return parameters
        End Function

        Public Function GetSubJobNumberByJobNumberMethTag(ByVal JobNumber As String, ByVal MethTag As String) As String Implements IDAL.IPMS_SubProjectInfo.GetSubJobNumberByJobNumberMethTag
            Dim strSql As String
            Dim strNumber As String
            Dim strMaxNumber As String
            Dim strSubJobNumber As String = String.Empty

            strNumber = JobNumber & "-" & MethTag

            strSql = "Select  MAX(RIGHT(rtrim(SubJobNumber), (LEN(Rtrim(SubJobNumber)) - 12)))  as MaxNumber  From  [t_PMS_SubProjectInfo]  " & _
                    " Where  Status=0 And Left(SubJobNumber,12)='" + Trim(strNumber) + "'"

            Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(CommandType.Text, strSql)


            If dr.Read Then
                strMaxNumber = Trim(IIf(IsDBNull(dr("MaxNumber")), "", dr("MaxNumber")))
                If strMaxNumber = "" Then
                    strSubJobNumber = strNumber & "0"
                Else
                    strSubJobNumber = strNumber & CStr(CInt(strMaxNumber) + 1)
                End If

            End If

            dr.Close()
            Return strSubJobNumber

        End Function
    End Class
End Namespace
