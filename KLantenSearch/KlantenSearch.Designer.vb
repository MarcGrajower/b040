<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KlantenSearch
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
        Me.LblBase1 = New b040.lblBase()
        Me.TelefoonTextBox = New b040.txtBase()
        Me.AdresTextBox = New b040.txtBase()
        Me.LblBase2 = New b040.lblBase()
        Me.PostNrTextBox = New b040.txtBase()
        Me.LblBase3 = New b040.lblBase()
        Me.GemeenteTextBox = New b040.txtBase()
        Me.LblBase4 = New b040.lblBase()
        Me.FaxTextBox = New b040.txtBase()
        Me.LblBase5 = New b040.lblBase()
        Me.GSMTextBox = New b040.txtBase()
        Me.LblBase6 = New b040.lblBase()
        Me.BTW_NRTextbox = New b040.txtBase()
        Me.LblBase7 = New b040.lblBase()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Type_FactTextbox = New b040.txtBase()
        Me.LblBase8 = New b040.lblBase()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 7.8!)
        Me.LblBase1.Location = New System.Drawing.Point(327, 13)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(62, 18)
        Me.LblBase1.TabIndex = 1
        Me.LblBase1.Text = "Telefoon"
        '
        'TelefoonTextBox
        '
        Me.TelefoonTextBox.fieldLength = 0
        Me.TelefoonTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TelefoonTextBox.forceUppercase = True
        Me.TelefoonTextBox.ForeColor = System.Drawing.Color.DarkBlue
        Me.TelefoonTextBox.lIsSearch = False
        Me.TelefoonTextBox.Location = New System.Drawing.Point(402, 13)
        Me.TelefoonTextBox.Name = "TelefoonTextBox"
        Me.TelefoonTextBox.nIO = b040.IOValues.IOAlwaysEnable
        Me.TelefoonTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TelefoonTextBox.Size = New System.Drawing.Size(309, 25)
        Me.TelefoonTextBox.TabIndex = 2
        '
        'AdresTextBox
        '
        Me.AdresTextBox.fieldLength = 0
        Me.AdresTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.AdresTextBox.forceUppercase = True
        Me.AdresTextBox.ForeColor = System.Drawing.Color.DarkBlue
        Me.AdresTextBox.lIsSearch = False
        Me.AdresTextBox.Location = New System.Drawing.Point(402, 44)
        Me.AdresTextBox.Name = "AdresTextBox"
        Me.AdresTextBox.nIO = b040.IOValues.IOAlwaysEnable
        Me.AdresTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.AdresTextBox.Size = New System.Drawing.Size(309, 25)
        Me.AdresTextBox.TabIndex = 4
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 7.8!)
        Me.LblBase2.Location = New System.Drawing.Point(327, 44)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(44, 18)
        Me.LblBase2.TabIndex = 3
        Me.LblBase2.Text = "Adres"
        '
        'PostNrTextBox
        '
        Me.PostNrTextBox.fieldLength = 0
        Me.PostNrTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PostNrTextBox.forceUppercase = True
        Me.PostNrTextBox.ForeColor = System.Drawing.Color.DarkBlue
        Me.PostNrTextBox.lIsSearch = False
        Me.PostNrTextBox.Location = New System.Drawing.Point(402, 75)
        Me.PostNrTextBox.Name = "PostNrTextBox"
        Me.PostNrTextBox.nIO = b040.IOValues.IOAlwaysEnable
        Me.PostNrTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.PostNrTextBox.Size = New System.Drawing.Size(309, 25)
        Me.PostNrTextBox.TabIndex = 6
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Font = New System.Drawing.Font("Trebuchet MS", 7.8!)
        Me.LblBase3.Location = New System.Drawing.Point(327, 75)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(49, 18)
        Me.LblBase3.TabIndex = 5
        Me.LblBase3.Text = "PostNr"
        '
        'GemeenteTextBox
        '
        Me.GemeenteTextBox.fieldLength = 0
        Me.GemeenteTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GemeenteTextBox.forceUppercase = True
        Me.GemeenteTextBox.ForeColor = System.Drawing.Color.DarkBlue
        Me.GemeenteTextBox.lIsSearch = False
        Me.GemeenteTextBox.Location = New System.Drawing.Point(402, 106)
        Me.GemeenteTextBox.Name = "GemeenteTextBox"
        Me.GemeenteTextBox.nIO = b040.IOValues.IOAlwaysEnable
        Me.GemeenteTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.GemeenteTextBox.Size = New System.Drawing.Size(309, 25)
        Me.GemeenteTextBox.TabIndex = 8
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Font = New System.Drawing.Font("Trebuchet MS", 7.8!)
        Me.LblBase4.Location = New System.Drawing.Point(327, 106)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(74, 18)
        Me.LblBase4.TabIndex = 7
        Me.LblBase4.Text = "Gemeente"
        '
        'FaxTextBox
        '
        Me.FaxTextBox.fieldLength = 0
        Me.FaxTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FaxTextBox.forceUppercase = True
        Me.FaxTextBox.ForeColor = System.Drawing.Color.DarkBlue
        Me.FaxTextBox.lIsSearch = False
        Me.FaxTextBox.Location = New System.Drawing.Point(402, 137)
        Me.FaxTextBox.Name = "FaxTextBox"
        Me.FaxTextBox.nIO = b040.IOValues.IOAlwaysEnable
        Me.FaxTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.FaxTextBox.Size = New System.Drawing.Size(309, 25)
        Me.FaxTextBox.TabIndex = 10
        '
        'LblBase5
        '
        Me.LblBase5.AutoSize = True
        Me.LblBase5.Font = New System.Drawing.Font("Trebuchet MS", 7.8!)
        Me.LblBase5.Location = New System.Drawing.Point(327, 137)
        Me.LblBase5.Name = "LblBase5"
        Me.LblBase5.Size = New System.Drawing.Size(29, 18)
        Me.LblBase5.TabIndex = 9
        Me.LblBase5.Text = "Fax"
        '
        'GSMTextBox
        '
        Me.GSMTextBox.fieldLength = 0
        Me.GSMTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GSMTextBox.forceUppercase = True
        Me.GSMTextBox.ForeColor = System.Drawing.Color.DarkBlue
        Me.GSMTextBox.lIsSearch = False
        Me.GSMTextBox.Location = New System.Drawing.Point(402, 168)
        Me.GSMTextBox.Name = "GSMTextBox"
        Me.GSMTextBox.nIO = b040.IOValues.IOAlwaysEnable
        Me.GSMTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.GSMTextBox.Size = New System.Drawing.Size(309, 25)
        Me.GSMTextBox.TabIndex = 12
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Font = New System.Drawing.Font("Trebuchet MS", 7.8!)
        Me.LblBase6.Location = New System.Drawing.Point(327, 168)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(35, 18)
        Me.LblBase6.TabIndex = 11
        Me.LblBase6.Text = "GSM"
        '
        'BTW_NRTextbox
        '
        Me.BTW_NRTextbox.fieldLength = 0
        Me.BTW_NRTextbox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BTW_NRTextbox.forceUppercase = True
        Me.BTW_NRTextbox.ForeColor = System.Drawing.Color.DarkBlue
        Me.BTW_NRTextbox.lIsSearch = False
        Me.BTW_NRTextbox.Location = New System.Drawing.Point(402, 199)
        Me.BTW_NRTextbox.Name = "BTW_NRTextbox"
        Me.BTW_NRTextbox.nIO = b040.IOValues.IOAlwaysEnable
        Me.BTW_NRTextbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.BTW_NRTextbox.Size = New System.Drawing.Size(309, 25)
        Me.BTW_NRTextbox.TabIndex = 14
        '
        'LblBase7
        '
        Me.LblBase7.AutoSize = True
        Me.LblBase7.Font = New System.Drawing.Font("Trebuchet MS", 7.8!)
        Me.LblBase7.Location = New System.Drawing.Point(327, 199)
        Me.LblBase7.Name = "LblBase7"
        Me.LblBase7.Size = New System.Drawing.Size(57, 18)
        Me.LblBase7.TabIndex = 13
        Me.LblBase7.Text = "BTW NR"
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.Location = New System.Drawing.Point(13, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(305, 240)
        Me.DataGridView1.TabIndex = 0
        '
        'Type_FactTextbox
        '
        Me.Type_FactTextbox.fieldLength = 0
        Me.Type_FactTextbox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Type_FactTextbox.forceUppercase = True
        Me.Type_FactTextbox.ForeColor = System.Drawing.Color.DarkBlue
        Me.Type_FactTextbox.lIsSearch = False
        Me.Type_FactTextbox.Location = New System.Drawing.Point(401, 231)
        Me.Type_FactTextbox.Name = "Type_FactTextbox"
        Me.Type_FactTextbox.nIO = b040.IOValues.IOAlwaysEnable
        Me.Type_FactTextbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Type_FactTextbox.Size = New System.Drawing.Size(309, 25)
        Me.Type_FactTextbox.TabIndex = 16
        '
        'LblBase8
        '
        Me.LblBase8.AutoSize = True
        Me.LblBase8.Font = New System.Drawing.Font("Trebuchet MS", 7.8!)
        Me.LblBase8.Location = New System.Drawing.Point(326, 231)
        Me.LblBase8.Name = "LblBase8"
        Me.LblBase8.Size = New System.Drawing.Size(68, 18)
        Me.LblBase8.TabIndex = 15
        Me.LblBase8.Text = "Type Fact"
        '
        'KlantenSearch
        '
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(722, 268)
        Me.Controls.Add(Me.Type_FactTextbox)
        Me.Controls.Add(Me.LblBase8)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BTW_NRTextbox)
        Me.Controls.Add(Me.LblBase7)
        Me.Controls.Add(Me.GSMTextBox)
        Me.Controls.Add(Me.LblBase6)
        Me.Controls.Add(Me.FaxTextBox)
        Me.Controls.Add(Me.LblBase5)
        Me.Controls.Add(Me.GemeenteTextBox)
        Me.Controls.Add(Me.LblBase4)
        Me.Controls.Add(Me.PostNrTextBox)
        Me.Controls.Add(Me.LblBase3)
        Me.Controls.Add(Me.AdresTextBox)
        Me.Controls.Add(Me.LblBase2)
        Me.Controls.Add(Me.TelefoonTextBox)
        Me.Controls.Add(Me.LblBase1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.FormMode = b040.ModeValues.RecordEntry
        Me.Name = "KlantenSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblBase1 As lblBase
    Friend WithEvents TelefoonTextBox As txtBase
    Friend WithEvents AdresTextBox As txtBase
    Friend WithEvents LblBase2 As lblBase
    Friend WithEvents PostNrTextBox As txtBase
    Friend WithEvents LblBase3 As lblBase
    Friend WithEvents GemeenteTextBox As txtBase
    Friend WithEvents LblBase4 As lblBase
    Friend WithEvents FaxTextBox As txtBase
    Friend WithEvents LblBase5 As lblBase
    Friend WithEvents GSMTextBox As txtBase
    Friend WithEvents LblBase6 As lblBase
    Friend WithEvents BTW_NRTextbox As txtBase
    Friend WithEvents LblBase7 As lblBase
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Type_FactTextbox As txtBase
    Friend WithEvents LblBase8 As lblBase
End Class
