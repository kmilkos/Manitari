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

<DefaultClassOptions()>
<XafDisplayName("Αποθήκη")>
<NavigationItem("Αποθήκες")>
<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)>
<Persistent("Warehouse")>
Public Class Warehouse ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _item As inventoryitem
    <XafDisplayName("Αντικείμενο")>
    Property Item As inventoryitem
        Get
            Return _item
        End Get
        Set(ByVal Value As inventoryitem)
            SetPropertyValue(Nameof(Item), _item, Value)
        End Set
    End Property

    Private _amount As Single
    <XafDisplayName("Ποσότητα")>
    Property Amount As Single
        Get
            Return _amount
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(Amount), _amount, Value)
        End Set
    End Property
End Class
