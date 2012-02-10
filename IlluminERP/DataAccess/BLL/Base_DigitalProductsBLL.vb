

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL


    Public Class Base_DigitalProductsBLL
        Private factory As New DALFactory
        Private DPBLL As IBase_DigitalProducts = factory.GetProduct("Base_DigitalProductsDAO")

        Public Sub New()

        End Sub

        Public Function GetDigitalProductsInfo() As DataSet
            Return DPBLL.GetDigitalProductsInfo()
        End Function

        Public Function GetDigitalProductsInfoByID(ByVal Id As Integer) As Model.Base_DigitalProducts
            Return DPBLL.GetDigitalProductsInfoByID(Id)
        End Function

    End Class
End Namespace
