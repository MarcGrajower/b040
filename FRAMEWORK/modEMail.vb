Imports System.Net.Mail
Module modEMail
    Public Sub SendEmail(ByVal subject As String, ByVal messageBody As String, _
         ByVal fromAddress As String, ByVal toAddress As String, ByVal ccAddress As String)

        Dim message As New MailMessage()
        Dim client As New SmtpClient()

        'Set the sender's address
        message.From = New MailAddress(fromAddress)
        'Allow multiple "To" addresses to be separated by a semi-colon
        If (toAddress.Trim.Length > 0) Then
            For Each addr As String In toAddress.Split(";"c)
                message.To.Add(New MailAddress(addr))
            Next
        End If

        'Allow multiple "Cc" addresses to be separated by a semi-colon
        If (ccAddress.Trim.Length > 0) Then
            For Each addr As String In ccAddress.Split(";"c)
                message.CC.Add(New MailAddress(addr))
            Next
        End If
        'Set the subject and message body text
        message.Subject = subject
        message.IsBodyHtml = False
        message.Body = messageBody

        client.Host = "smtp.gMAIL.com"
        client.Credentials = New System.Net.NetworkCredential("b040Mail2@gmail.com", "Mail2B040")
        client.Port = 587
        client.EnableSsl = True
        'Send the e-mail message
        client.Send(message)
    End Sub
End Module
