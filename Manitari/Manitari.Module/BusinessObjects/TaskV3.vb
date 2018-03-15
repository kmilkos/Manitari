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
Imports System.Xml
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Persistent.Base.General

<DefaultClassOptions>
<XafDisplayName("Εκκρέμότητα")>
<ImageName("BO_Task")>
<Persistent("Task")>
<NavigationItem("Λειτουργία")>
Public Class Task
    Inherits BaseObject
    Implements IComparable, IEvent

    Private _priority As PriorityEnum

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

        Priority = PriorityEnum.Normal
        SubmittedOn = Today
        AllDay = True
    End Sub

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

#Region "IEvent"
    <XafDisplayName("Θέμα")>
    Public Property Subject As String Implements IEvent.Subject
        Get
            Return GetPropertyValue("Subject")
        End Get
        Set(value As String)
            SetPropertyValue("Subject", value)
        End Set
    End Property

    <Size(SizeAttribute.Unlimited)>
    <XafDisplayName("Περιγραφή")>
    Public Property Description As String Implements IEvent.Description
        Get
            Return GetPropertyValue("Description")
        End Get
        Set(value As String)
            SetPropertyValue("Description", value)
        End Set
    End Property

    Private _submittedOn As DateTime
    <XafDisplayName("Καταχώρηση")>
    Property SubmittedOn As DateTime
        Get
            Return _submittedOn
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(Nameof(SubmittedOn), _submittedOn, Value)
        End Set
    End Property

    <XafDisplayName("Ξεκίνησε")>
    Public Property StartOn As Date Implements IEvent.StartOn
        Get
            Return GetPropertyValue("StartOn")
        End Get
        Set(value As Date)
            SetPropertyValue("StartOn", value)
        End Set
    End Property

    <XafDisplayName("Ολοκληρώθηκε")>
    Public Property EndOn As Date Implements IEvent.EndOn
        Get
            Return GetPropertyValue("EndOn")
        End Get
        Set(value As Date)
            SetPropertyValue("EndOn", value)
        End Set
    End Property

    <XafDisplayName("Ολοήμερο?")>
    Public Property AllDay As Boolean Implements IEvent.AllDay
        Get
            Return GetPropertyValue("AllDay")
        End Get
        Set(value As Boolean)
            SetPropertyValue("AllDay", value)
        End Set
    End Property

    <XafDisplayName("Τοποθεσία")>
    Public Property Location As String Implements IEvent.Location
        Get
            Return GetPropertyValue("Location")
        End Get
        Set(value As String)
            SetPropertyValue("Location", value)
        End Set
    End Property

    <XafDisplayName("Ετικέτα")>
    Public Property Label As Integer Implements IEvent.Label
        Get
            Return GetPropertyValue("Label")
        End Get
        Set(value As Integer)
            SetPropertyValue("Label", value)
        End Set
    End Property

    <XafDisplayName("Κατάσταση")>
    Public Property Status As Integer Implements IEvent.Status
        Get
            Return GetPropertyValue("Status")
        End Get
        Set(value As Integer)
            SetPropertyValue("Status", value)
        End Set
    End Property

    <XafDisplayName("Τύπος")>
    Public Property Type As Integer Implements IEvent.Type
        Get
            Return GetPropertyValue("Type")
        End Get
        Set(value As Integer)
            SetPropertyValue("Type", value)
        End Set
    End Property

    Public Property ResourceId As String Implements IEvent.ResourceId
        Get
            Return GetPropertyValue("ResourceId")
        End Get
        Set(value As String)
            SetPropertyValue("ResourceId", value)
        End Set
    End Property

    Public ReadOnly Property AppointmentId As Object Implements IEvent.AppointmentId
        Get
            Return GetPropertyValue("AppointmentId")
        End Get
    End Property
#End Region

#Region "ITask"
    Private _taskStatus As TaskStatusEnum
    <XafDisplayName("Κατάσταση")>
    Property TaskStatus As TaskStatusEnum
        Get
            Return _taskStatus
        End Get
        Set(ByVal Value As TaskStatusEnum)
            SetPropertyValue(NameOf(TaskStatus), _taskStatus, Value)
        End Set
    End Property
#End Region

#Region "Actions"
    <Action(Caption:="Postpone", ImageName:="State_Task_Deferred")>
    Public Sub Postpone()
        If (EndOn = DateTime.MinValue) Then
            EndOn = DateTime.Now
        End If

        EndOn = EndOn + TimeSpan.FromDays(1)
    End Sub

    <Action(Caption:="Mark Completed", ImageName:="State_Task_Completed")>
    Public Sub MarkCompleted()
        'SetPropertyValue("Status", TaskStatusEnum.Completed)
        SetPropertyValue("TaskStatus", TaskStatusEnum.Completed)
        SetPropertyValue("EndOn", Today)
    End Sub
#End Region

    Private _category As Category
    '<DataSourceCriteria("Department.Title = 'Παραγωγή'")>
    <DevExpress.Xpo.AssociationAttribute("Tasks-Category")>
    <XafDisplayName("Κατηγορία")>
    Public Property Category As Category
        Get
            Return _category
        End Get
        Set
            SetPropertyValue("Category", _category, Value)
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return This.Subject
    End Function

    Public Property Priority As PriorityEnum
        Get
            Return _priority
        End Get
        Set(value As PriorityEnum)
            SetPropertyValue("Priority", _priority, value)
        End Set
    End Property

    Public Enum PriorityEnum
        <ImageName("State_Priority_Low")>
        Low = 0
        <ImageName("State_Priority_Normal")>
        Normal = 1
        <ImageName("State_Priority_High")>
        High = 2
    End Enum

    Public Enum TaskStatusEnum As Integer
        NotStarted = 0
        InProgress = 1
        Deffered = 2
        WaitingSomeoneElse = 3
        Completed = 4
    End Enum
End Class
