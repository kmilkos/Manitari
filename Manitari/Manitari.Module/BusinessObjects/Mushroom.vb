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

<DefaultProperty("FullName")>
<Persistent("Mushroom")>
<NavigationItem("Πωλήσεις")>
<DefaultClassOptions()> _
Public Class Mushroom ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub

    Private _mushroomType As MushroomTypeEnum
    Property MushroomType As MushroomTypeEnum
        Get
            Return _mushroomType
        End Get
        Set(ByVal Value As MushroomTypeEnum)
            SetPropertyValue(NameOf(MushroomType), _mushroomType, Value)
        End Set
    End Property

    Private _mushroomSize As MushroomSizeEnum
    Property MushroomSize As MushroomSizeEnum
        Get
            Return _mushroomSize
        End Get
        Set(ByVal Value As MushroomSizeEnum)
            SetPropertyValue(NameOf(MushroomSize), _mushroomSize, Value)
        End Set
    End Property

    Private _wrapping As MushroomWrapping
    Property Wrapping As MushroomWrapping
        Get
            Return _wrapping
        End Get
        Set(ByVal Value As MushroomWrapping)
            SetPropertyValue(Nameof(Wrapping), _wrapping, Value)
        End Set
    End Property
    

    Private _priceBuying As Decimal
    Property PriceBuying As Decimal
        Get
            Return _priceBuying
        End Get
        Set(ByVal Value As Decimal)
            SetPropertyValue(NameOf(PriceBuying), _priceBuying, Value)
        End Set
    End Property

    Private _priceSelling As Decimal
    Property PriceSelling As Decimal
        Get
            Return _priceSelling
        End Get
        Set(ByVal Value As Decimal)
            SetPropertyValue(NameOf(PriceSelling), _priceSelling, Value)
        End Set
    End Property

    Public ReadOnly Property FullName As String
        Get
            Return ObjectFormatter.Format("{MushroomType} {MushroomSize} {Wrapping} ({PriceSelling})", This, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty)
        End Get
    End Property

    Public Enum MushroomTypeEnum
        Λευκό
        Πορτομπέλο
        Καφέ
        Πλευρώτους
    End Enum

    Public Enum MushroomSizeEnum
        Αδιάφορο
        Μικρό
        Κανονικό
        Μεσαίο
        Giant
    End Enum

    Public Enum MushroomWrapping
        Χύμα
        Συσκευασία500γρ
        Συσκευασία250γρ
        Συσκευασία400γρ
        Συσκευασία200γρ
    End Enum

End Class
