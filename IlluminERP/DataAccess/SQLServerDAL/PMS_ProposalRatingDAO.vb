Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_ProposalRatingDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_ProposalRating





        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub



        Private Function GetParameters(ByVal info As PMS_ProposalRatingInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@UserId", SqlDbType.Int), _
                                                                    New SqlParameter("@ProId", SqlDbType.Int), _
                                                                    New SqlParameter("@Comments", SqlDbType.Char), _
                                                                    New SqlParameter("@Rating", SqlDbType.Decimal
                                                                                     )}
            parameters(0).Value = info.Id
            parameters(1).Value = info.UserId
            parameters(2).Value = info.ProId
            parameters(3).Value = info.Comments
            parameters(4).Value = info.Rating
            Return parameters
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_ProposalRatingInfo
            Dim info As New PMS_ProposalRatingInfo
            info.Id = Convert.ToInt32(dr("ID"))

            If Not Convert.IsDBNull(dr("UserId")) Then
                info.UserId = Convert.ToInt32(dr("UserId"))
            End If

            If Not Convert.IsDBNull(dr("ProId")) Then
                info.ProId = Convert.ToInt32(dr("ProId"))
            End If

            If Not Convert.IsDBNull(dr("Rating")) Then
                info.Rating = Convert.ToDecimal(dr("Rating"))
            End If

            If Not Convert.IsDBNull(dr("Comments")) Then
                info.Comments = Convert.ToString(dr("Comments"))
            End If

            Return info

        End Function

        Public Function AddProposalRatinginfo(ByVal Info As Model.PMS_ProposalRatingInfo) As Boolean Implements IDAL.IPMS_ProposalRating.AddProposalRatinginfo
            Dim strSql As String


            strSql = "Insert into t_PMS_ProposalRating (UserId,ProId,Rating,Comments) Values ("
            strSql += "'" + Info.UserId.ToString + "',"
            strSql += "'" + Info.ProId.ToString + "',"
            strSql += "'" + Info.Rating.ToString + "',"
            strSql += "'" + Info.Comments.ToString + "')"
            strSql += " select ID=@@Identity"


            Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, strSql)
            If dr.Read Then
                Info.Id = Convert.ToInt32(dr("Id"))
                dr.Close()
                dr = Nothing
                Return Info.Id
            Else
                Return 0
            End If

        End Function

        Public Function DeleteProposalRatinginfo(ByVal Info As Model.PMS_ProposalRatingInfo) As Boolean Implements IDAL.IPMS_ProposalRating.DeleteProposalRatinginfo
            Dim strSql As String

            strSql = " Delete From t_PMS_ProposalRating "
            strSql += " Where  Id  ='" + CStr(Info.Id) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetProposalRatingInfoById(ByVal Id As Integer) As Model.PMS_ProposalRatingInfo Implements IDAL.IPMS_ProposalRating.GetProposalRatingInfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_ProposalRating] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_ProposalRatingInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetProposalRatingInfoByProId(ByVal ProId As Integer) As System.Data.DataView Implements IDAL.IPMS_ProposalRating.GetProposalRatingInfoByProId
            Dim paramProId As New SqlParameter("@ProId", SqlDbType.Char)
            paramProId.Value = ProId
            Dim sql As String = "select * from [t_PMS_ProposalRating] where ProID = @ProId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramProId)
            Dim info As PMS_ProposalRatingInfo = Nothing
            If Not (ds Is Nothing) Then
                Return ds.Tables(0).DefaultView
            Else
                Return Nothing
            End If
        End Function

        Public Function UpdateProposalRatinginfo(ByVal Info As Model.PMS_ProposalRatingInfo) As Boolean Implements IDAL.IPMS_ProposalRating.UpdateProposalRatinginfo
            Dim strSql As String

            strSql = " Update t_PMS_ProposalRating set "
            strSql += "Rating='" + Info.Rating.ToString + "',"
            strSql += "Comments='" + Info.Comments.ToString + "'"
            strSql += " Where ProId ='" + Info.ProId.ToString + "'" + " and  UserId ='" + Info.UserId.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function


        Public Function GetProposalRatingInfoByProidUserId(ByVal Proid As Integer, ByVal UserId As Integer) As Boolean Implements IDAL.IPMS_ProposalRating.GetProposalRatingInfoByProidUserId
            Dim paramProId As New SqlParameter("@ProId", SqlDbType.Char)
            Dim paramUserId As New SqlParameter("@UserId", SqlDbType.Char)
            paramProId.Value = Proid
            paramUserId.Value = UserId
            Dim sql As String = "select * from [t_PMS_ProposalRating] where ProID = @ProId and UserId=@UserId"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramProId, paramUserId)
            Dim info As PMS_ProposalRatingInfo = Nothing
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace

