Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_busiessUnitBLL
        Private factory As New DALFactory
        Private BusinessUnitDAL As IBase_BusinessUnit = factory.GetProduct("Base_BusinessUnitDAO")

        Public Sub New()

        End Sub

        Public Function GetBusinessUnitInfo() As DataSet
            Return BusinessUnitDAL.GetBusinessUnitInfo()
        End Function

        Public Function GetBusinessUnitInfoByID(ByVal Id As Integer) As Model.Base_BusinessUnit

            Return BusinessUnitDAL.GetBusinessUnitInfoByID(Id)
        End Function
    End Class
End Namespace

