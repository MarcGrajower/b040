Imports System.Data.OleDb
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Public Class TestForm
    Dim cancelEdit As Boolean = False
    Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As New sqlClass
        Dim cSql As String = "select kl_naam from klanten"
        sql.Execute(cSql)
        'DataGridView1.DataSource = sql.dt
        Dim col As New DataGridViewColumn
        col.Name = "colName"
        DataGridView1.Columns.Add("Test", "Test")
        For Each dr As DataRow In sql.dt.Rows
            Dim dgvR As Integer = DataGridView1.Rows.Add()
            DataGridView1(0, dgvR).Value = dr(0)
        Next
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    End Sub
 
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        DataGridView1.CurrentCell.Value = True

    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
 
    End Sub
    Sub dataGridView1_CurrentCellDirtyStateChanged( _
    ByVal sender As Object, ByVal e As EventArgs) _
    Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Index = DataGridView1.CurrentRow.Index Then
                r.Cells(0).Value = True
                r.Cells(0).ReadOnly = True
            Else
                r.Cells(0).Value = False
                r.Cells(0).ReadOnly = False
            End If
        Next
        DataGridView1.Invalidate()
    End Sub

   

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DateTimePicker1.Value = Now()

    End Sub
End Class
