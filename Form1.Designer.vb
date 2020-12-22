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
		Me.txtFilePath = New System.Windows.Forms.TextBox()
		Me.btnOpenFile = New System.Windows.Forms.Button()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtSQL = New System.Windows.Forms.TextBox()
		Me.btnGo = New System.Windows.Forms.Button()
		Me.lbDepViews = New System.Windows.Forms.ListBox()
		Me.cmViews = New System.Windows.Forms.ListBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.chkFormatSql = New System.Windows.Forms.CheckBox()
		Me.btnSelectAll = New System.Windows.Forms.Button()
		Me.chkReplace = New System.Windows.Forms.CheckBox()
		Me.lbDepTables = New System.Windows.Forms.ListBox()
		Me.btnSaveAll = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
		Me.txtRowLimit = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.chkCTE = New System.Windows.Forms.CheckBox()
		Me.btnBeautify = New System.Windows.Forms.Button()
		Me.btnLoad = New System.Windows.Forms.Button()
		Me.chkCreateProc = New System.Windows.Forms.CheckBox()
		Me.chkDepTables = New System.Windows.Forms.CheckBox()
		Me.lbMacros = New System.Windows.Forms.ListBox()
		Me.btnLoadMacros = New System.Windows.Forms.Button()
		Me.btnMarcoCreate = New System.Windows.Forms.Button()
		Me.chkScriptDepView = New System.Windows.Forms.CheckBox()
		Me.lbProcs = New System.Windows.Forms.ListBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.btnSaveAllMacros = New System.Windows.Forms.Button()
		Me.btnGetProcSQL = New System.Windows.Forms.Button()
		Me.btnSaveAllProcs = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'txtFilePath
		'
		Me.txtFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtFilePath.Location = New System.Drawing.Point(55, 13)
		Me.txtFilePath.Name = "txtFilePath"
		Me.txtFilePath.Size = New System.Drawing.Size(689, 20)
		Me.txtFilePath.TabIndex = 0
		'
		'btnOpenFile
		'
		Me.btnOpenFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnOpenFile.Location = New System.Drawing.Point(892, 13)
		Me.btnOpenFile.Name = "btnOpenFile"
		Me.btnOpenFile.Size = New System.Drawing.Size(36, 23)
		Me.btnOpenFile.TabIndex = 1
		Me.btnOpenFile.Text = "..."
		Me.btnOpenFile.UseVisualStyleBackColor = True
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(2, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(47, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "File path"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(52, 36)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(35, 13)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Views"
		'
		'txtSQL
		'
		Me.txtSQL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtSQL.Location = New System.Drawing.Point(46, 425)
		Me.txtSQL.Multiline = True
		Me.txtSQL.Name = "txtSQL"
		Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtSQL.Size = New System.Drawing.Size(893, 323)
		Me.txtSQL.TabIndex = 5
		'
		'btnGo
		'
		Me.btnGo.Location = New System.Drawing.Point(55, 235)
		Me.btnGo.Name = "btnGo"
		Me.btnGo.Size = New System.Drawing.Size(82, 34)
		Me.btnGo.TabIndex = 6
		Me.btnGo.Text = "Get SQL"
		Me.btnGo.UseVisualStyleBackColor = True
		'
		'lbDepViews
		'
		Me.lbDepViews.FormattingEnabled = True
		Me.lbDepViews.Location = New System.Drawing.Point(46, 337)
		Me.lbDepViews.Name = "lbDepViews"
		Me.lbDepViews.Size = New System.Drawing.Size(299, 82)
		Me.lbDepViews.TabIndex = 7
		'
		'cmViews
		'
		Me.cmViews.FormattingEnabled = True
		Me.cmViews.Location = New System.Drawing.Point(46, 56)
		Me.cmViews.Name = "cmViews"
		Me.cmViews.Size = New System.Drawing.Size(299, 173)
		Me.cmViews.TabIndex = 8
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(43, 317)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(91, 13)
		Me.Label3.TabIndex = 9
		Me.Label3.Text = "Dependent Views"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(12, 428)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(28, 13)
		Me.Label5.TabIndex = 11
		Me.Label5.Text = "SQL"
		'
		'chkFormatSql
		'
		Me.chkFormatSql.AutoSize = True
		Me.chkFormatSql.Checked = True
		Me.chkFormatSql.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkFormatSql.Location = New System.Drawing.Point(55, 284)
		Me.chkFormatSql.Name = "chkFormatSql"
		Me.chkFormatSql.Size = New System.Drawing.Size(82, 17)
		Me.chkFormatSql.TabIndex = 12
		Me.chkFormatSql.Text = "Format SQL"
		Me.chkFormatSql.UseVisualStyleBackColor = True
		'
		'btnSelectAll
		'
		Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSelectAll.Location = New System.Drawing.Point(851, 385)
		Me.btnSelectAll.Name = "btnSelectAll"
		Me.btnSelectAll.Size = New System.Drawing.Size(77, 34)
		Me.btnSelectAll.TabIndex = 13
		Me.btnSelectAll.Text = "Select SQL"
		Me.btnSelectAll.UseVisualStyleBackColor = True
		'
		'chkReplace
		'
		Me.chkReplace.AutoSize = True
		Me.chkReplace.Checked = True
		Me.chkReplace.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkReplace.Location = New System.Drawing.Point(143, 284)
		Me.chkReplace.Name = "chkReplace"
		Me.chkReplace.Size = New System.Drawing.Size(124, 17)
		Me.chkReplace.TabIndex = 14
		Me.chkReplace.Text = "Search and Replace"
		Me.chkReplace.UseVisualStyleBackColor = True
		'
		'lbDepTables
		'
		Me.lbDepTables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lbDepTables.FormattingEnabled = True
		Me.lbDepTables.Location = New System.Drawing.Point(351, 337)
		Me.lbDepTables.Name = "lbDepTables"
		Me.lbDepTables.Size = New System.Drawing.Size(295, 82)
		Me.lbDepTables.TabIndex = 15
		'
		'btnSaveAll
		'
		Me.btnSaveAll.Location = New System.Drawing.Point(144, 235)
		Me.btnSaveAll.Name = "btnSaveAll"
		Me.btnSaveAll.Size = New System.Drawing.Size(88, 34)
		Me.btnSaveAll.TabIndex = 16
		Me.btnSaveAll.Text = "Save all Views"
		Me.btnSaveAll.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(348, 317)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(39, 13)
		Me.Label6.TabIndex = 17
		Me.Label6.Text = "Tables"
		'
		'ProgressBar1
		'
		Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ProgressBar1.Location = New System.Drawing.Point(5, 736)
		Me.ProgressBar1.Name = "ProgressBar1"
		Me.ProgressBar1.Size = New System.Drawing.Size(923, 12)
		Me.ProgressBar1.TabIndex = 18
		Me.ProgressBar1.Visible = False
		'
		'txtRowLimit
		'
		Me.txtRowLimit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtRowLimit.Location = New System.Drawing.Point(715, 338)
		Me.txtRowLimit.Name = "txtRowLimit"
		Me.txtRowLimit.Size = New System.Drawing.Size(50, 20)
		Me.txtRowLimit.TabIndex = 19
		Me.txtRowLimit.Text = "1000"
		'
		'Label7
		'
		Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(652, 341)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(57, 13)
		Me.Label7.TabIndex = 20
		Me.Label7.Text = "Max Rows"
		'
		'chkCTE
		'
		Me.chkCTE.AutoSize = True
		Me.chkCTE.Checked = True
		Me.chkCTE.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkCTE.Location = New System.Drawing.Point(273, 285)
		Me.chkCTE.Name = "chkCTE"
		Me.chkCTE.Size = New System.Drawing.Size(47, 17)
		Me.chkCTE.TabIndex = 23
		Me.chkCTE.Text = "CTE"
		Me.chkCTE.UseVisualStyleBackColor = True
		'
		'btnBeautify
		'
		Me.btnBeautify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnBeautify.Location = New System.Drawing.Point(784, 385)
		Me.btnBeautify.Name = "btnBeautify"
		Me.btnBeautify.Size = New System.Drawing.Size(62, 34)
		Me.btnBeautify.TabIndex = 24
		Me.btnBeautify.Text = "Beautify"
		Me.btnBeautify.UseVisualStyleBackColor = True
		'
		'btnLoad
		'
		Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnLoad.Location = New System.Drawing.Point(750, 13)
		Me.btnLoad.Name = "btnLoad"
		Me.btnLoad.Size = New System.Drawing.Size(136, 23)
		Me.btnLoad.TabIndex = 25
		Me.btnLoad.Text = "Load views and procs"
		Me.btnLoad.UseVisualStyleBackColor = True
		Me.btnLoad.Visible = False
		'
		'chkCreateProc
		'
		Me.chkCreateProc.AutoSize = True
		Me.chkCreateProc.Checked = True
		Me.chkCreateProc.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkCreateProc.Location = New System.Drawing.Point(326, 284)
		Me.chkCreateProc.Name = "chkCreateProc"
		Me.chkCreateProc.Size = New System.Drawing.Size(108, 17)
		Me.chkCreateProc.TabIndex = 27
		Me.chkCreateProc.Text = "Create proc/view"
		Me.chkCreateProc.UseVisualStyleBackColor = True
		'
		'chkDepTables
		'
		Me.chkDepTables.AutoSize = True
		Me.chkDepTables.Location = New System.Drawing.Point(393, 317)
		Me.chkDepTables.Name = "chkDepTables"
		Me.chkDepTables.Size = New System.Drawing.Size(138, 17)
		Me.chkDepTables.TabIndex = 28
		Me.chkDepTables.Text = "Script dependent tables"
		Me.chkDepTables.UseVisualStyleBackColor = True
		'
		'lbMacros
		'
		Me.lbMacros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lbMacros.FormattingEnabled = True
		Me.lbMacros.Location = New System.Drawing.Point(653, 56)
		Me.lbMacros.Name = "lbMacros"
		Me.lbMacros.Size = New System.Drawing.Size(286, 173)
		Me.lbMacros.TabIndex = 29
		'
		'btnLoadMacros
		'
		Me.btnLoadMacros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnLoadMacros.Location = New System.Drawing.Point(654, 235)
		Me.btnLoadMacros.Name = "btnLoadMacros"
		Me.btnLoadMacros.Size = New System.Drawing.Size(83, 31)
		Me.btnLoadMacros.TabIndex = 31
		Me.btnLoadMacros.Text = "Load Macros"
		Me.btnLoadMacros.UseVisualStyleBackColor = True
		'
		'btnMarcoCreate
		'
		Me.btnMarcoCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnMarcoCreate.Location = New System.Drawing.Point(743, 235)
		Me.btnMarcoCreate.Name = "btnMarcoCreate"
		Me.btnMarcoCreate.Size = New System.Drawing.Size(85, 31)
		Me.btnMarcoCreate.TabIndex = 32
		Me.btnMarcoCreate.Text = "Create Macro"
		Me.btnMarcoCreate.UseVisualStyleBackColor = True
		'
		'chkScriptDepView
		'
		Me.chkScriptDepView.AutoSize = True
		Me.chkScriptDepView.Location = New System.Drawing.Point(144, 317)
		Me.chkScriptDepView.Name = "chkScriptDepView"
		Me.chkScriptDepView.Size = New System.Drawing.Size(137, 17)
		Me.chkScriptDepView.TabIndex = 33
		Me.chkScriptDepView.Text = "Script dependent views"
		Me.chkScriptDepView.UseVisualStyleBackColor = True
		'
		'lbProcs
		'
		Me.lbProcs.FormattingEnabled = True
		Me.lbProcs.Location = New System.Drawing.Point(351, 56)
		Me.lbProcs.Name = "lbProcs"
		Me.lbProcs.Size = New System.Drawing.Size(296, 173)
		Me.lbProcs.TabIndex = 34
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(348, 36)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(61, 13)
		Me.Label4.TabIndex = 35
		Me.Label4.Text = "Procedures"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(650, 36)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(42, 13)
		Me.Label8.TabIndex = 36
		Me.Label8.Text = "Macros"
		'
		'btnSaveAllMacros
		'
		Me.btnSaveAllMacros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSaveAllMacros.Location = New System.Drawing.Point(835, 234)
		Me.btnSaveAllMacros.Name = "btnSaveAllMacros"
		Me.btnSaveAllMacros.Size = New System.Drawing.Size(93, 31)
		Me.btnSaveAllMacros.TabIndex = 37
		Me.btnSaveAllMacros.Text = "Save All Macros"
		Me.btnSaveAllMacros.UseVisualStyleBackColor = True
		'
		'btnGetProcSQL
		'
		Me.btnGetProcSQL.Location = New System.Drawing.Point(352, 232)
		Me.btnGetProcSQL.Name = "btnGetProcSQL"
		Me.btnGetProcSQL.Size = New System.Drawing.Size(82, 34)
		Me.btnGetProcSQL.TabIndex = 38
		Me.btnGetProcSQL.Text = "Get SQL"
		Me.btnGetProcSQL.UseVisualStyleBackColor = True
		'
		'btnSaveAllProcs
		'
		Me.btnSaveAllProcs.Location = New System.Drawing.Point(443, 232)
		Me.btnSaveAllProcs.Name = "btnSaveAllProcs"
		Me.btnSaveAllProcs.Size = New System.Drawing.Size(88, 34)
		Me.btnSaveAllProcs.TabIndex = 39
		Me.btnSaveAllProcs.Text = "Save all Procs"
		Me.btnSaveAllProcs.UseVisualStyleBackColor = True
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(940, 750)
		Me.Controls.Add(Me.btnSaveAllProcs)
		Me.Controls.Add(Me.btnGetProcSQL)
		Me.Controls.Add(Me.btnSaveAllMacros)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.lbProcs)
		Me.Controls.Add(Me.chkScriptDepView)
		Me.Controls.Add(Me.btnMarcoCreate)
		Me.Controls.Add(Me.btnLoadMacros)
		Me.Controls.Add(Me.lbMacros)
		Me.Controls.Add(Me.chkDepTables)
		Me.Controls.Add(Me.chkCreateProc)
		Me.Controls.Add(Me.btnLoad)
		Me.Controls.Add(Me.btnBeautify)
		Me.Controls.Add(Me.chkCTE)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.txtRowLimit)
		Me.Controls.Add(Me.ProgressBar1)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.btnSaveAll)
		Me.Controls.Add(Me.lbDepTables)
		Me.Controls.Add(Me.chkReplace)
		Me.Controls.Add(Me.btnSelectAll)
		Me.Controls.Add(Me.chkFormatSql)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.cmViews)
		Me.Controls.Add(Me.lbDepViews)
		Me.Controls.Add(Me.btnGo)
		Me.Controls.Add(Me.txtSQL)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.btnOpenFile)
		Me.Controls.Add(Me.txtFilePath)
		Me.Name = "Form1"
		Me.Text = "Access to SQL"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
	Friend WithEvents btnOpenFile As System.Windows.Forms.Button
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtSQL As System.Windows.Forms.TextBox
	Friend WithEvents btnGo As System.Windows.Forms.Button
	Friend WithEvents lbDepViews As System.Windows.Forms.ListBox
	Friend WithEvents cmViews As System.Windows.Forms.ListBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents chkFormatSql As System.Windows.Forms.CheckBox
	Friend WithEvents btnSelectAll As System.Windows.Forms.Button
	Friend WithEvents chkReplace As System.Windows.Forms.CheckBox
	Friend WithEvents lbDepTables As System.Windows.Forms.ListBox
	Friend WithEvents btnSaveAll As System.Windows.Forms.Button
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
	Friend WithEvents txtRowLimit As System.Windows.Forms.TextBox
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents chkCTE As System.Windows.Forms.CheckBox
	Friend WithEvents btnBeautify As Button
	Friend WithEvents btnLoad As Button
	Friend WithEvents chkCreateProc As CheckBox
	Friend WithEvents chkDepTables As CheckBox
	Friend WithEvents lbMacros As ListBox
	Friend WithEvents btnLoadMacros As Button
	Friend WithEvents btnMarcoCreate As Button
	Friend WithEvents chkScriptDepView As CheckBox
	Friend WithEvents lbProcs As ListBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents btnSaveAllMacros As Button
	Friend WithEvents btnGetProcSQL As Button
	Friend WithEvents btnSaveAllProcs As Button
End Class
