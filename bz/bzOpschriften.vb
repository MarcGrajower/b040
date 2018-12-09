Public Class bzOpschriften
    Public Sub fillCBOColumn(ByVal cbo As DataGridViewComboBoxColumn)
        Dim o As New sqlClass
        o.Execute("select ops_omschrijving from Opschriften")
        cbo.Items.Clear()
        For Each r As DataRow In o.dt.Rows
            cbo.Items.Add(r("Ops_omschrijving"))
        Next
        ''
    End Sub
    'Public Sub updateTbl(ByVal cbo As DataGridViewComboBoxColumn)
    '    For Each c As String In cbo.Items
    '        checkNewValue(c)
    '    Next
    'End Sub
    Public Sub checkNewValue(ByVal c As String, ByVal cbo As DataGridViewComboBoxColumn)
        If Trim(c) = "" Then
            c = ""
            Exit Sub
        End If
        Dim c1 = UCase(c)
        Dim o As New sqlClass
        Dim n As Integer = o.Execute("select * from Opschriften where ops_omschrijving = '" & c1 & "'")
        If n = 0 Then
            o.ExecuteNonQuery("insert into Opschriften (ops_omschrijving) values ('" & c1 & "')")
            Me.fillCBOColumn(cbo)
        End If
    End Sub

End Class
