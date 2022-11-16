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
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPageDirect = New System.Windows.Forms.TabPage()
        Me.CB_OnOffLine = New System.Windows.Forms.CheckBox()
        Me.PL_Device = New System.Windows.Forms.Panel()
        Me.GB_PathOpimizing = New System.Windows.Forms.GroupBox()
        Me.RB_PO7 = New System.Windows.Forms.RadioButton()
        Me.RB_PO5 = New System.Windows.Forms.RadioButton()
        Me.Lbl_Lengt = New System.Windows.Forms.Label()
        Me.RB_PO1 = New System.Windows.Forms.RadioButton()
        Me.RB_PO2 = New System.Windows.Forms.RadioButton()
        Me.RB_PO3 = New System.Windows.Forms.RadioButton()
        Me.RB_PO4 = New System.Windows.Forms.RadioButton()
        Me.BT_ShowPath = New System.Windows.Forms.Button()
        Me.BT_Set0 = New System.Windows.Forms.Button()
        Me.BT_SetCursor = New System.Windows.Forms.Button()
        Me.BT_Process = New System.Windows.Forms.Button()
        Me.BT_Choose = New System.Windows.Forms.Button()
        Me.BT_UM = New System.Windows.Forms.Button()
        Me.BT_ML = New System.Windows.Forms.Button()
        Me.BT_DR = New System.Windows.Forms.Button()
        Me.BT_DM = New System.Windows.Forms.Button()
        Me.BT_UR = New System.Windows.Forms.Button()
        Me.BT_MR = New System.Windows.Forms.Button()
        Me.BT_DL = New System.Windows.Forms.Button()
        Me.BT_UL = New System.Windows.Forms.Button()
        Me.GB_ToolPosition = New System.Windows.Forms.GroupBox()
        Me.NumUD_Y = New System.Windows.Forms.NumericUpDown()
        Me.NumUD_X = New System.Windows.Forms.NumericUpDown()
        Me.Lbl_x = New System.Windows.Forms.Label()
        Me.Lbl_y = New System.Windows.Forms.Label()
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
        Me.tabPageLayerS = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CompBt = New System.Windows.Forms.Button()
        Me.CNC_CheckLayerVisibility = New System.Windows.Forms.CheckBox()
        Me.CNC_LayerGrid = New System.Windows.Forms.DataGridView()
        Me.Layer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tool = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.CutterPanel = New System.Windows.Forms.GroupBox()
        Me.SpeedUp_UDBT = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SP4SpeedDown_UDBT = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SP1SpeedDown_UDBT = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SP2SpeedDown_UDBT = New System.Windows.Forms.NumericUpDown()
        Me.LaserPanel = New System.Windows.Forms.GroupBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.CutPower_UDBT = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CutSpeedDown_UDBT = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.EngPower_UDBT = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.EngSpeedDown_UDBT = New System.Windows.Forms.NumericUpDown()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl.SuspendLayout()
        Me.TabPageDirect.SuspendLayout()
        Me.PL_Device.SuspendLayout()
        Me.GB_PathOpimizing.SuspendLayout()
        Me.GB_ToolPosition.SuspendLayout()
        CType(Me.NumUD_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUD_X, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BasePointGB.SuspendLayout()
        Me.tabPageLayerS.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.CNC_LayerGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.CutterPanel.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        CType(Me.SP4SpeedDown_UDBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        CType(Me.SP1SpeedDown_UDBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        CType(Me.SP2SpeedDown_UDBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LaserPanel.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.CutPower_UDBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CutSpeedDown_UDBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox16.SuspendLayout()
        CType(Me.EngPower_UDBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EngSpeedDown_UDBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPageDirect)
        Me.TabControl.Controls.Add(Me.tabPageLayerS)
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(522, 718)
        Me.TabControl.TabIndex = 1
        '
        'TabPageDirect
        '
        Me.TabPageDirect.Controls.Add(Me.CB_OnOffLine)
        Me.TabPageDirect.Controls.Add(Me.PL_Device)
        Me.TabPageDirect.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDirect.Name = "TabPageDirect"
        Me.TabPageDirect.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDirect.Size = New System.Drawing.Size(514, 692)
        Me.TabPageDirect.TabIndex = 5
        Me.TabPageDirect.Text = "Direct"
        Me.TabPageDirect.UseVisualStyleBackColor = True
        '
        'CB_OnOffLine
        '
        Me.CB_OnOffLine.Appearance = System.Windows.Forms.Appearance.Button
        Me.CB_OnOffLine.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CB_OnOffLine.Location = New System.Drawing.Point(12, 4)
        Me.CB_OnOffLine.Name = "CB_OnOffLine"
        Me.CB_OnOffLine.Size = New System.Drawing.Size(102, 24)
        Me.CB_OnOffLine.TabIndex = 36
        Me.CB_OnOffLine.Text = "online"
        Me.CB_OnOffLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_OnOffLine.UseVisualStyleBackColor = False
        '
        'PL_Device
        '
        Me.PL_Device.Controls.Add(Me.GB_PathOpimizing)
        Me.PL_Device.Controls.Add(Me.BT_ShowPath)
        Me.PL_Device.Controls.Add(Me.BT_Set0)
        Me.PL_Device.Controls.Add(Me.BT_SetCursor)
        Me.PL_Device.Controls.Add(Me.BT_Process)
        Me.PL_Device.Controls.Add(Me.BT_Choose)
        Me.PL_Device.Controls.Add(Me.BT_UM)
        Me.PL_Device.Controls.Add(Me.BT_ML)
        Me.PL_Device.Controls.Add(Me.BT_DR)
        Me.PL_Device.Controls.Add(Me.BT_DM)
        Me.PL_Device.Controls.Add(Me.BT_UR)
        Me.PL_Device.Controls.Add(Me.BT_MR)
        Me.PL_Device.Controls.Add(Me.BT_DL)
        Me.PL_Device.Controls.Add(Me.BT_UL)
        Me.PL_Device.Controls.Add(Me.GB_ToolPosition)
        Me.PL_Device.Controls.Add(Me.BasePointGB)
        Me.PL_Device.Enabled = False
        Me.PL_Device.Location = New System.Drawing.Point(6, 34)
        Me.PL_Device.Name = "PL_Device"
        Me.PL_Device.Size = New System.Drawing.Size(111, 640)
        Me.PL_Device.TabIndex = 14
        '
        'GB_PathOpimizing
        '
        Me.GB_PathOpimizing.Controls.Add(Me.RB_PO7)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_PO5)
        Me.GB_PathOpimizing.Controls.Add(Me.Lbl_Lengt)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_PO1)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_PO2)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_PO3)
        Me.GB_PathOpimizing.Controls.Add(Me.RB_PO4)
        Me.GB_PathOpimizing.Location = New System.Drawing.Point(6, 426)
        Me.GB_PathOpimizing.Name = "GB_PathOpimizing"
        Me.GB_PathOpimizing.Size = New System.Drawing.Size(101, 175)
        Me.GB_PathOpimizing.TabIndex = 26
        Me.GB_PathOpimizing.TabStop = False
        Me.GB_PathOpimizing.Text = "Path Optimizing"
        '
        'RB_PO7
        '
        Me.RB_PO7.AutoSize = True
        Me.RB_PO7.Checked = True
        Me.RB_PO7.Location = New System.Drawing.Point(6, 88)
        Me.RB_PO7.Name = "RB_PO7"
        Me.RB_PO7.Size = New System.Drawing.Size(64, 17)
        Me.RB_PO7.TabIndex = 39
        Me.RB_PO7.TabStop = True
        Me.RB_PO7.Text = "NENE +"
        Me.ToolTips.SetToolTip(Me.RB_PO7, "Nearest Neighbor Heuristik")
        Me.RB_PO7.UseVisualStyleBackColor = True
        '
        'RB_PO5
        '
        Me.RB_PO5.AutoSize = True
        Me.RB_PO5.Location = New System.Drawing.Point(6, 134)
        Me.RB_PO5.Name = "RB_PO5"
        Me.RB_PO5.Size = New System.Drawing.Size(66, 17)
        Me.RB_PO5.TabIndex = 38
        Me.RB_PO5.Text = "FARIN +"
        Me.ToolTips.SetToolTip(Me.RB_PO5, "Farthest-Insertion-Heuristik")
        Me.RB_PO5.UseVisualStyleBackColor = True
        '
        'Lbl_Lengt
        '
        Me.Lbl_Lengt.AutoSize = True
        Me.Lbl_Lengt.Location = New System.Drawing.Point(6, 151)
        Me.Lbl_Lengt.Name = "Lbl_Lengt"
        Me.Lbl_Lengt.Size = New System.Drawing.Size(13, 13)
        Me.Lbl_Lengt.TabIndex = 37
        Me.Lbl_Lengt.Text = "0"
        '
        'RB_PO1
        '
        Me.RB_PO1.AutoSize = True
        Me.RB_PO1.Location = New System.Drawing.Point(9, 42)
        Me.RB_PO1.Name = "RB_PO1"
        Me.RB_PO1.Size = New System.Drawing.Size(55, 17)
        Me.RB_PO1.TabIndex = 1
        Me.RB_PO1.Text = "SORX"
        Me.ToolTips.SetToolTip(Me.RB_PO1, "Sorting X Value")
        Me.RB_PO1.UseVisualStyleBackColor = True
        '
        'RB_PO2
        '
        Me.RB_PO2.AutoSize = True
        Me.RB_PO2.Checked = True
        Me.RB_PO2.Location = New System.Drawing.Point(9, 65)
        Me.RB_PO2.Name = "RB_PO2"
        Me.RB_PO2.Size = New System.Drawing.Size(55, 17)
        Me.RB_PO2.TabIndex = 2
        Me.RB_PO2.TabStop = True
        Me.RB_PO2.Text = "NENE"
        Me.ToolTips.SetToolTip(Me.RB_PO2, "Nearest Neighbor Heuristik")
        Me.RB_PO2.UseVisualStyleBackColor = True
        '
        'RB_PO3
        '
        Me.RB_PO3.AutoSize = True
        Me.RB_PO3.Location = New System.Drawing.Point(6, 111)
        Me.RB_PO3.Name = "RB_PO3"
        Me.RB_PO3.Size = New System.Drawing.Size(57, 17)
        Me.RB_PO3.TabIndex = 3
        Me.RB_PO3.Text = "FARIN"
        Me.ToolTips.SetToolTip(Me.RB_PO3, "Farthest-Insertion-Heuristik")
        Me.RB_PO3.UseVisualStyleBackColor = True
        '
        'RB_PO4
        '
        Me.RB_PO4.AutoSize = True
        Me.RB_PO4.Location = New System.Drawing.Point(9, 19)
        Me.RB_PO4.Name = "RB_PO4"
        Me.RB_PO4.Size = New System.Drawing.Size(49, 17)
        Me.RB_PO4.TabIndex = 4
        Me.RB_PO4.Text = "none"
        Me.RB_PO4.UseVisualStyleBackColor = True
        '
        'BT_ShowPath
        '
        Me.BT_ShowPath.Location = New System.Drawing.Point(6, 397)
        Me.BT_ShowPath.Name = "BT_ShowPath"
        Me.BT_ShowPath.Size = New System.Drawing.Size(101, 23)
        Me.BT_ShowPath.TabIndex = 25
        Me.BT_ShowPath.Text = "Show Path"
        Me.BT_ShowPath.UseVisualStyleBackColor = True
        '
        'BT_Set0
        '
        Me.BT_Set0.Location = New System.Drawing.Point(5, 112)
        Me.BT_Set0.Name = "BT_Set0"
        Me.BT_Set0.Size = New System.Drawing.Size(102, 23)
        Me.BT_Set0.TabIndex = 22
        Me.BT_Set0.Text = "Zero Point"
        Me.BT_Set0.UseVisualStyleBackColor = True
        '
        'BT_SetCursor
        '
        Me.BT_SetCursor.Font = New System.Drawing.Font("Wingdings", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_SetCursor.Location = New System.Drawing.Point(41, 40)
        Me.BT_SetCursor.Margin = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.BT_SetCursor.Name = "BT_SetCursor"
        Me.BT_SetCursor.Size = New System.Drawing.Size(30, 30)
        Me.BT_SetCursor.TabIndex = 17
        Me.BT_SetCursor.Text = "°"
        Me.BT_SetCursor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_SetCursor.UseVisualStyleBackColor = True
        '
        'BT_Process
        '
        Me.BT_Process.Location = New System.Drawing.Point(6, 221)
        Me.BT_Process.Name = "BT_Process"
        Me.BT_Process.Size = New System.Drawing.Size(101, 23)
        Me.BT_Process.TabIndex = 22
        Me.BT_Process.Text = "Process"
        Me.BT_Process.UseVisualStyleBackColor = True
        '
        'BT_Choose
        '
        Me.BT_Choose.Location = New System.Drawing.Point(6, 250)
        Me.BT_Choose.Name = "BT_Choose"
        Me.BT_Choose.Size = New System.Drawing.Size(101, 23)
        Me.BT_Choose.TabIndex = 0
        Me.BT_Choose.Text = "Choose Objects"
        Me.BT_Choose.UseVisualStyleBackColor = True
        '
        'BT_UM
        '
        Me.BT_UM.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_UM.Location = New System.Drawing.Point(41, 4)
        Me.BT_UM.Name = "BT_UM"
        Me.BT_UM.Size = New System.Drawing.Size(30, 30)
        Me.BT_UM.TabIndex = 6
        Me.BT_UM.Text = "é"
        Me.BT_UM.UseVisualStyleBackColor = True
        '
        'BT_ML
        '
        Me.BT_ML.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_ML.Location = New System.Drawing.Point(5, 40)
        Me.BT_ML.Name = "BT_ML"
        Me.BT_ML.Size = New System.Drawing.Size(30, 30)
        Me.BT_ML.TabIndex = 5
        Me.BT_ML.Text = "ç"
        Me.BT_ML.UseVisualStyleBackColor = True
        '
        'BT_DR
        '
        Me.BT_DR.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_DR.Location = New System.Drawing.Point(77, 76)
        Me.BT_DR.Name = "BT_DR"
        Me.BT_DR.Size = New System.Drawing.Size(30, 30)
        Me.BT_DR.TabIndex = 12
        Me.BT_DR.Text = "î"
        Me.BT_DR.UseVisualStyleBackColor = True
        '
        'BT_DM
        '
        Me.BT_DM.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_DM.Location = New System.Drawing.Point(41, 76)
        Me.BT_DM.Name = "BT_DM"
        Me.BT_DM.Size = New System.Drawing.Size(30, 30)
        Me.BT_DM.TabIndex = 7
        Me.BT_DM.Text = "ê"
        Me.BT_DM.UseVisualStyleBackColor = True
        '
        'BT_UR
        '
        Me.BT_UR.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_UR.Location = New System.Drawing.Point(77, 4)
        Me.BT_UR.Name = "BT_UR"
        Me.BT_UR.Size = New System.Drawing.Size(30, 30)
        Me.BT_UR.TabIndex = 11
        Me.BT_UR.Text = "ì"
        Me.BT_UR.UseVisualStyleBackColor = True
        '
        'BT_MR
        '
        Me.BT_MR.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_MR.Location = New System.Drawing.Point(77, 40)
        Me.BT_MR.Name = "BT_MR"
        Me.BT_MR.Size = New System.Drawing.Size(30, 30)
        Me.BT_MR.TabIndex = 8
        Me.BT_MR.Text = "è"
        Me.BT_MR.UseVisualStyleBackColor = True
        '
        'BT_DL
        '
        Me.BT_DL.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_DL.Location = New System.Drawing.Point(5, 76)
        Me.BT_DL.Name = "BT_DL"
        Me.BT_DL.Size = New System.Drawing.Size(30, 30)
        Me.BT_DL.TabIndex = 10
        Me.BT_DL.Text = "í"
        Me.BT_DL.UseVisualStyleBackColor = True
        '
        'BT_UL
        '
        Me.BT_UL.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BT_UL.Location = New System.Drawing.Point(5, 4)
        Me.BT_UL.Name = "BT_UL"
        Me.BT_UL.Size = New System.Drawing.Size(30, 30)
        Me.BT_UL.TabIndex = 9
        Me.BT_UL.Text = "ë"
        Me.BT_UL.UseVisualStyleBackColor = True
        '
        'GB_ToolPosition
        '
        Me.GB_ToolPosition.Controls.Add(Me.NumUD_Y)
        Me.GB_ToolPosition.Controls.Add(Me.NumUD_X)
        Me.GB_ToolPosition.Controls.Add(Me.Lbl_x)
        Me.GB_ToolPosition.Controls.Add(Me.Lbl_y)
        Me.GB_ToolPosition.Location = New System.Drawing.Point(6, 142)
        Me.GB_ToolPosition.Name = "GB_ToolPosition"
        Me.GB_ToolPosition.Size = New System.Drawing.Size(102, 74)
        Me.GB_ToolPosition.TabIndex = 4
        Me.GB_ToolPosition.TabStop = False
        Me.GB_ToolPosition.Text = "Tool Position"
        '
        'NumUD_Y
        '
        Me.NumUD_Y.Location = New System.Drawing.Point(32, 45)
        Me.NumUD_Y.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.NumUD_Y.Name = "NumUD_Y"
        Me.NumUD_Y.Size = New System.Drawing.Size(64, 20)
        Me.NumUD_Y.TabIndex = 17
        Me.NumUD_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NumUD_X
        '
        Me.NumUD_X.Location = New System.Drawing.Point(32, 19)
        Me.NumUD_X.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.NumUD_X.Name = "NumUD_X"
        Me.NumUD_X.Size = New System.Drawing.Size(64, 20)
        Me.NumUD_X.TabIndex = 18
        Me.NumUD_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_x
        '
        Me.Lbl_x.AutoSize = True
        Me.Lbl_x.Location = New System.Drawing.Point(6, 21)
        Me.Lbl_x.Name = "Lbl_x"
        Me.Lbl_x.Size = New System.Drawing.Size(20, 13)
        Me.Lbl_x.TabIndex = 2
        Me.Lbl_x.Text = "X="
        '
        'Lbl_y
        '
        Me.Lbl_y.AutoSize = True
        Me.Lbl_y.Location = New System.Drawing.Point(6, 47)
        Me.Lbl_y.Name = "Lbl_y"
        Me.Lbl_y.Size = New System.Drawing.Size(20, 13)
        Me.Lbl_y.TabIndex = 3
        Me.Lbl_y.Text = "Y="
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
        Me.BasePointGB.Location = New System.Drawing.Point(6, 279)
        Me.BasePointGB.Name = "BasePointGB"
        Me.BasePointGB.Size = New System.Drawing.Size(101, 112)
        Me.BasePointGB.TabIndex = 24
        Me.BasePointGB.TabStop = False
        Me.BasePointGB.Text = "Set Basepoint"
        '
        'BT_DevMM
        '
        Me.BT_DevMM.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevMM.Location = New System.Drawing.Point(35, 44)
        Me.BT_DevMM.Name = "BT_DevMM"
        Me.BT_DevMM.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevMM.TabIndex = 8
        Me.BT_DevMM.Text = "╬"
        Me.BT_DevMM.UseVisualStyleBackColor = True
        '
        'BT_DevTL
        '
        Me.BT_DevTL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevTL.Location = New System.Drawing.Point(6, 15)
        Me.BT_DevTL.Name = "BT_DevTL"
        Me.BT_DevTL.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevTL.TabIndex = 6
        Me.BT_DevTL.Text = "╔"
        Me.BT_DevTL.UseVisualStyleBackColor = True
        '
        'BT_DevTR
        '
        Me.BT_DevTR.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevTR.Location = New System.Drawing.Point(64, 15)
        Me.BT_DevTR.Name = "BT_DevTR"
        Me.BT_DevTR.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevTR.TabIndex = 7
        Me.BT_DevTR.Text = "╗"
        Me.BT_DevTR.UseVisualStyleBackColor = True
        '
        'BT_DevTM
        '
        Me.BT_DevTM.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevTM.Location = New System.Drawing.Point(35, 15)
        Me.BT_DevTM.Name = "BT_DevTM"
        Me.BT_DevTM.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevTM.TabIndex = 0
        Me.BT_DevTM.Text = "╦"
        Me.BT_DevTM.UseVisualStyleBackColor = True
        '
        'BT_DevBM
        '
        Me.BT_DevBM.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevBM.Location = New System.Drawing.Point(35, 73)
        Me.BT_DevBM.Name = "BT_DevBM"
        Me.BT_DevBM.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevBM.TabIndex = 1
        Me.BT_DevBM.Text = "╩"
        Me.BT_DevBM.UseVisualStyleBackColor = True
        '
        'BT_DevBR
        '
        Me.BT_DevBR.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevBR.Location = New System.Drawing.Point(64, 73)
        Me.BT_DevBR.Name = "BT_DevBR"
        Me.BT_DevBR.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevBR.TabIndex = 5
        Me.BT_DevBR.Text = "╝"
        Me.BT_DevBR.UseVisualStyleBackColor = True
        '
        'BT_DevMR
        '
        Me.BT_DevMR.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevMR.Location = New System.Drawing.Point(64, 44)
        Me.BT_DevMR.Name = "BT_DevMR"
        Me.BT_DevMR.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevMR.TabIndex = 2
        Me.BT_DevMR.Text = "╣"
        Me.BT_DevMR.UseVisualStyleBackColor = True
        '
        'BT_DevBL
        '
        Me.BT_DevBL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevBL.Location = New System.Drawing.Point(6, 73)
        Me.BT_DevBL.Name = "BT_DevBL"
        Me.BT_DevBL.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevBL.TabIndex = 4
        Me.BT_DevBL.Text = "╚"
        Me.BT_DevBL.UseVisualStyleBackColor = True
        '
        'BT_DevML
        '
        Me.BT_DevML.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_DevML.Location = New System.Drawing.Point(6, 44)
        Me.BT_DevML.Name = "BT_DevML"
        Me.BT_DevML.Size = New System.Drawing.Size(30, 30)
        Me.BT_DevML.TabIndex = 3
        Me.BT_DevML.Text = "╠"
        Me.BT_DevML.UseVisualStyleBackColor = True
        '
        'tabPageLayerS
        '
        Me.tabPageLayerS.Controls.Add(Me.SplitContainer1)
        Me.tabPageLayerS.Location = New System.Drawing.Point(4, 22)
        Me.tabPageLayerS.Name = "tabPageLayerS"
        Me.tabPageLayerS.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageLayerS.Size = New System.Drawing.Size(514, 692)
        Me.tabPageLayerS.TabIndex = 2
        Me.tabPageLayerS.Text = "Layer Settings"
        Me.tabPageLayerS.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.CompBt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CNC_CheckLayerVisibility)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CNC_LayerGrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(508, 686)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 6
        '
        'CompBt
        '
        Me.CompBt.Location = New System.Drawing.Point(125, 0)
        Me.CompBt.Name = "CompBt"
        Me.CompBt.Size = New System.Drawing.Size(80, 23)
        Me.CompBt.TabIndex = 6
        Me.CompBt.Text = "compatibility"
        Me.CompBt.UseVisualStyleBackColor = True
        '
        'CNC_CheckLayerVisibility
        '
        Me.CNC_CheckLayerVisibility.AutoSize = True
        Me.CNC_CheckLayerVisibility.Location = New System.Drawing.Point(3, 3)
        Me.CNC_CheckLayerVisibility.Name = "CNC_CheckLayerVisibility"
        Me.CNC_CheckLayerVisibility.Size = New System.Drawing.Size(116, 17)
        Me.CNC_CheckLayerVisibility.TabIndex = 5
        Me.CNC_CheckLayerVisibility.Text = "Hide unused layers"
        Me.CNC_CheckLayerVisibility.UseVisualStyleBackColor = True
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
        Me.CNC_LayerGrid.Name = "CNC_LayerGrid"
        Me.CNC_LayerGrid.RowHeadersVisible = False
        Me.CNC_LayerGrid.RowTemplate.Height = 20
        Me.CNC_LayerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CNC_LayerGrid.Size = New System.Drawing.Size(508, 660)
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
        Me.Tool.Items.AddRange(New Object() {"-", "frame", "cut", "engrave", "SP1", "SP2", "SP4"})
        Me.Tool.Name = "Tool"
        Me.Tool.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(514, 692)
        Me.TabPage1.TabIndex = 6
        Me.TabPage1.Text = "Devices"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Label1"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.RadioButton4)
        Me.Panel3.Controls.Add(Me.RadioButton3)
        Me.Panel3.Controls.Add(Me.ComboBox1)
        Me.Panel3.Controls.Add(Me.ComboBox2)
        Me.Panel3.Controls.Add(Me.CutterPanel)
        Me.Panel3.Controls.Add(Me.LaserPanel)
        Me.Panel3.Location = New System.Drawing.Point(58, 98)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(377, 419)
        Me.Panel3.TabIndex = 36
        '
        'RadioButton4
        '
        Me.RadioButton4.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton4.Location = New System.Drawing.Point(171, 3)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(142, 23)
        Me.RadioButton4.TabIndex = 34
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Cutter"
        Me.RadioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton3.Location = New System.Drawing.Point(9, 3)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(142, 23)
        Me.RadioButton3.TabIndex = 33
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Laser"
        Me.RadioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(9, 35)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(142, 21)
        Me.ComboBox1.TabIndex = 27
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(171, 35)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(142, 21)
        Me.ComboBox2.TabIndex = 28
        '
        'CutterPanel
        '
        Me.CutterPanel.Controls.Add(Me.SpeedUp_UDBT)
        Me.CutterPanel.Controls.Add(Me.NumericUpDown1)
        Me.CutterPanel.Controls.Add(Me.GroupBox11)
        Me.CutterPanel.Controls.Add(Me.GroupBox12)
        Me.CutterPanel.Controls.Add(Me.GroupBox13)
        Me.CutterPanel.Enabled = False
        Me.CutterPanel.Location = New System.Drawing.Point(165, 62)
        Me.CutterPanel.Name = "CutterPanel"
        Me.CutterPanel.Size = New System.Drawing.Size(156, 297)
        Me.CutterPanel.TabIndex = 32
        Me.CutterPanel.TabStop = False
        Me.CutterPanel.Text = "Zünd"
        '
        'SpeedUp_UDBT
        '
        Me.SpeedUp_UDBT.AutoSize = True
        Me.SpeedUp_UDBT.Location = New System.Drawing.Point(7, 256)
        Me.SpeedUp_UDBT.Name = "SpeedUp_UDBT"
        Me.SpeedUp_UDBT.Size = New System.Drawing.Size(61, 26)
        Me.SpeedUp_UDBT.TabIndex = 24
        Me.SpeedUp_UDBT.Text = "z-up travel " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "height (mm)"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Enabled = False
        Me.NumericUpDown1.Location = New System.Drawing.Point(94, 258)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NumericUpDown1.Size = New System.Drawing.Size(43, 20)
        Me.NumericUpDown1.TabIndex = 25
        Me.NumericUpDown1.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label12)
        Me.GroupBox11.Controls.Add(Me.SP4SpeedDown_UDBT)
        Me.GroupBox11.Location = New System.Drawing.Point(6, 179)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(142, 73)
        Me.GroupBox11.TabIndex = 23
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "SP4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Speed [mm/s]"
        '
        'SP4SpeedDown_UDBT
        '
        Me.SP4SpeedDown_UDBT.Enabled = False
        Me.SP4SpeedDown_UDBT.Location = New System.Drawing.Point(88, 26)
        Me.SP4SpeedDown_UDBT.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SP4SpeedDown_UDBT.Name = "SP4SpeedDown_UDBT"
        Me.SP4SpeedDown_UDBT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SP4SpeedDown_UDBT.Size = New System.Drawing.Size(43, 20)
        Me.SP4SpeedDown_UDBT.TabIndex = 16
        Me.SP4SpeedDown_UDBT.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label13)
        Me.GroupBox12.Controls.Add(Me.SP1SpeedDown_UDBT)
        Me.GroupBox12.Location = New System.Drawing.Point(6, 21)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(142, 73)
        Me.GroupBox12.TabIndex = 21
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "SP1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Speed [mm/s]"
        '
        'SP1SpeedDown_UDBT
        '
        Me.SP1SpeedDown_UDBT.Location = New System.Drawing.Point(88, 19)
        Me.SP1SpeedDown_UDBT.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.SP1SpeedDown_UDBT.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.SP1SpeedDown_UDBT.Name = "SP1SpeedDown_UDBT"
        Me.SP1SpeedDown_UDBT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SP1SpeedDown_UDBT.Size = New System.Drawing.Size(43, 20)
        Me.SP1SpeedDown_UDBT.TabIndex = 14
        Me.SP1SpeedDown_UDBT.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label14)
        Me.GroupBox13.Controls.Add(Me.SP2SpeedDown_UDBT)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 100)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(142, 73)
        Me.GroupBox13.TabIndex = 22
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "SP2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Speed [mm/s]"
        '
        'SP2SpeedDown_UDBT
        '
        Me.SP2SpeedDown_UDBT.Location = New System.Drawing.Point(88, 19)
        Me.SP2SpeedDown_UDBT.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.SP2SpeedDown_UDBT.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SP2SpeedDown_UDBT.Name = "SP2SpeedDown_UDBT"
        Me.SP2SpeedDown_UDBT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SP2SpeedDown_UDBT.Size = New System.Drawing.Size(43, 20)
        Me.SP2SpeedDown_UDBT.TabIndex = 14
        Me.SP2SpeedDown_UDBT.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'LaserPanel
        '
        Me.LaserPanel.Controls.Add(Me.GroupBox15)
        Me.LaserPanel.Controls.Add(Me.GroupBox16)
        Me.LaserPanel.Enabled = False
        Me.LaserPanel.Location = New System.Drawing.Point(3, 62)
        Me.LaserPanel.Name = "LaserPanel"
        Me.LaserPanel.Size = New System.Drawing.Size(156, 178)
        Me.LaserPanel.TabIndex = 31
        Me.LaserPanel.TabStop = False
        Me.LaserPanel.Text = "Euro Laser"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.CutPower_UDBT)
        Me.GroupBox15.Controls.Add(Me.Label15)
        Me.GroupBox15.Controls.Add(Me.Label16)
        Me.GroupBox15.Controls.Add(Me.CutSpeedDown_UDBT)
        Me.GroupBox15.Location = New System.Drawing.Point(6, 21)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(142, 73)
        Me.GroupBox15.TabIndex = 21
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Cut"
        '
        'CutPower_UDBT
        '
        Me.CutPower_UDBT.Location = New System.Drawing.Point(91, 43)
        Me.CutPower_UDBT.Name = "CutPower_UDBT"
        Me.CutPower_UDBT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CutPower_UDBT.Size = New System.Drawing.Size(43, 20)
        Me.CutPower_UDBT.TabIndex = 15
        Me.CutPower_UDBT.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Power (1-80%)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Speed [mm/s]"
        '
        'CutSpeedDown_UDBT
        '
        Me.CutSpeedDown_UDBT.Location = New System.Drawing.Point(91, 19)
        Me.CutSpeedDown_UDBT.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.CutSpeedDown_UDBT.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.CutSpeedDown_UDBT.Name = "CutSpeedDown_UDBT"
        Me.CutSpeedDown_UDBT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CutSpeedDown_UDBT.Size = New System.Drawing.Size(43, 20)
        Me.CutSpeedDown_UDBT.TabIndex = 14
        Me.CutSpeedDown_UDBT.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.EngPower_UDBT)
        Me.GroupBox16.Controls.Add(Me.Label17)
        Me.GroupBox16.Controls.Add(Me.Label18)
        Me.GroupBox16.Controls.Add(Me.EngSpeedDown_UDBT)
        Me.GroupBox16.Location = New System.Drawing.Point(6, 100)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(142, 73)
        Me.GroupBox16.TabIndex = 22
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Engrave"
        '
        'EngPower_UDBT
        '
        Me.EngPower_UDBT.Location = New System.Drawing.Point(88, 43)
        Me.EngPower_UDBT.Name = "EngPower_UDBT"
        Me.EngPower_UDBT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EngPower_UDBT.Size = New System.Drawing.Size(43, 20)
        Me.EngPower_UDBT.TabIndex = 15
        Me.EngPower_UDBT.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Power (1-80%)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 13)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "Speed [mm/s]"
        '
        'EngSpeedDown_UDBT
        '
        Me.EngSpeedDown_UDBT.Location = New System.Drawing.Point(88, 19)
        Me.EngSpeedDown_UDBT.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.EngSpeedDown_UDBT.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.EngSpeedDown_UDBT.Name = "EngSpeedDown_UDBT"
        Me.EngSpeedDown_UDBT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EngSpeedDown_UDBT.Size = New System.Drawing.Size(43, 20)
        Me.EngSpeedDown_UDBT.TabIndex = 14
        Me.EngSpeedDown_UDBT.Value = New Decimal(New Integer() {150, 0, 0, 0})
        '
        'PlugInControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl)
        Me.Name = "PlugInControls"
        Me.Size = New System.Drawing.Size(522, 718)
        Me.TabControl.ResumeLayout(False)
        Me.TabPageDirect.ResumeLayout(False)
        Me.PL_Device.ResumeLayout(False)
        Me.GB_PathOpimizing.ResumeLayout(False)
        Me.GB_PathOpimizing.PerformLayout()
        Me.GB_ToolPosition.ResumeLayout(False)
        Me.GB_ToolPosition.PerformLayout()
        CType(Me.NumUD_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUD_X, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BasePointGB.ResumeLayout(False)
        Me.tabPageLayerS.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.CNC_LayerGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.CutterPanel.ResumeLayout(False)
        Me.CutterPanel.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.SP4SpeedDown_UDBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        CType(Me.SP1SpeedDown_UDBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        CType(Me.SP2SpeedDown_UDBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LaserPanel.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.CutPower_UDBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CutSpeedDown_UDBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        CType(Me.EngPower_UDBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EngSpeedDown_UDBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPageDirect As System.Windows.Forms.TabPage
    Friend WithEvents BT_Set0 As System.Windows.Forms.Button
    Friend WithEvents BT_SetCursor As System.Windows.Forms.Button
    Friend WithEvents BT_Process As System.Windows.Forms.Button
    Friend WithEvents BT_Choose As System.Windows.Forms.Button
    Friend WithEvents BT_UM As System.Windows.Forms.Button
    Friend WithEvents BT_ML As System.Windows.Forms.Button
    Friend WithEvents BT_DR As System.Windows.Forms.Button
    Friend WithEvents BT_DM As System.Windows.Forms.Button
    Friend WithEvents BT_UR As System.Windows.Forms.Button
    Friend WithEvents BT_MR As System.Windows.Forms.Button
    Friend WithEvents BT_DL As System.Windows.Forms.Button
    Friend WithEvents BT_UL As System.Windows.Forms.Button
    Friend WithEvents Lbl_x As System.Windows.Forms.Label
    Friend WithEvents Lbl_y As System.Windows.Forms.Label
    Friend WithEvents BT_DevMM As System.Windows.Forms.Button
    Friend WithEvents BT_DevTL As System.Windows.Forms.Button
    Friend WithEvents BT_DevTR As System.Windows.Forms.Button
    Friend WithEvents BT_DevTM As System.Windows.Forms.Button
    Friend WithEvents BT_DevBM As System.Windows.Forms.Button
    Friend WithEvents BT_DevBR As System.Windows.Forms.Button
    Friend WithEvents BT_DevMR As System.Windows.Forms.Button
    Friend WithEvents BT_DevBL As System.Windows.Forms.Button
    Friend WithEvents BT_DevML As System.Windows.Forms.Button
    Private WithEvents tabPageLayerS As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents CompBt As System.Windows.Forms.Button
    Friend WithEvents Layer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tool As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Public WithEvents TabControl As System.Windows.Forms.TabControl
    Protected Friend WithEvents PL_Device As System.Windows.Forms.Panel
    Protected Friend WithEvents CB_OnOffLine As System.Windows.Forms.CheckBox
    Protected Friend WithEvents CNC_LayerGrid As System.Windows.Forms.DataGridView
    Protected Friend WithEvents CNC_CheckLayerVisibility As System.Windows.Forms.CheckBox
    Public WithEvents NumUD_Y As System.Windows.Forms.NumericUpDown
    Public WithEvents NumUD_X As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents CutterPanel As System.Windows.Forms.GroupBox
    Private WithEvents SpeedUp_UDBT As System.Windows.Forms.Label
    Private WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Private WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents SP4SpeedDown_UDBT As System.Windows.Forms.NumericUpDown
    Private WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents SP1SpeedDown_UDBT As System.Windows.Forms.NumericUpDown
    Private WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents SP2SpeedDown_UDBT As System.Windows.Forms.NumericUpDown
    Friend WithEvents LaserPanel As System.Windows.Forms.GroupBox
    Private WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Private WithEvents CutPower_UDBT As System.Windows.Forms.NumericUpDown
    Private WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents CutSpeedDown_UDBT As System.Windows.Forms.NumericUpDown
    Private WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Private WithEvents EngPower_UDBT As System.Windows.Forms.NumericUpDown
    Private WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents Label18 As System.Windows.Forms.Label
    Private WithEvents EngSpeedDown_UDBT As System.Windows.Forms.NumericUpDown
    Public WithEvents GB_ToolPosition As System.Windows.Forms.GroupBox
    Friend WithEvents BT_ShowPath As System.Windows.Forms.Button
    Friend WithEvents RB_PO1 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_PO2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_PO3 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_PO4 As System.Windows.Forms.RadioButton
    Public WithEvents Lbl_Lengt As System.Windows.Forms.Label
    Public WithEvents GB_PathOpimizing As System.Windows.Forms.GroupBox
    Friend WithEvents RB_PO5 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_PO7 As System.Windows.Forms.RadioButton
    Protected Friend WithEvents BasePointGB As System.Windows.Forms.GroupBox

End Class
