Public Class NetworkSetting

    Property Id As String
    Property LinkLayer As String
    Property InternetLayer As String
    Property TransportLayer As String
    Property ApplicationLayer As String

    Sub getConfig(ByVal myConnection As XElement)
        If myConnection IsNot Nothing Then

            For Each att In myConnection.Attributes

                Select Case att.Name.ToString.ToLower

                    Case "id"
                        Id = att.Value.ToString

                    Case "link"
                        LinkLayer = att.Value.ToString

                    Case "internet"
                        InternetLayer = att.Value.ToString

                    Case "transport"
                        TransportLayer = att.Value.ToString

                    Case "application"
                        ApplicationLayer = att.Value.ToString

                End Select
            Next

        End If

    End Sub

End Class
