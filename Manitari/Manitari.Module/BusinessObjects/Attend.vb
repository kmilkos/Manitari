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
<XafDisplayName("Ωρολόγιο")>
<NavigationItem("Προσωπικό")>
<Persistent("Attend")>
Public Class Attend ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        _theDate = Now
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _employee As Employee
    Property Employee As Employee
        Get
            Return _employee
        End Get
        Set(ByVal Value As Employee)
            SetPropertyValue(Nameof(Employee), _employee, Value)
        End Set
    End Property

    Private _theDate As DateTime
    Property TheDate As DateTime
        Get
            Return _theDate
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(Nameof(TheDate), _theDate, Value)
        End Set
    End Property

    Private _startTime As TimeSpan
    Property StartTime As TimeSpan
        Get
            Return _startTime
        End Get
        Set(ByVal Value As TimeSpan)
            SetPropertyValue(NameOf(StartTime), _startTime, Value)
        End Set
    End Property

    Private _endtime As TimeSpan
    Property EndTime As TimeSpan
        Get
            Return _endtime
        End Get
        Set(ByVal Value As TimeSpan)
            SetPropertyValue(NameOf(EndTime), _endtime, Value)
        End Set
    End Property

    Public ReadOnly Property TotalHours() As TimeSpan
        Get
            TotalHours = _endtime - _startTime
        End Get
    End Property

    '<Action(Caption:="My UI Action", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)> _
    'Public Sub ActionMethod()
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
