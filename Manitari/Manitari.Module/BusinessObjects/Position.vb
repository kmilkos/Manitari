Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

'<ImageName("BO_Contact")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
<DefaultProperty("Title")>
<Persistent("Position")>
<DefaultClassOptions()>
<DevExpress.ExpressApp.DC.XafDisplayNameAttribute("Θέση Εργασίας")>
Public Class Position ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    'Private _PersistentProperty As String
    '<XafDisplayName("My display name"), ToolTip("My hint message")> _
    '<ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(False)> _
    '<Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)> _
    'Public Property PersistentProperty() As String
    '    Get
    '        Return _PersistentProperty
    '    End Get
    '    Set(ByVal value As String)
    '        SetPropertyValue("PersistentProperty", _PersistentProperty, value)
    '    End Set
    'End Property

    '<Action(Caption:="My UI Action", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)> _
    'Public Sub ActionMethod()
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub

    Private _title As String

    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(value As String)
            SetPropertyValue("Title", _title, value)
        End Set
    End Property

    <DevExpress.Xpo.AssociationAttribute("Employees-Positions")>
    Public ReadOnly Property Employees As XPCollection(Of Employee)
        Get
            Return GetCollection(Of Employee)("Employees")
        End Get
    End Property

    <DevExpress.Xpo.AssociationAttribute("Skills-Position")>
    Public ReadOnly Property Skills As XPCollection(Of Skill)
        Get
            Return GetCollection(Of Skill)("Skills")
        End Get
    End Property

    Private _department As Department
    <DevExpress.Xpo.AssociationAttribute("Positions-Department")>
    Public Property Department As Department
        Get
            Return _department
        End Get
        Set(ByVal value As Department)
            SetPropertyValue("Department", _department, value)
        End Set
    End Property
End Class
