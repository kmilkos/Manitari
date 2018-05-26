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
<DC.XafDisplayName("Λεπτομέρειες Παραγγελίας")>
<ImageName("BO_Order_Item")>
<NavigationItem("Πωλήσεις")>
<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)>
<Persistent("OrderDetail")>
Public Class OrderDetail ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

    Dim FPA As Single = 0.13

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub
    Public Overrides Function Equals(obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Private _order As Order
    <Association("Order-OrderDetails")>
    <Browsable(False)>
    Property Order() As Order
        Get
            Return _order
        End Get
        Set(ByVal Value As Order)
            SetPropertyValue(NameOf(Order), _order, Value)
        End Set
    End Property

    Private _mushroom As Mushroom
    <XafDisplayName("Μανιτάρι")>
    Property Mushroom As Mushroom
        Get
            Return _mushroom
        End Get
        Set(ByVal Value As Mushroom)
            SetPropertyValue(Nameof(Mushroom), _mushroom, Value)
        End Set
    End Property

    Private _quantity As Single
    <XafDisplayName("Ποσότητα")>
    Property Quantity As Single
        Get
            Return _quantity
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(Quantity), _quantity, Value)
        End Set
    End Property

    Private _priceperkilo As Single
    <XafDisplayName("Τιμή Κιλού")>
    Property Priceperkilo As Single
        Get
            Return _priceperkilo
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(Priceperkilo), _priceperkilo, Value)
        End Set
    End Property

    Private _discount As Single
    <XafDisplayName("Εκπτωση")>
    Property Discount As Single
        Get
            Return _discount
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(Nameof(Discount), _discount, Value)
        End Set
    End Property


    <PersistentAlias("(Priceperkilo * Quantity)-Discount")>
    <XafDisplayName("Τελική Τιμή")>
    Public ReadOnly Property Linetotal() As Single
        Get
            Dim tempObject As Object
            tempObject = EvaluateAlias("Linetotal")
            If tempObject IsNot Nothing Then
                Return CDbl(tempObject)
            Else
                Return 0
            End If
        End Get
    End Property

    <XafDisplayName("Φ.Π.Α.")>
    Public ReadOnly Property TotalFpa() As Single
        Get
            Return Linetotal * FPA
        End Get
    End Property

    <PersistentAlias("Linetotal + TotalFpa")>
    <XafDisplayName("Συνολο Τελικό")>
    Public ReadOnly Property TotalPrice() As Single
        Get
            Dim tempObject As Object
            tempObject = EvaluateAlias("TotalPrice")
            If tempObject IsNot Nothing Then
                Return CDbl(tempObject)
            Else
                Return 0
            End If
        End Get
    End Property
End Class
