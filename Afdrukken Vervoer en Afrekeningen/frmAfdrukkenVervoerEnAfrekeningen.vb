Imports System.Threading
Imports System.Threading.Tasks
Public Class frmAfdrukkenVervoerEnAfrekiningen
    Dim _interrupt As Boolean = False
    Dim cAlleKlantenCode As String = "***"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _interrupt = True
        Me.Close()
    End Sub


    Private Sub frmAfdrukkenVervoerEnAfrekeningen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormMode = ModeValues.RecordEntry
        Me.txtKlNr.backColorFocus = Color.LightPink
        Me.setTooltip(Me.txtKlNr, "[***] voor alle klanten.")
        Me.txtDatumLevering.Text = bzBestel.dGetLeveringForBestellingDatum.ToString(cDateFormat)
        Me.txtKlNr.Text = Me.cAlleKlantenCode
        Me.txtKlNaam.Text = "Alle Klanten."
        AfdrukkenPerTourCheckbox.Checked = True
        Me.txtVervoerCopijen.Text = "1"
        Me.txtAfrekeningCopijen.Text = "1"
        Me.btnOK.Focus()
    End Sub

    Private Sub txtKlNr_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKlNr.Enter
        Me.txtKlNaam.Text = ""
    End Sub

    Private Sub txtKlNr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKlNr.Validated
        If Me.txtKlNr.Text = "" Then Exit Sub
        Me.txtKlNr.backColorFocus = Color.White
        If txtKlNr.Text = Me.cAlleKlantenCode Then
            Me.txtKlNaam.Text = "Alle Klanten"
            Exit Sub
        End If
        Dim oKlanten As New bzKlanten
        If oKlanten.Kl_NummerExists(Me.txtKlNr.Text) Then
            Me.txtKlNaam.Text = oKlanten.record.KL_Naam
        End If
        Me.txtKlNr.Text = oKlanten.record.KL_Nummer
    End Sub

    Private Sub txtKlNr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtKlNr.Validating
        Dim cInput As String = Trim(Me.txtKlNr.Text)
        If cInput = "" Then Exit Sub
        If cInput = Me.cAlleKlantenCode Then Exit Sub
        Dim obzKlanten As New bzKlanten
        If obzKlanten.Kl_NummerExists(cInput) Then Exit Sub
        If obzKlanten.KL_CodeExists(cInput) Then
            Me.txtKlNr.Text = obzKlanten.record.KL_Nummer
            Exit Sub
        End If
        Dim sql As New sqlClass
        Dim tally As Long = sql.Execute("select KL_nummer,Kl_Naam from klanten where kl_naam like '%" & cInput & "%' and kl_Actief = true order by kl_naam")
        If tally = 1 Then
            Me.txtKlNr.Text = sql.dt(0)("Kl_Nummer")
            Exit Sub
        End If
        If tally > 1 Then
            Dim fKlant As New PopupFrm
            fKlant.caller = Me.txtKlNr
            fKlant.dt = sql.dt
            fKlant.ShowDialog()
            If fKlant.userCanceled Then
                e.Cancel = True
                Exit Sub
            End If
            Me.txtKlNr.Text = fKlant.g(fKlant.g.Columns("KL_Nummer").Index, fKlant.selected).FormattedValue
            Exit Sub
        End If
        MsgBox("Ongeldige Ingave")
        e.Cancel = True
    End Sub
    Function getCount() As Long
        Dim klantClause As String = ""
        If Me.txtKlNr.Text <> Me.cAlleKlantenCode Then
            klantClause = " and besth_Klant = " & bzKlanten.kl_id(Me.txtKlNr.Text)
        End If
        Dim sqlObject As New sqlClass
        Dim count As Long
        Dim Sql As String = " select count(*) from besth "
        Sql &= " where besth_DatLevering = " & sqlClass.cDateForJet(CType(Me.txtDatumLevering.Text, Date)) & " "
        Sql &= klantClause & " "
        count = sqlObject.ExecuteScalar(Sql)
        Sql = " select count(*) from ph "
        Sql &= "where besth_DatLevering = " & sqlClass.cDateForJet(CType(Me.txtDatumLevering.Text, Date)) & " "
        Sql &= klantClause & " "
        count += sqlObject.ExecuteScalar(Sql)
        Return count
    End Function
    ''' <summary>
    ''' Prints the bestellingen for particulieren
    ''' </summary>
    ''' <param name="oxl"></param>
    ''' <param name="d"></param>
    ''' <remarks>forces afdrykkeb per tour
    ''' and directs printing to the defaultprinter (not the uitzonderlijke printer aka epson
    ''' </remarks>
    Public Shared Sub processParticulieren(oxl As clsExcel, d As Date)
        Dim oSql As New sqlClass
        Dim cSql As String
        cSql = "select besth_Docnr from pH,Klanten "
        cSql &= " where besth_Klant = kl_id "
        cSql &= " and besth_DatLevering = " & sqlClass.cDateForJet(d)
        cSql &= " and besth_Klant <> " & BzWinkelproductie.klId
        cSql &= " order by kl_Naam"
        Dim nDocs As Integer = oSql.Execute(cSql)
        For Each oDoc As DataRow In oSql.dt.Rows
            Dim o As New bzUitzonderlijkAfrekening
            Dim afdrukkenPerTour As Boolean = True
            Dim tour As String = " "
            o.requestPrinting(oDoc("besth_docnr"),
                             afdrukkenPerTour,
                             tour,
                              cDefaultPrinter,
                              oxl)
            o = Nothing
        Next
    End Sub
    Sub process(osql As sqlClass)
        Dim leveringsDatum As Date = CType(Me.txtDatumLevering.Text, Date)
        Using oXl As New clsExcel
            If particulierenCheckbox.Checked Then
                batchAfdrukkenParticulierenOverzicht.report(oXl, leveringsDatum, cDefaultPrinter)
                'processParticulieren(oXl, leveringsDatum)
            End If
            If Val(Me.txtVervoerCopijen.Text) > 0 Then
                For Each oDoc As DataRow In osql.dt.Rows
                    Application.DoEvents()
                    If _interrupt Then
                        Return
                    End If
                    Dim o As New bzVervoerDocument
                    o.cDocNr = oDoc("Besth_Docnr")
                    o.cTour = Strings.Right(" " & Trim(Me.txtTour.Text), 1)
                    o.lReportByTour = AfdrukkenPerTourCheckbox.Checked
                    o.nCopies = Val(Me.txtVervoerCopijen.Text)
                    o.Print(oXl)
                    o = Nothing
                Next
            End If
            If Val(Me.txtAfrekeningCopijen.Text) > 0 Then
                For Each oDoc As DataRow In osql.dt.Rows
                    Application.DoEvents()
                    If _interrupt Then
                        Return
                    End If
                    Dim o As New bzAfrekeningDocument
                    o.cDocNr = oDoc("Besth_Docnr")
                    o.cTour = Strings.Right(" " & Trim(Me.txtTour.Text), 1)
                    o.lReportByTour = AfdrukkenPerTourCheckbox.Checked
                    o.nCopies = Val(Me.txtAfrekeningCopijen.Text)
                    o.Print(oXl)
                    o = Nothing
                Next
            End If
        End Using
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If getCount() = 0 Then
            MsgBox("Er werden geen bestellingen gevonden voor Uw selectie")
            Exit Sub
        End If
        btnOK.Enabled = False
        Dim oSql As New sqlClass
        Dim cSql As String
        cSql = "select besth_Docnr from BestH,Klanten "
        cSql &= "where besth_Klant = kl_id "
        cSql &= "and besth_DatLevering = " & sqlClass.cDateForJet(CType(Me.txtDatumLevering.Text, Date))
        If Me.txtKlNr.Text <> Me.cAlleKlantenCode Then
            cSql &= " and besth_Klant = " & bzKlanten.kl_id(Me.txtKlNr.Text)
        End If
        cSql &= " order by kl_Naam"
        Dim nDocs As Integer = oSql.Execute(cSql)
        If nDocs = 0 Then
            MsgBox("Er werden geen bestellingen gevonden voor Uw selectie")
            btnOK.Enabled = True
            Exit Sub
        End If
        _interrupt = False
        process(oSql)
        Close()
    End Sub
End Class
