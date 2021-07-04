<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailFacturenFrm
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PnlBase1 = New b040.pnlBase()
        Me.LblBase3 = New b040.lblBase()
        Me.FactuurNrTotTxtBase = New b040.txtBase()
        Me.LblBase5 = New b040.lblBase()
        Me.LblBase1 = New b040.lblBase()
        Me.FactuurNrVanTextBase = New b040.txtBase()
        Me.txtAantalFacturen = New b040.txtBase()
        Me.g = New System.Windows.Forms.DataGridView()
        Me.Klant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BTW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Netto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InclColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BtnBase1 = New b040.btnBase()
        Me.BtnBase2 = New b040.btnBase()
        Me.CloseButton = New b040.btnBase()
        Me.PnlBase1.SuspendLayout()
        CType(Me.g, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.AutoSize = True
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.LblBase3)
        Me.PnlBase1.Controls.Add(Me.FactuurNrTotTxtBase)
        Me.PnlBase1.Controls.Add(Me.LblBase5)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.FactuurNrVanTextBase)
        Me.PnlBase1.Controls.Add(Me.txtAantalFacturen)
        Me.PnlBase1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlBase1.Location = New System.Drawing.Point(0, 0)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(680, 48)
        Me.PnlBase1.TabIndex = 39
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase3.Location = New System.Drawing.Point(95, 3)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(90, 16)
        Me.LblBase3.TabIndex = 20
        Me.LblBase3.Text = "Factuur Nt (Tot)"
        '
        'FactuurNrTotTxtBase
        '
        Me.FactuurNrTotTxtBase.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.FactuurNrTotTxtBase.fieldLength = 0
        Me.FactuurNrTotTxtBase.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FactuurNrTotTxtBase.forceUppercase = True
        Me.FactuurNrTotTxtBase.ForeColor = System.Drawing.Color.DarkBlue
        Me.FactuurNrTotTxtBase.lIsSearch = False
        Me.FactuurNrTotTxtBase.Location = New System.Drawing.Point(96, 19)
        Me.FactuurNrTotTxtBase.Name = "FactuurNrTotTxtBase"
        Me.FactuurNrTotTxtBase.nIO = b040.IOValues.IOAlwaysEnable
        Me.FactuurNrTotTxtBase.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.FactuurNrTotTxtBase.Size = New System.Drawing.Size(83, 21)
        Me.FactuurNrTotTxtBase.TabIndex = 19
        Me.FactuurNrTotTxtBase.TabStop = False
        Me.FactuurNrTotTxtBase.ValidatingType = GetType(Date)
        '
        'LblBase5
        '
        Me.LblBase5.AutoSize = True
        Me.LblBase5.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase5.Location = New System.Drawing.Point(194, 4)
        Me.LblBase5.Name = "LblBase5"
        Me.LblBase5.Size = New System.Drawing.Size(39, 16)
        Me.LblBase5.TabIndex = 12
        Me.LblBase5.Text = "Aantal"
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(5, 4)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(92, 16)
        Me.LblBase1.TabIndex = 16
        Me.LblBase1.Text = "Factuur Nt (Van)"
        '
        'FactuurNrVanTextBase
        '
        Me.FactuurNrVanTextBase.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.FactuurNrVanTextBase.fieldLength = 0
        Me.FactuurNrVanTextBase.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FactuurNrVanTextBase.forceUppercase = True
        Me.FactuurNrVanTextBase.ForeColor = System.Drawing.Color.DarkBlue
        Me.FactuurNrVanTextBase.lIsSearch = False
        Me.FactuurNrVanTextBase.Location = New System.Drawing.Point(6, 20)
        Me.FactuurNrVanTextBase.Name = "FactuurNrVanTextBase"
        Me.FactuurNrVanTextBase.nIO = b040.IOValues.IOAlwaysEnable
        Me.FactuurNrVanTextBase.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.FactuurNrVanTextBase.Size = New System.Drawing.Size(83, 21)
        Me.FactuurNrVanTextBase.TabIndex = 15
        Me.FactuurNrVanTextBase.TabStop = False
        Me.FactuurNrVanTextBase.ValidatingType = GetType(Integer)
        '
        'txtAantalFacturen
        '
        Me.txtAantalFacturen.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.txtAantalFacturen.fieldLength = 0
        Me.txtAantalFacturen.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtAantalFacturen.forceUppercase = True
        Me.txtAantalFacturen.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtAantalFacturen.lIsSearch = False
        Me.txtAantalFacturen.Location = New System.Drawing.Point(184, 20)
        Me.txtAantalFacturen.Name = "txtAantalFacturen"
        Me.txtAantalFacturen.nIO = b040.IOValues.IOAlwaysDisable
        Me.txtAantalFacturen.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtAantalFacturen.Size = New System.Drawing.Size(64, 21)
        Me.txtAantalFacturen.TabIndex = 4
        Me.txtAantalFacturen.TabStop = False
        Me.txtAantalFacturen.ValidatingType = GetType(Date)
        '
        'g
        '
        Me.g.AllowUserToAddRows = False
        Me.g.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.g.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.g.BackgroundColor = System.Drawing.Color.White
        Me.g.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.g.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.g.ColumnHeadersHeight = 21
        Me.g.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.g.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Klant, Me.Tr, Me.BTW, Me.Netto, Me.Column1, Me.InclColumn})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Beige
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.g.DefaultCellStyle = DataGridViewCellStyle7
        Me.g.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.g.GridColor = System.Drawing.Color.LightGray
        Me.g.Location = New System.Drawing.Point(-1, 51)
        Me.g.Name = "g"
        Me.g.RowHeadersVisible = False
        Me.g.RowHeadersWidth = 62
        Me.g.RowTemplate.Height = 20
        Me.g.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.g.Size = New System.Drawing.Size(677, 467)
        Me.g.TabIndex = 40
        Me.g.TabStop = False
        '
        'Klant
        '
        Me.Klant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Beige
        Me.Klant.DefaultCellStyle = DataGridViewCellStyle2
        Me.Klant.HeaderText = "Klant"
        Me.Klant.MinimumWidth = 8
        Me.Klant.Name = "Klant"
        Me.Klant.ReadOnly = True
        Me.Klant.Width = 58
        '
        'Tr
        '
        Me.Tr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Tr.DefaultCellStyle = DataGridViewCellStyle3
        Me.Tr.HeaderText = "Naam"
        Me.Tr.MinimumWidth = 8
        Me.Tr.Name = "Tr"
        Me.Tr.ReadOnly = True
        '
        'BTW
        '
        Me.BTW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Format = "##0.00 %"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.BTW.DefaultCellStyle = DataGridViewCellStyle4
        Me.BTW.HeaderText = "E-Mail"
        Me.BTW.MinimumWidth = 8
        Me.BTW.Name = "BTW"
        Me.BTW.Width = 62
        '
        'Netto
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 5)
        Me.Netto.DefaultCellStyle = DataGridViewCellStyle5
        Me.Netto.HeaderText = "Factuur Nr"
        Me.Netto.MinimumWidth = 8
        Me.Netto.Name = "Netto"
        Me.Netto.ReadOnly = True
        Me.Netto.Width = 88
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column1.HeaderText = "Bedrag"
        Me.Column1.MinimumWidth = 8
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 68
        '
        'InclColumn
        '
        Me.InclColumn.HeaderText = "Incl."
        Me.InclColumn.MinimumWidth = 8
        Me.InclColumn.Name = "InclColumn"
        Me.InclColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InclColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.InclColumn.Width = 55
        '
        'BtnBase1
        '
        Me.BtnBase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.BtnBase1.Location = New System.Drawing.Point(-1, 524)
        Me.BtnBase1.Name = "BtnBase1"
        Me.BtnBase1.nIO = b040.IOValues.IOKeyEntryEnable
        Me.BtnBase1.Size = New System.Drawing.Size(75, 23)
        Me.BtnBase1.TabIndex = 41
        Me.BtnBase1.Text = "BtnBase1"
        Me.BtnBase1.UseVisualStyleBackColor = True
        '
        'BtnBase2
        '
        Me.BtnBase2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.BtnBase2.Location = New System.Drawing.Point(70, 524)
        Me.BtnBase2.Name = "BtnBase2"
        Me.BtnBase2.nIO = b040.IOValues.IOKeyEntryEnable
        Me.BtnBase2.Size = New System.Drawing.Size(75, 23)
        Me.BtnBase2.TabIndex = 42
        Me.BtnBase2.Text = "BtnBase2"
        Me.BtnBase2.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.CloseButton.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.CloseButton.Location = New System.Drawing.Point(601, 524)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.nIO = b040.IOValues.IOKeyEntryEnable
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 43
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'EmailFacturenFrm
        '
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(680, 547)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.BtnBase2)
        Me.Controls.Add(Me.BtnBase1)
        Me.Controls.Add(Me.g)
        Me.Controls.Add(Me.PnlBase1)
        Me.Name = "EmailFacturenFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E-mailen Facturen"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        CType(Me.g, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnlBase1 As pnlBase
    Friend WithEvents LblBase1 As lblBase
    Friend WithEvents FactuurNrVanTextBase As txtBase
    Friend WithEvents txtAantalFacturen As txtBase
    Friend WithEvents LblBase3 As lblBase
    Friend WithEvents FactuurNrTotTxtBase As txtBase
    Friend WithEvents LblBase5 As lblBase
    Friend WithEvents g As DataGridView
    Friend WithEvents Klant As DataGridViewTextBoxColumn
    Friend WithEvents Tr As DataGridViewTextBoxColumn
    Friend WithEvents BTW As DataGridViewTextBoxColumn
    Friend WithEvents Netto As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents InclColumn As DataGridViewCheckBoxColumn
    Friend WithEvents BtnBase1 As btnBase
    Friend WithEvents BtnBase2 As btnBase
    Friend WithEvents CloseButton As btnBase
End Class
