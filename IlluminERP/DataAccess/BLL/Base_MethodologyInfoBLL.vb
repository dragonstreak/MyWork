


Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL

    Public Class Base_MethodologyInfoBLL
        Private factory As New DALFactory
        Private MethodologyInfoDal As Ibase_MethodologyInfo = factory.GetProduct("Base_MethodologyInfoDAO")

        Public Sub New()

        End Sub


        Public Function GetMethodologyInfo(ByVal Id As Integer) As Base_MethodologyInfo
            Return MethodologyInfoDal.GetMethodologyInfo(Id)
        End Function

        Public Function GetMethodologyInfoByType(ByVal MethType As Integer) As DataSet
            Return MethodologyInfoDal.GetMethodologyInfoByType(MethType)
        End Function


    End Class
End Namespace
