Imports System.ComponentModel
Imports System.Globalization
Public Class txtBase
    Inherits System.Windows.Forms.MaskedTextBox
    Implements IcontrolIOEnable
    Implements IControlMaskit

    Dim mIO As IOValues
    Dim nSaveColor As Color
    Public backColorFocus As Color = applicationFocusBackcolor
    Dim backColorDisabled As Color = Color.FromArgb(210, 210, 210)
    Dim backColorEnabled As Color = Color.White
    Dim ioEnabled As Boolean
    Friend previousText As String
    Dim f As New frmB040
    Dim mFieldLength As Integer
    Dim mForceUppercase As Boolean
    Property forceUppercase() As Boolean
        Get
            forceUppercase = mForceUppercase
        End Get
        Set(ByVal value As Boolean)
            mForceUppercase = value
        End Set
    End Property
    Property fieldLength() As Integer
        Get
            fieldLength = mFieldLength
        End Get
        Set(ByVal value As Integer)
            mFieldLength = value
        End Set
    End Property
    Dim mlIsSearch As Boolean
    Public Property lIsSearch() As Boolean
        Get
            lIsSearch = mlIsSearch
        End Get
        Set(ByVal value As Boolean)
            mlIsSearch = value
        End Set
    End Property
    Private Sub txtBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        ' this seems to suppress the beep and terminate the field
        Me.f.lastKeycode = Asc(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send(vbTab)
            e.Handled = True
        End If
    End Sub
    'Private Sub txtBase_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    '    Me.f.lastKeycode = e.KeyCode
    '    If e.KeyCode = Keys.Enter Then
    '        SendKeys.Send(vbTab)
    '        e.Handled   True
    '    End If

    'End Sub
    'Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
    '    ' http://www.syncfusion.com/FAQ/windowsforms/faq_c94c.aspx#q1121q
    '    If e.KeyChar = Chr(13) Then 'CChar(13)
    '        SendKeys.Send(vbTab)
    '        e.Handled = True
    '    Else
    '        MyBase.OnKeyPress(e)
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

        Select Case Me.TextAlign
            Case HorizontalAlignment.Center
                sf.Alignment = StringAlignment.Center
            Case HorizontalAlignment.Left
                sf.Alignment = StringAlignment.Near
            Case HorizontalAlignment.Right
                sf.Alignment = StringAlignment.Far
        End Select

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
            Exit Sub
        End If
        If Me.mIO = IOValues.IOAlwaysDisable Then
            Me.ioEnabled = False
            Me.TabStop = False
            Me.Enabled = False
            Me.BackColor = Me.backColorDisabled
            Me.ForeColor = Color.DarkBlue
            Exit Sub
        End If
        If mode = ModeValues.KeyEntry Then
            If Me.mIO = IOValues.IOKeyEntryEnable Then
                Me.BackColor = Me.backColorEnabled
                Me.ForeColor = Color.DarkBlue
                Me.ioEnabled = True
                Me.Enabled = True
                'Me.TabStop = True
            Else
                Me.BackColor = Me.backColorDisabled
                Me.ForeColor = Color.DarkBlue
                Me.ioEnabled = False
                Me.Enabled = False
                ' Me.TabStop = False
            End If
        End If
        If mode = ModeValues.RecordEntry Then
            If Me.mIO = IOValues.IOKeyEntryEnable Then
                Me.ioEnabled = False
                Me.Enabled = False
                ' Me.TabStop = False
                Me.BackColor = Me.backColorDisabled
                Me.ForeColor = Color.DarkBlue
            Else
                Me.BackColor = Me.backColorEnabled
                Me.ForeColor = Color.DarkBlue
                Me.Enabled = True
                'Me.ioEnabled = True
                Me.TabStop = True
            End If
        End If
        If Me.Focused Then
            ' otherwise when you lose focus, lost focus restores the wrong color
            Me.nSaveColor = Me.BackColor
        End If
    End Sub
    Sub New()
        mIO = IOValues.IOAlwaysEnable
        Me.ioEnabled = True
        Me.PromptChar = " "
        Me.ForeColor = Color.DarkBlue
        Me.Font = New Font("Trebuchet MS", 9.0!, FontStyle.Bold)
        Me.mForceUppercase = True
        Me.AsciiOnly = False
    End Sub
    Public Property nIO() As IOValues
        Get
            Return mIO
        End Get
        Set(ByVal value As IOValues)
            mIO = value
        End Set
    End Property
    Private Sub txtBase_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.f.lastKeycode = Keys.None
        If Me.lIsSearch Then Exit Sub
        Me.previousText = Me.Text
        Me.nSaveColor = Me.BackColor
        If Me.Enabled Then
            Me.BackColor = Me.backColorFocus
            ' MG 27/feb/11
            Me.SelectAll()
            'Me.SelectionStart = 0
            'If Len(Me.Text) = 0 Then
            '    Me.SelectionLength = 0
            'Else
            '    Me.SelectionLength = Len(Me.Text)
            'End If
        End If
    End Sub
    Private Sub txtBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.previousText = Me.Text
        Me.BackColor = Me.nSaveColor
        ' this gives an error at design time when the BestH_DatBest was deleted and then re-created.
        Me.f.previousControl = Me
    End Sub
    Friend Overridable Sub MaskIt() Implements IControlMaskit.MaskIt
        If Me.DataBindings.Count = 0 Then Exit Sub ' not yet bound
        If Me.Mask <> "" Then
            Exit Sub
        End If
        Dim B As Binding = Me.DataBindings.Item(0)
        Dim c As DataColumn = B.DataSource.datasource.tables(B.DataSource.datamember).columns(B.BindingMemberInfo.BindingField)

        Dim ct = c.DataType.ToString
        If ct = "System.String" Then

            Me.Mask = If(Me.mForceUppercase, ">", "") & New String("C", c.MaxLength)
            Me.fieldLength = c.MaxLength
            Exit Sub
        End If
        If ct = "System.DateTime" Then
            ' MG vrijdag 18 februari 2011
            Throw New InvalidOperationException(ct & " should be txtBaseDate.")
            'Dim cDS As String = DateTimeFormatInfo.CurrentInfo.DateSeparator
            'Me.Mask = "##" & cDS & "aaa" & cDS & "##"
            'Exit Sub
        End If
        If ct = "System.Decimal" Then
            Throw New InvalidOperationException(ct & " should be txtBaseNUmeric.")
        End If
    End Sub
    Private Sub txtBase_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        Me.f = Me.FindForm
    End Sub
    'Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
    '    If keyData = Keys.Enter And Me.Text = "" Then
    '        Me.OnValidating(New CancelEventArgs)
    '        Return True
    '    End If
    '    Return MyBase.ProcessDialogKey(keyData)
    'End Function


End Class
Class txtBaseNumeric
    Inherits txtBase
    Implements IControlBindingFormat
    Sub bindingFormat() Implements IControlBindingFormat.BindingFormat
        If Me.DataBindings.Count = 0 Then Exit Sub
        Dim B As Binding = Me.DataBindings.Item(0)
        AddHandler B.Format, AddressOf NumToD2
        AddHandler B.Parse, AddressOf d2ToNum
    End Sub
    Public Sub txtBaseNumeric_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "." Then
            e.KeyChar = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        End If
        '       MyBase.OnKeyPress(e)
    End Sub
    Function NumFormat() As String
        ' there must be a smarter way to do this.
        Dim i As Int16
        Dim c As String = Me.Text
        For i = 1 To Len(c)
            If Mid(c, i, 1) = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator Then
                c = Strings.Left(c, i - 1) & "." & Strings.Right(c, Len(c) - i)
            End If
        Next
        Return Trim(FormatNumber(c, 2))
    End Function
    Sub NumToD2(ByVal sender As Object, ByVal cEvent As ConvertEventArgs)
        If cEvent.Value IsNot System.DBNull.Value Then
            cEvent.Value = Trim(FormatNumber(cEvent.Value, 2))
        Else
            cEvent.Value = ""
        End If

    End Sub
    Sub d2ToNum(ByVal sender As Object, ByVal cEvent As ConvertEventArgs)
        If cEvent.DesiredType Is GetType(Decimal) Then
            ' there must be a smarter way to do this.
            Dim c As String = cEvent.Value
            For i As Integer = 1 To Len(c)
                If Mid(c, i, 1) = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator Then
                    c = Strings.Left(c, i - 1) & "." & Strings.Right(c, Len(Me.Text) - i)
                End If
            Next

            cEvent.Value = Val(c)
        End If
    End Sub
    Friend Overrides Sub maskit()
        Me.Mask = ""
    End Sub
    'Private Sub txtBaseNumeric_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Validated
    '    ' Me.Text = Me.numFormat
    'End Sub
End Class
Class txtBaseDate
    ' MG vrijdag 18 februari 2011
    Inherits txtBase
    Implements IControlBindingFormat
    Sub bindingFormat() Implements IControlBindingFormat.BindingFormat
        If Me.DataBindings.Count = 0 Then Exit Sub
        Dim B As Binding = Me.DataBindings.Item(0)
        AddHandler B.Format, AddressOf DateToText
        AddHandler B.Parse, AddressOf TextToDate
    End Sub
    Sub TextToDate(ByVal sender As Object, ByVal cEvent As ConvertEventArgs)
        ' MG 18/feb/11
        If cEvent.Value IsNot System.DBNull.Value Then
            Try
                cEvent.Value = Date.Parse(cEvent.Value)
            Catch
            End Try

        End If
    End Sub
    Sub DateToText(ByVal sender As Object, ByVal cEvent As ConvertEventArgs)
        If cEvent.Value IsNot DBNull.Value Then
            cEvent.Value = Format(cEvent.Value, cDateFormat)
        End If
    End Sub
    Friend Overrides Sub maskit()
        Dim cDS As String = DateTimeFormatInfo.CurrentInfo.DateSeparator
        Me.Mask = "##" & cDS & "##" & cDS & "##"
        Exit Sub
    End Sub
    Public Function lIsBlank() As Boolean
        Return Me.Text = "  /  /"
    End Function
    Public Function lIsValid() As Boolean
        Dim d As Date
        Dim l As Boolean = True
        Try
            d = CDate(Me.Text)
        Catch ex As Exception
            l = False
        End Try
        Return l
    End Function

End Class
Class txtBaseMultiline
    ' MG 20/apr/11
    Inherits TextBox
    Implements IcontrolIOEnable
    Dim mIo As Integer
    Dim ioEnabled As Boolean

    Dim backColorDisabled As Color = Color.FromArgb(210, 210, 210)
    Dim backColorEnabled As Color = Color.White
    Dim nSaveColor As Color
    Dim backColorFocus As Color = applicationFocusBackcolor


    Sub ioEnable(ByVal mode As ModeValues) Implements IcontrolIOEnable.ioEnable
        If Me.mIo = IOValues.IOAlwaysEnable Then
            Me.ioEnabled = True
            Me.TabStop = True
            Exit Sub
        End If
        If Me.mIo = IOValues.IOAlwaysDisable Then
            Me.ioEnabled = False
            Me.TabStop = False
            Me.Enabled = False
            Me.BackColor = Me.backColorDisabled
            Me.ForeColor = Color.DarkBlue
            Exit Sub
        End If
        If mode = ModeValues.KeyEntry Then
            If Me.mIo = IOValues.IOKeyEntryEnable Then
                Me.BackColor = Me.backColorEnabled
                Me.ForeColor = Color.DarkBlue
                Me.ioEnabled = True
                Me.Enabled = True
                'Me.TabStop = True
            Else
                Me.BackColor = Me.backColorDisabled
                Me.ForeColor = Color.DarkBlue
                Me.ioEnabled = False
                Me.Enabled = False
                ' Me.TabStop = False
            End If
        End If
        If mode = ModeValues.RecordEntry Then
            If Me.mIo = IOValues.IOKeyEntryEnable Then
                Me.ioEnabled = False
                Me.Enabled = False
                ' Me.TabStop = False
                Me.BackColor = Me.backColorDisabled
                Me.ForeColor = Color.DarkBlue
            Else
                Me.BackColor = Me.backColorEnabled
                Me.ForeColor = Color.DarkBlue
                Me.Enabled = True
                'Me.ioEnabled = True
                Me.TabStop = True
            End If
        End If
        If Me.Focused Then
            ' otherwise when you lose focus, lost focus restores the wrong color
            Me.nSaveColor = Me.BackColor
        End If
    End Sub
    Sub New()
        mIo = IOValues.IOAlwaysEnable
        Me.ioEnabled = True
        Me.ForeColor = Color.DarkBlue
        Me.Font = New Font("Trebuchet MS", 9.0!, FontStyle.Bold)
        Me.Multiline = True
    End Sub
    Public Property nIO() As IOValues
        Get
            Return mIo
        End Get
        Set(ByVal value As IOValues)
            mIo = value
        End Set
    End Property
    Private Sub txtBase_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.nSaveColor = Me.BackColor
        If Me.Enabled Then
            Me.BackColor = Me.backColorFocus
            ' MG 27/feb/11
            Me.SelectAll()
            'Me.SelectionStart = 0
            'If Len(Me.Text) = 0 Then
            '    Me.SelectionLength = 0
            'Else
            '    Me.SelectionLength = Len(Me.Text)
            'End If
        End If
    End Sub
    Private Sub txtBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.BackColor = Me.nSaveColor
    End Sub
End Class