Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model

Namespace IDAL
    Friend Interface IPMS_UploadFileInfo
        Function GetUploadFileInfoById(ByVal Id As Integer) As Model.PMS_UploadFileInfo

        Function GetUploadFileInfoByProId(ByVal ProId As Integer) As DataView

        Function AddUploadFileInfo(ByVal info As Model.PMS_UploadFileInfo) As Integer

        Function DeleteUploadFileInfo(ByVal Info As Model.PMS_UploadFileInfo) As Boolean
    End Interface
End Namespace 
