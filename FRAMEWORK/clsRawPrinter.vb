Imports System.Runtime.InteropServices

Public Class clsRawPrinter
    ' ----- The code in this class is based on Microsoft
    '       knowledge base article number 322090.
    '       Web: http://support.microsoft.com/?id=322090

    ' ----- Structure and API declarations.
    <StructLayout(LayoutKind.Sequential, _
    CharSet:=CharSet.Unicode)> _
    Private Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> _
           Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> _
           Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> _
           Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, _
       CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function OpenPrinter(ByVal src As String, _
       ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, _
       CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function ClosePrinter( _
       ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, _
       CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function StartDocPrinter( _
       ByVal hPrinter As IntPtr, ByVal level As Int32, _
       ByRef pDI As DOCINFOW) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, _
       CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function EndDocPrinter( _
       ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, _
       CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function StartPagePrinter( _
       ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, _
       CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function EndPagePrinter( _
       ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, _
       CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function WritePrinter( _
       ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, _
       ByVal dwCount As Int32, ByRef dwWritten As Int32) _
       As Boolean
    End Function

    Public Shared Function SendStringToPrinter( _
          ByVal targetPrinter As String, _
          ByVal stringContent As String, _
          ByVal documentTitle As String) As Boolean
        ' ----- Send an array of bytes to a printer queue.
        '       Return True on success.
        Dim printerHandle As IntPtr
        Dim errorCode As Int32
        Dim docDetail As DOCINFOW = Nothing
        Dim bytesWritten As Int32
        Dim printSuccess As Boolean
        Dim contentBytes As IntPtr
        Dim contentSize As Int32

        On Error Resume Next

        ' ----- Set up the identity of this document.
        With docDetail
            .pDocName = documentTitle
            .pDataType = "RAW"
        End With

        ' ----- Convert the string to ANSI text.
        contentSize = stringContent.Length()
        contentBytes = Marshal.StringToCoTaskMemAnsi( _
           stringContent)

        ' ----- Open the printer and print the document.
        printSuccess = False
        If OpenPrinter(targetPrinter, printerHandle, 0) Then
            If StartDocPrinter(printerHandle, 1, docDetail) Then
                If StartPagePrinter(printerHandle) Then
                    ' ----- Send the content to the printer.
                    printSuccess = WritePrinter(printerHandle, _
                       contentBytes, contentSize, bytesWritten)
                    EndPagePrinter(printerHandle)
                End If
                EndDocPrinter(printerHandle)
            End If
            ClosePrinter(printerHandle)
        End If

        ' ----- GetLastError may provide information on the
        '       last error. For now, just ignore it.
        If (printSuccess = False) Then errorCode = _
           Marshal.GetLastWin32Error()

        ' ----- Free up unused memory.
        Marshal.FreeCoTaskMem(contentBytes)

        ' ----- Complete.
        Return printSuccess
    End Function
End Class
