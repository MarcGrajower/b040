Imports System.Windows.Forms

Public Class YesNoForm
    Dim mDefaultLabelHeight As Integer
    WriteOnly Property DefaultLabelHeight() As Integer
        Set(ByVal value As Integer)
            mDefaultLabelHeight = value
        End Set
    End Property
    Private Sub BtnBase1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBase1.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnBase2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBase2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub YesNoForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim n As Integer = Me.lblbase1.Size.Height - Me.mDefaultLabelHeight
        If n <= 0 Then Exit Sub
        Me.BtnBase1.Top += n
        Me.BtnBase2.Top += n
        Me.Height += n
    End Sub

 
    Private Sub YesNoForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.J Then
            BtnBase1_Click(sender, e)
        End If
        If e.KeyCode = Keys.Y Then
            BtnBase1_Click(sender, e)
        End If
        If e.KeyCode = Keys.N Then
            BtnBase2_Click(sender, e)
        End If
    End Sub
End Class
