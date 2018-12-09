<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutomatischBestellen
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
        Me.components = New System.ComponentModel.Container()
        Me.PnlBase1 = New b040.pnlBase()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.progressbar1 = New System.Windows.Forms.ProgressBar()
        Me.btnOK = New b040.btnBase()
        Me.btnCancel = New b040.btnBase()
        Me.PnlBase2 = New b040.pnlBase()
        Me.TxtType = New b040.txtBase()
        Me.LblBase1 = New b040.lblBase()
        Me.LblBase4 = New b040.lblBase()
        Me.CboStandaard = New b040.cboBase()
        Me.PnlBase3 = New b040.pnlBase()
        Me.LblBase3 = New b040.lblBase()
        Me.afdrukkenParticulieren = New b040.checkboxBase()
        Me.PnlBase4 = New b040.pnlBase()
        Me.datumLabel = New b040.lblBase()
        Me.AfdrukkenLaatsteParticulieren = New b040.btnBase()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PnlBase1.SuspendLayout()
        Me.PnlBase2.SuspendLayout()
        Me.PnlBase3.SuspendLayout()
        Me.PnlBase4.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.MonthCalendar1)
        Me.PnlBase1.Location = New System.Drawing.Point(5, 7)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(192, 174)
        Me.PnlBase1.TabIndex = 0
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(8, 3)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 6
        '
        'progressbar1
        '
        Me.progressbar1.Location = New System.Drawing.Point(124, 184)
        Me.progressbar1.Name = "progressbar1"
        Me.progressbar1.Size = New System.Drawing.Size(310, 25)
        Me.progressbar1.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnOK.Location = New System.Drawing.Point(10, 184)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnOK.Size = New System.Drawing.Size(32, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnCancel.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.btnCancel.Location = New System.Drawing.Point(437, 183)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnCancel.Size = New System.Drawing.Size(31, 26)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'PnlBase2
        '
        Me.PnlBase2.BackColor = System.Drawing.Color.Silver
        Me.PnlBase2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase2.Controls.Add(Me.TxtType)
        Me.PnlBase2.Controls.Add(Me.LblBase1)
        Me.PnlBase2.Controls.Add(Me.LblBase4)
        Me.PnlBase2.Controls.Add(Me.CboStandaard)
        Me.PnlBase2.Location = New System.Drawing.Point(203, 7)
        Me.PnlBase2.Name = "PnlBase2"
        Me.PnlBase2.Size = New System.Drawing.Size(265, 65)
        Me.PnlBase2.TabIndex = 8
        '
        'TxtType
        '
        Me.TxtType.fieldLength = 0
        Me.TxtType.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtType.forceUppercase = True
        Me.TxtType.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtType.lIsSearch = False
        Me.TxtType.Location = New System.Drawing.Point(79, 4)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtType.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtType.Size = New System.Drawing.Size(171, 28)
        Me.TxtType.TabIndex = 1
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(16, 9)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(44, 23)
        Me.LblBase1.TabIndex = 4
        Me.LblBase1.Text = "Type"
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase4.Location = New System.Drawing.Point(16, 31)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(86, 23)
        Me.LblBase4.TabIndex = 3
        Me.LblBase4.Text = "Standaard"
        '
        'CboStandaard
        '
        Me.CboStandaard.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CboStandaard.ForeColor = System.Drawing.Color.DarkBlue
        Me.CboStandaard.FormattingEnabled = True
        Me.CboStandaard.Location = New System.Drawing.Point(79, 27)
        Me.CboStandaard.Name = "CboStandaard"
        Me.CboStandaard.nIO = b040.IOValues.IOAlwaysEnable
        Me.CboStandaard.setAutocomplete = False
        Me.CboStandaard.Size = New System.Drawing.Size(171, 31)
        Me.CboStandaard.TabIndex = 2
        '
        'PnlBase3
        '
        Me.PnlBase3.BackColor = System.Drawing.Color.Silver
        Me.PnlBase3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase3.Controls.Add(Me.LblBase3)
        Me.PnlBase3.Controls.Add(Me.afdrukkenParticulieren)
        Me.PnlBase3.Location = New System.Drawing.Point(203, 73)
        Me.PnlBase3.Name = "PnlBase3"
        Me.PnlBase3.Size = New System.Drawing.Size(265, 33)
        Me.PnlBase3.TabIndex = 10
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase3.Location = New System.Drawing.Point(13, 7)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(308, 23)
        Me.LblBase3.TabIndex = 9
        Me.LblBase3.Text = "Afdrukken Particulieren (Epson Printer)"
        '
        'afdrukkenParticulieren
        '
        Me.afdrukkenParticulieren.BackColor = System.Drawing.SystemColors.Window
        Me.afdrukkenParticulieren.Checked = True
        Me.afdrukkenParticulieren.CheckState = System.Windows.Forms.CheckState.Checked
        Me.afdrukkenParticulieren.Font = New System.Drawing.Font("Trebuchet MS", 12.0!)
        Me.afdrukkenParticulieren.ForeColor = System.Drawing.Color.DarkBlue
        Me.afdrukkenParticulieren.Location = New System.Drawing.Point(232, 5)
        Me.afdrukkenParticulieren.Name = "afdrukkenParticulieren"
        Me.afdrukkenParticulieren.nIO = b040.IOValues.IOAlwaysEnable
        Me.afdrukkenParticulieren.Size = New System.Drawing.Size(18, 18)
        Me.afdrukkenParticulieren.TabIndex = 8
        Me.afdrukkenParticulieren.UseVisualStyleBackColor = False
        '
        'PnlBase4
        '
        Me.PnlBase4.BackColor = System.Drawing.Color.Silver
        Me.PnlBase4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase4.Controls.Add(Me.datumLabel)
        Me.PnlBase4.Location = New System.Drawing.Point(203, 106)
        Me.PnlBase4.Name = "PnlBase4"
        Me.PnlBase4.Size = New System.Drawing.Size(265, 75)
        Me.PnlBase4.TabIndex = 11
        '
        'datumLabel
        '
        Me.datumLabel.AutoSize = True
        Me.datumLabel.Font = New System.Drawing.Font("Trebuchet MS", 24.0!, System.Drawing.FontStyle.Bold)
        Me.datumLabel.Location = New System.Drawing.Point(9, 11)
        Me.datumLabel.Name = "datumLabel"
        Me.datumLabel.Size = New System.Drawing.Size(338, 61)
        Me.datumLabel.TabIndex = 4
        Me.datumLabel.Text = "Donderdag 31"
        '
        'AfdrukkenLaatsteParticulieren
        '
        Me.AfdrukkenLaatsteParticulieren.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.AfdrukkenLaatsteParticulieren.Image = Global.b040.My.Resources.Resources.PRINT
        Me.AfdrukkenLaatsteParticulieren.Location = New System.Drawing.Point(48, 184)
        Me.AfdrukkenLaatsteParticulieren.Name = "AfdrukkenLaatsteParticulieren"
        Me.AfdrukkenLaatsteParticulieren.nIO = b040.IOValues.IOKeyEntryEnable
        Me.AfdrukkenLaatsteParticulieren.Size = New System.Drawing.Size(32, 24)
        Me.AfdrukkenLaatsteParticulieren.TabIndex = 12
        Me.AfdrukkenLaatsteParticulieren.Text = "OK"
        Me.AfdrukkenLaatsteParticulieren.UseVisualStyleBackColor = True
        '
        'frmAutomatischBestellen
        '
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(469, 215)
        Me.Controls.Add(Me.AfdrukkenLaatsteParticulieren)
        Me.Controls.Add(Me.PnlBase4)
        Me.Controls.Add(Me.PnlBase3)
        Me.Controls.Add(Me.PnlBase2)
        Me.Controls.Add(Me.progressbar1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.PnlBase1)
        Me.Name = "frmAutomatischBestellen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Automatisch Bestellen"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase2.ResumeLayout(False)
        Me.PnlBase2.PerformLayout()
        Me.PnlBase3.ResumeLayout(False)
        Me.PnlBase3.PerformLayout()
        Me.PnlBase4.ResumeLayout(False)
        Me.PnlBase4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents btnOK As b040.btnBase
    Friend WithEvents btnCancel As b040.btnBase
    Friend WithEvents progressbar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents PnlBase2 As b040.pnlBase
    Friend WithEvents TxtType As b040.txtBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents CboStandaard As b040.cboBase
    Friend WithEvents PnlBase3 As b040.pnlBase
    Friend WithEvents LblBase3 As b040.lblBase
    Friend WithEvents afdrukkenParticulieren As b040.checkboxBase
    Friend WithEvents PnlBase4 As b040.pnlBase
    Friend WithEvents datumLabel As b040.lblBase
    Friend WithEvents AfdrukkenLaatsteParticulieren As btnBase
    Friend WithEvents ToolTip1 As ToolTip
End Class
