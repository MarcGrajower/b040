Imports System
Imports System.Collections.Specialized
Imports System.Collections.ObjectModel
Imports System.Collections
Imports System.Text
Imports System.Configuration
Imports Microsoft.VisualBasic

Public Module modB040Config
    Public Function lb040Config(ByVal f As frmMain) As Boolean
        lb040Config = False
        ' "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\data\b040\b040_be.accdb"
        Dim cConnString As String = ""
        Dim cInifile As String = "C:\_config\b040.ini"
        If System.IO.File.Exists(cInifile) = False Then
            MsgBox("Cannot open " & cInifile & vbCrLf & "Terminating ...")
            Exit Function
        End If
        f.ToolStripStatusLabel1.Text = cInifile & " found."
        Dim reader As New System.IO.StreamReader(cInifile)
        Dim c As String
        Do While Not reader.EndOfStream
            c = reader.ReadLine
            If Strings.Left(c, 7) = "CONNECT" Then
                cConnString = Mid(c, 11)
            End If
        Loop
        Global.b040.My.MySettings.Default("b040_beConnectionString") = cConnString
        Dim lFailed As Boolean = False
        Try
            nLog("Starting Up", "Main")
        Catch
            lFailed = True
        End Try
        If lFailed Then
            MsgBox("Cannot connect to database" & vbCrLf &
                   "Connection : " & Global.b040.My.MySettings.Default("b040_beConnectionString") & vbCrLf &
                   "Terminating ... ")
            Exit Function
        End If
        lb040Config = True
    End Function
    Public Function cConfiguredUitzPrinter() As String
        ' MG 02/apr/11
        Dim o As New sqlClass
        Dim c = cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = '" & My.Computer.Name & "' and cfg_Variable = 'UITZPRINTER'"))
        If c <> "" Then Return c
        Return cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = 'DEFAULT' and cfg_Variable = 'UITZPRINTER'"))
    End Function
    Public Function cDefaultPrinter() As String
        Dim c As String = "select cfg_Value from config where cfg_Station = " & sqlClass.c(My.Computer.Name) & " and cfg_Variable = " & sqlClass.c("DEFPRINTER")
        Dim o As New sqlClass : Dim n As Long = o.Execute(c)
        If n = 0 Then
            Dim pc As New PrinterClass
            Return pc.DefaultPrinterName
        End If
        Return o.dt(0)("cfg_value")
    End Function
    Public Function cXLSFolder() As String
        ' MG 03/apr/11
        Dim o As New sqlClass
        Dim c = cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = '" & My.Computer.Name & "' and cfg_Variable = 'XLSFOLDER'"))
        If c <> "" Then Return c
        Return cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = 'DEFAULT' and cfg_Variable = 'XLSFOLDER'"))
    End Function
    Public Function lPreviewSaves() As Boolean
        ' MG 16/apr/11
        Dim o As New sqlClass
        If cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = '" & My.Computer.Name & "' and cfg_Variable = 'PREVIEWSAVES'")) = "YES" Then Return True
        If cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = 'DEFAULT' and cfg_Variable = 'PREVIEWSAVES'")) = "YES" Then Return True
        Return False

    End Function
    Public Function cDocsFolder() As String
        ' MG 03/apr/11
        ' enhance : create folder/ throw exception if there is no such folder.
        Dim o As New sqlClass
        Dim c = cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = '" & My.Computer.Name & "' and cfg_Variable = 'DOCSFOLDER'"))
        If c <> "" Then Return c
        Return cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = 'DEFAULT' and cfg_Variable = 'DOCSFOLDER'"))
    End Function
    Public Function Generic(cField As String)
        Dim o As New sqlClass
        Dim c = cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = '" & My.Computer.Name & "' and cfg_Variable = " & sqlClass.c(cField)))
        If c <> "" Then Return c
        Return cNvl(o.ExecuteScalar("select cfg_Value from config where cfg_station = 'DEFAULT' and cfg_Variable = " & sqlClass.c(cField)))
    End Function
End Module
