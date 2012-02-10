

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components



Namespace SQLServerDAL
    Friend Class Base_SubContractInfoDAO
        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_SubContractInfo

        Private ConnTNSMIS As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("CONN_DB_TNSMIS").ConnectionString



        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub
        Public Function GetSubContractCity() As System.Data.DataSet Implements IDAL.IBase_SubContractInfo.GetSubContractCity
          
            Dim sql As String = "select distinct S_City from [t_SubcontractInfo] Order by S_City "
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnTNSMIS, CommandType.Text, sql)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Public Function GetSubContractbyCity(ByVal City As String) As System.Data.DataSet Implements IDAL.IBase_SubContractInfo.GetSubContractbyCity
            Dim paramCity As New SqlParameter("@City", SqlDbType.VarChar)
            paramCity.Value = City
            Dim sql As String = "select * from [t_SubcontractInfo] where S_City = @City "
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnTNSMIS, CommandType.Text, sql, paramCity)

            If Not (ds Is Nothing) Then
                Return ds
            Else
                Return Nothing
            End If

        End Function

        Public Function GetSubContractInfoById(ByVal id As Integer) As Model.Base_SubContractInfo Implements IDAL.IBase_SubContractInfo.GetSubContractInfoById
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = id
            Dim sql As String = "select * from [t_SubcontractInfo] where Id = @id "
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnTNSMIS, CommandType.Text, sql, paramID)
            Dim info As Base_SubContractInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToInfo(ds.Tables(0).Rows(0))
            End If
            Return info
        End Function

        Private Function MapRowToInfo(ByVal dr As DataRow) As Base_SubContractInfo
            Dim info As New Base_SubContractInfo
            info.ID = Convert.ToInt32(dr("ID"))
            info.S_City = dr("S_City").ToString()
            info.S_Name = Convert.ToString(dr("S_Name"))

            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_SubContractInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@S_City", SqlDbType.VarChar), _
                                                                    New SqlParameter("@S_Name", SqlDbType.VarChar)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.S_City
            parameters(2).Value = info.S_Name


            Return parameters
        End Function

      
    End Class
End Namespace
