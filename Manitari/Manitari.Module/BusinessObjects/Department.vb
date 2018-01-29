Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

<DefaultClassOptions()>
<DefaultProperty("Title")>
<Persistent("Department")>
<XafDisplayName("Τμήματα")>
<NavigationItem("Λειτουργία")>
Public Class Department
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

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
