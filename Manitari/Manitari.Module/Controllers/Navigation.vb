Imports DevExpress.Data
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.XtraNavBar
Imports System
Imports System.Linq

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
Partial Public Class Navigation
    Inherits WindowController
    Public Sub New()
        InitializeComponent()
        ' Target required Windows (via the TargetXXX properties) and create their Actions.
    End Sub

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        Dim navigationController As ShowNavigationItemController = Frame.GetController(Of ShowNavigationItemController)()
        If navigationController IsNot Nothing Then
            AddHandler Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction.CustomizeControl, AddressOf ShowNavigationItemAction_CustomizeControl
        End If
    End Sub

    Private Sub ShowNavigationItemAction_CustomizeControl(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.Actions.CustomizeControlEventArgs)
        Dim navBar As NavBarControl = TryCast(e.Control, NavBarControl)
        If navBar IsNot Nothing Then
            ' Customize NavBar
            For Each group As NavBarGroup In navBar.Groups
                If group.ControlContainer IsNot Nothing AndAlso group.ControlContainer.Controls.Count = 1 Then
                    Dim treeList As DevExpress.XtraTreeList.TreeList = TryCast(group.ControlContainer.Controls(0), DevExpress.XtraTreeList.TreeList)

                    treeList.ExpandAll()
                End If
            Next group
        Else
            Dim treeList As DevExpress.XtraTreeList.TreeList = TryCast(e.Control, DevExpress.XtraTreeList.TreeList)
            If treeList IsNot Nothing Then
                ' Customize TreeList
                treeList.ExpandAll()

            End If
        End If
    End Sub

    Protected Overrides Sub OnDeactivated()
        Dim navigationController As ShowNavigationItemController = Frame.GetController(Of ShowNavigationItemController)()
        If navigationController IsNot Nothing Then
            RemoveHandler Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction.CustomizeControl, AddressOf ShowNavigationItemAction_CustomizeControl
        End If
        MyBase.OnDeactivated()
    End Sub
End Class
