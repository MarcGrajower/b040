<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BestelHardcopyRequestFrm
    Inherits frmB040


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
        Me.PnlBase1 = New b040.pnlBase()
        Me.ParticulierJaNeen = New b040.cbobaseJaNeen()
        Me.LblBase1 = New b040.lblBase()
        Me.LblBase6 = New b040.lblBase()
        Me.UitzondelijkPrinter = New b040.cboBase()
        Me.Uitzonderlijk = New b040.cbobaseJaNeen()
        Me.LblBase5 = New b040.lblBase()
        Me.Faktuur = New b040.txtBaseNumeric()
        Me.LblBase11 = New b040.lblBase()
        Me.Afrekening = New b040.txtBaseNumeric()
        Me.LblBase10 = New b040.lblBase()
        Me.Vervoer = New b040.txtBaseNumeric()
        Me.TourCtl = New b040.txtBaseNumeric()
        Me.AfdrukkenTour = New b040.cbobaseJaNeen()
        Me.LblBase9 = New b040.lblBase()
        Me.cboPrinters = New b040.cboBase()
        Me.LblBase4 = New b040.lblBase()
        Me.LblBase3 = New b040.lblBase()
        Me.LblBase2 = New b040.lblBase()
        Me.btnCancel = New b040.btnBase()
        Me.btnOK = New b040.btnBase()
        Me.lblFactNr = New b040.lblBase()
        Me.epson_button = New b040.btnBase()
        Me.PnlBase1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.ParticulierJaNeen)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.LblBase6)
        Me.PnlBase1.Controls.Add(Me.UitzondelijkPrinter)
        Me.PnlBase1.Controls.Add(Me.Uitzonderlijk)
        Me.PnlBase1.Controls.Add(Me.LblBase5)
        Me.PnlBase1.Controls.Add(Me.Faktuur)
        Me.PnlBase1.Controls.Add(Me.LblBase11)
        Me.PnlBase1.Controls.Add(Me.Afrekening)
        Me.PnlBase1.Controls.Add(Me.LblBase10)
        Me.PnlBase1.Controls.Add(Me.Vervoer)
        Me.PnlBase1.Controls.Add(Me.TourCtl)
        Me.PnlBase1.Controls.Add(Me.AfdrukkenTour)
        Me.PnlBase1.Controls.Add(Me.LblBase9)
        Me.PnlBase1.Controls.Add(Me.cboPrinters)
        Me.PnlBase1.Controls.Add(Me.LblBase4)
        Me.PnlBase1.Controls.Add(Me.LblBase3)
        Me.PnlBase1.Controls.Add(Me.LblBase2)
        Me.PnlBase1.Location = New System.Drawing.Point(4, 4)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(385, 204)
        Me.PnlBase1.TabIndex = 9
        '
        'ParticulierJaNeen
        '
        Me.ParticulierJaNeen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ParticulierJaNeen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ParticulierJaNeen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ParticulierJaNeen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ParticulierJaNeen.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ParticulierJaNeen.ForeColor = System.Drawing.Color.DarkBlue
        Me.ParticulierJaNeen.FormattingEnabled = True
        Me.ParticulierJaNeen.Location = New System.Drawing.Point(128, 175)
        Me.ParticulierJaNeen.Name = "ParticulierJaNeen"
        Me.ParticulierJaNeen.nIO = b040.IOValues.IOAlwaysEnable
        Me.ParticulierJaNeen.setAutocomplete = False
        Me.ParticulierJaNeen.Size = New System.Drawing.Size(252, 22)
        Me.ParticulierJaNeen.TabIndex = 34
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase1.Location = New System.Drawing.Point(4, 179)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(65, 18)
        Me.LblBase1.TabIndex = 33
        Me.LblBase1.Text = "Particulier"
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase6.Location = New System.Drawing.Point(4, 157)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(82, 18)
        Me.LblBase6.TabIndex = 32
        Me.LblBase6.Text = "Epson Printer"
        '
        'UitzondelijkPrinter
        '
        Me.UitzondelijkPrinter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.UitzondelijkPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.UitzondelijkPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.UitzondelijkPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UitzondelijkPrinter.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UitzondelijkPrinter.ForeColor = System.Drawing.Color.DarkBlue
        Me.UitzondelijkPrinter.FormattingEnabled = True
        Me.UitzondelijkPrinter.Location = New System.Drawing.Point(128, 153)
        Me.UitzondelijkPrinter.Name = "UitzondelijkPrinter"
        Me.UitzondelijkPrinter.nIO = b040.IOValues.IOAlwaysEnable
        Me.UitzondelijkPrinter.setAutocomplete = False
        Me.UitzondelijkPrinter.Size = New System.Drawing.Size(252, 22)
        Me.UitzondelijkPrinter.TabIndex = 8
        '
        'Uitzonderlijk
        '
        Me.Uitzonderlijk.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Uitzonderlijk.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Uitzonderlijk.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Uitzonderlijk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Uitzonderlijk.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Uitzonderlijk.ForeColor = System.Drawing.Color.DarkBlue
        Me.Uitzonderlijk.FormattingEnabled = True
        Me.Uitzonderlijk.Location = New System.Drawing.Point(128, 131)
        Me.Uitzonderlijk.Name = "Uitzonderlijk"
        Me.Uitzonderlijk.nIO = b040.IOValues.IOAlwaysEnable
        Me.Uitzonderlijk.setAutocomplete = False
        Me.Uitzonderlijk.Size = New System.Drawing.Size(252, 22)
        Me.Uitzonderlijk.TabIndex = 7
        '
        'LblBase5
        '
        Me.LblBase5.AutoSize = True
        Me.LblBase5.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase5.Location = New System.Drawing.Point(4, 135)
        Me.LblBase5.Name = "LblBase5"
        Me.LblBase5.Size = New System.Drawing.Size(40, 18)
        Me.LblBase5.TabIndex = 29
        Me.LblBase5.Text = "Epson"
        '
        'Faktuur
        '
        Me.Faktuur.fieldLength = 0
        Me.Faktuur.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Faktuur.forceUppercase = True
        Me.Faktuur.ForeColor = System.Drawing.Color.DarkBlue
        Me.Faktuur.lIsSearch = False
        Me.Faktuur.Location = New System.Drawing.Point(128, 110)
        Me.Faktuur.Name = "Faktuur"
        Me.Faktuur.nIO = b040.IOValues.IOAlwaysEnable
        Me.Faktuur.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Faktuur.Size = New System.Drawing.Size(252, 21)
        Me.Faktuur.TabIndex = 6
        '
        'LblBase11
        '
        Me.LblBase11.AutoSize = True
        Me.LblBase11.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase11.Location = New System.Drawing.Point(4, 114)
        Me.LblBase11.Name = "LblBase11"
        Me.LblBase11.Size = New System.Drawing.Size(104, 18)
        Me.LblBase11.TabIndex = 27
        Me.LblBase11.Text = "Faktuur (copijen)"
        '
        'Afrekening
        '
        Me.Afrekening.fieldLength = 0
        Me.Afrekening.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Afrekening.forceUppercase = True
        Me.Afrekening.ForeColor = System.Drawing.Color.DarkBlue
        Me.Afrekening.lIsSearch = False
        Me.Afrekening.Location = New System.Drawing.Point(128, 89)
        Me.Afrekening.Name = "Afrekening"
        Me.Afrekening.nIO = b040.IOValues.IOAlwaysEnable
        Me.Afrekening.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Afrekening.Size = New System.Drawing.Size(252, 21)
        Me.Afrekening.TabIndex = 5
        '
        'LblBase10
        '
        Me.LblBase10.AutoSize = True
        Me.LblBase10.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase10.Location = New System.Drawing.Point(4, 93)
        Me.LblBase10.Name = "LblBase10"
        Me.LblBase10.Size = New System.Drawing.Size(121, 18)
        Me.LblBase10.TabIndex = 25
        Me.LblBase10.Text = "Afrekening (copijen)"
        '
        'Vervoer
        '
        Me.Vervoer.fieldLength = 0
        Me.Vervoer.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Vervoer.forceUppercase = True
        Me.Vervoer.ForeColor = System.Drawing.Color.DarkBlue
        Me.Vervoer.lIsSearch = False
        Me.Vervoer.Location = New System.Drawing.Point(128, 68)
        Me.Vervoer.Name = "Vervoer"
        Me.Vervoer.nIO = b040.IOValues.IOAlwaysEnable
        Me.Vervoer.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Vervoer.Size = New System.Drawing.Size(252, 21)
        Me.Vervoer.TabIndex = 4
        '
        'TourCtl
        '
        Me.TourCtl.fieldLength = 0
        Me.TourCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TourCtl.forceUppercase = True
        Me.TourCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.TourCtl.lIsSearch = False
        Me.TourCtl.Location = New System.Drawing.Point(128, 25)
        Me.TourCtl.Name = "TourCtl"
        Me.TourCtl.nIO = b040.IOValues.IOAlwaysEnable
        Me.TourCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TourCtl.Size = New System.Drawing.Size(252, 21)
        Me.TourCtl.TabIndex = 2
        '
        'AfdrukkenTour
        '
        Me.AfdrukkenTour.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.AfdrukkenTour.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AfdrukkenTour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.AfdrukkenTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AfdrukkenTour.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.AfdrukkenTour.ForeColor = System.Drawing.Color.DarkBlue
        Me.AfdrukkenTour.FormattingEnabled = True
        Me.AfdrukkenTour.Location = New System.Drawing.Point(128, 46)
        Me.AfdrukkenTour.Name = "AfdrukkenTour"
        Me.AfdrukkenTour.nIO = b040.IOValues.IOAlwaysEnable
        Me.AfdrukkenTour.setAutocomplete = False
        Me.AfdrukkenTour.Size = New System.Drawing.Size(252, 22)
        Me.AfdrukkenTour.TabIndex = 3
        '
        'LblBase9
        '
        Me.LblBase9.AutoSize = True
        Me.LblBase9.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase9.Location = New System.Drawing.Point(4, 7)
        Me.LblBase9.Name = "LblBase9"
        Me.LblBase9.Size = New System.Drawing.Size(46, 18)
        Me.LblBase9.TabIndex = 21
        Me.LblBase9.Text = "Printer"
        '
        'cboPrinters
        '
        Me.cboPrinters.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPrinters.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPrinters.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinters.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cboPrinters.ForeColor = System.Drawing.Color.DarkBlue
        Me.cboPrinters.FormattingEnabled = True
        Me.cboPrinters.Location = New System.Drawing.Point(128, 3)
        Me.cboPrinters.Name = "cboPrinters"
        Me.cboPrinters.nIO = b040.IOValues.IOAlwaysEnable
        Me.cboPrinters.setAutocomplete = False
        Me.cboPrinters.Size = New System.Drawing.Size(252, 22)
        Me.cboPrinters.TabIndex = 1
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase4.Location = New System.Drawing.Point(4, 72)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(104, 18)
        Me.LblBase4.TabIndex = 16
        Me.LblBase4.Text = "Vervoer (copijen)"
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase3.Location = New System.Drawing.Point(4, 50)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(116, 18)
        Me.LblBase3.TabIndex = 15
        Me.LblBase3.Text = "Afdrukken per Tour"
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase2.Location = New System.Drawing.Point(4, 29)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(33, 18)
        Me.LblBase2.TabIndex = 14
        Me.LblBase2.Text = "Tour"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Silver
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(315, 209)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.nIO = b040.IOValues.IOAlwaysEnable
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Annuleren"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Silver
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnOK.Location = New System.Drawing.Point(5, 209)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "Afdrukken"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lblFactNr
        '
        Me.lblFactNr.AutoSize = True
        Me.lblFactNr.BackColor = System.Drawing.Color.Maroon
        Me.lblFactNr.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactNr.ForeColor = System.Drawing.Color.Yellow
        Me.lblFactNr.Location = New System.Drawing.Point(100, 194)
        Me.lblFactNr.Name = "lblFactNr"
        Me.lblFactNr.Size = New System.Drawing.Size(0, 18)
        Me.lblFactNr.TabIndex = 10
        Me.lblFactNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'epson_button
        '
        Me.epson_button.BackColor = System.Drawing.Color.Silver
        Me.epson_button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.epson_button.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.epson_button.Location = New System.Drawing.Point(80, 209)
        Me.epson_button.Name = "epson_button"
        Me.epson_button.nIO = b040.IOValues.IOKeyEntryEnable
        Me.epson_button.Size = New System.Drawing.Size(75, 23)
        Me.epson_button.TabIndex = 11
        Me.epson_button.Text = "Epson"
        Me.epson_button.UseVisualStyleBackColor = False
        '
        'BestelHardcopyRequestFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(391, 234)
        Me.Controls.Add(Me.epson_button)
        Me.Controls.Add(Me.lblFactNr)
        Me.Controls.Add(Me.PnlBase1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "BestelHardcopyRequestFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Afdrukken"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As b040.btnBase
    Friend WithEvents btnCancel As b040.btnBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents LblBase3 As b040.lblBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents cboPrinters As cboBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents LblBase9 As b040.lblBase
    Friend WithEvents LblBase6 As b040.lblBase
    Friend WithEvents UitzondelijkPrinter As cboBase
    Friend WithEvents Uitzonderlijk As cbobaseJaNeen
    Friend WithEvents LblBase5 As b040.lblBase
    Friend WithEvents Faktuur As txtBaseNumeric
    Friend WithEvents LblBase11 As b040.lblBase
    Friend WithEvents Afrekening As txtBaseNumeric
    Friend WithEvents LblBase10 As b040.lblBase
    Friend WithEvents Vervoer As txtBaseNumeric
    Friend WithEvents TourCtl As txtBaseNumeric
    Friend WithEvents AfdrukkenTour As cbobaseJaNeen
    Friend WithEvents lblFactNr As b040.lblBase
    Friend WithEvents epson_button As b040.btnBase
    Friend WithEvents ParticulierJaNeen As b040.cbobaseJaNeen
    Friend WithEvents LblBase1 As b040.lblBase
End Class
