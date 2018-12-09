<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFeestdagen
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFeestdagen))
        Me.FeestdagenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FeestdagenDataset = New b040.FeestdagenDataset
        Me.SaveButton = New b040.btnBase
        Me.deleteButton = New b040.btnBase
        Me.btnExit = New b040.btnBase
        Me.FeestdagenTableAdapter = New b040.FeestdagenDatasetTableAdapters.FeestdagenTableAdapter
        Me.PnlBase1 = New b040.pnlBase
        Me.txtFD_Datum = New b040.txtBaseDate
        Me.Label1 = New System.Windows.Forms.Label
        Me.PnlBase2 = New b040.pnlBase
        Me.txtFD_Naam = New b040.txtBase
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.FeestdagenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FeestdagenDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBase1.SuspendLayout()
        Me.PnlBase2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FeestdagenBindingSource
        '
        Me.FeestdagenBindingSource.DataMember = "Feestdagen"
        Me.FeestdagenBindingSource.DataSource = Me.FeestdagenDataset
        '
        'FeestdagenDataset
        '
        Me.FeestdagenDataset.DataSetName = "FeestdagenDataset"
        Me.FeestdagenDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SaveButton
        '
        Me.SaveButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Image = CType(resources.GetObject("SaveButton.Image"), System.Drawing.Image)
        Me.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveButton.Location = New System.Drawing.Point(3, 73)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 2
        Me.SaveButton.Text = "Bewaar"
        Me.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'deleteButton
        '
        Me.deleteButton.Image = CType(resources.GetObject("deleteButton.Image"), System.Drawing.Image)
        Me.deleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.deleteButton.Location = New System.Drawing.Point(140, 73)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.deleteButton.Size = New System.Drawing.Size(75, 23)
        Me.deleteButton.TabIndex = 3
        Me.deleteButton.Text = "Verwijder"
        Me.deleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(217, 73)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.nIO = b040.IOValues.IOAlwaysEnable
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Sluit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'FeestdagenTableAdapter
        '
        Me.FeestdagenTableAdapter.ClearBeforeFill = True
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.CausesValidation = False
        Me.PnlBase1.Controls.Add(Me.txtFD_Datum)
        Me.PnlBase1.Controls.Add(Me.Label1)
        Me.PnlBase1.Location = New System.Drawing.Point(3, 3)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(289, 30)
        Me.PnlBase1.TabIndex = 1
        '
        'txtFD_Datum
        '
        Me.txtFD_Datum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFD_Datum.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FeestdagenBindingSource, "FD_Datum", True))
        Me.txtFD_Datum.fieldLength = 0
        Me.txtFD_Datum.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtFD_Datum.forceUppercase = True
        Me.txtFD_Datum.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtFD_Datum.HideSelection = False
        Me.txtFD_Datum.Location = New System.Drawing.Point(71, 2)
        Me.txtFD_Datum.Name = "txtFD_Datum"
        Me.txtFD_Datum.nIO = b040.IOValues.IOKeyEntryEnable
        Me.txtFD_Datum.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFD_Datum.Size = New System.Drawing.Size(201, 20)
        Me.txtFD_Datum.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Datum"
        '
        'PnlBase2
        '
        Me.PnlBase2.BackColor = System.Drawing.Color.Silver
        Me.PnlBase2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase2.Controls.Add(Me.txtFD_Naam)
        Me.PnlBase2.Controls.Add(Me.Label2)
        Me.PnlBase2.Location = New System.Drawing.Point(3, 35)
        Me.PnlBase2.Name = "PnlBase2"
        Me.PnlBase2.Size = New System.Drawing.Size(289, 34)
        Me.PnlBase2.TabIndex = 2
        '
        'txtFD_Naam
        '
        Me.txtFD_Naam.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FeestdagenBindingSource, "FD_Naam", True))
        Me.txtFD_Naam.fieldLength = 0
        Me.txtFD_Naam.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtFD_Naam.forceUppercase = True
        Me.txtFD_Naam.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtFD_Naam.Location = New System.Drawing.Point(71, 3)
        Me.txtFD_Naam.Name = "txtFD_Naam"
        Me.txtFD_Naam.nIO = b040.IOValues.IORecordEntryEnable
        Me.txtFD_Naam.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtFD_Naam.Size = New System.Drawing.Size(201, 20)
        Me.txtFD_Naam.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Feestdag"
        '
        'frmFeestdagen
        '
        Me.AutoSize = True
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(303, 102)
        Me.Controls.Add(Me.PnlBase2)
        Me.Controls.Add(Me.PnlBase1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmFeestdagen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Feestdagen"
        Me.TopMost = True
        CType(Me.FeestdagenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FeestdagenDataset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.PnlBase2.ResumeLayout(False)
        Me.PnlBase2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FeestdagenDataset As b040.FeestdagenDataset
    Friend WithEvents FeestdagenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FeestdagenTableAdapter As b040.FeestdagenDatasetTableAdapters.FeestdagenTableAdapter
    Friend WithEvents SaveButton As b040.btnBase
    Friend WithEvents deleteButton As b040.btnBase
    Friend WithEvents btnExit As b040.btnBase
    Friend WithEvents FeestdagenTableAdapter1 As b040.FeestdagenDatasetTableAdapters.FeestdagenTableAdapter
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PnlBase2 As b040.pnlBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFD_Naam As b040.txtBase
    Friend WithEvents txtFD_Datum As b040.txtBaseDate

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class
