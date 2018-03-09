Imports DevExpress.ExpressApp.Model
Imports System.Xml
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.Base.General
Imports DevExpress.ExpressApp.DC

<DefaultClassOptions>
<Persistent("FarmAction")>
<DC.XafDisplayName("Εργασίες Παραγωγής")>
<NavigationItem("Παραγωγή")>
Public Class FarmAction
    Inherits BaseObject

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
    End Sub

    Private _name As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    <XafDisplayName("Τίτλος")>
    Property Name As String
        Get
            Return _name
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Name), _name, Value)
        End Set
    End Property

    Private _category As Category
    <DataSourceCriteria("Department.Title = 'Παραγωγή'")>
    <XafDisplayName("Κατηγορία")>
    Property Category As Category
        Get
            Return _category
        End Get
        Set(ByVal Value As Category)
            SetPropertyValue(NameOf(Category), _category, Value)
        End Set
    End Property


End Class