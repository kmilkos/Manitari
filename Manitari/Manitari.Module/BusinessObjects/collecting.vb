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

'<DefaultProperty("CompostCode")>
<DefaultClassOptions>
<XafDisplayName("Συγκομιδή")>
<ImageName("Action_StateMachine")>
<Persistent("collecting")>
<NavigationItem("Παραγωγή")>
Public Class collecting ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _compost As Compost
    <AssociationAttribute("Compost-Collectings")>
    <XafDisplayName("Κομπόστα")>
    Public Property Compost() As Compost
        Get
            Return _compost
        End Get
        Set(value As Compost)
            SetPropertyValue("Compost", _compost, value)
        End Set
    End Property


    Private _room As Integer
    <XafDisplayName("Θάλαμος")>
    Property room As Integer
        Get
            Return _room
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Nameof(room), _room, Value)
        End Set
    End Property

    Private _flush1 As Single
    <XafDisplayName("1ο Flush")>
    Property flush1 As Single
        Get
            Return _flush1
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush1), _flush1, Value)
        End Set
    End Property

    Private _flush2 As Single
    <XafDisplayName("2o flush")>
    Property flush2 As Single
        Get
            Return _flush2
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush2), _flush2, Value)
        End Set
    End Property

    Private _flush3 As Single
    <XafDisplayName("3ο flush")>
    Property flush3 As Single
        Get
            Return _flush3
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(NameOf(flush3), _flush3, Value)
        End Set
    End Property

    Function IsOdd(ByVal iNum As Integer) As Boolean
        IsOdd = ((iNum \ 2) * 2 <> iNum)
    End Function
End Class
