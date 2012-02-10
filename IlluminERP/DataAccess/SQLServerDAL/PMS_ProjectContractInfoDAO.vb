

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class PMS_ProjectContractInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_ProjectContractInfo


        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Public Function AddProjectContractInfo(ByVal info As Model.PMS_ProjectContractInfo) As Integer Implements IDAL.IPMS_ProjectContractInfo.AddProjectContractInfo
            Dim strSql As String
            strSql = "Insert into t_PMS_ProjectContractInfo (ProjectId,ContractDate,Amount,AdditionalAmount,Contact,Telephone,Memo,CreateUser,CreateDate) Values("
            strSql += "'" + info.ProjectId.ToString + "',"
            strSql += "'" + info.ContractDate.ToString + "',"
            strSql += "'" + info.Amount.ToString + "',"
            strSql += "'" + info.AdditionalAmount.ToString + "',"
            strSql += "'" + info.Contact.ToString + "',"
            strSql += "'" + info.Telephone.ToString + "',"
            strSql += "'" + info.Memo.ToString + "',"
            strSql += "'" + info.CreateUser.ToString + "',"
            strSql += "'" + info.CreateDate.ToString + "')"
            strSql += " Select Id =@@Identity"


            Dim dr As SqlClient.SqlDataReader = ExecuteReader(CommandType.Text, strSql)
            If dr.Read Then
                info.ID = Convert.ToInt32(dr("Id"))
                dr.Close()
                dr = Nothing
                Return info.ID
            Else
                Return 0
            End If
        End Function

        Public Function GetProjectContractInfoById(ByVal Id As Integer) As Model.PMS_ProjectContractInfo Implements IDAL.IPMS_ProjectContractInfo.GetProjectContractInfoById
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = Id
            Dim sql As String = "select * from [t_PMS_ProjectContractInfo] where  ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_ProjectContractInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToClientInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetProjectContractInfobyProId(ByVal ProId As Integer) As Model.PMS_ProjectContractInfo Implements IDAL.IPMS_ProjectContractInfo.GetProjectContractInfobyProId
            Dim paramId As New SqlParameter("@ProId", SqlDbType.Char)
            paramId.Value = ProId
            Dim sql As String = "select * from [t_PMS_ProjectContractInfo] where  ProjectId = @ProId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_ProjectContractInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToClientInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function IsExistProjectContract(ByVal ProId As Integer) As Boolean Implements IDAL.IPMS_ProjectContractInfo.IsExistProjectContract
            Dim ParamProId As SqlParameter = New SqlParameter("@ProId", SqlDbType.Int)
            ParamProId.Value = ProId
            Dim sql As String = "select count(0) from [t_PMS_ProjectContractInfo] where ProjectId = @ProId "
            Dim count As Integer = 0
            count = ExecuteScalar(CommandType.Text, sql, ParamProId)
            If count = 1 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function UpdateProjectContractInfo(ByVal Info As Model.PMS_ProjectContractInfo) As Boolean Implements IDAL.IPMS_ProjectContractInfo.UpdateProjectContractInfo
            Dim strSql As String

            strSql = " Update t_PMS_ProjectContractInfo set "
            strSql += "ContractDate='" + Info.ContractDate.ToString + "'"
            strSql += ",Amount='" + Info.Amount.ToString + "'"
            strSql += ",AdditionalAmount='" + Info.AdditionalAmount.ToString + "'"
            strSql += ",Contact='" + Info.Contact.ToString + "'"
            strSql += ",Telephone='" + Info.Telephone.ToString + "'"
            strSql += ",Memo='" + Info.Memo.ToString + "'"
            strSql += " Where Id ='" + Info.ProjectId.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function


        Private Function MapRowToClientInfo(ByVal dr As DataRow) As PMS_ProjectContractInfo

            Dim info As New PMS_ProjectContractInfo
            info.ID = Convert.ToInt32(dr("ID"))

            info.ProjectId = dr("ProjectId").ToString()

            If Not Convert.IsDBNull(dr("ContractDate")) Then
                info.ContractDate = Convert.ToDateTime(dr("ContractDate"))
            End If

            If Not Convert.IsDBNull(dr("CreateDate")) Then
                info.CreateDate = Convert.ToDateTime(dr("CreateDate"))
            End If


            If Not Convert.IsDBNull(dr("CreateUser")) Then
                info.CreateUser = Convert.ToInt32(dr("CreateUser"))
            End If

            If Not Convert.IsDBNull(dr("Memo")) Then
                info.Memo = dr("Memo").ToString()
            End If


            If Not Convert.IsDBNull(dr("Telephone")) Then
                info.Telephone = dr("Telephone").ToString()
            End If

            If Not Convert.IsDBNull(dr("Contact")) Then
                info.Contact = dr("Contact").ToString()
            End If

            If Not Convert.IsDBNull(dr("AdditionalAmount")) Then
                info.AdditionalAmount = Convert.ToDecimal(dr("AdditionalAmount"))
            End If

            If Not Convert.IsDBNull(dr("Amount")) Then
                info.Amount = Convert.ToDecimal(dr("Amount"))
            End If


            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_ProjectContractInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ProjectId", SqlDbType.Int), _
                                                                    New SqlParameter("@ContractDate", SqlDbType.DateTime), _
                                                                    New SqlParameter("@Amount", SqlDbType.Decimal), _
                                                                    New SqlParameter("@AdditionalAmount", SqlDbType.Decimal), _
                                                                    New SqlParameter("@CreateUser", SqlDbType.Int), _
                                                                    New SqlParameter("@CreateDate", SqlDbType.DateTime), _
                                                                    New SqlParameter("@Contact", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Telephone", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Memo", SqlDbType.VarChar)}
            parameters(0).Value = info.ID
            parameters(1).Value = info.ProjectId
            parameters(2).Value = info.ContractDate
            parameters(3).Value = info.Amount
            parameters(4).Value = info.AdditionalAmount
            parameters(5).Value = info.CreateUser
            parameters(6).Value = info.CreateDate
            parameters(7).Value = info.Contact
            parameters(8).Value = info.Telephone
            parameters(9).Value = info.Memo

            Return parameters
        End Function

    End Class
End Namespace
