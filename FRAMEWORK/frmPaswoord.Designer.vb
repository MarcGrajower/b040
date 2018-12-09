<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaswoord
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
        Me.TxtPaswoord = New b040.txtBase()
        Me.LblBase1 = New b040.lblBase()
        Me.TxtBase1 = New b040.txtBase()
        Me.SuspendLayout()
        '
        'TxtPaswoord
        '
        Me.TxtPaswoord.BeepOnError = True
        Me.TxtPaswoord.fieldLength = 8
        Me.TxtPaswoord.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtPaswoord.forceUppercase = True
        Me.TxtPaswoord.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtPaswoord.HideSelection = False
        Me.TxtPaswoord.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.TxtPaswoord.lIsSearch = False
        Me.TxtPaswoord.Location = New System.Drawing.Point(76, 2)
        Me.TxtPaswoord.Mask = "00000000"
        Me.TxtPaswoord.Name = "TxtPaswoord"
        Me.TxtPaswoord.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtPaswoord.PromptChar = Global.Microsoft.VisualBasic.ChrW(176)
        Me.TxtPaswoord.Size = New System.Drawing.Size(100, 21)
        Me.TxtPaswoord.TabIndex = 0
        Me.TxtPaswoord.UseSystemPasswordChar = True
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(7, 6)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(55, 16)
        Me.LblBase1.TabIndex = 1
        Me.LblBase1.Text = "Paswoord"
        '
        'TxtBase1
        '
        Me.TxtBase1.fieldLength = 4
        Me.TxtBase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtBase1.forceUppercase = True
        Me.TxtBase1.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtBase1.lIsSearch = False
        Me.TxtBase1.Location = New System.Drawing.Point(137, -1)
        Me.TxtBase1.Name = "TxtBase1"
        Me.TxtBase1.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtBase1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtBase1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBase1.Size = New System.Drawing.Size(10, 21)
        Me.TxtBase1.TabIndex = 2
        '
        'frmPaswoord
        '
        Me.ClientSize = New System.Drawing.Size(187, 26)
        Me.Controls.Add(Me.LblBase1)
        Me.Controls.Add(Me.TxtPaswoord)
        Me.Controls.Add(Me.TxtBase1)
        Me.Name = "frmPaswoord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toegang"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtPaswoord As b040.txtBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents TxtBase1 As b040.txtBase

End Class
