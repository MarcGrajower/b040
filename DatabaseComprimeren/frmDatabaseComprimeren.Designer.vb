<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabaseComprimeren
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
        Me.PnlBase1 = New b040.pnlBase
        Me.LblBase1 = New b040.lblBase
        Me.txtPhase = New b040.txtBase
        Me.btnOK = New b040.btnBase
        Me.btnAnnuleren = New b040.btnBase
        Me.PnlBase1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.txtPhase)
        Me.PnlBase1.Location = New System.Drawing.Point(1, 2)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(418, 37)
        Me.PnlBase1.TabIndex = 39
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Location = New System.Drawing.Point(7, 9)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(40, 13)
        Me.LblBase1.TabIndex = 40
        Me.LblBase1.Text = "Phase:"
        '
        'txtPhase
        '
        Me.txtPhase.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtPhase.fieldLength = 0
        Me.txtPhase.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtPhase.forceUppercase = True
        Me.txtPhase.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtPhase.Location = New System.Drawing.Point(48, 6)
        Me.txtPhase.Name = "txtPhase"
        Me.txtPhase.nIO = b040.IOValues.IOAlwaysDisable
        Me.txtPhase.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtPhase.Size = New System.Drawing.Size(361, 20)
        Me.txtPhase.TabIndex = 17
        Me.txtPhase.TabStop = False
        Me.txtPhase.ValidatingType = GetType(Date)
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(2, 42)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 40
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnAnnuleren
        '
        Me.btnAnnuleren.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuleren.Location = New System.Drawing.Point(344, 42)
        Me.btnAnnuleren.Name = "btnAnnuleren"
        Me.btnAnnuleren.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnAnnuleren.Size = New System.Drawing.Size(75, 23)
        Me.btnAnnuleren.TabIndex = 41
        Me.btnAnnuleren.Text = "Annuleren"
        Me.btnAnnuleren.UseVisualStyleBackColor = True
        '
        'frmDatabaseComprimeren
        '
        Me.CancelButton = Me.btnAnnuleren
        Me.ClientSize = New System.Drawing.Size(419, 65)
        Me.Controls.Add(Me.btnAnnuleren)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.PnlBase1)
        Me.Name = "frmDatabaseComprimeren"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Comprimeren"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents txtPhase As b040.txtBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents btnOK As b040.btnBase
    Friend WithEvents btnAnnuleren As b040.btnBase

End Class
