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
<XafDisplayName("Μέτρηση")>
<NavigationItem("Παραγωγη")>
<DefaultProperty("Type")>
<Persistent("Measurement")>
Public Class Measurement
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        TheDate = Now
    End Sub

    Private _theDate As DateTime
    Property TheDate As DateTime
        Get
            Return _theDate
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue(Nameof(TheDate), _theDate, Value)
        End Set
    End Property
    
    Enum MeasurementTypeEnum
        Αμμωνία = 0
        ΚομπόσταΚιλά = 1
    End Enum

    Private _measurementType As MeasurementTypeEnum
    Property MeasurementType As MeasurementTypeEnum
        Get
            Return _measurementType
        End Get
        Set(ByVal Value As MeasurementTypeEnum)
            SetPropertyValue(Nameof(MeasurementType), _measurementType, Value)
        End Set
    End Property

    Private _measurement As Single
    Property Measurement As Single
        Get
            Return _measurement
        End Get
        Set(ByVal Value As Single)
            SetPropertyValue(Nameof(Measurement), _measurement, Value)
        End Set
    End Property

    Private _compost As Compost
    <Association("Compost-Measurements")>
    Property Compost() As Compost
        Get
            Return _compost
        End Get
        Set(ByVal Value As Compost)
            SetPropertyValue(NameOf(Compost), _compost, Value)
        End Set
    End Property
End Class
