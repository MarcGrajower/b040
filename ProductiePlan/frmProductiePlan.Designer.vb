<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductiePlan
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
        Me.PnlBase1 = New b040.pnlBase()
        Me.TxtSnijdplan = New b040.txtBase()
        Me.TxtBijzonderArtikels = New b040.txtBase()
        Me.TxtKat5 = New b040.txtBase()
        Me.TxtKat4 = New b040.txtBase()
        Me.TxtKat3 = New b040.txtBase()
        Me.txtKat2 = New b040.txtBase()
        Me.TxtKat1 = New b040.txtBase()
        Me.TxtLeveringsDatum = New b040.txtBaseDate()
        Me.LblBase10 = New b040.lblBase()
        Me.LblBase8 = New b040.lblBase()
        Me.LblBase1 = New b040.lblBase()
        Me.LblBase7 = New b040.lblBase()
        Me.LblBase6 = New b040.lblBase()
        Me.LblBase5 = New b040.lblBase()
        Me.LblBase4 = New b040.lblBase()
        Me.LblBase9 = New b040.lblBase()
        Me.LblBase2 = New b040.lblBase()
        Me.btnOK = New b040.btnBase()
        Me.btnCancel = New b040.btnBase()
        Me.cboPrinters = New b040.cboBase()
        Me.PnlBase1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.TxtSnijdplan)
        Me.PnlBase1.Controls.Add(Me.TxtBijzonderArtikels)
        Me.PnlBase1.Controls.Add(Me.TxtKat5)
        Me.PnlBase1.Controls.Add(Me.TxtKat4)
        Me.PnlBase1.Controls.Add(Me.TxtKat3)
        Me.PnlBase1.Controls.Add(Me.txtKat2)
        Me.PnlBase1.Controls.Add(Me.TxtKat1)
        Me.PnlBase1.Controls.Add(Me.TxtLeveringsDatum)
        Me.PnlBase1.Controls.Add(Me.LblBase10)
        Me.PnlBase1.Controls.Add(Me.LblBase8)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.LblBase7)
        Me.PnlBase1.Controls.Add(Me.LblBase6)
        Me.PnlBase1.Controls.Add(Me.LblBase5)
        Me.PnlBase1.Controls.Add(Me.LblBase4)
        Me.PnlBase1.Controls.Add(Me.LblBase9)
        Me.PnlBase1.Controls.Add(Me.cboPrinters)
        Me.PnlBase1.Controls.Add(Me.LblBase2)
        Me.PnlBase1.Location = New System.Drawing.Point(2, 4)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(391, 208)
        Me.PnlBase1.TabIndex = 24
        '
        'TxtSnijdplan
        '
        Me.TxtSnijdplan.fieldLength = 0
        Me.TxtSnijdplan.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtSnijdplan.forceUppercase = True
        Me.TxtSnijdplan.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtSnijdplan.lIsSearch = False
        Me.TxtSnijdplan.Location = New System.Drawing.Point(128, 180)
        Me.TxtSnijdplan.Name = "TxtSnijdplan"
        Me.TxtSnijdplan.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtSnijdplan.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtSnijdplan.Size = New System.Drawing.Size(261, 21)
        Me.TxtSnijdplan.TabIndex = 15
        '
        'TxtBijzonderArtikels
        '
        Me.TxtBijzonderArtikels.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.TxtBijzonderArtikels.fieldLength = 0
        Me.TxtBijzonderArtikels.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtBijzonderArtikels.forceUppercase = True
        Me.TxtBijzonderArtikels.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtBijzonderArtikels.lIsSearch = False
        Me.TxtBijzonderArtikels.Location = New System.Drawing.Point(128, 158)
        Me.TxtBijzonderArtikels.Name = "TxtBijzonderArtikels"
        Me.TxtBijzonderArtikels.nIO = b040.IOValues.IOAlwaysDisable
        Me.TxtBijzonderArtikels.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBijzonderArtikels.Size = New System.Drawing.Size(261, 21)
        Me.TxtBijzonderArtikels.TabIndex = 14
        Me.TxtBijzonderArtikels.TabStop = False
        '
        'TxtKat5
        '
        Me.TxtKat5.fieldLength = 0
        Me.TxtKat5.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtKat5.forceUppercase = True
        Me.TxtKat5.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtKat5.lIsSearch = False
        Me.TxtKat5.Location = New System.Drawing.Point(128, 136)
        Me.TxtKat5.Name = "TxtKat5"
        Me.TxtKat5.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtKat5.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtKat5.Size = New System.Drawing.Size(261, 21)
        Me.TxtKat5.TabIndex = 13
        '
        'TxtKat4
        '
        Me.TxtKat4.fieldLength = 0
        Me.TxtKat4.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtKat4.forceUppercase = True
        Me.TxtKat4.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtKat4.lIsSearch = False
        Me.TxtKat4.Location = New System.Drawing.Point(128, 114)
        Me.TxtKat4.Name = "TxtKat4"
        Me.TxtKat4.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtKat4.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtKat4.Size = New System.Drawing.Size(261, 21)
        Me.TxtKat4.TabIndex = 12
        '
        'TxtKat3
        '
        Me.TxtKat3.fieldLength = 0
        Me.TxtKat3.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtKat3.forceUppercase = True
        Me.TxtKat3.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtKat3.lIsSearch = False
        Me.TxtKat3.Location = New System.Drawing.Point(128, 92)
        Me.TxtKat3.Name = "TxtKat3"
        Me.TxtKat3.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtKat3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtKat3.Size = New System.Drawing.Size(261, 21)
        Me.TxtKat3.TabIndex = 11
        '
        'txtKat2
        '
        Me.txtKat2.fieldLength = 0
        Me.txtKat2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtKat2.forceUppercase = True
        Me.txtKat2.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtKat2.lIsSearch = False
        Me.txtKat2.Location = New System.Drawing.Point(128, 70)
        Me.txtKat2.Name = "txtKat2"
        Me.txtKat2.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtKat2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtKat2.Size = New System.Drawing.Size(261, 21)
        Me.txtKat2.TabIndex = 10
        '
        'TxtKat1
        '
        Me.TxtKat1.fieldLength = 0
        Me.TxtKat1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtKat1.forceUppercase = True
        Me.TxtKat1.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtKat1.lIsSearch = False
        Me.TxtKat1.Location = New System.Drawing.Point(128, 48)
        Me.TxtKat1.Name = "TxtKat1"
        Me.TxtKat1.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtKat1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtKat1.Size = New System.Drawing.Size(261, 21)
        Me.TxtKat1.TabIndex = 9
        '
        'TxtLeveringsDatum
        '
        Me.TxtLeveringsDatum.fieldLength = 0
        Me.TxtLeveringsDatum.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtLeveringsDatum.forceUppercase = True
        Me.TxtLeveringsDatum.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtLeveringsDatum.lIsSearch = False
        Me.TxtLeveringsDatum.Location = New System.Drawing.Point(128, 26)
        Me.TxtLeveringsDatum.Name = "TxtLeveringsDatum"
        Me.TxtLeveringsDatum.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtLeveringsDatum.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtLeveringsDatum.Size = New System.Drawing.Size(261, 21)
        Me.TxtLeveringsDatum.TabIndex = 1
        '
        'LblBase10
        '
        Me.LblBase10.AutoSize = True
        Me.LblBase10.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase10.Location = New System.Drawing.Point(2, 161)
        Me.LblBase10.Name = "LblBase10"
        Me.LblBase10.Size = New System.Drawing.Size(102, 16)
        Me.LblBase10.TabIndex = 8
        Me.LblBase10.Text = "Bijzondere Artikels"
        '
        'LblBase8
        '
        Me.LblBase8.AutoSize = True
        Me.LblBase8.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase8.Location = New System.Drawing.Point(2, 183)
        Me.LblBase8.Name = "LblBase8"
        Me.LblBase8.Size = New System.Drawing.Size(52, 16)
        Me.LblBase8.TabIndex = 2
        Me.LblBase8.Text = "Snijdplan"
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(2, 139)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(127, 16)
        Me.LblBase1.TabIndex = 7
        Me.LblBase1.Text = "Kat. 5. Brood niet gesn;"
        '
        'LblBase7
        '
        Me.LblBase7.AutoSize = True
        Me.LblBase7.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase7.Location = New System.Drawing.Point(2, 117)
        Me.LblBase7.Name = "LblBase7"
        Me.LblBase7.Size = New System.Drawing.Size(89, 16)
        Me.LblBase7.TabIndex = 6
        Me.LblBase7.Text = "Kat. 4. Diversen"
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase6.Location = New System.Drawing.Point(2, 95)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(106, 16)
        Me.LblBase6.TabIndex = 5
        Me.LblBase6.Text = "Kat. 3. Groothandel"
        '
        'LblBase5
        '
        Me.LblBase5.AutoSize = True
        Me.LblBase5.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase5.Location = New System.Drawing.Point(2, 73)
        Me.LblBase5.Name = "LblBase5"
        Me.LblBase5.Size = New System.Drawing.Size(94, 16)
        Me.LblBase5.TabIndex = 4
        Me.LblBase5.Text = "Kat. 2. Pattiserie"
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase4.Location = New System.Drawing.Point(2, 51)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(74, 16)
        Me.LblBase4.TabIndex = 3
        Me.LblBase4.Text = "Kat. 1. Brood"
        '
        'LblBase9
        '
        Me.LblBase9.AutoSize = True
        Me.LblBase9.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase9.Location = New System.Drawing.Point(2, 7)
        Me.LblBase9.Name = "LblBase9"
        Me.LblBase9.Size = New System.Drawing.Size(43, 16)
        Me.LblBase9.TabIndex = 4
        Me.LblBase9.Text = "Printer"
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase2.Location = New System.Drawing.Point(2, 29)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(88, 16)
        Me.LblBase2.TabIndex = 5
        Me.LblBase2.Text = "Leveringsdatum"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.btnOK.Location = New System.Drawing.Point(4, 218)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 25
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.btnCancel.Location = New System.Drawing.Point(318, 218)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "Annuleren"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboPrinters
        '
        Me.cboPrinters.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cboPrinters.ForeColor = System.Drawing.Color.DarkBlue
        Me.cboPrinters.FormattingEnabled = True
        Me.cboPrinters.Location = New System.Drawing.Point(128, 3)
        Me.cboPrinters.Name = "cboPrinters"
        Me.cboPrinters.nIO = b040.IOValues.IOAlwaysEnable
        Me.cboPrinters.setAutocomplete = False
        Me.cboPrinters.Size = New System.Drawing.Size(261, 26)
        Me.cboPrinters.TabIndex = 0
        '
        'frmProductiePlan
        '
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 242)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.PnlBase1)
        Me.FormMode = b040.ModeValues.RecordEntry
        Me.KeyPreview = True
        Me.Name = "frmProductiePlan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productie- en Snijdplan"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents LblBase7 As b040.lblBase
    Friend WithEvents LblBase6 As b040.lblBase
    Friend WithEvents LblBase5 As b040.lblBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents LblBase9 As b040.lblBase
    Friend WithEvents LblBase10 As b040.lblBase
    Friend WithEvents LblBase8 As b040.lblBase
    Friend WithEvents TxtLeveringsDatum As b040.txtBaseDate
    Friend WithEvents btnOK As b040.btnBase
    Friend WithEvents btnCancel As b040.btnBase
    Friend WithEvents TxtSnijdplan As b040.txtBase
    Friend WithEvents TxtBijzonderArtikels As b040.txtBase
    Friend WithEvents TxtKat5 As b040.txtBase
    Friend WithEvents TxtKat4 As b040.txtBase
    Friend WithEvents TxtKat3 As b040.txtBase
    Friend WithEvents txtKat2 As b040.txtBase
    Friend WithEvents TxtKat1 As b040.txtBase
    Friend WithEvents cboPrinters As b040.cboBase

End Class
