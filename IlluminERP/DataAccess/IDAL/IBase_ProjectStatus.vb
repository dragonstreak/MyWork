Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL

    Friend Interface IBase_ProjectStatus

        Function GetProjectStatusInfo() As DataSet

        Function GetProjectStatusInfoById(ByVal ID As Integer) As Base_ProjectStatus

        Function GetProjectOngoingStatusInfo() As DataSet
    End Interface
End Namespace
