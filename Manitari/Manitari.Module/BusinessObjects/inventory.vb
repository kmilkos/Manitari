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
<XafDisplayName("Απογραφή")>
<DefaultProperty("Display")>
<Persistent("Inventory")>
<NavigationItem("Αποθήκες")>
Public Class Inventory
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
    End Sub

    Private _theDate As DateTime
    <XafDisplayName("Ημερομηνία")>
    Property TheDate As DateTime
        Get
            Return _theDate
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(NameOf(TheDate), _theDate, Value)
        End Set
    End Property

    <Association("Inventory-InventoryItems"), DevExpress.Xpo.Aggregated>
    Public ReadOnly Property InventoryItems() As XPCollection(Of InventoryItem)
        Get
            Return GetCollection(Of InventoryItem)(NameOf(InventoryItems))
        End Get
    End Property

    <XafDisplayName("Περιγραφή")>
    Public ReadOnly Property Display As String
        Get
            'Return "TODO: Rebuild the inventory system"
            Return String.Format("{0} ({1})", TheDate.ToShortDateString, InventoryItems.Count.ToString)
        End Get
    End Property

End Class
