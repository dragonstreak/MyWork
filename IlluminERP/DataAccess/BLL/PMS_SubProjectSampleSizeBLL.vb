

Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL

Public Class PMS_SubProjectSampleSizeBLL
        Private factory As New DALFactory
        Private SubProjectSampleSizeDAL As IPMS_SubProjectSampleSize = factory.GetProduct("PMS_SubProjectSampleSizeDAO")

        Public Sub New()

        End Sub
        Public Function GetSubProjectSampleSizeById(ByVal ID As Integer) As Model.PMS_SubProjectSampleSize
            Return SubProjectSampleSizeDAL.GetSubProjectSampleSizeById(ID)

        End Function

        Public Function GetSubProjectSampleSizeBySubProId(ByVal SubProId As Integer) As DataSet
            Return SubProjectSampleSizeDAL.GetSubProjectSampleSizeBySubProId(SubProId)
        End Function

        Public Function AddSubProjectSampleSizeInfo(ByVal info As Model.PMS_SubProjectSampleSize) As Integer
            Return SubProjectSampleSizeDAL.AddSubProjectSampleSizeInfo(info)
        End Function

        Public Function DeleteSubProjectSampleSizeInfoById(ByVal Id As Integer) As Boolean
            Return SubProjectSampleSizeDAL.DeleteSubProjectSampleSizeInfoById(Id)
        End Function
    End Class
End Namespace
