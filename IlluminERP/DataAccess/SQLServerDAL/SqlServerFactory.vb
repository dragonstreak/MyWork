Imports System
Imports DataAccess.IDAL
Imports System.Web
Imports System.Configuration



Namespace SQLServerDAL

    Friend Class SqlServerFactory
        Implements DataAccess.IDAL.IFactory

        Private _connectionString As String

        Private _transState As TransactionState

        Private _transaction As System.Data.SqlClient.SqlTransaction


        Public Sub New()

            _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("CONN_DB_TNSERP").ConnectionString

            _transaction = Nothing

        End Sub


        Friend Function GetConnection() As String
            Return _connectionString
        End Function


        Friend Function GetTransaction() As System.Data.SqlClient.SqlTransaction
            Return _transaction
        End Function


        Public Function GetProduct(ByVal className As String) As DataAccess.IDAL.IDAO Implements IDAL.IFactory.GetProduct
            If className = "UserInfoDAO" Then
                Return New UserInfoDAO(Me)
            ElseIf className = "System_ModelDAO" Then
                Return New System_ModelDAO(Me)
            ElseIf className = "Base_DepartmentDAO" Then
                Return New Base_DepartmentDAO(Me)
            ElseIf className = "Base_CityInfoDAO" Then
                Return New Base_CityInfoDAO(Me)
            ElseIf className = "Base_PositionInfoDAO" Then
                Return New Base_PositionInfoDAO(Me)
            ElseIf className = "User_TeamInfoDAO" Then
                Return New User_TeamInfoDAO(Me)
            ElseIf className = "User_UserTeamDAO" Then
                Return New User_UserTeamDAO(Me)
            ElseIf className = "Base_SectorDAO" Then
                Return New Base_SectorDAO(Me)
            ElseIf className = "Base_AOEDAO" Then
                Return New Base_AOEDAO(Me)
            ElseIf className = "Base_ProductCategoryDAO" Then
                Return New Base_ProductCategoryDAO(Me)
            ElseIf className = "Base_ProjectTypeDAO" Then
                Return New Base_ProjectTypeDAO(Me)
            ElseIf className = "PMS_ProposalUserTypeDAO" Then
                Return New PMS_ProposalUserTypeDAO(Me)
            ElseIf className = "Client_ClientInfoDAO" Then
                Return New Client_ClientInfoDAO(Me)
            ElseIf className = "Base_BusinessSolutionDAO" Then
                Return New Base_BusinessSolutionDAO(Me)
            ElseIf className = "PMS_ProposalInfoDAO" Then
                Return New PMS_ProposalInfoDAO(Me)
            ElseIf className = "User_TeamInfoDAO" Then
                Return New User_TeamInfoDAO(Me)
            ElseIf className = "User_RoleDAO" Then
                Return New User_RoleDAO(Me)
            ElseIf className = "User_UserGroupDAO" Then
                Return New User_UserGroupDAO(Me)
            ElseIf className = "User_TeamGroupDAO" Then
                Return New User_TeamGroupDAO(Me)
            ElseIf className = "User_GroupRoleDAO" Then
                Return New User_GroupRoleDAO(Me)
            ElseIf className = "User_UserRoleDAO" Then
                Return New User_UserRoleDAO(Me)
            ElseIf className = "User_GroupDAO" Then
                Return New User_GroupDAO(Me)
            ElseIf className = "System_ModelFunctionDAO" Then
                Return New System_ModelFunctionDAO(Me)
            ElseIf className = "User_RoleModelFunctionDAO" Then
                Return New User_RoleModelFunctionDAO(Me)
            ElseIf className = "Base_ClientUploadFileTypeDAO" Then
                Return New Base_ClientUploadFileTypeDAO(Me)
            ElseIf className = "Base_ClientInfoWayTypeDAO" Then
                Return New Base_ClientInfoWayTypeDAO(Me)
            ElseIf className = "Client_ClientDetailInfoDAO" Then
                Return New Client_ClientDetailInfoDAO(Me)
            ElseIf className = "Client_ClientUploadFileDAO" Then
                Return New Client_ClientUploadFileDAO(Me)
            ElseIf className = "Client_ClientInfoGetWayDAO" Then
                Return New Client_ClientInfoGetWayDAO(Me)
            ElseIf className = "Base_ProjectStatusDAO" Then
                Return New Base_ProjectStatusDAO(Me)
            ElseIf className = "Base_DigitalProductsDAO" Then
                Return New Base_DigitalProductsDAO(Me)
            ElseIf className = "PMS_ProposalUserInfoDAO" Then
                Return New PMS_ProposalUserInfoDAO(Me)
            ElseIf className = "Base_MethodologyInfoDAO" Then
                Return New Base_MethodologyInfoDAO(Me)
            ElseIf className = "PMS_SubProjectInfoDAO" Then
                Return New PMS_SubProjectInfoDAO(Me)
            ElseIf className = "PMS_PricingCityInfoDAO" Then
                Return New PMS_PricingCityInfoDAO(Me)
            ElseIf className = "PMS_PricingSampleCityInfoDAO" Then
                Return New PMS_PricingSampleCityInfoDAO(Me)
            ElseIf className = "PMS_SubProjectSampleSizeDAO" Then
                Return New PMS_SubProjectSampleSizeDAO(Me)
            ElseIf className = "Base_ProDesignRecruitmentSelectionDAO" Then
                Return New Base_ProDesignRecruitmentSelectionDAO(Me)
            ElseIf className = "Base_ProDesignCriteriaSelectionDAO" Then
                Return New Base_ProDesignCriteriaSelectionDAO(Me)
            ElseIf className = "PMS_ProDesginCriteriaDAO" Then
                Return New PMS_ProDesginCriteriaDAO(Me)
            ElseIf className = "PMS_ProDesignRecruitmentDAO" Then
                Return New PMS_ProDesignRecruitmentDAO(Me)
            ElseIf className = "Base_DepMapCostCategoryDAO" Then
                Return New Base_DepMapCostCategoryDAO(Me)
            ElseIf className = "PMS_PricingDirectCostInfoDAO" Then
                Return New PMS_PricingDirectCostInfoDAO(Me)
            ElseIf className = "Base_CostCategoryDAO" Then
                Return New Base_CostCategoryDAO(Me)
            ElseIf className = "Base_PricingProjectStageDAO" Then
                Return New Base_PricingProjectStageDAO(Me)
            ElseIf className = "Base_PricingPositionDAO" Then
                Return New Base_PricingPositionDAO(Me)
            ElseIf className = "PMS_PricingTimeCostDAO" Then
                Return New PMS_PricingTimeCostDAO(Me)
            ElseIf className = "PMS_PricingSubContractDAO" Then
                Return New PMS_PricingSubContractDAO(Me)
            ElseIf className = "Base_SubContractInfoDAO" Then
                Return New Base_SubContractInfoDAO(Me)
            ElseIf className = "PMS_RevenueDAO" Then
                Return New PMS_RevenueDAO(Me)
            ElseIf className = "Base_MBPQuestionDAO" Then
                Return New Base_MBPQuestionDAO(Me)
            ElseIf className = "Base_MBPAnswerDAO" Then
                Return New Base_MBPAnswerDAO(Me)
            ElseIf className = "System_PermissionDAO" Then
                Return New System_PermissionDAO(Me)
            ElseIf className = "System_NewsDAO" Then
                Return New System_NewsDAO(Me)
            ElseIf className = "Base_ListItemDAO" Then
                Return New Base_ListItemDAO(Me)
            ElseIf className = "System_UploadFileDAO" Then
                Return New System_UploadFileDAO(Me)
            ElseIf className = "User_AppointmentsDAO" Then
                Return New User_AppointmentsDAO(Me)
            ElseIf className = "Base_StudyTypeDAO" Then
                Return New Base_StudyTypeDAO(Me)
            ElseIf className = "Base_BusinessUnitDAO" Then
                Return New Base_BusinessUnitDAO(Me)
            ElseIf className = "PMS_ProRelationInfoDAO" Then
                Return New PMS_ProRelationInfoDAO(Me)
            ElseIf className = "PMS_ProposalRatingDAO" Then
                Return New PMS_ProposalRatingDAO(Me)
            ElseIf className = "Base_ProposalRatingDAO" Then
                Return New Base_ProposalRatingDAO(Me)
            ElseIf className = "PMS_ProjectContractInfoDAO" Then
                Return New PMS_ProjectContractInfoDAO(Me)
            ElseIf className = "PMS_ProjectContractFileInfoDAO" Then
                Return New PMS_ProjectContractFileInfoDAO(Me)
            ElseIf className = "PMS_UploadFileTypeDAO" Then
                Return New PMS_UploadFileTypeDAO(Me)
            ElseIf className = "PMS_UploadFileInfoDAO" Then
                Return New PMS_UploadFileInfoDAO(Me)
                'ElseIf className = "PMS_UploadFileTypeDAO" Then
                ' Return New PMS_UploadFileTypeDAO(Me)
                'ElseIf className = "Base_DepMapCostCategoryDAO" Then
                '    Return New Base_DepMapCostCategoryDAO(Me)
            Else
                System.Diagnostics.Debug.Assert(False, "Unknown product [" + className + "] cannot be constracted", "Factory cannot construct product named [" + className + "]. please check your code " + ControlChars.Lf + "Maybe incorrect product name is typed")
            End If
            Return Nothing
        End Function


        Public Sub BeginTransaction() Implements IDAL.IFactory.BeginTransaction
            Dim conn As New System.Data.SqlClient.SqlConnection(_connectionString)
            conn.Open()

            _transaction = conn.BeginTransaction()
            _transState = TransactionState.Required
        End Sub


        Public Sub Commit() Implements IDAL.IFactory.Commit
            System.Diagnostics.Debug.Assert(Not (_transaction Is Nothing), "The variable _transaction is NULL!!")
            Dim conn As System.Data.SqlClient.SqlConnection = _transaction.Connection
            System.Diagnostics.Debug.Assert(Not (conn Is Nothing), "The property _transaction.Connection is NULL!!")

            Try
                _transaction.Commit()
            Catch ex As Exception
                Dim str As String = ex.Message

            End Try

            conn.Close()
            _transState = TransactionState.None
        End Sub


        Public Sub Rollback() Implements IDAL.IFactory.Rollback
            System.Diagnostics.Debug.Assert(Not (_transaction Is Nothing), "The variable _transaction is NULL!!")
            Dim conn As System.Data.SqlClient.SqlConnection = _transaction.Connection
            System.Diagnostics.Debug.Assert(Not (conn Is Nothing), "The property _transaction.Connection is NULL!!")

            Try
                _transaction.Rollback()
            Catch
            End Try

            conn.Close()
            _transState = TransactionState.None
        End Sub


        Public ReadOnly Property TransState() As TransactionState Implements IDAL.IFactory.TransState
            Get
                Return _transState
            End Get
        End Property

    End Class
End Namespace
