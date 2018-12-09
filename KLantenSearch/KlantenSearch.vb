Imports System.Data
Public Class KlantenSearch
    Public klanten As New DataTable
    Public Property ReturnValue As Long = 0
    Private Sub KlantenSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = klanten
        DataGridView1.Columns(0).Visible = False
        For i As Integer = 1 To DataGridView1.Columns.Count
            DataGridView1.Columns(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        DataGridView1.ColumnHeadersVisible = False
        DataGridView1.DefaultCellStyle.ForeColor = Color.DarkBlue
        DataGridView1.DefaultCellStyle.SelectionBackColor = applicationFocusBackcolor
        DataGridView1.Focus()
        Activate()
    End Sub

    Private Sub DataGridView1_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        ' If e.RowIndex = Nothing Then Exit Sub
        If e.RowIndex >= DataGridView1.Rows.Count Then Exit Sub
        Dim klid As Integer = gen.nNvlI(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
        If klid = 0 Then Exit Sub
        Dim klantinfo As New bzKlantenSearch.clsKlantInfo()
        bzKlantenSearch.GetKlant(klid, klantinfo)
        TelefoonTextBox.Text = klantinfo.Telefoon
        AdresTextBox.Text = klantinfo.Adres
        PostNrTextBox.Text = klantinfo.PostNr
        GemeenteTextBox.Text = klantinfo.Gemeente
        FaxTextBox.Text = klantinfo.Fax
        GSMTextBox.Text = klantinfo.GSM
        BTW_NRTextbox.Text = klantinfo.BTW_NR
        Type_FactTextbox.Text = klantinfo.Type_Fact
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        setReturnValue(e.RowIndex)
        Close()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Escape Then
            setReturnValueToZero()
            Close()
        End If
        If e.KeyCode = Keys.Enter Then
            setReturnValue(DataGridView1.CurrentRow.Index)
            Close()
        End If
    End Sub
    Private Sub setReturnValue(rowIndex As Integer)
        ReturnValue = gen.nNvlI(DataGridView1.Rows(rowIndex).Cells(0).Value)
    End Sub
    Private Sub setReturnValueToZero()
        ReturnValue = 0
    End Sub
End Class
