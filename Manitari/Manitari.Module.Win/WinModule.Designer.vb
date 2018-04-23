Imports Microsoft.VisualBasic
Imports System

Partial Public Class ManitariWindowsFormsModule
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
        'ManitariWindowsFormsModule
        '
        Me.RequiredModuleTypes.Add(GetType(Manitari.[Module].ManitariModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(Xpand.ExpressApp.ImportWizard.Win.ImportWizardWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(Xpand.ExpressApp.Security.Win.XpandSecurityWinModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditorWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Workflow.Win.WorkflowWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(LlamachantFramework.[Module].Win.LlamachantFrameworkWindowsFormsModule))

    End Sub

#End Region
End Class