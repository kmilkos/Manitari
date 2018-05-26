Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

<DefaultClassOptions()>
<DefaultProperty("Title")>
<Persistent("Department")>
<XafDisplayName("Τμήματα")>
<ImageName("BO_Organization")>
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

    <XafDisplayName("Τίτλος")>
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(value As String)
            SetPropertyValue("Title", _title, value)
        End Set
    End Property
    <XafDisplayName("Γραφείο")>
    Public Property Office() As String
        Get
            Return _office
        End Get
        Set(value As String)
            SetPropertyValue("Office", _office, value)
        End Set
    End Property

    <DevExpress.Xpo.AssociationAttribute("Positions-Department")>
    <XafDisplayName("Θέσεις Εργασίας")>
    Public ReadOnly Property Positions As XPCollection(Of Position)
        Get
            Return GetCollection(Of Position)("Positions")
        End Get
    End Property

    <DevExpress.Xpo.AssociationAttribute("Employees-Department")>
    <XafDisplayName("Προσωπικό")>
    Public ReadOnly Property Employees As XPCollection(Of Employee)
        Get
            Return GetCollection(Of Employee)("Employees")
        End Get
    End Property
End Class
