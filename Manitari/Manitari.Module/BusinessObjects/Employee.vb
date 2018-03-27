Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Base.General
Imports DevExpress.Persistent.BaseImpl
Imports System.Drawing
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.PivotGrid.ServerMode

<DefaultClassOptions>
<ImageName("BO_Contact")>
<DefaultProperty("FullName")>
<Persistent("Employee")>
<XafDisplayName("Προσωπικό")>
Public Class Employee ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits Person

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

        '_Color = Color.White.ToArgb()

    End Sub

#Region "Properties"
    Private _manager As Employee
    <DataSourceProperty("Department.Employees", DataSourcePropertyIsNullMode.SelectAll)>
    <DataSourceCriteria("Position.Title = 'Υπεύθυνος' AND Oid !='@This.Oid'")>
    <XafDisplayName("Συντονιστής")>
    Public Property Manager As Employee
        Get
            Return _manager
        End Get
        Set(value As Employee)
            SetPropertyValue("Manager", _manager, value)
        End Set
    End Property

    Private _datehired As DateTime
    <XafDisplayName("Πρόσληψη")>
    Public Property DateHired As DateTime
        Set(value As DateTime)
            SetPropertyValue("DateHired", _datehired, value)
        End Set
        Get
            Return _datehired
        End Get
    End Property

    Private _datefired As DateTime
    <XafDisplayName("Απόλυση")>
    Public Property DateFired As DateTime
        Set(value As DateTime)
            SetPropertyValue("DateFired", _datefired, value)
        End Set
        Get
            Return _datefired
        End Get
    End Property

    Private _nickname As String
    <XafDisplayName("Ψευδόνυμο")>
    Public Property Nickname() As String
        Get
            Return _nickname
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Nickname", _nickname, value)
        End Set
    End Property

    Private _notes As String
    <Size(SizeAttribute.Unlimited)>
    <XafDisplayName("Σημειώσεις")>
    Public Property Notes() As String
        Get
            Return _notes
        End Get
        Set(value As String)
            SetPropertyValue("Notes", _notes, value)
        End Set
    End Property
#End Region

#Region "Connections"
    Private _department As Department
    <DevExpress.Xpo.AssociationAttribute("Employees-Department")>
    <XafDisplayName("Τμήμα")>
    Public Property Department As Department
        Get
            Return _department
        End Get
        Set
            SetPropertyValue("Department", _department, Value)
        End Set
    End Property

    Private _position As Position
    <Association("Position-Employees")>
    <XafDisplayName("Θέση Εργασίας")>
    Property Position() As Position
        Get
            Return _position
        End Get
        Set(ByVal Value As Position)
            SetPropertyValue(NameOf(Position), _position, Value)
        End Set
    End Property

    <Association("Employee-Attends"), DevExpress.Xpo.Aggregated>
    <XafDisplayName("Ωρολόγιο")>
    Public ReadOnly Property Attends() As XPCollection(Of Attend)
        Get
            Return GetCollection(Of Attend)(NameOf(Attends))
        End Get
    End Property

    <DevExpress.Xpo.AssociationAttribute("Skills-Employees")>
    <XafDisplayName("Ικανότητες")>
    Public ReadOnly Property Skills As XPCollection(Of Skill)
        Get
            Return GetCollection(Of Skill)("Skills")
        End Get
    End Property

    <Association("Employee-DailyLogs")>
    <XafDisplayName("Ημερήσιες Εργασίες")>
    Public ReadOnly Property DailyLogs() As XPCollection(Of DailyLog)
        Get
            Return GetCollection(Of DailyLog)(NameOf(DailyLogs))
        End Get
    End Property

    <Association("Employee-Tasks")>
    Public ReadOnly Property Tasks() As XPCollection(Of Task)
        Get
            Return GetCollection(Of Task)(NameOf(Tasks))
        End Get
    End Property
#End Region

End Class
