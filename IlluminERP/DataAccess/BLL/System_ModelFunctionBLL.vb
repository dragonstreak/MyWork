Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class System_ModelFunctionBLL

        Private factory As New DALFactory
        Private ModelFunctionDAL As ISystem_ModelFunction = factory.GetProduct("System_ModelFunctionDAO")


        Public Sub New()

        End Sub

        Public Function GetModelFunctionById(ByVal Id As Integer) As System_ModelFunction
            Return ModelFunctionDAL.GetModelFunctionById(Id)
        End Function

        Function GetModelFunctionByModelId(ByVal ModelId As Integer) As DataSet
            Return ModelFunctionDAL.GetModelFunctionByModelId(ModelId)
        End Function

        Public Function AddModelFunction(ByVal Info As System_ModelFunction) As Boolean
            Return ModelFunctionDAL.AddModelFunction(Info)
        End Function

        Public Function DeleteModelFunctionbyId(ByVal Id As String) As Boolean
            Return ModelFunctionDAL.DeleteModelFunctionbyId(Id)
        End Function

    End Class
End Namespace

