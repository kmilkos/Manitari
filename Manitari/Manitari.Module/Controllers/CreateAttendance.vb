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
Imports DevExpress.ExpressApp.Xpo

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class CreateAttendance
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        ' Target required Views (via the TargetXXX properties) and create their Actions.
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

    Private Sub AddEmployees_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles AddEmployees.Execute
        Using os As XPObjectSpace = Application.CreateObjectSpace()
            Dim EmployeeBaseList As IList(Of Employee) = os.GetObjects(Of Employee)()
            'some code which performs actions using the objectSpace Object Space  


            For Each employee In EmployeeBaseList
                Dim newAttend As Attend = os.CreateObject(Of Attend)()

                newAttend.Employee = employee
                newAttend.TheDate = Today
                newAttend.StartTime = Today + " 07:30"
                newAttend.EndTime = Today + " 15:30"
            Next

            os.CommitChanges()
            os.Refresh()
        End Using
    End Sub
End Class
