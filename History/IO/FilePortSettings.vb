Public Class FilePortSetting
    Inherits PortSetting

    Property FileExtension As String

    Property MimeType As String

    Sub getConfig(ByVal myConnection As XElement)

        If myConnection IsNot Nothing Then

            For Each att In myConnection.Attributes

                Select Case att.Name.ToString.ToLower

                    Case "id"

                        Id = att.Value.ToString

                    Case "type"

                        Type = att.Value.ToString

                    Case "fileext"

                        FileExtension = att.Value.ToString

                    Case "mime"

                        MimeType = att.Value.ToString

                End Select

            Next

        End If

    End Sub

End Class
