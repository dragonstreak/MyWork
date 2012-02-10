
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class System_UploadFileBLL

        Private factory As New DALFactory
        Private UploadFileDAL As ISystem_UploadFile = factory.GetProduct("System_UploadFileDAO")

        Public Function AddEntity(ByVal entity As System_UploadFile) As Integer
            Return UploadFileDAL.AddEntity(entity)
        End Function

        Public Function GetEntityById(ByVal Id As Integer) As System_UploadFile
            Return UploadFileDAL.GetEntityById(Id)
        End Function

        Public Function GetEntityDataSet() As DataSet
            Return UploadFileDAL.GetEntityDataSet()
        End Function

        Public Sub DeleteEntityById(ByVal Id As Integer)
            UploadFileDAL.DeleteEntityById(Id)
        End Sub

        Public Function GetUploadFileIdListByMainEntityId(ByVal mainEntityId As Integer) As List(Of Integer)
            Return UploadFileDAL.GetUploadFileIdListByMainEntityId(mainEntityId)
        End Function

    End Class
End Namespace

