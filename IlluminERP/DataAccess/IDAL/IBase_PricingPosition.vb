Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_PricingPosition
        Function GetPricingPositionByDepId(ByVal DepId As Integer) As DataSet

        Function GetPricingPositionById(ByVal ID As Integer) As Base_PricingPosition
    End Interface
End Namespace
