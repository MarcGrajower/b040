<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndexArtikels
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndexArtikels))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtRekening = New b040.txtBase()
        Me.LblBase1 = New b040.lblBase()
        Me.BtnSectionToggle = New b040.btnBase()
        Me.BtnClose = New b040.btnBase()
        Me.TxtBedrag = New b040.txtBase()
        Me.txtPercent = New b040.txtBase()
        Me.TxtExPost = New b040.txtBase()
        Me.TxtDoel = New b040.txtBase()
        Me.LblBase3 = New b040.lblBase()
        Me.LblBase4 = New b040.lblBase()
        Me.LblBase5 = New b040.lblBase()
        Me.LblBase6 = New b040.lblBase()
        Me.PnlBase1 = New b040.pnlBase()
        Me.GrdArtikels = New b040.grdBase()
        Me.grdArtikelDetails = New b040.grdBase()
        Me.PnlBase1.SuspendLayout()
        CType(Me.GrdArtikels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdArtikelDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRekening
        '
        Me.txtRekening.fieldLength = 0
        Me.txtRekening.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtRekening.forceUppercase = True
        Me.txtRekening.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtRekening.lIsSearch = False
        Me.txtRekening.Location = New System.Drawing.Point(1, 19)
        Me.txtRekening.Name = "txtRekening"
        Me.txtRekening.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtRekening.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtRekening.Size = New System.Drawing.Size(275, 20)
        Me.txtRekening.TabIndex = 0
        Me.txtRekening.TabStop = False
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Location = New System.Drawing.Point(-2, 3)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(53, 13)
        Me.LblBase1.TabIndex = 1
        Me.LblBase1.Text = "Rekening"
        '
        'BtnSectionToggle
        '
        Me.BtnSectionToggle.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSectionToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSectionToggle.Location = New System.Drawing.Point(3, 492)
        Me.BtnSectionToggle.Name = "BtnSectionToggle"
        Me.BtnSectionToggle.nIO = b040.IOValues.IOAlwaysEnable
        Me.BtnSectionToggle.Size = New System.Drawing.Size(116, 23)
        Me.BtnSectionToggle.TabIndex = 0
        Me.BtnSectionToggle.Text = "Section Toggle (F3)"
        Me.BtnSectionToggle.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnClose.Location = New System.Drawing.Point(1041, 490)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.nIO = b040.IOValues.IOAlwaysEnable
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 5
        Me.BtnClose.Text = "Sluit"
        Me.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'TxtBedrag
        '
        Me.TxtBedrag.fieldLength = 0
        Me.TxtBedrag.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtBedrag.forceUppercase = True
        Me.TxtBedrag.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtBedrag.lIsSearch = False
        Me.TxtBedrag.Location = New System.Drawing.Point(278, 19)
        Me.TxtBedrag.Name = "TxtBedrag"
        Me.TxtBedrag.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtBedrag.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtBedrag.Size = New System.Drawing.Size(87, 20)
        Me.TxtBedrag.TabIndex = 6
        Me.TxtBedrag.TabStop = False
        '
        'txtPercent
        '
        Me.txtPercent.fieldLength = 0
        Me.txtPercent.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtPercent.forceUppercase = True
        Me.txtPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtPercent.lIsSearch = False
        Me.txtPercent.Location = New System.Drawing.Point(366, 19)
        Me.txtPercent.Name = "txtPercent"
        Me.txtPercent.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtPercent.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtPercent.Size = New System.Drawing.Size(56, 20)
        Me.txtPercent.TabIndex = 7
        Me.txtPercent.TabStop = False
        '
        'TxtExPost
        '
        Me.TxtExPost.fieldLength = 0
        Me.TxtExPost.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtExPost.forceUppercase = True
        Me.TxtExPost.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtExPost.lIsSearch = False
        Me.TxtExPost.Location = New System.Drawing.Point(511, 19)
        Me.TxtExPost.Name = "TxtExPost"
        Me.TxtExPost.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtExPost.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtExPost.Size = New System.Drawing.Size(80, 20)
        Me.TxtExPost.TabIndex = 8
        Me.TxtExPost.TabStop = False
        '
        'TxtDoel
        '
        Me.TxtDoel.fieldLength = 0
        Me.TxtDoel.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtDoel.forceUppercase = True
        Me.TxtDoel.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtDoel.lIsSearch = False
        Me.TxtDoel.Location = New System.Drawing.Point(423, 19)
        Me.TxtDoel.Name = "TxtDoel"
        Me.TxtDoel.nIO = b040.IOValues.IOAlwaysEnable
        Me.TxtDoel.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtDoel.Size = New System.Drawing.Size(87, 20)
        Me.TxtDoel.TabIndex = 9
        Me.TxtDoel.TabStop = False
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Location = New System.Drawing.Point(279, 3)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(41, 13)
        Me.LblBase3.TabIndex = 11
        Me.LblBase3.Text = "Bedrag"
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Location = New System.Drawing.Point(363, 3)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(44, 13)
        Me.LblBase4.TabIndex = 12
        Me.LblBase4.Text = "Percent"
        '
        'LblBase5
        '
        Me.LblBase5.AutoSize = True
        Me.LblBase5.Location = New System.Drawing.Point(424, 3)
        Me.LblBase5.Name = "LblBase5"
        Me.LblBase5.Size = New System.Drawing.Size(29, 13)
        Me.LblBase5.TabIndex = 13
        Me.LblBase5.Text = "Doel"
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Location = New System.Drawing.Point(514, 3)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(39, 13)
        Me.LblBase6.TabIndex = 14
        Me.LblBase6.Text = "Expost"
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.TxtBedrag)
        Me.PnlBase1.Controls.Add(Me.LblBase4)
        Me.PnlBase1.Controls.Add(Me.LblBase6)
        Me.PnlBase1.Controls.Add(Me.txtRekening)
        Me.PnlBase1.Controls.Add(Me.LblBase5)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.txtPercent)
        Me.PnlBase1.Controls.Add(Me.LblBase3)
        Me.PnlBase1.Controls.Add(Me.TxtExPost)
        Me.PnlBase1.Controls.Add(Me.TxtDoel)
        Me.PnlBase1.Location = New System.Drawing.Point(2, 2)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(1113, 44)
        Me.PnlBase1.TabIndex = 15
        '
        'GrdArtikels
        '
        Me.GrdArtikels.AllowUserToAddRows = False
        Me.GrdArtikels.AllowUserToDeleteRows = False
        Me.GrdArtikels.BackgroundColor = System.Drawing.Color.White
        Me.GrdArtikels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdArtikels.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.GrdArtikels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdArtikels.DefaultCellStyle = DataGridViewCellStyle6
        Me.GrdArtikels.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.GrdArtikels.GridColor = System.Drawing.Color.LightGray
        Me.GrdArtikels.lKeepHighlightOnLostFocus = False
        Me.GrdArtikels.Location = New System.Drawing.Point(3, 46)
        Me.GrdArtikels.Name = "GrdArtikels"
        Me.GrdArtikels.nIO = b040.IOValues.IORecordEntryEnable
        Me.GrdArtikels.ReadOnly = True
        Me.GrdArtikels.RowHeadersVisible = False
        Me.GrdArtikels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GrdArtikels.Size = New System.Drawing.Size(554, 442)
        Me.GrdArtikels.TabIndex = 16
        '
        'grdArtikelDetails
        '
        Me.grdArtikelDetails.AllowUserToAddRows = False
        Me.grdArtikelDetails.AllowUserToDeleteRows = False
        Me.grdArtikelDetails.BackgroundColor = System.Drawing.Color.White
        Me.grdArtikelDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdArtikelDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdArtikelDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdArtikelDetails.DefaultCellStyle = DataGridViewCellStyle8
        Me.grdArtikelDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grdArtikelDetails.GridColor = System.Drawing.Color.LightGray
        Me.grdArtikelDetails.lKeepHighlightOnLostFocus = False
        Me.grdArtikelDetails.Location = New System.Drawing.Point(558, 46)
        Me.grdArtikelDetails.Name = "grdArtikelDetails"
        Me.grdArtikelDetails.nIO = b040.IOValues.IORecordEntryEnable
        Me.grdArtikelDetails.ReadOnly = True
        Me.grdArtikelDetails.RowHeadersVisible = False
        Me.grdArtikelDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdArtikelDetails.Size = New System.Drawing.Size(558, 442)
        Me.grdArtikelDetails.TabIndex = 17
        '
        'frmIndexArtikels
        '
        Me.BackColor = System.Drawing.Color.SaddleBrown
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(1119, 518)
        Me.Controls.Add(Me.grdArtikelDetails)
        Me.Controls.Add(Me.GrdArtikels)
        Me.Controls.Add(Me.PnlBase1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnSectionToggle)
        Me.KeyPreview = True
        Me.Name = "frmIndexArtikels"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artikels (Index)"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        CType(Me.GrdArtikels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdArtikelDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtRekening As b040.txtBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents BtnSectionToggle As b040.btnBase
    Friend WithEvents BtnClose As b040.btnBase
    Friend WithEvents TxtBedrag As b040.txtBase
    Friend WithEvents txtPercent As b040.txtBase
    Friend WithEvents TxtExPost As b040.txtBase
    Friend WithEvents TxtDoel As b040.txtBase
    Friend WithEvents LblBase3 As b040.lblBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents LblBase5 As b040.lblBase
    Friend WithEvents LblBase6 As b040.lblBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents GrdArtikels As b040.grdBase
    Friend WithEvents grdArtikelDetails As b040.grdBase

End Class
