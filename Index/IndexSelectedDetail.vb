Public Class IndexSelectedDetail
    Public nHoev As Double
    Public nBedrag As Double
    Public f As b040.frmIndex
    Sub New(ByVal oFrm As b040.frmIndex)
        Me.f = oFrm
    End Sub
    Public Function nPrice() As Double
        Dim nRow As Integer = f.grdDetail.CurrentRow.Index
        Me.nHoev = f.grdDetail("COLHOEV", nRow).Value
        Me.nBedrag = f.grdDetail("COLBEDRAG1", nRow).Value
        If Me.nHoev = 0 Then
            Return 0
        End If
        Return Me.nBedrag / Me.nHoev
    End Function
    Public Sub recompute(Optional ByVal nDetailCurrentRow As Integer = -1)
        If nDetailCurrentRow = -1 Then nDetailCurrentRow = Me.f.grdDetail.CurrentCell.RowIndex
        Dim oSql As New sqlClass
        Dim c As String
        c = "update " & Me.f.cGlobalFilename
        c &= " set expostHoev = " & modDutch.cIntegerParse(Me.f.grdDetail("COLHOEVEP", nDetailCurrentRow).Value)
        c &= ", expostBedrag = " & sqlClass.cDoubleForjet(Me.f.grdDetail("COLBEDRAGEP", nDetailCurrentRow).Value)
        c &= " where bestd_id = " & Me.f.grdDetail("COLBESTD_ID", nDetailCurrentRow).Value
        oSql.ExecuteNonQuery(c)
        Dim nTotHoev As Long = 0
        Dim nTotBedrag As Double = 0
        For Each oRow As DataGridViewRow In Me.f.grdDetail.Rows
            nTotHoev += Me.f.grdDetail("COLHOEVEP", oRow.Index).Value
            nTotBedrag += Me.f.grdDetail("COLBEDRAGEP", oRow.Index).Value
        Next
        With Me.f
            .GrdTransaction("COLEXPOST", .GrdTransaction.SelectedRows(0).Index).Value = nTotBedrag
        End With
        nTotBedrag = 0
        For Each oRow As DataGridViewRow In Me.f.GrdTransaction.Rows
            nTotBedrag += Me.f.GrdTransaction("COLEXPOST", oRow.Index).Value
        Next
        Me.f.GrdKlant("EXPOST", Me.f.GrdKlant.SelectedRows(0).Index).Value = nTotBedrag
    End Sub

End Class
