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

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
<NavigationItem("Λειτουργία")>
<Persistent("DailyRoomActions")>
<DefaultClassOptions()>
Public Class DailyRoomActions ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        TheDate = Now
    End Sub

    Private _date As DateTime
    Public Property TheDate As DateTime
        Get
            Return _date
        End Get
        Set(value As DateTime)
            SetPropertyValue("TheDate", _date, value)
        End Set
    End Property

    Private _roomJob1 As DayRoomEnum
    Public Property RoomJob1 As DayRoomEnum
        Get
            Return _roomJob1
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob1", _roomJob1, value)
        End Set
    End Property
    Private _roomDesc1 As String
    Public Property RoomDesc1 As String
        Get
            Return _roomDesc1
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc1", _roomDesc1, value)
        End Set
    End Property

    Private _roomJob2 As DayRoomEnum
    Public Property RoomJob2 As DayRoomEnum
        Get
            Return _roomJob2
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob2", _roomJob2, value)
        End Set
    End Property
    Private _roomDesc2 As String
    Public Property RoomDesc2 As String
        Get
            Return _roomDesc2
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc2", _roomDesc2, value)
        End Set
    End Property

    Private _roomJob3 As DayRoomEnum
    Public Property RoomJob3 As DayRoomEnum
        Get
            Return _roomJob3
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob3", _roomJob3, value)
        End Set
    End Property
    Private _roomDesc3 As String
    Public Property RoomDesc3 As String
        Get
            Return _roomDesc3
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc3", _roomDesc3, value)
        End Set
    End Property

    Private _roomJob4 As DayRoomEnum
    Public Property RoomJob4 As DayRoomEnum
        Get
            Return _roomJob4
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob4", _roomJob4, value)
        End Set
    End Property
    Private _roomDesc4 As String
    Public Property RoomDesc4 As String
        Get
            Return _roomDesc4
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc4", _roomDesc4, value)
        End Set
    End Property

    Private _roomJob5 As DayRoomEnum
    Public Property RoomJob5 As DayRoomEnum
        Get
            Return _roomJob5
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob5", _roomJob5, value)
        End Set
    End Property
    Private _roomDesc5 As String
    Public Property RoomDesc5 As String
        Get
            Return _roomDesc5
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc5", _roomDesc5, value)
        End Set
    End Property

    Private _roomJob6 As DayRoomEnum
    Public Property RoomJob6 As DayRoomEnum
        Get
            Return _roomJob6
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob6", _roomJob6, value)
        End Set
    End Property
    Private _roomDesc6 As String
    Public Property RoomDesc6 As String
        Get
            Return _roomDesc6
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc6", _roomDesc6, value)
        End Set
    End Property

    Private _roomJob7 As DayRoomEnum
    Public Property RoomJob7 As DayRoomEnum
        Get
            Return _roomJob7
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob7", _roomJob7, value)
        End Set
    End Property
    Private _roomDesc7 As String
    Public Property RoomDesc7 As String
        Get
            Return _roomDesc7
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc7", _roomDesc7, value)
        End Set
    End Property

    Private _roomJob8 As DayRoomEnum
    Public Property RoomJob8 As DayRoomEnum
        Get
            Return _roomJob8
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob8", _roomJob8, value)
        End Set
    End Property
    Private _roomDesc8 As String
    Public Property RoomDesc8 As String
        Get
            Return _roomDesc8
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc81", _roomDesc8, value)
        End Set
    End Property

    Private _roomJob9 As DayRoomEnum
    Public Property RoomJob9 As DayRoomEnum
        Get
            Return _roomJob9
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob9", _roomJob9, value)
        End Set
    End Property
    Private _roomDesc9 As String
    Public Property RoomDesc9 As String
        Get
            Return _roomDesc9
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc9", _roomDesc9, value)
        End Set
    End Property

    Private _roomJob10 As DayRoomEnum
    Public Property RoomJob10 As DayRoomEnum
        Get
            Return _roomJob10
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob10", _roomJob10, value)
        End Set
    End Property
    Private _roomDesc10 As String
    Public Property RoomDesc10 As String
        Get
            Return _roomDesc10
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc1", _roomDesc10, value)
        End Set
    End Property

    Private _roomJob11 As DayRoomEnum
    Public Property RoomJob11 As DayRoomEnum
        Get
            Return _roomJob11
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob11", _roomJob11, value)
        End Set
    End Property
    Private _roomDesc11 As String
    Public Property RoomDesc11 As String
        Get
            Return _roomDesc11
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc11", _roomDesc11, value)
        End Set
    End Property

    Private _roomJob12 As DayRoomEnum
    Public Property RoomJob12 As DayRoomEnum
        Get
            Return _roomJob12
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob12", _roomJob12, value)
        End Set
    End Property
    Private _roomDesc12 As String
    Public Property RoomDesc12 As String
        Get
            Return _roomDesc12
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc12", _roomDesc12, value)
        End Set
    End Property

    Private _roomJob13 As DayRoomEnum
    Public Property RoomJob13 As DayRoomEnum
        Get
            Return _roomJob13
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob13", _roomJob13, value)
        End Set
    End Property
    Private _roomDesc13 As String
    Public Property RoomDesc13 As String
        Get
            Return _roomDesc13
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc13", _roomDesc13, value)
        End Set
    End Property

    Private _roomJob14 As DayRoomEnum
    Public Property RoomJob14 As DayRoomEnum
        Get
            Return _roomJob14
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob14", _roomJob14, value)
        End Set
    End Property
    Private _roomDesc14 As String
    Public Property RoomDesc14 As String
        Get
            Return _roomDesc14
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc14", _roomDesc14, value)
        End Set
    End Property

    Private _roomJob15 As DayRoomEnum
    Public Property RoomJob15 As DayRoomEnum
        Get
            Return _roomJob15
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob15", _roomJob15, value)
        End Set
    End Property
    Private _roomDesc15 As String
    Public Property RoomDesc15 As String
        Get
            Return _roomDesc15
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc15", _roomDesc15, value)
        End Set
    End Property

    Private _roomJob16 As DayRoomEnum
    Public Property RoomJob16 As DayRoomEnum
        Get
            Return _roomJob16
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob16", _roomJob16, value)
        End Set
    End Property
    Private _roomDesc16 As String
    Public Property RoomDesc16 As String
        Get
            Return _roomDesc16
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc16", _roomDesc16, value)
        End Set
    End Property

    Private _roomJob17 As DayRoomEnum
    Public Property RoomJob17 As DayRoomEnum
        Get
            Return _roomJob17
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob7", _roomJob17, value)
        End Set
    End Property
    Private _roomDesc17 As String
    Public Property RoomDesc17 As String
        Get
            Return _roomDesc17
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc17", _roomDesc17, value)
        End Set
    End Property

    Private _roomJob18 As DayRoomEnum
    Public Property RoomJob18 As DayRoomEnum
        Get
            Return _roomJob18
        End Get
        Set(value As DayRoomEnum)
            SetPropertyValue("RoomJob8", _roomJob18, value)
        End Set
    End Property
    Private _roomDesc18 As String
    Public Property RoomDesc18 As String
        Get
            Return _roomDesc18
        End Get
        Set(value As String)
            SetPropertyValue("RoomDesc18", _roomDesc18, value)
        End Set
    End Property



    Private _daybunker1 As DayBunkerEnum
    Public Property DayBunker1 As DayBunkerEnum
        Get
            Return _daybunker1
        End Get
        Set(value As DayBunkerEnum)
            SetPropertyValue("DayBunker1", _daybunker1, value)
        End Set
    End Property
    Private _BunkerDesc1 As String
    Public Property BunkerDesc1 As String
        Get
            Return _BunkerDesc1
        End Get
        Set(value As String)
            SetPropertyValue("BunkerDesc1", _BunkerDesc1, value)
        End Set
    End Property

    Private _daybunker2 As DayBunkerEnum
    Public Property DayBunker2 As DayBunkerEnum
        Get
            Return _daybunker2
        End Get
        Set(value As DayBunkerEnum)
            SetPropertyValue("DayBunker2", _daybunker2, value)
        End Set
    End Property
    Private _BunkerDesc2 As String
    Public Property BunkerDesc2 As String
        Get
            Return _BunkerDesc2
        End Get
        Set(value As String)
            SetPropertyValue("BunkerDesc2", _BunkerDesc2, value)
        End Set
    End Property

    Public Enum DayBunkerEnum
        Prewet
        Mix
        Bunker1
        BUnker2
        Πλατεία
        ΠλατείαΤούνελ
        Τούνελ
        Σπορά
    End Enum

    Public Enum DayRoomEnum
        Προετοιμασία
        Υπόστρωμα
        Σκάλισμα
        Τύρφη
        Ruffling
        Πότισμα
        Συγκομοιδή
        Άδειασμα
        Πλύσιμο
        Άδειος
    End Enum
End Class