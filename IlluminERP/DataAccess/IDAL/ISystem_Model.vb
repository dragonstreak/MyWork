Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL


    Friend Interface ISystem_Model

        Function GetSystemMenuBylevel(ByVal level As Integer) As DataSet

        Function GetMenuItemByParent(ByVal parentID As Integer) As DataSet

        Function GetModelInfoById(ByVal Id As Integer) As System_Model

        Function GetModelInfo() As DataSet

        Function GetModelInfoByCode(ByVal Code As String) As System_Model


        Function AddmodelInfo(ByVal info As Model.System_Model) As Boolean

        Function ModifyModelInfoById(ByVal Info As Model.System_Model) As Boolean






    End Interface


End Namespace
