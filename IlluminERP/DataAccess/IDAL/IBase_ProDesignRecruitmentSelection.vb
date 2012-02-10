
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_ProDesignRecruitmentSelection

        Function GetRecruitmentSelectionInfoByRecruitmentId(ByVal RecruitmentId As Integer) As DataSet

        Function GetRecruitmentSelectionInfoByID(ByVal ID As Integer) As Base_ProDesignRecruitmentSelection



    End Interface
End Namespace
