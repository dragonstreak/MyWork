
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.Components


Namespace SQLServerDAL
    Friend Class Base_DepartmentDAO

        Inherits BaseSqlServerDAO
        Implements DataAccess.IDAL.IBase_Department

        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub


        Private Function MapRowToDepartmentInfo(ByVal dr As DataRow) As Base_DepartmentInfo
            Dim info As New Base_DepartmentInfo
            info.ID = Convert.ToInt32(dr("ID"))
            info.Department = dr("Department").ToString()

            If Not Convert.IsDBNull(dr("Department")) Then
                info.Department = dr("Department").ToString()
            End If


            Return info

        End Function


        Private Function GetParameters(ByVal info As Model.Base_DepartmentInfo) As SqlParameter()
            Dim parameters() As SqlParameter = {New SqlParameter("@ID", SqlDbType.Int), _
                                                                    New SqlParameter("@Department", SqlDbType.Char)}

            parameters(0).Value = info.ID
            parameters(1).Value = info.Department


            Return parameters
        End Function

        Public Function GetDepartmentInfoByID(ByVal intID As Integer) As Model.Base_DepartmentInfo Implements IDAL.IBase_Department.GetDepartmentInfoByID
            Dim paramID As New SqlParameter("@id", SqlDbType.Int)
            paramID.Value = intID
            Dim sql As String = "select * from [t_base_Department] where Id = @id"
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql, paramID)
            Dim info As Base_DepartmentInfo = Nothing
            If Not (ds Is Nothing) And ds.Tables(0).Rows.Count = 1 Then
                info = MapRowToDepartmentInfo(ds.Tables(0).Rows(0))
            End If
            Return info

        End Function

        Public Function GetDepartmentInfo() As System.Data.DataSet Implements IDAL.IBase_Department.GetDepartmentInfo
            
            Dim sql As String = "select * from [t_base_Department] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)

            Return ds

        End Function
    End Class
End Namespace

