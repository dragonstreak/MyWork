Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_BusinessSolutionBLL
        Private factory As New DALFactory
        Private BSDAL As IBase_BusinessSolution = factory.GetProduct("Base_BusinessSolutionDAO")

        Public Sub New()

        End Sub

        Public Function GetBSInfo() As DataSet
            Return BSDAL.GetBSInfo()
        End Function

        Public Function GetBSByID(ByVal Id As Integer) As Model.Base_BusinessSolution
            Return BSDAL.GetBSByID(Id)
        End Function

    End Class
End Namespace

