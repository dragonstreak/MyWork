Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IBase_DigitalProducts


        Function GetDigitalProductsInfo() As DataSet

        Function GetDigitalProductsInfoByID(ByVal ID As Integer) As Base_DigitalProducts


    End Interface
End Namespace
