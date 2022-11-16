<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlugInControls
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlugInControls))
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPageDirect = New System.Windows.Forms.TabPage()
        Me.CB_OnOffLine = New System.Windows.Forms.CheckBox()
        Me.PL_Device = New System.Windows.Forms.Panel()
        Me.CB_CutOut = New System.Windows.Forms.CheckBox()
        Me.BT_GetLocation = New System.Windows.Forms.Button()
        Me.GB_LastPos = New System.Windows.Forms.GroupBox()
        Me.BT_SetParking = New System.Windows.Forms.Button()
        Me.RB_EndPos_2Park = New System.Windows.Forms.RadioButton()
        Me.RB_EndPos_2Start = New System.Windows.Forms.RadioButton()
        Me.RB_EndPos_Stay = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PB_FileUpload = New System.Windows.Forms.ProgressBar()
        Me.PB_JobProcess = New System.Windows.Forms.ProgressBar()
        Me.CB_Preview = New System.Windows.Forms.CheckBox()
        Me.BasePointGB = New System.Windows.Forms.GroupBox()
        Me.BT_DevMM = New System.Windows.Forms.Button()
        Me.BT_DevTL = New System.Windows.Forms.Button()
        Me.BT_DevTR = New System.Windows.Forms.Button()
        Me.BT_DevTM = New System.Windows.Forms.Button()
        Me.BT_DevBM = New System.Windows.Forms.Button()
        Me.BT_DevBR = New System.Windows.Forms.Button()
        Me.BT_DevMR = New System.Windows.Forms.Button()
        Me.BT_DevBL = New System.Windows.Forms.Button()
        Me.BT_DevML = New System.Windows.Forms.Button()
        Me.BT_Set0 = New System.Windows.Forms.Button()
        Me.BT_Choose = New System.Windows.Forms.Button()
        Me.Lbl_Info = New System.Windows.Forms.Label()
        Me.GB_BBox = New System.Windows.Forms.GroupBox()
        Me.CB_BBox = New System.Windows.Forms.CheckBox()
        Me.NumUD_BBox = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GB_ToolPosition = New System.Windows.Forms.GroupBox()
        Me.BT_UL = New System.Windows.Forms.Button()
        Me.BT_DL = New System.Windows.Forms.Button()
        Me.NumUD_Y = New System.Windows.Forms.NumericUpDown()
        Me.BT_MR = New System.Windows.Forms.Button()
        Me.NumUD_X = New System.Windows.Forms.NumericUpDown()
        Me.BT_UR = New System.Windows.Forms.Button()
        Me.Lbl_x = New System.Windows.Forms.Label()
        Me.Lbl_y = New System.Windows.Forms.Label()
        Me.BT_DM = New System.Windows.Forms.Button()
        Me.BT_UM = New System.Windows.Forms.Button()
        Me.BT_SetToolPos = New System.Windows.Forms.Button()
        Me.BT_ML = New System.Windows.Forms.Button()
        Me.BT_DR = New System.Windows.Forms.Button()
        Me.BT_Process = New System.Windows.Forms.Button()
        Me.GB_PathOpimizing = New System.Windows.Forms.GroupBox()
        Me.RB_OpNene2 = New System.Windows.Forms.RadioButton()
        Me.RB_OpFarin2 = New System.Windows.Forms.RadioButton()
        Me.RB_OpSorx = New System.Windows.Forms.RadioButton()
        Me.RB_OpNene = New System.Windows.Forms.RadioButton()
        Me.RB_OpFarin = New System.Windows.Forms.RadioButton()
        Me.RB_OpNone = New System.Windows.Forms.RadioButton()
        Me.TabPageLayer = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BT_Compatibility = New System.Windows.Forms.Button()
        Me.CB_LayerVisibility = New System.Windows.Forms.CheckBox()
        Me.CNC_LayerGrid = New System.Windows.Forms.DataGridView()
        Me.Layer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tool = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabPageDevice = New System.Windows.Forms.TabPage()
        Me.BT_Reset = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CB_DeviceChoose = New System.Windows.Forms.ComboBox()
        Me.PanelDevice = New System.Windows.Forms.Panel()
        Me.TV_Material = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GBTools = New System.Windows.Forms.GroupBox()
        Me.TabTerminal = New System.Windows.Forms.TabPage()
        Me.GB_Terminal_Recieved = New System.Windows.Forms.GroupBox()
        Me.BT_CLSRec = New System.Windows.Forms.Button()
        Me.LB_TerminalRec = New System.Windows.Forms.ListBox()
        Me.GB_TerminalSend = New System.Windows.Forms.GroupBox()
        Me.BT_Write2Log = New System.Windows.Forms.Button()
        Me.BT_FrontEnd = New System.Windows.Forms.Button()
        Me.BT_TerminalSend = New System.Windows.Forms.Button()
        Me.TB_TerminalSend = New System.Windows.Forms.TextBox()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl.SuspendLayout()
        Me.TabPageDirect.SuspendLayout()
        Me.PL_Device.SuspendLayout()
        Me.GB_LastPos.SuspendLayout()
        Me.BasePointGB.SuspendLayout()
        Me.GB_BBox.SuspendLayout()
        CType(Me.NumUD_BBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_ToolPosition.SuspendLayout()
        CType(Me.NumUD_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUD_X, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_PathOpimizing.SuspendLayout()
        Me.TabPageLayer.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.CNC_LayerGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageDevice.SuspendLayout()
        Me.PanelDevice.SuspendLayout()
        Me.TabTerminal.SuspendLayout()
        Me.GB_Terminal_Recieved.SuspendLayout()
        Me.GB_TerminalSend.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPageDirect)
        Me.TabControl.Controls.Add(Me.TabPageLayer)
        Me.TabControl.Controls.Add(Me.TabPageDevice)
        Me.TabControl.Controls.Add(Me.TabTerminal)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(260, 900)
        Me.TabControl.TabIndex = 1
        '
        'TabPageDirect
        '
        Me.TabPageDirect.Controls.Add(Me.CB_OnOffLine)
        Me.TabPageDirect.Controls.Add(Me.PL_Device)
        Me.TabPageDirect.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDirect.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageDirect.Name = "TabPageDirect"
        Me.TabPageDirect.Size = New System.Drawing.Size(252, 874)
        Me.TabPageDirect.TabIndex = 5
        Me.TabPageDirect.Text = "Direct"
        Me.TabPageDirect.UseVisualStyleBackColor = True
        '
        'CB_OnOffLine
        '
        Me.CB_OnOffLine.Appearance = System.Windows.Forms.Appearance.Button
        Me.CB_OnOffLine.BackColor = System.Drawing.Color.Maroon
        Me.CB_OnOffLine.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CB_OnOffLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_OnOffLine.Location = New System.Drawing.Point(6, 4)
        Me.CB_OnOffLine.Name = "CB_OnOffLine"
        Me.CB_OnOffLine.Size = New System.Drawing.Size(240, 23)
        Me.CB_OnOffLine.TabIndex = 36
        Me.CB_OnOffLine.Text = "Activate"
        Me.CB_OnOffLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_OnOffLine.UseVisualStyleBackColor = False
        '
        'PL_Device
        '
        Me.PL_Device.Controls.Add(Me.CB_CutOut)
        Me.PL_Device.Controls.Add(Me.BT_GetLocation)
        Me.PL_Device.Controls.Add(Me.GB_LastPos)
        Me.PL_Device.Controls.Add(Me.Label6)
        Me.PL_Device.Controls.Add(Me.PB_FileUpload)
        Me.PL_Device.Controls.Add(Me.PB_JobProcess)
        Me.PL_Device.Controls.Add(Me.CB_Preview)
        Me.PL_Device.Controls.Add(Me.BasePointGB)
        Me.PL_Device.Controls.Add(Me.BT_Set0)
        Me.PL_Device.Controls.Add(Me.BT_Choose)
        Me.PL_Device.Controls.Add(Me.Lbl_Info)
        Me.PL_Device.Controls.Add(Me.GB_BBox)
        Me.PL_Device.Controls.Add(Me.GB_ToolPosition)
        Me.PL_Device.Controls.Add(Me.BT_Process)
        Me.PL_Device.Controls.Add(Me.GB_PathOpimizing)
        Me.PL_Device.Enabled = False
        Me.PL_Device.Location = New System.Drawing.Point(0, 29)
        Me.PL_Device.Name = "PL_Device"
        Me.PL_Device.Size = New System.Drawing.Size(250, 782)
        Me.PL_Device.TabIndex = 14
        '
        'CB_CutOut
        '
        Me.CB_CutOut.AutoSize = True
        Me.CB_CutOut.Location = New System.Drawing.Point(17, 417)
        Me.CB_CutOut.Name = "CB_CutOut"
        Me.CB_CutOut.Size = New System.Drawing.Size(68, 17)
        Me.CB_CutOut.TabIndex = 39
        Me.CB_CutOut.Text = "Cropping"
        Me.CB_CutOut.UseVisualStyleBackColor = True
        Me.CB_CutOut.Visible = False
        '
        'BT_GetLocation
        '
        Me.BT_GetLocation.Location = New System.Drawing.Point(129, 36)
        Me.BT_GetLocation.Name = "BT_GetLocation"
        Me.BT_GetLocation.Size = New System.Drawing.Size(117, 23)
        Me.BT_GetLocation.TabIndex = 47
        Me.BT_GetLocation.Text = "Get Location"
        Me.BT_GetLocation.UseVisualStyleBackColor = True
        '
        'GB_LastPos
        '
        Me.GB_LastPos.Controls.Add(Me.BT_SetParking)
        Me.GB_LastPos.Controls.Add(Me.RB_EndPos_2Park)
        Me.GB_LastPos.Controls.Add(Me.RB_EndPos_2Start)
        Me.GB_LastPos.Controls.Add(Me.RB_EndPos_Stay)
        Me.GB_LastPos.Location = New System.Drawing.Point(130, 588)
        Me.GB_LastPos.Name = "GB_LastPos"
        Me.GB_LastPos.Size = New System.Drawing.Size(117, 91)
        Me.GB_LastPos.TabIndex = 46
        Me.GB_LastPos.TabStop = False
        Me.GB_LastPos.Text = "Final Tool Position:"
        Me.GB_LastPos.Visible = False
        '
        'BT_SetParking
        '
        Me.BT_SetParking.Location = New System.Drawing.Point(74, 16)
        Me.BT_SetParking.Margin = New System.Windows.Forms.Padding(0)
        Me.BT_SetParking.Name = "BT_SetParking"
        Me.BT_SetParking.Size = New System.Drawing.Size(36, 23)
        Me.BT_SetParking.TabIndex = 37
        Me.BT_SetParking.Text = "Set"
        Me.BT_SetParking.UseVisualStyleBackColor = True
        Me.BT_SetParking.Visible = False
        '
        'RB_EndPos_2Park
        '
        Me.RB_EndPos_2Park.AutoSize = True
        Me.RB_EndPos_2Park.Checked = True
        Me.RB_EndPos_2Park.Location = New System.Drawing.Point(6, 19)
        Me.RB_EndPos_2Park.Name = "RB_EndPos_2Park"
        Me.RB_EndPos_2Park.Size = New System.Drawing.Size(61, 17)
        Me.RB_EndPos_2Park.TabIndex = 2
        Me.RB_EndPos_2Park.TabStop = True
        Me.RB_EndPos_2Park.Text = "Parking"
        Me.RB_EndPos_2Park.UseVisualStyleBackColor = True
        '
        'RB_EndPos_2Start
        '
        Me.RB_EndPos_2Start.AutoSize = True
        Me.RB_EndPos_2Start.Location = New System.Drawing.Point(8, 65)
        Me.RB_EndPos_2Start.Name = "RB_EndPos_2Start"
        Me.RB_EndPos_2Start.Size = New System.Drawing.Size(87, 17)
        Me.RB_EndPos_2Start.TabIndex = 1
        Me.RB_EndPos_2Start.Text = "Back to Start"
        Me.RB_EndPos_2Start.UseVisualStyleBackColor = True
        '
        'RB_EndPos_Stay
        '
        Me.RB_EndPos_Stay.AutoSize = True
        Me.RB_EndPos_Stay.Location = New System.Drawing.Point(8, 42)
        Me.RB_EndPos_Stay.Name = "RB_EndPos_Stay"
        Me.RB_EndPos_Stay.Size = New System.Drawing.Size(45, 17)
        Me.RB_EndPos_Stay.TabIndex = 0
        Me.RB_EndPos_Stay.Text = "Last"
        Me.RB_EndPos_Stay.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Job Process:"
        '
        'PB_FileUpload
        '
        Me.PB_FileUpload.Location = New System.Drawing.Point(6, 180)
        Me.PB_FileUpload.Maximum = 15
        Me.PB_FileUpload.Name = "PB_FileUpload"
        Me.PB_FileUpload.Size = New System.Drawing.Size(240, 10)
        Me.PB_FileUpload.Step = 1
        Me.PB_FileUpload.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_FileUpload.TabIndex = 37
        '
        'PB_JobProcess
        '
        Me.PB_JobProcess.Location = New System.Drawing.Point(6, 189)
        Me.PB_JobProcess.Maximum = 14
        Me.PB_JobProcess.Name = "PB_JobProcess"
        Me.PB_JobProcess.Size = New System.Drawing.Size(240, 24)
        Me.PB_JobProcess.Step = 1
        Me.PB_JobProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_JobProcess.TabIndex = 42
        '
        'CB_Preview
        '
        Me.CB_Preview.Appearance = System.Windows.Forms.Appearance.Button
        Me.CB_Preview.Location = New System.Drawing.Point(6, 4)
        Me.CB_Preview.Name = "CB_Preview"
        Me.CB_Preview.Size = New System.Drawing.Size(240, 23)
        Me.CB_Preview.TabIndex = 41
        Me.CB_Preview.Text = "Preview On"
        Me.CB_Preview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_Preview.UseVisualStyleBackColor = False
        '
        'BasePointGB
        '
        Me.BasePointGB.Controls.Add(Me.BT_DevMM)
        Me.BasePointGB.Controls.Add(Me.BT_DevTL)
        Me.BasePointGB.Controls.Add(Me.BT_DevTR)
        Me.BasePointGB.Controls.Add(Me.BT_DevTM)
        Me.BasePointGB.Controls.Add(Me.BT_DevBM)
        Me.BasePointGB.Controls.Add(Me.BT_DevBR)
        Me.BasePointGB.Controls.Add(Me.BT_DevMR)
        Me.BasePointGB.Controls.Add(Me.BT_DevBL)
        Me.BasePointGB.Controls.Add(Me.BT_DevML)
        Me.BasePointGB.Enabled = False
        Me.BasePointGB.Location = New System.Drawing.Point(6, 489)
        Me.BasePointGB.Name = "BasePointGB"
        Me.BasePointGB.Size = New System.Drawing.Size(117, 123)
        Me.BasePointGB.TabIndex = 24
        Me.BasePointGB.TabStop = False
        Me.BasePointGB.Text = "Basepoint"
        Me.BasePointGB.Visible = False
        '
        'BT_DevMM
        '
        Me.BT_DevMM.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevMM.Image = CType(resources.GetObject("BT_DevMM.Image"), System.Drawing.Image)
        Me.BT_DevMM.Location = New System.Drawing.Point(42, 52)
        Me.BT_DevMM.Name = "BT_DevMM"
        Me.BT_DevMM.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevMM.TabIndex = 8
        Me.BT_DevMM.UseVisualStyleBackColor = True
        '
        'BT_DevTL
        '
        Me.BT_DevTL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevTL.Image = CType(resources.GetObject("BT_DevTL.Image"), System.Drawing.Image)
        Me.BT_DevTL.Location = New System.Drawing.Point(9, 19)
        Me.BT_DevTL.Name = "BT_DevTL"
        Me.BT_DevTL.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevTL.TabIndex = 6
        Me.BT_DevTL.UseVisualStyleBackColor = True
        '
        'BT_DevTR
        '
        Me.BT_DevTR.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevTR.Image = CType(resources.GetObject("BT_DevTR.Image"), System.Drawing.Image)
        Me.BT_DevTR.Location = New System.Drawing.Point(75, 19)
        Me.BT_DevTR.Name = "BT_DevTR"
        Me.BT_DevTR.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevTR.TabIndex = 7
        Me.BT_DevTR.UseVisualStyleBackColor = True
        '
        'BT_DevTM
        '
        Me.BT_DevTM.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevTM.Image = CType(resources.GetObject("BT_DevTM.Image"), System.Drawing.Image)
        Me.BT_DevTM.Location = New System.Drawing.Point(42, 19)
        Me.BT_DevTM.Name = "BT_DevTM"
        Me.BT_DevTM.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevTM.TabIndex = 0
        Me.BT_DevTM.UseVisualStyleBackColor = True
        '
        'BT_DevBM
        '
        Me.BT_DevBM.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevBM.Image = CType(resources.GetObject("BT_DevBM.Image"), System.Drawing.Image)
        Me.BT_DevBM.Location = New System.Drawing.Point(42, 84)
        Me.BT_DevBM.Name = "BT_DevBM"
        Me.BT_DevBM.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevBM.TabIndex = 1
        Me.BT_DevBM.UseVisualStyleBackColor = True
        '
        'BT_DevBR
        '
        Me.BT_DevBR.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevBR.Image = CType(resources.GetObject("BT_DevBR.Image"), System.Drawing.Image)
        Me.BT_DevBR.Location = New System.Drawing.Point(75, 84)
        Me.BT_DevBR.Name = "BT_DevBR"
        Me.BT_DevBR.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevBR.TabIndex = 5
        Me.BT_DevBR.UseVisualStyleBackColor = True
        '
        'BT_DevMR
        '
        Me.BT_DevMR.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevMR.Image = CType(resources.GetObject("BT_DevMR.Image"), System.Drawing.Image)
        Me.BT_DevMR.Location = New System.Drawing.Point(75, 52)
        Me.BT_DevMR.Name = "BT_DevMR"
        Me.BT_DevMR.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevMR.TabIndex = 2
        Me.BT_DevMR.UseVisualStyleBackColor = True
        '
        'BT_DevBL
        '
        Me.BT_DevBL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevBL.Image = CType(resources.GetObject("BT_DevBL.Image"), System.Drawing.Image)
        Me.BT_DevBL.Location = New System.Drawing.Point(9, 84)
        Me.BT_DevBL.Name = "BT_DevBL"
        Me.BT_DevBL.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevBL.TabIndex = 4
        Me.BT_DevBL.UseVisualStyleBackColor = True
        '
        'BT_DevML
        '
        Me.BT_DevML.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevML.Image = CType(resources.GetObject("BT_DevML.Image"), System.Drawing.Image)
        Me.BT_DevML.Location = New System.Drawing.Point(9, 52)
        Me.BT_DevML.Name = "BT_DevML"
        Me.BT_DevML.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevML.TabIndex = 3
        Me.BT_DevML.UseVisualStyleBackColor = True
        '
        'BT_Set0
        '
        Me.BT_Set0.Location = New System.Drawing.Point(129, 69)
        Me.BT_Set0.Name = "BT_Set0"
        Me.BT_Set0.Size = New System.Drawing.Size(117, 23)
        Me.BT_Set0.TabIndex = 22
        Me.BT_Set0.Text = "Set Origin"
        Me.BT_Set0.UseVisualStyleBackColor = True
        '
        'BT_Choose
        '
        Me.BT_Choose.Location = New System.Drawing.Point(10, 460)
        Me.BT_Choose.Name = "BT_Choose"
        Me.BT_Choose.Size = New System.Drawing.Size(101, 23)
        Me.BT_Choose.TabIndex = 0
        Me.BT_Choose.Text = "Choose Objects"
        Me.BT_Choose.UseVisualStyleBackColor = True
        Me.BT_Choose.Visible = False
        '
        'Lbl_Info
        '
        Me.Lbl_Info.AccessibleName = resources.GetString("Lbl_Info.AccessibleName")
        Me.Lbl_Info.AutoSize = True
        Me.Lbl_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Info.Location = New System.Drawing.Point(7, 216)
        Me.Lbl_Info.Name = "Lbl_Info"
        Me.Lbl_Info.Size = New System.Drawing.Size(0, 16)
        Me.Lbl_Info.TabIndex = 37
        '
        'GB_BBox
        '
        Me.GB_BBox.Controls.Add(Me.CB_BBox)
        Me.GB_BBox.Controls.Add(Me.NumUD_BBox)
        Me.GB_BBox.Controls.Add(Me.Label2)
        Me.GB_BBox.Location = New System.Drawing.Point(6, 29)
        Me.GB_BBox.Name = "GB_BBox"
        Me.GB_BBox.Size = New System.Drawing.Size(117, 69)
        Me.GB_BBox.TabIndex = 39
        Me.GB_BBox.TabStop = False
        Me.GB_BBox.Text = "Bounding Box"
        '
        'CB_BBox
        '
        Me.CB_BBox.AutoSize = True
        Me.CB_BBox.Location = New System.Drawing.Point(8, 17)
        Me.CB_BBox.Name = "CB_BBox"
        Me.CB_BBox.Size = New System.Drawing.Size(111, 17)
        Me.CB_BBox.TabIndex = 38
        Me.CB_BBox.Text = "Cut Bounding Box"
        Me.CB_BBox.UseVisualStyleBackColor = True
        '
        'NumUD_BBox
        '
        Me.NumUD_BBox.Location = New System.Drawing.Point(52, 38)
        Me.NumUD_BBox.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NumUD_BBox.Name = "NumUD_BBox"
        Me.NumUD_BBox.Size = New System.Drawing.Size(58, 20)
        Me.NumUD_BBox.TabIndex = 19
        Me.NumUD_BBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumUD_BBox.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Offset"
        '
        'GB_ToolPosition
        '
        Me.GB_ToolPosition.Controls.Add(Me.BT_UL)
        Me.GB_ToolPosition.Controls.Add(Me.BT_DL)
        Me.GB_ToolPosition.Controls.Add(Me.NumUD_Y)
        Me.GB_ToolPosition.Controls.Add(Me.BT_MR)
        Me.GB_ToolPosition.Controls.Add(Me.NumUD_X)
        Me.GB_ToolPosition.Controls.Add(Me.BT_UR)
        Me.GB_ToolPosition.Controls.Add(Me.Lbl_x)
        Me.GB_ToolPosition.Controls.Add(Me.Lbl_y)
        Me.GB_ToolPosition.Controls.Add(Me.BT_DM)
        Me.GB_ToolPosition.Controls.Add(Me.BT_UM)
        Me.GB_ToolPosition.Controls.Add(Me.BT_SetToolPos)
        Me.GB_ToolPosition.Controls.Add(Me.BT_ML)
        Me.GB_ToolPosition.Controls.Add(Me.BT_DR)
        Me.GB_ToolPosition.Location = New System.Drawing.Point(135, 370)
        Me.GB_ToolPosition.Name = "GB_ToolPosition"
        Me.GB_ToolPosition.Size = New System.Drawing.Size(117, 201)
        Me.GB_ToolPosition.TabIndex = 4
        Me.GB_ToolPosition.TabStop = False
        Me.GB_ToolPosition.Text = "Tool Position"
        Me.GB_ToolPosition.Visible = False
        '
        'BT_UL
        '
        Me.BT_UL.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_UL.Location = New System.Drawing.Point(9, 71)
        Me.BT_UL.Name = "BT_UL"
        Me.BT_UL.Size = New System.Drawing.Size(30, 30)
        Me.BT_UL.TabIndex = 9
        Me.BT_UL.Text = "ë"
        Me.BT_UL.UseVisualStyleBackColor = True
        '
        'BT_DL
        '
        Me.BT_DL.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_DL.Location = New System.Drawing.Point(9, 136)
        Me.BT_DL.Name = "BT_DL"
        Me.BT_DL.Size = New System.Drawing.Size(30, 30)
        Me.BT_DL.TabIndex = 10
        Me.BT_DL.Text = "í"
        Me.BT_DL.UseVisualStyleBackColor = True
        '
        'NumUD_Y
        '
        Me.NumUD_Y.Location = New System.Drawing.Point(32, 45)
        Me.NumUD_Y.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.NumUD_Y.Name = "NumUD_Y"
        Me.NumUD_Y.Size = New System.Drawing.Size(73, 20)
        Me.NumUD_Y.TabIndex = 17
        Me.NumUD_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BT_MR
        '
        Me.BT_MR.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_MR.Location = New System.Drawing.Point(75, 104)
        Me.BT_MR.Name = "BT_MR"
        Me.BT_MR.Size = New System.Drawing.Size(30, 30)
        Me.BT_MR.TabIndex = 8
        Me.BT_MR.Text = "è"
        Me.BT_MR.UseVisualStyleBackColor = True
        '
        'NumUD_X
        '
        Me.NumUD_X.Location = New System.Drawing.Point(32, 19)
        Me.NumUD_X.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.NumUD_X.Name = "NumUD_X"
        Me.NumUD_X.Size = New System.Drawing.Size(73, 20)
        Me.NumUD_X.TabIndex = 18
        Me.NumUD_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BT_UR
        '
        Me.BT_UR.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_UR.Location = New System.Drawing.Point(75, 71)
        Me.BT_UR.Name = "BT_UR"
        Me.BT_UR.Size = New System.Drawing.Size(30, 30)
        Me.BT_UR.TabIndex = 11
        Me.BT_UR.Text = "ì"
        Me.BT_UR.UseVisualStyleBackColor = True
        '
        'Lbl_x
        '
        Me.Lbl_x.AutoSize = True
        Me.Lbl_x.Location = New System.Drawing.Point(15, 22)
        Me.Lbl_x.Name = "Lbl_x"
        Me.Lbl_x.Size = New System.Drawing.Size(14, 13)
        Me.Lbl_x.TabIndex = 2
        Me.Lbl_x.Text = "X"
        '
        'Lbl_y
        '
        Me.Lbl_y.AutoSize = True
        Me.Lbl_y.Location = New System.Drawing.Point(15, 48)
        Me.Lbl_y.Name = "Lbl_y"
        Me.Lbl_y.Size = New System.Drawing.Size(14, 13)
        Me.Lbl_y.TabIndex = 3
        Me.Lbl_y.Text = "Y"
        '
        'BT_DM
        '
        Me.BT_DM.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_DM.Location = New System.Drawing.Point(42, 136)
        Me.BT_DM.Name = "BT_DM"
        Me.BT_DM.Size = New System.Drawing.Size(30, 30)
        Me.BT_DM.TabIndex = 7
        Me.BT_DM.Text = "ê"
        Me.BT_DM.UseVisualStyleBackColor = True
        '
        'BT_UM
        '
        Me.BT_UM.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_UM.Location = New System.Drawing.Point(42, 71)
        Me.BT_UM.Name = "BT_UM"
        Me.BT_UM.Size = New System.Drawing.Size(30, 30)
        Me.BT_UM.TabIndex = 6
        Me.BT_UM.Text = "é"
        Me.BT_UM.UseVisualStyleBackColor = True
        '
        'BT_SetToolPos
        '
        Me.BT_SetToolPos.Font = New System.Drawing.Font("Wingdings", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_SetToolPos.Location = New System.Drawing.Point(42, 104)
        Me.BT_SetToolPos.Margin = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.BT_SetToolPos.Name = "BT_SetToolPos"
        Me.BT_SetToolPos.Size = New System.Drawing.Size(30, 30)
        Me.BT_SetToolPos.TabIndex = 17
        Me.BT_SetToolPos.Text = "°"
        Me.BT_SetToolPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_SetToolPos.UseVisualStyleBackColor = True
        '
        'BT_ML
        '
        Me.BT_ML.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_ML.Location = New System.Drawing.Point(9, 104)
        Me.BT_ML.Name = "BT_ML"
        Me.BT_ML.Size = New System.Drawing.Size(30, 30)
        Me.BT_ML.TabIndex = 5
        Me.BT_ML.Text = "ç"
        Me.BT_ML.UseVisualStyleBackColor = True
        '
        'BT_DR
        '
        Me.BT_DR.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_DR.Location = New System.Drawing.Point(75, 136)
        Me.BT_DR.Name = "BT_DR"
        Me.BT_DR.Size = New System.Drawing.Size(30, 30)
        Me.BT_DR.TabIndex = 12
        Me.BT_DR.Text = "î"
        Me.BT_DR.UseVisualStyleBackColor = True
        '
        'BT_Process
        '
        Me.BT_Process.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_Process.Location = New System.Drawing.Point(6, 102)
        Me.BT_Process.Name = "BT_Process"
        Me.BT_Process.Size = New System.Drawing.Size(240, 57)
        Me.BT_Process.TabIndex = 22
        Me.BT_Process.Text = "START"
        Me.BT_Process.UseVisualStyleBackColor = True
        '
        'GB_PathOpimizing
        '
        Me.GB_PathOpimizing.Controls.Add(Me.RB_OpNene2)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_OpFarin2)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_OpSorx)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_OpNene)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_OpFarin)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_OpNone)
        Me.GB_PathOpimizing.Location = New System.Drawing.Point(6, 618)
        Me.GB_PathOpimizing.Name = "GB_PathOpimizing"
        Me.GB_PathOpimizing.Size = New System.Drawing.Size(117, 88)
        Me.GB_PathOpimizing.TabIndex = 26
        Me.GB_PathOpimizing.TabStop = False
        Me.GB_PathOpimizing.Text = "Path Optimizing"
        Me.GB_PathOpimizing.Visible = False
        '
        'RB_OpNene2
        '
        Me.RB_OpNene2.Appearance = System.Windows.Forms.Appearance.Button
        Me.RB_OpNene2.Checked = True
        Me.RB_OpNene2.Location = New System.Drawing.Point(60, 38)
        Me.RB_OpNene2.Name = "RB_OpNene2"
        Me.RB_OpNene2.Size = New System.Drawing.Size(50, 23)
        Me.RB_OpNene2.TabIndex = 39
        Me.RB_OpNene2.TabStop = True
        Me.RB_OpNene2.Text = "&& 2opt"
        Me.RB_OpNene2.UseVisualStyleBackColor = True
        '
        'RB_OpFarin2
        '
        Me.RB_OpFarin2.Appearance = System.Windows.Forms.Appearance.Button
        Me.RB_OpFarin2.Location = New System.Drawing.Point(60, 61)
        Me.RB_OpFarin2.Name = "RB_OpFarin2"
        Me.RB_OpFarin2.Size = New System.Drawing.Size(50, 23)
        Me.RB_OpFarin2.TabIndex = 38
        Me.RB_OpFarin2.Text = "&& 2 opt"
        Me.RB_OpFarin2.UseVisualStyleBackColor = True
        '
        'RB_OpSorx
        '
        Me.RB_OpSorx.Appearance = System.Windows.Forms.Appearance.Button
        Me.RB_OpSorx.Location = New System.Drawing.Point(60, 15)
        Me.RB_OpSorx.Name = "RB_OpSorx"
        Me.RB_OpSorx.Size = New System.Drawing.Size(50, 23)
        Me.RB_OpSorx.TabIndex = 1
        Me.RB_OpSorx.Text = "SORX"
        Me.RB_OpSorx.UseVisualStyleBackColor = True
        '
        'RB_OpNene
        '
        Me.RB_OpNene.Appearance = System.Windows.Forms.Appearance.Button
        Me.RB_OpNene.Location = New System.Drawing.Point(8, 38)
        Me.RB_OpNene.Name = "RB_OpNene"
        Me.RB_OpNene.Size = New System.Drawing.Size(50, 23)
        Me.RB_OpNene.TabIndex = 2
        Me.RB_OpNene.Text = "NENE"
        Me.RB_OpNene.UseVisualStyleBackColor = True
        '
        'RB_OpFarin
        '
        Me.RB_OpFarin.Appearance = System.Windows.Forms.Appearance.Button
        Me.RB_OpFarin.Location = New System.Drawing.Point(8, 61)
        Me.RB_OpFarin.Name = "RB_OpFarin"
        Me.RB_OpFarin.Size = New System.Drawing.Size(50, 23)
        Me.RB_OpFarin.TabIndex = 3
        Me.RB_OpFarin.Text = "FARIN"
        Me.RB_OpFarin.UseVisualStyleBackColor = True
        '
        'RB_OpNone
        '
        Me.RB_OpNone.Appearance = System.Windows.Forms.Appearance.Button
        Me.RB_OpNone.Location = New System.Drawing.Point(8, 15)
        Me.RB_OpNone.Name = "RB_OpNone"
        Me.RB_OpNone.Size = New System.Drawing.Size(50, 23)
        Me.RB_OpNone.TabIndex = 4
        Me.RB_OpNone.Text = "none"
        Me.RB_OpNone.UseVisualStyleBackColor = True
        '
        'TabPageLayer
        '
        Me.TabPageLayer.Controls.Add(Me.SplitContainer1)
        Me.TabPageLayer.Location = New System.Drawing.Point(4, 22)
        Me.TabPageLayer.Name = "TabPageLayer"
        Me.TabPageLayer.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageLayer.Size = New System.Drawing.Size(252, 874)
        Me.TabPageLayer.TabIndex = 2
        Me.TabPageLayer.Text = "Layer Settings"
        Me.TabPageLayer.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.BT_Compatibility)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_LayerVisibility)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CNC_LayerGrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(246, 868)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 6
        '
        'BT_Compatibility
        '
        Me.BT_Compatibility.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Compatibility.Location = New System.Drawing.Point(153, 0)
        Me.BT_Compatibility.Name = "BT_Compatibility"
        Me.BT_Compatibility.Size = New System.Drawing.Size(90, 23)
        Me.BT_Compatibility.TabIndex = 6
        Me.BT_Compatibility.Text = "Legacy Names"
        Me.BT_Compatibility.UseVisualStyleBackColor = True
        Me.BT_Compatibility.Visible = False
        '
        'CB_LayerVisibility
        '
        Me.CB_LayerVisibility.AutoSize = True
        Me.CB_LayerVisibility.Location = New System.Drawing.Point(3, 3)
        Me.CB_LayerVisibility.Name = "CB_LayerVisibility"
        Me.CB_LayerVisibility.Size = New System.Drawing.Size(151, 17)
        Me.CB_LayerVisibility.TabIndex = 5
        Me.CB_LayerVisibility.Text = "don't list layers without tool"
        Me.CB_LayerVisibility.UseVisualStyleBackColor = True
        '
        'CNC_LayerGrid
        '
        Me.CNC_LayerGrid.AllowUserToAddRows = False
        Me.CNC_LayerGrid.AllowUserToDeleteRows = False
        Me.CNC_LayerGrid.AllowUserToResizeRows = False
        Me.CNC_LayerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.CNC_LayerGrid.BackgroundColor = System.Drawing.SystemColors.Window
        Me.CNC_LayerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.CNC_LayerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CNC_LayerGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Layer, Me.Tool})
        Me.CNC_LayerGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CNC_LayerGrid.GridColor = System.Drawing.SystemColors.Menu
        Me.CNC_LayerGrid.Location = New System.Drawing.Point(0, 0)
        Me.CNC_LayerGrid.Margin = New System.Windows.Forms.Padding(0)
        Me.CNC_LayerGrid.Name = "CNC_LayerGrid"
        Me.CNC_LayerGrid.RowHeadersVisible = False
        Me.CNC_LayerGrid.RowTemplate.Height = 20
        Me.CNC_LayerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CNC_LayerGrid.Size = New System.Drawing.Size(246, 842)
        Me.CNC_LayerGrid.TabIndex = 0
        '
        'Layer
        '
        Me.Layer.FillWeight = 200.0!
        Me.Layer.HeaderText = "Layer"
        Me.Layer.Name = "Layer"
        Me.Layer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Layer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Tool
        '
        Me.Tool.FillWeight = 150.0!
        Me.Tool.HeaderText = "Tool"
        Me.Tool.Items.AddRange(New Object() {"-", "CUT", "ENG", "SP1", "SP2", "SP4"})
        Me.Tool.Name = "Tool"
        Me.Tool.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'TabPageDevice
        '
        Me.TabPageDevice.Controls.Add(Me.BT_Reset)
        Me.TabPageDevice.Controls.Add(Me.Label4)
        Me.TabPageDevice.Controls.Add(Me.CB_DeviceChoose)
        Me.TabPageDevice.Controls.Add(Me.PanelDevice)
        Me.TabPageDevice.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDevice.Name = "TabPageDevice"
        Me.TabPageDevice.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDevice.Size = New System.Drawing.Size(252, 874)
        Me.TabPageDevice.TabIndex = 6
        Me.TabPageDevice.Text = "Devices"
        Me.TabPageDevice.UseVisualStyleBackColor = True
        '
        'BT_Reset
        '
        Me.BT_Reset.Location = New System.Drawing.Point(206, 8)
        Me.BT_Reset.Name = "BT_Reset"
        Me.BT_Reset.Size = New System.Drawing.Size(44, 23)
        Me.BT_Reset.TabIndex = 42
        Me.BT_Reset.Text = "Reset"
        Me.BT_Reset.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Device"
        '
        'CB_DeviceChoose
        '
        Me.CB_DeviceChoose.FormattingEnabled = True
        Me.CB_DeviceChoose.Items.AddRange(New Object() {"no device configurations"})
        Me.CB_DeviceChoose.Location = New System.Drawing.Point(47, 10)
        Me.CB_DeviceChoose.Name = "CB_DeviceChoose"
        Me.CB_DeviceChoose.Size = New System.Drawing.Size(153, 21)
        Me.CB_DeviceChoose.TabIndex = 40
        '
        'PanelDevice
        '
        Me.PanelDevice.Controls.Add(Me.TV_Material)
        Me.PanelDevice.Controls.Add(Me.Label1)
        Me.PanelDevice.Controls.Add(Me.GBTools)
        Me.PanelDevice.Location = New System.Drawing.Point(0, 37)
        Me.PanelDevice.Name = "PanelDevice"
        Me.PanelDevice.Size = New System.Drawing.Size(250, 875)
        Me.PanelDevice.TabIndex = 39
        '
        'TV_Material
        '
        Me.TV_Material.Location = New System.Drawing.Point(3, 19)
        Me.TV_Material.Name = "TV_Material"
        Me.TV_Material.Size = New System.Drawing.Size(244, 249)
        Me.TV_Material.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Material"
        '
        'GBTools
        '
        Me.GBTools.Location = New System.Drawing.Point(3, 274)
        Me.GBTools.Name = "GBTools"
        Me.GBTools.Size = New System.Drawing.Size(244, 432)
        Me.GBTools.TabIndex = 31
        Me.GBTools.TabStop = False
        Me.GBTools.Text = "Tools"
        '
        'TabTerminal
        '
        Me.TabTerminal.Controls.Add(Me.GB_Terminal_Recieved)
        Me.TabTerminal.Controls.Add(Me.GB_TerminalSend)
        Me.TabTerminal.Location = New System.Drawing.Point(4, 22)
        Me.TabTerminal.Name = "TabTerminal"
        Me.TabTerminal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTerminal.Size = New System.Drawing.Size(252, 874)
        Me.TabTerminal.TabIndex = 7
        Me.TabTerminal.Text = "Terminal"
        Me.TabTerminal.UseVisualStyleBackColor = True
        '
        'GB_Terminal_Recieved
        '
        Me.GB_Terminal_Recieved.Controls.Add(Me.BT_CLSRec)
        Me.GB_Terminal_Recieved.Controls.Add(Me.LB_TerminalRec)
        Me.GB_Terminal_Recieved.Location = New System.Drawing.Point(6, 257)
        Me.GB_Terminal_Recieved.Name = "GB_Terminal_Recieved"
        Me.GB_Terminal_Recieved.Size = New System.Drawing.Size(240, 362)
        Me.GB_Terminal_Recieved.TabIndex = 5
        Me.GB_Terminal_Recieved.TabStop = False
        Me.GB_Terminal_Recieved.Text = "Recieved Data"
        '
        'BT_CLSRec
        '
        Me.BT_CLSRec.Location = New System.Drawing.Point(159, 16)
        Me.BT_CLSRec.Name = "BT_CLSRec"
        Me.BT_CLSRec.Size = New System.Drawing.Size(75, 23)
        Me.BT_CLSRec.TabIndex = 1
        Me.BT_CLSRec.Text = "CLS"
        Me.BT_CLSRec.UseVisualStyleBackColor = True
        '
        'LB_TerminalRec
        '
        Me.LB_TerminalRec.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LB_TerminalRec.FormattingEnabled = True
        Me.LB_TerminalRec.Location = New System.Drawing.Point(3, 43)
        Me.LB_TerminalRec.Name = "LB_TerminalRec"
        Me.LB_TerminalRec.Size = New System.Drawing.Size(234, 316)
        Me.LB_TerminalRec.TabIndex = 0
        '
        'GB_TerminalSend
        '
        Me.GB_TerminalSend.Controls.Add(Me.BT_Write2Log)
        Me.GB_TerminalSend.Controls.Add(Me.BT_FrontEnd)
        Me.GB_TerminalSend.Controls.Add(Me.BT_TerminalSend)
        Me.GB_TerminalSend.Controls.Add(Me.TB_TerminalSend)
        Me.GB_TerminalSend.Location = New System.Drawing.Point(6, 6)
        Me.GB_TerminalSend.Name = "GB_TerminalSend"
        Me.GB_TerminalSend.Size = New System.Drawing.Size(240, 245)
        Me.GB_TerminalSend.TabIndex = 4
        Me.GB_TerminalSend.TabStop = False
        Me.GB_TerminalSend.Text = "Send Data"
        '
        'BT_Write2Log
        '
        Me.BT_Write2Log.Location = New System.Drawing.Point(87, 216)
        Me.BT_Write2Log.Name = "BT_Write2Log"
        Me.BT_Write2Log.Size = New System.Drawing.Size(66, 23)
        Me.BT_Write2Log.TabIndex = 6
        Me.BT_Write2Log.Text = "Write2Log"
        Me.BT_Write2Log.UseVisualStyleBackColor = True
        '
        'BT_FrontEnd
        '
        Me.BT_FrontEnd.Location = New System.Drawing.Point(6, 216)
        Me.BT_FrontEnd.Name = "BT_FrontEnd"
        Me.BT_FrontEnd.Size = New System.Drawing.Size(75, 23)
        Me.BT_FrontEnd.TabIndex = 5
        Me.BT_FrontEnd.Text = "FrontEnd"
        Me.BT_FrontEnd.UseVisualStyleBackColor = True
        '
        'BT_TerminalSend
        '
        Me.BT_TerminalSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_TerminalSend.Location = New System.Drawing.Point(159, 216)
        Me.BT_TerminalSend.Name = "BT_TerminalSend"
        Me.BT_TerminalSend.Size = New System.Drawing.Size(75, 23)
        Me.BT_TerminalSend.TabIndex = 0
        Me.BT_TerminalSend.Text = "Send"
        Me.BT_TerminalSend.UseVisualStyleBackColor = True
        '
        'TB_TerminalSend
        '
        Me.TB_TerminalSend.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_TerminalSend.Location = New System.Drawing.Point(6, 19)
        Me.TB_TerminalSend.Multiline = True
        Me.TB_TerminalSend.Name = "TB_TerminalSend"
        Me.TB_TerminalSend.Size = New System.Drawing.Size(228, 191)
        Me.TB_TerminalSend.TabIndex = 1
        '
        'PlugInControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "PlugInControls"
        Me.Size = New System.Drawing.Size(260, 900)
        Me.TabControl.ResumeLayout(False)
        Me.TabPageDirect.ResumeLayout(False)
        Me.PL_Device.ResumeLayout(False)
        Me.PL_Device.PerformLayout()
        Me.GB_LastPos.ResumeLayout(False)
        Me.GB_LastPos.PerformLayout()
        Me.BasePointGB.ResumeLayout(False)
        Me.GB_BBox.ResumeLayout(False)
        Me.GB_BBox.PerformLayout()
        CType(Me.NumUD_BBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_ToolPosition.ResumeLayout(False)
        Me.GB_ToolPosition.PerformLayout()
        CType(Me.NumUD_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUD_X, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_PathOpimizing.ResumeLayout(False)
        Me.TabPageLayer.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.CNC_LayerGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageDevice.ResumeLayout(False)
        Me.TabPageDevice.PerformLayout()
        Me.PanelDevice.ResumeLayout(False)
        Me.PanelDevice.PerformLayout()
        Me.TabTerminal.ResumeLayout(False)
        Me.GB_Terminal_Recieved.ResumeLayout(False)
        Me.GB_TerminalSend.ResumeLayout(False)
        Me.GB_TerminalSend.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents TabPageDirect As System.Windows.Forms.TabPage
    Protected WithEvents BT_Set0 As System.Windows.Forms.Button
    Protected WithEvents BT_SetToolPos As System.Windows.Forms.Button
    Protected WithEvents BT_Process As System.Windows.Forms.Button
    Protected WithEvents BT_UM As System.Windows.Forms.Button
    Protected WithEvents BT_ML As System.Windows.Forms.Button
    Protected WithEvents BT_DR As System.Windows.Forms.Button
    Protected WithEvents BT_DM As System.Windows.Forms.Button
    Protected WithEvents BT_UR As System.Windows.Forms.Button
    Protected WithEvents BT_MR As System.Windows.Forms.Button
    Protected WithEvents BT_DL As System.Windows.Forms.Button
    Protected WithEvents BT_UL As System.Windows.Forms.Button
    Protected WithEvents Lbl_x As System.Windows.Forms.Label
    Protected WithEvents Lbl_y As System.Windows.Forms.Label
    Protected WithEvents BT_DevMM As System.Windows.Forms.Button
    Protected WithEvents BT_DevTL As System.Windows.Forms.Button
    Protected WithEvents BT_DevTR As System.Windows.Forms.Button
    Protected WithEvents BT_DevTM As System.Windows.Forms.Button
    Protected WithEvents BT_DevBM As System.Windows.Forms.Button
    Protected WithEvents BT_DevBR As System.Windows.Forms.Button
    Protected WithEvents BT_DevMR As System.Windows.Forms.Button
    Protected WithEvents BT_DevBL As System.Windows.Forms.Button
    Protected WithEvents BT_DevML As System.Windows.Forms.Button
    Protected WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Protected WithEvents BT_Compatibility As System.Windows.Forms.Button
    Protected WithEvents ToolTips As System.Windows.Forms.ToolTip
    Protected WithEvents TabControl As System.Windows.Forms.TabControl
    Protected WithEvents PL_Device As System.Windows.Forms.Panel
    Protected WithEvents CNC_LayerGrid As System.Windows.Forms.DataGridView
    Protected WithEvents CB_LayerVisibility As System.Windows.Forms.CheckBox
    Protected WithEvents NumUD_Y As System.Windows.Forms.NumericUpDown
    Protected WithEvents NumUD_X As System.Windows.Forms.NumericUpDown
    Protected WithEvents GB_ToolPosition As System.Windows.Forms.GroupBox
    Protected WithEvents RB_OpSorx As System.Windows.Forms.RadioButton
    Protected WithEvents RB_OpNene As System.Windows.Forms.RadioButton
    Protected WithEvents RB_OpFarin As System.Windows.Forms.RadioButton
    Protected WithEvents RB_OpNone As System.Windows.Forms.RadioButton
    Protected WithEvents GB_PathOpimizing As System.Windows.Forms.GroupBox
    Protected WithEvents RB_OpFarin2 As System.Windows.Forms.RadioButton
    Protected WithEvents RB_OpNene2 As System.Windows.Forms.RadioButton
    Protected WithEvents BasePointGB As System.Windows.Forms.GroupBox
    Protected WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents GB_BBox As System.Windows.Forms.GroupBox
    Protected WithEvents CB_BBox As System.Windows.Forms.CheckBox
    Protected WithEvents BT_Choose As System.Windows.Forms.Button
    Protected WithEvents CB_Preview As System.Windows.Forms.CheckBox
    Protected WithEvents CB_CutOut As System.Windows.Forms.CheckBox
    Protected WithEvents RB_EndPos_2Park As System.Windows.Forms.RadioButton
    Protected WithEvents RB_EndPos_Stay As System.Windows.Forms.RadioButton
    Protected WithEvents RB_EndPos_2Start As System.Windows.Forms.RadioButton
    Protected WithEvents Lbl_Info As System.Windows.Forms.Label
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents PanelDevice As System.Windows.Forms.Panel
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TabPageLayer As System.Windows.Forms.TabPage
    Protected WithEvents TabPageDevice As System.Windows.Forms.TabPage
    Protected WithEvents CB_DeviceChoose As System.Windows.Forms.ComboBox
    Protected WithEvents BT_Reset As System.Windows.Forms.Button
    Protected WithEvents TV_Material As System.Windows.Forms.TreeView
    Protected WithEvents GBTools As System.Windows.Forms.GroupBox
    Protected WithEvents TabTerminal As System.Windows.Forms.TabPage
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents PB_FileUpload As System.Windows.Forms.ProgressBar
    Protected WithEvents PB_JobProcess As System.Windows.Forms.ProgressBar
    Protected WithEvents GB_TerminalSend As System.Windows.Forms.GroupBox
    Protected WithEvents BT_TerminalSend As System.Windows.Forms.Button
    Protected WithEvents TB_TerminalSend As System.Windows.Forms.TextBox
    Protected WithEvents BT_SetParking As System.Windows.Forms.Button
    Protected WithEvents BT_FrontEnd As System.Windows.Forms.Button
    Protected WithEvents GB_Terminal_Recieved As System.Windows.Forms.GroupBox
    Protected WithEvents LB_TerminalRec As System.Windows.Forms.ListBox
    Protected WithEvents BT_CLSRec As System.Windows.Forms.Button
    Protected WithEvents GB_LastPos As System.Windows.Forms.GroupBox
    Protected WithEvents CB_OnOffLine As System.Windows.Forms.CheckBox
    Protected WithEvents BT_Write2Log As System.Windows.Forms.Button
    Friend WithEvents BT_GetLocation As System.Windows.Forms.Button
    Friend WithEvents Layer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tool As System.Windows.Forms.DataGridViewComboBoxColumn
    Protected WithEvents NumUD_BBox As System.Windows.Forms.NumericUpDown

End Class
