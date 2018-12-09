Imports System.Data.OleDb
Imports System.IO

Public Class frmDatabaseComprimeren
    Dim cFullPath As String

    Private Sub frmDatabaseComprimeren_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtPhase.Text = "1/4. Process opstarten."
        Me.btnAnnuleren.Enabled = False
        Me.btnOK.Enabled = True
        Dim conn As New OleDbConnection(My.Settings.b040_beConnectionString)
        conn.Open()
        Me.cFullPath = conn.DataSource
        nLog("DB Size before " & New FileInfo(Me.cFullPath).Length & ")", Me.Name)
        conn.Close()
        Me.btnOK.Text = "Starten"
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.btnOK.Text = "Sluiten" Then
            Me.Close()
            Exit Sub
        End If
        Me.btnOK.Text = "Sluiten"
        Dim cFolder As String = IO.Path.GetDirectoryName(cFullPath)
        Dim cFilename As String = IO.Path.GetFileName(cFullPath)
        Dim cTempName As String = cFolder & IO.Path.GetRandomFileName
        Dim cCheckName As String = cFolder & "\" & IO.Path.GetFileNameWithoutExtension(cFullPath) & ".laccdb"
        Me.txtPhase.Text = "2/4. Wacthen op Exclusieve Toegang. (+/- 1 min) "
        Me.btnAnnuleren.Enabled = True
        Me.btnOK.Enabled = False
        Dim t As DateTime = Now
        While IO.File.Exists(cCheckName)
            System.Threading.Thread.Sleep(2000)
            Dim n As Double = Int((Now - t).TotalSeconds)
            If n > 120 Then
                Dim c As String = "Het zou kunnen dat de database niet exclusief toegangkelijk is."
                c &= "  Controleert U dit even?" + vbCrLf + vbCrLf
                c &= "  Indien U Ja antwoordt wordt nogmaals gedurende 2 min getracht de database exclusief te openen, anders wordt dit process afgesloten."
                If YesNO(c, ContentAlignment.MiddleLeft) Then
                    t = Now
                Else
                    Me.Close()
                    Exit Sub
                End If
            End If
            Me.txtPhase.Text = "2/4 Wachten op Exclusieve Toegang. (" & Int((Now - t).TotalSeconds) & " sec.  Normaal +/- 1 min)"
            Application.DoEvents()
        End While
        Me.btnAnnuleren.Enabled = False
        Me.txtPhase.Text = "3/4 Compressie"
        Dim o = CreateObject("access.application")
        o.compactrepair(cFullPath, cTempName, False)
        o.quit()
        o = Nothing
        Me.txtPhase.Text = "4/4 Afsluiten"
        Application.DoEvents()
        IO.File.Copy(cTempName, cFullPath, True)
        IO.File.Delete(cTempName)
        Me.txtPhase.Text = "De compressie van de database is gelukt."

        nLog("DB Compressed (" & New FileInfo(cFullPath).Length & ")", Me.Name)
        Me.btnOK.Enabled = True
    End Sub

    Private Sub btnAnnuleren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnuleren.Click
        Me.Close()
    End Sub

End Class
