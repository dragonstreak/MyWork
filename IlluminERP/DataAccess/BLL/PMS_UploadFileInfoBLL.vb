
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports Utils



Namespace BLL
    Public Class PMS_UploadFileInfoBLL
        Private factory As New DALFactory
        Private UploadFileInfoDAL As IPMS_UploadFileInfo = factory.GetProduct("PMS_UploadFileInfoDAO")
        Public Sub New()

        End Sub

        Public Function GetUploadFileInfoById(ByVal Id As Integer) As Model.PMS_UploadFileInfo
            Return Me.UploadFileInfoDAL.GetUploadFileInfoById(Id)
        End Function

        Public Function GetUploadFileInfoByProId(ByVal ProId As Integer) As DataView
            Return Me.UploadFileInfoDAL.GetUploadFileInfoByProId(ProId)
        End Function

        Public Function AddUploadFileInfo(ByVal info As Model.PMS_UploadFileInfo) As Integer
            Return Me.UploadFileInfoDAL.AddUploadFileInfo(info)
        End Function

        Public Function DeleteUploadFileInfo(ByVal Info As Model.PMS_UploadFileInfo) As Boolean
            Return Me.UploadFileInfoDAL.DeleteUploadFileInfo(Info)
        End Function
    End Class
End Namespace
