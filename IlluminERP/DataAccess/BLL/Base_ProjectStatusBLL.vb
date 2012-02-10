Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_ProjectStatusBLL
        Private factory As New DALFactory
        Private ProjectStatusDAL As IBase_ProjectStatus = factory.GetProduct("Base_ProjectStatusDAO")

        Public Sub New()

        End Sub

        Public Function GetProjectStatusInfo() As DataSet
            Return ProjectStatusDAL.GetProjectStatusInfo
        End Function

        Function GetProjectStatusInfoById(ByVal ID As Integer) As Base_ProjectStatus
            Return ProjectStatusDAL.GetProjectStatusInfoById(ID)
        End Function

        Function GetProjectOngoingStatusInfo() As DataSet
            Return ProjectStatusDAL.GetProjectOngoingStatusInfo
        End Function
    End Class
End Namespace
