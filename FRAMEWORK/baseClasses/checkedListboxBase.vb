Imports b040
Public Class checkedListboxBase
    Inherits CheckedListBox
    Implements IcontrolIOEnable
    Implements IControlMaskit
    Dim mIO As IOValues
    Dim ioEnabled As Boolean
    Dim nSaveColor As Color
    Dim backColorFocus As Color = applicationFocusBackcolor
    Dim backColorDisabled As Color = Color.FromArgb(210, 210, 210)
    Dim backColorEnabled As Color = Color.White
    Dim f As frmB040
    Public Sub IOEnable(mode As ModeValues) Implements IcontrolIOEnable.ioEnable
        If Me.mIO = IOValues.IOAlwaysEnable Then
            Me.ioEnabled = True
            Me.TabStop = True
            Exit Sub
        End If
        If mode = ModeValues.KeyEntry Then
            If Me.mIO = IOValues.IOKeyEntryEnable Then
                Me.BackColor = Me.backColorEnabled
                Me.ForeColor = Color.DarkBlue
                Me.ioEnabled = True
                Me.Enabled = True
            Else
                Me.BackColor = Me.backColorDisabled
                Me.ForeColor = Color.DarkBlue
                Me.TabStop = False
                Me.Enabled = False
            End If
            Exit Sub
        End If
        If mode = ModeValues.RecordEntry Then
            If Me.mIO = IOValues.IOKeyEntryEnable Then
                Me.ioEnabled = False
                Me.Enabled = False
                Me.TabStop = False
                Me.BackColor = Me.backColorDisabled
                Me.ForeColor = Color.DarkBlue
            Else
                Me.BackColor = Me.backColorEnabled
                Me.ForeColor = Color.DarkBlue
                Me.Enabled = True
                Me.ioEnabled = True
                Me.TabStop = True
            End If
        End If
        If Me.mIO = IOValues.IOAlwaysDisable Then
            Me.ioEnabled = False
            Enabled = False
            Me.TabStop = False
            Me.BackColor = Me.backColorDisabled
            Me.ForeColor = Color.DarkBlue
        End If
        If Me.Focused Then
            ' otherwise when you lose focus, lost focus restores the wrong color
            Me.nSaveColor = Me.BackColor
        End If

    End Sub
    Public Sub MaskIt() Implements IControlMaskit.MaskIt

    End Sub
    Sub New()
        mIO = IOValues.IOAlwaysEnable
        Me.ioEnabled = True
        ' Me.PromptChar = " "
        'Me.ForeColor = Color.DarkBlue
        Me.Font = New Font("Trebuchet MS", 12.0!, FontStyle.Regular)
    End Sub
    Public Property nIO() As IOValues
        Get
            Return mIO
        End Get
        Set(ByVal value As IOValues)
            mIO = value
        End Set
    End Property

    Private Sub checkedListboxBase_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        f = FindForm()
    End Sub

    Private Sub checkedListboxBase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Me.SelectedIndexChanged
        For i As Long = 0 To Me.Items.Count - 1
            If i = SelectedIndex Then
                Me.SetItemChecked(i, True)
            Else
                Me.SetItemChecked(i, False)
            End If
        Next
    End Sub
    Private Sub checkedListboxBase_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.nSaveColor = Me.BackColor
        If Me.Enabled Then
            Me.BackColor = Me.backColorFocus
        End If
    End Sub
    Private Sub checkedListboxBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.BackColor = Me.nSaveColor
    End Sub
    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Using Brush = New SolidBrush(Color.DarkBlue)
            Dim h As Integer = e.Bounds.Height
            Dim center As New Point(h / 2, h / 2)
            Dim radius As Integer = 5
            Dim textRectangle = New Rectangle(h, 1, e.Bounds.Width - h, h)
            Dim pen As New System.Drawing.Pen(Brush)
            For i As Integer = 0 To Items.Count - 1
                Dim center_i As New Point(center.X, center.Y + i * h)

                drawcircle(center_i, radius, e.Graphics, Me.BackColor, True)
                drawcircle(center_i, radius, e.Graphics, Me.ForeColor)
                If i = Me.SelectedIndex Then
                    drawcircle(center_i, radius - 2, e.Graphics, Me.ForeColor, True)
                End If
                textRectangle.Y = i * h + (h - Me.FontHeight) / 2
                e.Graphics.DrawString(Items(i), Me.Font, Brush, textRectangle)
            Next
        End Using
        'If e.State = DrawItemState.Focus Then
        'e.DrawFocusRectangle()
        'End If
        'Dim rectangle As RectangleF = e.Graphics.ClipBounds
        'e.DrawBackground()
        'Dim index = e.Index
        'If index < 0 OrElse index >= Items.Count Then
        '    Return
        'End If
        'e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        'Dim rItem As New Rectangle(20, e.Bounds.Y, e.Bounds.Width - 20, 20)
        'Using brush = New SolidBrush(Color.DarkBlue)
        '    Dim rGlyph As New Rectangle(0, e.Bounds.Y, 20, 20)
        '    If e.Index = Me.SelectedIndex Then
        '        ControlPaint.DrawMenuGlyph(e.Graphics, rGlyph, MenuGlyph.Checkmark)
        '    End If

        '    e.Graphics.DrawString(Me.Items(e.Index).ToString, Me.Font, brush, rItem)
        'End Using
    End Sub
    Private Sub drawcircle(p As Point, r As Integer, g As Graphics, col As Color, Optional fill As Boolean = False)
        Dim top As New Point(p.X - r, p.Y - r)
        Dim diameter As Integer = r * 2
        If fill = False Then
            g.DrawEllipse(New Pen(col), New Rectangle(top.X, top.Y, diameter, diameter))
        Else
            g.FillEllipse(New SolidBrush(col), New Rectangle(top.X, top.Y, diameter, diameter))
        End If
    End Sub
    Private Sub checkedListboxbase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        Me.f.lastKeycode = Asc(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send(vbTab)
            e.Handled = True
        End If
    End Sub
End Class
