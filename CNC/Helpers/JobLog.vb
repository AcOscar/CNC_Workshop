Imports System.IO

Public Class JobLog

    Private Shared _LogFileLocation As String

    Private Const TimeFormat As String = "yyyy.MM.dd HH:mm:ss.ffff"


    Public Shared Sub Write(ByRef Text As String)

        Using _StreamWriter = New StreamWriter(FullFilename, True)

            _StreamWriter.AutoFlush = True

            _StreamWriter.Write((Format(Now, TimeFormat) & vbTab & Text & vbCrLf))

        End Using

    End Sub

    Shared Function SetLogLocation(Path As String) As Boolean

        Try
            Dim dirinfo As DirectoryInfo = Directory.CreateDirectory(Path)

            _LogFileLocation = dirinfo.FullName

        Catch ex As Exception

            LogFile.Write(ex.Message)

            Return False

        End Try

        Return True

    End Function

    Shared ReadOnly Property LogFileLocation As String

        Get

            Return _LogFileLocation

        End Get

    End Property

    Shared ReadOnly Property FullFilename As String
        Get

            Dim DayFileName As String

            DayFileName = Format(Now, "yyyy-MM") & ".log"

            Dim _Path As String

            _Path = Path.Combine(_LogFileLocation, DayFileName)

            Return _Path

        End Get

    End Property

End Class
