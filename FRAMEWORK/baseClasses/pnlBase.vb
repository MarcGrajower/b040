Public Class pnlBase
    Inherits System.Windows.Forms.Panel
    Implements IcontrolIOEnable
    Implements IControlMaskit
    Implements IControlBindingFormat
    Sub New()
        MyBase.New()
        Me.BackColor = Color.Silver
        Me.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Me.TabStop = False
    End Sub
    Public Sub ioEnable(ByVal Mode As ModeValues) Implements IcontrolIOEnable.ioEnable
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is IcontrolIOEnable Then
                CType(ctrl, IcontrolIOEnable).ioEnable(Mode)
            End If
        Next
    End Sub
    Public Sub MaskIt() Implements IControlMaskit.MaskIt
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is IControlMaskit Then
                CType(ctrl, IControlMaskit).MaskIt()
            End If
        Next
    End Sub
    Public Sub BindingFormat() Implements IControlBindingFormat.BindingFormat
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is IControlBindingFormat Then
                CType(ctrl, IControlBindingFormat).BindingFormat()
            End If
        Next
    End Sub
End Class
