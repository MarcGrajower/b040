Imports System.IO

Module gen
    Public Function WrapText(ByVal Text As String, ByVal LineLength As Integer) As List(Of String)
        Dim ReturnValue As New List(Of String)
        ' Remove leading and trailing spaces
        Text = Trim(Text)
        Dim Words As String() = Text.Split(" ")
        If Words.Length = 1 And Words(0).Length > LineLength Then
            ' Text is just one big word that is longer than one line
            ' Split it mercilessly
            Dim lines As Integer = (Int(Text.Length / LineLength) + 1)
            Text = Text.PadRight(lines * LineLength)
            For i As Integer = 0 To lines - 1
                Dim SliceStart As Integer = i * LineLength
                ReturnValue.Add(Text.Substring(SliceStart, LineLength))
            Next
        Else
            Dim CurrentLine As New System.Text.StringBuilder
            For Each Word As String In Words
                ' will this word fit on the current line?
                If CurrentLine.Length + Word.Length < LineLength Then
                    CurrentLine.Append(Word & " ")
                Else
                    ' is the word too long for one line
                    If Word.Length > LineLength Then
                        ' hack off the first piece, fill out the current line and start a new line
                        Dim Slice As String = Word.Substring(0, LineLength - CurrentLine.Length)
                        CurrentLine.Append(Slice)
                        ReturnValue.Add(CurrentLine.ToString)
                        CurrentLine = New System.Text.StringBuilder()

                        ' Remove the first slice from the word
                        Word = Word.Substring(Slice.Length, Word.Length - Slice.Length)

                        ' How many more lines do we need for this word?
                        Dim RemainingSlices As Integer = Int(Word.Length / LineLength) + 1
                        For LineNumber As Integer = 1 To RemainingSlices
                            If LineNumber = RemainingSlices Then
                                'this is the last slice
                                CurrentLine.Append(Word & " ")
                            Else
                                ' this is not the last slice
                                ' hack off a slice that is one line long, add that slice
                                ' to the output as a line and start a new line
                                Slice = Word.Substring(0, LineLength)
                                CurrentLine.Append(Slice)

                                ReturnValue.Add(CurrentLine.ToString)
                                CurrentLine = New System.Text.StringBuilder()

                                ' Remove the slice from the Word
                                Word = Word.Substring(Slice.Length, Word.Length - Slice.Length)
                            End If
                        Next
                    Else
                        ' finish the current line and start a new one with the wrapped word
                        ReturnValue.Add(CurrentLine.ToString)
                        CurrentLine = New System.Text.StringBuilder(Word & " ")
                    End If
                End If
            Next

            ' Write the last line to the output
            If CurrentLine.Length > 0 Then
                ReturnValue.Add(CurrentLine.ToString)
            End If
        End If
        Return ReturnValue
    End Function
    Public Function mLines(ByVal c As String) As Integer
        Dim a As Array = Split(c, vbNewLine)
        Return a.Length
    End Function
    Public Function cReformat(ByVal cInput As String, Optional ByVal n As Integer = 40)
        Dim l1 As Array = Split(cInput, vbNewLine)
        Dim l2 As New List(Of String)
        For Each c2 As String In l1
            For Each c3 As String In WrapText(c2, n)
                l2.Add(c3)
            Next
        Next
        Dim c As String = ""
        For Each c2 As String In l2
            c &= c2 & vbNewLine
        Next
        c = Left(c, Len(c) - 1)
        Return c
    End Function
    Function cNvl(ByVal v) As String
        If v Is Nothing Then Return ""
        If v Is DBNull.Value Then Return ""
        Return CType(v, String)
    End Function
    Function nNvlI(ByVal v) As Long
        If v Is Nothing Then Return 0
        If v Is DBNull.Value Then Return 0
        Return CType(v, Long)
    End Function
    Function nNvlD(ByVal v) As Double
        If v Is Nothing Then Return 0
        If v Is DBNull.Value Then Return 0
        Dim d As Double = 0
        Double.TryParse(v, d)
        Return d
    End Function
    Function bNvl(ByVal v) As Boolean
        If v Is Nothing Then Return False
        If v Is DBNull.Value Then Return False
        Return CType(v, Boolean)
    End Function
    Function nRound(ByVal d As Double, ByVal dec As Integer) As Double
        ' MG 21/feb/11
        ' careful, if you don't use this function you "round to even", meaning 1.255 will round to 1.26 and 1.265 will round to 1.26.
        Return Math.Round(d, dec, MidpointRounding.AwayFromZero)
    End Function
    Function nRoundup(ByVal n As Double, ByVal nDecimals As Integer) As Double
        If gen.nRound(n, nDecimals) = n Then Return n
        Return gen.nRound(n + 0.5 * 10 ^ -nDecimals, nDecimals)
    End Function
End Module
