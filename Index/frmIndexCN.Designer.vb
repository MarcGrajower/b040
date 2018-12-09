<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndexCN
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnOK = New b040.btnBase
        Me.BtnClose = New b040.btnBase
        Me.grdCN = New b040.grdBase
        Me.colKlant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colArtikel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPercent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colExpostHoev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colExpostBedrag = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNul = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colBestd_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colKL_Nummer = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.grdCN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOK.Image = Global.b040.My.Resources.Resources.save
        Me.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOK.Location = New System.Drawing.Point(2, 559)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.nIO = b040.IOValues.IORecordEntryEnable
        Me.BtnOK.Size = New System.Drawing.Size(75, 23)
        Me.BtnOK.TabIndex = 0
        Me.BtnOK.Text = "OK"
        Me.BtnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.SystemColors.Control
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClose.Location = New System.Drawing.Point(452, 559)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.nIO = b040.IOValues.IORecordEntryEnable
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Sluiten"
        Me.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'grdCN
        '
        Me.grdCN.BackgroundColor = System.Drawing.Color.White
        Me.grdCN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colKlant, Me.colArtikel, Me.colPercent, Me.colExpostHoev, Me.colExpostBedrag, Me.colNul, Me.colBestd_id, Me.colKL_Nummer})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCN.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdCN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grdCN.GridColor = System.Drawing.Color.LightGray
        Me.grdCN.lKeepHighlightOnLostFocus = False
        Me.grdCN.Location = New System.Drawing.Point(0, 0)
        Me.grdCN.Name = "grdCN"
        Me.grdCN.nIO = b040.IOValues.IORecordEntryEnable
        Me.grdCN.ReadOnly = True
        Me.grdCN.RowHeadersVisible = False
        Me.grdCN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdCN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdCN.Size = New System.Drawing.Size(529, 557)
        Me.grdCN.TabIndex = 2
        '
        'colKlant
        '
        Me.colKlant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colKlant.HeaderText = "Klant"
        Me.colKlant.Name = "colKlant"
        Me.colKlant.ReadOnly = True
        '
        'colArtikel
        '
        Me.colArtikel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colArtikel.HeaderText = "Artikel"
        Me.colArtikel.Name = "colArtikel"
        Me.colArtikel.ReadOnly = True
        '
        'colPercent
        '
        Me.colPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colPercent.HeaderText = "Percent"
        Me.colPercent.Name = "colPercent"
        Me.colPercent.ReadOnly = True
        Me.colPercent.Width = 69
        '
        'colExpostHoev
        '
        Me.colExpostHoev.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colExpostHoev.HeaderText = "Hoev"
        Me.colExpostHoev.Name = "colExpostHoev"
        Me.colExpostHoev.ReadOnly = True
        Me.colExpostHoev.Width = 58
        '
        'colExpostBedrag
        '
        Me.colExpostBedrag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colExpostBedrag.HeaderText = "Bedrag"
        Me.colExpostBedrag.Name = "colExpostBedrag"
        Me.colExpostBedrag.ReadOnly = True
        Me.colExpostBedrag.Width = 66
        '
        'colNul
        '
        Me.colNul.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colNul.HeaderText = "Nul!"
        Me.colNul.Name = "colNul"
        Me.colNul.ReadOnly = True
        Me.colNul.Width = 32
        '
        'colBestd_id
        '
        Me.colBestd_id.HeaderText = "best_id"
        Me.colBestd_id.Name = "colBestd_id"
        Me.colBestd_id.ReadOnly = True
        Me.colBestd_id.Visible = False
        '
        'colKL_Nummer
        '
        Me.colKL_Nummer.HeaderText = "KL_Nummer"
        Me.colKL_Nummer.Name = "colKL_Nummer"
        Me.colKL_Nummer.ReadOnly = True
        Me.colKL_Nummer.Visible = False
        '
        'frmIndexCN
        '
        Me.BackColor = System.Drawing.Color.SaddleBrown
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(533, 586)
        Me.Controls.Add(Me.grdCN)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnOK)
        Me.Name = "frmIndexCN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crediet Nota's (Index)"
        CType(Me.grdCN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnOK As b040.btnBase
    Friend WithEvents BtnClose As b040.btnBase
    Friend WithEvents grdCN As b040.grdBase
    Friend WithEvents colKlant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colArtikel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPercent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpostHoev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpostBedrag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNul As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colBestd_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colKL_Nummer As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
