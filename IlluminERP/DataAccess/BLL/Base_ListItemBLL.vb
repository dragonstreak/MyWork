Imports DataAccess.IDAL
Imports DataAccess.Model

Namespace BLL

    Public Class Base_ListItemBLL
        Private factory As New DALFactory
        Private ListItemDAL As IBase_ListItem = factory.GetProduct("Base_ListItemDAO")

        Public Sub New()

        End Sub

        Public Function AddEntity(ByVal listItem As Base_ListItem) As Integer
            Return ListItemDAL.AddEntity(listItem)
        End Function

        Public Function UpdateEntity(ByVal listItem As Base_ListItem) As Boolean
            Return ListItemDAL.UpdateEntity(listItem)
        End Function

        Public Function GetEntityByID(ByVal Id As Integer) As Base_ListItem

            Return ListItemDAL.GetEntityById(Id)
        End Function

        Function GetEntityList(ByVal filter As ListItemQueryFilter) As DataTable
            Return ListItemDAL.GetEntityList(filter)
        End Function

        Public Function IsEntityExist(ByVal entity As Base_ListItem) As Boolean
            Return ListItemDAL.IsEntityExist(entity)
        End Function
    End Class
End Namespace
