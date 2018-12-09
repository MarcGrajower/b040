<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKlantOperaties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKlantOperaties))
        Me.PnlBase1 = New b040.pnlBase()
        Me.TxtBase2 = New b040.txtBase()
        Me.TxtBase1 = New b040.txtBase()
        Me.LblBase1 = New b040.lblBase()
        Me.GrdBase1 = New b040.grdBase()
        Me.BtnBase1 = New b040.btnBase()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Excel = New b040.btnBase()
        Me.HulpOpenenDocument = New System.Windows.Forms.Label()
        Me.Afdrukken = New b040.btnBase()
        Me.PnlBase1.SuspendLayout()
        CType(Me.GrdBase1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.TxtBase2)
        Me.PnlBase1.Controls.Add(Me.TxtBase1)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Location = New System.Drawing.Point(2, 4)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(325, 47)
        Me.PnlBase1.TabIndex = 0
        '
        'TxtBase2
        '
        Me.TxtBase2.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
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
        Me.TxtBase1.Location = New System.Drawing.Point(67, 1)
        Me.TxtBase1.Name = "TxtBase1"
        Me.TxtBase1.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtBase1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBase1.Size = New System.Drawing.Size(250, 21)
        Me.TxtBase1.TabIndex = 0
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(9, 7)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(33, 16)
        Me.LblBase1.TabIndex = 0
        Me.LblBase1.Text = "Klant"
        '
        'GrdBase1
        '
        Me.GrdBase1.BackgroundColor = System.Drawing.Color.White
        Me.GrdBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdBase1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdBase1.DefaultCellStyle = DataGridViewCellStyle2
        Me.GrdBase1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.GrdBase1.GridColor = System.Drawing.Color.LightGray
        Me.GrdBase1.lKeepHighlightOnLostFocus = False
        Me.GrdBase1.Location = New System.Drawing.Point(2, 52)
        Me.GrdBase1.Name = "GrdBase1"
        Me.GrdBase1.nIO = b040.IOValues.IORecordEntryEnable
        Me.GrdBase1.RowHeadersVisible = False
        Me.GrdBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdBase1.Size = New System.Drawing.Size(325, 442)
        Me.GrdBase1.TabIndex = 1
        Me.GrdBase1.TabStop = False
        '
        'BtnBase1
        '
        Me.BtnBase1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnBase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.BtnBase1.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.BtnBase1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBase1.Location = New System.Drawing.Point(251, 497)
        Me.BtnBase1.Name = "BtnBase1"
        Me.BtnBase1.nIO = b040.IOValues.IOAlwaysEnable
        Me.BtnBase1.Size = New System.Drawing.Size(75, 23)
        Me.BtnBase1.TabIndex = 2
        Me.BtnBase1.Text = "Sluiten"
        Me.BtnBase1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBase1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(194, 522)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(133, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'Excel
        '
        Me.Excel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Excel.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.Excel.ForeColor = System.Drawing.Color.Black
        Me.Excel.Image = CType(resources.GetObject("Excel.Image"), System.Drawing.Image)
        Me.Excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Excel.Location = New System.Drawing.Point(2, 497)
        Me.Excel.Name = "Excel"
        Me.Excel.nIO = b040.IOValues.IOAlwaysEnable
        Me.Excel.Size = New System.Drawing.Size(89, 23)
        Me.Excel.TabIndex = 4
        Me.Excel.Text = "->Excel (^X)"
        Me.Excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Excel.UseVisualStyleBackColor = True
        '
        'HulpOpenenDocument
        '
        Me.HulpOpenenDocument.AutoSize = True
        Me.HulpOpenenDocument.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HulpOpenenDocument.ForeColor = System.Drawing.Color.DarkGreen
        Me.HulpOpenenDocument.Location = New System.Drawing.Point(2, 527)
        Me.HulpOpenenDocument.Name = "HulpOpenenDocument"
        Me.HulpOpenenDocument.Size = New System.Drawing.Size(185, 18)
        Me.HulpOpenenDocument.TabIndex = 5
        Me.HulpOpenenDocument.Text = "RightClick opent het document" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Afdrukken
        '
        Me.Afdrukken.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Afdrukken.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.Afdrukken.ForeColor = System.Drawing.Color.Black
        Me.Afdrukken.Image = Global.b040.My.Resources.Resources.PRINT
        Me.Afdrukken.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Afdrukken.Location = New System.Drawing.Point(94, 497)
        Me.Afdrukken.Name = "Afdrukken"
        Me.Afdrukken.nIO = b040.IOValues.IOAlwaysEnable
        Me.Afdrukken.Size = New System.Drawing.Size(117, 23)
        Me.Afdrukken.TabIndex = 6
        Me.Afdrukken.Text = "Afdrukken (^P)"
        Me.Afdrukken.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Afdrukken.UseVisualStyleBackColor = True
        '
        'frmKlantOperaties
        '
        Me.CancelButton = Me.BtnBase1
        Me.ClientSize = New System.Drawing.Size(330, 544)
        Me.Controls.Add(Me.Afdrukken)
        Me.Controls.Add(Me.HulpOpenenDocument)
        Me.Controls.Add(Me.Excel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.BtnBase1)
        Me.Controls.Add(Me.GrdBase1)
        Me.Controls.Add(Me.PnlBase1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormMode = b040.ModeValues.RecordEntry
        Me.Name = "frmKlantOperaties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operaties"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        CType(Me.GrdBase1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents GrdBase1 As b040.grdBase
    Friend WithEvents TxtBase2 As b040.txtBase
    Friend WithEvents TxtBase1 As b040.txtBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents BtnBase1 As b040.btnBase
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Excel As b040.btnBase
    Friend WithEvents HulpOpenenDocument As System.Windows.Forms.Label
    Friend WithEvents Afdrukken As b040.btnBase

End Class
