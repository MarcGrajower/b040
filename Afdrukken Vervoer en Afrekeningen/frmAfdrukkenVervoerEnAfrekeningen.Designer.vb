<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAfdrukkenVervoerEnAfrekiningen
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
        Me.btnOK = New b040.btnBase()
        Me.btnCancel = New b040.btnBase()
        Me.PnlBase1 = New b040.pnlBase()
        Me.txtKlNaam = New b040.txtBase()
        Me.txtDatumLevering = New b040.txtBaseDate()
        Me.LblBase7 = New b040.lblBase()
        Me.txtKlNr = New b040.txtBase()
        Me.LblBase6 = New b040.lblBase()
        Me.txtAfrekeningCopijen = New b040.txtBase()
        Me.LblBase10 = New b040.lblBase()
        Me.txtVervoerCopijen = New b040.txtBase()
        Me.txtTour = New b040.txtBase()
        Me.LblBase1 = New b040.lblBase()
        Me.LblBase4 = New b040.lblBase()
        Me.LblBase2 = New b040.lblBase()
        Me.PnlBase2 = New b040.pnlBase()
        Me.particulierenCheckbox = New b040.checkboxBase()
        Me.LblBase8 = New b040.lblBase()
        Me.AfdrukkenPerTourCheckbox = New b040.checkboxBase()
        Me.LblBase13 = New b040.lblBase()
        Me.LblBase15 = New b040.lblBase()
        Me.PnlBase1.SuspendLayout()
        Me.PnlBase2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Silver
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnOK.Location = New System.Drawing.Point(1, 185)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.nIO = b040.IOValues.IORecordEntryEnable
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Afdrukken"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Silver
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(311, 185)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.nIO = b040.IOValues.IOAlwaysEnable
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Annuleren"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.txtKlNaam)
        Me.PnlBase1.Controls.Add(Me.txtDatumLevering)
        Me.PnlBase1.Controls.Add(Me.LblBase7)
        Me.PnlBase1.Controls.Add(Me.txtKlNr)
        Me.PnlBase1.Controls.Add(Me.LblBase6)
        Me.PnlBase1.Controls.Add(Me.txtAfrekeningCopijen)
        Me.PnlBase1.Controls.Add(Me.LblBase10)
        Me.PnlBase1.Controls.Add(Me.txtVervoerCopijen)
        Me.PnlBase1.Controls.Add(Me.txtTour)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.LblBase4)
        Me.PnlBase1.Controls.Add(Me.LblBase2)
        Me.PnlBase1.Location = New System.Drawing.Point(0, 2)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(385, 146)
        Me.PnlBase1.TabIndex = 0
        '
        'txtKlNaam
        '
        Me.txtKlNaam.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.txtKlNaam.fieldLength = 0
        Me.txtKlNaam.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtKlNaam.forceUppercase = True
        Me.txtKlNaam.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtKlNaam.lIsSearch = False
        Me.txtKlNaam.Location = New System.Drawing.Point(113, 25)
        Me.txtKlNaam.Name = "txtKlNaam"
        Me.txtKlNaam.nIO = b040.IOValues.IOKeyEntryEnable
        Me.txtKlNaam.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtKlNaam.Size = New System.Drawing.Size(262, 21)
        Me.txtKlNaam.TabIndex = 34
        '
        'txtDatumLevering
        '
        Me.txtDatumLevering.fieldLength = 0
        Me.txtDatumLevering.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtDatumLevering.forceUppercase = True
        Me.txtDatumLevering.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtDatumLevering.lIsSearch = False
        Me.txtDatumLevering.Location = New System.Drawing.Point(113, 48)
        Me.txtDatumLevering.Name = "txtDatumLevering"
        Me.txtDatumLevering.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtDatumLevering.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDatumLevering.Size = New System.Drawing.Size(262, 21)
        Me.txtDatumLevering.TabIndex = 1
        '
        'LblBase7
        '
        Me.LblBase7.AutoSize = True
        Me.LblBase7.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase7.Location = New System.Drawing.Point(4, 52)
        Me.LblBase7.Name = "LblBase7"
        Me.LblBase7.Size = New System.Drawing.Size(95, 16)
        Me.LblBase7.TabIndex = 33
        Me.LblBase7.Text = "Datum (Levering)"
        '
        'txtKlNr
        '
        Me.txtKlNr.fieldLength = 0
        Me.txtKlNr.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtKlNr.forceUppercase = True
        Me.txtKlNr.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtKlNr.lIsSearch = False
        Me.txtKlNr.Location = New System.Drawing.Point(113, 3)
        Me.txtKlNr.Name = "txtKlNr"
        Me.txtKlNr.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtKlNr.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtKlNr.Size = New System.Drawing.Size(262, 21)
        Me.txtKlNr.TabIndex = 0
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase6.Location = New System.Drawing.Point(4, 7)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(33, 16)
        Me.LblBase6.TabIndex = 31
        Me.LblBase6.Text = "Klant"
        '
        'txtAfrekeningCopijen
        '
        Me.txtAfrekeningCopijen.fieldLength = 0
        Me.txtAfrekeningCopijen.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtAfrekeningCopijen.forceUppercase = True
        Me.txtAfrekeningCopijen.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtAfrekeningCopijen.lIsSearch = False
        Me.txtAfrekeningCopijen.Location = New System.Drawing.Point(113, 117)
        Me.txtAfrekeningCopijen.Name = "txtAfrekeningCopijen"
        Me.txtAfrekeningCopijen.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtAfrekeningCopijen.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtAfrekeningCopijen.Size = New System.Drawing.Size(262, 21)
        Me.txtAfrekeningCopijen.TabIndex = 4
        '
        'LblBase10
        '
        Me.LblBase10.AutoSize = True
        Me.LblBase10.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase10.Location = New System.Drawing.Point(4, 121)
        Me.LblBase10.Name = "LblBase10"
        Me.LblBase10.Size = New System.Drawing.Size(110, 16)
        Me.LblBase10.TabIndex = 25
        Me.LblBase10.Text = "Afrekening (copijen)"
        '
        'txtVervoerCopijen
        '
        Me.txtVervoerCopijen.fieldLength = 0
        Me.txtVervoerCopijen.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtVervoerCopijen.forceUppercase = True
        Me.txtVervoerCopijen.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtVervoerCopijen.lIsSearch = False
        Me.txtVervoerCopijen.Location = New System.Drawing.Point(113, 94)
        Me.txtVervoerCopijen.Name = "txtVervoerCopijen"
        Me.txtVervoerCopijen.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtVervoerCopijen.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtVervoerCopijen.Size = New System.Drawing.Size(262, 21)
        Me.txtVervoerCopijen.TabIndex = 3
        '
        'txtTour
        '
        Me.txtTour.fieldLength = 0
        Me.txtTour.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtTour.forceUppercase = True
        Me.txtTour.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtTour.lIsSearch = False
        Me.txtTour.Location = New System.Drawing.Point(113, 71)
        Me.txtTour.Name = "txtTour"
        Me.txtTour.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtTour.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtTour.Size = New System.Drawing.Size(262, 21)
        Me.txtTour.TabIndex = 2
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(-34, 46)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(43, 16)
        Me.LblBase1.TabIndex = 4
        Me.LblBase1.Text = "Printer"
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase4.Location = New System.Drawing.Point(4, 99)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(96, 16)
        Me.LblBase4.TabIndex = 16
        Me.LblBase4.Text = "Vervoer (copijen)"
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase2.Location = New System.Drawing.Point(4, 75)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(30, 16)
        Me.LblBase2.TabIndex = 14
        Me.LblBase2.Text = "Tour"
        '
        'PnlBase2
        '
        Me.PnlBase2.BackColor = System.Drawing.Color.Silver
        Me.PnlBase2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase2.Controls.Add(Me.particulierenCheckbox)
        Me.PnlBase2.Controls.Add(Me.LblBase8)
        Me.PnlBase2.Controls.Add(Me.AfdrukkenPerTourCheckbox)
        Me.PnlBase2.Controls.Add(Me.LblBase13)
        Me.PnlBase2.Controls.Add(Me.LblBase15)
        Me.PnlBase2.Location = New System.Drawing.Point(1, 148)
        Me.PnlBase2.Name = "PnlBase2"
        Me.PnlBase2.Size = New System.Drawing.Size(385, 36)
        Me.PnlBase2.TabIndex = 1
        '
        'particulierenCheckbox
        '
        Me.particulierenCheckbox.BackColor = System.Drawing.Color.White
        Me.particulierenCheckbox.Checked = True
        Me.particulierenCheckbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.particulierenCheckbox.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.particulierenCheckbox.ForeColor = System.Drawing.Color.DarkBlue
        Me.particulierenCheckbox.Location = New System.Drawing.Point(112, 4)
        Me.particulierenCheckbox.Name = "particulierenCheckbox"
        Me.particulierenCheckbox.nIO = b040.IOValues.IOAlwaysEnable
        Me.particulierenCheckbox.Size = New System.Drawing.Size(21, 21)
        Me.particulierenCheckbox.TabIndex = 0
        Me.particulierenCheckbox.UseVisualStyleBackColor = False
        '
        'LblBase8
        '
        Me.LblBase8.AutoSize = True
        Me.LblBase8.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase8.Location = New System.Drawing.Point(3, 7)
        Me.LblBase8.Name = "LblBase8"
        Me.LblBase8.Size = New System.Drawing.Size(72, 16)
        Me.LblBase8.TabIndex = 37
        Me.LblBase8.Text = "Particulieren"
        '
        'AfdrukkenPerTourCheckbox
        '
        Me.AfdrukkenPerTourCheckbox.BackColor = System.Drawing.Color.White
        Me.AfdrukkenPerTourCheckbox.Checked = True
        Me.AfdrukkenPerTourCheckbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AfdrukkenPerTourCheckbox.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AfdrukkenPerTourCheckbox.ForeColor = System.Drawing.Color.DarkBlue
        Me.AfdrukkenPerTourCheckbox.Location = New System.Drawing.Point(321, 4)
        Me.AfdrukkenPerTourCheckbox.Name = "AfdrukkenPerTourCheckbox"
        Me.AfdrukkenPerTourCheckbox.nIO = b040.IOValues.IOAlwaysEnable
        Me.AfdrukkenPerTourCheckbox.Size = New System.Drawing.Size(21, 21)
        Me.AfdrukkenPerTourCheckbox.TabIndex = 1
        Me.AfdrukkenPerTourCheckbox.UseVisualStyleBackColor = False
        '
        'LblBase13
        '
        Me.LblBase13.AutoSize = True
        Me.LblBase13.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase13.Location = New System.Drawing.Point(-34, 46)
        Me.LblBase13.Name = "LblBase13"
        Me.LblBase13.Size = New System.Drawing.Size(43, 16)
        Me.LblBase13.TabIndex = 4
        Me.LblBase13.Text = "Printer"
        '
        'LblBase15
        '
        Me.LblBase15.AutoSize = True
        Me.LblBase15.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase15.Location = New System.Drawing.Point(193, 7)
        Me.LblBase15.Name = "LblBase15"
        Me.LblBase15.Size = New System.Drawing.Size(104, 16)
        Me.LblBase15.TabIndex = 15
        Me.LblBase15.Text = "Afdrukken per Tour"
        '
        'frmAfdrukkenVervoerEnAfrekiningen
        '
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(389, 211)
        Me.Controls.Add(Me.PnlBase2)
        Me.Controls.Add(Me.PnlBase1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormMode = b040.ModeValues.RecordEntry
        Me.Name = "frmAfdrukkenVervoerEnAfrekiningen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch Afdrukken Bestel Documenten"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.PnlBase2.ResumeLayout(False)
        Me.PnlBase2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As b040.btnBase
    Friend WithEvents btnCancel As b040.btnBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents txtAfrekeningCopijen As b040.txtBase
    Friend WithEvents LblBase10 As b040.lblBase
    Friend WithEvents txtVervoerCopijen As b040.txtBase
    Friend WithEvents txtTour As b040.txtBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents txtKlNaam As b040.txtBase
    Friend WithEvents txtDatumLevering As b040.txtBaseDate
    Friend WithEvents LblBase7 As b040.lblBase
    Friend WithEvents LblBase6 As b040.lblBase
    Friend WithEvents txtKlNr As b040.txtBase
    Friend WithEvents PnlBase2 As b040.pnlBase
    Friend WithEvents particulierenCheckbox As b040.checkboxBase
    Friend WithEvents LblBase8 As b040.lblBase
    Friend WithEvents AfdrukkenPerTourCheckbox As b040.checkboxBase
    Friend WithEvents LblBase13 As b040.lblBase
    Friend WithEvents LblBase15 As b040.lblBase

End Class
