Public Class Messenger

    Public Shared Sub Desaster(ByVal Message As String)

        MsgBox(Message, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "CNC Plugin Desaster")

        LogFile.Write("Desaster - " & Message & " - ")

    End Sub

    Public Shared Sub Info(ByVal Message As String)

        MsgBox(Message, CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle), "CNC Plugin")

        LogFile.Write("Info - " & Message & " - ")

    End Sub

End Class
