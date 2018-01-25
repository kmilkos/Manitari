Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.ConditionalAppearance
Imports DevExpress.ExpressApp.Editors
Imports System.Globalization
Imports DevExpress.Persistent.Validation


'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
<Persistent("Production")>
<NavigationItem("Άλλα")>
<DefaultClassOptions()> _
Public Class Production ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).


    Private _productionRoomNumber As Int32
    Private _notes As String
    Private _height As Single
    Private _quality As String

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        TheDate = Today

        CompostAction = 0
        CompostSource = 0
        CompostTarget = 0

    End Sub

    Private _theDate As DateTime
    Public Property TheDate As DateTime
        Get
            Return _theDate
        End Get
        Set(value As DateTime)
            SetPropertyValue("TheDate", _theDate, value)
        End Set
    End Property

    Private _productionaction As ProductionActionEnum
    Public Property ProductionAction As ProductionActionEnum
        Get
            Return _productionaction
        End Get
        Set(value As ProductionActionEnum)
            SetPropertyValue("ProductionAction", _productionaction, value)
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

    <RuleRange("", DefaultContexts.Save, 0, 18)>
    Public Property ProductionRoomNumber As Int32
        Get
            Return _productionRoomNumber

        End Get
        Set(value As Int32)
            SetPropertyValue("ProductionRoomNumber", _productionRoomNumber, value)
        End Set
    End Property

    <Size(SizeAttribute.Unlimited)>
    Public Property Notes As String
        Get
            Return _notes
        End Get
        Set(value As String)
            SetPropertyValue("Notes", _notes, value)
        End Set
    End Property

    <AppearanceAttribute("HeightVisibility", Context:="DetailView", Criteria:="ProductionAction == 'Άδειασμα'", Visibility:=ViewItemVisibility.Hide)>
    Public Property Height As Single
        Get
            Return _height

        End Get
        Set(value As Single)
            SetPropertyValue("Height", _height, value)
        End Set
    End Property

    <AppearanceAttribute("QualityVisibility", Context:="DetailView", Criteria:="ProductionAction = 'Άδειασμα'", Visibility:=ViewItemVisibility.Hide)>
    Public Property Quality As String
        Get
            Return _quality

        End Get
        Set(value As String)
            SetPropertyValue("Quality", _quality, value)
        End Set
    End Property


#Region "κομποστάδικο"
    Private _compostAction As CompostActionEnum
    <Appearance("CompostActionVisibility", Visibility:=ViewItemVisibility.Hide, Criteria:="ProductionAction <> 'Κομποστάδικο'", Context:="DetailView")>
    Public Property CompostAction As CompostActionEnum
        Get
            Return _compostAction

        End Get
        Set(value As CompostActionEnum)
            SetPropertyValue("CompostAction", _compostAction, value)
        End Set
    End Property

    Private _compostsource As CompostPlacesEnum
    <Appearance("CompostSourceVisibility", Visibility:=ViewItemVisibility.Hide, Criteria:="ProductionAction <> 'Κομποστάδικο'", Context:="DetailView")>
    Public Property CompostSource As CompostPlacesEnum
        Get
            Return _compostsource

        End Get
        Set(value As CompostPlacesEnum)
            SetPropertyValue("CompostSource", _compostsource, value)
        End Set
    End Property

    Private _composttarget As CompostPlacesEnum
    <Appearance("CompostTargetVisibility", Visibility:=ViewItemVisibility.Hide, Criteria:="ProductionAction <> 'Κομποστάδικο'", Context:="DetailView")>
    Public Property CompostTarget As CompostPlacesEnum
        Get
            Return _composttarget

        End Get
        Set(value As CompostPlacesEnum)
            SetPropertyValue("CompostTarget", _composttarget, value)
        End Set
    End Property
#End Region

#Region "Υπόστρωμα"
    Private _compostcode As String
    Private _seedWhite As String
    Private _squaremeterWhite As Single
    Private _seedPortobello As String
    Private _squaremeterPortobello As Single

    Private _compost As Compost
    <AssociationAttribute("Compost-Productions")>
    Public Property Compost() As Compost
        Get
            Return _compost
        End Get
        Set(value As Compost)
            SetPropertyValue("Compost", _compost, value)
        End Set
    End Property

    <Appearance("SeedWhiteVisibility", Visibility:=ViewItemVisibility.Hide, Criteria:="ProductionAction <> 'Υπόστρωμα'", Context:="DetailView")>
    Public Property SeedWhite As String
        Get
            Return _seedWhite
        End Get
        Set(value As String)
            SetPropertyValue("SeedWhite", _seedWhite, value)
        End Set
    End Property

    <Appearance("SquareMeterWhiteVisibility", Visibility:=ViewItemVisibility.Hide, Criteria:="ProductionAction <> 'Υπόστρωμα'", Context:="DetailView")>
    Public Property SquareMeterWhite As Single
        Get
            Return _squaremeterWhite
        End Get
        Set(value As Single)
            SetPropertyValue("SquareMeterWhite", _squaremeterWhite, value)
        End Set
    End Property

    <Appearance("SeedPortobelloVisibility", Visibility:=ViewItemVisibility.Hide, Criteria:="ProductionAction <> 'Υπόστρωμα'", Context:="DetailView")>
    Public Property SeedPortobello As String
        Get
            Return _seedPortobello
        End Get
        Set(value As String)
            SetPropertyValue("SeedPortobello", _seedPortobello, value)
        End Set
    End Property

    <Appearance("SquareMeterPortobelloVisibility", Visibility:=ViewItemVisibility.Hide, Criteria:="ProductionAction <> 'Υπόστρωμα'", Context:="DetailView")>
    Public Property SquareMeterPortobello As Single
        Get
            Return _squaremeterPortobello
        End Get
        Set(value As Single)
            SetPropertyValue("SquareMeterPortobello", _squaremeterPortobello, value)
        End Set
    End Property
#End Region

#Region "Τύρφη"
    Private _cubicmeters As Single
    <Appearance("CubicMeters", Visibility:=ViewItemVisibility.Hide, Criteria:="ProductionAction <> 'Τύρφη'", Context:="DetailView")>
    Public Property CubicMeters As Single
        Get
            Return _cubicmeters
        End Get
        Set(value As Single)
            SetPropertyValue("CubicMeters", _cubicmeters, value)
        End Set
    End Property
#End Region

#Region "Άδειασμα"
    Private _truckster As String
    <AppearanceAttribute("TrucksterVisibility", Context:="DetailView", Criteria:="ProductionAction <> 'Άδειασμα'", Visibility:=ViewItemVisibility.Hide)>
    Public Property Truckster As String
        Get
            Return _truckster
        End Get
        Set(value As String)
            SetPropertyValue("Truckster", _truckster, value)
        End Set
    End Property
#End Region

    Public Enum ProductionActionEnum
        Υπόστρωμα
        Τύρφη
        Ruffling
        Άδειασμα
        Κομποστάδικο
    End Enum

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
