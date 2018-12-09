Public Class frmPaswoord
    Dim lAccess As Boolean = False

    Private Sub TxtPaswoord_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPaswoord.Validated
        Me.DialogResult = IIf(Me.lAccess, Windows.Forms.DialogResult.OK, Windows.Forms.DialogResult.No)
        Me.Close()
    End Sub
    Private Sub TxtPaswoord_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPaswoord.Validating
        Me.lAccess = (Strings.Left(Me.TxtPaswoord.Text, 4) = "8488")
    End Sub

   
End Class
