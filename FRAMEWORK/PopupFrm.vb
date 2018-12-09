Public Class PopupFrm
    Public dt As DataTable
    Public caller As Control
    Public userCanceled As Boolean
    Public selected As Integer
    Public hideFirstColumn As Boolean = False
    Private Sub PopupFrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Me.selected = Me.g.CurrentRow.Index
        Me.Close()
    End Sub
    Private Sub PopupFrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(27) Or Me.g.CurrentRow.Index = 0 Then
            Me.userCanceled = True
        End If
        Me.selected = Me.g.CurrentRow.Index - 1
        Me.Close()
    End Sub

    Private Sub PopupFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = Me.caller.Parent.PointToScreen(Me.caller.Location)
        Me.Left = Me.Left + Me.caller.Width
        If TypeOf Me.caller Is DataGridViewTextBoxEditingControl Then Me.Top = Me.Top - 4
        Me.g.Top = 0
        Me.g.Left = 0
        Me.g.RowHeadersVisible = False
        Me.g.ColumnHeadersVisible = False
        Me.g.DefaultCellStyle.Font = New Font("Trebuchet MS", 9.0!, FontStyle.Bold)
        Me.g.GridColor = Color.LightGray
        Me.g.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.g.DefaultCellStyle.BackColor = Color.DarkBlue
        Me.g.DefaultCellStyle.ForeColor = Color.White
        Me.g.DefaultCellStyle.SelectionBackColor = Color.Red
        Me.g.DefaultCellStyle.SelectionForeColor = Color.White
        Me.g.BackgroundColor = Color.DarkBlue
        Me.g.DataSource = Me.dt
        For i As Integer = 1 To Me.g.Columns.Count
            Me.g.Columns(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        If hideFirstColumn = True Then
            g.Columns(0).Visible = False
        End If
    End Sub

    Private Sub PopupFrm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim w As Integer = 0
        For Each col As DataGridViewColumn In Me.g.Columns
            w = w + col.Width + 1
        Next
        Me.g.Width = w + 20
        Me.Width = w + 2
        Me.g.Height = Math.Min(20, Math.Max(Me.dt.Rows.Count, 10)) * (Me.g.RowTemplate.Height + 1)
        Me.Height = Me.g.Height + 5
        If Me.Top + Me.Height > My.Computer.Screen.WorkingArea.Height Then
            Me.Top = My.Computer.Screen.WorkingArea.Height - Me.Height
        End If
    End Sub

    Private Sub g_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles g.Click
        Me.selected = Me.g.CurrentRow.Index
        Me.Close()
    End Sub
End Class