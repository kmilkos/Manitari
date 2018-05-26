Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.Core

Public Class MySplashScreen
    Implements ISplash
    Private Shared form As SplashScreenForm
    Private _isStarted As Boolean

    Sub New()
        InitializeComponent()
    End Sub

    Public ReadOnly Property IsStarted As Boolean Implements ISplash.IsStarted
        Get
            Return _isStarted
        End Get
    End Property

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Sub Start() Implements ISplash.Start
        _isStarted = True
        form = New SplashScreenForm("Starting")
        form.Show()
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub [Stop]() Implements ISplash.Stop
        If form IsNot Nothing Then
            form.Hide()
            form.Close()
            form = Nothing
        End If
        _isStarted = False
    End Sub

    Public Sub SetDisplayText(displayText As String) Implements ISplash.SetDisplayText
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum
End Class
