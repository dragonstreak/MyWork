
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class Base_ProDesignCriteriaSelectionBLL
        Private factory As New DALFactory
        Private CriteriaSelectionBLLDAL As IBase_ProDesignCriteriaSelection = factory.GetProduct("Base_ProDesignCriteriaSelectionDAO")

        Public Sub New()

        End Sub

        Public Function GetCriteriaSelectionInfoByCriteriaId(ByVal CriteriaId As Integer) As DataSet
            Return CriteriaSelectionBLLDAL.GetCriteriaSelectionInfoByCriteriaId(CriteriaId)
        End Function

        Public Function GetCriteriaSelectionInfoByID(ByVal ID As Integer) As Base_ProDesignCriteriaSelection
            Return CriteriaSelectionBLLDAL.GetCriteriaSelectionInfoByID(ID)
        End Function
    End Class
End Namespace
