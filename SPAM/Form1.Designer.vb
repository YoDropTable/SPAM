<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.TableLayoutPanelMain = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.instructionPanal = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.memoryPanal = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.diskPanal = New System.Windows.Forms.FlowLayoutPanel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pagesControl = New System.Windows.Forms.NumericUpDown()
        Me.sizeControl = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanelMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pagesControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sizeControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanelMain
        '
        Me.TableLayoutPanelMain.ColumnCount = 3
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelMain.Controls.Add(Me.TextBox1, 0, 3)
        Me.TableLayoutPanelMain.Controls.Add(Me.GroupBox1, 0, 2)
        Me.TableLayoutPanelMain.Controls.Add(Me.GroupBox2, 1, 2)
        Me.TableLayoutPanelMain.Controls.Add(Me.GroupBox3, 2, 2)
        Me.TableLayoutPanelMain.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanelMain.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelMain.Name = "TableLayoutPanelMain"
        Me.TableLayoutPanelMain.RowCount = 4
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelMain.Size = New System.Drawing.Size(955, 541)
        Me.TableLayoutPanelMain.TabIndex = 0
        '
        'TextBox1
        '
        Me.TableLayoutPanelMain.SetColumnSpan(Me.TextBox1, 4)
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(3, 429)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(949, 109)
        Me.TextBox1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 85)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 338)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Read"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.instructionPanal, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(306, 319)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'instructionPanal
        '
        Me.instructionPanal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.instructionPanal.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.instructionPanal.Location = New System.Drawing.Point(3, 3)
        Me.instructionPanal.Name = "instructionPanal"
        Me.instructionPanal.Size = New System.Drawing.Size(300, 283)
        Me.instructionPanal.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 292)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 24)
        Me.Panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(222, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Next"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.memoryPanal)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(321, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 338)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Physical Memory"
        '
        'memoryPanal
        '
        Me.memoryPanal.AutoScroll = True
        Me.memoryPanal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.memoryPanal.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.memoryPanal.Location = New System.Drawing.Point(3, 16)
        Me.memoryPanal.Name = "memoryPanal"
        Me.memoryPanal.Size = New System.Drawing.Size(306, 319)
        Me.memoryPanal.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.diskPanal)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(639, 85)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(313, 338)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Disk Space"
        '
        'diskPanal
        '
        Me.diskPanal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.diskPanal.Location = New System.Drawing.Point(3, 16)
        Me.diskPanal.Name = "diskPanal"
        Me.diskPanal.Size = New System.Drawing.Size(307, 319)
        Me.diskPanal.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.TableLayoutPanelMain.SetColumnSpan(Me.MenuStrip1, 3)
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(955, 32)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 28)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenFileToolStripMenuItem
        '
        Me.OpenFileToolStripMenuItem.Image = Global.SPAM.My.Resources.Resources.icons8_open_32
        Me.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem"
        Me.OpenFileToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.OpenFileToolStripMenuItem.Text = "Open File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Panel2
        '
        Me.TableLayoutPanelMain.SetColumnSpan(Me.Panel2, 3)
        Me.Panel2.Controls.Add(Me.pagesControl)
        Me.Panel2.Controls.Add(Me.sizeControl)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 35)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(949, 44)
        Me.Panel2.TabIndex = 5
        '
        'pagesControl
        '
        Me.pagesControl.Location = New System.Drawing.Point(270, 12)
        Me.pagesControl.Name = "pagesControl"
        Me.pagesControl.Size = New System.Drawing.Size(120, 20)
        Me.pagesControl.TabIndex = 5
        Me.pagesControl.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'sizeControl
        '
        Me.sizeControl.Location = New System.Drawing.Point(71, 12)
        Me.sizeControl.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.sizeControl.Name = "sizeControl"
        Me.sizeControl.Size = New System.Drawing.Size(70, 20)
        Me.sizeControl.TabIndex = 4
        Me.sizeControl.Value = New Decimal(New Integer() {512, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pages in Memory"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Block Size"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 541)
        Me.Controls.Add(Me.TableLayoutPanelMain)
        Me.Name = "Form1"
        Me.Text = "SPAM: Simulated Page Allocation Manager"
        Me.TableLayoutPanelMain.ResumeLayout(False)
        Me.TableLayoutPanelMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pagesControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sizeControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanelMain As TableLayoutPanel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents instructionPanal As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents memoryPanal As FlowLayoutPanel
    Friend WithEvents OpenFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pagesControl As NumericUpDown
    Friend WithEvents sizeControl As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents diskPanal As FlowLayoutPanel
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
End Class
