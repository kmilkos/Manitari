Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

<DefaultProperty("Title")>
<Persistent("Department")>
<DefaultClassOptions()>
<XafDisplayName("Τμήματα")>
Public Class Department ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _title As String
    Private _office As String

    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(value As String)
            SetPropertyValue("Title", _title, value)
        End Set
    End Property
    Public Property Office() As String
        Get
            Return _office
        End Get
        Set(value As String)
            SetPropertyValue("Office", _office, value)
        End Set
    End Property

    <DevExpress.Xpo.AssociationAttribute("Positions-Department")>
    Public ReadOnly Property Positions As XPCollection(Of Position)
        Get
            Return GetCollection(Of Position)("Positions")
        End Get
    End Property

    <DevExpress.Xpo.AssociationAttribute("Employees-Department")>
    Public ReadOnly Property Employees As XPCollection(Of Employee)
        Get
            Return GetCollection(Of Employee)("Employees")
        End Get
    End Property
End Class
