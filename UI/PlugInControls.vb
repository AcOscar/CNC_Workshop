<System.Runtime.InteropServices.Guid("10fd7cee-dd97-4c13-a58a-ddaf21d1a85b")> _
Public Class PlugInControls

    Public Overridable Sub PlugInControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ToolTips.SetToolTip(BT_Set0, "change the basepoint for the device origin point")
        ToolTips.SetToolTip(BT_Process, "starts the job")
        ToolTips.SetToolTip(BT_Choose, "select objects to process")
        ToolTips.SetToolTip(BT_SetToolPos, "set the tool position")

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
        ToolTips.SetToolTip(BT_DevMM, "sets the basepoint to the middle corner of your selected objects")
        ToolTips.SetToolTip(BT_DevMR, "sets the basepoint to the middle right corner of your selected objects")
        ToolTips.SetToolTip(BT_DevBL, "sets the basepoint to the bottom left corner of your selected objects")
        ToolTips.SetToolTip(BT_DevBM, "sets the basepoint to the bottom middle corner of your selected objects")
        ToolTips.SetToolTip(BT_DevBR, "sets the basepoint to the bottom rightcorner of your selected objects")

        ToolTips.SetToolTip(BT_GetLocation, "get the current location of the tool and shows them in rhino")

        ToolTips.SetToolTip(RB_OpNone, "no sorting algorithm, the objects will be cut in draw order")
        ToolTips.SetToolTip(RB_OpSorx, "SORting by X value")
        ToolTips.SetToolTip(RB_OpNene, "NEarest NEighbor heuristic")
        ToolTips.SetToolTip(RB_OpNene2, "NEarest NEighbor heuristic and 2-opt-heuristic post optimization")
        ToolTips.SetToolTip(RB_OpFarin, "FARthest INsertion heuristic")
        ToolTips.SetToolTip(RB_OpFarin2, "FARthest INsertion heuristic and 2-opt-heuristic post optimization")

        ToolTips.SetToolTip(CB_Preview, "shows a preview of the path to cut")
        ToolTips.SetToolTip(CB_OnOffLine, "activates and deactivates this plugin")

        ToolTips.SetToolTip(PB_FileUpload, "file upload progress")
        ToolTips.SetToolTip(PB_JobProcess, "job progress")

        ToolTips.SetToolTip(NumUD_X, "shows and set the X position of the tool")
        ToolTips.SetToolTip(NumUD_Y, "shows and set the Y position of the tool")

        ToolTips.SetToolTip(BT_Compatibility, "converts old layernames to the requierd settings" & vbCrLf _
                            & "Layer: 932_SP1 to SP1" & vbCrLf _
                            & "Layer: 932_SP2 to SP2" & vbCrLf _
                            & "Layer: 932_SP4 to SP4" & vbCrLf _
                            & "Layer: 932_Cut to CUT" & vbCrLf _
                            & "Layer: 932_Engrave to ENG")

        ToolTips.SetToolTip(CB_LayerVisibility, "Hides all layers without a tool assignment")

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

    Overridable Sub BT_SetToolPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SetToolPos.Click

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

    Overridable Sub CB_LayerVisibility_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_LayerVisibility.CheckedChanged

    End Sub

    Overridable Sub BT_Compatibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Compatibility.Click

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

    Overridable Sub CB_BBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_BBox.CheckedChanged

    End Sub

    Overridable Sub CB_Preview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Preview.CheckedChanged

    End Sub

    Overridable Sub RB_OpNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_OpNone.CheckedChanged

    End Sub

    Overridable Sub RB_OpSorx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_OpSorx.CheckedChanged

    End Sub

    Overridable Sub RB_OpNene_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_OpNene.CheckedChanged

    End Sub

    Overridable Sub RB_OpNene2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_OpNene2.CheckedChanged

    End Sub

    Overridable Sub RB_OpFarin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_OpFarin.CheckedChanged

    End Sub

    Overridable Sub RB_OpFarin2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_OpFarin2.CheckedChanged

    End Sub

    Overridable Sub NumUD_BBox_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUD_BBox.ValueChanged

    End Sub

    Overridable Sub BT_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Reset.Click

    End Sub

    Overridable Sub BT_TerminalSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TerminalSend.Click

    End Sub

    Overridable Sub BT_FrontEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_FrontEnd.Click

    End Sub

    Overridable Sub BT_CLSRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CLSRec.Click

    End Sub

    Overridable Sub CB_Tracing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Overridable Sub BT_Write2Log_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Write2Log.Click

    End Sub

    Overridable Sub BT_GetLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GetLocation.Click

    End Sub

#Region "DrecksPatch"
    'wegen "http://connect.microsoft.com/VisualStudio/feedback/details/216189/numericupdown-use-of-mouse-wheel-may-result-in-different-increment"

    Protected Sub OnMouseWheel1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NumUD_BBox.MouseWheel

        Dim _NumUD As NumericUpDown = sender

        Select Case e.Delta

            Case Is > 0

                If _NumUD.Value < _NumUD.Maximum Then

                    _NumUD.Value += _NumUD.Increment

                End If

            Case Is < 0

                If _NumUD.Value > _NumUD.Minimum Then

                    _NumUD.Value -= _NumUD.Increment

                End If

        End Select

    End Sub

#End Region

End Class
