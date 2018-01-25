Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Mobile
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Security.ClientServer


' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
Partial Public Class ManitariMobileApplication
    Inherits MobileApplication
    Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Mobile.SystemModule.SystemMobileModule
    Private module3 As Manitari.Module.ManitariModule
    Private module4 As Manitari.Module.Mobile.ManitariMobileModule

    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Private securityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    Private auditTrailModule As DevExpress.ExpressApp.AuditTrail.AuditTrailModule
    Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private chartModule As DevExpress.ExpressApp.Chart.ChartModule
    Private cloneObjectModule As DevExpress.ExpressApp.CloneObject.CloneObjectModule
    Private cloneObjectMobileModule As DevExpress.ExpressApp.CloneObject.Mobile.CloneObjectMobileModule
    Private conditionalAppearanceModule As DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule
    Private conditionalAppearanceMobileModule As DevExpress.ExpressApp.ConditionalAppearance.Mobile.ConditionalAppearanceMobileModule
    Private dashboardsModule As DevExpress.ExpressApp.Dashboards.DashboardsModule
    Private fileAttachmentsMobileModule As DevExpress.ExpressApp.FileAttachments.Mobile.FileAttachmentsMobileModule
    Private kpiModule As DevExpress.ExpressApp.Kpi.KpiModule
    Private localizationMobileModule As DevExpress.ExpressApp.Localization.Mobile.LocalizationMobileModule
    Private mapsMobileModule As DevExpress.ExpressApp.Maps.Mobile.MapsMobileModule
    Private notificationsModule As DevExpress.ExpressApp.Notifications.NotificationsModule
    Private pivotChartModuleBase As DevExpress.ExpressApp.PivotChart.PivotChartModuleBase
    Private pivotGridModule As DevExpress.ExpressApp.PivotGrid.PivotGridModule
    Private reportsModuleV2 As DevExpress.ExpressApp.ReportsV2.ReportsModuleV2
    Private reportsMobileModuleV2 As DevExpress.ExpressApp.ReportsV2.Mobile.ReportsMobileModuleV2
    Private schedulerModuleBase As DevExpress.ExpressApp.Scheduler.SchedulerModuleBase
    Private scriptRecorderModuleBase As DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase
    Private stateMachineModule As DevExpress.ExpressApp.StateMachine.StateMachineModule
    Private treeListEditorsModuleBase As DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase
    Private validationModule As DevExpress.ExpressApp.Validation.ValidationModule
    Private validationMobileModule As DevExpress.ExpressApp.Validation.Mobile.ValidationMobileModule
    Private viewVariantsModule As DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule
    Private workflowModule As DevExpress.ExpressApp.Workflow.WorkflowModule

#Region "Default XAF configuration options (https://www.devexpress.com/kb=T501418)"
    Shared Sub New()
        DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = True
        DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = False
    End Sub
    Private Sub InitializeDefaults()
        LinkNewObjectToParentImmediately = False
    End Sub
#End Region
    Public Sub New()
		SecurityAdapterHelper.Enable()
		Tracing.Initialize()
        If (Not ConfigurationManager.ConnectionStrings.Item("ConnectionString") Is Nothing) Then
            ConnectionString = ConfigurationManager.ConnectionStrings.Item("ConnectionString").ConnectionString
        End If
#If EASYTEST Then
        If (Not ConfigurationManager.ConnectionStrings.Item("EasyTestConnectionString") Is Nothing) Then
            ConnectionString = ConfigurationManager.ConnectionStrings.Item("EasyTestConnectionString").ConnectionString
        End If
#End If
        InitializeComponent()
		InitializeDefaults()
#If DEBUG Then
        If System.Diagnostics.Debugger.IsAttached AndAlso CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema Then
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        End If
#End If
    End Sub
    Protected Overrides Sub SetLogonParametersForUIBuilder(logonParameters As Object)
        MyBase.SetLogonParametersForUIBuilder(logonParameters)
        DirectCast(logonParameters, AuthenticationStandardLogonParameters).UserName = "Admin"
        DirectCast(logonParameters, AuthenticationStandardLogonParameters).Password = ""
    End Sub
    Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
        args.ObjectSpaceProvider = New SecuredObjectSpaceProvider(DirectCast(Me.Security, ISelectDataSecurityProvider), GetDataStoreProvider(args.ConnectionString, args.Connection), True)
        args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
    End Sub
    Private Function GetDataStoreProvider(ByVal connectionString As String, ByVal connection As System.Data.IDbConnection) As IXpoDataStoreProvider
        Dim application As System.Web.HttpApplicationState = If((System.Web.HttpContext.Current IsNot Nothing), System.Web.HttpContext.Current.Application, Nothing)
        Dim dataStoreProvider As IXpoDataStoreProvider = Nothing
        If Not application Is Nothing AndAlso application("DataStoreProvider") IsNot Nothing Then
            dataStoreProvider = TryCast(application("DataStoreProvider"), IXpoDataStoreProvider)
        Else
            If Not String.IsNullOrEmpty(connectionString) Then
                dataStoreProvider = New ConnectionStringDataStoreProvider(connectionString)
            ElseIf Not connection Is Nothing Then
                dataStoreProvider = New ConnectionDataStoreProvider(connection)
            End If
            If Not application Is Nothing Then
                application("DataStoreProvider") = dataStoreProvider
            End If
        End If
        Return dataStoreProvider
    End Function
    Private Sub ManitariMobileApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
        e.Updater.Update()
        e.Handled = True
#Else
        If System.Diagnostics.Debugger.IsAttached Then
            e.Updater.Update()
            e.Handled = True
        Else
            Dim message As String = "The application cannot connect to the specified database, " & _
                "because the database doesn't exist, its version is older " & _
                "than that of the application or its schema does not match " & _
                "the ORM data model structure. To avoid this error, use one " & _
                "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article."

            If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
                message &= Constants.vbCrLf & Constants.vbCrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
            End If
            Throw New InvalidOperationException(message)
        End If
#End If
    End Sub
    Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Mobile.SystemModule.SystemMobileModule()
        Me.module3 = New Manitari.Module.ManitariModule()
        Me.module4 = New Manitari.Module.Mobile.ManitariMobileModule()
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.securityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex()
        Me.authenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
        Me.auditTrailModule = New DevExpress.ExpressApp.AuditTrail.AuditTrailModule()
        Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
        Me.chartModule = New DevExpress.ExpressApp.Chart.ChartModule()
        Me.cloneObjectModule = New DevExpress.ExpressApp.CloneObject.CloneObjectModule()
        Me.cloneObjectMobileModule = New DevExpress.ExpressApp.CloneObject.Mobile.CloneObjectMobileModule()
        Me.conditionalAppearanceModule = New DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule()
        Me.conditionalAppearanceMobileModule = New DevExpress.ExpressApp.ConditionalAppearance.Mobile.ConditionalAppearanceMobileModule()
        Me.dashboardsModule = New DevExpress.ExpressApp.Dashboards.DashboardsModule()
        Me.fileAttachmentsMobileModule = New DevExpress.ExpressApp.FileAttachments.Mobile.FileAttachmentsMobileModule()
        Me.kpiModule = New DevExpress.ExpressApp.Kpi.KpiModule()
        Me.localizationMobileModule = New DevExpress.ExpressApp.Localization.Mobile.LocalizationMobileModule()
        Me.mapsMobileModule = New DevExpress.ExpressApp.Maps.Mobile.MapsMobileModule()
        Me.notificationsModule = New DevExpress.ExpressApp.Notifications.NotificationsModule()
        Me.pivotChartModuleBase = New DevExpress.ExpressApp.PivotChart.PivotChartModuleBase()
        Me.pivotGridModule = New DevExpress.ExpressApp.PivotGrid.PivotGridModule()
        Me.reportsModuleV2 = New DevExpress.ExpressApp.ReportsV2.ReportsModuleV2()
        Me.reportsMobileModuleV2 = New DevExpress.ExpressApp.ReportsV2.Mobile.ReportsMobileModuleV2()
        Me.schedulerModuleBase = New DevExpress.ExpressApp.Scheduler.SchedulerModuleBase()
        Me.scriptRecorderModuleBase = New DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase()
        Me.stateMachineModule = New DevExpress.ExpressApp.StateMachine.StateMachineModule()
        Me.treeListEditorsModuleBase = New DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase()
        Me.validationModule = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.validationMobileModule = New DevExpress.ExpressApp.Validation.Mobile.ValidationMobileModule()
        Me.viewVariantsModule = New DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule()
        Me.workflowModule = New DevExpress.ExpressApp.Workflow.WorkflowModule()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        ' 
        ' securityStrategyComplex1
        ' 
        Me.securityStrategyComplex1.Authentication = Me.authenticationStandard1
        Me.securityStrategyComplex1.RoleType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole)
        Me.securityStrategyComplex1.UserType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser)
        ' 
        ' securityModule1
        ' 
        Me.securityModule1.UserType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser)
        ' 
        ' authenticationStandard1
        ' 
        Me.authenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
        '
        ' auditTrailModule
        '
        Me.auditTrailModule.AuditDataItemPersistentType = GetType(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent)
        '
        ' dashboardsModule
        '
        Me.dashboardsModule.DashboardDataType = GetType(DevExpress.Persistent.BaseImpl.DashboardData)
        '
        ' reportsModuleV2
        '
        Me.reportsModuleV2.EnableInplaceReports = True
        Me.reportsModuleV2.ReportDataType = GetType(DevExpress.Persistent.BaseImpl.ReportDataV2)
        Me.reportsModuleV2.ShowAdditionalNavigation = False
        Me.reportsModuleV2.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML
        '
        ' stateMachineModule
        '
        Me.stateMachineModule.StateMachineStorageType = GetType(DevExpress.ExpressApp.StateMachine.Xpo.XpoStateMachine)
        '
        ' workflowModule
        '
        Me.workflowModule.RunningWorkflowInstanceInfoType = GetType(DevExpress.ExpressApp.Workflow.Xpo.XpoRunningWorkflowInstanceInfo)
        Me.workflowModule.StartWorkflowRequestType = GetType(DevExpress.ExpressApp.Workflow.Xpo.XpoStartWorkflowRequest)
        Me.workflowModule.UserActivityVersionType = GetType(DevExpress.ExpressApp.Workflow.Versioning.XpoUserActivityVersion)
        Me.workflowModule.WorkflowControlCommandRequestType = GetType(DevExpress.ExpressApp.Workflow.Xpo.XpoWorkflowInstanceControlCommandRequest)
        Me.workflowModule.WorkflowDefinitionType = GetType(DevExpress.ExpressApp.Workflow.Xpo.XpoWorkflowDefinition)
        Me.workflowModule.WorkflowInstanceKeyType = GetType(DevExpress.Workflow.Xpo.XpoInstanceKey)
        Me.workflowModule.WorkflowInstanceType = GetType(DevExpress.Workflow.Xpo.XpoWorkflowInstance)
        ' 
        ' ManitariMobileApplication
        ' 
        Me.ApplicationName = "Manitari"
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.securityModule1)
        Me.Security = Me.securityStrategyComplex1
        Me.Modules.Add(Me.auditTrailModule)
        Me.Modules.Add(Me.objectsModule)
        Me.Modules.Add(Me.chartModule)
        Me.Modules.Add(Me.cloneObjectModule)
        Me.Modules.Add(Me.cloneObjectMobileModule)
        Me.Modules.Add(Me.conditionalAppearanceModule)
        Me.Modules.Add(Me.conditionalAppearanceMobileModule)
        Me.Modules.Add(Me.dashboardsModule)
        Me.Modules.Add(Me.fileAttachmentsMobileModule)
        Me.Modules.Add(Me.kpiModule)
        Me.Modules.Add(Me.localizationMobileModule)
        Me.Modules.Add(Me.mapsMobileModule)
        Me.Modules.Add(Me.notificationsModule)
        Me.Modules.Add(Me.pivotChartModuleBase)
        Me.Modules.Add(Me.pivotGridModule)
        Me.Modules.Add(Me.reportsModuleV2)
        Me.Modules.Add(Me.reportsMobileModuleV2)
        Me.Modules.Add(Me.schedulerModuleBase)
        Me.Modules.Add(Me.scriptRecorderModuleBase)
        Me.Modules.Add(Me.stateMachineModule)
        Me.Modules.Add(Me.treeListEditorsModuleBase)
        Me.Modules.Add(Me.validationModule)
        Me.Modules.Add(Me.validationMobileModule)
        Me.Modules.Add(Me.viewVariantsModule)
        Me.Modules.Add(Me.workflowModule)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
End Class

