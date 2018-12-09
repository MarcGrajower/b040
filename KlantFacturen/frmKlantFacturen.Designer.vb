<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKlantFacturen
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKlantFacturen))
        Me.GrdBase1 = New b040.grdBase()
        Me.PnlBase1 = New b040.pnlBase()
        Me.TxtBase3 = New b040.txtBase()
        Me.LblBase2 = New b040.lblBase()
        Me.TxtBase2 = New b040.txtBase()
        Me.TxtBase1 = New b040.txtBase()
        Me.LblBase1 = New b040.lblBase()
        Me.BtnBase1 = New b040.btnBase()
        Me.excelButton = New b040.btnBase()
        CType(Me.GrdBase1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBase1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrdBase1
        '
        Me.GrdBase1.BackgroundColor = System.Drawing.Color.White
        Me.GrdBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdBase1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdBase1.DefaultCellStyle = DataGridViewCellStyle2
        Me.GrdBase1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.GrdBase1.GridColor = System.Drawing.Color.LightGray
        Me.GrdBase1.lKeepHighlightOnLostFocus = False
        Me.GrdBase1.Location = New System.Drawing.Point(4, 50)
        Me.GrdBase1.Name = "GrdBase1"
        Me.GrdBase1.nIO = b040.IOValues.IORecordEntryEnable
        Me.GrdBase1.RowHeadersVisible = False
        Me.GrdBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdBase1.Size = New System.Drawing.Size(325, 442)
        Me.GrdBase1.TabIndex = 1
        Me.GrdBase1.TabStop = False
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.TxtBase3)
        Me.PnlBase1.Controls.Add(Me.LblBase2)
        Me.PnlBase1.Controls.Add(Me.TxtBase2)
        Me.PnlBase1.Controls.Add(Me.TxtBase1)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Location = New System.Drawing.Point(4, 2)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(325, 47)
        Me.PnlBase1.TabIndex = 0
        '
        'TxtBase3
        '
        Me.TxtBase3.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.TxtBase3.fieldLength = 0
        Me.TxtBase3.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtBase3.forceUppercase = True
        Me.TxtBase3.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtBase3.lIsSearch = False
        Me.TxtBase3.Location = New System.Drawing.Point(249, 0)
        Me.TxtBase3.Name = "TxtBase3"
        Me.TxtBase3.nIO = b040.IOValues.IOAlwaysDisable
        Me.TxtBase3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBase3.Size = New System.Drawing.Size(68, 21)
        Me.TxtBase3.TabIndex = 5
        Me.TxtBase3.TabStop = False
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase2.Location = New System.Drawing.Point(161, 4)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(86, 16)
        Me.LblBase2.TabIndex = 4
        Me.LblBase2.Text = "Waarde Ex BTW"
        '
        'TxtBase2
        '
        Me.TxtBase2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.TxtBase2.fieldLength = 0
        Me.TxtBase2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtBase2.forceUppercase = True
        Me.TxtBase2.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtBase2.lIsSearch = False
        Me.TxtBase2.Location = New System.Drawing.Point(67, 20)
        Me.TxtBase2.Name = "TxtBase2"
        Me.TxtBase2.nIO = b040.IOValues.IOAlwaysDisable
        Me.TxtBase2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBase2.Size = New System.Drawing.Size(251, 21)
        Me.TxtBase2.TabIndex = 3
        Me.TxtBase2.TabStop = False
        '
        'TxtBase1
        '
        Me.TxtBase1.fieldLength = 0
        Me.TxtBase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtBase1.forceUppercase = True
        Me.TxtBase1.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtBase1.lIsSearch = False
        Me.TxtBase1.Location = New System.Drawing.Point(67, 0)
        Me.TxtBase1.Name = "TxtBase1"
        Me.TxtBase1.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtBase1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBase1.Size = New System.Drawing.Size(84, 21)
        Me.TxtBase1.TabIndex = 1
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(31, 4)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(33, 16)
        Me.LblBase1.TabIndex = 0
        Me.LblBase1.Text = "Klant"
        '
        'BtnBase1
        '
        Me.BtnBase1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnBase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.BtnBase1.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.BtnBase1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBase1.Location = New System.Drawing.Point(253, 495)
        Me.BtnBase1.Name = "BtnBase1"
        Me.BtnBase1.nIO = b040.IOValues.IOAlwaysEnable
        Me.BtnBase1.Size = New System.Drawing.Size(75, 23)
        Me.BtnBase1.TabIndex = 2
        Me.BtnBase1.Text = "Sluiten"
        Me.BtnBase1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBase1.UseVisualStyleBackColor = True
        '
        'excelButton
        '
        Me.excelButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.excelButton.Image = CType(resources.GetObject("excelButton.Image"), System.Drawing.Image)
        Me.excelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.excelButton.Location = New System.Drawing.Point(4, 495)
        Me.excelButton.Name = "excelButton"
        Me.excelButton.nIO = b040.IOValues.IOAlwaysEnable
        Me.excelButton.Size = New System.Drawing.Size(105, 23)
        Me.excelButton.TabIndex = 3
        Me.excelButton.Text = "-> Excel (^X)"
        Me.excelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.excelButton.UseVisualStyleBackColor = True
        '
        'frmKlantFacturen
        '
        Me.CancelButton = Me.BtnBase1
        Me.ClientSize = New System.Drawing.Size(331, 521)
        Me.Controls.Add(Me.excelButton)
        Me.Controls.Add(Me.BtnBase1)
        Me.Controls.Add(Me.GrdBase1)
        Me.Controls.Add(Me.PnlBase1)
        Me.Name = "frmKlantFacturen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overzicht Facturen"
        CType(Me.GrdBase1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnBase1 As b040.btnBase
    Friend WithEvents GrdBase1 As b040.grdBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents TxtBase2 As b040.txtBase
    Friend WithEvents TxtBase1 As b040.txtBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents TxtBase3 As b040.txtBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents excelButton As b040.btnBase

End Class
