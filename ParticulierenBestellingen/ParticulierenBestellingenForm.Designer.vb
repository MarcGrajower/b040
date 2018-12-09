<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParticulierenBestellingenForm
    Inherits b040.frmB040

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
        Me.btnCancel = New b040.btnBase()
        Me.LblBase1 = New b040.lblBase()
        Me.leveringMonthCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnOK = New b040.btnBase()
        Me.AnnulerenButton = New b040.btnBase()
        Me.PcPrint1 = New b040.PCPrint()
        Me.LblBase9 = New b040.lblBase()
        Me.copijenTextBox = New b040.txtBaseNumeric()
        Me.LblBase2 = New b040.lblBase()
        Me.BtnBase2 = New b040.btnBase()
        Me.printersCombobox1 = New b040.printersCombobox()
        Me.PnlBase2 = New b040.pnlBase()
        Me.leveringLabel = New System.Windows.Forms.Label()
        Me.PnlBase1.SuspendLayout()
        Me.PnlBase2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.btnCancel)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.leveringMonthCalendar)
        Me.PnlBase1.Location = New System.Drawing.Point(3, 4)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(184, 196)
        Me.PnlBase1.TabIndex = 25
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.btnCancel.Location = New System.Drawing.Point(292, 266)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "Annuleren"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(2, 8)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(52, 16)
        Me.LblBase1.TabIndex = 14
        Me.LblBase1.Text = "Levering"
        '
        'leveringMonthCalendar
        '
        Me.leveringMonthCalendar.AllowDrop = True
        Me.leveringMonthCalendar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.leveringMonthCalendar.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.leveringMonthCalendar.ForeColor = System.Drawing.Color.DarkBlue
        Me.leveringMonthCalendar.Location = New System.Drawing.Point(2, 24)
        Me.leveringMonthCalendar.MaxSelectionCount = 1
        Me.leveringMonthCalendar.Name = "leveringMonthCalendar"
        Me.leveringMonthCalendar.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.btnOK.Location = New System.Drawing.Point(190, 177)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'AnnulerenButton
        '
        Me.AnnulerenButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerenButton.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.AnnulerenButton.Location = New System.Drawing.Point(367, 177)
        Me.AnnulerenButton.Name = "AnnulerenButton"
        Me.AnnulerenButton.nIO = b040.IOValues.IOKeyEntryEnable
        Me.AnnulerenButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerenButton.TabIndex = 1
        Me.AnnulerenButton.Text = "Annuleren"
        Me.AnnulerenButton.UseVisualStyleBackColor = True
        '
        'PcPrint1
        '
        Me.PcPrint1.PrinterFont = Nothing
        Me.PcPrint1.TextToPrint = ""
        '
        'LblBase9
        '
        Me.LblBase9.AutoSize = True
        Me.LblBase9.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase9.Location = New System.Drawing.Point(2, 9)
        Me.LblBase9.Name = "LblBase9"
        Me.LblBase9.Size = New System.Drawing.Size(43, 16)
        Me.LblBase9.TabIndex = 4
        Me.LblBase9.Text = "Printer"
        '
        'copijenTextBox
        '
        Me.copijenTextBox.fieldLength = 0
        Me.copijenTextBox.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.copijenTextBox.forceUppercase = True
        Me.copijenTextBox.ForeColor = System.Drawing.Color.DarkBlue
        Me.copijenTextBox.lIsSearch = False
        Me.copijenTextBox.Location = New System.Drawing.Point(4, 71)
        Me.copijenTextBox.Name = "copijenTextBox"
        Me.copijenTextBox.nIO = b040.IOValues.IOAlwaysEnable
        Me.copijenTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.copijenTextBox.Size = New System.Drawing.Size(238, 26)
        Me.copijenTextBox.TabIndex = 1
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase2.Location = New System.Drawing.Point(4, 55)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(46, 16)
        Me.LblBase2.TabIndex = 15
        Me.LblBase2.Text = "Copijen"
        '
        'BtnBase2
        '
        Me.BtnBase2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.BtnBase2.Location = New System.Drawing.Point(185, 266)
        Me.BtnBase2.Name = "BtnBase2"
        Me.BtnBase2.nIO = b040.IOValues.IOKeyEntryEnable
        Me.BtnBase2.Size = New System.Drawing.Size(75, 23)
        Me.BtnBase2.TabIndex = 26
        Me.BtnBase2.Text = "OK"
        Me.BtnBase2.UseVisualStyleBackColor = True
        '
        'printersCombobox1
        '
        Me.printersCombobox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.printersCombobox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.printersCombobox1.Location = New System.Drawing.Point(0, 20)
        Me.printersCombobox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.printersCombobox1.Name = "printersCombobox1"
        Me.printersCombobox1.Size = New System.Drawing.Size(244, 24)
        Me.printersCombobox1.TabIndex = 0
        '
        'PnlBase2
        '
        Me.PnlBase2.BackColor = System.Drawing.Color.Silver
        Me.PnlBase2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase2.Controls.Add(Me.leveringLabel)
        Me.PnlBase2.Controls.Add(Me.printersCombobox1)
        Me.PnlBase2.Controls.Add(Me.BtnBase2)
        Me.PnlBase2.Controls.Add(Me.LblBase2)
        Me.PnlBase2.Controls.Add(Me.copijenTextBox)
        Me.PnlBase2.Controls.Add(Me.LblBase9)
        Me.PnlBase2.Location = New System.Drawing.Point(189, 4)
        Me.PnlBase2.Name = "PnlBase2"
        Me.PnlBase2.Size = New System.Drawing.Size(258, 170)
        Me.PnlBase2.TabIndex = 28
        '
        'leveringLabel
        '
        Me.leveringLabel.AutoSize = True
        Me.leveringLabel.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.leveringLabel.Location = New System.Drawing.Point(7, 122)
        Me.leveringLabel.Name = "leveringLabel"
        Me.leveringLabel.Size = New System.Drawing.Size(75, 27)
        Me.leveringLabel.TabIndex = 27
        Me.leveringLabel.Text = "Label1"
        '
        'ParticulierenBestellingenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerenButton
        Me.ClientSize = New System.Drawing.Size(448, 206)
        Me.Controls.Add(Me.AnnulerenButton)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.PnlBase2)
        Me.Controls.Add(Me.PnlBase1)
        Me.Name = "ParticulierenBestellingenForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bestellingen Particulieren"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.PnlBase2.ResumeLayout(False)
        Me.PnlBase2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents btnOK As b040.btnBase
    Friend WithEvents btnCancel As b040.btnBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents leveringMonthCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents AnnulerenButton As b040.btnBase
    Friend WithEvents PcPrint1 As b040.PCPrint
    Friend WithEvents LblBase9 As b040.lblBase
    Friend WithEvents copijenTextBox As b040.txtBaseNumeric
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents BtnBase2 As b040.btnBase
    Friend WithEvents printersCombobox1 As b040.printersCombobox
    Friend WithEvents PnlBase2 As b040.pnlBase
    Friend WithEvents leveringLabel As System.Windows.Forms.Label
End Class
