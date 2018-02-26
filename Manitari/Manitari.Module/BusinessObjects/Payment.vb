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
<XafDisplayName("Πληρωμές Πελατών")>
<ImageName("BO_Contact")>
<DefaultProperty("TheDate")>
<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)>
<Persistent("Payment")>
<NavigationItem("Πωλήσεις")>
Public Class Payment ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        _theDate = Now
    End Sub

    Private _theDate As DateTime
    <XafDisplayName("Ημερομηνία")>
    Property TheDate As DateTime
        Get
            Return _theDate
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(Nameof(TheDate), _theDate, Value)
        End Set
    End Property

    Private _ammount As Single
    <XafDisplayName("Ποσότητα")>
    Property Ammount As Single
        Get
            Return _ammount
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(Nameof(Ammount), _ammount, Value)
        End Set
    End Property

    <Association("Payment-Orders")>
    <XafDisplayName("Παραγγελίες")>
    Public ReadOnly Property Orders() As XPCollection(Of Order)
        Get
            Return GetCollection(Of Order)("Orders")
        End Get
    End Property
End Class
