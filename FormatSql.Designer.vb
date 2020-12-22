<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormatSql
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
		Me.txtIn = New System.Windows.Forms.TextBox()
		Me.txtOut = New System.Windows.Forms.TextBox()
		Me.btnBeautify = New System.Windows.Forms.Button()
		Me.btnSelectAll = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'txtIn
		'
		Me.txtIn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtIn.Location = New System.Drawing.Point(0, 3)
		Me.txtIn.Multiline = True
		Me.txtIn.Name = "txtIn"
		Me.txtIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtIn.Size = New System.Drawing.Size(757, 116)
		Me.txtIn.TabIndex = 6
		'
		'txtOut
		'
		Me.txtOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtOut.Location = New System.Drawing.Point(0, 127)
		Me.txtOut.Multiline = True
		Me.txtOut.Name = "txtOut"
		Me.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtOut.Size = New System.Drawing.Size(757, 254)
		Me.txtOut.TabIndex = 7
		'
		'btnBeautify
		'
		Me.btnBeautify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnBeautify.Location = New System.Drawing.Point(282, 397)
		Me.btnBeautify.Name = "btnBeautify"
		Me.btnBeautify.Size = New System.Drawing.Size(75, 39)
		Me.btnBeautify.TabIndex = 8
		Me.btnBeautify.Text = "Beautify"
		Me.btnBeautify.UseVisualStyleBackColor = True
		'
		'btnSelectAll
		'
		Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnSelectAll.Location = New System.Drawing.Point(384, 399)
		Me.btnSelectAll.Name = "btnSelectAll"
		Me.btnSelectAll.Size = New System.Drawing.Size(77, 34)
		Me.btnSelectAll.TabIndex = 14
		Me.btnSelectAll.Text = "Select All"
		Me.btnSelectAll.UseVisualStyleBackColor = True
		'
		'FormatSql
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(769, 448)
		Me.Controls.Add(Me.btnSelectAll)
		Me.Controls.Add(Me.btnBeautify)
		Me.Controls.Add(Me.txtOut)
		Me.Controls.Add(Me.txtIn)
		Me.Name = "FormatSql"
		Me.Text = "FormatSql"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents txtIn As TextBox
	Friend WithEvents txtOut As TextBox
	Friend WithEvents btnBeautify As Button
	Friend WithEvents btnSelectAll As Button
End Class
