Imports System.Threading
Public Enum ErrSeverity
    errWarning = 1
    errTerminal = 2
End Enum
Public Class ExceptionMG
    Inherits Exception
    Sub New()
        MsgBox("mg exception")
    End Sub
End Class


Friend Class ThreadExceptionHandler

    '

    ' Handles the thread exception.

    '

    Public Sub Application_ThreadException(ByVal sender As System.Object, ByVal e As ThreadExceptionEventArgs)
        Dim c As String = "Onvoorziene Fout in het programma."
        c = c & vbCrLf & e.Exception.Message
        c = c & vbCrLf & "Kleinblatt 2.0 (B040) wordt nu afgesloten."
        MsgBox(c)

        Dim i As Integer = nLog()
        Dim da As New dsErrorTableAdapters.ErrorTableAdapter

        Dim ex As Exception = e.Exception
        c = e.Exception.Message
        c = c & vbCrLf & "sender : " & sender.ToString
        c = c & vbCrLf & Environment.GetEnvironmentVariable("username") & " op " & My.Computer.Name
        c = c & vbCrLf
        c = c & vbCrLf & ex.ToString
        Dim S = Split(c, vbCrLf)
        Try
            SendEmail("B040 Terminal Error : " & S(0), c, "b040Mail2@gmail.com", "b040Mail2@gmail.com", "p806Antwerp@gmail.com")
        Catch e1 As Exception
            MsgBox("EMail kon niet gestuurd worden." & vbCrLf & e1.ToString)
        End Try
        Dim n As Integer = 0
        Try
            n = da.Insert(My.Computer.Name, Environment.GetEnvironmentVariable("username"), Now, c, Left(S(0), 40), ErrSeverity.errTerminal)
        Catch
        End Try
        Application.Exit()

    End Sub


End Class ' ThreadExceptionHandler
