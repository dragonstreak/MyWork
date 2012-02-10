Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.SQLServerDAL
Public Class PMS_RespondentCriteriaBLL
    Dim dalFactory As EnterpriseDalFactory
    Dim iEntity As IPMS_RespondentCriteria
    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_RespondentCriteria, PMS_RespondentCriteriaDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_RespondentCriteria
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_RespondentCriteria)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_RespondentCriteria) As Integer
        Return iEntity.SaveEntity(entity)
    End Function
   
    Public Function GetComponentCriteriaList(ByVal componentId As Integer) As List(Of PMS_RespondentCriteria)
        Return iEntity.GetComponentCriteriaList(componentId)
    End Function
End Class
