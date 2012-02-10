
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IPMS_ProDesginCriteria

        Function GetProDesignCriteriaById(ByVal Id As Integer) As Model.PMS_ProDesginCriteria

        Function GetProDesignCriteriaBySubProId(ByVal SubProId As Integer) As DataSet

        Function AddProDesignCriteria(ByVal Info As Model.PMS_ProDesginCriteria) As Integer

        Function DeleteProDesignCriteria(ByVal Info As Model.PMS_ProDesginCriteria) As Integer

    End Interface
End Namespace
