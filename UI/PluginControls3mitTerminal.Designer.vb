<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PluginControls3
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PluginControls3))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TP_Machine = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.P_Bottom = New System.Windows.Forms.Panel()
        Me.CB_BBox = New System.Windows.Forms.CheckBox()
        Me.Lbl_Info = New System.Windows.Forms.Label()
        Me.CB_Preview = New System.Windows.Forms.CheckBox()
        Me.CB_PathOpt = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PB_FileUpload = New System.Windows.Forms.ProgressBar()
        Me.PB_JobProcess = New System.Windows.Forms.ProgressBar()
        Me.BT_StartDirect = New System.Windows.Forms.Button()
        Me.BT_Set0 = New System.Windows.Forms.Button()
        Me.BT_WriteFile = New System.Windows.Forms.Button()
        Me.GBTools = New System.Windows.Forms.GroupBox()
        Me.CB_Material = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_DeviceChoose = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TP_Layers = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CB_ShowVisibleLayers = New System.Windows.Forms.CheckBox()
        Me.DGV_LayerGrid = New System.Windows.Forms.DataGridView()
        Me.Layer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tool = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabTerminal = New System.Windows.Forms.TabPage()
        Me.GB_Terminal_Recieved = New System.Windows.Forms.GroupBox()
        Me.BT_CLSRec = New System.Windows.Forms.Button()
        Me.LB_TerminalRec = New System.Windows.Forms.ListBox()
        Me.GB_TerminalSend = New System.Windows.Forms.GroupBox()
        Me.BT_Write2Log = New System.Windows.Forms.Button()
        Me.BT_FrontEnd = New System.Windows.Forms.Button()
        Me.BT_TerminalSend = New System.Windows.Forms.Button()
        Me.TB_TerminalSend = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TP_Machine.SuspendLayout()
        Me.P_Bottom.SuspendLayout()
        Me.TP_Layers.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGV_LayerGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabTerminal.SuspendLayout()
        Me.GB_Terminal_Recieved.SuspendLayout()
        Me.GB_TerminalSend.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TP_Machine)
        Me.TabControl1.Controls.Add(Me.TP_Layers)
        Me.TabControl1.Controls.Add(Me.TabTerminal)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(220, 762)
        Me.TabControl1.TabIndex = 0
        '
        'TP_Machine
        '
        Me.TP_Machine.Controls.Add(Me.Label3)
        Me.TP_Machine.Controls.Add(Me.RadioButton2)
        Me.TP_Machine.Controls.Add(Me.RadioButton1)
        Me.TP_Machine.Controls.Add(Me.P_Bottom)
        Me.TP_Machine.Controls.Add(Me.GBTools)
        Me.TP_Machine.Controls.Add(Me.CB_Material)
        Me.TP_Machine.Controls.Add(Me.Label2)
        Me.TP_Machine.Controls.Add(Me.CB_DeviceChoose)
        Me.TP_Machine.Controls.Add(Me.Label1)
        Me.TP_Machine.Location = New System.Drawing.Point(4, 22)
        Me.TP_Machine.Name = "TP_Machine"
        Me.TP_Machine.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Machine.Size = New System.Drawing.Size(212, 736)
        Me.TP_Machine.TabIndex = 0
        Me.TP_Machine.Text = "Machine"
        Me.TP_Machine.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(-1, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 23)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Source"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadioButton2
        '
        Me.RadioButton2.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton2.Location = New System.Drawing.Point(131, 6)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(75, 23)
        Me.RadioButton2.TabIndex = 52
        Me.RadioButton2.Text = "File"
        Me.RadioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(50, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(75, 23)
        Me.RadioButton1.TabIndex = 51
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Drawing"
        Me.RadioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'P_Bottom
        '
        Me.P_Bottom.Controls.Add(Me.CB_BBox)
        Me.P_Bottom.Controls.Add(Me.Lbl_Info)
        Me.P_Bottom.Controls.Add(Me.CB_Preview)
        Me.P_Bottom.Controls.Add(Me.CB_PathOpt)
        Me.P_Bottom.Controls.Add(Me.Label6)
        Me.P_Bottom.Controls.Add(Me.PB_FileUpload)
        Me.P_Bottom.Controls.Add(Me.PB_JobProcess)
        Me.P_Bottom.Controls.Add(Me.BT_StartDirect)
        Me.P_Bottom.Controls.Add(Me.BT_Set0)
        Me.P_Bottom.Controls.Add(Me.BT_WriteFile)
        Me.P_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.P_Bottom.Location = New System.Drawing.Point(3, 378)
        Me.P_Bottom.Name = "P_Bottom"
        Me.P_Bottom.Size = New System.Drawing.Size(206, 355)
        Me.P_Bottom.TabIndex = 50
        '
        'CB_BBox
        '
        Me.CB_BBox.AutoSize = True
        Me.CB_BBox.Checked = True
        Me.CB_BBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_BBox.Location = New System.Drawing.Point(9, 28)
        Me.CB_BBox.Name = "CB_BBox"
        Me.CB_BBox.Size = New System.Drawing.Size(111, 17)
        Me.CB_BBox.TabIndex = 52
        Me.CB_BBox.Text = "Cut Bounding Box"
        Me.CB_BBox.UseVisualStyleBackColor = True
        '
        'Lbl_Info
        '
        Me.Lbl_Info.AccessibleName = resources.GetString("Lbl_Info.AccessibleName")
        Me.Lbl_Info.AutoSize = True
        Me.Lbl_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Info.Location = New System.Drawing.Point(6, 216)
        Me.Lbl_Info.Name = "Lbl_Info"
        Me.Lbl_Info.Size = New System.Drawing.Size(137, 32)
        Me.Lbl_Info.TabIndex = 50
        Me.Lbl_Info.Text = "Please restart Rhino " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to work with this plugin"
        '
        'CB_Preview
        '
        Me.CB_Preview.Appearance = System.Windows.Forms.Appearance.Button
        Me.CB_Preview.Location = New System.Drawing.Point(3, 49)
        Me.CB_Preview.Name = "CB_Preview"
        Me.CB_Preview.Size = New System.Drawing.Size(200, 23)
        Me.CB_Preview.TabIndex = 51
        Me.CB_Preview.Text = "Calculate Time"
        Me.CB_Preview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_Preview.UseVisualStyleBackColor = False
        '
        'CB_PathOpt
        '
        Me.CB_PathOpt.Checked = True
        Me.CB_PathOpt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_PathOpt.Location = New System.Drawing.Point(9, 6)
        Me.CB_PathOpt.Name = "CB_PathOpt"
        Me.CB_PathOpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CB_PathOpt.Size = New System.Drawing.Size(111, 17)
        Me.CB_PathOpt.TabIndex = 42
        Me.CB_PathOpt.Text = "Path Optimisation"
        Me.CB_PathOpt.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Job Process:"
        '
        'PB_FileUpload
        '
        Me.PB_FileUpload.Location = New System.Drawing.Point(3, 180)
        Me.PB_FileUpload.Maximum = 15
        Me.PB_FileUpload.Name = "PB_FileUpload"
        Me.PB_FileUpload.Size = New System.Drawing.Size(200, 10)
        Me.PB_FileUpload.Step = 1
        Me.PB_FileUpload.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_FileUpload.TabIndex = 47
        '
        'PB_JobProcess
        '
        Me.PB_JobProcess.Location = New System.Drawing.Point(3, 189)
        Me.PB_JobProcess.Maximum = 14
        Me.PB_JobProcess.Name = "PB_JobProcess"
        Me.PB_JobProcess.Size = New System.Drawing.Size(200, 24)
        Me.PB_JobProcess.Step = 1
        Me.PB_JobProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_JobProcess.TabIndex = 48
        '
        'BT_StartDirect
        '
        Me.BT_StartDirect.Location = New System.Drawing.Point(3, 107)
        Me.BT_StartDirect.Name = "BT_StartDirect"
        Me.BT_StartDirect.Size = New System.Drawing.Size(200, 23)
        Me.BT_StartDirect.TabIndex = 44
        Me.BT_StartDirect.Text = "Cut"
        Me.BT_StartDirect.UseVisualStyleBackColor = True
        '
        'BT_Set0
        '
        Me.BT_Set0.Location = New System.Drawing.Point(3, 78)
        Me.BT_Set0.Name = "BT_Set0"
        Me.BT_Set0.Size = New System.Drawing.Size(200, 23)
        Me.BT_Set0.TabIndex = 46
        Me.BT_Set0.Text = "Set Origin"
        Me.BT_Set0.UseVisualStyleBackColor = True
        '
        'BT_WriteFile
        '
        Me.BT_WriteFile.Location = New System.Drawing.Point(3, 136)
        Me.BT_WriteFile.Name = "BT_WriteFile"
        Me.BT_WriteFile.Size = New System.Drawing.Size(200, 23)
        Me.BT_WriteFile.TabIndex = 45
        Me.BT_WriteFile.Text = "Write Jobfile"
        Me.BT_WriteFile.UseVisualStyleBackColor = True
        '
        'GBTools
        '
        Me.GBTools.Location = New System.Drawing.Point(3, 89)
        Me.GBTools.Name = "GBTools"
        Me.GBTools.Size = New System.Drawing.Size(203, 250)
        Me.GBTools.TabIndex = 31
        Me.GBTools.TabStop = False
        Me.GBTools.Text = "Tools"
        '
        'CB_Material
        '
        Me.CB_Material.DropDownHeight = 500
        Me.CB_Material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Material.DropDownWidth = 250
        Me.CB_Material.FormattingEnabled = True
        Me.CB_Material.IntegralHeight = False
        Me.CB_Material.Location = New System.Drawing.Point(50, 62)
        Me.CB_Material.Name = "CB_Material"
        Me.CB_Material.Size = New System.Drawing.Size(156, 21)
        Me.CB_Material.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Material"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CB_DeviceChoose
        '
        Me.CB_DeviceChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_DeviceChoose.FormattingEnabled = True
        Me.CB_DeviceChoose.Location = New System.Drawing.Point(50, 35)
        Me.CB_DeviceChoose.Name = "CB_DeviceChoose"
        Me.CB_DeviceChoose.Size = New System.Drawing.Size(156, 21)
        Me.CB_DeviceChoose.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Device"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TP_Layers
        '
        Me.TP_Layers.Controls.Add(Me.SplitContainer1)
        Me.TP_Layers.Location = New System.Drawing.Point(4, 22)
        Me.TP_Layers.Name = "TP_Layers"
        Me.TP_Layers.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Layers.Size = New System.Drawing.Size(212, 736)
        Me.TP_Layers.TabIndex = 1
        Me.TP_Layers.Text = "Layers"
        Me.TP_Layers.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_ShowVisibleLayers)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DGV_LayerGrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(206, 730)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 7
        '
        'CB_ShowVisibleLayers
        '
        Me.CB_ShowVisibleLayers.AutoSize = True
        Me.CB_ShowVisibleLayers.Checked = True
        Me.CB_ShowVisibleLayers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_ShowVisibleLayers.Location = New System.Drawing.Point(3, 3)
        Me.CB_ShowVisibleLayers.Name = "CB_ShowVisibleLayers"
        Me.CB_ShowVisibleLayers.Size = New System.Drawing.Size(135, 17)
        Me.CB_ShowVisibleLayers.TabIndex = 5
        Me.CB_ShowVisibleLayers.Text = "show only visible layers"
        Me.CB_ShowVisibleLayers.UseVisualStyleBackColor = True
        '
        'DGV_LayerGrid
        '
        Me.DGV_LayerGrid.AllowUserToAddRows = False
        Me.DGV_LayerGrid.AllowUserToDeleteRows = False
        Me.DGV_LayerGrid.AllowUserToResizeRows = False
        Me.DGV_LayerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_LayerGrid.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGV_LayerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGV_LayerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_LayerGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Layer, Me.Tool})
        Me.DGV_LayerGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_LayerGrid.GridColor = System.Drawing.SystemColors.Menu
        Me.DGV_LayerGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGV_LayerGrid.Margin = New System.Windows.Forms.Padding(0)
        Me.DGV_LayerGrid.Name = "DGV_LayerGrid"
        Me.DGV_LayerGrid.RowHeadersVisible = False
        Me.DGV_LayerGrid.RowTemplate.Height = 20
        Me.DGV_LayerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_LayerGrid.Size = New System.Drawing.Size(206, 704)
        Me.DGV_LayerGrid.TabIndex = 0
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
        'TabTerminal
        '
        Me.TabTerminal.Controls.Add(Me.GB_Terminal_Recieved)
        Me.TabTerminal.Controls.Add(Me.GB_TerminalSend)
        Me.TabTerminal.Location = New System.Drawing.Point(4, 22)
        Me.TabTerminal.Name = "TabTerminal"
        Me.TabTerminal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTerminal.Size = New System.Drawing.Size(212, 736)
        Me.TabTerminal.TabIndex = 8
        Me.TabTerminal.Text = "Terminal"
        Me.TabTerminal.UseVisualStyleBackColor = True
        '
        'GB_Terminal_Recieved
        '
        Me.GB_Terminal_Recieved.Controls.Add(Me.BT_CLSRec)
        Me.GB_Terminal_Recieved.Controls.Add(Me.LB_TerminalRec)
        Me.GB_Terminal_Recieved.Location = New System.Drawing.Point(6, 257)
        Me.GB_Terminal_Recieved.Name = "GB_Terminal_Recieved"
        Me.GB_Terminal_Recieved.Size = New System.Drawing.Size(200, 362)
        Me.GB_Terminal_Recieved.TabIndex = 5
        Me.GB_Terminal_Recieved.TabStop = False
        Me.GB_Terminal_Recieved.Text = "Recieved Data"
        '
        'BT_CLSRec
        '
        Me.BT_CLSRec.Location = New System.Drawing.Point(122, 14)
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
        Me.LB_TerminalRec.Size = New System.Drawing.Size(194, 316)
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
        Me.GB_TerminalSend.Size = New System.Drawing.Size(200, 245)
        Me.GB_TerminalSend.TabIndex = 4
        Me.GB_TerminalSend.TabStop = False
        Me.GB_TerminalSend.Text = "Send Data"
        '
        'BT_Write2Log
        '
        Me.BT_Write2Log.Location = New System.Drawing.Point(72, 216)
        Me.BT_Write2Log.Name = "BT_Write2Log"
        Me.BT_Write2Log.Size = New System.Drawing.Size(65, 23)
        Me.BT_Write2Log.TabIndex = 6
        Me.BT_Write2Log.Text = "Write2Log"
        Me.BT_Write2Log.UseVisualStyleBackColor = True
        '
        'BT_FrontEnd
        '
        Me.BT_FrontEnd.Location = New System.Drawing.Point(6, 216)
        Me.BT_FrontEnd.Name = "BT_FrontEnd"
        Me.BT_FrontEnd.Size = New System.Drawing.Size(60, 23)
        Me.BT_FrontEnd.TabIndex = 5
        Me.BT_FrontEnd.Text = "FrontEnd"
        Me.BT_FrontEnd.UseVisualStyleBackColor = True
        '
        'BT_TerminalSend
        '
        Me.BT_TerminalSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_TerminalSend.Location = New System.Drawing.Point(143, 216)
        Me.BT_TerminalSend.Name = "BT_TerminalSend"
        Me.BT_TerminalSend.Size = New System.Drawing.Size(51, 23)
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
        Me.TB_TerminalSend.Size = New System.Drawing.Size(188, 191)
        Me.TB_TerminalSend.TabIndex = 1
        '
        'PluginControls3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "PluginControls3"
        Me.Size = New System.Drawing.Size(220, 762)
        Me.TabControl1.ResumeLayout(False)
        Me.TP_Machine.ResumeLayout(False)
        Me.P_Bottom.ResumeLayout(False)
        Me.P_Bottom.PerformLayout()
        Me.TP_Layers.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGV_LayerGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabTerminal.ResumeLayout(False)
        Me.GB_Terminal_Recieved.ResumeLayout(False)
        Me.GB_TerminalSend.ResumeLayout(False)
        Me.GB_TerminalSend.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TP_Machine As System.Windows.Forms.TabPage
    Friend WithEvents TP_Layers As System.Windows.Forms.TabPage
    Protected WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Protected WithEvents CB_ShowVisibleLayers As System.Windows.Forms.CheckBox
    Protected WithEvents DGV_LayerGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Layer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tool As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents GBTools As System.Windows.Forms.GroupBox
    Protected WithEvents CB_PathOpt As System.Windows.Forms.CheckBox
    Protected Friend WithEvents CB_DeviceChoose As System.Windows.Forms.ComboBox
    Protected Friend WithEvents CB_Material As System.Windows.Forms.ComboBox
    Protected WithEvents BT_Set0 As System.Windows.Forms.Button
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents PB_FileUpload As System.Windows.Forms.ProgressBar
    Protected WithEvents PB_JobProcess As System.Windows.Forms.ProgressBar
    Protected WithEvents Lbl_Info As System.Windows.Forms.Label
    Protected Friend WithEvents P_Bottom As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents CB_Preview As System.Windows.Forms.CheckBox
    Protected WithEvents TabTerminal As System.Windows.Forms.TabPage
    Protected WithEvents GB_Terminal_Recieved As System.Windows.Forms.GroupBox
    Protected WithEvents BT_CLSRec As System.Windows.Forms.Button
    Protected WithEvents LB_TerminalRec As System.Windows.Forms.ListBox
    Protected WithEvents GB_TerminalSend As System.Windows.Forms.GroupBox
    Protected WithEvents BT_Write2Log As System.Windows.Forms.Button
    Protected WithEvents BT_FrontEnd As System.Windows.Forms.Button
    Protected WithEvents BT_TerminalSend As System.Windows.Forms.Button
    Protected WithEvents TB_TerminalSend As System.Windows.Forms.TextBox
    Protected Friend WithEvents CB_BBox As System.Windows.Forms.CheckBox
    Protected Friend WithEvents BT_StartDirect As System.Windows.Forms.Button
    Protected Friend WithEvents BT_WriteFile As System.Windows.Forms.Button
    Protected Friend WithEvents TabControl1 As System.Windows.Forms.TabControl

End Class
