Public Class lblBase
    Inherits system.Windows.Forms.Label
    'Public Sub New()
    'MyBase.new()
    ' Me.BackColor = Me.Parent.BackColor
    'End Sub
    Sub New()
        Me.Font = New Font("Trebuchet MS", Me.Font.Size)
    End Sub
End Class
