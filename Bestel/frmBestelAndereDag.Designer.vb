<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBestelAndereDag
    Inherits b040.frmB040

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancel = New b040.btnBase
        Me.btnOK = New b040.btnBase
        Me.PnlBase1 = New b040.pnlBase
        Me.TxtBaseDate1 = New b040.txtBaseDate
        Me.LblBase1 = New b040.lblBase
        Me.LblBase2 = New b040.lblBase
        Me.PnlBase1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Silver
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(137, 41)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.nIO = b040.IOValues.IOAlwaysEnable
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Annuleren"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Silver
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(4, 41)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.TxtBaseDate1)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.LblBase2)
        Me.PnlBase1.Location = New System.Drawing.Point(2, 4)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(209, 34)
        Me.PnlBase1.TabIndex = 0
        '
        'TxtBaseDate1
        '
        Me.TxtBaseDate1.fieldLength = 0
        Me.TxtBaseDate1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtBaseDate1.forceUppercase = True
        Me.TxtBaseDate1.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtBaseDate1.lIsSearch = False
        Me.TxtBaseDate1.Location = New System.Drawing.Point(104, 4)
        Me.TxtBaseDate1.Name = "TxtBaseDate1"
        Me.TxtBaseDate1.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtBaseDate1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBaseDate1.Size = New System.Drawing.Size(100, 20)
        Me.TxtBaseDate1.TabIndex = 0
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Location = New System.Drawing.Point(-34, 46)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(37, 13)
        Me.LblBase1.TabIndex = 4
        Me.LblBase1.Text = "Printer"
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Location = New System.Drawing.Point(4, 8)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(88, 13)
        Me.LblBase2.TabIndex = 14
        Me.LblBase2.Text = "Datum (Levering)"
        '
        'frmBestelAndereDag
        '
        Me.BackColor = System.Drawing.Color.Maroon
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(217, 67)
        Me.Controls.Add(Me.PnlBase1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmBestelAndereDag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Andere Dag"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As b040.btnBase
    Friend WithEvents btnOK As b040.btnBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents TxtBaseDate1 As b040.txtBaseDate

End Class
