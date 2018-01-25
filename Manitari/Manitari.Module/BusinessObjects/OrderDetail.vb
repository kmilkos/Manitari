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

'<ImageName("BO_Contact")>
'<DefaultProperty("FullName")>
<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)>
<Persistent("OrderDetail")>
<DefaultClassOptions()> _
Public Class OrderDetail ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _order As Order
    <Association("Order-OrderDetails")>
    <Browsable(False)>
    Property order() As Order
        Get
            Return _order
        End Get
        Set(ByVal Value As Order)
            SetPropertyValue(NameOf(order), _order, Value)
        End Set
    End Property

    Private _mushroom As Mushroom
    Property Mushroom As Mushroom
        Get
            Return _mushroom
        End Get
        Set(ByVal Value As Mushroom)
            SetPropertyValue(Nameof(Mushroom), _mushroom, Value)
        End Set
    End Property


    Private _quantity As Single
    Property Quantity As Single
        Get
            Return _quantity
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(Quantity), _quantity, Value)
        End Set
    End Property

    Private _priceperkilo As Single
    Property Priceperkilo As Single
        Get
            Return _priceperkilo
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(Priceperkilo), _priceperkilo, Value)
        End Set
    End Property

    Private _discount As Single
    Property Discount As Single
        Get
            Return _discount
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(Nameof(Discount), _discount, Value)
        End Set
    End Property


    <PersistentAlias("(Priceperkilo * Quantity)-Discount")>
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
End Class
