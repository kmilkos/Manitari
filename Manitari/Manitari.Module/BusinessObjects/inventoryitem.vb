﻿Imports Microsoft.VisualBasic
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
<XafDisplayName("Απογραφή - Υπολίστα")>
<DefaultProperty("Display")>
<Persistent("InventoryItem")>
<NavigationItem("Αποθήκες")>
Public Class InventoryItem ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _item As WarehouseItem
    <XafDisplayName("Αντικείμενο")>
    Property Item As WarehouseItem
        Get
            Return _item
        End Get
        Set(ByVal Value As WarehouseItem)
            SetPropertyValue(NameOf(Item), _item, Value)
        End Set
    End Property

    Private _count As Single
    <XafDisplayName("Ποσότητα")>
    Property Count As Single
        Get
            Return _count
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(Count), _count, Value)
        End Set
    End Property

    Private _inventory As Inventory
    <Association("Inventory-InventoryItems")>
    Property Inventory() As Inventory
        Get
            Return _inventory
        End Get
        Set(ByVal Value As Inventory)
            SetPropertyValue(NameOf(Inventory), _inventory, Value)
        End Set
    End Property


    Public ReadOnly Property Display As String
        Get
            Return ObjectFormatter.Format("{Item} ({Count})", This, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty)
        End Get
    End Property
End Class
