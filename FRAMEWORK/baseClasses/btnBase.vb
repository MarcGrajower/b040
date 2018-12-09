Public Class btnBase
    Inherits System.Windows.Forms.Button
    Implements IcontrolIOEnable
    Public mIO As IOValues
    Sub New()
        Me.Font = New Font("Trebuchet MS", 9)
    End Sub
    Public Property nIO() As IOValues
        Get
            Return mIO
        End Get
        Set(ByVal value As IOValues)
            mIO = value
        End Set
    End Property
    Public Sub ioEnable(ByVal Mode As ModeValues) Implements IcontrolIOEnable.ioEnable
        If Me.mIO = IOValues.IOAlwaysEnable Then
            Me.Enabled = True
            Me.TabStop = True
            Exit Sub
        End If
        If Me.mIO = IOValues.IOAlwaysDisable Then
            Me.Enabled = False
            Exit Sub
        End If
        If Mode = ModeValues.KeyEntry Then
            If Me.mIO = IOValues.IOKeyEntryEnable Then
                Me.Enabled = True
            Else
                Me.Enabled = False
            End If
        End If
        If Mode = ModeValues.RecordEntry Then
            If Me.mIO = IOValues.IOKeyEntryEnable Then
                Me.Enabled = False
            Else
                Me.Enabled = True
            End If
        End If
    End Sub
End Class
