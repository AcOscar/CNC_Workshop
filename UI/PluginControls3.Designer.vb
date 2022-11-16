<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PluginControls3
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GB_JobProcess = New System.Windows.Forms.GroupBox()
        Me.BT_StopTransmit = New System.Windows.Forms.Button()
        Me.Lbl_Info = New System.Windows.Forms.Label()
        Me.PB_FileUpload = New System.Windows.Forms.ProgressBar()
        Me.PB_JobProcess = New System.Windows.Forms.ProgressBar()
        Me.TP_Layers = New System.Windows.Forms.TabPage()
        Me.SplitContainer_Layers = New System.Windows.Forms.SplitContainer()
        Me.CB_CutByLayerOrder = New System.Windows.Forms.CheckBox()
        Me.CB_ShowVisibleLayers = New System.Windows.Forms.CheckBox()
        Me.DGV_LayerGrid = New System.Windows.Forms.DataGridView()
        Me.Layer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tool = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Sortorder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LayerIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TP_Cutter = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.P_Bottom = New System.Windows.Forms.Panel()
        Me.CB_ShowCutter = New System.Windows.Forms.CheckBox()
        Me.CB_Preview = New System.Windows.Forms.CheckBox()
        Me.BT_Set0 = New System.Windows.Forms.Button()
        Me.BT_MoveJob = New System.Windows.Forms.Button()
        Me.BT_StartDirect = New System.Windows.Forms.Button()
        Me.P_Top = New System.Windows.Forms.Panel()
        Me.Label_Device = New System.Windows.Forms.Label()
        Me.CB_DeviceChoose = New System.Windows.Forms.ComboBox()
        Me.Label_Material = New System.Windows.Forms.Label()
        Me.CB_Material = New System.Windows.Forms.ComboBox()
        Me.GBTools = New System.Windows.Forms.GroupBox()
        Me.FLP_Tools = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabControl_CNCWrkshp = New System.Windows.Forms.TabControl()
        Me.GB_JobProcess.SuspendLayout()
        Me.TP_Layers.SuspendLayout()
        CType(Me.SplitContainer_Layers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Layers.Panel1.SuspendLayout()
        Me.SplitContainer_Layers.Panel2.SuspendLayout()
        Me.SplitContainer_Layers.SuspendLayout()
        CType(Me.DGV_LayerGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP_Cutter.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.P_Bottom.SuspendLayout()
        Me.P_Top.SuspendLayout()
        Me.GBTools.SuspendLayout()
        Me.TabControl_CNCWrkshp.SuspendLayout()
        Me.SuspendLayout()
        '
        'GB_JobProcess
        '
        Me.GB_JobProcess.Controls.Add(Me.BT_StopTransmit)
        Me.GB_JobProcess.Controls.Add(Me.Lbl_Info)
        Me.GB_JobProcess.Controls.Add(Me.PB_FileUpload)
        Me.GB_JobProcess.Controls.Add(Me.PB_JobProcess)
        Me.GB_JobProcess.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GB_JobProcess.Location = New System.Drawing.Point(0, 1562)
        Me.GB_JobProcess.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GB_JobProcess.Name = "GB_JobProcess"
        Me.GB_JobProcess.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GB_JobProcess.Size = New System.Drawing.Size(1269, 265)
        Me.GB_JobProcess.TabIndex = 55
        Me.GB_JobProcess.TabStop = False
        Me.GB_JobProcess.Text = "Job Process"
        '
        'BT_StopTransmit
        '
        Me.BT_StopTransmit.Location = New System.Drawing.Point(16, 69)
        Me.BT_StopTransmit.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.BT_StopTransmit.Name = "BT_StopTransmit"
        Me.BT_StopTransmit.Size = New System.Drawing.Size(549, 55)
        Me.BT_StopTransmit.TabIndex = 54
        Me.BT_StopTransmit.Text = "Stop Transmitting"
        Me.BT_StopTransmit.UseVisualStyleBackColor = True
        Me.BT_StopTransmit.Visible = False
        '
        'Lbl_Info
        '
        Me.Lbl_Info.AccessibleName = ""
        Me.Lbl_Info.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Info.Location = New System.Drawing.Point(11, 134)
        Me.Lbl_Info.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Lbl_Info.Name = "Lbl_Info"
        Me.Lbl_Info.Size = New System.Drawing.Size(1248, 114)
        Me.Lbl_Info.TabIndex = 50
        Me.Lbl_Info.Text = "Please restart Rhino " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to work with " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "this plugin"
        '
        'PB_FileUpload
        '
        Me.PB_FileUpload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB_FileUpload.Location = New System.Drawing.Point(19, 45)
        Me.PB_FileUpload.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.PB_FileUpload.Maximum = 15
        Me.PB_FileUpload.Name = "PB_FileUpload"
        Me.PB_FileUpload.Size = New System.Drawing.Size(1227, 24)
        Me.PB_FileUpload.Step = 1
        Me.PB_FileUpload.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_FileUpload.TabIndex = 47
        '
        'PB_JobProcess
        '
        Me.PB_JobProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB_JobProcess.Location = New System.Drawing.Point(19, 67)
        Me.PB_JobProcess.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.PB_JobProcess.Maximum = 14
        Me.PB_JobProcess.Name = "PB_JobProcess"
        Me.PB_JobProcess.Size = New System.Drawing.Size(1227, 57)
        Me.PB_JobProcess.Step = 1
        Me.PB_JobProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB_JobProcess.TabIndex = 48
        '
        'TP_Layers
        '
        Me.TP_Layers.Controls.Add(Me.SplitContainer_Layers)
        Me.TP_Layers.Location = New System.Drawing.Point(10, 48)
        Me.TP_Layers.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TP_Layers.Name = "TP_Layers"
        Me.TP_Layers.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TP_Layers.Size = New System.Drawing.Size(1249, 1497)
        Me.TP_Layers.TabIndex = 1
        Me.TP_Layers.Text = "Layers"
        Me.TP_Layers.UseVisualStyleBackColor = True
        '
        'SplitContainer_Layers
        '
        Me.SplitContainer_Layers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Layers.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer_Layers.IsSplitterFixed = True
        Me.SplitContainer_Layers.Location = New System.Drawing.Point(8, 7)
        Me.SplitContainer_Layers.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.SplitContainer_Layers.Name = "SplitContainer_Layers"
        Me.SplitContainer_Layers.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_Layers.Panel1
        '
        Me.SplitContainer_Layers.Panel1.AutoScroll = True
        Me.SplitContainer_Layers.Panel1.AutoScrollMinSize = New System.Drawing.Size(0, 50)
        Me.SplitContainer_Layers.Panel1.Controls.Add(Me.CB_CutByLayerOrder)
        Me.SplitContainer_Layers.Panel1.Controls.Add(Me.CB_ShowVisibleLayers)
        Me.SplitContainer_Layers.Panel1MinSize = 50
        '
        'SplitContainer_Layers.Panel2
        '
        Me.SplitContainer_Layers.Panel2.Controls.Add(Me.DGV_LayerGrid)
        Me.SplitContainer_Layers.Size = New System.Drawing.Size(1233, 1483)
        Me.SplitContainer_Layers.SplitterWidth = 2
        Me.SplitContainer_Layers.TabIndex = 7
        '
        'CB_CutByLayerOrder
        '
        Me.CB_CutByLayerOrder.AutoSize = True
        Me.CB_CutByLayerOrder.Location = New System.Drawing.Point(277, 7)
        Me.CB_CutByLayerOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.CB_CutByLayerOrder.Name = "CB_CutByLayerOrder"
        Me.CB_CutByLayerOrder.Size = New System.Drawing.Size(254, 36)
        Me.CB_CutByLayerOrder.TabIndex = 6
        Me.CB_CutByLayerOrder.Text = "Cut Layer Order"
        Me.CB_CutByLayerOrder.UseVisualStyleBackColor = True
        '
        'CB_ShowVisibleLayers
        '
        Me.CB_ShowVisibleLayers.AutoSize = True
        Me.CB_ShowVisibleLayers.Checked = True
        Me.CB_ShowVisibleLayers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_ShowVisibleLayers.Location = New System.Drawing.Point(8, 7)
        Me.CB_ShowVisibleLayers.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.CB_ShowVisibleLayers.Name = "CB_ShowVisibleLayers"
        Me.CB_ShowVisibleLayers.Size = New System.Drawing.Size(254, 36)
        Me.CB_ShowVisibleLayers.TabIndex = 5
        Me.CB_ShowVisibleLayers.Text = "Filter On Layers"
        Me.CB_ShowVisibleLayers.UseVisualStyleBackColor = True
        '
        'DGV_LayerGrid
        '
        Me.DGV_LayerGrid.AllowUserToAddRows = False
        Me.DGV_LayerGrid.AllowUserToDeleteRows = False
        Me.DGV_LayerGrid.AllowUserToResizeRows = False
        Me.DGV_LayerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_LayerGrid.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGV_LayerGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV_LayerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DGV_LayerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_LayerGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Layer, Me.Tool, Me.Sortorder, Me.LayerIndex})
        Me.DGV_LayerGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_LayerGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGV_LayerGrid.GridColor = System.Drawing.SystemColors.Menu
        Me.DGV_LayerGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGV_LayerGrid.Margin = New System.Windows.Forms.Padding(0)
        Me.DGV_LayerGrid.Name = "DGV_LayerGrid"
        Me.DGV_LayerGrid.RowHeadersVisible = False
        Me.DGV_LayerGrid.RowHeadersWidth = 102
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV_LayerGrid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_LayerGrid.RowTemplate.Height = 80
        Me.DGV_LayerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGV_LayerGrid.Size = New System.Drawing.Size(1233, 1431)
        Me.DGV_LayerGrid.TabIndex = 0
        '
        'Layer
        '
        Me.Layer.FillWeight = 200.0!
        Me.Layer.HeaderText = "Layer"
        Me.Layer.MinimumWidth = 12
        Me.Layer.Name = "Layer"
        Me.Layer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Layer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Tool
        '
        Me.Tool.FillWeight = 150.0!
        Me.Tool.HeaderText = "Tool"
        Me.Tool.Items.AddRange(New Object() {"-"})
        Me.Tool.MinimumWidth = 12
        Me.Tool.Name = "Tool"
        Me.Tool.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Sortorder
        '
        Me.Sortorder.HeaderText = "Sortorder"
        Me.Sortorder.MinimumWidth = 12
        Me.Sortorder.Name = "Sortorder"
        Me.Sortorder.Visible = False
        '
        'LayerIndex
        '
        Me.LayerIndex.HeaderText = "LayerIndex"
        Me.LayerIndex.MinimumWidth = 12
        Me.LayerIndex.Name = "LayerIndex"
        Me.LayerIndex.Visible = False
        '
        'TP_Cutter
        '
        Me.TP_Cutter.Controls.Add(Me.TableLayoutPanel1)
        Me.TP_Cutter.Location = New System.Drawing.Point(10, 48)
        Me.TP_Cutter.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TP_Cutter.Name = "TP_Cutter"
        Me.TP_Cutter.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TP_Cutter.Size = New System.Drawing.Size(1249, 1497)
        Me.TP_Cutter.TabIndex = 0
        Me.TP_Cutter.Text = "Cutter"
        Me.TP_Cutter.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.P_Bottom, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.P_Top, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GBTools, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 7)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1233, 1483)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'P_Bottom
        '
        Me.P_Bottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P_Bottom.Controls.Add(Me.CB_ShowCutter)
        Me.P_Bottom.Controls.Add(Me.CB_Preview)
        Me.P_Bottom.Controls.Add(Me.BT_Set0)
        Me.P_Bottom.Controls.Add(Me.BT_MoveJob)
        Me.P_Bottom.Controls.Add(Me.BT_StartDirect)
        Me.P_Bottom.Location = New System.Drawing.Point(8, 1299)
        Me.P_Bottom.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.P_Bottom.Name = "P_Bottom"
        Me.P_Bottom.Size = New System.Drawing.Size(1217, 177)
        Me.P_Bottom.TabIndex = 3
        '
        'CB_ShowCutter
        '
        Me.CB_ShowCutter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_ShowCutter.Appearance = System.Windows.Forms.Appearance.Button
        Me.CB_ShowCutter.Location = New System.Drawing.Point(11, 14)
        Me.CB_ShowCutter.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.CB_ShowCutter.Name = "CB_ShowCutter"
        Me.CB_ShowCutter.Size = New System.Drawing.Size(1201, 55)
        Me.CB_ShowCutter.TabIndex = 53
        Me.CB_ShowCutter.Text = "Show Cutter"
        Me.CB_ShowCutter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_ShowCutter.UseVisualStyleBackColor = False
        '
        'CB_Preview
        '
        Me.CB_Preview.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_Preview.Appearance = System.Windows.Forms.Appearance.Button
        Me.CB_Preview.Location = New System.Drawing.Point(11, 81)
        Me.CB_Preview.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.CB_Preview.Name = "CB_Preview"
        Me.CB_Preview.Size = New System.Drawing.Size(1201, 55)
        Me.CB_Preview.TabIndex = 0
        Me.CB_Preview.Text = "Preview Job"
        Me.CB_Preview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_Preview.UseVisualStyleBackColor = False
        '
        'BT_Set0
        '
        Me.BT_Set0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Set0.Location = New System.Drawing.Point(11, 148)
        Me.BT_Set0.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.BT_Set0.Name = "BT_Set0"
        Me.BT_Set0.Size = New System.Drawing.Size(1201, 55)
        Me.BT_Set0.TabIndex = 1
        Me.BT_Set0.Text = "Move Cutter"
        Me.BT_Set0.UseVisualStyleBackColor = True
        '
        'BT_MoveJob
        '
        Me.BT_MoveJob.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_MoveJob.Location = New System.Drawing.Point(11, 148)
        Me.BT_MoveJob.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.BT_MoveJob.Name = "BT_MoveJob"
        Me.BT_MoveJob.Size = New System.Drawing.Size(1201, 55)
        Me.BT_MoveJob.TabIndex = 54
        Me.BT_MoveJob.Text = "Move Job"
        Me.BT_MoveJob.UseVisualStyleBackColor = True
        '
        'BT_StartDirect
        '
        Me.BT_StartDirect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_StartDirect.Location = New System.Drawing.Point(11, 215)
        Me.BT_StartDirect.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.BT_StartDirect.Name = "BT_StartDirect"
        Me.BT_StartDirect.Size = New System.Drawing.Size(1201, 55)
        Me.BT_StartDirect.TabIndex = 2
        Me.BT_StartDirect.Text = "Cut"
        Me.BT_StartDirect.UseVisualStyleBackColor = True
        '
        'P_Top
        '
        Me.P_Top.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P_Top.Controls.Add(Me.Label_Device)
        Me.P_Top.Controls.Add(Me.CB_DeviceChoose)
        Me.P_Top.Controls.Add(Me.Label_Material)
        Me.P_Top.Controls.Add(Me.CB_Material)
        Me.P_Top.Location = New System.Drawing.Point(8, 7)
        Me.P_Top.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.P_Top.Name = "P_Top"
        Me.P_Top.Size = New System.Drawing.Size(1217, 136)
        Me.P_Top.TabIndex = 54
        '
        'Label_Device
        '
        Me.Label_Device.Location = New System.Drawing.Point(29, 10)
        Me.Label_Device.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label_Device.Name = "Label_Device"
        Me.Label_Device.Size = New System.Drawing.Size(125, 50)
        Me.Label_Device.TabIndex = 0
        Me.Label_Device.Text = "Device"
        Me.Label_Device.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CB_DeviceChoose
        '
        Me.CB_DeviceChoose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_DeviceChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_DeviceChoose.FormattingEnabled = True
        Me.CB_DeviceChoose.Location = New System.Drawing.Point(171, 12)
        Me.CB_DeviceChoose.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.CB_DeviceChoose.Name = "CB_DeviceChoose"
        Me.CB_DeviceChoose.Size = New System.Drawing.Size(1034, 39)
        Me.CB_DeviceChoose.TabIndex = 1
        '
        'Label_Material
        '
        Me.Label_Material.Location = New System.Drawing.Point(29, 74)
        Me.Label_Material.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label_Material.Name = "Label_Material"
        Me.Label_Material.Size = New System.Drawing.Size(125, 50)
        Me.Label_Material.TabIndex = 2
        Me.Label_Material.Text = "Material"
        Me.Label_Material.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CB_Material
        '
        Me.CB_Material.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_Material.DropDownHeight = 500
        Me.CB_Material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Material.DropDownWidth = 180
        Me.CB_Material.FormattingEnabled = True
        Me.CB_Material.IntegralHeight = False
        Me.CB_Material.Location = New System.Drawing.Point(171, 76)
        Me.CB_Material.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.CB_Material.Name = "CB_Material"
        Me.CB_Material.Size = New System.Drawing.Size(1034, 39)
        Me.CB_Material.TabIndex = 2
        '
        'GBTools
        '
        Me.GBTools.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBTools.Controls.Add(Me.FLP_Tools)
        Me.GBTools.Location = New System.Drawing.Point(8, 471)
        Me.GBTools.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GBTools.Name = "GBTools"
        Me.GBTools.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GBTools.Size = New System.Drawing.Size(1217, 500)
        Me.GBTools.TabIndex = 31
        Me.GBTools.TabStop = False
        Me.GBTools.Text = "Tools"
        '
        'FLP_Tools
        '
        Me.FLP_Tools.AutoScroll = True
        Me.FLP_Tools.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FLP_Tools.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FLP_Tools.Location = New System.Drawing.Point(8, 38)
        Me.FLP_Tools.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.FLP_Tools.Name = "FLP_Tools"
        Me.FLP_Tools.Size = New System.Drawing.Size(1201, 455)
        Me.FLP_Tools.TabIndex = 0
        Me.FLP_Tools.WrapContents = False
        '
        'TabControl_CNCWrkshp
        '
        Me.TabControl_CNCWrkshp.Controls.Add(Me.TP_Cutter)
        Me.TabControl_CNCWrkshp.Controls.Add(Me.TP_Layers)
        Me.TabControl_CNCWrkshp.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl_CNCWrkshp.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_CNCWrkshp.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TabControl_CNCWrkshp.Name = "TabControl_CNCWrkshp"
        Me.TabControl_CNCWrkshp.SelectedIndex = 0
        Me.TabControl_CNCWrkshp.Size = New System.Drawing.Size(1269, 1555)
        Me.TabControl_CNCWrkshp.TabIndex = 0
        '
        'PluginControls3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GB_JobProcess)
        Me.Controls.Add(Me.TabControl_CNCWrkshp)
        Me.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.MinimumSize = New System.Drawing.Size(533, 477)
        Me.Name = "PluginControls3"
        Me.Size = New System.Drawing.Size(1269, 1827)
        Me.GB_JobProcess.ResumeLayout(False)
        Me.TP_Layers.ResumeLayout(False)
        Me.SplitContainer_Layers.Panel1.ResumeLayout(False)
        Me.SplitContainer_Layers.Panel1.PerformLayout()
        Me.SplitContainer_Layers.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Layers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Layers.ResumeLayout(False)
        CType(Me.DGV_LayerGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP_Cutter.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.P_Bottom.ResumeLayout(False)
        Me.P_Top.ResumeLayout(False)
        Me.GBTools.ResumeLayout(False)
        Me.TabControl_CNCWrkshp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GB_JobProcess As System.Windows.Forms.GroupBox
    Public WithEvents BT_StopTransmit As System.Windows.Forms.Button
    Public WithEvents Lbl_Info As System.Windows.Forms.Label
    Public WithEvents PB_FileUpload As System.Windows.Forms.ProgressBar
    Public WithEvents PB_JobProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents TP_Layers As System.Windows.Forms.TabPage
    Protected WithEvents SplitContainer_Layers As System.Windows.Forms.SplitContainer
    Public WithEvents CB_CutByLayerOrder As System.Windows.Forms.CheckBox
    Public WithEvents CB_ShowVisibleLayers As System.Windows.Forms.CheckBox
    Public WithEvents DGV_LayerGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Layer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tool As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Sortorder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LayerIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TP_Cutter As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Protected Friend WithEvents P_Bottom As System.Windows.Forms.Panel
    Public WithEvents CB_ShowCutter As System.Windows.Forms.CheckBox
    Public WithEvents CB_Preview As System.Windows.Forms.CheckBox
    Public WithEvents BT_Set0 As System.Windows.Forms.Button
    Public WithEvents BT_MoveJob As System.Windows.Forms.Button
    Public WithEvents BT_StartDirect As System.Windows.Forms.Button
    Public WithEvents P_Top As System.Windows.Forms.Panel
    Public WithEvents Label_Device As System.Windows.Forms.Label
    Public WithEvents CB_DeviceChoose As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Material As System.Windows.Forms.Label
    Public WithEvents CB_Material As System.Windows.Forms.ComboBox
    Public WithEvents GBTools As System.Windows.Forms.GroupBox
    Public WithEvents FLP_Tools As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents TabControl_CNCWrkshp As System.Windows.Forms.TabControl
End Class
