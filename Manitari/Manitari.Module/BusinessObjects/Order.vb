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
<XafDisplayName("Παραγγελία")>
<ImageName("BO_Contact")>
<DefaultProperty("TheDate")>
<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)>
<Persistent("Order")>
<NavigationItem("Πωλήσεις")>
Public Class Order
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        _theDate = Now

    End Sub

    <Action(Caption:="Send By Email", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)>
    Public Sub ActionMethod()
        ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        '    Me.PersistentProperty = "Paid"
    End Sub

    Private _theDate As DateTime
    Property TheDate As DateTime
        Get
            Return _theDate
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(NameOf(TheDate), _theDate, Value)
        End Set
    End Property

    Private _customer As Customer
    <Association("Customer-Orders")>
    Property Customer() As Customer
        Get
            Return _customer
        End Get
        Set(ByVal Value As Customer)
            SetPropertyValue(NameOf(Customer), _customer, Value)
        End Set
    End Property

    Private _paperID As String
    <Size(5)>
    Property PaperID As String
        Get
            Return _paperID
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(PaperID), _paperID, Value)
        End Set
    End Property


    <Association("Order-OrderDetails")>
    Public ReadOnly Property OrderDetails() As XPCollection(Of OrderDetail)
        Get
            Return GetCollection(Of OrderDetail)("OrderDetails")
        End Get
    End Property

    'Πληρώθηκε απο πληρωμή ##link to another table##
    Private _payment As Payment
    <Association("Payment-Orders")>
    Property Payment() As Payment
        Get
            Return _payment
        End Get
        Set(ByVal Value As Payment)
            SetPropertyValue(NameOf(Payment), _payment, Value)
        End Set
    End Property

    Private fOrdersTotal As Nullable(Of Decimal) = Nothing
    Public ReadOnly Property OrdersTotal() As Nullable(Of Decimal)
        Get
            If (Not IsLoading) AndAlso (Not IsSaving) AndAlso Not fOrdersTotal.HasValue Then
                UpdateOrdersTotal(False)
            End If
            Return fOrdersTotal
        End Get
    End Property

    Public Sub UpdateOrdersTotal(ByVal forceChangeEvents As Boolean)
        Dim oldOrdersTotal As Nullable(Of Decimal) = fOrdersTotal
        Dim tempTotal As Decimal = 0D
        For Each detail As OrderDetail In OrderDetails
            tempTotal += detail.Linetotal
        Next detail
        fOrdersTotal = tempTotal
        If forceChangeEvents Then
            OnChanged("OrdersTotal", oldOrdersTotal, fOrdersTotal)
        End If
    End Sub
End Class
