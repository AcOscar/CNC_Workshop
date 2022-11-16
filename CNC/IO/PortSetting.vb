
Public MustInherit Class PortSetting

    Property Type As String
    Property Id As String

    MustOverride Sub getConfig(ByVal myConnection As XElement)

End Class
