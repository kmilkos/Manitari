Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.Core

Public Class MySplashScreen

    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Friend Sub UpdateInfo(Text As String)
        labelControl2.Text = Text
    End Sub

End Class

Public Class MySplash
    Implements ISplash, ISupportUpdateSplash

    Private Shared form As MySplashScreen

    Private Shared isStarted_Renamed As Boolean = False
    Public Sub Start() Implements ISplash.Start
        isStarted_Renamed = True
        form = New MySplashScreen()
        form.Show()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub [Stop]() Implements ISplash.Stop
        If form IsNot Nothing Then
            form.Hide()
            form.Close()
            form = Nothing
        End If
        isStarted_Renamed = False
    End Sub
    Private ReadOnly Property ISplash_IsStarted As Boolean Implements ISplash.IsStarted
        Get
            Return isStarted_Renamed
        End Get
    End Property

    Public Sub UpdateSplash(ByVal caption As String, ByVal description As String, ParamArray ByVal additionalParams() As Object)
        form.UpdateInfo(description)
    End Sub

    Private Sub ISupportUpdateSplash_UpdateSplash(caption As String, description As String, ParamArray additionalParams() As Object) Implements ISupportUpdateSplash.UpdateSplash
        Throw New NotImplementedException()
    End Sub

    Private Sub SetDisplayText(displayText As String) Implements ISplash.SetDisplayText
    End Sub
End Class

