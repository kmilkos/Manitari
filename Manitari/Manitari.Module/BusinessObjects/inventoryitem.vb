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

<DefaultClassOptions>
<XafDisplayName("Αντικείμενα Απογραφής")>
<NavigationItem("Αποθήκες")>
<DefaultProperty("ItemName")>
<Persistent("InventoryItems")>
Public Class inventoryitem
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
    End Sub

    Private _itemName As String
    <XafDisplayName("Ονομα Αντικειμένου")>
    Property ItemName As String
        Get
            Return _itemName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(ItemName), _itemName, Value)
        End Set
    End Property

    Private _counterType As InventoryItemCounterEnum
    <XafDisplayName("΄Μονάδα Μέτρησης")>
    Property CounterType As InventoryItemCounterEnum
        Get
            Return _counterType
        End Get
        Set(ByVal Value As InventoryItemCounterEnum)
            SetPropertyValue(NameOf(CounterType), _counterType, Value)
        End Set
    End Property

    Private _itemConverter As Single
    <XafDisplayName("Μετατροπή 1")>
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
