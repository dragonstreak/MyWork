
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL


Public Class PMS_PricingSubContractBLL
        Private factory As New DALFactory
        Private PricingSubContractDAL As IPMS_PricingSubContract = factory.GetProduct("PMS_PricingSubContractDAO")

        Public Sub New()

        End Sub

        Public Function GetPricingSubContractById(ByVal Id As Integer) As PMS_PricingSubContract
            Return PricingSubContractDAL.GetPricingSubContractById(Id)
        End Function

        Public Function GetPricingSubContractBySubProid(ByVal SubProid As Integer) As DataSet
            Return PricingSubContractDAL.GetPricingSubContractBySubProid(SubProid)
        End Function

        Public Function GetPricingSubContractBySubProidDepId(ByVal SubProid As Integer, ByVal DepId As Integer) As DataSet
            Return PricingSubContractDAL.GetPricingSubContractBySubProidDepId(SubProid, DepId)
        End Function

        Public Function AddPricingSubContract(ByVal info As Model.PMS_PricingSubContract) As Integer
            Return PricingSubContractDAL.AddPricingSubContract(info)
        End Function

        Public Function DeletePricingSubContract(ByVal Id As Integer) As Boolean
            Return PricingSubContractDAL.DeletePricingSubContract(Id)
        End Function

        Public Function GetSumTotalCostByProId(ByVal ProId As Integer) As DataSet
            Return PricingSubContractDAL.GetSumTotalCostByProId(ProId)
        End Function
    End Class

End Namespace
