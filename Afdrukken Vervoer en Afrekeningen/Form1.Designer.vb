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
        Me.BtnBase1 = New b040.btnBase
        Me.btnCancel = New b040.btnBase
        Me.PnlBase1 = New b040.pnlBase
        Me.txtKlNaam = New b040.txtBaseNumeric
        Me.txtDatumLevering = New b040.txtBaseNumeric
        Me.LblBase7 = New b040.lblBase
        Me.txtKlNr = New b040.txtBaseNumeric
        Me.LblBase6 = New b040.lblBase
        Me.Afrekening = New b040.txtBaseNumeric
        Me.LblBase10 = New b040.lblBase
        Me.Vervoer = New b040.txtBaseNumeric
        Me.TourCtl = New b040.txtBaseNumeric
        Me.AfdrukkenTour = New b040.cbobaseJaNeen
        Me.LblBase1 = New b040.lblBase
        Me.LblBase4 = New b040.lblBase
        Me.LblBase3 = New b040.lblBase
        Me.LblBase2 = New b040.lblBase
        Me.PnlBase1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnBase1
        '
        Me.BtnBase1.BackColor = System.Drawing.Color.Silver
        Me.BtnBase1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnBase1.Location = New System.Drawing.Point(3, 285)
        Me.BtnBase1.Name = "BtnBase1"
        Me.BtnBase1.nIO = b040.IOValues.IOKeyEntryEnable
        Me.BtnBase1.Size = New System.Drawing.Size(75, 23)
        Me.BtnBase1.TabIndex = 9
        Me.BtnBase1.Text = "Afdrukken"
        Me.BtnBase1.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Silver
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(313, 286)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.nIO = b040.IOValues.IOAlwaysEnable
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
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
        Me.PnlBase1.Controls.Add(Me.Afrekening)
        Me.PnlBase1.Controls.Add(Me.LblBase10)
        Me.PnlBase1.Controls.Add(Me.Vervoer)
        Me.PnlBase1.Controls.Add(Me.TourCtl)
        Me.PnlBase1.Controls.Add(Me.AfdrukkenTour)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.LblBase4)
        Me.PnlBase1.Controls.Add(Me.LblBase3)
        Me.PnlBase1.Controls.Add(Me.LblBase2)
        Me.PnlBase1.Location = New System.Drawing.Point(3, 8)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(385, 272)
        Me.PnlBase1.TabIndex = 10
        '
        'txtKlNaam
        '
        Me.txtKlNaam.fieldLength = 0
        Me.txtKlNaam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtKlNaam.forceUppercase = True
        Me.txtKlNaam.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtKlNaam.lIsSearch = False
        Me.txtKlNaam.Location = New System.Drawing.Point(113, 25)
        Me.txtKlNaam.Name = "txtKlNaam"
        Me.txtKlNaam.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtKlNaam.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtKlNaam.Size = New System.Drawing.Size(262, 20)
        Me.txtKlNaam.TabIndex = 34
        '
        'txtDatumLevering
        '
        Me.txtDatumLevering.fieldLength = 0
        Me.txtDatumLevering.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtDatumLevering.forceUppercase = True
        Me.txtDatumLevering.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtDatumLevering.lIsSearch = False
        Me.txtDatumLevering.Location = New System.Drawing.Point(113, 48)
        Me.txtDatumLevering.Name = "txtDatumLevering"
        Me.txtDatumLevering.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtDatumLevering.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtDatumLevering.Size = New System.Drawing.Size(262, 20)
        Me.txtDatumLevering.TabIndex = 32
        '
        'LblBase7
        '
        Me.LblBase7.AutoSize = True
        Me.LblBase7.Location = New System.Drawing.Point(4, 52)
        Me.LblBase7.Name = "LblBase7"
        Me.LblBase7.Size = New System.Drawing.Size(88, 13)
        Me.LblBase7.TabIndex = 33
        Me.LblBase7.Text = "Datum (Levering)"
        '
        'txtKlNr
        '
        Me.txtKlNr.fieldLength = 0
        Me.txtKlNr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtKlNr.forceUppercase = True
        Me.txtKlNr.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtKlNr.lIsSearch = False
        Me.txtKlNr.Location = New System.Drawing.Point(113, 3)
        Me.txtKlNr.Name = "txtKlNr"
        Me.txtKlNr.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtKlNr.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtKlNr.Size = New System.Drawing.Size(262, 20)
        Me.txtKlNr.TabIndex = 30
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Location = New System.Drawing.Point(4, 7)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(31, 13)
        Me.LblBase6.TabIndex = 31
        Me.LblBase6.Text = "Klant"
        '
        'Afrekening
        '
        Me.Afrekening.fieldLength = 0
        Me.Afrekening.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Afrekening.forceUppercase = True
        Me.Afrekening.ForeColor = System.Drawing.Color.DarkBlue
        Me.Afrekening.lIsSearch = False
        Me.Afrekening.Location = New System.Drawing.Point(113, 135)
        Me.Afrekening.Name = "Afrekening"
        Me.Afrekening.nIO = b040.IOValues.IOAlwaysEnable
        Me.Afrekening.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Afrekening.Size = New System.Drawing.Size(262, 20)
        Me.Afrekening.TabIndex = 5
        '
        'LblBase10
        '
        Me.LblBase10.AutoSize = True
        Me.LblBase10.Location = New System.Drawing.Point(4, 141)
        Me.LblBase10.Name = "LblBase10"
        Me.LblBase10.Size = New System.Drawing.Size(101, 13)
        Me.LblBase10.TabIndex = 25
        Me.LblBase10.Text = "Afrekening (copijen)"
        '
        'Vervoer
        '
        Me.Vervoer.fieldLength = 0
        Me.Vervoer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Vervoer.forceUppercase = True
        Me.Vervoer.ForeColor = System.Drawing.Color.DarkBlue
        Me.Vervoer.lIsSearch = False
        Me.Vervoer.Location = New System.Drawing.Point(113, 114)
        Me.Vervoer.Name = "Vervoer"
        Me.Vervoer.nIO = b040.IOValues.IOAlwaysEnable
        Me.Vervoer.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Vervoer.Size = New System.Drawing.Size(262, 20)
        Me.Vervoer.TabIndex = 4
        '
        'TourCtl
        '
        Me.TourCtl.fieldLength = 0
        Me.TourCtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TourCtl.forceUppercase = True
        Me.TourCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.TourCtl.lIsSearch = False
        Me.TourCtl.Location = New System.Drawing.Point(113, 71)
        Me.TourCtl.Name = "TourCtl"
        Me.TourCtl.nIO = b040.IOValues.IOAlwaysEnable
        Me.TourCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TourCtl.Size = New System.Drawing.Size(262, 20)
        Me.TourCtl.TabIndex = 2
        '
        'AfdrukkenTour
        '
        Me.AfdrukkenTour.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.AfdrukkenTour.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AfdrukkenTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AfdrukkenTour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AfdrukkenTour.ForeColor = System.Drawing.Color.DarkBlue
        Me.AfdrukkenTour.FormattingEnabled = True
        Me.AfdrukkenTour.Location = New System.Drawing.Point(113, 92)
        Me.AfdrukkenTour.Name = "AfdrukkenTour"
        Me.AfdrukkenTour.nIO = b040.IOValues.IOAlwaysEnable
        Me.AfdrukkenTour.Size = New System.Drawing.Size(262, 21)
        Me.AfdrukkenTour.TabIndex = 3
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
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Location = New System.Drawing.Point(4, 119)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(87, 13)
        Me.LblBase4.TabIndex = 16
        Me.LblBase4.Text = "Vervoer (copijen)"
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Location = New System.Drawing.Point(4, 97)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(99, 13)
        Me.LblBase3.TabIndex = 15
        Me.LblBase3.Text = "Afdrukken per Tour"
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Location = New System.Drawing.Point(4, 75)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(29, 13)
        Me.LblBase2.TabIndex = 14
        Me.LblBase2.Text = "Tour"
        '
        'frmAfdrukkenVervoerEnAfrekiningen
        '
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(394, 312)
        Me.Controls.Add(Me.PnlBase1)
        Me.Controls.Add(Me.BtnBase1)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmAfdrukkenVervoerEnAfrekiningen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnBase1 As b040.btnBase
    Friend WithEvents btnCancel As b040.btnBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents Afrekening As b040.txtBaseNumeric
    Friend WithEvents LblBase10 As b040.lblBase
    Friend WithEvents Vervoer As b040.txtBaseNumeric
    Friend WithEvents TourCtl As b040.txtBaseNumeric
    Friend WithEvents AfdrukkenTour As b040.cbobaseJaNeen
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents LblBase3 As b040.lblBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents txtKlNaam As b040.txtBaseNumeric
    Friend WithEvents txtDatumLevering As b040.txtBaseNumeric
    Friend WithEvents LblBase7 As b040.lblBase
    Friend WithEvents LblBase6 As b040.lblBase
    Friend WithEvents txtKlNr As b040.txtBaseNumeric

End Class
