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
<DefaultProperty("Location")>
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

    Private _location As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    Property Location As String
        Get
            Return _location
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Nameof(Location), _location, Value)
        End Set
    End Property
    

    <Association("Warehouse-WarehouseItems")>
    Public ReadOnly Property WarehouseItems() As XPCollection(Of WarehouseItem)
        Get
            Return GetCollection(Of WarehouseItem)(NameOf(WarehouseItems))
        End Get
    End Property

End Class
