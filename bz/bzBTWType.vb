Public Class bzBTWType
    Public Sub fillCbo(ByVal cbo As cboBase)
        Dim sql As New sqlClass
        sql.Execute("Select * from BTWType")
        For Each r As DataRow In sql.dt.Rows
            cbo.Items.Add(r("BTW_OMSCHRIJVING"))
        Next
    End Sub
    Public Shared Sub fillListbox(lb As checkedListboxBase)
        Dim sql As New sqlClass
        sql.Execute("select * from btwtype")
        For Each r As DataRow In sql.dt.Rows
            lb.Items.Add(r("BTW_OMSCHRIJVING"))
        Next
    End Sub

    Public Function id(ByVal c As String) As Long
        Dim sql As New sqlClass
        Return sql.ExecuteScalar("select btw_id from BtwType where BTW_OMSCHRIJVING = '" & c & "'")
    End Function
    Public Shared Function cOmschrijving(ByVal nPk As Long) As String
        Dim o As New sqlClass : Return o.ExecuteScalar("select btw_Omschrijving from btwtype where BTW_ID = " & nPk)
    End Function
End Class
