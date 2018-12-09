Imports System.String

Public Class grdBase
    Inherits DataGridView
    Implements IControlMaskit
    Implements IcontrolIOEnable
    Dim mIO As IOValues
    Dim f As New frmB040
    Dim ioEnabled As Boolean
    Friend backColorEnabled As Color = Color.White
    Friend backColorDisabled As Color = Color.FromArgb(220, 220, 220)
    Friend backColorSelection As Color = applicationFocusBackcolor
    Dim nSavecolor As Color
    Friend columnValidateIfEmpty() As Boolean
    Friend columnDisabled() As Boolean
    Friend columnDecimals() As Integer
    Friend columnTabstops() As Boolean
    Dim mKeepHightlightOnLostFocus As Boolean = False
    Dim ValueOnEntry
    Public Property lKeepHighlightOnLostFocus() As Boolean
        Get
            Return mKeepHightlightOnLostFocus
        End Get
        Set(ByVal value As Boolean)
            mKeepHightlightOnLostFocus = value
        End Set
    End Property

    Friend Overloads Property currentColumnValue(ByVal ctrl As String) As String
        Get
            If Me.Columns(ctrl) Is Nothing Then
                Throw New InvalidOperationException(ctrl & " is not a valid control name")
            End If
            Return Me(Me.Columns(ctrl).Index, Me.CurrentRow.Index).FormattedValue
        End Get
        Set(ByVal value As String)
            Me(Me.Columns(ctrl).Index, Me.CurrentRow.Index).Value = value
        End Set
    End Property
    Sub New()
        Me.RowHeadersVisible = False
        Me.SelectionMode = DataGridViewSelectionMode.CellSelect
        Me.DefaultCellStyle.Font = New Font("Trebuchet MS", 10.0F, FontStyle.Bold)
        Me.DefaultCellStyle.ForeColor = Color.DarkBlue
        Me.DefaultCellStyle.SelectionForeColor = Color.DarkBlue
        Me.DefaultCellStyle.SelectionBackColor = Me.DefaultCellStyle.BackColor
        Me.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        Me.ColumnHeadersDefaultCellStyle.Font = New Font(Me.DefaultCellStyle.Font, FontStyle.Regular)
        Me.BackgroundColor = Color.White
        Me.GridColor = Color.LightGray  ' does not seem to have a lot of effect.
        Me.EditMode = DataGridViewEditMode.EditOnKeystroke
        Me.nIO = ModeValues.RecordEntry
        Me.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Me.lKeepHighlightOnLostFocus = False
        Me.ClearSelection()
    End Sub
    Sub maskit() Implements IControlMaskit.MaskIt
        Me.f = Me.FindForm
        ReDim Me.columnValidateIfEmpty(Me.Columns.Count)
        For Each b As Boolean In Me.columnValidateIfEmpty
            b = False
        Next
        ReDim Me.columnDisabled(Me.Columns.Count)
        For Each b As Boolean In Me.columnDisabled
            b = False
        Next
        ReDim Me.columnDecimals(Me.Columns.Count)
        ReDim Me.columnTabstops(Me.Columns.Count)
        For i As Integer = 0 To Me.Columns.Count - 1
            Me.columnDecimals(i) = 2
            Me.columnTabstops(i) = True
        Next
        For Each c As DataGridViewColumn In Me.Columns
            If c.Visible = True Then
                c.Resizable = DataGridViewTriState.True
                c.SortMode = DataGridViewColumnSortMode.NotSortable ' you want this if you want your headers to be centered.     
                If ((TypeOf c Is DataGridViewTextBoxColumn)) And Me.columnDatatype(c) = "System.String" Then
                    If CType(c, DataGridViewTextBoxColumn).MaxInputLength = 32767 Then CType(c, DataGridViewTextBoxColumn).MaxInputLength = columnMaxlength(c)
                    If columnDisabled(c.Index) = True Then
                        c.FillWeight = Math.Max(columnMaxlength(c), Len(c.HeaderText))
                    End If
                    c.Resizable = DataGridViewTriState.True
                    'c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    If c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet Then
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    End If
                Else
                    c.FillWeight = Len(c.HeaderText)
                    If c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet Then
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                End If
            End If
        Next
        Me.DefaultCellStyle.SelectionBackColor = Me.DefaultCellStyle.BackColor
        Me.ClearSelection()
    End Sub
    Function columnDatatype(ByVal C As DataGridViewColumn) As String
        If C.IsDataBound Then
            Return Me.DataSource.datasource.tables(Me.DataSource.datamember).columns(C.DataPropertyName).DataType.ToString
        End If
        Return "Unbound"
    End Function
    Function columnMaxlength(ByVal C As DataGridViewColumn) As Integer
        Return Me.DataSource.datasource.tables(Me.DataSource.datamember).columns(C.DataPropertyName).maxlength
    End Function
    Sub ioEnable(ByVal mode As ModeValues) Implements IcontrolIOEnable.ioEnable
        If Me.mIO = IOValues.IOKeyEntryEnable Then
            Throw New InvalidOperationException("Grids cannot be IOKeyEntryEnabled.")
        End If
        If Me.mIO = IOValues.IOAlwaysEnable Then
            Throw New InvalidOperationException("IOAlwaysEnabled Grdbase are not supported.")
        End If
        If mode = ModeValues.RecordEntry Then
            Me.DefaultCellStyle.BackColor = Me.backColorEnabled
            Me.DefaultCellStyle.SelectionBackColor = Me.DefaultCellStyle.BackColor
            Me.ReadOnly = False
            Me.Enabled = True
            For Each col As DataGridViewColumn In Me.Columns
                If col.Visible = True AndAlso Me.columnDisabled(col.Index) = True Then
                    col.DefaultCellStyle.BackColor = Me.backColorDisabled
                    col.DefaultCellStyle.SelectionBackColor = Me.backColorSelection
                    col.ReadOnly = True
                End If
            Next
        Else
            Me.DefaultCellStyle.BackColor = Me.backColorDisabled
            Me.DefaultCellStyle.SelectionBackColor = Me.backColorDisabled
            Me.ReadOnly = True
            Me.Enabled = False
        End If
    End Sub
    Public Property nIO() As IOValues
        Get
            Return mIO
        End Get
        Set(ByVal value As IOValues)
            mIO = value
        End Set
    End Property
    Protected Overloads Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            Return Me.ProcessTabKey(keyData)
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function
    Protected Overloads Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        Me.f.lastKeycode = e.KeyCode
        If f.lastKeycode = Keys.Tab Then
            If e.Shift Then f.lastKeycode = 15
        End If
        If e.KeyData = Keys.Enter Then
            Me.ProcessTabKey(e.KeyData)
            Exit Sub
        End If
        MyBase.OnKeyDown(e)
    End Sub

    Private Sub grdBase_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEnter
        Me.ValueOnEntry = Me(e.ColumnIndex, e.RowIndex).Value
    End Sub

    Private Sub grdBase_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Me.CellFormatting
        If e.Value Is DBNull.Value Then Exit Sub
        If e.Value Is Nothing Then Exit Sub

        If Me.columnDatatype(Me.Columns(e.ColumnIndex)) = "System.Decimal" Then
            e.Value = FormatNumber(Val(e.Value), Me.columnDecimals(e.ColumnIndex))
        End If
    End Sub

 
    Private Sub grdBase_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Me.DataError
        Dim c As String = "<Waarde kan niet voorgesteld worden>"
        Dim cFoutmelding As String = ""
        Try
            c = "<" & Me(e.ColumnIndex, e.RowIndex).Value.ToString & ">"
        Catch ex As Exception
            cFoutmelding = ex.Message
        End Try
        c &= " : deze waarde is niet geldig in deze kolom " & Me.Columns(e.ColumnIndex).Name & vbCrLf
        c &= "Fout melding : " & cFoutmelding & vbCrLf
        c &= "Context melding : " & e.Context.ToString
        MsgBox(c)
        e.ThrowException = False
    End Sub
    Private Sub grdbase_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Me.EditingControlShowing
        If TypeOf Columns(CurrentCell.ColumnIndex) Is DataGridViewComboBoxColumn Then
            ' MG 18/mrt/11 - makes sure (part of - see also cellValidating) that user can enter "any" value.
            If (Me.CurrentCellAddress.X = Me.Columns(CurrentCell.ColumnIndex).DisplayIndex) Then
                'Cast To Normal ComboBox
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If (cb IsNot Nothing) Then
                    'Change Style To DropDown, To Allow For Data Entry
                    cb.DropDownStyle = ComboBoxStyle.DropDown
                End If
                Exit Sub
            End If
        End If
        ' don't ask, but keep together with textbox_Keypress 
        If Not (TypeOf (Columns(CurrentCell.ColumnIndex)) Is DataGridViewTextBoxColumn) Then
            Exit Sub
        End If
        Dim tb As TextBox = CType(e.Control, TextBox)
        AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' don't ask, but keep together with grdbase_EditingControlShowing
        If columnDatatype(Columns(CurrentCell.ColumnIndex)) = "System.Decimal" Then
            If e.KeyChar = "." Then
                e.KeyChar = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            End If
        End If

    End Sub
    Public Function thisRow(ByVal f As String)
        Return Me(Me.Columns(f).Index, Me.CurrentRow.Index).Value
    End Function
    Friend Sub setColumnDisabled(ByVal c As String)
        If Me.Columns(c) Is Nothing Then Throw New InvalidOperationException(c & " is not a valid column in " & Me.Name)
        Me.columnDisabled(Me.Columns(c).Index) = True
    End Sub
    Friend Sub setColumnTabstopFalse(ByVal c As String)
        If Me.Columns(c) Is Nothing Then Throw New InvalidOperationException(c & " is not a valid column in " & Me.Name)
        Me.columnTabstops(Me.Columns(c).Index) = False
    End Sub
    Friend Sub setColumnTabstop(ByVal c As String)
        If Me.Columns(c) Is Nothing Then Throw New InvalidOperationException(c & " is not a valid column in " & Me.Name)
        Me.columnTabstops(Me.Columns(c).Index) = True
    End Sub
    Friend Sub setColumnDecimals(ByVal c As String, ByVal n As Integer)
        If Me.Columns(c) Is Nothing Then Throw New InvalidOperationException(c & " is not a valid column in " & Me.Name)
        Me.columnDecimals(Me.Columns(c).Index) = n
    End Sub

    Private Sub GrdBase_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles Me.CellValidating
        Dim Input As String = Nothing
        If Me.EditingControl Is Nothing Then
            If Me.columnValidateIfEmpty Is Nothing Then
                Exit Sub
            End If
            If Me.columnValidateIfEmpty(e.ColumnIndex) = False Then
                Exit Sub
            End If
            Input = gen.cNvl(Me(e.ColumnIndex, e.RowIndex).Value)
        Else
            Input = Me.EditingControl.Text
        End If
        Me.f.grdCurrentlyValidating = Me
        'If Input = "" AndAlso Me.columnValidateIfEmpty(e.ColumnIndex) = False Then
        '    Exit Sub
        'End If
        Select Case True
            Case TypeOf (Me.Columns(e.ColumnIndex)) Is DataGridViewComboBoxColumn
                ' MG 23/mrt/12
                ' modified in such a way that lower case characters get converted to upper case.
                ' MG 18/mrt/11 - makes sure (part of,see showing) that user can enter "any value" in the combobox.
                'Create a New ComboBoxColumn Object, And Cast The dataGridView's Column To That
                Dim comboBoxColumn As DataGridViewComboBoxColumn = CType(Me.Columns(e.ColumnIndex), DataGridViewComboBoxColumn)
                'If In ComboBoxColumn
                If (e.ColumnIndex = comboBoxColumn.DisplayIndex) Then
                    If (Not comboBoxColumn.Items.Contains(UCase(e.FormattedValue))) Then
                        'Add The Text Entered By The User
                        comboBoxColumn.Items.Add(UCase(e.FormattedValue))
                        'Make Sure Value Stays Displayed ( May HAve To Enter Value Twice )
                        Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = comboBoxColumn.Items(comboBoxColumn.Items.Count - 1)
                    Else
                        Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = UCase(e.FormattedValue)
                    End If
                End If
            Case TypeOf (Me.Columns(e.ColumnIndex)) Is DataGridViewTextBoxColumn
            Case Else
                ' MsgBox("Column type not supported")
                Exit Sub
        End Select
        If Me.f.grdValidate(UCase(Me.Columns(e.ColumnIndex).Name), Input) = False Then
            e.Cancel = True
        End If
        'If Me.columnDatatype(Me.Columns(e.ColumnIndex)) = "System.Decimal" Then
        '    input = FormatNumber(Val(input), Me.columnDecimals(e.ColumnIndex))
        'End If
        If Me.EditingControl Is Nothing Then
            '           Input = ""
            Return
        End If
        Me.EditingControl.Text = Input
    End Sub


    Friend Sub currentColumnEnable(ByVal ctrl As String, ByVal enable As Boolean)
        With Me(Me.Columns(ctrl).Index, Me.CurrentRow.Index)
            If enable Then
                .Style.BackColor = Me.backColorEnabled
                .ReadOnly = False
            Else
                .Style.BackColor = Me.backColorDisabled
                .ReadOnly = True
            End If
        End With
    End Sub
    Protected Overrides Sub OnCellEnter(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If Me.Focused = True Then
            If CurrentCell.ReadOnly = True Then
                SendKeys.Send("{TAB}")
                Exit Sub
            End If
            If columnDisabled(e.ColumnIndex) = True Then
                SendKeys.Send("{TAB}")
                Exit Sub
            End If
            If columnTabstops(e.ColumnIndex) = False Then
                If Me.f.lastKeycode = Keys.Tab Or Me.f.lastKeycode = Keys.Enter Then
                    SendKeys.Send("{TAB}")
                    ' is this not missing exit sub?
                End If
            End If
        End If

        MyBase.OnCellEnter(e)
        Me.f.lastKeycode = 0
    End Sub
    Public Sub EnableCell(ByVal c As DataGridViewCell, ByVal Enable As Boolean)
        c.ReadOnly = Not Enable
        c.Style.BackColor = IIf(Enable, Me.backColorEnabled, Me.backColorDisabled)
    End Sub
    Friend Sub grdBase_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        '    ' not sure this one is needed
        '    Me.DefaultCellStyle.SelectionBackColor = Me.DefaultCellStyle.BackColor
        '    Me.Refresh()
        'End Sub
        Me.DefaultCellStyle.SelectionBackColor = Me.DefaultCellStyle.BackColor
        If Me.lKeepHighlightOnLostFocus = False Then
            Me.ClearSelection()
        End If
    End Sub
    'Private Sub grdBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
    '    Me.DefaultCellStyle.SelectionBackColor = Me.DefaultCellStyle.BackColor
    '    Me.ClearSelection()
    'End Sub



    Private Sub grdBase_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellValueChanged
        ' MG 22/mei/11  
        If Me.Focused = False Then Exit Sub
        If TypeOf (Me.Columns(e.ColumnIndex)) Is DataGridViewCheckBoxColumn Then
            Me.f.grdValidate(UCase(Me.Columns(e.ColumnIndex).Name), "")
            Exit Sub
        End If
    End Sub

    Private Sub grdBase_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.CellMouseClick
        ' MG 26/mei/12 - wonder what this is for
        If Me.Focused = False Then Exit Sub
        If TypeOf (Me.Columns(e.ColumnIndex)) Is DataGridViewCheckBoxColumn Then
            Me.f.grdValidate(UCase(Me.Columns(e.ColumnIndex).Name), "")
            Exit Sub
        End If
    End Sub

    Private Sub grdBase_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter

        Me.DefaultCellStyle.SelectionBackColor = Me.backColorSelection
        Me.f.previousControl = Me
    End Sub
    Public Function nColumnLeft(ByVal cCol As String) As Long
        Dim n As Long = 0
        For Each oCol As DataGridViewColumn In Me.Columns
            If oCol.Name = cCol Then Exit For
            n += oCol.Width
        Next
        Return n
    End Function

  
End Class


