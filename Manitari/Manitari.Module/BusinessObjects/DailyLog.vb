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
Imports DevExpress.Persistent.Base.General
Imports DevExpress.Xpo.Metadata
Imports System.Xml

<DefaultClassOptions>
<DC.XafDisplayName("Ημερήσιο Αρχείο")>
<Persistent("DailyLog")>
<NavigationItem("Παραγωγή")>
Public Class DailyLog
    Inherits BaseObject
    Implements IEvent

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

        TheDate = Today
        StartOn = Today
        EndOn = Today
    End Sub

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

    Private _operation As Category
    <Association("Category-DailyLogs")>
    <DataSourceCriteria("Department.Title = 'Παραγωγή'")>
    <XafDisplayName("Κατηγορία")>
    Property Operation() As Category
        Get
            Return _operation
        End Get
        Set(ByVal Value As Category)
            SetPropertyValue(NameOf(Operation), _operation, Value)
        End Set
    End Property

    <Association("Employee-DailyLogs")>
    <XafDisplayName("Εργαζόμενοι")>
    Public ReadOnly Property Employees() As XPCollection(Of Employee)
        Get
            Return GetCollection(Of Employee)(NameOf(Employees))
        End Get
    End Property


#Region "IEvent"
    Private _notes As String
    <Size(SizeAttribute.Unlimited)>
    <XafDisplayName("Σημειώσεις")>
    Property Notes As String Implements IEvent.Description
        Get
            Return _notes
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Notes), _notes, Value)
        End Set
    End Property

    Private _subject As String
    '<Browsable(False)>
    Public Property Subject As String Implements IEvent.Subject
        Get
            If IsNothing(Operation) Then
                Return _subject
            Else
                Return Operation.Caption
            End If
        End Get
        Set(value As String)
            If IsNothing(Operation) Then
                SetPropertyValue("Subject", _subject, value)
            Else
                SetPropertyValue("Subject", _subject, Operation.Caption)
            End If

        End Set
    End Property

    <Browsable(False)>
    Public Property StartOn As Date Implements IEvent.StartOn
        Get
            Return _theDate
        End Get
        Set(value As Date)
            SetPropertyValue("StartOn", _theDate)
        End Set
    End Property

    <Browsable(False)>
    Public Property EndOn As Date Implements IEvent.EndOn
        Get
            Return _theDate
        End Get
        Set(value As Date)
            SetPropertyValue("EndOn", StartOn.AddDays(1))
        End Set
    End Property

    <Browsable(False)>
    Public Property AllDay As Boolean Implements IEvent.AllDay
        Get
            Return True
        End Get
        Set(value As Boolean)
            SetPropertyValue("AllDay", True)
        End Set
    End Property

    Private _location As String
    Public Property Location As String Implements IEvent.Location
        Get
            Return _location
        End Get
        Set(value As String)
            SetPropertyValue("Location", _location, value)
        End Set
    End Property

    <Browsable(False)>
    Public Property Label As Integer Implements IEvent.Label
        Get
            Return 0
        End Get
        Set(value As Integer)
            SetPropertyValue("Label", value)
        End Set
    End Property

    <Browsable(False)>
    Public Property Status As Integer Implements IEvent.Status
        Get
            Return 0
        End Get
        Set(value As Integer)
            SetPropertyValue("Status", value)
        End Set
    End Property

    <Browsable(False)>
    Public Property Type As Integer Implements IEvent.Type
        Get
            Return 0
        End Get
        Set(value As Integer)
            SetPropertyValue("Type", value)
        End Set
    End Property

    <Browsable(False)>
    <Size(SizeAttribute.Unlimited)>
    Public Property ResourceId As String Implements IEvent.ResourceId
        Get
            ResourceId = Nothing
            Return ResourceId
        End Get
        Set(value As String)
            SetPropertyValue("ResourceId", value)
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property AppointmentId As Object Implements IEvent.AppointmentId
        Get
            Return Oid
        End Get
    End Property
#End Region
End Class
