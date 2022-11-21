Imports System.IO
Imports Rhino

<Guid("06D01CD3-3455-429D-B822-D72AC1AEF8C3")>
Public Class UIWrapper
    Inherits PluginControls3

    ''' <summary>
    ''' instace to the workshop
    ''' </summary>
    Public WithEvents WorkShop As CNC_Workshop

    ''' <summary>
    ''' a little helper with all rhino stuff
    ''' </summary>
    Protected Friend RhinoWorker As RhWorker

    ''' <summary>
    ''' protector during form settings each other
    ''' </summary>
    Private EventsAllowed As Boolean = True

    ' ''' <summary>
    ' ''' a comboboxfor the bbox tool
    ' ''' </summary>
    'Private CB_BBoxToolChooser As New ComboBox

    ''' <summary>
    ''' our tooltips
    ''' </summary>
    Private Tooltips As ToolTip

    ''' <summary>
    ''' a modal window to prevent rhino using while we trace the cut progress on the screen
    ''' </summary>
    Private DialogStopTraceForm As New DialogStopTrace

    ''' <summary>
    ''' flag to remember that the device was visible while toggle preview
    ''' </summary>
    Private DeviceWasOn As Boolean

    ''' <summary>
    ''' remember the last jobno from the device to track the right order
    ''' </summary>
    Private Shared LastJobNo As Integer = 0

    ''' <summary>
    ''' we are in the right job order
    ''' </summary>
    Private Shared WeAreInFlow As Boolean = False

    ''' <summary>
    ''' here we start
    ''' </summary>
    Sub PluginControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Initialize()

        InitToolTips()

        AttachEventHandlers()

        RefreshControls()

    End Sub

    ''' <summary>
    ''' the firsts things todo
    ''' </summary>
    Sub Initialize()

        'this reads the config files
        WorkShop = New CNC_Workshop

        LogFile.Create("c:\temp\CNC_Logfile-")

        WorkShop.SetCurrentDefaultDevice()

        'set the combobox for the devices
        Me.CB_DeviceChoose.Items.Clear()

        Dim mylist As New List(Of String)

        For Each d As CNC_Device In WorkShop.Devices

            Me.CB_DeviceChoose.Items.Add(d.DeviceName)

            'fill all tool names for the layer/tool schedule
            For Each t As CNC_Tool In d.Tools

                mylist.Add(t.ID)

            Next

        Next

        mylist.Sort()

        For a = mylist.Count - 1 To 1 Step -1

            If mylist(a) = mylist(a - 1) Then
                mylist.RemoveAt(a)
                ' a -= 1
            End If

        Next

        Dim cmb As DataGridViewComboBoxColumn = CType(Me.DGV_LayerGrid.Columns(1), DataGridViewComboBoxColumn)

        cmb.Items.Clear()

        cmb.Items.Add("-")

        For Each p As String In mylist

            cmb.Items.Add(p)

        Next

        'this is imposible but never say never
        If WorkShop.CurrentDevice Is Nothing Then

            Messenger.Desaster("no Device available, please check configuration")

            Exit Sub

        End If

        'initialize the helper
        'ini an empty conduit
        RhinoWorker = New RhWorker With {
            .Conduit = New RhDisplayConduit()
        }

        RhinoWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)

        'before we adding the handler, otherwise we will raise the selectedindexchanged event
        Me.CB_DeviceChoose.SelectedIndex = CB_DeviceChoose.FindString(WorkShop.CurrentDevice.DeviceName)

        'Me.CB_Source.SelectedIndex = 0

        Me.Lbl_Info.Text = ""

        CB_ShowCutter.Checked = False

        CB_ShowCutter.Text = "Show Cutter"

        'CB_BBoxToolChooser.Enabled = CB_BBox.Checked

        'we check this later but here is a save value
        Me.BT_StartDirect.Enabled = False

        'BT_Set0 and BT_MoveJob are on the same location so we have to toggle his visibility
        Me.BT_Set0.Visible = True

        Me.BT_MoveJob.Visible = False

    End Sub

    ''' <summary>
    ''' setups all tooltip texts
    ''' </summary>
    Sub InitToolTips()

        Tooltips = New ToolTip

        'Tooltips.SetToolTip(Me.CB_Source,
        '                    "Choose the origin of your cut job. " & vbCrLf &
        '                    "The current open drawing or " & vbCrLf &
        '                    "an external previously prepared plt-file")

        Tooltips.SetToolTip(Me.CB_DeviceChoose,
                            "Choose the target device. " & vbCrLf &
                            "You can choose between ""Zünd MS-1200 Cutter""" & vbCrLf &
                            "or the ""Eurolaser 800""")

        Tooltips.SetToolTip(Me.CB_Material,
                            "Some presets for different materials. " & vbCrLf &
                            "You can stil change this later. ")

        'Tooltips.SetToolTip(Me.CB_PathOpt, "Finds a short way through the geometry to save cutting time.")

        'Tooltips.SetToolTip(Me.CB_BBox, "Cuts a bounding box around your geometry with an offset of 5 mm.")

        Tooltips.SetToolTip(Me.CB_ShowCutter, "Switch the display of the current device on or off.")

        Tooltips.SetToolTip(Me.CB_Preview, "Shows a preview of all objects which will be cut.")

        Tooltips.SetToolTip(Me.BT_Set0,
                            "LMB: Moves the cutter from a point to a point." & vbCrLf &
                            "RMB: Moves the cutter zeropoint to a point.")

        Tooltips.SetToolTip(Me.BT_StartDirect,
                            "LMB: Sends the job direct to the device and trace the job progress." & vbCrLf &
                            "RMB: Sends the job direct to the device without tracing.")

        'Tooltips.SetToolTip(Me.BT_WriteFile,
        '                    "Saves the job as a file for later use. " & vbCrLf &
        '                    "Later, you can still change the tool settings (speed, etc.).")

        Tooltips.SetToolTip(Me.PB_FileUpload, "The job-upload progress.")

        Tooltips.SetToolTip(Me.PB_JobProcess, "The cut progress.")

        Tooltips.SetToolTip(Me.CB_ShowVisibleLayers, "filter to show only visible layers")

        Dim Cutstring As String = String.Empty

        For Each a As String In WorkShop.CurrentDevice.ToolOrder

            Cutstring &= a & " - "

        Next

        Cutstring = Cutstring.Remove(Cutstring.Length - 3, 3)

        Tooltips.SetToolTip(Me.CB_CutByLayerOrder, "Cuts the element respecting the layer sort order from top to down." & vbCrLf &
                                    "Otherwise its cuting in this order: " & Cutstring)

        Tooltips.SetToolTip(Me.BT_MoveJob, "Moves the job geomtry inside the cut area.")

    End Sub

    ''' <summary>
    ''' attaching all eventHandlers
    ''' </summary>
    Sub AttachEventHandlers()
        'sorce drawing or exrternl plt file
        'AddHandler CB_Source.SelectedIndexChanged, AddressOf Handle_CB_Source_SelectedIndexChanged

        'comboboxes for device and material
        AddHandler CB_DeviceChoose.SelectedIndexChanged, AddressOf Handle_CB_DeviceChoose_SelectedIndexChanged
        AddHandler CB_Material.SelectedIndexChanged, AddressOf Handle_CB_Material_SelectedIndexChanged
        'checkboxes for pathoptimizing and bounding box
        'AddHandler CB_PathOpt.CheckedChanged, AddressOf Handle_CB_PathOpt_CheckedChanged
        'AddHandler CB_BBox.CheckedChanged, AddressOf Handle_CB_BBox_CheckedChanged
        'preview/calculate tim
        AddHandler CB_Preview.CheckedChanged, AddressOf Handle_CB_Preview_CheckedChanged
        'move the device origin

        AddHandler BT_Set0.MouseUp, AddressOf Handle_BT_SetZero_MouseUp

        'start job direct to the machine
        AddHandler BT_StartDirect.MouseUp, AddressOf Handle_BT_StartDirect_MouseUp
        'write a jobfile
        AddHandler BT_WriteFile.Click, AddressOf Handle_BT_WriteFile_Click

        AddHandler CB_ShowCutter.CheckedChanged, AddressOf Handle_CB_ShowHideDevice

        AddHandler BT_StopTransmit.Click, AddressOf Handle_BT_StopTransmit_Click

        'layer tab
        'a rhino event for the layertabel

#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        AddHandler RhinoDoc.ActiveDoc.LayerTableEvent, AddressOf Handle_LayerTableEvent
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance

        AddHandler CB_ShowVisibleLayers.CheckedChanged, AddressOf Handle_CB_ShowVisibleLayers_CheckedChanged

        AddHandler CB_CutByLayerOrder.CheckedChanged, AddressOf Handle_CB_CutByLayerOrder_CheckedChanged


        AddHandler DGV_LayerGrid.EditingControlShowing, AddressOf Handle_DGV_EditingControlShowing

        AddHandler DGV_LayerGrid.DataError, AddressOf Handle_DataGridView1_DataError

        AddHandler BT_MoveJob.MouseUp, AddressOf Handle_BT_MoveJob_MouseUp


    End Sub

    ''' <summary>
    ''' Updates all controls
    ''' </summary>
    Sub RefreshControls()
        'to prevent events
        EventsAllowed = False

        'set combo device
        Me.CB_DeviceChoose.SelectedIndex = CB_DeviceChoose.FindString(WorkShop.CurrentDevice.DeviceName)

        Me.BuildMaterialList()

        Me.BuildToolControls()

        If WorkShop.IsControlComputer Then

            Invoker_ControlFunction(BT_StartDirect, "Enabled", True)

        Else

            Invoker_ControlFunction(BT_StartDirect, "Enabled", False)

        End If

        RhinoWorker.RefreshLayerList(DGV_LayerGrid, MyBase.CB_ShowVisibleLayers.Checked)

        Me.Lbl_Info.Text =
            "© CNC Workshop" & vbCrLf &
            "Version: " & My.Application.Info.Version.ToString & vbCrLf &
            "Date: " & IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString("d.MM.yyyy HH:mm:ss")

        Me.Refresh()

        EventsAllowed = True

    End Sub

    '''' <summary>
    '''' reading a file and so
    '''' </summary> 
    'Sub MakeItFromFile()
    '    'preview off
    '    CB_Preview.Checked = False

    '    CB_DeviceChoose.Enabled = False

    '    'what ever was in it, get rid of it
    '    WorkShop.CurrentDevice.PurgeOldObjectsFromTools()

    '    'a little helper
    '    Dim myHPGL_Reader As New HPGL_Reader

    '    Dim myFilename As String

    '    myFilename = GetFileName()

    '    'read and remember the located device id
    '    Dim myID As String = myHPGL_Reader.ParseHPGLFile(myFilename, WorkShop)

    '    RefreshControls()

    '    If myID = String.Empty Then

    '        Exit Sub
    '    Else

    '        RhinoWorker.Optimizer.CreateProcessOrder(WorkShop.CurrentDevice)
    '    End If

    '    'load the proper device to conduit otherwise the old (wrong?) device will be shown
    '    RhinoWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)

    '    'this triggered the preview on
    '    CB_Preview.Checked = True

    'End Sub

    ''' <summary>
    ''' create the job based on our drawing
    ''' </summary>
    Sub MakeItFromDrawing()
        'preview off
        CB_Preview.Checked = False

        CB_DeviceChoose.Enabled = True

        'what ever was in it, get rid of it
        WorkShop.CurrentDevice.PurgeOldObjectsFromTools()

        'to indicate that the content is from a file and not from the drawing
        WorkShop.CurrentDevice.FromFile = False

        'triggered a device change
        Handle_CB_DeviceChoose_SelectedIndexChanged(Nothing, Nothing)

        RefreshControls()

    End Sub

    ''' <summary>
    ''' opens a OpenFileDialog and returns a filename
    ''' </summary>
    Function GetFileName() As String
        Dim myDialog = New OpenFileDialog With {
            .Filter = "plt files (*.plt)|*.plt|All files (*.*)|*.*",
            .FilterIndex = 1,
            .Title = "Open Plotfile",
            .RestoreDirectory = True
        }

        If myDialog.ShowDialog() = DialogResult.OK Then

            LogFile.Write("selected file: " & myDialog.FileName)

            Return myDialog.FileName

        End If

        Return Nothing

    End Function

    ''' <summary>
    ''' creates the list of all materials in the comolist
    ''' </summary>
    Sub BuildMaterialList()

        CB_Material.Items.Clear()

        If WorkShop.CurrentDevice.FromFile Then

            CB_Material.Items.Add("User Settings")

        End If

        CB_Material.Items.Add("Default Settings")

        For Each Material As CNC_Material In WorkShop.MaterialsFor(WorkShop.CurrentDevice)

            CB_Material.Items.Add(Material)

        Next

        CB_Material.SelectedIndex = 0

    End Sub

    ''' <summary>
    ''' creates all controls for the tool settings
    ''' </summary>
    Private Sub BuildToolControls()

        Dim myToolTips As New ToolTip

        Me.GBTools.Visible = False

        Me.FLP_Tools.Controls.Clear()

        Dim _width As Integer = 480

        Dim _height As Integer = 146

        Dim propYOffset As Integer = 42

        Dim ToolYOffset As Integer = 62
        'Dim _width As Integer = 190

        'Dim _height As Integer = 73

        'Dim propYOffset As Integer = 21

        'Dim ToolYOffset As Integer = 31

        Dim y As Integer = 0

        For Each tool As CNC_Tool In WorkShop.CurrentDevice.Tools

            Dim aGroupBox As New GroupBox With {
                .Text = tool.ID,
                .Width = _width
            }

            Me.FLP_Tools.Controls.Add(aGroupBox)

            Dim propY As Integer = 0

            aGroupBox.Location = New Drawing.Point(6, y + propYOffset)

            For Each prop As CNC_Property In tool.Properties

                If prop.IsHidden Then Continue For


                Dim aLabel As New Label

                If prop.ID.Contains("tool") Then

                    aLabel.Text = prop.ID

                    aLabel.AutoSize = True

                    aGroupBox.Controls.Add(aLabel)

                    propY += propYOffset

                    aLabel.Location = New Drawing.Point(aGroupBox.Location.X + 6, propY)

                    Dim myT As New TextBox With {
                        .Size = New Drawing.Size(116, 40)
                    }
                    aGroupBox.Controls.Add(myT)
                    myT.Location = New Drawing.Point(aLabel.Location.X + 244, aLabel.Location.Y - 4)
                    myT.Tag = prop.ID

                    myT.Text = prop.Text

                    AddHandler myT.TextChanged, AddressOf Handler_TB_TextChanged

                    Continue For

                End If

                aLabel.Text = prop.Text

                aLabel.AutoSize = True

                aGroupBox.Controls.Add(aLabel)

                propY += propYOffset

                aLabel.Location = New Drawing.Point(aGroupBox.Location.X + 6, propY)

                Dim aUpDown As New NumericUpDown With {
                    .DecimalPlaces = CInt(prop.DisplayDecimalPlaces),
                    .Increment = CDec(prop.DisplayIncrement),
                    .Minimum = CDec(prop.Min * prop.DisplayFactor),
                    .Maximum = CDec(prop.Max * prop.DisplayFactor)
                }

                If prop.Value <= prop.Max AndAlso
                    prop.Value >= prop.Min Then

                    aUpDown.Value = CDec(prop.Value * prop.DisplayFactor)

                End If

                aUpDown.Size = New Drawing.Size(114, 40)

                myToolTips.SetToolTip(aUpDown, aUpDown.Minimum & " - " & aUpDown.Maximum)

                aGroupBox.Controls.Add(aUpDown)

                aUpDown.Location = New Drawing.Point(aLabel.Location.X + 344, aLabel.Location.Y - 4)

                aUpDown.Tag = prop.ID

                AddHandler aUpDown.ValueChanged, AddressOf Handler_UD_ValueChanged

            Next

            aGroupBox.Height = propY + ToolYOffset

            y += aGroupBox.Height

        Next

        'Dim myBBoxPanel As New Panel

        ' myBBoxPanel.Width = _width

        'myBBoxPanel.Height = 30

        'myBBoxPanel.Location = New Drawing.Point(GBTools.Location.X + 3, y + 24)

        'Dim BBoxLabel As New Label

        'BBoxLabel.Text = "Bounding Box Tool:"

        'BBoxLabel.Location = New Drawing.Point(3, 3)

        'myBBoxPanel.Controls.Add(BBoxLabel)

        'RemoveHandler CB_BBoxToolChooser.SelectedIndexChanged, AddressOf Handle_BBoxToolChooser_SelectedIndexChanged

        ' CB_BBoxToolChooser = New ComboBox

        'CB_BBoxToolChooser.Items.Clear()

        'CB_BBoxToolChooser.Text = ""

        'CB_BBoxToolChooser.Location = New Drawing.Point(BBoxLabel.Location.X + 125, 3)

        'CB_BBoxToolChooser.Width = 58

        'For Each tt As CNC_Tool In WorkShop.CurrentDevice.Tools

        '    CB_BBoxToolChooser.Items.Add(tt.ID)

        'Next

        If WorkShop.CurrentDevice.BBoxToolID = String.Empty Then

            WorkShop.CurrentDevice.SetBBoxTool(New List(Of String))

        End If

        'CB_BBoxToolChooser.SelectedText = WorkShop.CurrentDevice.BBoxToolID

        'AddHandler CB_BBoxToolChooser.SelectedIndexChanged, AddressOf Handle_BBoxToolChooser_SelectedIndexChanged

        '  myBBoxPanel.Controls.Add(CB_BBoxToolChooser)

        'Me.FLP_Tools.Controls.Add(myBBoxPanel)

        Me.GBTools.Visible = True

    End Sub

    ''' <summary>
    ''' this will stop the job tracing mechanism
    ''' </summary>
    Private Sub StopTracing()

        RhinoWorker.PreviewOff()

        Invoker_ControlFunction(CB_Preview, "Checked", False)

        Invoker_ControlFunction(PB_JobProcess, "Value", 0)

        Invoker_ControlFunction(PB_JobProcess, "Maximum", 1)

        RhinoWorker.Conduit.PurgeJob(withZeropoint:=False)

        WeAreInFlow = False

        LastJobNo = 0

        CNC_Workshop.ProcessTimer.Stop()

    End Sub

    ''' <summary>
    ''' disable all our controls because we make a long term process
    ''' </summary>
    Sub SwitchWaitOn()

        Me.TabControl_CNCWrkshp.Enabled = False

        Me.TabControl_CNCWrkshp.Cursor = Cursors.WaitCursor

    End Sub

    ''' <summary>
    ''' (re)enable our control after a long term process
    ''' </summary>
    Sub SwitchWaitOff()

        'this indicates the the serial transmission is still runnig
        If Not BT_StopTransmit.Visible Then

            Invoker_ControlFunction(Me.TabControl_CNCWrkshp, "Cursor", Cursors.Default)

            Invoker_ControlFunction(Me.TabControl_CNCWrkshp, "Enabled", True)

        End If

    End Sub

    ''' <summary>
    ''' to invoke the window controls
    ''' </summary>
    Sub Invoker_ControlFunction(ByVal control As Control, ByVal FunctionName As String, ByVal value As Object)

        If control.InvokeRequired Then

            control.Invoke(Sub() Invoker_ControlFunction(control, FunctionName, value))

        Else

            If value Is Nothing Then

                CallByName(control, FunctionName, CallType.Method)

            Else
                CallByName(control, FunctionName, CallType.Set, value)

            End If

        End If

    End Sub

#Region "Machine Tab Events"
    'Sub Handle_CB_Source_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

    '    Select Case CB_Source.SelectedItem.ToString

    '        Case "File"

    '            'BT_Set0 and BT_MoveJob are on the same location so we have to toggle his visibility
    '            Me.BT_MoveJob.Visible = True

    '            Me.BT_Set0.Visible = False

    '            MakeItFromFile()

    '            If WorkShop.CurrentDevice.WithReferencePoint Then

    '                BT_MoveJob.Visible = True

    '                BT_MoveJob.Enabled = True

    '                BT_Set0.Visible = False

    '                'CB_PathOpt.Visible = False

    '            End If

    '        Case "Current Drawing"

    '            'BT_Set0 and BT_MoveJob are on the same location so we have to toggle his visibility
    '            Me.BT_Set0.Visible = True

    '            Me.BT_MoveJob.Visible = False

    '            MakeItFromDrawing()

    '            If WorkShop.CurrentDevice.WithReferencePoint Then

    '                'CB_PathOpt.Visible = True

    '                BT_MoveJob.Visible = False

    '                BT_Set0.Visible = True

    '            End If

    '    End Select

    'End Sub

    Sub Handle_CB_DeviceChoose_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If EventsAllowed Then

            SwitchWaitOn()
            'shutdown the old one
            If WorkShop.CurrentDevice IsNot Nothing Then

                WorkShop.CurrentDevice.PurgeOldObjectsFromTools()

                RhinoWorker.Conduit.PurgeJob(withZeropoint:=True)

            End If

            WorkShop.SetCurrentDeviceByName(CB_DeviceChoose.SelectedItem.ToString)

            RhinoWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)

            'preview off
            CB_Preview.Checked = False

            SwitchWaitOff()

            Me.Refresh()

            RhinoDoc.ActiveDoc.Views.Redraw()

            InitToolTips()

            RefreshControls()

        End If

    End Sub

    Sub Handler_UD_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        EventsAllowed = False

        If Not CB_Material.Items.Contains("User Settings") Then

            CB_Material.Items.Insert(0, "User Settings")

        End If

        CB_Material.SelectedIndex = 0

        EventsAllowed = True

        Dim myUD As NumericUpDown = CType(sender, NumericUpDown)

        For Each tool As CNC_Tool In WorkShop.CurrentDevice.Tools

            If tool.ID = myUD.Parent.Text Then

                tool.setProperty(myUD.Tag.ToString, CStr(myUD.Value), wasDisplayed:=True)

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
                        'set to default becaus the overide just some properties but it can chnage more proerptioes before
                        tool.setDefault()

                        tool.setPropertyBySetting(ts)

                    End If

                Next

            Next

            WorkShop.CurrentDevice.SetBBoxTool(myNewMat.BBoxTool)

            BuildToolControls()

        End If

    End Sub

    Sub Handle_CB_ShowHideDevice(ByVal sender As Object, ByVal e As EventArgs)

        If CB_ShowCutter.Checked Then

            'looking for referencpoint, this only usefull if we are a controler
            If WorkShop.IsControlComputer Then
                If WorkShop.CurrentDevice.WithReferencePoint Then

                    DialogStopTraceForm = New DialogStopTrace("Close")
                    'this will open the serial port
                    WorkShop.SendDirect("OR;")

                    Dim myRes As DialogResult = DialogStopTraceForm.ShowDialog(Me)
                    'close serial port
                    WorkShop.Disconnect()

                    Me.BringToFront()

                End If

            End If

            RhinoWorker.Conduit.EnableDevice(WorkShop.CurrentDevice.WithReferencePoint)

            CB_ShowCutter.Text = "Hide Cutter"

        Else

            If CB_Preview.Checked Then

                CB_Preview.Checked = False

            End If

            RhinoWorker.Conduit.DisableDevice()

            CB_ShowCutter.Text = "Show Cutter"

            Invoker_ControlFunction(Me.Lbl_Info, "Text", "")

        End If

    End Sub

    Sub Handle_CB_Preview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CB_Preview.Checked Then

            DeviceWasOn = CB_ShowCutter.Checked

            PB_FileUpload.Value = PB_FileUpload.Minimum

            PB_JobProcess.Value = PB_JobProcess.Minimum

            'WorkShop.CurrentDevice.WithBBox = CB_BBox.Checked

            Dim myTime As String = RhinoWorker.PreviewOn(WorkShop.CurrentDevice)

            Invoker_ControlFunction(Me.Lbl_Info, "Text", myTime)

            If WorkShop.CurrentDevice.WithReferencePoint Then

                BT_MoveJob.Enabled = True

            End If

            CB_ShowCutter.Checked = True

            CB_Preview.Text = "Preview Off"

        Else

            RhinoWorker.PreviewOff()

            If DeviceWasOn Then

                CB_ShowCutter.Checked = True

                RhinoWorker.Conduit.EnableDevice(WorkShop.CurrentDevice.WithReferencePoint)

            Else

                CB_ShowCutter.Checked = False

            End If

            If WorkShop.CurrentDevice.WithReferencePoint Then
                BT_MoveJob.Enabled = False
            End If

            CB_Preview.Text = "Preview Job"

        End If

    End Sub

    Sub Handle_BT_MoveJob_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Me.Enabled = False

        If RhinoWorker.Conduit.DeviceFixObjects.Count = 0 Then

            RhinoWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)

        End If

        RhinoWorker.Conduit.EnableJob(WorkShop.CurrentDevice.WithReferencePoint)

        Dim FromPoint As Coordinate = Nothing

        RhinoWorker.NewJobPosition(WorkShop.CurrentDevice, FromPoint)

        If CB_ShowCutter.Checked Then

            RhinoWorker.Conduit.EnableDevice(WorkShop.CurrentDevice.WithReferencePoint)

        Else

            RhinoWorker.Conduit.DisableDevice()

        End If

        Me.Enabled = True

    End Sub
    ''' <summary>
    ''' Move Cutter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub Handle_BT_SetZero_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Me.Enabled = False

        Dim PreviewState As Boolean

        PreviewState = CB_Preview.Checked

        'trigering preview off if its was on
        CB_Preview.Checked = False

        If RhinoWorker.Conduit.DeviceFixObjects.Count = 0 Then

            RhinoWorker.Conduit.LoadNewDevice(WorkShop.CurrentDevice)

        End If

        RhinoWorker.Conduit.EnableJob(WorkShop.CurrentDevice.WithReferencePoint)

        Dim FromPoint As Coordinate = Nothing

        'with right button we prechoose the device zeropoint
        If e.Button = Windows.Forms.MouseButtons.Right Then

            FromPoint = WorkShop.CurrentDevice.ZeroPoint

        End If

        RhinoWorker.NewZero(WorkShop.CurrentDevice, FromPoint)

        CB_Preview.Checked = PreviewState

        If CB_ShowCutter.Checked Then

            RhinoWorker.Conduit.EnableDevice(WorkShop.CurrentDevice.WithReferencePoint)

        Else

            RhinoWorker.Conduit.DisableDevice()

        End If

        Me.Enabled = True

    End Sub

    'Sub Handle_CB_PathOpt_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    CB_Preview.Checked = False

    'End Sub

    Sub Handle_BT_StopTransmit_Click(ByVal sender As Object, ByVal e As EventArgs)

        'this means it was not clicked
        If sender IsNot Nothing Then

            Invoker_ControlFunction(Me.Lbl_Info, "Text", "Job transmitting was stopped.")

        Else

            Invoker_ControlFunction(PB_JobProcess, "Value", 0)

            Invoker_ControlFunction(PB_JobProcess, "Maximum", 1)

            Invoker_ControlFunction(Me.Lbl_Info, "Text", "Job was transmitted.")

        End If

        If Not WorkShop.IsTracing Then

            WorkShop.Disconnect()

        End If

        'first make it invisible otheerwise the swichwaitoff would not work proper
        Invoker_ControlFunction(BT_StopTransmit, "Visible", False)

        SwitchWaitOff()

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

        Select Case WorkShop.CurrentDevice.Language
            Case "GCODEM3"
                myDialog.Filter = "cnc files (*.nc)|*.nc|All files (*.*)|*.*"
            Case Else
                myDialog.Filter = "plt files (*.plt)|*.plt|All files (*.*)|*.*"
        End Select

        myDialog.FilterIndex = 1

        myDialog.Title = "Save Plotfile"

        myDialog.RestoreDirectory = True

        If myDialog.ShowDialog() = DialogResult.OK Then

            LogFile.Write("Start File Writing")

            myFileStream = myDialog.OpenFile

            If (myFileStream IsNot Nothing) Then

                RhinoWorker.CreateJobString(WorkShop.CurrentDevice, Me.CB_Preview.Checked, withTrace:=False)

                Dim userInput As MemoryStream =
                New MemoryStream(System.Text.Encoding.ASCII.GetBytes(WorkShop.CurrentDevice.JobBuffer.ToString())) With {
                    .Position = 0
                }

                userInput.WriteTo(myFileStream)

                LogFile.Write(WorkShop.CurrentDevice.JobBuffer.ToString)

                myFileStream.Close()

                WorkShop.CurrentDevice.JobBuffer.Clear()

                Invoker_ControlFunction(Me.Lbl_Info, "Text", "Wrote file: " & Path.GetFileName(myDialog.FileName))

                LogFile.Write("End File Writing")

            End If

        End If

        SwitchWaitOff()

    End Sub

    Sub Handle_CB_BBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'switch off preview because is superseeded
        CB_Preview.Checked = False

        If WorkShop.CurrentDevice Is Nothing Then

            Exit Sub

        End If

        'CB_BBoxToolChooser.Enabled = CB_BBox.Checked

        'WorkShop.CurrentDevice.WithBBox = CB_BBox.Checked

    End Sub

    Sub Handle_BT_StartDirect_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If WorkShop.CurrentDevice.DefaultMaterialWarning Then

            If CB_Material.SelectedItem.ToString = "Default Settings" Then

                MsgBox("You can't cut with the default material." & vbCrLf & "Please choose a proper material.", MsgBoxStyle.Exclamation, "Material Settings")

                Exit Sub

            End If

        End If

        Dim withTrace As Boolean = True

        If e.Button = Windows.Forms.MouseButtons.Right Then

            withTrace = False

        End If

        SwitchWaitOn()

        JobLog.Write(WorkShop.CurrentDevice.ID & vbTab & RhinoWorker.LogInfo)

        'WorkShop.CurrentDevice.WithBBox = CB_BBox.Checked

        RhinoWorker.CreateJobString(WorkShop.CurrentDevice, Me.CB_Preview.Checked, withTrace)

        If WorkShop.CurrentDevice.TotalGeometryCount > 0 Then

            If WorkShop.SendJobToSerial() Then

                BT_StopTransmit.Width = PB_JobProcess.Width + 2

                BT_StopTransmit.Visible = True

                Invoker_ControlFunction(Me.Lbl_Info, "Text", "Transmitting Job.")

                If withTrace Then

                    DialogStopTraceForm = New DialogStopTrace

                    Dim myRes As DialogResult = DialogStopTraceForm.ShowDialog(Me)

                    Me.BringToFront()

                    Select Case myRes

                        Case DialogResult.OK
                            'Closed by user

                            Invoker_ControlFunction(Me.Lbl_Info, "Text", "Tracing was stopped by user.")

                            StopTracing()

                        Case DialogResult.Yes
                            'closed by Cutter JobEnd

                            Dim myText As String = RhinoWorker.GetFinishedTime(WorkShop.CurrentDevice)

                            Invoker_ControlFunction(Me.Lbl_Info, "Text", myText)

                            StopTracing()

                    End Select

                Else

                    StopTracing()

                End If

            End If

        End If

        'we stopped the trace not the transmitting
        If Not BT_StopTransmit.Visible Then

            Invoker_ControlFunction(PB_JobProcess, "Value", 0)

            Invoker_ControlFunction(PB_JobProcess, "Maximum", 1)

            WorkShop.Disconnect()

        End If

        WorkShop.IsTracing = False

        SwitchWaitOff()

        If WorkShop.CurrentDevice.SwitchDefaultMaterialAtEnd Then

            CB_Material.SelectedItem = "Default Settings"

        End If

    End Sub

    'Sub Handle_BBoxToolChooser_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

    '    WorkShop.CurrentDevice.BBoxToolID = CB_BBoxToolChooser.SelectedItem.ToString

    'End Sub
#End Region

#Region "LayerTab Events"

    Private Sub Handle_DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) ' Handles DataGridView1.DataError



        LogFile.Write(e.Exception.ToString & ";" & e.ColumnIndex.ToString & ";" & e.RowIndex.ToString)


        '   MessageBox.Show("Error happened " _
        '       & e.Context.ToString())

        '   If (e.Context = DataGridViewDataErrorContexts.Commit) _
        '       Then
        '       MessageBox.Show("Commit error")
        '   End If
        '   If (e.Context = DataGridViewDataErrorContexts _
        '       .CurrentCellChange) Then
        '       MessageBox.Show("Cell change")
        '   End If
        '   If (e.Context = DataGridViewDataErrorContexts.Parsing) _
        '       Then
        '       MessageBox.Show("parsing error")
        '   End If
        '   If (e.Context = _
        '       DataGridViewDataErrorContexts.LeaveControl) Then
        '       MessageBox.Show("leave control error")
        '   End If

        '   If (e.Context = _
        'DataGridViewDataErrorContexts.Formatting) Then
        '       MessageBox.Show("lFormattingr")
        '   End If



        'If (TypeOf (e.Exception) Is ConstraintException) Then
        '    Dim view As DataGridView = CType(sender, DataGridView)
        '    view.Rows(e.RowIndex).ErrorText = "an error"
        '    view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
        '        .ErrorText = "an error"

        '    e.ThrowException = False
        'End If
    End Sub



    Public Sub Handle_LayerTableEvent(ByVal sender As Object, ByVal e As DocObjects.Tables.LayerTableEventArgs)

        'because the sortorder is not right at this time, after the whole eventhandling she is right, so we have to wait
        MyEventDelayTimer.Interval = 10

        MyEventDelayTimer.Start()

    End Sub

    Dim WithEvents MyEventDelayTimer As New Timer

    Private Sub Delayed_Handle_LayerTableEvent() Handles MyEventDelayTimer.Tick

        'switch off preview because is superseeded
        CB_Preview.Checked = False

        MyEventDelayTimer.Stop()

        RhinoWorker.RefreshLayerList(DGV_LayerGrid, MyBase.CB_ShowVisibleLayers.Checked)

    End Sub


    Sub Handle_CB_ShowVisibleLayers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        RhinoWorker.RefreshLayerList(DGV_LayerGrid, MyBase.CB_ShowVisibleLayers.Checked)

    End Sub


    Private Sub Handle_CB_CutByLayerOrder_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

        WorkShop.CurrentDevice.CutByLayerOrder = CB_CutByLayerOrder.Checked

        'switch off preview because is superseeded
        CB_Preview.Checked = False

    End Sub


#End Region

#Region "MachinePark Events"

    Sub Handle_WorkShop_DataBlockSended(ByVal no As Integer, ByVal total As Integer) Handles WorkShop.DataBlockSended

        Invoker_ControlFunction(PB_FileUpload, "Maximum", total)

        Invoker_ControlFunction(PB_FileUpload, "Value", no)

        If no = total Then

            Handle_BT_StopTransmit_Click(Nothing, Nothing)

        End If

    End Sub

    Sub Handle_Workshop_JBReceived(ByVal Jobnumber As Integer) Handles WorkShop.JBReceived

        If LastJobNo + 1 = Jobnumber Then

            WeAreInFlow = True

            If WorkShop.IsTracing Then

                If Jobnumber > 1 Then

                    RhinoWorker.Conduit.ObjectFinished()

                End If

                RhinoWorker.CurrentObjectLength = RhinoWorker.Conduit.SwitchObjectsInProgressBegin()

                WorkShop.CurrentDevice.CurrentObject = Jobnumber

                Invoker_ControlFunction(PB_JobProcess, "Maximum", WorkShop.CurrentDevice.TotalGeometryCount)

                Invoker_ControlFunction(PB_JobProcess, "Value", Jobnumber)

                Dim myText As String = RhinoWorker.GetProcessingTime(WorkShop.CurrentDevice)

                Invoker_ControlFunction(Me.Lbl_Info, "Text", myText)

            End If

            LastJobNo = Jobnumber

        End If

        If Jobnumber = 0 AndAlso WeAreInFlow Then

            CNC_Workshop.ProcessTimer.Stop()

            If DialogStopTraceForm.Visible Then

                Invoker_ControlFunction(DialogStopTraceForm, "CloseByCode", Nothing)

            End If

        End If

    End Sub

    Private Sub Handle_Workshop_NewRefrencePointDetected() Handles WorkShop.NewRefrencePointDetected

        LogFile.Write("NewRefrencePointDetected: " & WorkShop.CurrentDevice.ReferencePoint.ToString)

        RhinoWorker.Conduit.SetNewReferencePoint(WorkShop.CurrentDevice)

        DialogStopTraceForm.CloseByCode()

    End Sub

#End Region

    Private Sub Handle_DGV_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)

        If DGV_LayerGrid.CurrentCell.ColumnIndex = 1 Then

            Dim combo As ComboBox = CType(e.Control, ComboBox)

            If (combo IsNot Nothing) Then

                ' Remove an existing event-handler, if present, to avoid adding multiple handlers when the editing control is reused.

                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)

                ' Add the event handler.

                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)

            End If

        End If

    End Sub

    Private Sub ComboBox_SelectionchangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim myLayerName As String = String.Empty

        If DGV_LayerGrid.SelectedCells.Count <> 1 Then

            Exit Sub

        End If

        myLayerName = DGV_LayerGrid.Item(0, DGV_LayerGrid.SelectedCells(0).RowIndex).Value.ToString

        Dim combo As ComboBox = CType(sender, ComboBox)

        Dim myToolName As String = String.Empty

        myToolName = combo.SelectedItem.ToString

        If myLayerName & myToolName <> "-" Then

            RhinoWorker.ToolForLayer(myLayerName, myToolName)

        End If

        If CB_Preview.Checked Then

            RhinoWorker.PreviewOff(withRedraw:=False)

            Dim myTime As String = RhinoWorker.PreviewOn(WorkShop.CurrentDevice)

            Invoker_ControlFunction(Me.Lbl_Info, "Text", myTime)

        End If

    End Sub

    Private Sub Handler_TB_TextChanged(sender As Object, e As EventArgs)

        EventsAllowed = False

        If Not CB_Material.Items.Contains("User Settings") Then

            CB_Material.Items.Insert(0, "User Settings")

        End If

        CB_Material.SelectedIndex = 0

        EventsAllowed = True

        Dim myt As TextBox = CType(sender, TextBox)

        For Each tool As CNC_Tool In WorkShop.CurrentDevice.Tools


            If tool.ID = myt.Parent.Text.ToString Then

                tool.setPropertyText(myt.Tag.ToString, myt.Text)

                Exit For

            End If

        Next

    End Sub

    Private Sub InitializeComponent()
        CType(Me.SplitContainer_Layers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Layers.Panel1.SuspendLayout()
        Me.SplitContainer_Layers.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer_Layers
        '
        '
        'UIWrapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.Name = "UIWrapper"
        Me.SplitContainer_Layers.Panel1.ResumeLayout(False)
        Me.SplitContainer_Layers.Panel1.PerformLayout()
        CType(Me.SplitContainer_Layers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Layers.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
End Class
