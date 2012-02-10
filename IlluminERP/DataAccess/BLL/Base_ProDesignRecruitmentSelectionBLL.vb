

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL
    Public Class Base_ProDesignRecruitmentSelectionBLL
        Private factory As New DALFactory
        Private RecruitmentSelectionDAL As IBase_ProDesignRecruitmentSelection = factory.GetProduct("Base_ProDesignRecruitmentSelectionDAO")

        Public Sub New()

        End Sub

        Public Function GetRecruitmentSelectionInfoByRecruitmentId(ByVal RecruitmentId As Integer) As DataSet
            Return RecruitmentSelectionDAL.GetRecruitmentSelectionInfoByRecruitmentId(RecruitmentId)
        End Function

        Public Function GetRecruitmentSelectionInfoByID(ByVal ID As Integer) As Base_ProDesignRecruitmentSelection
            Return RecruitmentSelectionDAL.GetRecruitmentSelectionInfoByID(ID)
        End Function

    End Class
End Namespace
