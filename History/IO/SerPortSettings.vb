Public Class SerPortSetting
    Inherits PortSetting

    Property PortName As String
    Property BaudRate As Integer
    Property parity As String
    Property databits As Integer
    Property stopbits As Integer
    Property handshake As String
    Property readtimeout As Integer
    Property writetimeout As Integer

    Sub getConfig(ByVal myConnection As XElement)
        If myConnection IsNot Nothing Then


            For Each att In myConnection.Attributes

                Select Case att.Name.ToString.ToLower
                    Case "type"
                        Type = att.Value.ToString

                    Case "id"
                        Id = att.Value.ToString

                    Case "port"
                        PortName = att.Value.ToString

                    Case "speed"
                        BaudRate = att.Value.ToString

                    Case "parity"
                        parity = att.Value.ToString

                    Case "databits"
                        databits = att.Value.ToString

                    Case "stopbits"
                        stopbits = att.Value.ToString

                    Case "handshake"
                        handshake = att.Value.ToString

                    Case "readtimeout"
                        readtimeout = att.Value.ToString

                    Case "writetimeout"
                        writetimeout = att.Value.ToString

                End Select
            Next

        End If

    End Sub

End Class
