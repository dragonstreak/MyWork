

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
Public Class Base_PricingProjectStageBLL
        Private factory As New DALFactory
        Private PricingStageDal As IBase_PricingProjectStage = factory.GetProduct("Base_PricingProjectStageDAO")

        Public Sub New()

        End Sub

        Public Function GetPricingStageByDepId(ByVal DepId As Integer) As DataSet
            Return PricingStageDal.GetPricingStageByDepId(DepId)
        End Function

        Public Function GetPricingStageById(ByVal ID As Integer) As Base_PricingProjectStage
            Return PricingStageDal.GetPricingStageById(ID)
        End Function
    End Class
End Namespace
