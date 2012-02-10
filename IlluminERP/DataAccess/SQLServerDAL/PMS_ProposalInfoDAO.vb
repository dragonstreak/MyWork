
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components
Imports Utils

Namespace SQLServerDAL

    Friend Class PMS_ProposalInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IPMS_ProposalInfo





        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Public Function GetProposalInfoByID(ByVal ID As Integer) As Model.PMS_ProposalInfo Implements IDAL.IPMS_ProposalInfo.GetProposalInfoByID
            Dim paramId As New SqlParameter("@ID", SqlDbType.Char)
            paramId.Value = ID
            Dim sql As String = "select * from [t_PMS_Proposalinfo] where ID = @ID "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramId)
            Dim info As PMS_ProposalInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToProposalInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Public Function GetProposallistByStatus(ByVal Status As String) As System.Data.DataView Implements IDAL.IPMS_ProposalInfo.GetProposallistByStatus
            Dim paramStatus As New SqlParameter("@Status", SqlDbType.Char)
            paramStatus.Value = Status

            Dim sql As String = "select * from [t_PMS_Proposalinfo] where Status  = @Status  Order by JobNumber DESC"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramStatus)

            If Not ds.Tables(0) Is Nothing Then
                Return ds.Tables(0).DefaultView

            Else
                Return Nothing
            End If
        End Function

        Public Function UpdateProposalInfo(ByVal info As Model.PMS_ProposalInfo) As Boolean Implements IDAL.IPMS_ProposalInfo.UpdateProposalInfo
            Dim factory As New SqlServerFactory
            Dim strSql As String
            factory.BeginTransaction()

            Try
                strSql = " Update t_PMS_Proposalinfo set "
                strSql += "JobName='" + info.JobName.ToString + "'"
                strSql += ",BusinessUnitId='" + info.BusinessUnitId.ToString + "'"
                strSql += ",SectorId='" + info.SectorId.ToString + "'"
                strSql += ",ProductCategoryId='" + info.ProductCategoryId.ToString + "'"
                strSql += ",StudyTypeId='" + info.StudyTypeId.ToString + "'"
                strSql += ",ClientId='" + info.ClientId.ToString + "'"
                strSql += ",ProposalRating='" + info.ProposalRating.ToString + "'"
                strSql += ",Isconfidential='" + info.Isconfidential.ToString + "'"
                strSql += ",Probability='" + info.Probability.ToString + "'"
                strSql += ",Status='" + info.Status.ToString + "'"
                strSql += ",Description='" + info.Description.ToString + "'"
                strSql += ",KeyWords='" + info.KeyWords.ToString + "'"
                strSql += ",CreateDate='" + info.CreateDate.ToString + "'"
                strSql += " Where JobNumber ='" + info.JobNumber.ToString + "'"

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


        Public Function GetJobNumber(ByVal Info As Model.PMS_ProposalInfo) As String Implements IDAL.IPMS_ProposalInfo.GetJobNumber

            Dim factory As New SqlServerFactory
            Dim sectorDal As IBase_Sector = factory.GetProduct("Base_SectorDAO")
            Dim strSql As String
            Dim strMaxNumber As String
            Dim strId As String
            Dim strJobNumber As String
            Try
                strId = 0
                strJobNumber = String.Empty
                strMaxNumber = String.Empty
                strSql = "Select Max(id) as ID From t_PMS_Proposalinfo where len(jobnumber)=6 "
                Dim dataReader As SqlClient.SqlDataReader = Me.ExecuteReader(CommandType.Text, strSql)

                If dataReader.Read Then
                    If Utils.DataConvert.ConvertDataToInt32(dataReader("ID")) = 0 Then
                        strId = 0
                    Else
                        strId = dataReader("ID")
                    End If

                End If
                dataReader.Close()

                strSql = "Select JobNumber From t_PMS_Proposalinfo where id='" + strId + "'"
                dataReader = Me.ExecuteReader(CommandType.Text, strSql)

                If dataReader.Read Then

                    strMaxNumber = Mid(dataReader("JobNumber").ToString, 5, 4)

                Else
                    strMaxNumber = "0000"
                End If
                dataReader.Close()

                If Len(Right(Now.Date.Month, 2)) = 1 Then
                    strJobNumber = Right(Now.Date.Year, 2) & "0" & Right(Now.Date.Month, 2) & Format((CLng(Left(strMaxNumber, 2)) + 1), "00")
                Else
                    strJobNumber = Right(Now.Date.Year, 2) & Right(Now.Date.Month, 2) & Format((CLng(Left(strMaxNumber, 2)) + 1), "00")
                End If


                Return strJobNumber.ToString
            Catch ex As Exception
                Return Nothing
            End Try


        End Function

        Public Function AddProposalInfo(ByVal info As Model.PMS_ProposalInfo) As Integer Implements IDAL.IPMS_ProposalInfo.AddProposalInfo

            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_Proposalinfo (JobNumber,JobName,JobIndex,BusinessUnitId,SectorId,ProductCategoryId,StudyTypeId,ClientId,ProposalRating,IsConfidential,"
                strSql = strSql & " Probability,CreateDate,UploadFilePath,Description,keywords,Status) Values ("
                strSql += "'" + info.JobNumber.ToString + "',"
                strSql += "'" + info.JobName.ToString + "',"
                strSql += "'" + info.JobIndex.ToString + "',"
                strSql += "'" + info.BusinessUnitId.ToString + "',"
                strSql += "'" + info.SectorId.ToString + "',"
                strSql += "'" + info.ProductCategoryId.ToString + "',"
                strSql += "'" + info.StudyTypeId.ToString + "',"
                strSql += "'" + info.ClientId.ToString + "',"
                strSql += "'" + info.ProposalRating.ToString + "',"
                strSql += "'" + info.Isconfidential.ToString + "',"
                strSql += "'" + info.Probability.ToString + "',"
                strSql += "'" + info.CreateDate.ToString + "',"
                strSql += "'" + info.UploadFilePath.ToString + "',"
                strSql += "'" + info.Description.ToString + "',"
                strSql += "'" + info.KeyWords.ToString + "',"
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


        Public Function AddProposaladdonInfo(ByVal info As Model.PMS_ProposalInfo) As Integer Implements IDAL.IPMS_ProposalInfo.AddProposaladdonInfo

            Dim strSql As String

            Try


                strSql = "Insert into t_PMS_Proposalinfo (JobNumber,JobName,JobIndex,BusinessUnitId,SectorId,ProductCategoryId,StudyTypeId,ClientId,Proposalrating,"
                strSql = strSql & " Probability,CreateDate,UploadFilePath,Description,keywords,Status) Values ("
                strSql += "'" + info.JobNumber.ToString + "',"
                strSql += "'" + info.JobName.ToString + "',"
                strSql += "'" + info.JobIndex.ToString + "',"
                strSql += "'" + info.BusinessUnitId.ToString + "',"
                strSql += "'" + info.SectorId.ToString + "',"
                strSql += "'" + info.ProductCategoryId.ToString + "',"
                strSql += "'" + info.StudyTypeId.ToString + "',"
                strSql += "'" + info.ClientId.ToString + "',"
                strSql += "'" + info.ProposalRating.ToString + "',"
                strSql += "'" + info.Isconfidential.ToString + "',"
                strSql += "'" + info.Probability.ToString + "',"
                strSql += "'" + info.CreateDate.ToString + "',"
                strSql += "'" + info.UploadFilePath.ToString + "',"
                strSql += "'" + info.Description.ToString + "',"
                strSql += "'" + info.KeyWords.ToString + "',"
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



        Private Function MapRowToProposalInfo(ByVal dr As DataRow) As PMS_ProposalInfo
            Dim info As New PMS_ProposalInfo
            info.Id = Convert.ToInt32(dr("ID"))
            info.JobNumber = dr("JobNumber").ToString()
            info.JobName = dr("JobName").ToString()
            info.JobIndex = dr("JobIndex").ToString()


            If Not Convert.IsDBNull(dr("BusinessUnitId")) Then
                info.BusinessUnitId = Convert.ToInt32(dr("BusinessUnitId"))
            End If

            If Not Convert.IsDBNull(dr("SectorId")) Then
                info.SectorId = Convert.ToInt32(dr("SectorId"))
            End If


            If Not Convert.IsDBNull(dr("ProductCategoryId")) Then
                info.ProductCategoryId = Convert.ToInt32(dr("ProductCategoryId"))
            End If

            If Not Convert.IsDBNull(dr("StudyTypeId")) Then
                info.StudyTypeId = Convert.ToString(dr("StudyTypeId"))
            End If

            If Not Convert.IsDBNull(dr("ClientId")) Then
                info.ClientId = Convert.ToInt32(dr("ClientId"))
            End If

            If Not Convert.IsDBNull(dr("ProposalRating")) Then
                info.ProposalRating = Convert.ToInt32(dr("ProposalRating"))
            End If

            If Not Convert.IsDBNull(dr("Isconfidential")) Then
                info.Isconfidential = Convert.ToInt32(dr("Isconfidential"))
            End If

            If Not Convert.IsDBNull(dr("Probability")) Then
                info.Probability = Convert.ToDecimal(dr("Probability"))
            End If


            If Not Convert.IsDBNull(dr("CreateDate")) Then
                info.CreateDate = Convert.ToDateTime(dr("CreateDate"))
            End If

            If Not Convert.IsDBNull(dr("Status")) Then
                info.Status = Convert.ToInt32(dr("Status"))
            End If

            If Not Convert.IsDBNull(dr("StatusNote")) Then
                info.StatusNote = dr("StatusNote").ToString
            End If

            If Not Convert.IsDBNull(dr("StatusDate")) Then
                info.StatusDate = Convert.ToDateTime(dr("StatusDate"))
            End If



            If Not Convert.IsDBNull(dr("UploadFilePath")) Then
                info.UploadFilePath = dr("UploadFilePath").ToString()
            End If


            If Not Convert.IsDBNull(dr("Description")) Then
                info.Description = dr("Description").ToString()
            End If

            If Not Convert.IsDBNull(dr("KeyWords")) Then
                info.KeyWords = dr("KeyWords").ToString()
            End If

            Return info

        End Function

        Private Function GetParameters(ByVal info As PMS_ProposalInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@JobNumber", SqlDbType.Char), _
                                                                    New SqlParameter("@JobName", SqlDbType.Char), _
                                                                    New SqlParameter("@JobIndex", SqlDbType.Int), _
                                                                    New SqlParameter("@BusinessUnitId", SqlDbType.Int), _
                                                                    New SqlParameter("@SectorId", SqlDbType.Int), _
                                                                    New SqlParameter("@ProductCategoryId", SqlDbType.Int), _
                                                                    New SqlParameter("@StudyTypeId", SqlDbType.VarChar), _
                                                                    New SqlParameter("@ClientId", SqlDbType.Int), _
                                                                     New SqlParameter("@ProposalRating", SqlDbType.Int), _
                                                                    New SqlParameter("@Probability", SqlDbType.Decimal), _
                                                                    New SqlParameter("@CreateDate", SqlDbType.DateTime), _
                                                                    New SqlParameter("@status", SqlDbType.Int), _
                                                                    New SqlParameter("@UploadFilePath", SqlDbType.VarChar), _
                                                                    New SqlParameter("@KeyWords", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Description", SqlDbType.VarChar), _
                                                                    New SqlParameter("@Isconfidential", SqlDbType.Int)}
            parameters(0).Value = info.Id
            parameters(1).Value = info.JobNumber
            parameters(2).Value = info.JobName
            parameters(3).Value = info.JobIndex
            parameters(4).Value = info.BusinessUnitId
            parameters(5).Value = info.SectorId
            parameters(6).Value = info.ProductCategoryId
            parameters(7).Value = info.StudyTypeId
            parameters(12).Value = info.ClientId
            parameters(13).Value = info.ProposalRating
            parameters(18).Value = info.Probability
            parameters(19).Value = info.CreateDate
            parameters(20).Value = info.Status
            parameters(21).Value = info.UploadFilePath
            parameters(22).Value = info.KeyWords
            parameters(23).Value = info.Description
            parameters(24).Value = info.Isconfidential
            Return parameters
        End Function




        Public Function UpdateProjectStatus(ByVal Info As Model.PMS_ProposalInfo) As Boolean Implements IDAL.IPMS_ProposalInfo.UpdateProjectStatus
            Dim factory As New SqlServerFactory
            Dim strSql As String
            Dim strStatus As String
            factory.BeginTransaction()
            strStatus = Utils.ConstantsUtils.ProjectStatus.Proposal
            Try
                strSql = " Update t_PMS_Proposalinfo set "
                strSql += "Status='" + Info.Status.ToString + "',"
                strSql += "StatusNote='" + Info.StatusNote.ToString + "',"
                strSql += "Statusdate='" + Info.StatusDate.ToString + "'"
                strSql += " Where Id ='" + Info.Id.ToString + "'"

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
                Dim str = ex.Message
                factory.Rollback()
                Return False

            End Try
        End Function

        Public Function GetProposallistByQueryInfo(ByVal QueryInfo As Model.PMS_ProposalInfo) As System.Data.DataView Implements IDAL.IPMS_ProposalInfo.GetProposallistByQueryInfo

            Dim sSql As String = "SELECT * FROM [t_PMS_Proposalinfo] WHERE 1=1 "
            If Not String.IsNullOrEmpty(QueryInfo.JobNumber.Trim()) Then

                sSql = sSql & " AND CHARINDEX('" & QueryInfo.JobNumber & "',JobNumber)>0 "
            End If
            If Not String.IsNullOrEmpty(QueryInfo.JobName.Trim()) Then
                sSql = sSql & " AND CHARINDEX('" & QueryInfo.JobName & "',JobName)>0 "
            End If

            If Not String.IsNullOrEmpty(QueryInfo.KeyWords.Trim()) Then
                sSql = sSql & " AND Keywords like  %" & QueryInfo.KeyWords & "% "
            End If

            If QueryInfo.ProductCategoryId > 0 Then
                sSql = sSql & " AND ProductCategoryId in ( " & QueryInfo.ProductCategoryId.ToString() + ")"
            End If
            If QueryInfo.SectorId > 0 Then
                sSql = sSql & " AND SectorId = '" & QueryInfo.SectorId.ToString() + "' "
            End If

            If QueryInfo.BusinessUnitId > 0 Then
                sSql = sSql & " AND BusinessUnitId = '" & QueryInfo.BusinessUnitId.ToString() + "' "
            End If

            If QueryInfo.ProposalRating > 0 Then
                sSql = sSql & " AND ProposalRating = '" & QueryInfo.ProposalRating.ToString() + "' "
            End If

            If QueryInfo.Status > 0 Then
                sSql = sSql & " AND Status >= '" & QueryInfo.Status.ToString() + "' "
            End If

            If QueryInfo.ClientId > 0 Then
                sSql = sSql & " AND ClientId = '" & QueryInfo.ClientId.ToString() + "' "
            End If

            sSql = sSql & " Order by JobNumber"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sSql)

            If Not ds.Tables(0) Is Nothing Then
                Return ds.Tables(0).DefaultView

            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' This method is used to get proposal list by query filter.
        ''' </summary>
        ''' <param name="proposalQueryFilter">Pass the query filter.</param>
        ''' <returns>Return proposal list dataset.</returns>
        ''' <remarks></remarks>
        Public Function GetProposalList(ByVal proposalQueryFilter As ProposalQueryFilter) As DataSet Implements IDAL.IPMS_ProposalInfo.GetProposalList

            Dim strSql As String
            Dim proposalDataSet As DataSet = Nothing

            Try

                strSql = "select Proposalinfo.*,ClientInfo.* ,"
                strSql += "(select top 1 E_Name from t_PMS_ProposalUserInfo a,t_User_UserInfo b"
                strSql += " where a.UserId=b.ID and a.ProId=Proposalinfo.id and a.ProposalUSerTypeId=1)as ResearchName,"
                strSql += "(select top 1 E_Name from t_PMS_ProposalUserInfo a,t_User_UserInfo b"
                strSql += " where a.UserId=b.ID and a.ProId=Proposalinfo.id and a.ProposalUSerTypeId=2)as ManagerName,projectStatus.projectstatus"
                strSql += " from t_PMS_Proposalinfo Proposalinfo,t_Client_ClientInfo ClientInfo,t_base_ProjectStatus ProjectStatus"
                strSql += " where Proposalinfo.EndingClient = ClientInfo.Id and Proposalinfo.status = projectStatus.id"
                strSql += FilterManager.GetFilterCondition(Of ProposalQueryFilter)(proposalQueryFilter)
                Dim parameters() As SqlParameter = {
               New SqlParameter("@Status", proposalQueryFilter.ProjectStatus),
                New SqlParameter("@JobNumber", proposalQueryFilter.JobNumber),
               New SqlParameter("@JobName", proposalQueryFilter.JobName),
               New SqlParameter("@ClientName", proposalQueryFilter.ClientName)
             }
                proposalDataSet = Me.ExecuteDataSet(strSql, parameters)

                Return proposalDataSet
            Catch ex As Exception
                Return Nothing
            End Try
        End Function



        Public Function GetProRelationList(ByVal ProId As String) As System.Data.DataView Implements IDAL.IPMS_ProposalInfo.GetProRelationList

            Dim strSql As String

            Try
                strSql = "select Id ,JobNumber,JobName ,ClientId From t_PMS_ProposalInfo Where Id  in " & _
               " (select relationproid From t_PMS_ProRelationInfo where proid ='" + ProId.ToString + "')"

                Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, strSql)

                If Not ds.Tables(0) Is Nothing Then
                    Return ds.Tables(0).DefaultView

                Else
                    Return Nothing
                End If


            Catch ex As Exception
                Return Nothing
            End Try


        End Function

        Public Function GetProposallistByQueryString(ByVal QueryString As String) As System.Data.DataView Implements IDAL.IPMS_ProposalInfo.GetProposallistByQueryString
            Dim sSql As String = "SELECT * FROM [t_PMS_Proposalinfo] WHERE 1=1 "
            If Not String.IsNullOrEmpty(QueryString) _
               AndAlso Not QueryString.StartsWith("AND", StringComparison.OrdinalIgnoreCase) Then
                QueryString = "AND " + QueryString
            End If
            sSql = sSql & QueryString
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sSql)
            If Not ds.Tables(0) Is Nothing Then
                Return ds.Tables(0).DefaultView

            Else
                Return Nothing
            End If
        End Function

        Public Function GetMyProposallistByUserId(ByVal UserId As String) As System.Data.DataView Implements IDAL.IPMS_ProposalInfo.GetMyProposallistByUserId

            Dim sSql As String = "SELECT * FROM [t_PMS_Proposalinfo] WHERE id in (Select Proid From t_PMS_ProposalUserinfo where Userid ='" + UserId.ToString + "' )"

            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sSql)
            If Not ds.Tables(0) Is Nothing Then
                Return ds.Tables(0).DefaultView

            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace
