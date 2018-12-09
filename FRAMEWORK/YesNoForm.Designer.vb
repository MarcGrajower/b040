<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YesNoForm
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
        Me.BtnBase2 = New b040.btnBase
        Me.BtnBase1 = New b040.btnBase
        Me.lblbase1 = New b040.lblBase
        Me.SuspendLayout()
        '
        'BtnBase2
        '
        Me.BtnBase2.Location = New System.Drawing.Point(343, 58)
        Me.BtnBase2.Name = "BtnBase2"
        Me.BtnBase2.nIO = b040.IOValues.IOAlwaysEnable
        Me.BtnBase2.Size = New System.Drawing.Size(75, 23)
        Me.BtnBase2.TabIndex = 2
        Me.BtnBase2.Text = "&Neen"
        Me.BtnBase2.UseVisualStyleBackColor = True
        '
        'BtnBase1
        '
        Me.BtnBase1.Location = New System.Drawing.Point(262, 58)
        Me.BtnBase1.Name = "BtnBase1"
        Me.BtnBase1.nIO = b040.IOValues.IOAlwaysEnable
        Me.BtnBase1.Size = New System.Drawing.Size(75, 23)
        Me.BtnBase1.TabIndex = 1
        Me.BtnBase1.Text = "&Ja"
        Me.BtnBase1.UseVisualStyleBackColor = True
        '
        'lblbase1
        '
        Me.lblbase1.AutoEllipsis = True
        Me.lblbase1.AutoSize = True
        Me.lblbase1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblbase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbase1.Location = New System.Drawing.Point(6, 4)
        Me.lblbase1.MaximumSize = New System.Drawing.Size(414, 0)
        Me.lblbase1.MinimumSize = New System.Drawing.Size(414, 47)
        Me.lblbase1.Name = "lblbase1"
        Me.lblbase1.Size = New System.Drawing.Size(414, 47)
        Me.lblbase1.TabIndex = 2
        Me.lblbase1.Text = "U weet toch zeker dat deze standaar mag verwijderd worden of niet soms?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblbase1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'YesNoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 88)
        Me.Controls.Add(Me.BtnBase2)
        Me.Controls.Add(Me.BtnBase1)
        Me.Controls.Add(Me.lblbase1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "YesNoForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gelieve te bevestigen:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblbase1 As b040.lblBase
    Friend WithEvents BtnBase1 As b040.btnBase
    Friend WithEvents BtnBase2 As b040.btnBase

End Class
