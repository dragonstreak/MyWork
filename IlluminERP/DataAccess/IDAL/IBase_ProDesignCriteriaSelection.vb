Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_ProDesignCriteriaSelection
        Function GetCriteriaSelectionInfoByCriteriaId(ByVal CriteriaId As Integer) As DataSet

        Function GetCriteriaSelectionInfoByID(ByVal ID As Integer) As Base_ProDesignCriteriaSelection

    End Interface
End Namespace
