Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.Globalization

<DefaultClassOptions>
<XafDisplayName("Κομπόστα")>
<DefaultProperty("CompostCode")>
<Persistent("Compost")>
<NavigationItem("Παραγωγή")>
Public Class Compost ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub

    Private _compostcode As String
    <XafDisplayName("Κωδικός Κομπόστας")>
    Public Property CompostCode As String
        Set(value As String)
            SetPropertyValue("CompostCode", _compostcode, value)
        End Set
        Get
            Return _compostcode
        End Get
    End Property

    Private _theDate As DateTime
    <XafDisplayName("Ημερομηνία")>
    Property TheDate As DateTime
        Get
            Return _theDate
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(NameOf(TheDate), _theDate, Value)
        End Set
    End Property

    Private _room As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    <XafDisplayName("Θάλαμος")>
    Property Room As String
        Get
            Return _room
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Room), _room, Value)
        End Set
    End Property

    Private _straw As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    <XafDisplayName("Αχυρο")>
    Property Straw As String
        Get
            Return _straw
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Nameof(Straw), _straw, Value)
        End Set
    End Property

    Private _gypsum As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    <XafDisplayName("Γύψος")>
    Property Gypsum As String
        Get
            Return _gypsum
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Nameof(Gypsum), _gypsum, Value)
        End Set
    End Property

    Private _manure As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    <XafDisplayName("Κοπρια")>
    Property Manure As String
        Get
            Return _manure
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Manure), _manure, Value)
        End Set
    End Property

#Region "Flushes"
    Private _room1 As Integer
    <XafDisplayName("1ος Θαλάμος")>
    Property room1 As Integer
        Get
            Return _room1
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(room1), _room1, Value)
        End Set
    End Property
    Private _flush11 As Single
    <XafDisplayName("1.1ο flush")>
    Property flush11 As Single
        Get
            Return _flush11
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush11), _flush11, Value)
        End Set
    End Property
    <XafDisplayName("1.1o Kg/m2")>
    Public ReadOnly Property Room1Flush1Kgm2() As Nullable(Of Single)
        Get
            Room1Flush1Kgm2 = flush11 / WhiteSeedm21

            Return Room1Flush1Kgm2
        End Get
    End Property
    Private _flush12 As Single
    <XafDisplayName("1.2ο flush")>
    Property flush12 As Single
        Get
            Return _flush12
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush12), _flush12, Value)
        End Set
    End Property
    <XafDisplayName("1.2o Kg/m2")>
    Public ReadOnly Property Room1Flush2Kgm2() As Nullable(Of Single)
        Get
            Room1Flush2Kgm2 = flush12 / WhiteSeedm21

            Return Room1Flush2Kgm2
        End Get
    End Property
    Private _flush13 As Single
    <XafDisplayName("1.3ο flush")>
    Property flush13 As Single
        Get
            Return _flush13
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush13), _flush13, Value)
        End Set
    End Property
    <XafDisplayName("1.3o Kg/m2")>
    Public ReadOnly Property Room1Flush3Kgm2() As Nullable(Of Single)
        Get
            Room1Flush3Kgm2 = flush13 / WhiteSeedm21

            Return Room1Flush3Kgm2
        End Get
    End Property
    Private _whiteSeedm21 As Integer
    <XafDisplayName("1.Λευκός μ2")>
    Property WhiteSeedm21 As Integer
        Get
            Return _whiteSeedm21
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(WhiteSeedm21), _whiteSeedm21, Value)
        End Set
    End Property
    Private _brownSeedm21 As Integer
    <XafDisplayName("1.Καφέ μ2")>
    Property BrownSeedm21 As Integer
        Get
            Return _brownSeedm21
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(BrownSeedm21), _brownSeedm21, Value)
        End Set
    End Property
    Private _isRoom1Empty As Boolean
    <XafDisplayName("1.Αδειασε;")>
    Property IsRoom1Empty As Boolean
        Get
            Return _isRoom1Empty
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue(Nameof(IsRoom1Empty), _isRoom1Empty, Value)
        End Set
    End Property

    Private _room2 As Integer
    <XafDisplayName("2ος Θαλάμος")>
    Property room2 As Integer
        Get
            Return _room2
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Nameof(room2), _room2, Value)
        End Set
    End Property
    Private _flush21 As Single
    <XafDisplayName("2.1ο flush")>
    Property flush21 As Single
        Get
            Return _flush21
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush21), _flush21, Value)
        End Set
    End Property
    <XafDisplayName("2.1o Kg/m2")>
    Public ReadOnly Property Room2Flush1Kgm2() As Nullable(Of Single)
        Get
            Room2Flush1Kgm2 = flush21 / WhiteSeedm22

            Return Room2Flush1Kgm2
        End Get
    End Property
    Private _flush22 As Single
    <XafDisplayName("2.2ο flush")>
    Property flush22 As Single
        Get
            Return _flush22
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush22), _flush22, Value)
        End Set
    End Property
    <XafDisplayName("2.2o Kg/m2")>
    Public ReadOnly Property Room2Flush2Kgm2() As Nullable(Of Single)
        Get
            Room2Flush2Kgm2 = flush22 / WhiteSeedm22

            Return Room2Flush2Kgm2
        End Get
    End Property
    Private _flush23 As Single
    <XafDisplayName("2.3ο flush")>
    Property flush23 As Single
        Get
            Return _flush23
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush23), _flush23, Value)
        End Set
    End Property
    <XafDisplayName("2.3o Kg/m2")>
    Public ReadOnly Property Room2Flush3Kgm2() As Nullable(Of Single)
        Get
            Room2Flush3Kgm2 = flush23 / WhiteSeedm22

            Return Room2Flush3Kgm2
        End Get
    End Property
    Private _whiteSeedm22 As Integer
    <XafDisplayName("2.Λευκός μ2")>
    Property WhiteSeedm22 As Integer
        Get
            Return _whiteSeedm22
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Nameof(WhiteSeedm22), _whiteSeedm22, Value)
        End Set
    End Property
    Private _brownSeedm22 As Integer
    <XafDisplayName("2.Καφέ μ2")>
    Property BrownSeedm22 As Integer
        Get
            Return _brownSeedm22
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(BrownSeedm22), _brownSeedm22, Value)
        End Set
    End Property
    Private _isRoom2Empty As Boolean
    <XafDisplayName("2.Αδειασε;")>
    Property IsRoom2Empty As Boolean
        Get
            Return _isRoom2Empty
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue(NameOf(IsRoom2Empty), _isRoom2Empty, Value)
        End Set
    End Property
#End Region

    <AssociationAttribute("Compost-CompostYards")>
    <XafDisplayName("Εργασίες Κομποστάδικου")>
    Public ReadOnly Property CompostYards() As XPCollection(Of CompostYard)
        Get
            Return GetCollection(Of CompostYard)("CompostYards")
        End Get
    End Property

    <AssociationAttribute("Compost-Productions")>
    <XafDisplayName("Εργασίες Παραγωγής")>
    Public ReadOnly Property Productions() As XPCollection(Of Production)
        Get
            Return GetCollection(Of Production)("Productions")
        End Get
    End Property

    <AssociationAttribute("Compost-Waterings")>
    <XafDisplayName("Ποτίσματα")>
    Public ReadOnly Property Waterings() As XPCollection(Of Watering)
        Get
            Return GetCollection(Of Watering)("Waterings")
        End Get
    End Property

    <AssociationAttribute("Compost-Collectings")>
    <XafDisplayName("Συγκομοιδή")>
    Public ReadOnly Property Collectings() As XPCollection(Of collecting)
        Get
            Return GetCollection(Of collecting)("Collectings")
        End Get
    End Property

    Public Shared Function GetISOWeekOfYear(dt As DateTime) As Integer
        Dim cal As Calendar = CultureInfo.InvariantCulture.Calendar
        Dim d As DayOfWeek = cal.GetDayOfWeek(dt)

        If (d >= DayOfWeek.Monday) AndAlso (d <= DayOfWeek.Wednesday) Then
            dt = dt.AddDays(3)
        End If

        Return cal.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
    End Function
End Class
