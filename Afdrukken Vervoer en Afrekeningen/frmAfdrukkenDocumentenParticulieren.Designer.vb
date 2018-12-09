<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAfdrukkenDocumentenParticulieren
    Inherits System.Windows.Forms.Form

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
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.PnlBase2 = New b040.pnlBase()
        Me.information = New b040.lblBase()
        Me.PnlBase3 = New b040.pnlBase()
        Me.dagLabel = New b040.lblBase()
        Me.OK = New b040.btnBase()
        Me.annuleren = New b040.btnBase()
        Me.PnlBase1.SuspendLayout()
        Me.PnlBase2.SuspendLayout()
        Me.PnlBase3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.MonthCalendar1)
        Me.PnlBase1.Location = New System.Drawing.Point(2, 3)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(177, 167)
        Me.PnlBase1.TabIndex = 0
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(0, 0)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        '
        'PnlBase2
        '
        Me.PnlBase2.BackColor = System.Drawing.Color.Silver
        Me.PnlBase2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase2.Controls.Add(Me.information)
        Me.PnlBase2.Location = New System.Drawing.Point(179, 5)
        Me.PnlBase2.Name = "PnlBase2"
        Me.PnlBase2.Size = New System.Drawing.Size(200, 100)
        Me.PnlBase2.TabIndex = 1
        '
        'LblBase1
        '
        Me.information.BackColor = System.Drawing.Color.Gainsboro
        Me.information.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.information.ForeColor = System.Drawing.Color.Green
        Me.information.Location = New System.Drawing.Point(6, 8)
        Me.information.Name = "LblBase1"
        Me.information.Size = New System.Drawing.Size(176, 72)
        Me.information.TabIndex = 0
        Me.information.Text = "Drukt documenten af van Particulieren op de ""gewone"" printer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PnlBase3
        '
        Me.PnlBase3.BackColor = System.Drawing.Color.Silver
        Me.PnlBase3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase3.Controls.Add(Me.dagLabel)
        Me.PnlBase3.Location = New System.Drawing.Point(179, 105)
        Me.PnlBase3.Name = "PnlBase3"
        Me.PnlBase3.Size = New System.Drawing.Size(200, 63)
        Me.PnlBase3.TabIndex = 2
        '
        'dagLabel
        '
        Me.dagLabel.AutoSize = True
        Me.dagLabel.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Bold)
        Me.dagLabel.Location = New System.Drawing.Point(14, 11)
        Me.dagLabel.Name = "dagLabel"
        Me.dagLabel.Size = New System.Drawing.Size(168, 29)
        Me.dagLabel.TabIndex = 0
        Me.dagLabel.Text = "Donderdag 31"
        Me.dagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OK
        '
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.OK.Image = Global.b040.My.Resources.Resources.PRINT
        Me.OK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OK.Location = New System.Drawing.Point(4, 166)
        Me.OK.Name = "OK"
        Me.OK.nIO = b040.IOValues.IOKeyEntryEnable
        Me.OK.Size = New System.Drawing.Size(73, 23)
        Me.OK.TabIndex = 0
        Me.OK.Text = "OK"
        Me.OK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK.UseVisualStyleBackColor = True
        '
        'annuleren
        '
        Me.annuleren.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.annuleren.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.annuleren.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.annuleren.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.annuleren.Location = New System.Drawing.Point(288, 166)
        Me.annuleren.Name = "annuleren"
        Me.annuleren.nIO = b040.IOValues.IOAlwaysEnable
        Me.annuleren.Size = New System.Drawing.Size(91, 23)
        Me.annuleren.TabIndex = 1
        Me.annuleren.Text = "Annuleren"
        Me.annuleren.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.annuleren.UseVisualStyleBackColor = True
        '
        'frmAfdrukkenDocumentenParticulieren
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.annuleren
        Me.ClientSize = New System.Drawing.Size(384, 193)
        Me.Controls.Add(Me.annuleren)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.PnlBase3)
        Me.Controls.Add(Me.PnlBase2)
        Me.Controls.Add(Me.PnlBase1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAfdrukkenDocumentenParticulieren"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Afdrukken Documenten Particulieren"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase2.ResumeLayout(False)
        Me.PnlBase3.ResumeLayout(False)
        Me.PnlBase3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents PnlBase2 As b040.pnlBase
    Friend WithEvents information As b040.lblBase
    Friend WithEvents PnlBase3 As b040.pnlBase
    Friend WithEvents dagLabel As b040.lblBase
    Friend WithEvents OK As b040.btnBase
    Friend WithEvents annuleren As b040.btnBase
End Class
