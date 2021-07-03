Imports System.Text.RegularExpressions
Public Class Helpers
    Public Shared ErrorMessage As String = ""
    Public Shared Function IsValidEmailAddress(address As String) As Boolean
        ErrorMessage = $"Email adres [{address}] is niet geldig"
        Dim emailPattern = "[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))"
        Dim regex As New Regex(emailPattern)
        Return (regex.Matches(address).Count() <> 0)
    End Function

End Class
