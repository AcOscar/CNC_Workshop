Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports

Public Class Form1

    Private WithEvents SerPort As SerialPort

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        btnDisconnect.Enabled = False           'Initially Disconnect Button is Disabled

        SerPort = New SerialPort

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        SerPort.PortName = "COM4"         'Set SerialPort1 to the selected COM port at startup
        SerPort.BaudRate = "19200"         'Set Baud rate to the selected value on
        'OtpSeral Port Property
        SerPort.StopBits = IO.Ports.Handshake.RequestToSend
        SerPort.Parity = IO.Ports.Parity.None
        SerPort.StopBits = IO.Ports.StopBits.One
        SerPort.DataBits = 8            'Open our serial port
        SerPort.ReadBufferSize = 50000
        SerPort.ReadTimeout = 500
        SerPort.WriteTimeout = 2000
        SerPort.Open()

        btnConnect.Enabled = False          'Disable Connect button

        btnDisconnect.Enabled = True        'and Enable Disconnect button

    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click

        SerPort.Close()             'Close our Serial Port

        btnConnect.Enabled = True

        btnDisconnect.Enabled = False

    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click

        SerPort.Write(txtTransmit.Text & vbCr) 'The text contained in the txtText will be sent to the serial port as ascii

        txtTransmit.Text = ""

    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerPort.DataReceived

        TerminalRecText(SerPort.ReadExisting())    'Automatically called every time a data is received at the serialPort

    End Sub

    Private Last As String = String.Empty

    Sub TerminalRecText(ByVal value As String)

        If Me.ListBox1.InvokeRequired Then

            Me.ListBox1.Invoke(Sub() TerminalRecText(value))

        Else
            Dim myTxt() = value.Split(";")

            For Each c In myTxt

                If c.StartsWith("PU") Or c.StartsWith("PD") Then

                    Last = c

                    Continue For

                End If

                If c.StartsWith("OA") Then

                    Me.ListBox1.Items.Add(Last)

                End If

                If c.StartsWith("JB") Then

                    Me.ListBox1.Items.Add(c)

                End If

                If c.StartsWith("OI") Then

                    Me.ListBox1.Items.Add(c)

                End If

                If c.StartsWith("MS") Then

                    Me.ListBox1.Items.Add(c)

                End If

            Next

        End If

    End Sub

    Private Sub btCLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCLS.Click

        Me.ListBox1.Items.Clear()

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim SelItem As String = Me.ListBox1.SelectedItem.ToString.Trim

        If SelItem = "" Then

            Exit Sub

        End If

        If SelItem.Length < 2 Then

            Exit Sub

        End If

        Select Case SelItem.Substring(0, 2)

            Case "OI"
                SerPort.Write("M-1200;")

            Case "PD"
                Dim myParts() As String = SelItem.Substring(2).Split(",")

                SerPort.Write(SelItem.Substring(2) & ",1;")

            Case "PU"

                Dim myParts() As String = SelItem.Substring(2).Split(",")

                SerPort.Write(SelItem.Substring(2) & ",0;")

            Case "JB"

                SerPort.Write(SelItem & ";")

        End Select

    End Sub

    Private JobTimer As Boolean = False


    Private WithEvents myTimer As New Timers.Timer

    Sub mytimerelapsed() Handles myTimer.Elapsed
        Dim mytest As String = MaskedTextBox1.Text

        'myTimer.Interval = MaskedTextBox1.ValidateText
        Dim myHour As Integer
        Dim myMinutes As Integer
        Dim mySec As Integer

        Dim myTime() As String

        myTime = mytest.Split(":")

        myHour = myTime(0)
        myMinutes = myTime(1)
        mySec = myTime(2)

        myMinutes += myHour * 60

        mySec += myMinutes * 60

        myTimer.Interval = (mySec * 1000) / NumericUpDown2.Value

        jbcounter += 1

        If jbcounter = NumericUpDown2.Value + 1 Then

            SerPort.Write("JB" & 0 & Chr(13))

            myTimer.Stop()

        Else

            SerPort.Write("JB" & jbcounter & Chr(13))

        End If

    End Sub

    Private jbcounter As Integer = 0

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then

            jbcounter = 0

            JobTimer = True

            ' myTimer.Interval = NumericUpDown1.Value * 1000

            mytimerelapsed()

            myTimer.Start()

        Else

            JobTimer = False

            myTimer.Stop()

        End If

    End Sub

End Class