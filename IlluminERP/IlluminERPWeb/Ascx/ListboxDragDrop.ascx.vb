Imports Telerik.Web.UI

Public Delegate Sub CheckSelectedItemHandler(ByVal rlb As RadListBox)

Partial Class Ascx_ListboxDragDrop
    Inherits System.Web.UI.UserControl

    Public Enum ListBoxName
        UnSelected
        Selected
    End Enum

    Public Event OnCheckSelectedItems As CheckSelectedItemHandler


#Region "Public Property"
    Private _unSelectedDS As Object
    Private _selectedDS As Object
    Private _dataTextField As String
    Private _dataValueField As String
    Private _isUnSelectedCheckboxEnable As Boolean = False
    Private _isSelectedCheckboxEnable As Boolean = False
    Private _selectedCheckItemList As List(Of String)

    Public Property UnSelectedDataSource() As Object
        Get
            Return _unSelectedDS
        End Get
        Set(ByVal value As Object)
            _unSelectedDS = value
        End Set
    End Property

    Public Property SelectedDataSource() As Object
        Get
            Return _selectedDS
        End Get
        Set(ByVal value As Object)
            _selectedDS = value
        End Set
    End Property

    Public Property DataTextField() As String
        Get
            Return _dataTextField
        End Get
        Set(ByVal value As String)
            _dataTextField = value
        End Set
    End Property

    Public Property DataValueField() As String
        Get
            Return _dataValueField
        End Get
        Set(ByVal value As String)
            _dataValueField = value
        End Set
    End Property

    Public Property IsUnSelectedCheckBoxEnable As Boolean
        Get
            Return _isUnSelectedCheckboxEnable
        End Get
        Set(ByVal value As Boolean)
            _isUnSelectedCheckboxEnable = value
        End Set
    End Property

    Public Property IsSelectedCheckBoxEnable As Boolean
        Get
            Return _isSelectedCheckboxEnable
        End Get
        Set(ByVal value As Boolean)
            _isSelectedCheckboxEnable = value
        End Set
    End Property

    Public Property SelectedCheckItemList As List(Of String)
        Get
            Return _selectedCheckItemList
        End Get
        Set(ByVal value As List(Of String))
            _selectedCheckItemList = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitControl()

        End If

    End Sub

    Private Sub InitControl()

        rlbUnSelected.CheckBoxes = IsUnSelectedCheckBoxEnable
        rlbSelected.CheckBoxes = IsSelectedCheckBoxEnable

        If UnSelectedDataSource IsNot Nothing Then
            rlbUnSelected.DataSource = UnSelectedDataSource
            rlbUnSelected.DataTextField = DataTextField
            rlbUnSelected.DataValueField = DataValueField
            rlbUnSelected.DataBind()
        End If
        If SelectedDataSource IsNot Nothing Then
            rlbSelected.DataSource = SelectedDataSource
            rlbSelected.DataTextField = DataTextField
            rlbSelected.DataValueField = DataValueField
            rlbSelected.DataBind()
        End If

        If SelectedCheckItemList IsNot Nothing Then
            CheckListBoxItem(ListBoxName.Selected, SelectedCheckItemList)
        End If

    End Sub

    Public Sub CheckListBoxItem(ByVal lbName As ListBoxName, ByVal lbItemValues As List(Of String))
        Dim rlb As RadListBox = Nothing
        If lbName = ListBoxName.UnSelected Then
            rlb = rlbUnSelected
        End If
        If lbName = ListBoxName.Selected Then
            rlb = rlbSelected
        End If

        For Each items As RadListBoxItem In rlb.Items
            If lbItemValues.Contains(items.Value) Then
                items.Checked = True
            End If
        Next
    End Sub

    Public Function GetFinalChecked() As NameValueCollection
        Dim result As New NameValueCollection
        For Each item As RadListBoxItem In rlbSelected.Items
            If item.Checked Then
                result.Add(item.Value, item.Text)
            End If
        Next
        Return result
    End Function

    Public Function GetFinalCheckedValue() As List(Of String)
        Dim result As NameValueCollection
        result = GetFinalChecked()
        Dim valueList As New List(Of String)
        If result IsNot Nothing Then
            For Each key As String In result.AllKeys
                valueList.Add(key)
            Next
        End If
        Return valueList
    End Function

    Public Function GetFinalSelected() As NameValueCollection
        Dim result As New NameValueCollection
        For Each item As RadListBoxItem In rlbSelected.Items
            result.Add(item.Value, item.Text)
        Next
        Return result
    End Function

    Public Function GetFinalSelectedValue() As List(Of String)
        Dim result As NameValueCollection
        result = GetFinalSelected()
        Dim valueList As New List(Of String)
        If result IsNot Nothing Then
            For Each key As String In result.AllKeys
                valueList.Add(key)
            Next
        End If
        Return valueList
    End Function



End Class
