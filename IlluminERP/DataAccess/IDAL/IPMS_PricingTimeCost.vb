
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL


    Friend Interface IPMS_PricingTimeCost

        Function GetPricingTimeCostById(ByVal Id As Integer) As PMS_PricingTimeCost

        Function GetPricingTimeCostBySubProidCityIdDepId(ByVal SubProid As Integer, ByVal CityId As Integer, ByVal DepId As Integer) As DataSet

        Function GetPricingTimeCostBySubProidCityIdDepIdStageId(ByVal SubProid As Integer, ByVal CityId As Integer, ByVal DepId As Integer, ByVal StageId As Integer, ByVal PositionId As Integer) As DataSet

        Function AddPricingTimeCost(ByVal Info As PMS_PricingTimeCost) As Integer

        Function DelPricingTimeCost(ByVal info As PMS_PricingTimeCost) As Boolean

        Function ModifyPricingTimeCost(ByVal info As PMS_PricingTimeCost) As Boolean

        Function IsExistRecord(ByVal Info As PMS_PricingTimeCost) As Boolean

        Function GetSumTotalCostByProId(ByVal ProId As Integer) As DataSet


    End Interface
End Namespace
