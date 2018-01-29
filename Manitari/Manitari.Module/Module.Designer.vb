﻿Imports Microsoft.VisualBasic
Imports System

Partial Public Class ManitariModule
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        '
        'ManitariModule
        '
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.ModelDifference))
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect))
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.BaseObject))
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent))
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference))
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.FileData))
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.FileAttachmentBase))
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.Analysis))
        Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.HCategory))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.SystemModule.SystemModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.AuditTrail.AuditTrailModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Chart.ChartModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.CloneObject.CloneObjectModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Dashboards.DashboardsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Kpi.KpiModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Notifications.NotificationsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.PivotChart.PivotChartModuleBase))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.PivotGrid.PivotGridModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Scheduler.SchedulerModuleBase))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.StateMachine.StateMachineModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Validation.ValidationModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Workflow.WorkflowModule))

    End Sub

#End Region
End Class
