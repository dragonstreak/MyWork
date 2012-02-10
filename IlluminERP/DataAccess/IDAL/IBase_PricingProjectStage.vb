Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_PricingProjectStage
        Function GetPricingStageByDepId(ByVal DepId As Integer) As DataSet

        Function GetPricingStageById(ByVal ID As Integer) As Base_PricingProjectStage
    End Interface
End Namespace
