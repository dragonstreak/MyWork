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
    
    Friend Interface IPMS_RespondentCriteria
        
        Function GetEntityById(ByVal Id As Integer) As PMS_RespondentCriteria
        
        Function GetEntityList() As List(Of PMS_RespondentCriteria)
        
        Function GetEntityDataSet() As DataSet
        
        Sub DeleteEntity(ByVal Id As Integer)
        
        Function SaveEntity(ByVal entity As PMS_RespondentCriteria) As Integer

        Function GetComponentCriteriaList(ByVal componentId As Integer) As List(Of PMS_RespondentCriteria)
    End Interface
End Namespace
