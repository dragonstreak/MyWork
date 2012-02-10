Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_SubContractInfoBLL
        Private factory As New DALFactory
        Private SubContractInfoDAL As IBase_SubContractInfo = factory.GetProduct("Base_SubContractInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetSubContractInfoById(ByVal Id As Integer) As Base_SubContractInfo
            Return SubContractInfoDAL.GetSubContractInfoById(Id)
        End Function

        Public Function GetSubContractbyCity(ByVal City As String) As DataSet
            Return SubContractInfoDAL.GetSubContractbyCity(City)
        End Function

        Public Function GetSubContractCity() As DataSet
            Return SubContractInfoDAL.GetSubContractCity
        End Function

    End Class
End Namespace
