
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model


Namespace BLL
    Public Class Base_PositionInfoBLL
        Private factory As New DALFactory
        Private PositionInfoDAL As IBase_PositionInfo = factory.GetProduct("Base_PositionInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetPositionInfo() As DataSet
            Return PositionInfoDAL.GetPositionInfo()
        End Function

        Public Function GetPositionInfoByID(ByVal Id As Integer) As Model.Base_PositionInfo
            Return PositionInfoDAL.GetPositionInfoByID(Id)
        End Function

    End Class
End Namespace
