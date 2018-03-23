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
<XafDisplayName("Κομποστάδικο")>
<Persistent("CompostYard")>
<DefaultProperty("CompostCode")>
<NavigationItem("Παραγωγή")>
Public Class CompostYard ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        TheDate = Now
    End Sub

    Private _theDate As DateTime
    <XafDisplayName("Ημερομηνία")>
    Public Property TheDate As DateTime
        Get
            Return _theDate

        End Get
        Set(value As DateTime)
            SetPropertyValue("CompostDate", _theDate, value)
        End Set
    End Property

    Private _compost As Compost
    <AssociationAttribute("Compost-CompostYards")>
    <XafDisplayName("Κομπόστα")>
    Public Property Compost() As Compost
        Get
            Return _compost
        End Get
        Set(value As Compost)
            SetPropertyValue("Compost", _compost, value)
        End Set
    End Property

    Private _farmAction As FarmAction
    <DataSourceCriteria("Category.Caption = 'Κομποστάδικο'")>
    <XafDisplayName("Εργασία")>
    Property FarmAction As FarmAction
        Get
            Return _farmAction
        End Get
        Set(ByVal Value As FarmAction)
            SetPropertyValue(NameOf(FarmAction), _farmAction, Value)
        End Set
    End Property

    Private _CompostComments As String
    <Size(4096)>
    <XafDisplayName("Σημειώσεις")>
    Public Property CompostComments As String
        Get
            Return _CompostComments

        End Get
        Set(value As String)
            SetPropertyValue("CompostComments", _CompostComments, value)
        End Set
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
