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
<DefaultProperty("Title")>
<Persistent("Skillset")>
<XafDisplayName("Σετ Ικανοτήτων")>
Public Class Skillset
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _skill As Skill
    Property Skill As Skill
        Get
            Return _skill
        End Get
        Set(ByVal Value As Skill)
            SetPropertyValue(Nameof(Skill), _skill, Value)
        End Set
    End Property
    

    Private _employee As Employee
    <Association("Employee-Skillsets")> _
    Property Employee() As Employee
        Get
            Return _employee
        End Get
        Set(ByVal Value As Employee)
            SetPropertyValue(Nameof(Employee), _employee, Value)
        End Set
    End Property
    
End Class
