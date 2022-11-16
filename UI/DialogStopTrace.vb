Imports System.Windows.Forms

Public Class DialogStopTrace
    Dim toolTip1 As New ToolTip()

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'close by user
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        Me.Close()

    End Sub

    Public Sub CloseByCode()
        'close by code
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes

        Me.Close()

    End Sub

    Private Sub DialogStopTrace_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        toolTip1.AutoPopDelay = 0

        toolTip1.SetToolTip(Me.OK_Button, "This will NOT stop the cutter!")

        Me.BringToFront()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New(ByVal ButtonText As String)

        ' This call is required by the designer.
        InitializeComponent()

        Me.OK_Button.Text = ButtonText

    End Sub

End Class
