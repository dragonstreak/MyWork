

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Base_AOEBLL
        Private factory As New DALFactory
        Private AOEDAL As IBase_AOE = factory.GetProduct("Base_AOEDAO")

        Public Sub New()

        End Sub

        Public Function GetAOEInfo() As DataSet
            Return AOEDAL.GetAOEInfo()
        End Function

        Public Function GetAOEInfoByID(ByVal Id As Integer) As Model.Base_AOE
            Return AOEDAL.GetAOEInfoByID(Id)
        End Function

    End Class
End Namespace

