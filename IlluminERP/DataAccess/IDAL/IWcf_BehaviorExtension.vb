'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.1
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
    
    Friend Interface IWcf_BehaviorExtension
        
        Function GetEntityById(ByVal Id As Integer) As Wcf_BehaviorExtensionInfo
        
        Function GetEntityDataSet() As DataSet
        
        Sub DeleteEntityById(ByVal Id As Integer)

        Function GetWCFBehaviorExtensionByName(ByVal extensionName As String) As Wcf_BehaviorExtensionInfo
    End Interface
End Namespace
