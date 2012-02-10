
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL


Public Class PMS_PricingTimeCostBLL
        Private factory As New DALFactory
        Private PricingTimeCostDAL As IPMS_PricingTimeCost = factory.GetProduct("PMS_PricingTimeCostDAO")

        Public Sub New()

        End Sub


        Public Function GetPricingTimeCostById(ByVal Id As Integer) As PMS_PricingTimeCost
            Return PricingTimeCostDAL.GetPricingTimeCostById(Id)
        End Function

        Public Function GetPricingTimeCostBySubProidCityIdDepId(ByVal SubProid As Integer, ByVal CityId As Integer, ByVal DepId As Integer) As DataSet
            Return PricingTimeCostDAL.GetPricingTimeCostBySubProidCityIdDepId(SubProid, CityId, DepId)

        End Function


        Public Function AddPricingTimeCost(ByVal Info As PMS_PricingTimeCost) As Integer
            Return PricingTimeCostDAL.AddPricingTimeCost(Info)
        End Function

        Public Function DelPricingTimeCost(ByVal info As PMS_PricingTimeCost) As Boolean
            Return PricingTimeCostDAL.DelPricingTimeCost(info)
        End Function

        Public Function ModifyPricingTimeCost(ByVal info As PMS_PricingTimeCost) As Boolean
            Return PricingTimeCostDAL.ModifyPricingTimeCost(info)
        End Function

        Public Function GetPricingTimeCostBySubProidCityIdDepIdStageId(ByVal SubProid As Integer, ByVal CityId As Integer, ByVal DepId As Integer, ByVal StageId As Integer, ByVal PositionId As Integer) As DataSet
            Return PricingTimeCostDAL.GetPricingTimeCostBySubProidCityIdDepIdStageId(SubProid, CityId, DepId, StageId, PositionId)
        End Function

        Public Function IsExistRecord(ByVal Info As PMS_PricingTimeCost) As Boolean
            Return PricingTimeCostDAL.IsExistRecord(Info)
        End Function

        Public Function GetSumTotalCostByProId(ByVal ProId As Integer) As DataSet
            Return PricingTimeCostDAL.GetSumTotalCostByProId(ProId)
        End Function

    End Class
End Namespace
