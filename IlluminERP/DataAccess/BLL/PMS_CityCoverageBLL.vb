Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.SQLServerDAL
Public Class PMS_CityCoverageBLL
    Dim dalFactory As EnterpriseDalFactory
    Dim iEntity As IPMS_CityCoverage
    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_CityCoverage, PMS_CityCoverageDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_CityCoverage
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_CityCoverage)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_CityCoverage) As Integer
        Return iEntity.SaveEntity(entity)
    End Function

    Public Function GetComponentCityCoverageList(ByVal componentId As Integer) As List(Of PMS_CityCoverage)
        Return iEntity.GetComponentCityCoverageList(componentId)
    End Function

End Class
