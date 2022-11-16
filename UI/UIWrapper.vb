Imports Rhino
Imports Rhino.DocObjects

<System.Runtime.InteropServices.Guid("06D01CD3-3455-429D-B822-D72AC1AEF8C3")> _
Public Class UIWrapper
    Inherits PlugInControls

    'Inherits WrkShp.PlugInControls
    Friend MachinePark As CNC_MachinePark

    Friend WithEvents CurrentDevice As CNC_Device

    Friend DispConduit As rhDisplayConduit

    Private myWorker As New RhWorker

    Private Property contentIsChanging As Boolean

    Private numPrevent As Boolean = False

    Private Property BBox As Double

    Private myChooser As New UIDeviceChooser

    Public Shared ReadOnly Property Guid As Guid
        Get
            Return New Guid("06D01CD3-3455-429D-B822-D72AC1AEF8C3")
        End Get
    End Property

#Region "Control Events"

    Private Sub InitializeComponent()
        Me.PL_Device.SuspendLayout()
        CType(Me.NumUD_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUD_X, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_ToolPosition.SuspendLayout()
        CType(Me.NumUD_BBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RhUIWrapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "RhUIWrapper"
        Me.PL_Device.ResumeLayout(False)
        Me.PL_Device.PerformLayout()
        CType(Me.NumUD_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUD_X, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_ToolPosition.ResumeLayout(False)
        Me.GB_ToolPosition.PerformLayout()
        CType(Me.NumUD_BBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Overrides Sub PlugInControl_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        MyBase.PlugInControl_Load(sender, e)

        AddHandler RhinoDoc.ActiveDoc.LayerTableEvent, AddressOf LayerTableEvent

        MachinePark = New CNC_MachinePark

        CurrentDevice = MachinePark.GetConnectedDevice

        DispConduit = New rhDisplayConduit

        contentIsChanging = False

        myWorker.RefreshLayerList(CNC_LayerGrid, MyBase.CB_LayerVisibility.Checked)

        contentIsChanging = True

        myWorker.LengtLabel = Me.Lbl_Info

        myWorker.PB_FileUpload = Me.PB_FileUpload
        myWorker.PB_JobProcess = Me.PB_JobProcess

        AddHandler Me.TV_Material.AfterSelect, AddressOf MaterialChanged

        DeviceTabIni()

        'conduit laden
        DispConduit.DeviceFixObjects = myWorker.GetConduitObj(CurrentDevice.ProxyGraphic)
        DispConduit.ToolObjectsXY = myWorker.GetConduitObj(CurrentDevice.CurTool.ProxyGraphicXY)
        DispConduit.ToolObjectsX = myWorker.GetConduitObj(CurrentDevice.CurTool.ProxyGraphicX)
        DispConduit.ToolObjectsY = myWorker.GetConduitObj(CurrentDevice.CurTool.ProxyGraphicY)

        myChooser.Port = CurrentDevice.serialPort

        CB_BBox.Checked = True

    End Sub

#End Region

#Region "DirectTab"

#Region "Move Tool Arrows"

    ''' <summary>
    ''' Up Left
    ''' </summary>
    Overrides Sub BT_UL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        CurrentDevice.ToolRelativeMove(-10, 10, True)

        UpdateDisplay()

    End Sub

    ''' <summary>
    ''' Up Middle
    ''' </summary>
    Overrides Sub BT_UM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        CurrentDevice.ToolRelativeMove(0, 10, True)

        UpdateDisplay()

    End Sub

    ''' <summary>
    ''' Up Right
    ''' </summary>
    Overrides Sub BT_UR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        CurrentDevice.ToolRelativeMove(10, 10, True)

        UpdateDisplay()

    End Sub

    ''' <summary>
    ''' Middle Left
    ''' </summary>
    Overrides Sub BT_ML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        CurrentDevice.ToolRelativeMove(-10, 0, True)

        UpdateDisplay()

    End Sub

    ''' <summary>
    ''' Middle Right
    ''' </summary>
    Overrides Sub BT_MR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        CurrentDevice.ToolRelativeMove(10, 0, True)

        UpdateDisplay()

    End Sub

    ''' <summary>
    ''' Down Left
    ''' </summary>
    Overrides Sub BT_DL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        CurrentDevice.ToolRelativeMove(-10, -10, True)

        UpdateDisplay()

    End Sub

    ''' <summary>
    ''' Down Middle
    ''' </summary>
    Overrides Sub BT_DM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        CurrentDevice.ToolRelativeMove(0, -10, True)

        UpdateDisplay()

    End Sub

    ''' <summary>
    ''' Down Right
    ''' </summary>
    Overrides Sub BT_DR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        CurrentDevice.ToolRelativeMove(10, -10, True)

        UpdateDisplay()

    End Sub
#End Region

    Overrides Sub BT_SetToolPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        Dim gp = New Rhino.Input.Custom.GetPoint()

        gp.SetCommandPrompt("Select Tool Position")

        gp.Get()

        If gp.CommandResult() <> Rhino.Commands.Result.Success Then

            Exit Sub

        End If

        Dim ToolPosition As New Coordinate(gp.Point.X, gp.Point.Y)

        Dim topoint As New Coordinate(CType(ToolPosition - CurrentDevice.ZeroPoint, Coordinate))

        CurrentDevice.ToolAbsoluteMove(topoint, True)

        UpdateDisplay()

    End Sub

    Overrides Sub BT_Set0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

        'If myWorker.newZero(CurrentDevice, DispConduit) Then
        If myWorker.newZero(CurrentDevice, DispConduit) Then

            UpdateDisplay()

        End If

    End Sub

    Overrides Sub NumUD_X_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Not numPrevent Then

            CurrentDevice.ToolAbsoluteMove(New Coordinate(NumUD_X.Value, NumUD_Y.Value), True)

            UpdateDisplay()

        End If

    End Sub

    Overrides Sub NumUD_Y_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Not numPrevent Then

            CurrentDevice.ToolAbsoluteMove(New Coordinate(NumUD_X.Value, NumUD_Y.Value), True)

            UpdateDisplay()

        End If

    End Sub

    Overrides Sub BT_Process_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ControlsDeactivate()

        GetOptimizingStyle()

        GetLastPosition()

        If myWorker.isObjectSelected Then

            myWorker.ProcessWithPreChoosenObjects(CurrentDevice, DispConduit)

        Else

            myWorker.ProcessWholeBench(CurrentDevice, DispConduit, Me.CB_Preview.Checked)

        End If

        UpdateDisplay()

    End Sub

    Sub ControlsDeactivate()

        GB_ToolPosition.Enabled = False

        GB_PathOpimizing.Enabled = False

        BT_Process.Enabled = False

        CB_Preview.Enabled = False

    End Sub

    Private Sub ControlsReactivate()

        If CB_Preview.InvokeRequired Then

            Me.CB_Preview.Invoke(Sub() CurrentDevice_DeviceProcessFinished())

        Else

            Me.CB_Preview.Checked = False

            Me.CB_Preview.Enabled = True

        End If

        ControlFunctionInvoker(GB_ToolPosition, "Enabled", True)

        ControlFunctionInvoker(GB_PathOpimizing, "Enabled", True)

        ControlFunctionInvoker(GB_PathOpimizing, "Enabled", True)

        ControlFunctionInvoker(BT_Process, "Enabled", True)

    End Sub

    Private Sub GetLastPosition()

        For Each rb As Control In Me.GB_PathOpimizing.Controls

            If TypeOf rb Is RadioButton Then

                Dim myRB As RadioButton = CType(rb, RadioButton)

                If myRB.Checked Then

                    Select Case myRB.Name

                        Case "RB_EndPos_2Park"
                            myWorker.Optimizer.LastPosition = OptimizerByIndex.LastPositionStyle.Parking

                        Case "RB_EndPos_Stay"
                            myWorker.Optimizer.LastPosition = OptimizerByIndex.LastPositionStyle.Last

                        Case "RB_EndPos_2Start"
                            myWorker.Optimizer.LastPosition = OptimizerByIndex.LastPositionStyle.Start

                    End Select

                End If

            End If

        Next

    End Sub

    Private Sub GetOptimizingStyle()

        For Each rb As Control In Me.GB_PathOpimizing.Controls

            If TypeOf rb Is RadioButton Then

                Dim myRB As RadioButton = CType(rb, RadioButton)

                If myRB.Checked Then

                    Select Case myRB.Name

                        Case "RB_OpSorx"

                            myWorker.Optimizer.OptimizingStyle = OptimizerByIndex.PathOptimzing.byX

                        Case "RB_OpNene"

                            myWorker.Optimizer.OptimizingStyle = OptimizerByIndex.PathOptimzing.NearestNeighbour

                        Case "RB_OpNene2"

                            myWorker.Optimizer.OptimizingStyle = OptimizerByIndex.PathOptimzing.NearestNeighbourPlus

                        Case "RB_OpFarin"

                            myWorker.Optimizer.OptimizingStyle = OptimizerByIndex.PathOptimzing.FarthestInsertion

                        Case "RB_OpFarin2"

                            myWorker.Optimizer.OptimizingStyle = OptimizerByIndex.PathOptimzing.FarthestInsertionPlus

                        Case "RB_OpNone"

                            myWorker.Optimizer.OptimizingStyle = OptimizerByIndex.PathOptimzing.none

                    End Select

                End If

            End If

        Next

        myWorker.LengtLabel = Me.Lbl_Info

    End Sub

    Overrides Sub CB_Preview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CB_Preview.Checked Then

            GetOptimizingStyle()

            GetLastPosition()

            PB_FileUpload.Value = PB_FileUpload.Minimum

            PB_JobProcess.Value = PB_JobProcess.Minimum

            myWorker.PreviewOn(CurrentDevice, DispConduit, CB_BBox.Checked, NumUD_BBox.Value)

            CB_Preview.Text = "Preview Off"

        Else

            myWorker.PreviewOff(DispConduit)

            CB_Preview.Text = "Preview On"

        End If

        UpdateDisplay()

    End Sub

    ''' <summary>
    ''' Bounding Box ein/ausschalten
    ''' </summary>
    Overrides Sub CB_BBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.withBBox = CB_BBox.Checked

        If CB_BBox.Checked Then

            myWorker.BBoxOn(CurrentDevice, DispConduit, NumUD_BBox.Value)

        Else

            myWorker.BBoxOff(CurrentDevice, DispConduit)

        End If

        UpdateDisplay()

    End Sub


    Public Overrides Sub CB_OnOffLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'cursur auf wait da gerade  der serport lange dauern kann
        Me.Cursor = Cursors.WaitCursor

        Me.SuspendLayout()

        If CB_OnOffLine.Checked Then

            '   myChooser.ShowDialog()

            If CurrentDevice.activate() Then

                'die Controls aktivieren
                Me.PL_Device.Enabled = True

                ControlsReactivate()

                Me.PL_Device.Update()

                Me.CB_Preview.Checked = False

                DispConduit.Enable()

            End If

            'dem knopf einen anderen Text wegen umschalten geben
            CB_OnOffLine.Text = "Deactivate"

        Else

            'offline
            CurrentDevice.deactivate()
            'die controls ausschalten
            Me.PL_Device.Enabled = False
            'das conduiot ausschalten und löschen
            DispConduit.Disable()

            DispConduit.Purge()

            Me.PB_FileUpload.Value = Me.PB_FileUpload.Minimum

            Me.PB_JobProcess.Value = Me.PB_JobProcess.Minimum

            'dem knopf einen anderen Text wegen umschalten geben
            CB_OnOffLine.Text = "Activate"
            'bildschirm neuzeichenn
            RhinoDoc.ActiveDoc.Views.ActiveView.Redraw()
        End If

        Me.ResumeLayout()
        'cursur wieder normal
        Me.Cursor = Cursors.Default

    End Sub

    Sub CB_OnOffLine_CheckState(ByVal value As CheckState)

        ControlFunctionInvoker(Me.CB_OnOffLine, "CheckState", value)

    End Sub

    Private Sub UpdatePath(ByVal sender As Object)

        Dim SendingCheckBox As RadioButton = CType(sender, RadioButton)

        If CB_Preview.Checked Then

            If SendingCheckBox.Checked Then

                If myWorker IsNot Nothing Then

                    Me.PL_Device.SuspendLayout()

                    Me.Cursor = Cursors.WaitCursor

                    Me.PL_Device.Enabled = False

                    GetOptimizingStyle()

                    myWorker.UpdatePath(CurrentDevice, DispConduit)

                    UpdateDisplay()

                    Me.PL_Device.Enabled = True

                    Me.Cursor = Cursors.Default

                    Me.PL_Device.ResumeLayout()

                End If

            End If

        End If

    End Sub

    Public Overrides Sub BT_GetLocation_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        CurrentDevice.SendSerialDirect(Chr(27) & ".[OA;")

    End Sub

    Sub PB_FileUploadRefresh()

        ControlMethodInvoker(Me.PB_FileUpload, "Refresh", Nothing)

        Me.PB_FileUpload.Refresh()

    End Sub

    Sub GB_ToolPositionRefresh()

        ControlMethodInvoker(Me.GB_ToolPosition, "Refresh", Nothing)

    End Sub

    ''' <summary>
    ''' Abstand der BoundungBox von der Geometrie
    ''' </summary>
    Overrides Sub NumUD_BBox_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If myWorker IsNot Nothing Then

            If CB_BBox.Checked Then

                BBox = NumUD_BBox.Value

                myWorker.BBoxOff(CurrentDevice, DispConduit)

                myWorker.BBoxOn(CurrentDevice, DispConduit, NumUD_BBox.Value)

                UpdateDisplay()

            End If

        End If

    End Sub

#Region "Optimizers"

    Overrides Sub RB_OpNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        UpdatePath(sender)

    End Sub

    Overrides Sub RB_OpSorx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        UpdatePath(sender)

    End Sub

    Overrides Sub RB_OpNene_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        UpdatePath(sender)

    End Sub

    Overrides Sub RB_OpNene2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        UpdatePath(sender)

    End Sub

    Overrides Sub RB_OpFarin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        UpdatePath(sender)

    End Sub

    Overrides Sub RB_OpFarin2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        UpdatePath(sender)

    End Sub

#End Region

#Region "choose BasePoint"

    Overrides Sub BT_Choose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If myWorker.PreChoosingObjects(CurrentDevice, DispConduit) > 0 Then

            BasePointGB.Enabled = True

        Else

            BasePointGB.Enabled = False

        End If

    End Sub

    Overrides Sub BT_DevTL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.TopLeft)

    End Sub

    Overrides Sub BT_DevTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.TopMiddle)

    End Sub

    Overrides Sub BT_DevTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.TopRight)

    End Sub

    Overrides Sub BT_DevML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.MiddleLeft)

    End Sub

    Overrides Sub BT_DevMM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.MiddleMiddle)

    End Sub

    Overrides Sub BT_DevMR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.MiddleRight)

    End Sub

    Overrides Sub BT_DevBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.BottomLeft)

    End Sub

    Overrides Sub BT_DevBM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.BottomMiddle)

    End Sub

    Overrides Sub BT_DevBR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CurrentDevice.SetToBoundingPoint(CNC_Device.BoxPosition.BottomRight)

    End Sub

#End Region

#End Region

#Region "LayerTab"

    Public Sub LayerTableEvent(ByVal sender As Object, ByVal e As Tables.LayerTableEventArgs)

        contentIsChanging = False

        myWorker.RefreshLayerList(CNC_LayerGrid, MyBase.CB_LayerVisibility.Checked)

        contentIsChanging = True

    End Sub

    Overrides Sub BT_Compatibility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        myWorker.Compatility()

        contentIsChanging = False

        myWorker.RefreshLayerList(CNC_LayerGrid, MyBase.CB_LayerVisibility.Checked)

        contentIsChanging = True

    End Sub

    Overrides Sub CNC_LayerGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        If contentIsChanging Then

            myWorker.CellEvent(CNC_LayerGrid, e)

            If CB_Preview.Checked Then

                myWorker.PreviewOff(DispConduit)

                GetOptimizingStyle()

                GetLastPosition()

                myWorker.PreviewOn(CurrentDevice, DispConduit, CB_BBox.Checked, NumUD_BBox.Value)

                UpdateDisplay()

            End If

        End If

    End Sub

    Public Overrides Sub CNC_LayerGrid_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Public Overrides Sub CB_LayerVisibility_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        contentIsChanging = False

        myWorker.RefreshLayerList(CNC_LayerGrid, MyBase.CB_LayerVisibility.Checked)

        contentIsChanging = True

    End Sub

#End Region

#Region "Device Tab"

    Public Overrides Sub BT_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        DeviceTabIni()

    End Sub

    Sub DeviceTabIni()

        MachinePark = New CNC_MachinePark

        Me.CB_DeviceChoose.Items.Clear()

        For Each d As CNC_Device In MachinePark.Devices

            Me.CB_DeviceChoose.Items.Add(d.DeviceName)

        Next

        If Me.CB_DeviceChoose.Items.Count > 0 Then

            Me.CB_DeviceChoose.SelectedItem = Me.CB_DeviceChoose.Items(1)

        End If

    End Sub

    Private Sub deviceChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CB_DeviceChoose.SelectedIndexChanged

        For Each device As CNC_Device In MachinePark.Devices

            If device.DeviceName = Me.CB_DeviceChoose.SelectedItem.ToString Then

                CurrentDevice = device

            End If

        Next

        BuildMaterialList()

        BuildToolList()

    End Sub

    Sub BuildMaterialList()
        Me.TV_Material.Nodes.Clear()

        For Each _Device As CNC_Device In MachinePark.Devices

            If _Device.DeviceName = Me.CB_DeviceChoose.SelectedItem.ToString Then

                Dim myDefaultMatrialNode As TreeNode

                myDefaultMatrialNode = Me.TV_Material.Nodes.Add("Default Settings")

                myDefaultMatrialNode.Name = "Default Settings"

                For Each Material As CNC_Material In MachinePark.Materials

                    For Each Thickness As CNC_Thickness In Material.Thickness

                        For Each ToolSetting As CNC_ToolSetting In Thickness.ToolSettings

                            For Each tool As CNC_Tool In _Device.Tools

                                If ToolSetting.ID = tool.ID Then

                                    Dim myMatrialNodes As TreeNode()

                                    myMatrialNodes = Me.TV_Material.Nodes.Find(Material.ID, True)

                                    Dim myCurrentMatrialNode As TreeNode

                                    If myMatrialNodes.Length <> 0 Then

                                        myCurrentMatrialNode = myMatrialNodes(0)

                                    Else

                                        myCurrentMatrialNode = Me.TV_Material.Nodes.Add(Material.Name)

                                        myCurrentMatrialNode.Name = Material.ID

                                    End If

                                    Dim myMatrialTypeNodes As TreeNode()

                                    myMatrialTypeNodes = myCurrentMatrialNode.Nodes.Find(Thickness.ID, True)

                                    Dim myCurrentMatrialTypeNode As TreeNode

                                    If myMatrialTypeNodes.Length <> 0 Then

                                        myCurrentMatrialTypeNode = myMatrialTypeNodes(0)

                                    Else

                                        myCurrentMatrialTypeNode = myCurrentMatrialNode.Nodes.Add(Thickness.Name)

                                        myCurrentMatrialTypeNode.Name = Thickness.ID

                                        myCurrentMatrialTypeNode.Tag = Material

                                    End If

                                End If

                            Next

                        Next

                    Next

                Next

            End If

        Next

        Me.TV_Material.ExpandAll()

    End Sub

    Private Sub BuildToolList()

        Dim myToolTips As New ToolTip

        Me.GBTools.Visible = False

        Me.GBTools.Controls.Clear()

        Dim _width As Integer = 222

        Dim _height As Integer = 73

        Dim propYOffset As Integer = 21

        Dim ToolYOffset As Integer = 31

        Dim y As Integer = 0

        For Each tool As CNC_Tool In CurrentDevice.Tools

            Dim aGroupBox As New GroupBox

            aGroupBox.Text = tool.ID

            aGroupBox.Width = _width

            Me.GBTools.Controls.Add(aGroupBox)

            Dim propY As Integer = 0

            aGroupBox.Location = New Drawing.Point(6, y + propYOffset)

            For Each prop As CNC_Property In tool.Properties

                If prop.ID.Contains("tool") Then

                    Continue For

                End If

                Dim aLabel As New Label

                aLabel.Text = prop.Text

                aLabel.AutoSize = True

                aGroupBox.Controls.Add(aLabel)

                propY += propYOffset

                aLabel.Location = New Drawing.Point(aGroupBox.Location.X + 5, propY)

                Dim aUpDown As New NumericUpDown

                aUpDown.DecimalPlaces = 1

                aUpDown.Minimum = CDec(prop.min)

                aUpDown.Maximum = CDec(prop.max)

                If prop.Value <= prop.max AndAlso
                    prop.Value >= prop.min Then

                    aUpDown.Value = CDec(prop.Value)

                End If

                aUpDown.Size = New Drawing.Size(70, 20)

                myToolTips.SetToolTip(aUpDown, aUpDown.Minimum & " - " & aUpDown.Maximum)

                aGroupBox.Controls.Add(aUpDown)

                aUpDown.Location = New Drawing.Point(aLabel.Location.X + 135, aLabel.Location.Y)

                aUpDown.Tag = prop.ID

                AddHandler aUpDown.ValueChanged, AddressOf UD_ValueChanged

            Next

            aGroupBox.Height = propY + ToolYOffset

            y += aGroupBox.Height

        Next

        Me.GBTools.Height = y + ToolYOffset

        Me.GBTools.Visible = True

    End Sub

    Private Sub MaterialChanged(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles TV_Material.AfterSelect
        Dim myNewMat As CNC_Material
        Dim myTreeView As TreeView
        Dim myTreeNode As TreeNode

        myTreeView = CType(sender, TreeView)

        myTreeNode = myTreeView.SelectedNode

        If myTreeNode.Tag Is Nothing Then
            If myTreeNode.Name = "Default Settings" Then

                For Each tool As CNC_Tool In CurrentDevice.Tools

                    tool.setDefault()

                Next

            End If

            BuildToolList()

            Exit Sub

        End If

        myNewMat = CType(myTreeNode.Tag, CNC_Material)

        Dim myToolsettings As List(Of CNC_ToolSetting)

        myToolsettings = getToolSettings(myNewMat, myTreeNode.Name)

        For Each ts As CNC_ToolSetting In myToolsettings

            For Each tool As CNC_Tool In CurrentDevice.Tools

                If tool.ID = ts.ID Then

                    tool.setProperty(ts)

                End If

            Next

        Next

        BuildToolList()

    End Sub

    Private Function getToolSettings(ByVal material As CNC_Material, ByVal id As String) As List(Of CNC_ToolSetting)

        For Each th As CNC_Thickness In material.Thickness

            If th.ID = id Then

                Return th.ToolSettings

            End If

        Next

        Return Nothing

    End Function

    Private Sub UD_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        'Stop
        Dim myUD As NumericUpDown = CType(sender, NumericUpDown)

        Dim myTs As New CNC_ToolSetting

        myTs.ID = myUD.Parent.Text

        CallByName(myTs, myUD.Tag.ToString, CallType.Set, myUD.Value)

        For Each tool As CNC_Tool In CurrentDevice.Tools

            If tool.ID = myTs.ID Then

                tool.setProperty(myTs)

                Exit For

            End If

        Next

    End Sub

#End Region

#Region "Terminal Tab"

    Public Overrides Sub BT_TerminalSend_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        LogFile.Write(Me.TB_TerminalSend.Text & vbCr)

        CurrentDevice.serialPort.SendDirect(Me.TB_TerminalSend.Text)

    End Sub

    Public Overrides Sub BT_CLSRec_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.LB_TerminalRec.Items.Clear()

    End Sub

    Public Overrides Sub BT_FrontEnd_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.TB_TerminalSend.Text = Chr(27) & ".["

    End Sub

    Sub LB_TerminalRecText(ByVal value As String)

        If Me.LB_TerminalRec.InvokeRequired Then

            Me.LB_TerminalRec.Invoke(Sub() LB_TerminalRecText(value))

        Else

            Me.LB_TerminalRec.Items.Add(value)

            Me.LB_TerminalRec.TopIndex = Me.LB_TerminalRec.Items.Count - 1

        End If

    End Sub

    Public Overrides Sub BT_Write2Log_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        LogFile.Write(Me.TB_TerminalSend.Text)

    End Sub

#End Region

#Region "MachinePark Events"

    Public Sub CurrentDevice_ToolPositionChanged(ByVal e As CNC_EventArgs) Handles CurrentDevice.ToolPositionChanged

        If CBool(e.OldPos <> e.NewPos) Then

            DispConduit.MoveAbsoluteCursorObjects(e.OldPos, e.NewPos)

            CurrentDevice.CurTool.Location = e.NewPos

            UpdateDisplay()

        End If

    End Sub

    Sub PB_FileUpload_Increment(ByVal no As Integer, ByVal total As Integer)

        PB_Invoker(Me.PB_FileUpload, no, total)

    End Sub

    Sub PB_JobProcess_Increment(ByVal no As Integer, ByVal total As Integer)

        PB_Invoker(Me.PB_JobProcess, no, total)

    End Sub

    Private Sub CurrentDevice_DataBlockSended(ByVal no As Integer, ByVal total As Integer) Handles CurrentDevice.DataBlockSended

        PB_FileUpload_Increment(no, total)

    End Sub

    Private Sub CurrentDevice_UpdateJobProgress(ByVal no As Integer, ByVal total As Integer) Handles CurrentDevice.UpdateJobProgress

        If no = 0 Then 'wir sind fertig

            CurrentDevice_DeviceProcessFinished()

        Else

            PB_JobProcess_Increment(no, total)

            myWorker.UpdateLabel(CurrentDevice, RhWorker.LabelState.Processing)

        End If


    End Sub

    Private Sub CurrentDevice_JobToolObjectBegin(ByVal Id As System.Guid) Handles CurrentDevice.JobToolObjectBegin

        myWorker.SwitchObjectsInProgressBegin(DispConduit) ', Id)

    End Sub

    Private Sub CurrentDevice_ToolObjectFinished(ByVal Id As System.Guid) Handles CurrentDevice.ToolObjectFinished

        myWorker.SwitchObjectsInProgressEnd(DispConduit)

    End Sub

    Private Sub CurrentDevice_DateRecieved(ByVal input As String) Handles CurrentDevice.DateRecieved

        LB_TerminalRecText(input)

    End Sub

    Sub CurrentDevice_DeviceProcessFinished() Handles CurrentDevice.DeviceProcessFinished

        ControlsReactivate()

        myWorker.UpdateLabel(CurrentDevice, RhWorker.LabelState.Finished)

    End Sub

    Sub ControlFunctionInvoker(ByVal control As Control, ByVal FunctionName As String, ByVal value As Object)

        If control.InvokeRequired Then

            control.Invoke(Sub() ControlFunctionInvoker(control, FunctionName, value))

        Else

            CallByName(control, FunctionName, CallType.Set, value)

        End If

    End Sub

    Sub ControlMethodInvoker(ByVal control As Control, ByVal MethodName As String, ByVal value As Object)

        If control.InvokeRequired Then

            control.Invoke(Sub() ControlMethodInvoker(control, MethodName, value))

        Else

            If value Is Nothing Then

                CallByName(control, MethodName, CallType.Method)

            Else

                CallByName(control, MethodName, CallType.Method, value)

            End If

        End If

    End Sub

    Sub PB_Invoker(ByVal ProcessBar As ProgressBar, ByVal no As Integer, ByVal total As Integer)

        If ProcessBar.InvokeRequired Then

            ProcessBar.Invoke(Sub() PB_Invoker(ProcessBar, no, total))

        Else

            ProcessBar.Maximum = total

            ProcessBar.Value = no

        End If

    End Sub

#End Region

    Public Sub UpdateDisplay()

        numPrevent = True

        ControlFunctionInvoker(NumUD_X, "Value", CurrentDevice.CurTool.Location.X)

        ControlFunctionInvoker(NumUD_Y, "Value", CurrentDevice.CurTool.Location.Y)

        numPrevent = False

        RhinoDoc.ActiveDoc.Views.Redraw()

        GB_ToolPositionRefresh()

        PB_FileUploadRefresh()

        Application.DoEvents()

    End Sub

End Class
