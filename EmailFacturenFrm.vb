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
End Class
