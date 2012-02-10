Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class Client_ClientDetailInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IClient_ClientDetailInfo





        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        'Public Function GetClientDetailInfoByClientId(ByVal ClientId As Integer) As Model.Client_ClientDetailInfo Implements IDAL.IClient_ClientDetailInfo.GetClientDetailInfoByClientId
        '    Dim paramClientId As New SqlParameter("@ClientId", SqlDbType.Char)
        '    paramClientId.Value = ClientId
        '    Dim sql As String = "select * from [t_Client_ClientDetailInfo] where ClientId = @ClientId "
        '    Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramClientId)
        '    Dim info As Client_ClientDetailInfo = Nothing
        '    If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
        '        info = MapRowToInfo(ds.Tables(0).Rows(0))
        '    End If
        '    Return info
        'End Function

        Public Function GetClientDetailInfoByID(ByVal ID As Integer) As Model.Client_ClientDetailInfo Implements IDAL.IClient_ClientDetailInfo.GetClientDetailInfoByID
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_Client_ClientDetailInfo] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As Client_ClientDetailInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Client_ClientDetailInfo
            Dim info As New Client_ClientDetailInfo
            info.Id = Convert.ToInt32(dr("ID"))

            info.ClientId = Convert.ToInt32(dr("ClientId"))

            If Not Convert.IsDBNull(dr("FirstNameCN")) Then
                info.FirstNameCN = dr("FirstNameCN").ToString()
            End If

            If Not Convert.IsDBNull(dr("FirstNameEN")) Then
                info.FirstNameEN = dr("FirstNameEN").ToString()
            End If

            If Not Convert.IsDBNull(dr("LastNameCN")) Then
                info.LastNameCN = dr("LastNameCN").ToString()
            End If

            If Not Convert.IsDBNull(dr("LastNameEN")) Then
                info.LastNameEN = dr("LastNameEN").ToString()
            End If

            If Not Convert.IsDBNull(dr("CompanyAddressCN")) Then
                info.CompanyAddressCN = dr("CompanyAddressCN").ToString()
            End If

            If Not Convert.IsDBNull(dr("CompanyAddressEN")) Then
                info.CompanyAddressEN = dr("CompanyAddressEN").ToString()
            End If

            If Not Convert.IsDBNull(dr("JobTitle")) Then
                info.JobTitle = dr("JobTitle").ToString()
            End If

            If Not Convert.IsDBNull(dr("Department")) Then
                info.Department = dr("Department").ToString()
            End If


            If Not Convert.IsDBNull(dr("Email")) Then
                info.Email = dr("Email").ToString()
            End If

            If Not Convert.IsDBNull(dr("MobilePhone")) Then
                info.MobilePhone = dr("MobilePhone").ToString()
            End If


            If Not Convert.IsDBNull(dr("TelDirect")) Then
                info.TelDirect = dr("TelDirect").ToString()
            End If


            If Not Convert.IsDBNull(dr("TelGeneral")) Then
                info.TelGeneral = dr("TelGeneral").ToString()
            End If


            If Not Convert.IsDBNull(dr("Country")) Then
                info.Country = dr("Country").ToString()
            End If


            If Not Convert.IsDBNull(dr("City")) Then
                info.City = dr("City").ToString()
            End If


            If Not Convert.IsDBNull(dr("PostCode")) Then
                info.PostCode = dr("PostCode").ToString()
            End If

            If Not Convert.IsDBNull(dr("Website")) Then
                info.Website = dr("Website").ToString()
            End If


            Return info

        End Function

        Private Function GetParameters(ByVal info As Client_ClientDetailInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@ClientId", SqlDbType.Int), _
                                                                    New SqlParameter("@FirstNameCN", SqlDbType.Char), _
                                                                    New SqlParameter("@FirstNameEN", SqlDbType.Char), _
                                                                    New SqlParameter("@LastNameCN", SqlDbType.Char), _
                                                                    New SqlParameter("@LastNameEN", SqlDbType.Char), _
                                                                    New SqlParameter("@CompanyAddressCN", SqlDbType.Char), _
                                                                    New SqlParameter("@CompanyAddressEN", SqlDbType.Char), _
                                                                    New SqlParameter("@JobTitle", SqlDbType.Char), _
                                                                    New SqlParameter("@Department", SqlDbType.Char), _
                                                                    New SqlParameter("@Email", SqlDbType.Char), _
                                                                    New SqlParameter("@MobilePhone", SqlDbType.Char), _
                                                                    New SqlParameter("@TelGeneral", SqlDbType.Char), _
                                                                    New SqlParameter("@TelDirect", SqlDbType.Char), _
                                                                    New SqlParameter("@Country", SqlDbType.Char), _
                                                                    New SqlParameter("@City", SqlDbType.Char), _
                                                                    New SqlParameter("@PostCode", SqlDbType.Char), _
                                                                    New SqlParameter("@Website", SqlDbType.Char)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.ClientId
            parameters(2).Value = info.FirstNameCN
            parameters(3).Value = info.FirstNameEN
            parameters(4).Value = info.LastNameCN
            parameters(5).Value = info.LastNameEN
            parameters(6).Value = info.CompanyAddressCN
            parameters(7).Value = info.CompanyAddressEN
            parameters(8).Value = info.JobTitle
            parameters(9).Value = info.Department
            parameters(10).Value = info.Email
            parameters(11).Value = info.MobilePhone
            parameters(12).Value = info.TelGeneral
            parameters(13).Value = info.TelDirect
            parameters(14).Value = info.Country
            parameters(15).Value = info.City
            parameters(16).Value = info.PostCode
            parameters(17).Value = info.Website

            Return parameters
        End Function


        Public Function AddClientDetailInfo(ByVal Info As Model.Client_ClientDetailInfo) As Integer Implements IDAL.IClient_ClientDetailInfo.AddClientDetailInfo
            Try

                Dim strSql As String

                strSql = "Insert into t_Client_ClientDetailInfo(ClientId,FirstNameCN,FirstNameEN,LastNameCN,LastNameEN,CompanyAddressCN,"
                strSql += " CompanyAddressEN,JobTitle,Department,Email,MobilePhone,TelGeneral,TelDirect,Country,City,PostCode,Website) Values("
                strSql += "'" + Info.ClientId.ToString + "',"
                strSql += "'" + Info.FirstNameCN.ToString + "',"
                strSql += "'" + Info.FirstNameEN.ToString + "',"
                strSql += "'" + Info.LastNameCN.ToString + "',"
                strSql += "'" + Info.LastNameEN.ToString + "',"
                strSql += "'" + Info.CompanyAddressCN.ToString + "',"
                strSql += "'" + Info.CompanyAddressEN.ToString + "',"
                strSql += "'" + Info.JobTitle.ToString + "',"
                strSql += "'" + Info.Department.ToString + "',"
                strSql += "'" + Info.Email.ToString + "',"
                strSql += "'" + Info.MobilePhone.ToString + "',"
                strSql += "'" + Info.TelGeneral.ToString + "',"
                strSql += "'" + Info.TelDirect.ToString + "',"
                strSql += "'" + Info.Country.ToString + "',"
                strSql += "'" + Info.City.ToString + "',"
                strSql += "'" + Info.PostCode.ToString + "',"
                strSql += "'" + Info.Website.ToString + "')"
                strSql += " Select Id =@@Identity"

                Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(CommandType.Text, strSql)
                If dr.Read Then
                    Info.Id = Convert.ToInt32(dr("Id"))
                    dr.Close()
                    dr = Nothing

                    Return Info.Id
                Else
                    Return 0
                End If
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function

        Public Function UpdateClientDetailInfo(ByVal Info As Model.Client_ClientDetailInfo) As Boolean Implements IDAL.IClient_ClientDetailInfo.UpdateClientDetailInfo
            Dim strSql As String

            strSql = " Update t_Client_ClientDetailInfo set "
            strSql += "ClientId='" + Info.ClientId.ToString + "'"
            strSql += ",CompanyAddress='" + Info.FirstNameCN.ToString + "'"
            strSql += ",IsWPPClient='" + Info.FirstNameEN.ToString + "'"
            strSql += ",StuffNumber='" + Info.LastNameCN.ToString + "'"
            strSql += ",BusinessActive='" + Info.LastNameEN.ToString + "'"
            strSql += ",ContactName='" + Info.CompanyAddressEN.ToString + "'"
            strSql += ",ContactInformation='" + Info.CompanyAddressCN.ToString + "'"
            strSql += ",LastYearTurnover='" + Info.JobTitle.ToString + "'"
            strSql += ",ConflictCheck='" + Info.Department.ToString + "'"
            strSql += ",CreditLimit='" + Info.Country.ToString + "'"
            strSql += ",Applicant='" + Info.City.ToString + "'"
            strSql += ",ApplicantDate='" + Info.Email.ToString + "'"
            strSql += ",ApproveStatus='" + Info.TelDirect.ToString + "'"
            strSql += ",ApproveStatus='" + Info.TelGeneral.ToString + "'"
            strSql += ",ApproveStatus='" + Info.MobilePhone.ToString + "'"
            strSql += ",ApproveStatus='" + Info.PostCode.ToString + "'"
            strSql += " Where ClientId ='" + Info.Website.ToString + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function



        Public Function GetClientDetailInfo() As System.Data.DataSet Implements IDAL.IClient_ClientDetailInfo.GetClientDetailInfo
            Dim sql As String = "select * from [t_Client_ClientDetailInfo] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetClientDetailInfoByClientId(ByVal ClientId As Integer) As System.Data.DataSet Implements IDAL.IClient_ClientDetailInfo.GetClientDetailInfoByClientId
            Dim paramClientId As New SqlParameter("@ClientId", SqlDbType.Char)
            paramClientId.Value = ClientId
            Dim sql As String = "select * from [t_Client_ClientDetailInfo] where ClientId = @ClientId "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramClientId)

            Return ds
        End Function

        Public Function DeleteClientDetailInfo(ByVal Id As Integer) As Boolean Implements IDAL.IClient_ClientDetailInfo.DeleteClientDetailInfo
            Dim strSql As String

            strSql = " Delete From t_Client_ClientDetailInfo "
            strSql += " Where id ='" + CStr(Id) + "'"

            Try

                ExecuteNonQuery(CommandType.Text, strSql)
                Return True
            Catch ex As Exception
                Dim str As String = ex.Message
                Return False

            Finally
            End Try
        End Function
    End Class


End Namespace
