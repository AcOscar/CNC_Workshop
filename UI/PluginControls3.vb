Public Class PluginControls3

    Private Sub PluginControls3_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.TabControl_CNCWrkshp.Height = Me.Height - Me.GB_JobProcess.Height

    End Sub

End Class
