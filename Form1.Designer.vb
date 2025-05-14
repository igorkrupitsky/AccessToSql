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
        Me.txtFilePath.Location = New System.Drawing.Point(82, 20)
        Me.txtFilePath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(1028, 26)
        Me.txtFilePath.TabIndex = 0
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenFile.Location = New System.Drawing.Point(1334, 20)
        Me.btnOpenFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(54, 35)
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
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "File path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Views"
        '
        'txtSQL
        '
        Me.txtSQL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQL.Location = New System.Drawing.Point(69, 654)
        Me.txtSQL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQL.Size = New System.Drawing.Size(1334, 146)
        Me.txtSQL.TabIndex = 5
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(82, 362)
        Me.btnGo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(123, 52)
        Me.btnGo.TabIndex = 6
        Me.btnGo.Text = "Get SQL"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'lbDepViews
        '
        Me.lbDepViews.FormattingEnabled = True
        Me.lbDepViews.ItemHeight = 20
        Me.lbDepViews.Location = New System.Drawing.Point(69, 518)
        Me.lbDepViews.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbDepViews.Name = "lbDepViews"
        Me.lbDepViews.Size = New System.Drawing.Size(446, 124)
        Me.lbDepViews.TabIndex = 7
        '
        'cmViews
        '
        Me.cmViews.FormattingEnabled = True
        Me.cmViews.ItemHeight = 20
        Me.cmViews.Location = New System.Drawing.Point(69, 86)
        Me.cmViews.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmViews.Name = "cmViews"
        Me.cmViews.Size = New System.Drawing.Size(446, 264)
        Me.cmViews.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 488)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Dependent Views"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 658)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "SQL"
        '
        'chkFormatSql
        '
        Me.chkFormatSql.AutoSize = True
        Me.chkFormatSql.Checked = True
        Me.chkFormatSql.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFormatSql.Location = New System.Drawing.Point(82, 437)
        Me.chkFormatSql.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkFormatSql.Name = "chkFormatSql"
        Me.chkFormatSql.Size = New System.Drawing.Size(122, 24)
        Me.chkFormatSql.TabIndex = 12
        Me.chkFormatSql.Text = "Format SQL"
        Me.chkFormatSql.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(1272, 592)
        Me.btnSelectAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(116, 52)
        Me.btnSelectAll.TabIndex = 13
        Me.btnSelectAll.Text = "Select SQL"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'chkReplace
        '
        Me.chkReplace.AutoSize = True
        Me.chkReplace.Checked = True
        Me.chkReplace.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReplace.Location = New System.Drawing.Point(214, 437)
        Me.chkReplace.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkReplace.Name = "chkReplace"
        Me.chkReplace.Size = New System.Drawing.Size(180, 24)
        Me.chkReplace.TabIndex = 14
        Me.chkReplace.Text = "Search and Replace"
        Me.chkReplace.UseVisualStyleBackColor = True
        '
        'lbDepTables
        '
        Me.lbDepTables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDepTables.FormattingEnabled = True
        Me.lbDepTables.ItemHeight = 20
        Me.lbDepTables.Location = New System.Drawing.Point(526, 518)
        Me.lbDepTables.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbDepTables.Name = "lbDepTables"
        Me.lbDepTables.Size = New System.Drawing.Size(436, 124)
        Me.lbDepTables.TabIndex = 15
        '
        'btnSaveAll
        '
        Me.btnSaveAll.Location = New System.Drawing.Point(216, 362)
        Me.btnSaveAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(132, 52)
        Me.btnSaveAll.TabIndex = 16
        Me.btnSaveAll.Text = "Save all Views"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(522, 488)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Tables"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 810)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1380, 18)
        Me.ProgressBar1.TabIndex = 18
        Me.ProgressBar1.Visible = False
        '
        'txtRowLimit
        '
        Me.txtRowLimit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRowLimit.Location = New System.Drawing.Point(1315, 518)
        Me.txtRowLimit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRowLimit.Name = "txtRowLimit"
        Me.txtRowLimit.Size = New System.Drawing.Size(73, 26)
        Me.txtRowLimit.TabIndex = 19
        Me.txtRowLimit.Text = "1000"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1225, 524)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 20)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Max Rows"
        '
        'chkCTE
        '
        Me.chkCTE.AutoSize = True
        Me.chkCTE.Checked = True
        Me.chkCTE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCTE.Location = New System.Drawing.Point(410, 438)
        Me.chkCTE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkCTE.Name = "chkCTE"
        Me.chkCTE.Size = New System.Drawing.Size(66, 24)
        Me.chkCTE.TabIndex = 23
        Me.chkCTE.Text = "CTE"
        Me.chkCTE.UseVisualStyleBackColor = True
        '
        'btnBeautify
        '
        Me.btnBeautify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBeautify.Location = New System.Drawing.Point(1172, 592)
        Me.btnBeautify.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBeautify.Name = "btnBeautify"
        Me.btnBeautify.Size = New System.Drawing.Size(93, 52)
        Me.btnBeautify.TabIndex = 24
        Me.btnBeautify.Text = "Beautify"
        Me.btnBeautify.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(1121, 20)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(204, 35)
        Me.btnLoad.TabIndex = 25
        Me.btnLoad.Text = "Load views and procs"
        Me.btnLoad.UseVisualStyleBackColor = True
        Me.btnLoad.Visible = False
        '
        'chkCreateProc
        '
        Me.chkCreateProc.AutoSize = True
        Me.chkCreateProc.Location = New System.Drawing.Point(489, 437)
        Me.chkCreateProc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkCreateProc.Name = "chkCreateProc"
        Me.chkCreateProc.Size = New System.Drawing.Size(152, 24)
        Me.chkCreateProc.TabIndex = 27
        Me.chkCreateProc.Text = "Create proc/view"
        Me.chkCreateProc.UseVisualStyleBackColor = True
        '
        'chkDepTables
        '
        Me.chkDepTables.AutoSize = True
        Me.chkDepTables.Location = New System.Drawing.Point(590, 488)
        Me.chkDepTables.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkDepTables.Name = "chkDepTables"
        Me.chkDepTables.Size = New System.Drawing.Size(204, 24)
        Me.chkDepTables.TabIndex = 28
        Me.chkDepTables.Text = "Script dependent tables"
        Me.chkDepTables.UseVisualStyleBackColor = True
        '
        'lbMacros
        '
        Me.lbMacros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbMacros.FormattingEnabled = True
        Me.lbMacros.ItemHeight = 20
        Me.lbMacros.Location = New System.Drawing.Point(980, 86)
        Me.lbMacros.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbMacros.Name = "lbMacros"
        Me.lbMacros.Size = New System.Drawing.Size(423, 264)
        Me.lbMacros.TabIndex = 29
        '
        'btnLoadMacros
        '
        Me.btnLoadMacros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadMacros.Location = New System.Drawing.Point(977, 362)
        Me.btnLoadMacros.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLoadMacros.Name = "btnLoadMacros"
        Me.btnLoadMacros.Size = New System.Drawing.Size(124, 48)
        Me.btnLoadMacros.TabIndex = 31
        Me.btnLoadMacros.Text = "Load Macros"
        Me.btnLoadMacros.UseVisualStyleBackColor = True
        '
        'btnMarcoCreate
        '
        Me.btnMarcoCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarcoCreate.Location = New System.Drawing.Point(1110, 362)
        Me.btnMarcoCreate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMarcoCreate.Name = "btnMarcoCreate"
        Me.btnMarcoCreate.Size = New System.Drawing.Size(128, 48)
        Me.btnMarcoCreate.TabIndex = 32
        Me.btnMarcoCreate.Text = "Create Macro"
        Me.btnMarcoCreate.UseVisualStyleBackColor = True
        '
        'chkScriptDepView
        '
        Me.chkScriptDepView.AutoSize = True
        Me.chkScriptDepView.Checked = True
        Me.chkScriptDepView.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScriptDepView.Location = New System.Drawing.Point(216, 488)
        Me.chkScriptDepView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkScriptDepView.Name = "chkScriptDepView"
        Me.chkScriptDepView.Size = New System.Drawing.Size(199, 24)
        Me.chkScriptDepView.TabIndex = 33
        Me.chkScriptDepView.Text = "Script dependent views"
        Me.chkScriptDepView.UseVisualStyleBackColor = True
        '
        'lbProcs
        '
        Me.lbProcs.FormattingEnabled = True
        Me.lbProcs.ItemHeight = 20
        Me.lbProcs.Location = New System.Drawing.Point(526, 86)
        Me.lbProcs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbProcs.Name = "lbProcs"
        Me.lbProcs.Size = New System.Drawing.Size(442, 264)
        Me.lbProcs.TabIndex = 34
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(522, 55)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Procedures"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(975, 55)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 20)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Macros"
        '
        'btnSaveAllMacros
        '
        Me.btnSaveAllMacros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAllMacros.Location = New System.Drawing.Point(1248, 360)
        Me.btnSaveAllMacros.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSaveAllMacros.Name = "btnSaveAllMacros"
        Me.btnSaveAllMacros.Size = New System.Drawing.Size(140, 48)
        Me.btnSaveAllMacros.TabIndex = 37
        Me.btnSaveAllMacros.Text = "Save All Macros"
        Me.btnSaveAllMacros.UseVisualStyleBackColor = True
        '
        'btnGetProcSQL
        '
        Me.btnGetProcSQL.Location = New System.Drawing.Point(528, 357)
        Me.btnGetProcSQL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGetProcSQL.Name = "btnGetProcSQL"
        Me.btnGetProcSQL.Size = New System.Drawing.Size(123, 52)
        Me.btnGetProcSQL.TabIndex = 38
        Me.btnGetProcSQL.Text = "Get SQL"
        Me.btnGetProcSQL.UseVisualStyleBackColor = True
        '
        'btnSaveAllProcs
        '
        Me.btnSaveAllProcs.Location = New System.Drawing.Point(664, 357)
        Me.btnSaveAllProcs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSaveAllProcs.Name = "btnSaveAllProcs"
        Me.btnSaveAllProcs.Size = New System.Drawing.Size(132, 52)
        Me.btnSaveAllProcs.TabIndex = 39
        Me.btnSaveAllProcs.Text = "Save all Procs"
        Me.btnSaveAllProcs.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1406, 832)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
