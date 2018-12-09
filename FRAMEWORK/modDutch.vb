Imports System.Globalization
Module modDutch
    Public cDateFormat As String = "dd/MM/yy"
    Public cDateWithWeekdayFormat As String = "dddd dd/MMM/yy"
    Function checkDate(ByVal c As String) As Boolean
        Dim d As Date
        Return Date.TryParseExact(c, cDateFormat, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, d)
    End Function
    Public Function parse_date(datestring As String) As Date
        Return Date.Parse(datestring, New CultureInfo("nl-BE"))
    End Function

    Function checkDateEmpty(ByVal c As String) As Boolean
        Return Trim(c) = "/  /"
    End Function
    Function YesNO(ByVal c As String, Optional ByVal Alignment As ContentAlignment = ContentAlignment.MiddleCenter) As Boolean
        Dim o As New b040.YesNoForm
        o.DefaultLabelHeight = o.lblbase1.Size.Height
        o.lblbase1.Text = c
        o.lblbase1.TextAlign = Alignment
        Return o.ShowDialog = 1
    End Function
    Public Function cDagInDeWeek(ByVal d As Date) As String
        Select Case d.DayOfWeek
            Case 0 : Return "Zondag"
            Case 1 : Return "Maandag"
            Case 2 : Return "Dinsdag"
            Case 3 : Return "Woensdag"
            Case 4 : Return "Donderdag"
            Case 5 : Return "Vrijdag"
            Case 6 : Return "Zaterdag"
            Case Else : Return ""
        End Select
    End Function
    Function cIntegerParse(ByVal c As String) As String
        Dim c1 As String = ""
        For i As Integer = 1 To Len(c)
            If Mid(c, i, 1) <> "." Then
                c1 = c1 + Mid(c, i, 1)
            End If
        Next
        Return c1
    End Function
End Module
