Public Class frmIndexCN

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmIndexCN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormMode = ModeValues.RecordEntry
        Dim oTooltip As New ToolTip
        oTooltip.ShowAlways = True
        oTooltip.SetToolTip(Me.BtnOK, "Opheffen van deze operatie wordt niet ondersteund.")
        oTooltip.SetToolTip(Me, "Het is niet aangewezen om CN's van '100% klanten' te annuleren")
        oTooltip.Active = True
        For Each oCol As DataGridViewColumn In Me.grdCN.Columns
            If oCol.Visible = True And oCol.GetType.Name = "DataGridViewTextboxColumn" Then oCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next

    End Sub
End Class
