Imports System.Globalization
Public Class frmAutomatischBestellen
    Dim AutomatischBestellenDatum As Date
    ' CONFIG - Laaste Particulieren JSon now in c:\docs hard coded
    Dim laasteParticulierenJson As String = modB040Config.Generic("DOCSFOLDER") + "automatischbestellen.Json"
    Private Function pCase(word As String) As String
        Return StrConv(word, VbStrConv.ProperCase)
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmAutomatischBestellen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bzBestel.loadMonthcalendarForDat_Levering(Me.MonthCalendar1)
        Me.MonthCalendar1.FirstDayOfWeek = Day.Sunday
        Me.AutomatischBestellenDatum = bzBestel.dGetLeveringForBestellingDatum(Now)
        Me.MonthCalendar1.SetSelectionRange(Me.AutomatischBestellenDatum, Me.AutomatischBestellenDatum)
        datumLabel.Text = pCase(AutomatischBestellenDatum.ToString("dddd d"))
        Me.TxtType.Text = "1"
        ToolTip1.SetToolTip(AfdrukkenLaatsteParticulieren, "Afdrukken laaste particuliere bestellingen bij hapering uitzondelijke printer (epson).")
        TypSTBestFillCbo(Me.CboStandaard)
        Me.CboStandaard.Text = pCase(CultureInfo.CurrentCulture.DateTimeFormat.DayNames(AutomatischBestellenDatum.DayOfWeek))
        Me.progressbar1.Visible = False
        Me.btnOK.Focus()
        Me.btnOK.Select()
        Dim f = frmMain.MdiChildren.FirstOrDefault(Function(x) x.Name = "frmProductiePlan")
        If (f Is Nothing) = False Then
            Dim totalWidth As Integer = f.Width + Me.Width + 2
            Me.Left = f.Left + f.Width + 2
        End If

    End Sub

    Private Sub txtType_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtType.Validating
        If Trim(Me.TxtType.Text) = "" Then Return
        If checkStandaardNr(Me.TxtType.Text) Then Return
        MsgBox(StandaardNrErrMsg)
        e.Cancel = True
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Trim(Me.txtType.Text) = "" Then
            MsgBox(StandaardNrErrMsg)
            Exit Sub
        End If
        Me.save()
    End Sub
    Sub save()
        '<KNOWN ISSUE>
        'The routine returns a wrong number of generated bestelling when there are zero line bestellingen.
        'This can happne because there are no detail lines, but also if Artikels are set to Inactief.
        Dim osql As New sqlClass
        Dim c As String
        c = "Select kl_id,sth_id "
        c &= "from StandaardH,Klanten "
        c &= "where sth_Klant = kl_id "
        c &= "and sth_type = " & sqlClass.c(Me.txtType.Text) & " "
        c &= "and sth_typSB = " & TypeSTBestFromOmschrijving(Me.CboStandaard.Text) & " "
        c &= "and kl_automatic = " & sqlClass.cBoolean(True) & " "
        c &= "and kl_actief = " & sqlClass.cBoolean(True) & " "
        c &= "and exists( select * from besth "
        c &= "where besth_klant = kl_id "
        c &= "and besth_datlevering = " & sqlClass.cDateForJet(AutomatischBestellenDatum) & ") = false "
        c &= "and exists( select * from Ph "
        c &= "where besth_klant = kl_id "
        c &= "and besth_datlevering = " & sqlClass.cDateForJet(AutomatischBestellenDatum) & ") = false"
        Dim n As Long = osql.Execute(c)
        Me.progressbar1.Maximum = n
        nLog("main sql returns " & n & " records", Me.Name)
        Dim oDocs As DataTable = osql.dt
        Dim obzBestel As New bzBestel
        Dim i As Integer = 0 : Me.progressbar1.Visible = True
        Dim coll = New List(Of [String])
        coll.Clear()
        For Each oDocRow As DataRow In oDocs.Rows
            If obzBestel.lExistsBestelling(oDocRow("Kl_id"), Me.AutomatischBestellenDatum) Then Continue For
            Dim documentNummer As String = ""
            Dim isParticulier As Boolean = False
            obzBestel.createBestelFromStandaard(oDocRow("Sth_id"), Me.AutomatischBestellenDatum, documentNummer, isParticulier)
            If afdrukkenParticulieren.Checked = True Then
                If isParticulier Then
                    If oDocRow("kl_id") = BzWinkelproductie.klId = False Then
                        coll.Add(documentNummer)
                        ' bzBestel.report(documentNummer)
                    End If
                End If
            End If
            i += 1
            Me.progressbar1.Value = i
        Next
        Me.progressbar1.Visible = False
        MsgBox(n & " bestelling werden automatisch gegeneerd voor " & Me.AutomatischBestellenDatum.ToString("dd/MM/yy"))
        Json.serialize(Of List(Of String))(coll, laasteParticulierenJson)
        If afdrukkenParticulieren.Checked = True Then
            For Each doc In coll
                bzBestel.report(doc)
            Next
        End If
        Me.Close()
    End Sub
    Private Sub MonthCalendar1_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim dOld As Date = Me.AutomatischBestellenDatum
        Dim dNew As Date = e.Start
        If dNew = dOld Then Exit Sub
        Do While bzBestel.lValidLeverdatum(dNew) = False
            dNew = dNew.AddDays(1)
        Loop
        Me.MonthCalendar1.SetDate(dNew)
        Me.AutomatischBestellenDatum = dNew
        datumLabel.Text = pCase(AutomatischBestellenDatum.ToString("dddd d"))
        Me.CboStandaard.Text = pCase(CultureInfo.CurrentCulture.DateTimeFormat.DayNames(Me.AutomatischBestellenDatum.DayOfWeek))
    End Sub

    Private Sub AfdrukkenLaatsteParticulieren_Click(sender As Object, e As EventArgs) Handles AfdrukkenLaatsteParticulieren.Click
        Dim coll As New List(Of String)
        Json.deserialize(Of List(Of String))(Me.laasteParticulierenJson, coll)
        For Each doc In coll
            bzBestel.report(doc)
        Next
    End Sub
End Class
