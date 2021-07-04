Public Class EmailFacturenFrm
    Dim _VanFactuurNr = 0
    Dim _TotFactuurNr = 0
    Dim _AantalFacturen = 0
    Private Sub EmailFacturenFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer : For i = 1 To 40
            g.Rows.Add()
        Next
    End Sub


    Private Sub FactuurNrVanTextBase_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FactuurNrVanTextBase.Validating
        If sender.Text = "" Then Return
        Dim input As String = sender.Text
        Dim result As Long
        If Int32.TryParse(input, result) = False Then
            MessageBox.Show($"{input} is niet geldig")
            e.Cancel = True
        End If
        _VanFactuurNr = result
        ValidateFactuurNummers(e)
    End Sub

    Private Sub FactuurNrTotTxtBase_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FactuurNrTotTxtBase.Validating
        Dim input As String = sender.Text
        Dim result As Long
        If Int32.TryParse(input, result) = False Then
            MessageBox.Show($"{input} is niet geldig")
            e.Cancel = True
        End If
        _TotFactuurNr = result
        ValidateFactuurNummers(e)
    End Sub
    Private Sub ValidateFactuurNummers(e As System.ComponentModel.CancelEventArgs)
        If _TotFactuurNr = 0 Then
            _TotFactuurNr = _VanFactuurNr
            _AantalFacturen = 1
            RefreshForm()
            Return
        End If
        If _TotFactuurNr < _VanFactuurNr Then
            Dim w As Long = _VanFactuurNr
            _VanFactuurNr = _TotFactuurNr
            _TotFactuurNr = w
        End If
        Dim s = New sqlClass()
        s.AddParameter(True, DbType.Boolean)
        s.AddParameter(_VanFactuurNr.ToString(), DbType.String)
        s.AddParameter(_TotFactuurNr.ToString(), DbType.String)
        Dim sql As String = "select "
        sql += "kl_nummer as Klant , "
        sql += "kl_naam, "
        sql += "kl_email, "
        sql += "facth_nummer, "
        sql += " facth_TotBet "
        sql += " From FactH,klanten Where facth_klant = kl_id And kl_emailfacturen = ? And facth_nummer >= ? And facth_nummer<=?"
        Dim dt = New DataTable()
        s.Execute(sql, dt)
        _AantalFacturen = dt.Rows.Count()
        'Me.EmailenFacturentGrdBase.Rows.Clear()
        Dim line = 0
        For Each row As DataRow In dt.Rows
            ' Dim line = Me.EmailenFacturentGrdBase.Rows.Add
            If (line >= g.Rows.Count) Then
                g.Rows.Add()
            End If
            g(0, line).Value = row("Klant")
            g(1, line).Value = row("Kl_naam")
            g(2, line).Value = row("Kl_EMail")
            CType(g(2, line), DataGridViewCell).Style.BackColor = Color.White
            g(3, line).Value = row("facth_Nummer").Trim()
            g(4, line).Value = $"{row("facth_totBet"):n2}"
            g(5, line).Value = True
            CType(g(5, line), DataGridViewCell).Style.BackColor = Color.White
            line += 1
        Next
        For l = line To g.Rows.Count - 1
            For Each f In g.Columns
                g(f.Index, l).Value = Nothing
                CType(g(f.Index, l), DataGridViewCell).Style.BackColor = g.DefaultCellStyle.BackColor
            Next
        Next
        g(0, 0).Selected = True

        ' Me.EmailenFacturentGrdBase.DataSource = dt



        RefreshForm()

    End Sub
    Private Sub RefreshForm()
        FactuurNrVanTextBase.Text = _VanFactuurNr.ToString()
        FactuurNrTotTxtBase.Text = _TotFactuurNr.ToString()
        txtAantalFacturen.Text = _AantalFacturen.ToString()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub g_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles g.CellContentClick
        'If g.Rows.Count() = 0 Then Return
        'If (New List(Of Integer) From {5}).Contains(e.ColumnIndex) = False Then Return
        'Dim email As String
        'Dim isEmailSet As Boolean

        'email = g(2, e.RowIndex).Value
        'isEmailSet = g(5, e.RowIndex).Value
        ''Select Case e.ColumnIndex
        ''    Case 2
        ''        If g.EditingControl Is Nothing Then Return
        ''        email = IIf(g.EditingControl Is Nothing, g(2, e.RowIndex).Value, g.EditingControl.Text)
        ''        isEmailSet = g(5, e.RowIndex).Value
        ''    Case 5
        ''        email = g(2, e.RowIndex).Value
        ''        isEmailSet = g.CurrentCell.FormattedValue
        ''End Select
        'If isEmailSet Then
        '    If Helpers.IsValidEmailAddress(email) = False Then
        '        MessageBox.Show(Helpers.ErrorMessage)
        '        g.CancelEdit()
        '        g.CurrentCell = g(e.ColumnIndex, e.RowIndex)
        '    End If
        'End If

    End Sub

    Private Sub g_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles g.CellLeave
    End Sub

    Private Sub g_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles g.CellValueChanged

    End Sub

    Private Sub g_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles g.CellValidating
        'If g.Rows.Count() = 0 Then Return
        'If (New List(Of Integer) From {2}).Contains(e.ColumnIndex) = False Then Return
        'Dim email As String
        'Dim isEmailSet As Boolean

        'email = e.FormattedValue
        'isEmailSet = g(5, e.RowIndex).Value
        ''Select Case e.ColumnIndex
        ''    Case 2
        ''        If g.EditingControl Is Nothing Then Return
        ''        email = IIf(g.EditingControl Is Nothing, g(2, e.RowIndex).Value, g.EditingControl.Text)
        ''        isEmailSet = g(5, e.RowIndex).Value
        ''    Case 5
        ''        email = g(2, e.RowIndex).Value
        ''        isEmailSet = g.CurrentCell.FormattedValue
        ''End Select
        'If isEmailSet Then
        '    If Helpers.IsValidEmailAddress(email) = False Then
        '        MessageBox.Show(Helpers.ErrorMessage)
        '        g.CancelEdit()
        '        e.Cancel = True
        '    End If
        'End If

    End Sub

    Private Sub g_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles g.CellEndEdit

    End Sub

    Private Sub g_Click(sender As Object, e As EventArgs) Handles g.Click

    End Sub

    Private Sub g_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles g.RowLeave
        'email = IIf(e.ColumnIndex = 2, g.EditingControl.Text, g(2, e.RowIndex).Value)
        'isEmailSet = g(5, e.RowIndex).Value
        'If isEmailSet Then
        '    If Helpers.IsValidEmailAddress(email) = False Then
        '        MessageBox.Show(Helpers.ErrorMessage)
        '        g.CancelEdit()
        '        g.Rows(e.RowIndex).Selected = True
        '    End If
        'End If
    End Sub

    Private Sub g_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles g.RowValidating
        If g.IsCurrentRowDirty = False Then Return
        email = g(2, e.RowIndex).Value
        isEmailSet = g(5, e.RowIndex).Value
        If isEmailSet Then
            If Helpers.IsValidEmailAddress(email) = False Then
                MessageBox.Show(Helpers.ErrorMessage)
                g.CancelEdit()
                e.Cancel = True
            End If
        End If

    End Sub
End Class
