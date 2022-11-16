Imports System.IO
Imports Rhino

<Guid("95A8FA72-6A25-4B88-AFA3-9E410EB79F2E")>
Public Class UIWrapper2

    Inherits PluginControls4

    Private WithEvents WorkShop As CNC_Workshop

    Private myWorker As RhWorker

    Private Property LayerContentIsChanging As Boolean

    Private EventsAllowed As Boolean = True

    Private myBBoxToolChooser As New ComboBox

    Sub PluginControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Initialize()

        AttachEventHandlers()

        RefreshControls()

    End Sub

    Sub Initialize()

        LogFile.Create("D:\CNC_Logfile-")

        'this reads the config files
        WorkShop = New CNC_Workshop

        'try to find a connected device, get the zund if is not connected
        WorkShop.LookingForDevice()

        WorkShop.SetDefaultDevice()

        'set the combobox for the devices
        Me.CB_DeviceChoose.Items.Clear()

        For Each d As CNC_Device In WorkShop.Devices

            Me.CB_DeviceChoose.Items.Add(d.DeviceName)

        Next

        'this is imposible but never say never
        If WorkShop.CurrentDevice Is Nothing Then

            Messenger.Desaster("no Device available, please check configuration")

            Exit Sub

        End If

        ' a helper class
        myWorker = New RhWorker
        'some handovers
        myWorker.InfoLabel = Me.Lbl_Info

        myWorker.PB_FileUpload = Me.PB_FileUpload

        myWorker.PB_JobProcess = Me.PB_JobProcess

        'ini a empty conduit
        myWorker.Conduit = New rhDisplayConduit()

        myWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)
        'before we adding the handler, otherwise we will raise the selectedindexchanged event
        Me.CB_DeviceChoose.SelectedIndex = CB_DeviceChoose.FindString(WorkShop.CurrentDevice.DeviceName)

        Me.CB_Source.SelectedIndex = 0

        Me.Lbl_Info.Text = ""

        Me.BT_StartDirect.Enabled = False

        SetBT_StartDirect()

    End Sub

    Sub AttachEventHandlers()
        'sorce drawing or exrternl plt file
        AddHandler CB_Source.SelectedIndexChanged, AddressOf Handle_CB_Source_SelectedIndexChanged

        'comboboxes for device and material
        AddHandler CB_DeviceChoose.SelectedIndexChanged, AddressOf Handle_CB_DeviceChoose_SelectedIndexChanged
        AddHandler CB_Material.SelectedIndexChanged, AddressOf Handle_CB_Material_SelectedIndexChanged
        'checkboxes for pathoptimizing and bounding box
        AddHandler CB_PathOpt.CheckedChanged, AddressOf Handle_CB_PathOpt_CheckedChanged
        AddHandler CB_BBox.CheckedChanged, AddressOf Handle_CB_BBox_CheckedChanged
        'preview/calculate tim
        AddHandler CB_Preview.CheckedChanged, AddressOf Handle_CB_Preview_CheckedChanged
        'move the device origin
        AddHandler BT_Set0.Click, AddressOf Handle_BT_SetZero_Click
        'start job direct to the machine
        AddHandler BT_StartDirect.Click, AddressOf Handle_BT_StartDirect_Click
        'write a jobfile
        AddHandler BT_WriteFile.Click, AddressOf Handle_BT_WriteFile_Click

        '  AddHandler CB_ShowHideDevice.CheckedChanged, AddressOf Handle_CB_ShowHideDevice

        'layer tab
        'a rhino event for the layertabel

        AddHandler RhinoDoc.ActiveDoc.LayerTableEvent, AddressOf LayerTableEvent

        AddHandler CB_ShowVisibleLayers.CheckedChanged, AddressOf Handle_CB_ShowVisibleLayers_CheckedChanged
        AddHandler DGV_LayerGrid.CellValueChanged, AddressOf Handle_DGV_LayerGrid_CellValueChanged

    End Sub

    ''' <summary>
    ''' enables or disable the direct cut button if the device currently conected
    ''' </summary>
    Sub SetBT_StartDirect() Handles WorkShop.DeviceDetected

        If WorkShop.CurrentDevice.ID = WorkShop.DetectedDeviceID Then

            ControlFunctionInvoker(BT_StartDirect, "Enabled", True)

        Else

            ControlFunctionInvoker(BT_StartDirect, "Enabled", False)

        End If

    End Sub

    Private Sub Handle_CB_Source_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        Select Case CB_Source.SelectedItem.ToString

            Case "File"
                MakeItFromFile()

            Case "Current Drawing"
                MakeItFromDrawing()

        End Select

    End Sub

    Sub MakeItFromFile()
        'preview off
        CB_Preview.Checked = False

        CB_DeviceChoose.Enabled = False

        'what ever was in it, get rid of it
        WorkShop.CurrentDevice.PurgeOldObjectsFromTools()

        'a little helper
        Dim myHPGL_Reader As New HPGL_Reader

        'read and remember the located device id
        Dim myID As String = myHPGL_Reader.ParseHPGLFile(GetFileName, WorkShop)

        RefreshControls()

        If myID = String.Empty Then

            Exit Sub
        Else
            'HACK: sets the geomtryorder to none optimization, this is necassary for a proper preview process
            myWorker.Optimizer.OptimizePathes_None(WorkShop.CurrentDevice)
        End If

        'load the proper device to conduit otherwise the old (wrong?) device will be shown
        myWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)

        'this triggered the preview on
        CB_Preview.Checked = True

    End Sub

    Sub MakeItFromDrawing()
        'preview off
        CB_Preview.Checked = False

        CB_DeviceChoose.Enabled = True

        'what ever was in it, get rid of it
        WorkShop.CurrentDevice.PurgeOldObjectsFromTools()

        'to indicate that the content is from a file and not from the drawing
        WorkShop.CurrentDevice.fromFile = False

        'triggered a device change
        Handle_CB_DeviceChoose_SelectedIndexChanged(Nothing, Nothing)

        RefreshControls()

    End Sub

    ''' <summary>
    ''' opens a OpenFileDialog and retunrns a filename
    ''' </summary>
    Function GetFileName() As String

        Dim myDialog = New OpenFileDialog

        myDialog.Filter = "plt files (*.plt)|*.plt|All files (*.*)|*.*"

        myDialog.FilterIndex = 1

        myDialog.Title = "Open Plotfile"

        myDialog.RestoreDirectory = True

        If myDialog.ShowDialog() = DialogResult.OK Then

            LogFile.Write("selected file: " & myDialog.FileName)

            Return myDialog.FileName

        End If

        Return Nothing

    End Function

    Sub Handle_CB_DeviceChoose_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If EventsAllowed Then

            SwitchWaitOn()
            'shutdown the old one
            If WorkShop.CurrentDevice IsNot Nothing Then

                WorkShop.CurrentDevice.PurgeOldObjectsFromTools()

                myWorker.Conduit.Purge(withZeropoint:=True)

            End If

            WorkShop.SetCurrentDeviceByName(CB_DeviceChoose.SelectedItem.ToString)

            myWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)

            'preview off
            CB_Preview.Checked = False

            SwitchWaitOff()

            Me.Refresh()

            RhinoDoc.ActiveDoc.Views.Redraw()

            RefreshControls()

        End If

    End Sub

    Private Sub UD_ValueChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)

        Dim myUD As NumericUpDown = CType(sender, NumericUpDown)

        Dim myTs As New CNC_ToolSetting

        myTs.ID = myUD.Parent.Text

        CallByName(myTs, myUD.Tag.ToString, CallType.Set, myUD.Value)

        For Each tool As CNC_Tool In WorkShop.CurrentDevice.Tools

            If tool.ID = myTs.ID Then

                tool.setProperty(myTs)


                Exit For

            End If

        Next

    End Sub

    Sub Handle_CB_Material_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If EventsAllowed Then

            Dim myNewMat As CNC_Material

            Select Case CB_Material.SelectedItem.ToString

                Case "Default Settings"
                    For Each tool As CNC_Tool In WorkShop.CurrentDevice.Tools

                        tool.setDefault()

                    Next

                    BuildToolControls()

                    Exit Sub

                Case "User Settings"

                    BuildToolControls()

                    Exit Sub

            End Select

            myNewMat = CType(CB_Material.SelectedItem, CNC_Material)

            For Each ts As CNC_ToolSetting In myNewMat.ToolSettings

                For Each tool As CNC_Tool In WorkShop.CurrentDevice.Tools

                    If tool.ID = ts.ID Then

                        tool.setProperty(ts)

                    End If

                Next

            Next

            WorkShop.CurrentDevice.setBBoxTool(myNewMat.BBoxTool)

            BuildToolControls()

        End If

    End Sub

    'Private Sub Handle_CB_ShowHideDevice(ByVal sender As Object, ByVal e As EventArgs)

    '    If CB_ShowHideDevice.Checked Then

    '        myWorker.Conduit.EnableDevice()

    '        CB_ShowHideDevice.Text = "Hide" & vbCrLf & "Device"

    '    Else

    '        If CB_Preview.Checked Then

    '            CB_Preview.Checked = False

    '        End If

    '        myWorker.Conduit.DisableDevice()

    '        CB_ShowHideDevice.Text = "Show" & vbCrLf & "Device"

    '    End If

    'End Sub

    Private DeviceWasOn As Boolean

    Sub Handle_CB_Preview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CB_Preview.Checked Then

            '  DeviceWasOn = CB_ShowHideDevice.Checked

            PB_FileUpload.Value = PB_FileUpload.Minimum

            PB_JobProcess.Value = PB_JobProcess.Minimum

            WorkShop.CurrentDevice.withBBox = CB_BBox.Checked

            myWorker.PreviewOn(WorkShop.CurrentDevice, CB_PathOpt.Checked)

            '    CB_ShowHideDevice.Checked = True

            CB_Preview.Text = "Preview Off"

            '   CB_ShowHideDevice.Checked = True

        Else

            myWorker.PreviewOff()

            If DeviceWasOn Then

                '      CB_ShowHideDevice.Checked = True

                myWorker.Conduit.EnableDevice()

            Else

                '    CB_ShowHideDevice.Checked = False

            End If


            CB_Preview.Text = "Calculate Time"

        End If

    End Sub

    Sub Handle_BT_SetZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Enabled = False

        Dim PreviewState As Boolean

        PreviewState = CB_Preview.Checked

        'trigering preview off if its was on
        CB_Preview.Checked = False

        If myWorker.Conduit.DeviceFixObjects.Count = 0 Then

            myWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)

        End If

        myWorker.Conduit.EnableJob()

        myWorker.newZero(WorkShop.CurrentDevice)

        CB_Preview.Checked = PreviewState

        'If CB_ShowHideDevice.Checked Then

        '    myWorker.Conduit.EnableDevice()

        'Else

        '    myWorker.Conduit.DisableDevice()

        'End If


        Me.Enabled = True

    End Sub

    Sub Handle_CB_PathOpt_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        CB_Preview.Checked = False

    End Sub

    ''' <summary>
    ''' Bounding Box ein/ausschalten
    ''' </summary>
    Sub Handle_CB_BBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'switch off preview because is superseeded
        CB_Preview.Checked = False

        If WorkShop.CurrentDevice Is Nothing Then

            Exit Sub

        End If

        WorkShop.CurrentDevice.withBBox = CB_BBox.Checked

    End Sub

    Sub Handle_BT_StartDirect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        myWorker.CreateJobString(WorkShop.CurrentDevice, Me.CB_Preview.Checked, CB_PathOpt.Checked)

        WorkShop.SendToSerial()

    End Sub

    Sub Handle_BT_WriteFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        SwitchWaitOn()

        Dim myDialog = New SaveFileDialog

        Dim myFileStream As IO.Stream

        If WorkShop.CurrentDevice.TotalGeometryCount = 0 Then ' Is Nothing OrElse MachinePark.CurrentDevice.JobBuffer.Length = 0 Then

            Messenger.Info("There are no objects to work with it.")
            SwitchWaitOff()
            Exit Sub

        End If

        ' Dim userInput As New IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(MachinePark.CurrentDevice.JobBuffer.))

        myDialog.Filter = "plt files (*.plt)|*.plt|All files (*.*)|*.*"

        myDialog.FilterIndex = 1

        myDialog.Title = "Save Plotfile"

        myDialog.RestoreDirectory = True

        If myDialog.ShowDialog() = DialogResult.OK Then

            LogFile.Write("Start File Writing")

            myFileStream = myDialog.OpenFile

            If (myFileStream IsNot Nothing) Then

                myWorker.CreateJobString(WorkShop.CurrentDevice, Me.CB_Preview.Checked, CB_PathOpt.Checked)

                Dim userInput As MemoryStream =
                New MemoryStream(System.Text.Encoding.ASCII.GetBytes(WorkShop.CurrentDevice.JobBuffer.ToString()))

                userInput.Position = 0

                userInput.WriteTo(myFileStream)

                LogFile.Write(WorkShop.CurrentDevice.JobBuffer.ToString)

                myFileStream.Close()

                WorkShop.CurrentDevice.JobBuffer.Clear()

                LogFile.Write("End File Writing")

            End If

        End If
        SwitchWaitOff()

    End Sub

    Sub SwitchWaitOn()
        Me.Enabled = False

        Me.Cursor = Cursors.WaitCursor

    End Sub

    Sub SwitchWaitOff()
        Me.Cursor = Cursors.Default

        Me.Enabled = True

    End Sub

    Sub SendStreamSerial(ByVal SerialStream As IO.Stream)
        LogFile.Write("Start Serial Transmision")

        'switch device Online
        WorkShop.SendDirect(Chr(27) & ".[ZF5;")

        'starts stopwatch for estimated times
        CNC_Workshop.ProcessTimer.Restart()

        WorkShop.SendToSerial()

        LogFile.Write("End Serial Transmision")

    End Sub


    Private Sub RefreshControls()
        'to prevent events
        EventsAllowed = False

        'set combo device
        Me.CB_DeviceChoose.SelectedIndex = CB_DeviceChoose.FindString(WorkShop.CurrentDevice.DeviceName)

        BuildMaterialList()

        BuildToolControls()

        SetBT_StartDirect()

        Me.Refresh()

        EventsAllowed = True

    End Sub

    Sub PB_FileUploadRefresh()

        ControlMethodInvoker(Me.PB_FileUpload, "Refresh", Nothing)

        Me.PB_FileUpload.Refresh()

    End Sub

#Region "Helpers"
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

    Sub BuildMaterialList()

        CB_Material.Items.Clear()

        If WorkShop.CurrentDevice.fromFile Then

            CB_Material.Items.Add("User Settings")

        End If

        CB_Material.Items.Add("Default Settings")

        For Each Material As CNC_Material In WorkShop.MaterialsFor(WorkShop.CurrentDevice)

            CB_Material.Items.Add(Material)

        Next

        CB_Material.SelectedIndex = 0

    End Sub

    Private Sub BuildToolControls()

        Dim myToolTips As New ToolTip

        Me.GBTools.Visible = False

        Me.FLP_Tools.Controls.Clear()

        Dim _width As Integer = 190

        Dim _height As Integer = 73

        Dim propYOffset As Integer = 21

        Dim ToolYOffset As Integer = 31

        Dim y As Integer = 0

        For Each tool As CNC_Tool In WorkShop.CurrentDevice.Tools

            Dim aGroupBox As New GroupBox

            aGroupBox.Text = tool.ID

            aGroupBox.Width = _width

            Me.FLP_Tools.Controls.Add(aGroupBox)

            Dim propY As Integer = 0

            aGroupBox.Location = New Drawing.Point(3, y + propYOffset)

            For Each prop As CNC_Property In tool.Properties

                If prop.isHidden Then Continue For

                If prop.ID.Contains("tool") Then

                    Continue For

                End If

                Dim aLabel As New Label

                aLabel.Text = prop.Text

                aLabel.AutoSize = True

                aGroupBox.Controls.Add(aLabel)

                propY += propYOffset

                aLabel.Location = New Drawing.Point(aGroupBox.Location.X + 3, propY)

                Dim aUpDown As New NumericUpDown

                aUpDown.DecimalPlaces = 1

                aUpDown.Minimum = CDec(prop.min)

                aUpDown.Maximum = CDec(prop.max)

                If prop.Value <= prop.max AndAlso
                    prop.Value >= prop.min Then

                    aUpDown.Value = CDec(prop.Value)

                End If

                aUpDown.Size = New Drawing.Size(58, 20)

                myToolTips.SetToolTip(aUpDown, aUpDown.Minimum & " - " & aUpDown.Maximum)

                aGroupBox.Controls.Add(aUpDown)

                aUpDown.Location = New Drawing.Point(aLabel.Location.X + 122, aLabel.Location.Y - 2)

                aUpDown.Tag = prop.ID

                AddHandler aUpDown.ValueChanged, AddressOf UD_ValueChanged_Handler

            Next

            aGroupBox.Height = propY + ToolYOffset

            y += aGroupBox.Height

        Next

        Dim myBBoxPanel As New Panel

        myBBoxPanel.Width = _width

        myBBoxPanel.Height = 30

        myBBoxPanel.Location = New Drawing.Point(GBTools.Location.X + 3, y + 24)

        Dim BBoLabele As New Label

        BBoLabele.Text = "Bounding Box Tool:"

        BBoLabele.Location = New Drawing.Point(3, 3)

        myBBoxPanel.Controls.Add(BBoLabele)

        RemoveHandler myBBoxToolChooser.SelectedIndexChanged, AddressOf Handle_myBBoxToolChooser_SelectedIndexChanged

        myBBoxToolChooser = New ComboBox

        myBBoxToolChooser.Location = New Drawing.Point(BBoLabele.Location.X + 125, 3)

        myBBoxToolChooser.Width = 58

        For Each tt As CNC_Tool In WorkShop.CurrentDevice.Tools

            myBBoxToolChooser.Items.Add(tt.ID)

        Next

        If WorkShop.CurrentDevice.BBoxToolID = String.Empty Then

            WorkShop.CurrentDevice.setBBoxTool(New List(Of String))

        End If

        myBBoxToolChooser.SelectedText = WorkShop.CurrentDevice.BBoxToolID

        AddHandler myBBoxToolChooser.SelectedIndexChanged, AddressOf Handle_myBBoxToolChooser_SelectedIndexChanged

        myBBoxPanel.Controls.Add(myBBoxToolChooser)

        Me.FLP_Tools.Controls.Add(myBBoxPanel)

        Me.GBTools.Visible = True

    End Sub

    Private Sub Handle_myBBoxToolChooser_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        WorkShop.CurrentDevice.BBoxToolID = myBBoxToolChooser.SelectedItem.ToString

    End Sub

#End Region

#Region "LayerTab"

    Public Sub LayerTableEvent(ByVal sender As Object, ByVal e As DocObjects.Tables.LayerTableEventArgs)

        LayerContentIsChanging = False

        myWorker.RefreshLayerList(DGV_LayerGrid, MyBase.CB_ShowVisibleLayers.Checked)

        LayerContentIsChanging = True

    End Sub

    Sub Handle_DGV_LayerGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        If LayerContentIsChanging Then

            myWorker.CellEvent(DGV_LayerGrid, e)

            If CB_Preview.Checked Then

                myWorker.PreviewOff()

                myWorker.PreviewOn(WorkShop.CurrentDevice, CB_PathOpt.Checked)

            End If

        End If

    End Sub

    Sub Handle_CB_ShowVisibleLayers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LayerContentIsChanging = False

        myWorker.RefreshLayerList(DGV_LayerGrid, MyBase.CB_ShowVisibleLayers.Checked)

        LayerContentIsChanging = True

    End Sub

#End Region

#Region "MachinePark Events"

    Public Sub CurrentDevice_ToolPositionChanged(ByVal Position As Coordinate) Handles WorkShop.ToolPositionChanged

        myWorker.Conduit.MoveAbsoluteCursorObjects(WorkShop.CurrentDevice) ', Position)

        WorkShop.CurrentDevice.ToolPosition = Position

    End Sub

    Private Sub CurrentDevice_DataBlockSended(ByVal no As Integer, ByVal total As Integer) Handles WorkShop.DataBlockSended

        PB_Invoker(Me.PB_FileUpload, no, total)

    End Sub

    Private Sub CurrentDevice_UpdateJobProgress(ByVal no As Integer) Handles WorkShop.UpdateJobProgress

        RhWorker.CurrentObjectLength = myWorker.Conduit.SwitchObjectsInProgressBegin()

        WorkShop.CurrentDevice.CurrentObject = no

        If no = 0 Then 'wir sind fertig

            CurrentDevice_DeviceProcessFinished()

        Else

            PB_Invoker(Me.PB_JobProcess, no, WorkShop.CurrentDevice.TotalGeometryCount)

            myWorker.ShowProcessingTime(WorkShop.CurrentDevice)

        End If

    End Sub

    Private Sub CurrentDevice_ToolObjectFinished() Handles WorkShop.ToolObjectFinished

        myWorker.Conduit.ObjectFinished()

    End Sub

    Sub CurrentDevice_DeviceProcessFinished() Handles WorkShop.DeviceProcessFinished

        ControlFunctionInvoker(CB_Preview, "Checked", False)

        myWorker.ShowFinishedTime(WorkShop.CurrentDevice)

        PB_Invoker(PB_FileUpload, 0, 1)

        PB_Invoker(PB_JobProcess, 0, 1)

    End Sub

    Sub ControlFunctionInvoker(ByVal control As Control, ByVal FunctionName As String, ByVal value As Object)

        If control.InvokeRequired Then

            control.Invoke(Sub() ControlFunctionInvoker(control, FunctionName, value))

        Else

            CallByName(control, FunctionName, CallType.Set, value)

        End If

    End Sub

    Sub PB_Invoker(ByVal ProcessBar As ProgressBar, ByVal no As Integer, ByVal total As Integer)

        If ProcessBar.InvokeRequired Then

            ProcessBar.Invoke(Sub() PB_Invoker(ProcessBar, no, total))

        Else

            ProcessBar.Maximum = total

            If no <= total Then

                ProcessBar.Value = no

            End If

        End If

    End Sub

#End Region

    Private Sub InitializeComponent()
        CType(Me.SplitContainer_Layers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Layers.Panel1.SuspendLayout()
        Me.SplitContainer_Layers.SuspendLayout()
        Me.P_Bottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer_Layers
        '
        '
        'UIWrapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "UIWrapper"
        Me.SplitContainer_Layers.Panel1.ResumeLayout(False)
        Me.SplitContainer_Layers.Panel1.PerformLayout()
        CType(Me.SplitContainer_Layers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Layers.ResumeLayout(False)
        Me.P_Bottom.ResumeLayout(False)
        Me.P_Bottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

End Class
