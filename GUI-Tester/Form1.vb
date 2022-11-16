Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mme As New PluginControls3


        Me.Controls.Add(mme)

        mme.Show()

    End Sub

End Class
