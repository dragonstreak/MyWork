
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports System.IO


Namespace BLL
    Public Class PMS_SubProjectInfoBLL
        Private factory As New DALFactory
        Private SubProjectInfoDAL As IPMS_SubProjectInfo = factory.GetProduct("PMS_SubProjectInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetSubProjectInfoById(ByVal ID As Integer) As Model.PMS_SubProjectInfo
            Return SubProjectInfoDAL.GetSubProjectInfoById(ID)
        End Function

        Public Function GetSubProjectInfoByProId(ByVal ProId As Integer) As DataSet
            Return SubProjectInfoDAL.GetSubProjectInfoByProId(ProId)
        End Function

        Public Function AddSubProjectInfo(ByVal info As Model.PMS_SubProjectInfo) As Integer
            Return SubProjectInfoDAL.AddSubProjectInfo(info)
        End Function

        Public Function UpdateSubProjectStatus(ByVal info As PMS_SubProjectInfo) As Boolean
            Return SubProjectInfoDAL.UpdateSubProjectStatus(info)
        End Function

        Public Function GetSubJobNumberByJobNumberMethTag(ByVal JobNumber As String, ByVal MethTag As String) As String
            Return SubProjectInfoDAL.GetSubJobNumberByJobNumberMethTag(JobNumber, MethTag)
        End Function
    End Class
End Namespace
