


Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class PMS_ProRelationBLL
        Private factory As New DALFactory
        Private ProRelationBLL As IPMS_ProRelationInfo = factory.GetProduct("PMS_ProRelationInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetRelationProInfoByProId(ByVal Proid As Integer) As DataSet
            Return Me.ProRelationBLL.GetRelationProInfoByProId(Proid)
        End Function

        Public Function GetRelationProInfoByRelationProId(ByVal RelationProId As Integer) As DataSet
            Return Me.ProRelationBLL.GetRelationProInfoByRelationProId(RelationProId)
        End Function

        Public Function InsertProRelationInfo(ByVal ProRelationInfo As PMS_ProRelationInfo) As Boolean
            Return Me.ProRelationBLL.InsertProRelationInfo(ProRelationInfo)
        End Function

        Public Function DeleteProRelationInfo(ByVal ProRelationInfo As PMS_ProRelationInfo) As Boolean
            Return Me.ProRelationBLL.DeleteProRelationInfo(ProRelationInfo)
        End Function

    End Class

End Namespace

