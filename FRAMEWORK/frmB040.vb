Public Class frmB040
    Inherits System.Windows.Forms.Form
    Dim mMode As ModeValues
    Public nLogSession As Long
    Public designWidth As Long
    Public designHeight As Long
    Public lastKeycode As Keys
    Public previousControl As New Control
    Public ModeShow As ModeShow = b040.ModeShow.Modeless
    Public eOpenMode As eFormOpen = eFormOpen.eFormOpenNormal
    Public cParameter As String = ""
    Public grdCurrentlyValidating As grdBase
    Dim oTooltip As New ToolTip

    Public Property FormMode() As ModeValues
        Get
            Return Me.mMode
        End Get
        Set(ByVal value As ModeValues)
            Me.mMode = value
            For Each ctrl As Control In Me.Controls
                If (TypeOf ctrl Is IcontrolIOEnable) Then
                    CType(ctrl, IcontrolIOEnable).ioEnable(value)
                End If
            Next
        End Set
    End Property

    Private Sub frmB040_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        unlockSession(Me.nLogSession)
        frmMain.resetBackgroundColor()
        nLog("Closing", Me.Name)
    End Sub

    Private Sub frmB040_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.lastKeycode = e.KeyCode
        If e.KeyCode = Keys.Home AndAlso e.Control = False AndAlso e.Alt = False AndAlso e.Shift = False Then
            Me.clear()
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Me.lastKeycode = keyData
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub frmB040_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormMode = ModeValues.KeyEntry
        Me.nLogSession = nLog("Opening", Me.Name)
        Me.designHeight = Me.Height
        Me.designWidth = Me.Width
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MasKit()
        Me.oTooltip.ShowAlways = True
        Me.oTooltip.Active = True
    End Sub
    Public Sub setTooltip(ByVal oCtrl As Control, ByVal cText As String)
        Me.oTooltip.SetToolTip(oCtrl, cText)
    End Sub
    Friend Sub MasKit()
        For Each ctrl As Control In Me.Controls
            If (TypeOf ctrl Is IControlMaskit) Then
                CType(ctrl, IControlMaskit).MaskIt()
            End If
            If (TypeOf ctrl Is IControlBindingFormat) Then
                CType(ctrl, IControlBindingFormat).BindingFormat()
            End If
        Next
    End Sub
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'frmB040
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.KeyPreview = True
        Me.Name = "frmB040"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Font = New Font("Trebuchet MS", Me.Font.Size)
        Me.ResumeLayout(False)

    End Sub
    Overridable Sub clear()
        ' MG 23/feb/11
        unlockSession(Me.nLogSession)
    End Sub
    Overridable Function grdValidate(ByVal ctrl As String, ByRef input As String) As Boolean
        Return True
    End Function
    'Overridable Overloads Function grdValidate(ByVal ctrl As String, ByRef input As String, ByVal oGrd As grdBase) As Boolean
    '    Return True
    'End Function

  
    Public Function cActiveControlName() As String
        Dim c As String = "*"
        Try
            c = UCase(Me.ActiveControl.Name)
        Catch ex As Exception
        End Try
        Return c
    End Function
End Class

