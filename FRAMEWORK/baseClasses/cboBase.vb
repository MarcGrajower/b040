Public Class cboBase
    Inherits System.Windows.Forms.ComboBox
    Implements IcontrolIOEnable
    Implements IControlMaskit

    Dim mIO As IOValues
    Dim nSaveColor As Color
    Dim backColorFocus As Color = applicationFocusBackcolor

    Dim backColorDisabled As Color = Color.FromArgb(210, 210, 210)
    Dim backColorEnabled As Color = Color.White
    Dim ioEnabled As Boolean
    Friend previousText As String = ""
    Friend WithEvents t As txtBase
    Friend f As New frmB040
    Dim _setAutocomplete As Boolean = False
    Public Property setAutocomplete() As Boolean
        Set(value As Boolean)
            Me._setAutocomplete = value
            If value = True Then
                AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
                AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
                DropDownStyle = ComboBoxStyle.DropDownList
            Else
                AutoCompleteMode = Windows.Forms.AutoCompleteMode.None
                AutoCompleteSource = Windows.Forms.AutoCompleteSource.None
                DropDownStyle = ComboBoxStyle.DropDown
            End If
        End Set
        Get
            Return _setAutocomplete
        End Get
    End Property
    Private Sub cbobase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        ' this seems to suppress the beep and terminate the field

        Me.f.lastKeycode = Asc(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send(vbTab)
            e.Handled = True
        End If
    End Sub

    'Protected Overrides Sub OnKeypress(ByVal e As KeyPressEventArgs)
    '    Me.f.lastKeycode = Asc(e.KeyChar)
    '    If e.KeyChar = Chr(13) Then
    '        SendKeys.Send(vbTab)
    '        e.Handled = True
    '    End If
    'End Sub
    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        'http://www.emoreau.com/Entries/Articles/2005/07/Colors-of-disabled-controls.aspx
        MyBase.OnEnabledChanged(e)
        If Not Me.Enabled Then
            Me.SetStyle(ControlStyles.UserPaint, True)
        Else
            Me.SetStyle(ControlStyles.UserPaint, False)
        End If
        Me.Invalidate()
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'http://www.emoreau.com/Entries/Articles/2005/07/Colors-of-disabled-controls.aspx
        MyBase.OnPaint(e)
        Dim TextBrush As SolidBrush
        Dim sf As New StringFormat
        'Select Case Me.TextAlign
        '    Case HorizontalAlignment.Center
        '        sf.Alignment = StringAlignment.Center
        '    Case HorizontalAlignment.Left
        '        sf.Alignment = StringAlignment.Near
        '    Case HorizontalAlignment.Right
        '        sf.Alignment = StringAlignment.Far
        'End Select

        Dim rDraw As RectangleF = RectangleF.op_Implicit(Me.ClientRectangle)
        rDraw.Inflate(0, 0)

        If Me.Enabled Then
            TextBrush = New SolidBrush(Me.ForeColor)
        Else
            TextBrush = New SolidBrush(Me.ForeColor)
            Dim BackBrush As New SolidBrush(Me.backColorDisabled)
            e.Graphics.FillRectangle(BackBrush, 0.0F, 0.0F, Me.Width, Me.Height)
        End If
        e.Graphics.DrawString(Me.Text, Me.Font, TextBrush, rDraw, sf)
    End Sub
    Sub ioEnable(ByVal mode As ModeValues) Implements IcontrolIOEnable.ioEnable
        If Me.mIO = IOValues.IOAlwaysEnable Then
            Me.ioEnabled = True
            Me.TabStop = True
            t.Visible = False
            Exit Sub
        End If
        If mode = ModeValues.KeyEntry Then
            If Me.mIO = IOValues.IOKeyEntryEnable Then
                Me.BackColor = Me.backColorEnabled
                Me.ioEnabled = True
                Me.Enabled = True
                t.Enabled = True
                t.Visible = False
            Else
                'Me.Enabled = False
                Me.BackColor = Me.backColorDisabled
                Me.TabStop = False
                Me.t.BringToFront()
                Me.SendToBack()
                t.Enabled = False
                Me.t.Visible = True
                t.Text = Text
            End If
            Exit Sub
        End If
        If mode = ModeValues.RecordEntry Then
            If Me.mIO = IOValues.IOKeyEntryEnable Then
                Me.ioEnabled = False
                ' Me.Enabled = False
                Me.TabStop = False
                Me.BackColor = Me.backColorDisabled
                Me.t.BringToFront()
                Me.t.Visible = True
                Me.t.Text = Me.Text
                Me.t.ioEnable(mode)
            Else
                Me.BackColor = Me.backColorEnabled
                Me.Enabled = True
                'Me.ioEnabled = True
                Me.TabStop = True
                Me.t.Visible = False
                Me.t.Enabled = False
                Me.SelectionLength = 0
            End If
        End If
        ' MG 14/mrt/11
        If Me.mIO = IOValues.IOAlwaysDisable Then
            Me.ioEnabled = False
            ' Me.Enabled = False
            Me.TabStop = False
            Me.BackColor = Me.backColorDisabled
            Me.SendToBack()
            Me.t.BringToFront()
            Me.t.Visible = True
            Me.t.Text = Me.Text
        End If
        If Me.Focused Then
            ' otherwise when you lose focus, lost focus restores the wrong color
            Me.nSaveColor = Me.BackColor
        End If
    End Sub
    Sub New()
        mIO = IOValues.IOAlwaysEnable
        Me.ioEnabled = True
        t = New txtBase
        t.nIO = nIO
    End Sub
    Public Property nIO() As IOValues
        Get
            Return mIO
        End Get
        Set(ByVal value As IOValues)
            mIO = value
        End Set
    End Property
    Private Sub cboBase_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If Me.f Is Nothing Then
            Me.f = Me.FindForm
        End If
        Me.f.lastKeycode = Keys.None
        Me.previousText = ""

        Me.nSaveColor = Me.BackColor
        If Me.Enabled Then
            Me.BackColor = Me.backColorFocus
            Me.SelectAll()
        End If
    End Sub
    Private Sub cboBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.BackColor = Me.nSaveColor
        Me.f.previousControl = Me
    End Sub

    Friend Overridable Sub MaskIt() Implements IControlMaskit.MaskIt
        If Me.DataBindings.Count = 0 Then Exit Sub ' not yet bound
        Dim B As Binding = Me.DataBindings.Item(0)
        Dim c As DataColumn = B.DataSource.datasource.tables(B.DataSource.datamember).columns(B.BindingMemberInfo.BindingField)
        Me.MaxLength = c.MaxLength
    End Sub

    Private Sub cboBase_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        f = FindForm()
        Parent.Controls.Add(t)
        t.Location = Location
        t.Size = Size
        t.Height = Height
        t.Width = Width
        t.Font = Font
        t.ForeColor = ForeColor
        t.nIO = IOValues.IOAlwaysDisable
        For Each b As Binding In DataBindings
            Dim b1 As New Binding(b.PropertyName, b.DataSource, b.BindingMemberInfo.BindingMember)
            t.DataBindings.Add(b1)
        Next
        Try
            t.ioEnable(f.FormMode)
        Catch
        End Try
    End Sub

    'Private Sub cboBase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    Me.f.lastKeycode = e.KeyCode
    '    If e.KeyCode = Keys.Enter Then
    '        SendKeys.Send(vbTab)
    '    End If
    'End Sub
    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        e.DrawBackground()
        If e.State = DrawItemState.Focus Then
            e.DrawFocusRectangle()
        End If
        Dim index = e.Index
        If index < 0 OrElse index >= Items.Count Then
            Return
        End If
        Dim item = Items(index)
        Dim text As String = If((item Is Nothing), "(null)", item.ToString())
        Using brush = New SolidBrush(Color.DarkBlue)
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
            e.Graphics.DrawString(text, Me.Font, brush, e.Bounds)
        End Using
    End Sub
End Class
Public Class cbobaseJaNeen
    Inherits cboBase
    Implements IControlBindingFormat
    Sub New()
        Me.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        Me.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
        Me.DropDownStyle = ComboBoxStyle.DropDown
    End Sub
    Sub BindingFormat() Implements IControlBindingFormat.BindingFormat
        If Me.DataBindings.Count = 0 Then Exit Sub
        Dim B As Binding = Me.DataBindings.Item(0)
        AddHandler B.Format, AddressOf BooleanToJaNeen
        AddHandler B.Parse, AddressOf JaneenToBoolean
    End Sub
    Sub BooleanToJaNeen(ByVal sender As Object, ByVal cEvent As ConvertEventArgs)
        If cEvent.Value Is System.DBNull.Value Then
            cEvent.Value = ""
            Exit Sub
        End If
        cEvent.Value = IIf(cEvent.Value, "Ja", "Neen")
        Me.Text = cEvent.Value
        Me.DisplayMember = cEvent.Value
        Me.SelectedValue = cEvent.Value
        Me.t.Text = cEvent.Value
    End Sub
    Sub JaneenToBoolean(ByVal sender As Object, ByVal cEvent As ConvertEventArgs)
        cEvent.Value = IIf(cEvent.Value = "Ja", True, False)
    End Sub
    Friend Overrides Sub maskit()
        MyBase.MaskIt()
        Dim a() As String = New String() {"Ja", "Neen"} : Me.Items.AddRange(a)
    End Sub
    Sub cast(ByVal l As Boolean)
        Me.Text = IIf(l, "Ja", "Neen")
        Me.t.Text = Me.Text
        Me.DisplayMember = Me.Text
        Me.SelectedValue = Me.Text
    End Sub
    Function cast()
        Return (Me.Text = "Ja")
    End Function
End Class