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
            SetPropertyValue(Nameof(Room), _room, Value)
        End Set
    End Property

    Private _isEmpty As Boolean
    <XafDisplayName("Πέταμα")>
    Property IsEmpty As Boolean
        Get
            Return _isEmpty
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue(NameOf(IsEmpty), _isEmpty, Value)
        End Set
    End Property

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

    Public Shared Function GetISOWeekOfYear(dt As DateTime) As Integer
        Dim cal As Calendar = CultureInfo.InvariantCulture.Calendar
        Dim d As DayOfWeek = cal.GetDayOfWeek(dt)

        If (d >= DayOfWeek.Monday) AndAlso (d <= DayOfWeek.Wednesday) Then
            dt = dt.AddDays(3)
        End If

        Return cal.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
    End Function
End Class
