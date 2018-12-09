Imports System.Data.OleDb.OleDbCommand
Partial Class dsArtikel
    Partial Class ArtikelDataTable

        Private Sub ArtikelDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.Art_BTWColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace dsArtikelTableAdapters

    Partial Public Class ArtikelTableAdapter

    End Class
End Namespace
