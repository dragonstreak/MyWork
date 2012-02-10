
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

Public Class Base_PricingPositionBLL
        Private factory As New DALFactory
        Private PricingPositionDal As IBase_PricingPosition = factory.GetProduct("Base_PricingPositionDAO")

        Public Sub New()

        End Sub

        Public Function GetPricingPositionByDepId(ByVal DepId As Integer) As DataSet
            Return PricingPositionDal.GetPricingPositionByDepId(DepId)
        End Function

        Public Function GetPricingPositionById(ByVal ID As Integer) As Base_PricingPosition
            Return PricingPositionDal.GetPricingPositionById(ID)
        End Function

    End Class
End Namespace
