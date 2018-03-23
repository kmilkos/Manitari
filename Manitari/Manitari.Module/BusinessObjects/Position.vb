Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.DC

<DefaultClassOptions>
<XafDisplayName("Θέσεις Εργασίας")>
<NavigationItem("Προσωπικό")>
<DefaultProperty("Title")>
<Persistent("Position")>
Public Class Position ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _title As String
    <XafDisplayName("Τίτλος")>
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(value As String)
            SetPropertyValue("Title", _title, value)
        End Set
    End Property

    <DevExpress.Xpo.AssociationAttribute("Position-Employees")>
    <XafDisplayName("Προσωπικό")>
    Public ReadOnly Property Employees As XPCollection(Of Employee)
        Get
            Return GetCollection(Of Employee)("Employees")
        End Get
    End Property

    Private _department As Department
    <DevExpress.Xpo.AssociationAttribute("Positions-Department")>
    <XafDisplayName("Τμήμα")>
    Public Property Department As Department
        Get
            Return _department
        End Get
        Set(ByVal value As Department)
            SetPropertyValue("Department", _department, value)
        End Set
    End Property
End Class
