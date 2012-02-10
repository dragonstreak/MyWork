Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL

    Public Class PMS_ProDesignRecruitmentBLL

        Private factory As New DALFactory
        Private ProDesignRecruitmentDAL As IPMS_ProDesignRecruitment = factory.GetProduct("PMS_ProDesignRecruitmentDAO")

        Public Sub New()

        End Sub

        Public Function GetProDesignRecruitmentById(ByVal Id As Integer) As Model.PMS_ProDesignRecruitment
            Return ProDesignRecruitmentDAL.GetProDesignRecruitmentById(Id)
        End Function

        Public Function GetProDesignRecruitmentBySubProId(ByVal SubProId As Integer) As DataSet
            Return ProDesignRecruitmentDAL.GetProDesignRecruitmentBySubProId(SubProId)
        End Function

        Public Function AddProDesignRecruitment(ByVal Info As Model.PMS_ProDesignRecruitment) As Integer
            Return ProDesignRecruitmentDAL.AddProDesignRecruitment(Info)
        End Function

        Public Function DeleteProDesignRecruitment(ByVal Info As Model.PMS_ProDesignRecruitment) As Integer
            Return ProDesignRecruitmentDAL.DeleteProDesignRecruitment(Info)
        End Function

        Public Function UpdateRecruitmentDescription(ByVal info As Model.PMS_ProDesignRecruitment) As Integer
            Return ProDesignRecruitmentDAL.UpdateRecruitmentDescription(info)
        End Function
    End Class
End Namespace
