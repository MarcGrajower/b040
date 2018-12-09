<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBestellingenAnnulerenPerDag
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
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.btnBestellingenAnnuleren = New b040.btnBase
        Me.btnSluiten = New b040.btnBase
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.PnlBase1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.MonthCalendar1)
        Me.PnlBase1.Location = New System.Drawing.Point(0, 2)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(292, 179)
        Me.PnlBase1.TabIndex = 1
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(62, 6)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 1
        '
        'btnBestellingenAnnuleren
        '
        Me.btnBestellingenAnnuleren.Image = Global.b040.My.Resources.Resources.save
        Me.btnBestellingenAnnuleren.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBestellingenAnnuleren.Location = New System.Drawing.Point(0, 184)
        Me.btnBestellingenAnnuleren.Name = "btnBestellingenAnnuleren"
        Me.btnBestellingenAnnuleren.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnBestellingenAnnuleren.Size = New System.Drawing.Size(82, 23)
        Me.btnBestellingenAnnuleren.TabIndex = 2
        Me.btnBestellingenAnnuleren.Text = "Annuleren"
        Me.btnBestellingenAnnuleren.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBestellingenAnnuleren.UseVisualStyleBackColor = True
        '
        'btnSluiten
        '
        Me.btnSluiten.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSluiten.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.btnSluiten.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSluiten.Location = New System.Drawing.Point(209, 184)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.nIO = b040.IOValues.IOKeyEntryEnable
        Me.btnSluiten.Size = New System.Drawing.Size(82, 23)
        Me.btnSluiten.TabIndex = 3
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSluiten.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(86, 184)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(119, 23)
        Me.ProgressBar1.TabIndex = 4
        '
        'frmBestellingenAnnulerenPerDag
        '
        Me.CancelButton = Me.btnSluiten
        Me.ClientSize = New System.Drawing.Size(292, 209)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnSluiten)
        Me.Controls.Add(Me.btnBestellingenAnnuleren)
        Me.Controls.Add(Me.PnlBase1)
        Me.Name = "frmBestellingenAnnulerenPerDag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bestellingen Annuleren voor één dag"
        Me.PnlBase1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnBestellingenAnnuleren As b040.btnBase
    Friend WithEvents btnSluiten As b040.btnBase
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
