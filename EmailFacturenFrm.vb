Public Class EmailFacturenFrm
    Dim _VanFactuurNr = 0
    Dim _TotFactuurNr = 0
    Dim _AantalFacturen = 0
    Private Sub EmailFacturenFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer : For i = 1 To 40
            EmailenFacturentGrdBase.Rows.Add()
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
            _TotFactuurNr = _VanFactuurnr
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
            If (line >= EmailenFacturentGrdBase.Rows.Count) Then
                EmailenFacturentGrdBase.Rows.Add()
            End If
            EmailenFacturentGrdBase(0, line).Value = row("Klant")
            EmailenFacturentGrdBase(1, line).Value = row("Kl_naam")
            EmailenFacturentGrdBase(2, line).Value = row("Kl_EMail")
            CType(EmailenFacturentGrdBase(2, line), DataGridViewCell).Style.BackColor = Color.White
            EmailenFacturentGrdBase(3, line).Value = row("facth_Nummer").Trim()
            EmailenFacturentGrdBase(4, line).Value = $"{row("facth_totBet"):n2}"
            EmailenFacturentGrdBase(5, line).Value = True
            CType(EmailenFacturentGrdBase(5, line), DataGridViewCell).Style.BackColor = Color.White
            line += 1
        Next
        For l = line To EmailenFacturentGrdBase.Rows.Count - 1
            For Each f In EmailenFacturentGrdBase.Columns
                EmailenFacturentGrdBase(f.Index, l).Value = Nothing
                CType(EmailenFacturentGrdBase(f.Index, l), DataGridViewCell).Style.BackColor = EmailenFacturentGrdBase.DefaultCellStyle.BackColor
            Next
        Next
        EmailenFacturentGrdBase(0, 0).Selected = True

        ' Me.EmailenFacturentGrdBase.DataSource = dt



        RefreshForm()

    End Sub
    Private Sub RefreshForm()
        FactuurNrVanTextBase.Text = _VanFactuurNr.ToString()
        FactuurNrTotTxtBase.Text = _TotFactuurNr.ToString()
        txtAantalFacturen.Text = _AantalFacturen.ToString()
    End Sub
    Public Shared Function GetInvoicesToEmail(fromNumber As Long, toNumber As Long) As DataTable
        Dim sql As String = "select * from FactH,Klanten "
        sql &= "Where FactH_Klant = Kl_ID "
        sql &= "and FactH_Nummer >= ? "
        sql &= "and FactH_Nummer <= ? "
        sql &= "and Kl_EmailFacturen =  ?"
        Dim cmd = New sqlClass
        cmd.AddParameter(fromNumber, DbType.Int32)
        cmd.AddParameter(toNumber, DbType.Int32)
        cmd.AddParameter(True, DbType.Boolean)
        Dim unused = cmd.Execute(sql)
        Return cmd.dt
    End Function
End Class
