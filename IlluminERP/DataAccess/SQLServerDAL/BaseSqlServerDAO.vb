Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL

Namespace SQLServerDAL
    Friend Class BaseSqlServerDAO
        Implements DataAccess.IDAL.IDAO

        Protected DEFAULT_NTEXT_LENGTH As Integer = 4000

        Private _factory As DataAccess.SQLServerDAL.SqlServerFactory


        Public Sub New(ByVal factory As DataAccess.IDAL.IFactory)
            System.Diagnostics.Debug.Assert((Not (factory Is Nothing)))
            System.Diagnostics.Debug.Assert(TypeOf factory Is SqlServerFactory)

            _factory = factory

        End Sub


        Protected Overloads Function ExecuteDataSet(ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As DataSet
            If _factory.TransState = TransactionState.Required Then
                Return SqlHelper.ExecuteDataset(_factory.GetTransaction(), commandType, commandText, commandParameters)
            Else
                Return SqlHelper.ExecuteDataset(_factory.GetConnection(), commandType, commandText, commandParameters)
            End If
        End Function


        Protected Overloads Function ExecuteNonQuery(ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As Integer
            If _factory.TransState = TransactionState.Required Then
                Return SqlHelper.ExecuteNonQuery(_factory.GetTransaction(), commandType, commandText, commandParameters)
            Else
                Return SqlHelper.ExecuteNonQuery(_factory.GetConnection(), commandType, commandText, commandParameters)
            End If
        End Function


        Protected Overloads Function ExecuteScalar(ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As Object
            If _factory.TransState = TransactionState.Required Then
                Return SqlHelper.ExecuteScalar(_factory.GetTransaction(), commandType, commandText, commandParameters)
            Else
                Return SqlHelper.ExecuteScalar(_factory.GetConnection(), commandType, commandText, commandParameters)
            End If
        End Function


        Protected Overloads Function ExecuteReader(ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
            If _factory.TransState = TransactionState.Required Then
                Return SqlHelper.ExecuteReader(_factory.GetTransaction(), commandType, commandText, commandParameters)
            Else
                Return SqlHelper.ExecuteReader(_factory.GetConnection(), commandType, commandText, commandParameters)
            End If
        End Function


        Protected Overloads Function ExecuteDataSet(ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As DataSet
            Return ExecuteDataSet(System.Data.CommandType.Text, commandText, commandParameters)
        End Function


        Protected Overloads Function ExecuteNonQuery(ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As Integer
            Return ExecuteNonQuery(System.Data.CommandType.Text, commandText, commandParameters)
        End Function


        Protected Overloads Function ExecuteScalar(ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As Object
            Return ExecuteScalar(System.Data.CommandType.Text, commandText, commandParameters)
        End Function


        Protected Overloads Function ExecuteReader(ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
            Return ExecuteReader(System.Data.CommandType.Text, commandText, commandParameters)
        End Function


        Public Function GetFactory() As IFactory Implements IDAO.GetFactory
            Return _factory
        End Function
    End Class
End Namespace
