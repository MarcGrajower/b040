Partial Class StandaardenDS
    Partial Class TypeStBEstDataTable

        Private Sub TypeStBEstDataTable_TypeStBEstRowChanging(ByVal sender As System.Object, ByVal e As TypeStBEstRowChangeEvent) Handles Me.TypeStBEstRowChanging

        End Sub

    End Class

    Partial Class StandaardHDataTable

        Private Sub StandaardHDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.sth_KlantColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace StandaardenDSTableAdapters
    
    Partial Public Class STandaardDTableAdapter
    End Class
End Namespace

Namespace StandaardenDSTableAdapters
    
    Partial Public Class StandaardHTableAdapter
    End Class
End Namespace
