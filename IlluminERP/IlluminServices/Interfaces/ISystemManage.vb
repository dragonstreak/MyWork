Imports Illumin.Services.DataContracts

<ServiceContract()>
Public Interface ISystemManage

    <OperationContract()>
    <WebInvoke(RequestFormat:=WebMessageFormat.Json, ResponseFormat:=WebMessageFormat.Json, BodyStyle:=WebMessageBodyStyle.WrappedRequest)>
    Function GetPageModule(ByVal param As GetPageModuleParam) As GetPageModuleResult

    <OperationContract()>
    <WebInvoke(RequestFormat:=WebMessageFormat.Json, ResponseFormat:=WebMessageFormat.Json, BodyStyle:=WebMessageBodyStyle.WrappedRequest)>
    Function GetPageModule2(ByVal pageUrl As String) As String

End Interface


