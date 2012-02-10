Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IPMS_ProRelationInfo

        Function GetRelationProInfoByProId(ByVal Proid As Integer) As DataSet

        Function GetRelationProInfoByRelationProId(ByVal RelationProId As Integer) As DataSet

        Function InsertProRelationInfo(ByVal ProRelationInfo As PMS_ProRelationInfo) As Boolean

        Function DeleteProRelationInfo(ByVal ProRelationInfo As PMS_ProRelationInfo) As Boolean

    End Interface

End Namespace

