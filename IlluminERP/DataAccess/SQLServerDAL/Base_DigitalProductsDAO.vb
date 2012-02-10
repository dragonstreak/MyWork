Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL


    Friend Class Base_DigitalProductsDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_DigitalProducts



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_DigitalProducts
            Dim info As New Base_DigitalProducts
            info.ID = Convert.ToInt32(dr("ID"))
            info.DigitalProducts = dr("DigitalProducts").ToString()
            info.DigitalProducts = dr("ShortName").ToString()

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_DigitalProducts) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                New SqlParameter("@DigitalProducts", SqlDbType.Char), _
                                                                    New SqlParameter("@ShortName", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.DigitalProducts
            parameters(2).Value = info.ShortName


            Return parameters
        End Function


        Public Function GetDigitalProductsInfo() As System.Data.DataSet Implements IDAL.IBase_DigitalProducts.GetDigitalProductsInfo
            Dim sql As String = "select * from [t_Base_DigitalProducts] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds
        End Function

        Public Function GetDigitalProductsInfoByID(ByVal ID As Integer) As Model.Base_DigitalProducts Implements IDAL.IBase_DigitalProducts.GetDigitalProductsInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = ID
            Dim sql As String = "select * from [t_Base_DigitalProducts] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_DigitalProducts = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function
    End Class

End Namespace
