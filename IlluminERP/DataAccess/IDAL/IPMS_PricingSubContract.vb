
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL

    Friend Interface IPMS_PricingSubContract

        Function GetPricingSubContractById(ByVal Id As Integer) As PMS_PricingSubContract

        Function GetPricingSubContractBySubProid(ByVal SubProid As Integer) As DataSet

        Function GetPricingSubContractBySubProidDepId(ByVal SubProid As Integer, ByVal DepId As Integer) As DataSet

        Function AddPricingSubContract(ByVal info As Model.PMS_PricingSubContract) As Integer

        Function DeletePricingSubContract(ByVal Id As Integer) As Boolean

        Function GetSumTotalCostByProId(ByVal ProId As Integer) As DataSet

    End Interface
End Namespace
