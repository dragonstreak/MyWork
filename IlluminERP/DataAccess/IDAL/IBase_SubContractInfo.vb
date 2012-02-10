
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_SubContractInfo

        Function GetSubContractInfoById(ByVal id As Integer) As Base_SubContractInfo

        Function GetSubContractbyCity(ByVal City As String) As DataSet

        Function GetSubContractCity() As DataSet


    End Interface
   

End Namespace
