Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess.Model


Namespace IDAL
    Friend Interface IBase_Department

        Function GetDepartmentInfo() As DataSet

        Function GetDepartmentInfoByID(ByVal ID As Integer) As Base_DepartmentInfo


    End Interface
End Namespace

