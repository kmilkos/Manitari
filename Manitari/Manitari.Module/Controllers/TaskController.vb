Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class TaskController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        ' Target required Views (via the TargetXXX properties) and create their Actions.
        TargetObjectType = GetType(Task)
        TargetViewType = ViewType.Any
        Dim markCompletedAction As New SimpleAction(Me, "MarkCompleted", DevExpress.Persistent.Base.PredefinedCategory.RecordEdit) With {
            .TargetObjectsCriteria = (CriteriaOperator.Parse("TaskStatus != ?", Task.TaskStatusEnum.Completed)).ToString(),
            .ConfirmationMessage = "Are you sure to mark the selected task(s) as 'Completed'?",
            .ImageName = "State_Task_Completed"
        }
        AddHandler markCompletedAction.Execute, Sub(s, e)

                                                    For Each task As Task In e.SelectedObjects
                                                        task.EndOn = Date.Now
                                                        task.TaskStatus = Task.TaskStatusEnum.Completed
                                                        View.ObjectSpace.SetModified(task) ' Mark the changed object as 'dirty' (only required if data properties do not provide change notifications).
                                                    Next task
                                                    View.ObjectSpace.CommitChanges()
                                                    Dim options As New MessageOptions()
                                                    options.Duration = 2000
                                                    options.Message = String.Format("{0} task(s) have been successfully updated!", e.SelectedObjects.Count)
                                                    options.Type = InformationType.Success
                                                    options.Web.Position = InformationPosition.Right
                                                    options.Win.Caption = "Success"
                                                    options.Win.Type = WinMessageType.Flyout
                                                    Application.ShowViewStrategy.ShowMessage(options)
                                                    View.ObjectSpace.Refresh() ' Optionally update the UI in accordance with the latest data changes.
                                                End Sub
    End Sub


    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub
End Class
