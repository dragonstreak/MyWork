Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Base_DepartmentBLL
        Private factory As New DALFactory
        Private DepartmentDAL As IBase_Department = factory.GetProduct("Base_DepartmentDAO")

        Public Sub New()

        End Sub

        Public Function GetDepartmentInfo() As DataSet
            Return DepartmentDAL.GetDepartmentInfo
        End Function

        Public Function GetDepartmentInfoByID(ByVal ID As Integer) As Base_DepartmentInfo
            Return DepartmentDAL.GetDepartmentInfoByID(ID)
        End Function





    End Class
End Namespace
