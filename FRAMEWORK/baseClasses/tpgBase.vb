Public Class tpgBase
    Inherits System.Windows.Forms.TabControl
    Implements IcontrolIOEnable
    Implements IControlMaskit
    Implements IControlBindingFormat
    Sub New()
        MyBase.New()
        Me.BackColor = Color.Silver
        Me.TabStop = False
        Me.Font = New Font("Trebuchet MS", Me.Font.Size)
    End Sub
    Public Sub ioEnable(ByVal Mode As ModeValues) Implements IcontrolIOEnable.ioEnable
        For Each p As TabPage In Me.TabPages
            For Each ctrl As Control In p.Controls
                If TypeOf ctrl Is IcontrolIOEnable Then
                    CType(ctrl, IcontrolIOEnable).ioEnable(Mode)
                End If
            Next
        Next
    End Sub
    Public Sub MaskIt() Implements IControlMaskit.MaskIt
        For Each p As TabPage In Me.TabPages
            For Each ctrl As Control In p.Controls
                If TypeOf ctrl Is IControlMaskit Then
                    CType(ctrl, IControlMaskit).MaskIt()
                End If
            Next
        Next
    End Sub
    Public Sub BindingFormat() Implements IControlBindingFormat.BindingFormat
        For Each p As TabPage In Me.TabPages
            For Each ctrl As Control In p.Controls
                If TypeOf ctrl Is IControlBindingFormat Then
                    CType(ctrl, IControlBindingFormat).BindingFormat()
                End If
            Next
        Next
    End Sub
End Class
