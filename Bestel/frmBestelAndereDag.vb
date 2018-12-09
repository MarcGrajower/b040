Public Class frmBestelAndereDag
    Public dCurrentLeveringsdatum As Date
    Public dAndereDatum As Date
    Public nKlid As Long

    Private Sub TxtBaseDate1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBaseDate1.Validating
        If Me.TxtBaseDate1.lIsBlank Then Exit Sub
        If Me.TxtBaseDate1.lIsValid = False Then
            MsgBox(Me.TxtBaseDate1.Text & " is geen geldige datum. (dd/mm/jj)")
            e.Cancel = True
            Exit Sub
        End If
        Dim dAndereDatum As Date = CDate(Me.TxtBaseDate1.Text)
        If dAndereDatum <= Today Then
            MsgBox("Datum moet een toekomstige datum zijn")
            e.Cancel = True
            Exit Sub
        End If
        If dAndereDatum = Me.dCurrentLeveringsdatum Then
            MsgBox("Datum mag niet dezelfde zijn als de leveringsdatum van het huidig document.")
            e.Cancel = True
            Exit Sub
        End If
        If dAndereDatum.DayOfWeek = DayOfWeek.Saturday Then
            MsgBox(Me.TxtBaseDate1.Text & " is een Zaterdag.")
            e.Cancel = True
            Exit Sub
        End If
        Dim obzFeestdagen As New bzFeestdagen
        If obzFeestdagen.isFeesdag(dAndereDatum) = True Then
            MsgBox(Me.TxtBaseDate1.Text & " is een feestdag. (" & Trim(obzFeestdagen.cNaam) & ")")
            e.Cancel = True
            Exit Sub
        End If
        Dim osql As New sqlClass
        Dim nDocs As Long = osql.Execute("select * from besth where besth_klant = " & Me.nKlid & " and besth_datlevering = " & sqlClass.cDateForJet(dAndereDatum))
        If nDocs <> 0 Then
            MsgBox(Me.TxtBaseDate1.Text & ".  Er is reeds een bestelling voor die dag.")
            e.Cancel = True
            Exit Sub
        End If
        Me.dAndereDatum = dAndereDatum
    End Sub

    Private Sub btnOK_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Enter
        If Me.TxtBaseDate1.lIsBlank Then
            MsgBox("Gelieve een datum in te geven (dd/mm/yy)")
            Me.TxtBaseDate1.Focus()
        End If
    End Sub

 End Class
