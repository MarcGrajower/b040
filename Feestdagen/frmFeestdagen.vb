Public Class frmFeestdagen
    Inherits frmB040
    Public Overrides Sub Clear()
        '        MyBase.clear()
        Me.FeestdagenDataset.Clear()
        Me.txtFD_Datum.Text = Format(Today, cDateFormat)
        Me.FormMode = ModeValues.KeyEntry
        Me.txtFD_Datum.Focus()
        unlockSession(Me.nLogSession)
    End Sub

    Private Sub frmFeestdagen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.End Then
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            Me.SaveButton_Click(sender, e)
        End If
    End Sub

    Private Sub frmFeestdagen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtFD_Datum.Text = Format(Today, cDateFormat)
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim nPK As Integer = Me.FeestdagenBindingSource.Current("ID")
        Me.FeestdagenBindingSource.EndEdit()
        Me.FeestdagenTableAdapter.Update(FeestdagenDataset.Feestdagen)
        unLock("Feestdagen", nPK)
        Dim c As String = IIf(nPK = 0, "Append ", "Update ") & Me.txtFD_Datum.Text
        Dim a As LogAction = IIf(nPK = 0, LogAction.logcreate, LogAction.logUpdate)
        nLog(c, Me.Name, LogType.logNormal, a, "Feestdagen", nPK)
        Me.Clear()
    End Sub


    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        Dim nPK As Integer = Me.FeestdagenBindingSource.Current("ID")
        Me.FeestdagenBindingSource.RemoveCurrent()
        Me.FeestdagenBindingSource.EndEdit()
        Me.FeestdagenTableAdapter.Update(FeestdagenDataset.Feestdagen)
        unLock("Feestdagen", nPK)
        nLog("Delete " & Me.txtFD_Datum.Text, Me.Name, LogType.logNormal, LogAction.logDelete, "Feestdagen", nPK)
        Me.clear()
    End Sub
    Private Sub txtFD_Datum_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFD_Datum.Validating
        Dim d As Date
        Dim lOK As Boolean = True
        If checkDate(Me.txtFD_Datum.Text) Then
            d = CDate(Me.txtFD_Datum.Text)
        Else
            MsgBox(Me.txtFD_Datum.Text & " is niet correct.")
            e.Cancel = True
            Exit Sub
        End If
        If d < Today Then
            MsgBox("Gelieve een datum in de toekomst te willen aangeven.")
            e.Cancel = True
            Exit Sub
        End If
        If Me.lastKeycode <> Keys.Tab Then
            Exit Sub
        End If
        Dim n As Integer = Me.FeestdagenTableAdapter.Fill(Me.FeestdagenDataset.Feestdagen, d)
        Me.txtFD_Datum.Text = Format(d, cDateFormat) ' needed after a call to binding?
        If n = 0 Then
            Me.FeestdagenBindingSource.AddNew()

            Me.txtFD_Datum.Text = Format(d, cDateFormat) ' needed after a call to binding?

            Me.FormMode = ModeValues.RecordEntry
            Exit Sub
        End If
        If Me.txtFD_Datum.previousText <> Me.txtFD_Datum.Text Then
            e.Cancel = True
            Me.txtFD_Datum.previousText = Me.txtFD_Datum.Text
            Exit Sub
        End If
        If lLock(Me.nLogSession, "Feestdagen", Me.FeestdagenBindingSource.Current("ID"), "") Then
            Me.FormMode = ModeValues.RecordEntry
            txtFD_Naam.Focus()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
