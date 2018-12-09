Public Class frmBestellingenAnnulerenPerDag

    Private Sub btnBestellingenAnnuleren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBestellingenAnnuleren.Click
        Dim oSqlCheck As New sqlClass
        Dim cSqlCheck As String = "select * from besth where besth_datlevering = " & sqlClass.cDateForJet(Me.MonthCalendar1.SelectionStart)
        cSqlCheck &= " and besth_factuur <> '1'"
        oSqlCheck.Execute(cSqlCheck)
        If oSqlCheck.dt.Rows.Count = 0 Then
            cSqlCheck = "select * from ph where besth_datlevering = " & sqlClass.cDateForJet(Me.MonthCalendar1.SelectionStart)
            cSqlCheck &= " and besth_factuur <> '1'"
            oSqlCheck.Execute(cSqlCheck)
            If oSqlCheck.dt.Rows.Count = 0 Then
                MsgBox("Er zijn geen (niet gefactureerde) bestellingen op " & Format(Me.MonthCalendar1.SelectionStart, modDutch.cDateFormat) & ".")
                Exit Sub
            End If
        End If

        Dim cYesNo As String = "Er zijn " & oSqlCheck.dt.Rows.Count & " (niet gefactureerde) bestellingen te annuleren op " & Format(Me.MonthCalendar1.SelectionStart, modDutch.cDateFormat) & "."
        cYesNo &= vbCrLf
        cYesNo &= "Gelieve Uw aanvraag om te annuleren te willen bevestigen."
        cYesNo &= vbCrLf
        cYesNo &= "Deze handeling is onomkeerbaar."
        If YesNO(cYesNo) = False Then Exit Sub
        Dim osql As New sqlClass
        osql.beginTransaction()
        Dim csql As String
        csql = "delete * from bestd "
        csql &= "where bestd_besth in ("
        csql &= "select besth_id from besth where besth_datlevering = " & sqlClass.cDateForJet(Me.MonthCalendar1.SelectionStart)
        csql &= " and besth_factuur <> '1'"
        csql &= ")"
        osql.ExecuteNonQuery(csql, osql.t)
        csql = "delete * from besth where besth_datlevering = " & sqlClass.cDateForJet(Me.MonthCalendar1.SelectionStart)
        csql &= " and besth_factuur <> '1'"
        osql.ExecuteNonQuery(csql, osql.t)
        csql = "delete * from pd "
        csql &= "where bestd_besth in ("
        csql &= "select besth_id from besth where besth_datlevering = " & sqlClass.cDateForJet(Me.MonthCalendar1.SelectionStart)
        csql &= " and besth_factuur <> '1'"
        csql &= ")"
        osql.ExecuteNonQuery(csql, osql.t)
        csql = "delete * from ph where besth_datlevering = " & sqlClass.cDateForJet(Me.MonthCalendar1.SelectionStart)
        csql &= " and besth_factuur <> '1'"
        osql.ExecuteNonQuery(csql, osql.t)
        osql.commitTransation()
        modLog.nlog("Bestellingen geannuleerd voor " & Format(Me.MonthCalendar1.SelectionStart, modDutch.cDateFormat))
        MsgBox("Bestellingen geannuleerd voor " & Format(Me.MonthCalendar1.SelectionStart, modDutch.cDateFormat))
    End Sub

    Private Sub btnSluiten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSluiten.Click
        Me.Close()
    End Sub

    Private Sub frmBestellingenAnnulerenPerDag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim c As String = "Let wel, alle bestellingen (niet leveringen) worden geannuleerd voor die dag, tenzij ze gefactureerd werden. "
        c &= vbCrLf
        c &= "Deze handeling is onomkeerbaar."
        Me.setTooltip(Me.btnBestellingenAnnuleren, c)
    End Sub
End Class
