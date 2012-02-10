
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_ProposalUserInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_ProposalUserInfo




        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function UpdatePropoSaluserInfo(ByVal Info As Model.PMS_ProposalUserInfo) As Boolean Implements IDAL.IPMS_ProposalUserInfo.UpdateProposaluserInfo
            Dim strSql As String

            strSql = " Update t_PMS_ProposalUserInfo set "
            strSql += "UserId='" + Info.UserId.ToString + "'"
            strSql += " Where ProId ='" + Info.ProId.ToString + "'" + " and  ProposalUserTypeId ='" + Info.ProposalUserTypeId.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function


        Public Function AddProposalUserinfo(ByVal Info As PMS_ProposalUserInfo) As Boolean Implements IDAL.IPMS_ProposalUserInfo.AddProposalUserinfo
            Dim strSql As String


            strSql = "Insert into t_PMS_ProposalUserInfo (UserId,ProId,ProposalUserTypeId) Values ("
            strSql += "'" + Info.UserId.ToString + "',"
            strSql += "'" + Info.ProId.ToString + "',"
            strSql += "'" + Info.ProposalUserTypeId.ToString + "')"
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

        Public Function DeleteProposalUserInfo(ByVal Info As PMS_ProposalUserInfo) As Boolean Implements IDAL.IPMS_ProposalUserInfo.DeleteProposalUserInfo
            Dim strSql As String

            strSql = " Delete From t_PMS_ProposalUserInfo "
            strSql += " Where id ='" + CStr(Info.Id) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function GetProposalUserinfoById(ByVal Id As Integer) As PMS_ProposalUserInfo Implements IDAL.IPMS_ProposalUserInfo.GetProposalUserinfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_ProposalUserInfo] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_ProposalUserInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetProposalUserinfoByProId(ByVal ProId As Integer) As System.Data.DataSet Implements IDAL.IPMS_ProposalUserInfo.GetProposalUserinfoByProId
            Dim paramProId As New SqlParameter("@ProId", SqlDbType.Char)
            paramProId.Value = ProId
            Dim sql As String = "select * from [t_PMS_ProposalUserInfo] where ProID = @ProId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramProId)
            Dim info As PMS_ProposalUserInfo = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Public Function GetProposalUserinfoByProIdTypeId(ByVal Proid As Integer, ByVal TypeId As Integer) As System.Data.DataSet Implements IDAL.IPMS_ProposalUserInfo.GetProposalUserinfoByProIdTypeId


            Dim sql As String = "select * from [t_PMS_ProposalUserInfo] where ProposalUserTypeId ='" & Proid.ToString & "'" & " and ProID='" + TypeId.ToString + "'"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)
            Dim info As PMS_ProposalUserInfo = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function

        Public Function GetProposalUserinfoByTypeId(ByVal TypeId As Integer) As System.Data.DataSet Implements IDAL.IPMS_ProposalUserInfo.GetProposalUserinfoByTypeId
            Dim paramTypeId As New SqlParameter("@TypeId", SqlDbType.Char)
            paramTypeId.Value = TypeId
            Dim sql As String = "select * from [t_PMS_ProposalUserInfo] where ProposalUserTypeId = @TypeId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramTypeId)
            Dim info As PMS_ProposalUserInfo = Nothing
            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If
        End Function


        Private Function GetParameters(ByVal info As PMS_ProposalUserInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@UserId", SqlDbType.Int), _
                                                                    New SqlParameter("@ProId", SqlDbType.Int), _
                                                                    New SqlParameter("@ProposalUserTypeId", SqlDbType.Int)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.UserId
            parameters(2).Value = info.ProId
            parameters(3).Value = info.ProposalUserTypeId
            Return parameters
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As PMS_ProposalUserInfo
            Dim info As New PMS_ProposalUserInfo
            info.Id = Convert.ToInt32(dr("ID"))

            If Not Convert.IsDBNull(dr("UserId")) Then
                info.UserId = Convert.ToInt32(dr("UserId"))
            End If

            If Not Convert.IsDBNull(dr("ProId")) Then
                info.ProId = Convert.ToInt32(dr("ProId"))
            End If

            If Not Convert.IsDBNull(dr("ProposalUserTypeId")) Then
                info.ProposalUserTypeId = Convert.ToInt32(dr("ProposalUserTypeId"))
            End If

            Return info

        End Function


        Public Function IsExistUserInfo(ByVal UserId As Integer, ByVal ProId As Integer) As Boolean Implements IDAL.IPMS_ProposalUserInfo.IsExistUserInfo
            Dim paramUserId As SqlParameter = New SqlParameter("@UserId", SqlDbType.Char)
            Dim paramProId As SqlParameter = New SqlParameter("@ProId", SqlDbType.Char)
            paramUserId.Value = UserId.ToString
            paramProId.Value = ProId.ToString

            Dim strSql As String = "select count(0) from  t_PMS_ProposalUserInfo where UserId = @UserId and ProId =@ProId "
            Dim count As Integer = 0
            count = Me.ExecuteScalar(CommandType.Text, strSql, paramUserId, paramProId)
            If count >= 1 Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace
