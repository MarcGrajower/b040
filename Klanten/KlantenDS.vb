Partial Class KlantenDS
    Partial Class KlantenDataTable

        Private Sub KlantenDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.KL_VoldaanColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace KlantenDSTableAdapters
    
    Partial Public Class KlantenCRUD
    End Class
End Namespace
