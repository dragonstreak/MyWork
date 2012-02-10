
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_SectorBLL
        Private factory As New DALFactory
        Private SectorDAL As IBase_Sector = factory.GetProduct("Base_SectorDAO")

        Public Sub New()

        End Sub

        Public Function GetSectorInfo() As DataSet
            Return SectorDAL.GetSectorInfo()
        End Function

        Public Function GetSectorInfoByID(ByVal Id As Integer) As Model.Base_Sector
            Return SectorDAL.GetSectorInfoByID(Id)
        End Function

        Public Function GetSectorInfoByBusinessUnitId(ByVal BUID As Integer) As DataSet
            Return SectorDAL.GetSectorInfoByBusinessUnitId(BUID)
        End Function
    End Class
End Namespace
