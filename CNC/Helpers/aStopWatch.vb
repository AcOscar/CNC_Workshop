''' <summary>
''' small simple stopwatch by Holger Rasch
''' </summary>
Public Class aStopWatch

    Private Shared myStopWatch As Stopwatch

    ''' <summary>
    ''' starts a new stopwatch
    ''' </summary>
    ''' <remarks>a existing watch will be reseted</remarks>
    Public Shared Sub Start()

        myStopWatch = New Stopwatch()

        myStopWatch.Start()

    End Sub

    ''' <summary>
    ''' stops the running stopwatch and shows the elapsed time in the command line
    ''' </summary>
    ''' <remarks>the stopwatch did't run after this command</remarks>
    Public Shared Function [Stop]() As String

        myStopWatch.Stop()

        Dim ts As TimeSpan = myStopWatch.Elapsed

        Dim elapsedTime As String = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10)

        Return elapsedTime

    End Function

    ''' <summary>
    ''' shows the elapsed time since the Start function as called
    ''' </summary>
    ''' <remarks>after this function stopwatch is still runing. To stop them please use the stop command</remarks>
    Public Shared Function Show() As String

        Dim ts As TimeSpan = myStopWatch.Elapsed

        Dim elapsedTime As String = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10)

        Return elapsedTime

    End Function

End Class
