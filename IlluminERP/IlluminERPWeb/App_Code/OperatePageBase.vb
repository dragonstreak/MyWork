Imports Microsoft.VisualBasic

Public Class OperatePageBase
    Inherits PageBase
    Protected OperateType As String = "New"
    Private operateParamName As String = "operateType"
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        If Not Page.IsPostBack Then
            'set operate type for this page
            SetOperateType()
            InitForm()
            SetForm()
        Else
            OperateType = ViewState("OperateType")
        End If
    End Sub
    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)
        MyBase.OnLoadComplete(e)

    End Sub
    Protected Overrides Sub OnPreInit(ByVal e As System.EventArgs)
        MyBase.OnPreInit(e)

    End Sub


    ''' <summary>
    ''' This method is the overridble method for page to set operate type.
    ''' This is the default implement fot page to set operate type.
    ''' Get the operate type from url, then set OperateType.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetOperateType()
        If Page.Request.QueryString.GetValues(operateParamName) Is Nothing Then
            Return
        End If
        OperateType = Page.Request.QueryString(operateParamName)

        ViewState("OperateType") = OperateType
    End Sub
    ''' <summary>
    ''' This method is for page to init the form.
    ''' child page should override it.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub InitForm()

    End Sub
    ''' <summary>
    ''' This method is for page to set the form.
    ''' child page should override it.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetForm()

    End Sub

End Class
