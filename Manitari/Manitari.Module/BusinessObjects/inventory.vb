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

<DefaultProperty("Display")>
<Persistent("Inventory")>
<NavigationItem("Reports")>
<DefaultClassOptions()> _
Public Class inventory ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
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

    <AssociationAttribute("inventory-inventorylistitems")>
    Public ReadOnly Property inventorylistitems() As XPCollection(Of inventorylistitem)
        Get
            Return GetCollection(Of inventorylistitem)("inventorylistitems")
        End Get
    End Property

    Public ReadOnly Property Display As String
        Get
            Return String.Format("{0} ({1})", TheDate.ToShortDateString, inventorylistitems.Count.ToString)
        End Get
    End Property

End Class
