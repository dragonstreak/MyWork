
Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports Utils



Namespace BLL
    Public Class Client_ClientInfoBLL
        Private factory As New DALFactory
        Private ClientInfoDAL As IClient_ClientInfo = factory.GetProduct("Client_ClientInfoDAO")

        Public Sub New()

        End Sub

        Public Function GetClientInfo() As DataSet
            Return ClientInfoDAL.GetClientInfo

        End Function

        Public Function GetClientInfoByID(ByVal Id As Integer) As Model.Client_ClientInfo
            Return ClientInfoDAL.GetClientInfoByID(Id)
        End Function

        Public Function GetClientInfoByClientType(ByVal ClientType As Integer) As DataView
            Return ClientInfoDAL.GetClientInfoByClientType(ClientType)
        End Function

        Public Function AddClientInfo(ByVal info As Client_ClientInfo) As Integer
            Return ClientInfoDAL.AddClientInfo(info)
        End Function

        Public Function UpdateClientInfo(ByVal Info As Client_ClientInfo) As Boolean
            Return ClientInfoDAL.UpdateClientInfo(Info)
        End Function

        Public Function IsExistClient(ByVal info As Model.Client_ClientInfo) As Boolean
            Return ClientInfoDAL.IsExistClient(info)
        End Function

        Public Function IsExistClientByCode(ByVal ClientCode As String) As Boolean
            Return ClientInfoDAL.IsExistClientByCode(ClientCode)
        End Function
        Public Function UpdateClientStatus(ByVal Id As Integer) As Boolean
            Return ClientInfoDAL.UpdateClientStatus(Id)
        End Function

        Public Function NewClientInfo(ByVal Info As Client_ClientInfo, ByVal dtDetailInfo As DataTable) As Integer
            Dim factory As New DALFactory

            Dim ClientId As Integer
            Dim ClientInfoDAL As IClient_ClientInfo = factory.GetProduct("Client_ClientInfoDAO")
            Dim ClientDetailDAL As IClient_ClientDetailInfo = factory.GetProduct("Client_ClientDetailInfoDAO")
            Dim ClientDetailInfo As Model.Client_ClientDetailInfo

            factory.BeginTransaction()
            Try
                ClientId = ClientInfoDAL.AddClientInfo(Info)


                For Each dr As DataRow In dtDetailInfo.Rows

                    ClientDetailInfo = New Client_ClientDetailInfo
                    ClientDetailInfo.ClientId = ClientId
                    ClientDetailInfo.City = dr("City")
                    ClientDetailInfo.CompanyAddressCN = dr("CompanyAddressCN")
                    ClientDetailInfo.CompanyAddressEN = dr("CompanyAddressEN")
                    ClientDetailInfo.Country = dr("Country")
                    ClientDetailInfo.Department = dr("Department")
                    ClientDetailInfo.Email = dr("Email")
                    ClientDetailInfo.FirstNameCN = dr("FirstNameCN")
                    ClientDetailInfo.FirstNameEN = dr("FirstNameEN")
                    ClientDetailInfo.LastNameEN = dr("LastNameEN")
                    ClientDetailInfo.LastNameCN = dr("LastNameCN")
                    ClientDetailInfo.JobTitle = dr("JobTitle")
                    ClientDetailInfo.MobilePhone = dr("MobilePhone")
                    ClientDetailInfo.PostCode = dr("PostCode")
                    ClientDetailInfo.TelDirect = dr("TelDirect")
                    ClientDetailInfo.TelGeneral = dr("TelGeneral")
                    ClientDetailInfo.Website = dr("Website")
                    ClientDetailDAL.AddClientDetailInfo(ClientDetailInfo)
                Next

                factory.Commit()
                Return ClientId
            Catch ex As Exception
                factory.Rollback()
                Return 0
            End Try
        End Function

        Public Function ModifyClientInfo(ByVal ClientInfo As Client_ClientInfo, ByVal dtDetailInfo As DataTable, ByVal dtGetClientWay As DataTable, ByVal dtUploadFile As DataTable) As Integer
            Dim factory As New DALFactory

            Dim ClientId As Integer
            Dim ClientInfoDAL As IClient_ClientInfo = factory.GetProduct("Client_ClientInfoDAO")
            Dim ClientDetailDAL As IClient_ClientDetailInfo = factory.GetProduct("Client_ClientDetailInfoDAO")
            Dim ClientGetClientWayDAL As IClient_ClientInfoGetWay = factory.GetProduct("Client_ClientInfoGetWayDAO")
            Dim ClientUploadFileBLL As IClient_ClientUploadFile = factory.GetProduct("Client_ClientUploadFileDAO")
            Dim ClientClientWayInfo As Model.Client_ClientInfoGetWay
            Dim clientClientUploadFile As New Model.Client_ClientUploadFile

            'Dim clientClientUploadFile As Model.Client_ClientUploadFile
            factory.BeginTransaction()
            Try


                ClientId = ClientInfo.ID
                ClientInfoDAL.UpdateClientInfo(ClientInfo)

                'DetailInfo.ClientId = ClientId
                'ClientDetailDAL.UpdateClientDetailInfo(DetailInfo)


                '  ClientGetClientWayDAL.DeleteClientINfoGetWay(ClientId)

                '获取联系人信息
                Dim oldDetailInfo As New Model.Client_ClientDetailInfo
                Dim ds As DataSet = ClientDetailDAL.GetClientDetailInfoByClientId(ClientId)
                Dim dt As DataTable
                dt = ds.Tables(0)

                ''获取客户信息的选项
                'Dim oldWayInfo As New Model.Client_ClientInfoGetWay
                'Dim ds As DataSet = ClientGetClientWayDAL.GetClientInfoGetWayByClientId(ClientId)
                'Dim dt As DataTable
                'dt = ds.Tables(0)

                '第一次新选项在老选项的中间判断。 如果没有新增
                For Each drNew As DataRow In dtGetClientWay.Rows
                    Dim i As Integer = 0
                    For Each olddr As DataRow In dt.Rows
                        If drNew("wayTypeId") = olddr("wayTypeId") Then
                            i = 1
                            Exit For
                        End If
                    Next

                    If i = 0 Then '新的
                        ClientClientWayInfo = New Client_ClientInfoGetWay
                        ClientClientWayInfo.ClientId = ClientId
                        ClientClientWayInfo.WayTypeId = drNew("WayTypeId")
                        ClientClientWayInfo.Description = drNew("Description")
                        ClientGetClientWayDAL.AddClientInfoGetWayInfo(ClientClientWayInfo)
                    End If
                Next


                '第一次新选项在老选项的中间判断。 如果没有新增
                For Each drNew As DataRow In dtGetClientWay.Rows
                    Dim i As Integer = 0
                    For Each olddr As DataRow In dt.Rows
                        If drNew("wayTypeId") = olddr("wayTypeId") Then
                            i = 1
                            Exit For
                        End If
                    Next

                    If i = 0 Then '新的
                        ClientClientWayInfo = New Client_ClientInfoGetWay
                        ClientClientWayInfo.ClientId = ClientId
                        ClientClientWayInfo.WayTypeId = drNew("WayTypeId")
                        ClientClientWayInfo.Description = drNew("Description")
                        ClientGetClientWayDAL.AddClientInfoGetWayInfo(ClientClientWayInfo)
                    End If
                Next

                '第二次老选项在新选项的中间判断。 如果没有删除

                For Each olddr As DataRow In dt.Rows
                    Dim i As Integer = 0
                    For Each drNew As DataRow In dtGetClientWay.Rows
                        If drNew("wayTypeId") = olddr("wayTypeId") Then
                            'ClientClientWayInfo = New Client_ClientInfoGetWay
                            'ClientClientWayInfo.Id = olddr("Id")
                            'ClientClientWayInfo.ClientId = ClientId
                            'ClientClientWayInfo.WayTypeId = drNew("WayTypeId")
                            'ClientClientWayInfo.Description = drNew("Description")
                            'ClientGetClientWayDAL.AddClientInfoGetWayInfo(ClientClientWayInfo)
                            i = 1
                            Exit For
                        End If
                    Next

                    If i = 0 Then
                        ClientClientWayInfo = New Client_ClientInfoGetWay
                        ClientClientWayInfo.Id = olddr("Id")
                        ClientGetClientWayDAL.DeleteClientINfoGetWay(ClientClientWayInfo)
                    End If
                Next


                '获取保存数据库上传文件信息
                '*********************************************************************
                '********************************************************************
                ds = ClientUploadFileBLL.GetClientUploadFileInfoByClientId(ClientId)
                dt = ds.Tables(0)

                '如果数据库没有数据，修改后有，直接插入数据
                If dt.Rows.Count = 0 Then
                    If dtUploadFile.Rows.Count > 0 Then
                        For Each drNew As DataRow In dtUploadFile.Rows
                            clientClientUploadFile = New Client_ClientUploadFile
                            clientClientUploadFile.ClientId = ClientId
                            clientClientUploadFile.FileName = drNew("FileName")
                            clientClientUploadFile.FileTypeId = drNew("FileTypeId")
                            clientClientUploadFile.FilePath = drNew("FilePath")
                            ClientUploadFileBLL.AddClientUploadFileInfo(clientClientUploadFile)
                        Next
                    End If
                Else

                    '新的在原数据库相比较
                    For Each drNew As DataRow In dtUploadFile.Rows
                        Dim i As Integer = 0
                        For Each olddr As DataRow In dt.Rows

                            If Utils.DataConvert.ConvertDataToInt32(drNew("id")) = olddr("id") Then
                                i = 1
                                Exit For
                            End If
                        Next
                        If i = 0 Then '不存在，需新加

                            clientClientUploadFile = New Client_ClientUploadFile
                            clientClientUploadFile.ClientId = ClientId
                            clientClientUploadFile.FileName = drNew("FileName")
                            clientClientUploadFile.FileTypeId = drNew("FileTypeId")
                            clientClientUploadFile.FilePath = drNew("FilePath")
                            ClientUploadFileBLL.AddClientUploadFileInfo(clientClientUploadFile)
                        End If

                    Next

                    '老的在新的中比较，如果没有就直接删除
                    For Each olddr As DataRow In dt.Rows
                        Dim i As Integer = 0
                        For Each drNew As DataRow In dtUploadFile.Rows
                            If Utils.DataConvert.ConvertDataToInt32(drNew("id")) = olddr("Id") Then
                                i = 1
                                Exit For
                            End If

                        Next
                        If i = 0 Then
                            clientClientUploadFile = New Client_ClientUploadFile
                            clientClientUploadFile.Id = olddr("Id")
                            ClientUploadFileBLL.DeleteClintUploadFile(clientClientUploadFile.Id)
                            Utils.FileUtils.DeleteFile(String.Empty, olddr("FilePath"))
                        End If


                    Next
                End If

                factory.Commit()
                Return ClientId
            Catch ex As Exception
                factory.Rollback()
                Return 0
            End Try
        End Function

    End Class
End Namespace
