Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Base.General
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports System
Imports System.ComponentModel
Imports System.Linq
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Model
Imports System.Drawing
Imports DevExpress.ExpressApp.DC

<DefaultClassOptions>
<XafDisplayName("Πελάτες")>
<ImageName("BO_Customer")>
<DefaultProperty("FullName")>
<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)>
<Persistent("Customer")>
<NavigationItem("Πωλήσεις")>
Public Class Customer ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Implements IPerson

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    <XafDisplayName("Επωνυμία Εταιρείας")>
    Public Property CompanyTitle As String
        Get
            Return GetPropertyValue(Of String)("CompanyTitle")
        End Get
        Set(value As String)
            SetPropertyValue("CompanyTitle", value)
        End Set
    End Property

    <XafDisplayName("Διεύθυνση")>
    Public Property CompanyAddress As String
        Get
            Return GetPropertyValue(Of String)("CompanyAddress")
        End Get
        Set(value As String)
            SetPropertyValue("CompanyAddress", value)
        End Set
    End Property

    <ModelDefault("EditMask", "000-000-000")>
    <XafDisplayName("Α.Φ.Μ.")>
    Public Property CompanyAFM As String
        Get
            Return GetPropertyValue(Of String)("CompanyAFM")
        End Get
        Set(value As String)
            SetPropertyValue("CompanyAFM", value)
        End Set
    End Property

    <XafDisplayName("Δ.Ο.Υ.")>
    Public Property CompanyDOY As String
        Get
            Return GetPropertyValue(Of String)("CompanyDOY")
        End Get
        Set(value As String)
            SetPropertyValue("CompanyDOY", value)
        End Set
    End Property

    <XafDisplayName("Είδος Εργασίας")>
    Public Property CompanyJobType As String
        Get
            Return GetPropertyValue(Of String)("CompanyJobType")
        End Get
        Set(value As String)
            SetPropertyValue("CompanyJobType", value)
        End Set
    End Property

    <Association("Customer-Orders"), DevExpress.Xpo.Aggregated>
    <XafDisplayName("Παραγγελίες")>
    Public ReadOnly Property Orders() As XPCollection(Of Order)
        Get
            Return GetCollection(Of Order)("Orders")
        End Get
    End Property



#Region "IPerson"
    Private Const defaultFullNameFormat As String = "{FirstName} {MiddleName} {LastName}"

    <XafDisplayName("Όνομα")>
    Public Property FirstName As String Implements IPerson.FirstName
        Get
            Return GetPropertyValue(Of String)("FirstName")
        End Get
        Set(value As String)
            SetPropertyValue("FirstName", value)
        End Set
    End Property

    <XafDisplayName("Επώνυμο")>
    Public Property LastName As String Implements IPerson.LastName
        Get
            Return GetPropertyValue(Of String)("LastName")
        End Get
        Set(value As String)
            SetPropertyValue("LastName", value)
        End Set
    End Property

    <XafDisplayName("Μεσαίο Όνομα")>
    Public Property MiddleName As String Implements IPerson.MiddleName
        Get
            Return GetPropertyValue(Of String)("MiddleName")
        End Get
        Set(value As String)
            SetPropertyValue("MiddleName", value)
        End Set
    End Property

    <XafDisplayName("Γενέθλια")>
    Public Property Birthday As Date Implements IPerson.Birthday
        Get
            Return GetPropertyValue(Of Date)("Birthday")
        End Get
        Set(value As Date)
            SetPropertyValue("Birthday", value)
        End Set
    End Property

    <XafDisplayName("Ονοματεπώνυμο")>
    Public ReadOnly Property FullName As String Implements IPerson.FullName
        Get
            Return ObjectFormatter.Format("{LastName} {MiddleName} {FirstName}", This, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty)
        End Get
    End Property

    <XafDisplayName("E-Mail")>
    Private _email, _oldemail As String
    <Size(255)>
    Public Property Email As String Implements IPerson.Email
        Get
            Return GetPropertyValue(Of String)("Email")
        End Get
        Set(value As String)
            SetPropertyValue("Email", value)
        End Set
    End Property

    Public Sub SetFullName(fullName As String) Implements IPerson.SetFullName
        PersonImpl.FullNameFormat = defaultFullNameFormat
    End Sub
#End Region

    Private fOrdersCount As Nullable(Of Integer) = Nothing
    <XafDisplayName("Παραγγελίες")>
    Public ReadOnly Property OrdersCount() As Nullable(Of Integer)
        Get
            If (Not IsLoading) AndAlso (Not IsSaving) AndAlso Not fOrdersCount.HasValue Then
                UpdateOrdersCount(False)
            End If
            Return fOrdersCount
        End Get
    End Property

    Public Sub UpdateOrdersCount(ByVal forceChangeEvents As Boolean)
        Dim oldOrdersCount As Nullable(Of Integer) = fOrdersCount
        fOrdersCount = Convert.ToInt32(Evaluate(CriteriaOperator.Parse("Orders.Count")))
        If forceChangeEvents Then
            OnChanged("OrdersCount", oldOrdersCount, fOrdersCount)
        End If
    End Sub
End Class
