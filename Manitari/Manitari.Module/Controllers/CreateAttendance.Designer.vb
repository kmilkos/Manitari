Partial Class CreateAttendance

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.AddEmployees = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'AddEmployees
        '
        Me.AddEmployees.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept
        Me.AddEmployees.Caption = "Add Employees"
        Me.AddEmployees.Category = "RecordEdit"
        Me.AddEmployees.ConfirmationMessage = "Are you sure?"
        Me.AddEmployees.Id = "AddEmployees"
        Me.AddEmployees.ImageName = "BO_Department"
        Me.AddEmployees.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage
        Me.AddEmployees.TargetObjectType = GetType(Manitari.[Module].Attend)
        Me.AddEmployees.TargetViewType = DevExpress.ExpressApp.ViewType.ListView
        Me.AddEmployees.ToolTip = "Add The Active Employees to Current Day Payroll"
        Me.AddEmployees.TypeOfView = GetType(DevExpress.ExpressApp.ListView)
        '
        'CreateAttendance
        '
        Me.Actions.Add(Me.AddEmployees)

    End Sub

    Friend WithEvents AddEmployees As DevExpress.ExpressApp.Actions.SimpleAction
End Class
