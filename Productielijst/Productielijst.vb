Public Class Productielijst
    ''' <summary>
    ''' Populates a list from PRODUCTIELIJST spreadsheet
    ''' Used to group ARTIKELS in PRODUCTIEPLAN
    ''' aka DEEG
    ''' </summary>
    Public Shared spreadsheetFilename As String = "Productielijst.xls"
    Class Model
        Public Groep As Integer
        Public ArtikelNummer As String
        Public Rank As Integer
        Sub New()
        End Sub
        Sub New(g As Integer, a As String, r As Integer)
            Groep = g
            ArtikelNummer = a
            Rank = r

        End Sub
    End Class
    Friend Shared list As New List(Of Model)
    ''' <summary>
    ''' reads the spreadsheet and populates list
    ''' Not done in New so that if needed the spreasheetFilename can be changed by client.
    ''' </summary>
    Public Shared Sub Initialise()
        Dim path As String = modB040Config.cXLSFolder & spreadsheetFilename
        Using excel As New clsExcel
            excel.openWorkbook(path)
            Dim break As String = "****"
            Dim row As Integer = 1
            Dim groep As Integer = 0
            Dim rank As Integer = 0
            While excel.cGet(row, 2) <> ""
                Dim model As New Model()
                Dim column2 As String = excel.cGet(row, 2)
                Dim trimmed As String = Trim(column2)
                Dim artikelNummer As String = Strings.Right(New String(" ", 4) & trimmed, 4)
                Dim groepString As String = Trim(excel.cGet(row, 1))
                If (groepString = break Or groepString = "") = False Then
                    break = groepString
                    groep = groep + 1
                    rank = 0
                End If
                rank = rank + 1
                model.Rank = rank
                model.ArtikelNummer = artikelNummer
                model.Groep = groep
                list.Add(model)
                row = row + 1
            End While
        End Using
    End Sub
    Public Shared Function GetModel(artikelNummer As String, Optional ByRef found As Boolean = True) As Model
        Dim model As New Model()
        model = list.AsEnumerable.FirstOrDefault(Function(m As Model) m.ArtikelNummer = artikelNummer)
        If model Is Nothing Then
            found = False
            model = New Model(999, "***", 999)
        End If
        Return model
    End Function
End Class
