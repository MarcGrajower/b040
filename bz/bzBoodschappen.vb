Public Class bzBoodschappen
    Public Sub fillCBOColumn(ByVal cbo As DataGridViewComboBoxColumn)
        Dim o As New sqlClass
        o.Execute("select bdschp_omschrijving from boodschappen")
        cbo.Items.Clear()
        For Each r As DataRow In o.dt.Rows
            cbo.Items.Add(r("Bdschp_omschrijving"))
        Next
    End Sub
    'Public Sub updateTbl(ByVal cbo As DataGridViewComboBoxColumn)
    '    For Each c As String In cbo.Items
    '        checkNewValue(c)
    '    Next
    'End Sub
    Public Sub checkNewValue(ByVal c As String, ByVal cbo As DataGridViewComboBoxColumn)
        Dim o As New sqlClass
        Dim c1 = UCase(c)
        Dim n As Integer = o.Execute("select * from boodschappen where bdschp_omschrijving = '" & c1 & "'")
        If n = 0 Then
            o.ExecuteNonQuery("insert into boodschappen (bdschp_omschrijving) values ('" & c1 & "')")
            Me.fillCBOColumn(cbo)
        End If
    End Sub

End Class
