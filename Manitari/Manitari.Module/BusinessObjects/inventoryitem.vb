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

<DefaultProperty("ItemName")>
<Persistent("InventoryItems")>
<NavigationItem("Reports")>
<DefaultClassOptions()>
Public Class inventoryitem ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _itemName As String
    Property ItemName As String
        Get
            Return _itemName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(ItemName), _itemName, Value)
        End Set
    End Property

    Private _counterType As InventoryItemCounterEnum
    Property CounterType As InventoryItemCounterEnum
        Get
            Return _counterType
        End Get
        Set(ByVal Value As InventoryItemCounterEnum)
            SetPropertyValue(NameOf(CounterType), _counterType, Value)
        End Set
    End Property

    Private _itemConverter As Single
    Property ItemConverter As Single
        Get
            Return _itemConverter
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(ItemConverter), _itemConverter, Value)
        End Set
    End Property


    Enum InventoryItemCounterEnum

        Κιλά
        Κουτί
        Μπετόνι
        Μπάλα
        Παλλέτα
        Σακούλα
        μ3
        μ2
        Τεμάχια
        Βαρέλι
        Μέτρα
    End Enum
End Class
