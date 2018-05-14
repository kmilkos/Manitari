Imports Microsoft.VisualBasic
Imports System

Partial Public Class ManitariWindowsFormsApplication
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed otherwise, false.</param>
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
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.securityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex()
        Me.authenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
        Me.auditTrailModule = New DevExpress.ExpressApp.AuditTrail.AuditTrailModule()
        Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
        Me.chartModule = New DevExpress.ExpressApp.Chart.ChartModule()
        Me.chartWindowsFormsModule = New DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule()
        Me.cloneObjectModule = New DevExpress.ExpressApp.CloneObject.CloneObjectModule()
        Me.conditionalAppearanceModule = New DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule()
        Me.dashboardsModule = New DevExpress.ExpressApp.Dashboards.DashboardsModule()
        Me.dashboardsWindowsFormsModule = New DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule()
        Me.fileAttachmentsWindowsFormsModule = New DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule()
        Me.htmlPropertyEditorWindowsFormsModule = New DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditorWindowsFormsModule()
        Me.kpiModule = New DevExpress.ExpressApp.Kpi.KpiModule()
        Me.notificationsModule = New DevExpress.ExpressApp.Notifications.NotificationsModule()
        Me.notificationsWindowsFormsModule = New DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule()
        Me.pivotChartModuleBase = New DevExpress.ExpressApp.PivotChart.PivotChartModuleBase()
        Me.pivotChartWindowsFormsModule = New DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule()
        Me.pivotGridModule = New DevExpress.ExpressApp.PivotGrid.PivotGridModule()
        Me.pivotGridWindowsFormsModule = New DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule()
        Me.reportsModuleV2 = New DevExpress.ExpressApp.ReportsV2.ReportsModuleV2()
        Me.reportsWindowsFormsModuleV2 = New DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2()
        Me.schedulerModuleBase = New DevExpress.ExpressApp.Scheduler.SchedulerModuleBase()
        Me.schedulerWindowsFormsModule = New DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule()
        Me.scriptRecorderModuleBase = New DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase()
        Me.scriptRecorderWindowsFormsModule = New DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule()
        Me.stateMachineModule = New DevExpress.ExpressApp.StateMachine.StateMachineModule()
        Me.treeListEditorsModuleBase = New DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase()
        Me.treeListEditorsWindowsFormsModule = New DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule()
        Me.validationModule = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.validationWindowsFormsModule = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule()
        Me.viewVariantsModule = New DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule()
        Me.workflowModule = New DevExpress.ExpressApp.Workflow.WorkflowModule()
        Me.workflowWindowsFormsModule = New DevExpress.ExpressApp.Workflow.Win.WorkflowWindowsFormsModule()
        'Me.WizardUIWindowsFormsModule1 = New Xpand.ExpressApp.WizardUI.Win.WizardUIWindowsFormsModule()
        Me.module3 = New Manitari.[Module].ManitariModule()
        Me.module4 = New Manitari.[Module].Win.ManitariWindowsFormsModule()
        'Me.ImportWizardWindowsFormsModule1 = New Xpand.ExpressApp.ImportWizard.Win.ImportWizardWindowsFormsModule()
        'Me.ImportWizardModule1 = New Xpand.ExpressApp.ImportWizard.ImportWizardModule()
        'Me.XpandValidationModule1 = New Xpand.ExpressApp.Validation.XpandValidationModule()
        'Me.XpandSecurityModule1 = New Xpand.ExpressApp.Security.XpandSecurityModule()
        'Me.LogicModule1 = New Xpand.ExpressApp.Logic.LogicModule()
        'Me.XpandSecurityWinModule1 = New Xpand.ExpressApp.Security.Win.XpandSecurityWinModule()
        Me.LlamachantFrameworkModule1 = New LlamachantFramework.[Module].LlamachantFrameworkModule()
        Me.LlamachantFrameworkWindowsFormsModule2 = New LlamachantFramework.[Module].Win.LlamachantFrameworkWindowsFormsModule()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'securityStrategyComplex1
        '
        Me.securityStrategyComplex1.Authentication = Me.authenticationStandard1
        Me.securityStrategyComplex1.RoleType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole)
        Me.securityStrategyComplex1.SupportNavigationPermissionsForTypes = False
        Me.securityStrategyComplex1.UserType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser)
        '
        'authenticationStandard1
        '
        Me.authenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
        '
        'auditTrailModule
        '
        Me.auditTrailModule.AuditDataItemPersistentType = GetType(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent)
        '
        'dashboardsModule
        '
        Me.dashboardsModule.DashboardDataType = GetType(DevExpress.Persistent.BaseImpl.DashboardData)
        '
        'dashboardsWindowsFormsModule
        '
        Me.dashboardsWindowsFormsModule.DesignerFormStyle = DevExpress.XtraBars.Ribbon.RibbonFormStyle.Ribbon
        '
        'notificationsModule
        '
        Me.notificationsModule.CanAccessPostponedItems = False
        Me.notificationsModule.NotificationsRefreshInterval = System.TimeSpan.Parse("00:05:00")
        Me.notificationsModule.NotificationsStartDelay = System.TimeSpan.Parse("00:00:05")
        Me.notificationsModule.ShowDismissAllAction = False
        Me.notificationsModule.ShowNotificationsWindow = True
        Me.notificationsModule.ShowRefreshAction = False
        '
        'pivotChartModuleBase
        '
        Me.pivotChartModuleBase.DataAccessMode = DevExpress.ExpressApp.CollectionSourceDataAccessMode.Client
        Me.pivotChartModuleBase.ShowAdditionalNavigation = False
        '
        'reportsModuleV2
        '
        Me.reportsModuleV2.EnableInplaceReports = True
        Me.reportsModuleV2.ReportDataType = GetType(DevExpress.Persistent.BaseImpl.ReportDataV2)
        Me.reportsModuleV2.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML
        '
        'stateMachineModule
        '
        Me.stateMachineModule.StateMachineStorageType = GetType(DevExpress.ExpressApp.StateMachine.Xpo.XpoStateMachine)
        '
        'validationModule
        '
        Me.validationModule.AllowValidationDetailsAccess = True
        Me.validationModule.IgnoreWarningAndInformationRules = False
        '
        'workflowModule
        '
        Me.workflowModule.RunningWorkflowInstanceInfoType = GetType(DevExpress.ExpressApp.Workflow.Xpo.XpoRunningWorkflowInstanceInfo)
        Me.workflowModule.StartWorkflowRequestType = GetType(DevExpress.ExpressApp.Workflow.Xpo.XpoStartWorkflowRequest)
        Me.workflowModule.UserActivityVersionType = GetType(DevExpress.ExpressApp.Workflow.Versioning.XpoUserActivityVersion)
        Me.workflowModule.WorkflowControlCommandRequestType = GetType(DevExpress.ExpressApp.Workflow.Xpo.XpoWorkflowInstanceControlCommandRequest)
        Me.workflowModule.WorkflowDefinitionType = GetType(DevExpress.ExpressApp.Workflow.Xpo.XpoWorkflowDefinition)
        Me.workflowModule.WorkflowInstanceKeyType = GetType(DevExpress.Workflow.Xpo.XpoInstanceKey)
        Me.workflowModule.WorkflowInstanceType = GetType(DevExpress.Workflow.Xpo.XpoWorkflowInstance)
        '
        'ManitariWindowsFormsApplication
        '
        Me.ApplicationName = "Manitari"
        Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.auditTrailModule)
        Me.Modules.Add(Me.objectsModule)
        Me.Modules.Add(Me.chartModule)
        Me.Modules.Add(Me.cloneObjectModule)
        Me.Modules.Add(Me.conditionalAppearanceModule)
        Me.Modules.Add(Me.dashboardsModule)
        Me.Modules.Add(Me.validationModule)
        Me.Modules.Add(Me.kpiModule)
        Me.Modules.Add(Me.notificationsModule)
        Me.Modules.Add(Me.pivotChartModuleBase)
        Me.Modules.Add(Me.pivotGridModule)
        Me.Modules.Add(Me.reportsModuleV2)
        Me.Modules.Add(Me.schedulerModuleBase)
        Me.Modules.Add(Me.scriptRecorderModuleBase)
        Me.Modules.Add(Me.stateMachineModule)
        Me.Modules.Add(Me.treeListEditorsModuleBase)
        Me.Modules.Add(Me.viewVariantsModule)
        Me.Modules.Add(Me.workflowModule)
        Me.Modules.Add(Me.securityModule1)
        Me.Modules.Add(Me.LlamachantFrameworkModule1)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.chartWindowsFormsModule)
        Me.Modules.Add(Me.dashboardsWindowsFormsModule)
        Me.Modules.Add(Me.fileAttachmentsWindowsFormsModule)
        Me.Modules.Add(Me.htmlPropertyEditorWindowsFormsModule)
        Me.Modules.Add(Me.notificationsWindowsFormsModule)
        Me.Modules.Add(Me.pivotChartWindowsFormsModule)
        Me.Modules.Add(Me.pivotGridWindowsFormsModule)
        Me.Modules.Add(Me.reportsWindowsFormsModuleV2)
        Me.Modules.Add(Me.schedulerWindowsFormsModule)
        Me.Modules.Add(Me.scriptRecorderWindowsFormsModule)
        Me.Modules.Add(Me.treeListEditorsWindowsFormsModule)
        Me.Modules.Add(Me.validationWindowsFormsModule)
        Me.Modules.Add(Me.workflowWindowsFormsModule)
        Me.Modules.Add(Me.module4)
        Me.Security = Me.securityStrategyComplex1
        Me.UseOldTemplates = False
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
    Private module3 As Global.Manitari.Module.ManitariModule
    Private module4 As Global.Manitari.Module.Win.ManitariWindowsFormsModule
    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Private securityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    Private auditTrailModule As DevExpress.ExpressApp.AuditTrail.AuditTrailModule
    Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private chartModule As DevExpress.ExpressApp.Chart.ChartModule
    Private chartWindowsFormsModule As DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule
    Private cloneObjectModule As DevExpress.ExpressApp.CloneObject.CloneObjectModule
    Private conditionalAppearanceModule As DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule
    Private dashboardsModule As DevExpress.ExpressApp.Dashboards.DashboardsModule
    Private dashboardsWindowsFormsModule As DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule
    Private fileAttachmentsWindowsFormsModule As DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule
    Private htmlPropertyEditorWindowsFormsModule As DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditorWindowsFormsModule
    Private kpiModule As DevExpress.ExpressApp.Kpi.KpiModule
    Private notificationsModule As DevExpress.ExpressApp.Notifications.NotificationsModule
    Private notificationsWindowsFormsModule As DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule
    Private pivotChartModuleBase As DevExpress.ExpressApp.PivotChart.PivotChartModuleBase
    Private pivotChartWindowsFormsModule As DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule
    Private pivotGridModule As DevExpress.ExpressApp.PivotGrid.PivotGridModule
    Private pivotGridWindowsFormsModule As DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule
    Private reportsModuleV2 As DevExpress.ExpressApp.ReportsV2.ReportsModuleV2
    Private reportsWindowsFormsModuleV2 As DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2
    Private schedulerModuleBase As DevExpress.ExpressApp.Scheduler.SchedulerModuleBase
    Private schedulerWindowsFormsModule As DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule
    Private scriptRecorderModuleBase As DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase
    Private scriptRecorderWindowsFormsModule As DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule
    Private stateMachineModule As DevExpress.ExpressApp.StateMachine.StateMachineModule
    Private treeListEditorsModuleBase As DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase
    Private treeListEditorsWindowsFormsModule As DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule
    Private validationModule As DevExpress.ExpressApp.Validation.ValidationModule
    Private validationWindowsFormsModule As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule
    Private viewVariantsModule As DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule
    Private workflowModule As DevExpress.ExpressApp.Workflow.WorkflowModule
    Private workflowWindowsFormsModule As DevExpress.ExpressApp.Workflow.Win.WorkflowWindowsFormsModule
    Friend WithEvents LlamachantFrameworkModule1 As LlamachantFramework.Module.LlamachantFrameworkModule
    Friend WithEvents LlamachantFrameworkWindowsFormsModule1 As LlamachantFramework.Module.Win.LlamachantFrameworkWindowsFormsModule
    Friend WithEvents LlamachantFrameworkWindowsFormsModule2 As LlamachantFramework.Module.Win.LlamachantFrameworkWindowsFormsModule
End Class
