Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class System_ModelBLL

        Private factory As New DALFactory
        Private ModelDAL As ISystem_Model = factory.GetProduct("System_ModelDAO")


        Public Sub New()

        End Sub

        Public Function GetSystemMenuBylevel(ByVal intLevel As Integer) As DataSet
            Return ModelDAL.GetSystemMenuBylevel(intLevel)
        End Function

        Public Function GetMenuItemByParent(ByVal parentID As Integer) As DataSet
            Return ModelDAL.GetMenuItemByParent(parentID)
        End Function


        Public Function GetModelInfoById(ByVal Id As Integer) As System_Model
            Return ModelDAL.GetModelInfoById(Id)
        End Function

        Public Function GetModelInfo() As DataSet
            Return ModelDAL.GetModelInfo
        End Function

        Public Function AddmodelInfo(ByVal info As Model.System_Model) As Boolean
            Return ModelDAL.AddmodelInfo(info)
        End Function

        Public Function ModifyModelInfoById(ByVal Info As Model.System_Model) As Boolean
            Return ModelDAL.ModifyModelInfoById(Info)

        End Function

        Public Function GetModelInfoByCode(ByVal Code As String) As System_Model
            Return ModelDAL.GetModelInfoByCode(Code)
        End Function
    End Class
End Namespace

