
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IPMS_ProDesignRecruitment
        Function GetProDesignRecruitmentById(ByVal Id As Integer) As Model.PMS_ProDesignRecruitment

        Function GetProDesignRecruitmentBySubProId(ByVal SubProId As Integer) As DataSet

        Function AddProDesignRecruitment(ByVal Info As Model.PMS_ProDesignRecruitment) As Integer

        Function DeleteProDesignRecruitment(ByVal Info As Model.PMS_ProDesignRecruitment) As Integer

        Function UpdateRecruitmentDescription(ByVal info As Model.PMS_ProDesignRecruitment) As Integer

    End Interface
End Namespace

