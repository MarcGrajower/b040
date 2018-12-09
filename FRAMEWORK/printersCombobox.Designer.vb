<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class printersCombobox
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
        Me.CboBase1 = New b040.cboBase()
        Me.SuspendLayout()
        '
        'CboBase1
        '
        Me.CboBase1.ForeColor = System.Drawing.Color.DarkBlue
        Me.CboBase1.FormattingEnabled = True
        Me.CboBase1.Location = New System.Drawing.Point(48, 4)
        Me.CboBase1.Name = "CboBase1"
        Me.CboBase1.nIO = b040.IOValues.IOAlwaysDisable
        Me.CboBase1.setAutocomplete = False
        Me.CboBase1.Size = New System.Drawing.Size(140, 21)
        Me.CboBase1.TabIndex = 0
        '
        'printersCombobox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CboBase1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.Name = "printersCombobox"
        Me.Size = New System.Drawing.Size(301, 33)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboBase1 As b040.cboBase

End Class
