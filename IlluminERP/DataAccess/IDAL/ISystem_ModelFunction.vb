Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface ISystem_ModelFunction

        Function GetModelFunctionById(ByVal Id As Integer) As System_ModelFunction

        Function GetModelFunctionByModelId(ByVal ModelId As Integer) As DataSet

        Function AddModelFunction(ByVal Info As System_ModelFunction) As Boolean

        Function DeleteModelFunctionbyId(ByVal Id As String) As Boolean





    End Interface
End Namespace
