Public MustInherit Class CNC_Port

    MustOverride Function Open(ByVal ps As PortSetting) As Boolean

    MustOverride Sub SendDirect(ByVal Text As String)

    MustOverride Sub SendIndirect2(ByRef Text As String)

    MustOverride Sub Close()

    MustOverride ReadOnly Property isOpen() As Boolean

    '    Event DataReceived(ByVal mySerInput As String)

    '  Event DataBlockSended(ByVal Number As Integer, ByVal Total As Integer)

End Class
