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
<XafDisplayName("Μονάδες Μέτρησης")>
<DefaultProperty("MetricName")>
<Persistent("Metric")>
<NavigationItem("Λειτουργία")>
Public Class Metric
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
    End Sub

    Private _metricName As String
    <Size(100)>
    Property MetricName As String
        Get
            Return _metricName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(MetricName), _metricName, Value)
        End Set
    End Property
    Private _description As String
    <Size(200)>
    Property Description As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Description), _description, Value)
        End Set
    End Property
End Class