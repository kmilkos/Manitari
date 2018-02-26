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
<XafDisplayName("Ικανότητα")>
<NavigationItem("Προσωπικό")>
<DefaultProperty("Title")>
<Persistent("Skill")>
Public Class Skill ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

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

    <DevExpress.Xpo.AssociationAttribute("Skills-Position")>
    <XafDisplayName("Θέσεις Εργασίας")>
    Public ReadOnly Property Positions As XPCollection(Of Position)
        Get
            Return GetCollection(Of Position)("Positions")
        End Get
    End Property

    <DevExpress.Xpo.AssociationAttribute("Skills-Employee")>
    <XafDisplayName("Προσωπικό")>
    Public ReadOnly Property Employees As XPCollection(Of Employee)
        Get
            Return GetCollection(Of Employee)("Employees")
        End Get
    End Property

    Public Enum JobTypeEnum
        Γενικά
        Καθημερινά
        Εβδομαδιαία
    End Enum
End Class
