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

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
<DefaultClassOptions()> _
Public Class Watering ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        _thedate = Now
    End Sub

    Private _thedate As DateTime
    Public Property TheDate As DateTime
        Get
            Return _thedate

        End Get
        Set(value As DateTime)
            SetPropertyValue("TheDate", _thedate, value)
        End Set
    End Property

    Private _compost As Compost
    <AssociationAttribute("Compost-Waterings")>
    Public Property Compost() As Compost
        Get
            Return _compost
        End Get
        Set(value As Compost)
            SetPropertyValue("Compost", _compost, value)
        End Set
    End Property

    Private _room As String
    Public Property Room As String
        Get
            Return _room
        End Get
        Set(value As String)
            SetPropertyValue("Room", _room, value)
        End Set
    End Property
    Private _quantity As Single
    Public Property Quantity As Single
        Get
            Return _quantity
        End Get
        Set(value As Single)
            SetPropertyValue("Quantity", _quantity, value)
        End Set
    End Property
    Private _waterammount As Single
    Public Property WaterAmmount As Single
        Get
            Return _waterammount

        End Get
        Set(value As Single)
            SetPropertyValue("WaterAmmount", _waterammount, value)
        End Set
    End Property
    Private _starttime As DateTime
    Public Property StartTime As DateTime
        Get
            Return _starttime
        End Get
        Set(value As DateTime)
            SetPropertyValue("StartTime", _starttime, value)
        End Set
    End Property

    <Size(4096)>
    Private _notes As String
    Public Property Notes As String
        Get
            Return _notes
        End Get
        Set(value As String)
            SetPropertyValue("Notes", _notes, value)
        End Set
    End Property

    <PersistentAlias("(WaterAmmount * Quantity)")>
    Public ReadOnly Property LiterTotal() As Single
        Get
            Dim tempObject As Object
            tempObject = EvaluateAlias("LiterTotal")
            If tempObject IsNot Nothing Then
                Return CDbl(tempObject)
            Else
                Return 0
            End If
        End Get
    End Property
End Class
