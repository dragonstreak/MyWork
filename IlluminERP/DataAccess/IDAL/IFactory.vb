Imports System


Namespace IDAL
    Friend Enum TransactionState
        None = 0

        Required = 1
    End Enum

    Friend Interface IFactory
        Function GetProduct(ByVal className As String) As IDAO

        Sub BeginTransaction()

        Sub Commit()

        Sub Rollback()

        ReadOnly Property TransState() As TransactionState

    End Interface
End Namespace
