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
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Xpo

<DefaultClassOptions>
<ImageName("Calender")>
<XafDisplayName("Ωρολόγιο")>
<NavigationItem("Προσωπικό")>
<Persistent("Attend")>
Public Class Attend
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        _theDate = Now
    End Sub

    Private _employee As Employee
    <Association("Employee-Attends")>
    <XafDisplayName("Εργαζόμενος")>
    Property Employee() As Employee
        Get
            Return _employee
        End Get
        Set(ByVal Value As Employee)
            SetPropertyValue(NameOf(Employee), _employee, Value)
        End Set
    End Property

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

    Private _startTime As DateTime
    <XafDisplayName("Ωρα Εκκίνησης")>
    Property StartTime As DateTime
        Get
            Return _startTime
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(NameOf(StartTime), _startTime, Value)
        End Set
    End Property

    Private _endtime As DateTime
    <XafDisplayName("Ωρα Αποχώρησης")>
    Property EndTime As DateTime
        Get
            Return _endtime
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(NameOf(EndTime), _endtime, Value)
        End Set
    End Property

    <XafDisplayName("Σύνολο Ωρών")>
    Public ReadOnly Property TotalHours() As TimeSpan
        Get
            TotalHours = _endtime - _startTime
        End Get
    End Property
End Class
