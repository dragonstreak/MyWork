'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.225
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports DataAccess.Model
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace IDAL
    
    Friend Interface IPMS_CityCoverage
        
        Function GetEntityById(ByVal Id As Integer) As PMS_CityCoverage
        
        Function GetEntityList() As List(Of PMS_CityCoverage)
        
        Function GetEntityDataSet() As DataSet
        
        Sub DeleteEntity(ByVal Id As Integer)
        
        Function SaveEntity(ByVal entity As PMS_CityCoverage) As Integer

        Function GetComponentCityCoverageList(ByVal componentId As Integer) As List(Of PMS_CityCoverage)
    End Interface
End Namespace
