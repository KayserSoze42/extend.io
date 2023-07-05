<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.okSearchButton = New System.Windows.Forms.Button()
        Me.infoLabel = New System.Windows.Forms.Label()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenNewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetFieldsCTRLRDelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewElementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveElements = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveAllElementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.NewButton = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'okSearchButton
        '
        Me.okSearchButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.okSearchButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.okSearchButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.okSearchButton.Location = New System.Drawing.Point(449, 124)
        Me.okSearchButton.Name = "okSearchButton"
        Me.okSearchButton.Size = New System.Drawing.Size(145, 32)
        Me.okSearchButton.TabIndex = 0
        Me.okSearchButton.Text = "OK"
        Me.okSearchButton.UseVisualStyleBackColor = False
        '
        'infoLabel
        '
        Me.infoLabel.AutoSize = True
        Me.infoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoLabel.Location = New System.Drawing.Point(146, 45)
        Me.infoLabel.Name = "infoLabel"
        Me.infoLabel.Size = New System.Drawing.Size(313, 50)
        Me.infoLabel.TabIndex = 1
        Me.infoLabel.Text = "Error reading the text file" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Open a file or a create new one"
        Me.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenButton
        '
        Me.OpenButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.OpenButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.OpenButton.Location = New System.Drawing.Point(22, 124)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(145, 32)
        Me.OpenButton.TabIndex = 2
        Me.OpenButton.Text = "OPEN FILE"
        Me.OpenButton.UseVisualStyleBackColor = False
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.PowderBlue
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(610, 28)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenNewFileToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ExitToolStripMenuItem1, Me.ExitToolStripMenuItem2})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenNewFileToolStripMenuItem
        '
        Me.OpenNewFileToolStripMenuItem.Name = "OpenNewFileToolStripMenuItem"
        Me.OpenNewFileToolStripMenuItem.Size = New System.Drawing.Size(202, 26)
        Me.OpenNewFileToolStripMenuItem.Text = "Create New File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(202, 26)
        Me.ExitToolStripMenuItem.Text = "Open New File"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(202, 26)
        Me.ExitToolStripMenuItem1.Text = "Set Browser Path"
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(202, 26)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchenterToolStripMenuItem, Me.ResetFieldsCTRLRDelToolStripMenuItem, Me.AddNewElementToolStripMenuItem, Me.RemoveElements})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(49, 24)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SearchenterToolStripMenuItem
        '
        Me.SearchenterToolStripMenuItem.Name = "SearchenterToolStripMenuItem"
        Me.SearchenterToolStripMenuItem.Size = New System.Drawing.Size(286, 26)
        Me.SearchenterToolStripMenuItem.Text = "Search ( Enter )"
        '
        'ResetFieldsCTRLRDelToolStripMenuItem
        '
        Me.ResetFieldsCTRLRDelToolStripMenuItem.Name = "ResetFieldsCTRLRDelToolStripMenuItem"
        Me.ResetFieldsCTRLRDelToolStripMenuItem.Size = New System.Drawing.Size(286, 26)
        Me.ResetFieldsCTRLRDelToolStripMenuItem.Text = "Reset Fields ( Ctrl + R / del )"
        '
        'AddNewElementToolStripMenuItem
        '
        Me.AddNewElementToolStripMenuItem.Name = "AddNewElementToolStripMenuItem"
        Me.AddNewElementToolStripMenuItem.Size = New System.Drawing.Size(286, 26)
        Me.AddNewElementToolStripMenuItem.Text = "Add New Element ( Ctrl + N )"
        '
        'RemoveElements
        '
        Me.RemoveElements.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveAllElementsToolStripMenuItem})
        Me.RemoveElements.Name = "RemoveElements"
        Me.RemoveElements.Size = New System.Drawing.Size(286, 26)
        Me.RemoveElements.Text = "Remove Elements"
        '
        'RemoveAllElementsToolStripMenuItem
        '
        Me.RemoveAllElementsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveAllElementsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RemoveAllElementsToolStripMenuItem.Name = "RemoveAllElementsToolStripMenuItem"
        Me.RemoveAllElementsToolStripMenuItem.Size = New System.Drawing.Size(233, 26)
        Me.RemoveAllElementsToolStripMenuItem.Text = "Remove All Elements"
        Me.RemoveAllElementsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NewButton
        '
        Me.NewButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.NewButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NewButton.Location = New System.Drawing.Point(234, 124)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(145, 32)
        Me.NewButton.TabIndex = 4
        Me.NewButton.Text = "NEW FILE"
        Me.NewButton.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(610, 180)
        Me.Controls.Add(Me.NewButton)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.infoLabel)
        Me.Controls.Add(Me.okSearchButton)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "SLinky - CLI"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents okSearchButton As Button
    Friend WithEvents infoLabel As Label
    Friend WithEvents OpenButton As Button
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenNewFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents NewButton As Button
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchenterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetFieldsCTRLRDelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddNewElementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveElements As ToolStripMenuItem
    Friend WithEvents RemoveAllElementsToolStripMenuItem As ToolStripMenuItem
End Class
