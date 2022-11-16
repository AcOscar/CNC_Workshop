<System.Runtime.InteropServices.Guid("C17FDF70-9152-4DC7-959B-82F901C8FC11")> _
Public Class PlugInControls

    Overridable Sub PlugInControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ToolTips.SetToolTip(BT_Set0, "Select a new Basepoint for the device zero point")
        ToolTips.SetToolTip(BT_Process, "starts the machine")
        ToolTips.SetToolTip(BT_Choose, "select objects to process")
        ToolTips.SetToolTip(BT_SetCursor, "set the tool position")

        ToolTips.SetToolTip(BT_UL, "move tool left up")
        ToolTips.SetToolTip(BT_UM, "move tool up")
        ToolTips.SetToolTip(BT_UR, "move tool right up")
        ToolTips.SetToolTip(BT_ML, "move tool middle left")
        ToolTips.SetToolTip(BT_MR, "move tool right")
        ToolTips.SetToolTip(BT_DL, "move tool left down")
        ToolTips.SetToolTip(BT_DM, "move tool down")
        ToolTips.SetToolTip(BT_DR, "move tool right down")

        ToolTips.SetToolTip(BT_DevTL, "sets the basepoint to the top left corner of your selected objects")
        ToolTips.SetToolTip(BT_DevTM, "sets the basepoint to the top middle corner of your selected objects")
        ToolTips.SetToolTip(BT_DevTR, "sets the basepoint to the top right corner of your selected objects")
        ToolTips.SetToolTip(BT_DevML, "sets the basepoint to the middle left corner of your selected objects")
        ToolTips.SetToolTip(BT_DevMM, "sets the basepoint to the middle middle corner of your selected objects")
        ToolTips.SetToolTip(BT_DevMR, "sets the basepoint to the middle right corner of your selected objects")
        ToolTips.SetToolTip(BT_DevBL, "sets the basepoint to the bottom left corner of your selected objects")
        ToolTips.SetToolTip(BT_DevBM, "sets the basepoint to the bottom middle corner of your selected objects")
        ToolTips.SetToolTip(BT_DevBR, "sets the basepoint to the bottom rightcorner of your selected objects")

    End Sub

    Public Overridable Sub CB_OnOffLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_OnOffLine.CheckedChanged

    End Sub

    Overridable Sub BT_UL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_UL.Click

    End Sub

    Overridable Sub BT_UM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_UM.Click

    End Sub

    Overridable Sub BT_UR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_UR.Click

    End Sub

    Overridable Sub BT_ML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ML.Click

    End Sub

    Overridable Sub BT_SetCursor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SetCursor.Click

    End Sub

    Overridable Sub BT_MR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_MR.Click

    End Sub

    Overridable Sub BT_DL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DL.Click

    End Sub

    Overridable Sub BT_DM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DM.Click

    End Sub

    Overridable Sub BT_DR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DR.Click

    End Sub

    Overridable Sub BT_Set0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Set0.Click

    End Sub

    Overridable Sub BT_Process_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Process.Click

    End Sub

    Overridable Sub BT_Choose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Choose.Click

    End Sub

    Overridable Sub BT_DevTL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevTL.Click

    End Sub

    Overridable Sub BT_DevTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevTM.Click

    End Sub

    Overridable Sub BT_DevTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevTR.Click

    End Sub

    Overridable Sub BT_DevML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevML.Click

    End Sub

    Overridable Sub BT_DevMM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevMM.Click

    End Sub

    Overridable Sub BT_DevMR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevMR.Click

    End Sub

    Overridable Sub BT_DevBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevBL.Click

    End Sub

    Overridable Sub BT_DevBM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevBM.Click

    End Sub

    Overridable Sub BT_DevBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DevBR.Click

    End Sub

    Overridable Sub CNC_LayerGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CNC_LayerGrid.CellContentClick

    End Sub

    Overridable Sub CNC_LayerGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CNC_LayerGrid.CellValueChanged

    End Sub

    Overridable Sub CNC_CheckLayerVisibility_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNC_CheckLayerVisibility.CheckedChanged

    End Sub

    Overridable Sub CompBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompBt.Click

    End Sub

    Overridable Sub NumUD_X_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUD_X.ValueChanged

    End Sub

    Overridable Sub NumUD_Y_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUD_Y.ValueChanged

    End Sub

    Overridable Sub BT_UL_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_UL.DoubleClick

    End Sub

    Overridable Sub BT_UM_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_UM.DoubleClick

    End Sub

    Overridable Sub BT_UR_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_UR.DoubleClick

    End Sub

    Overridable Sub BT_ML_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ML.DoubleClick

    End Sub

    Overridable Sub BT_MR_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_MR.DoubleClick

    End Sub

    Overridable Sub BT_DL_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DL.DoubleClick

    End Sub

    Overridable Sub BT_DM_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DM.DoubleClick

    End Sub

    Overridable Sub BT_DR_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DR.DoubleClick

    End Sub

    Overridable Sub BT_ShowPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ShowPath.Click

    End Sub
End Class
