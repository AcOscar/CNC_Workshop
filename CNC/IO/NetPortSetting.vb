Public Class NetPortSetting : Inherits PortSetting

    Public Property IPv4 As String

    Public Property SubnetMask As String


    Public Property HPGLPort As String

    Public Property StatusPort As String

    Overrides Sub getConfig(ByVal myConnection As XElement)
        If myConnection IsNot Nothing Then

            For Each att In myConnection.Attributes

                Select Case att.Name.ToString.ToLower
                    Case "type"
                        Type = att.Value.ToString

                    Case "id"
                        Id = att.Value.ToString

                    Case "ipv4"
                        IPv4 = att.Value.ToString

                    Case "subnetmask"
                        SubnetMask = att.Value.ToString

                    Case "hpglport"
                        HPGLPort = att.Value.ToString

                    Case "statusport"
                        StatusPort = att.Value.ToString

                End Select
            Next

        End If

    End Sub

End Class
