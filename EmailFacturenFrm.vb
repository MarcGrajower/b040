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
        _AantalFacturen = _TotFactuurNr - _VanFactuurNr + 1
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
