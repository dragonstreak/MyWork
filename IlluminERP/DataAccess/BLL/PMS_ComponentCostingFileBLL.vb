Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.SQLServerDAL
Imports System.IO
Public Class PMS_ComponentCostingFileBLL
    Dim dalFactory As EnterpriseDalFactory
    Dim iEntity As IPMS_ComponentCostingFile

    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_ComponentCostingFile, PMS_ComponentCostingFileDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_ComponentCostingFile
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_ComponentCostingFile)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_ComponentCostingFile) As Integer
        Return iEntity.SaveEntity(entity)
    End Function
    ''' <summary>
    ''' This method is used to get component costing file.
    ''' As of now, one component will only has one costing file.
    ''' </summary>
    ''' <param name="componentId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetComponentCostingFile(ByVal componentId As Integer) As PMS_ComponentCostingFile
        Dim list As List(Of PMS_ComponentCostingFile) = iEntity.GetComponentCostingFile(componentId)
        If list Is Nothing Then
            Return Nothing
        End If
        If list.Count = 0 Then
            Return Nothing
        End If
        'as of now ,one component will only has one costing file,so we will return the first entity.
        Return list(0)
    End Function
    Public Sub SaveCostingFile(ByVal showName As String, ByVal saveName As String, ByVal flag As String)

    End Sub


End Class
