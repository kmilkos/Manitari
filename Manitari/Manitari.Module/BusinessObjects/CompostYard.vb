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

'<ImageName("BO_Contact")>
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
<Persistent("CompostYard")>
<DefaultProperty("CompostCode")>
<DefaultClassOptions()>
<NavigationItem("Παραγωγή")>
Public Class CompostYard ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        CompostDate = Now
    End Sub

    Private _compostdate As DateTime
    Public Property CompostDate As DateTime
        Get
            Return _compostdate

        End Get
        Set(value As DateTime)
            SetPropertyValue("CompostDate", _compostdate, value)
        End Set
    End Property

    Private _compost As Compost
    <AssociationAttribute("Compost-CompostYards")>
    Public Property Compost() As Compost
        Get
            Return _compost
        End Get
        Set(value As Compost)
            SetPropertyValue("Compost", _compost, value)
        End Set
    End Property

    Private _farmAction As FarmAction
    Property FarmAction As FarmAction
        Get
            Return _farmAction
        End Get
        Set(ByVal Value As FarmAction)
            SetPropertyValue(NameOf(FarmAction), _farmAction, Value)
        End Set
    End Property

    Private _compostAction As CompostActionEnum
    Public Property CompostAction As CompostActionEnum
        Get
            Return _compostAction

        End Get
        Set(value As CompostActionEnum)
            SetPropertyValue("CompostAction", _compostAction, value)
        End Set
    End Property

    Private _compostsource As CompostPlacesEnum
    Public Property CompostSource As CompostPlacesEnum
        Get
            Return _compostsource

        End Get
        Set(value As CompostPlacesEnum)
            SetPropertyValue("CompostSource", _compostsource, value)
        End Set
    End Property

    Private _composttarget As CompostPlacesEnum
    Public Property CompostTarget As CompostPlacesEnum
        Get
            Return _composttarget

        End Get
        Set(value As CompostPlacesEnum)
            SetPropertyValue("CompostTarget", _composttarget, value)
        End Set
    End Property

    Private _CompostComments As String
    <Size(4096)>
    Public Property CompostComments As String
        Get
            Return _CompostComments

        End Get
        Set(value As String)
            SetPropertyValue("CompostComments", _CompostComments, value)
        End Set
    End Property

    Public Enum CompostActionEnum
        Prewet
        Mix
        Μεταφορά
        Σπορα
    End Enum

    Public Enum CompostPlacesEnum
        ΠλατείαΚομποστάδικου
        Bunker1
        Bunker2
        ΠλατείαΤούνελ
        Τούνελ
        Σπορά
    End Enum

    Public Shared Function GetISOWeekOfYear(dt As DateTime) As Integer
        Dim cal As Calendar = CultureInfo.InvariantCulture.Calendar
        Dim d As DayOfWeek = cal.GetDayOfWeek(dt)

        If (d >= DayOfWeek.Monday) AndAlso (d <= DayOfWeek.Wednesday) Then
            dt = dt.AddDays(3)
        End If

        Return cal.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
    End Function
End Class
