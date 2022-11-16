Public Class LogFile

    Private Shared _LogFileStream As IO.StreamWriter

    Private Const TimeFormat As String = "HH:mm:ss.ffff"

    Public Shared Sub Write(ByRef Text As String)

#If DEBUG Then
        If _LogFileStream IsNot Nothing Then

            _LogFileStream.Write((Format(Now, TimeFormat) & vbTab & Text & vbCrLf))

        End If
#End If

    End Sub

    ''' <summary>
    ''' Create a new empty Logfile
    ''' </summary>
    ''' <param name="FilePreString">the path and the begining of the filename 
    ''' like: C:\temp\myLogfile will produce a logfile:  C:\temp\myLogfile-131029-104048.txt</param>
    Shared Sub Create(ByVal FilePreString As String)

#If DEBUG Then
        Dim FileName As String

        FileName = FilePreString & Format(Now, "yyMMdd-HHmmss") & ".txt"

        _LogFileStream = System.IO.File.CreateText(FileName)

        _LogFileStream.AutoFlush = True

        Write("Username: " & Environment.UserName)

#End If

    End Sub

    Shared Sub Close()

#If DEBUG Then
        If _LogFileStream IsNot Nothing Then

            _LogFileStream.Close()


        End If
#End If

    End Sub

End Class

