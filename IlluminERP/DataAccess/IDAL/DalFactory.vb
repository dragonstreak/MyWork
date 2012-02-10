Imports System


Namespace IDAL

    Friend Class DALFactory
        Implements IFactory

        Private innerFactory As IFactory

        Private cache As System.Collections.IDictionary

        Private DEFAULT_CACHE_CAPCITY As Integer = 10


        Public Sub New()
            innerFactory = New SQLServerDAL.SqlServerFactory
            System.Diagnostics.Debug.Assert(Not (innerFactory Is Nothing), "innerFactory is NULL!! please check your code above")

            cache = New System.Collections.Hashtable(DEFAULT_CACHE_CAPCITY)
        End Sub



        Public Function GetProduct(ByVal className As String) As IDAO Implements IFactory.GetProduct
            If cache.Contains(className) Then
                Return cache(className)
            Else
                Dim dao As IDAO = innerFactory.GetProduct(className)
                System.Diagnostics.Debug.Assert(Not (dao Is Nothing), "Cannot find Product[" + className + "]")

                cache.Add(className, dao)
                Return dao
            End If
        End Function


        Public Sub BeginTransaction() Implements IFactory.BeginTransaction
            innerFactory.BeginTransaction()
        End Sub

        Public Sub Commit() Implements IFactory.Commit
            innerFactory.Commit()
        End Sub


        Public Sub Rollback() Implements IFactory.Rollback
            innerFactory.Rollback()
        End Sub


        Public ReadOnly Property TransState() As TransactionState Implements IFactory.TransState
            Get
                Return innerFactory.TransState
            End Get
        End Property


        Friend Function GetUserInfo() As IUser_UserInfo
            Return GetProduct("UserInfoDAO")
        End Function

        Friend Function GetDepartMentInfo() As IBase_Department
            Return GetProduct("Base_DepartmentDAO")
        End Function


        Friend Function GetCityInfo() As IBase_CityInfo
            Return GetProduct("Base_CityInfoDAO")
        End Function

        Friend Function GetPositionInfo() As IBase_PositionInfo
            Return GetProduct("Base_PositionInfoDAO")
        End Function

        'Friend Function GetPaymentVoucher() As IPaymentVoucher
        '    Return GetProduct("PaymentVoucherDAO")
        'End Function

        'Friend Function GetPaymentApprove() As IPaymentApprove
        '    Return GetProduct("PaymentApproveDAO")
        'End Function

        'Friend Function GetPVSupporting() As IPVSupporting
        '    Return GetProduct("PVSupportingDAO")
        'End Function

        'Friend Function GetPVCostItem() As IPVCostItem
        '    Return GetProduct("PVCostItemDAO")
        'End Function

        'Friend Function GetCFRecord() As ICFRecord
        '    Return GetProduct("CFRecordDAO")
        'End Function

        'Friend Function GetClaimFormApprove() As IClaimFormApprove
        '    Return GetProduct("ClaimFormApproveDAO")
        'End Function

        'Friend Function GetCurrencyRate() As ICFCurrencyRate
        '    Return GetProduct("CFCurrencyRateDAO")
        'End Function

        'Friend Function GetCFGenerate() As ICFGenerate
        '    Return GetProduct("CFGenerateDAO")
        'End Function

        'Friend Function GetMessage() As IMessage
        '    Return GetProduct("MessageDAO")
        'End Function

        'Friend Function GetTravelRequest() As ITravelRequest
        '    Return GetProduct("TravelRequestDAO")
        'End Function

        'Friend Function GetFlightRecord() As IFlightRecord
        '    Return GetProduct("FlightRecordDAO")
        'End Function

        'Friend Function GetPurchaseOrder() As IPurchaseOrder
        '    Return GetProduct("PurchaseOrderDAO")
        'End Function

        'Friend Function GetPOItem() As IPOItem
        '    Return GetProduct("POItemDAO")
        'End Function

        'Friend Function GetPVPO() As IPVPO
        '    Return GetProduct("PVPODAO")
        'End Function

        'Friend Function GetPOSupplier() As IPOSupplier
        '    Return GetProduct("POSupplierDAO")
        'End Function


    End Class
End Namespace
