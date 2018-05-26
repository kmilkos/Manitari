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
<Persistent("WarehouseItem")>
<XafDisplayName("Αντικείμενα Αποθήκης")>
<ImageName("BO_Product")>
<NavigationItem("Αποθήκες")>
<DefaultClassOptions()>
Public Class WarehouseItem
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
    End Sub

    Private _warehouse As Warehouse
    <Association("Warehouse-WarehouseItems")>
    <XafDisplayName("Αποθήκη")>
    Property Warehouse() As Warehouse
        Get
            Return _warehouse
        End Get
        Set(ByVal Value As Warehouse)
            SetPropertyValue(NameOf(Warehouse), _warehouse, Value)
        End Set
    End Property

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

    Private _unitOne As InventoryItemCounterEnum
    <XafDisplayName("Μονάδα Μέτρησης 1")>
    Property UnitOne As InventoryItemCounterEnum
        Get
            Return _unitOne
        End Get
        Set(ByVal Value As InventoryItemCounterEnum)
            SetPropertyValue(NameOf(UnitOne), _unitOne, Value)
        End Set
    End Property

    Private _unitOneAmount As Single
    <XafDisplayName("Ποσότητα 1")>
    Property UnitOneAmount As Single
        Get
            Return _unitOneAmount
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(UnitOneAmount), _unitOneAmount, Value)
        End Set
    End Property


    Private _unitTwo As InventoryItemCounterEnum
    <XafDisplayName("Μονάδα Μέτρησης 2")>
    Property UnitTwo As InventoryItemCounterEnum
        Get
            Return _unitTwo
        End Get
        Set(ByVal Value As InventoryItemCounterEnum)
            SetPropertyValue(NameOf(UnitTwo), _unitTwo, Value)
        End Set
    End Property

    Private _unitTwoAmount As Single
    <XafDisplayName("Ποσότητα 2")>
    Property UnitTwoAmount As Single
        Get
            Return _unitTwoAmount
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(UnitTwoAmount), _unitTwoAmount, Value)
        End Set
    End Property

    <PersistentAlias("(UnitOneAmount * UnitTwoAmount)")>
    <XafDisplayName("Ποσότητα 2 Υπολογισμός")>
    Public ReadOnly Property UnitTwoCalculation() As Single
        Get
            Dim tempObject As Object
            tempObject = EvaluateAlias("UnitTwoCalculation")
            If tempObject IsNot Nothing Then
                Return CDbl(tempObject)
            Else
                Return 0
            End If
        End Get
    End Property

    Private _unitThree As InventoryItemCounterEnum
    <XafDisplayName("Μονάδα Μέτρησης 3")>
    Property UnitThree As InventoryItemCounterEnum
        Get
            Return _unitThree
        End Get
        Set(ByVal Value As InventoryItemCounterEnum)
            SetPropertyValue(NameOf(UnitThree), _unitThree, Value)
        End Set
    End Property

    Private _unitThreeAmount As Single
    <XafDisplayName("Ποσότητα 3")>
    Property UnitThreeAmount As Single
        Get
            Return _unitThreeAmount
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(UnitThreeAmount), _unitThreeAmount, Value)
        End Set
    End Property

    <PersistentAlias("(UnitTwoCalculation * UnitThreeAmount)")>
    <XafDisplayName("Ποσότητα 3 Υπολογισμός")>
    Public ReadOnly Property UnitThreeCalculation() As Single
        Get
            Dim tempObject As Object
            tempObject = EvaluateAlias("UnitThreeCalculation")
            If tempObject IsNot Nothing Then
                Return CDbl(tempObject)
            Else
                Return 0
            End If
        End Get
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
