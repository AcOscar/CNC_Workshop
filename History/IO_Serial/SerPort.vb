Imports System.IO.Ports

Public Class SerPort
    WithEvents _serialPort As SerialPort
    Dim _isopen As Boolean

    'Public Shared msgLbl As Windows.Forms.Label


    Public Sub Open()
        ' Create a new SerialPort object with default settings.
        _serialPort = New SerialPort()

        '' Allow the user to set the appropriate properties.
        '_serialPort.PortName = "COM1"
        '_serialPort.BaudRate = 19200
        '_serialPort.Parity = Parity.None
        '_serialPort.DataBits = 8
        '_serialPort.StopBits = 1
        '_serialPort.Handshake = Handshake.RequestToSend

        '' Set the read/write timeouts
        '_serialPort.ReadTimeout = 500
        '_serialPort.WriteTimeout = 500

        '_serialPort.Open()
        ''_continue = True

    End Sub

    Public Sub Close()
        _isopen = False

        _serialPort.Close()
    End Sub

    Public Sub Send(ByVal Text As String)

        Try
            If _serialPort IsNot Nothing Then
                _serialPort.WriteLine(Text)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function CommandExec(ByVal Command As String) As String

        Dim answer As String = String.Empty
        '  AddHandler _serialPort.DataReceived, AddressOf DataReceivedHandler
        Try
            If _serialPort IsNot Nothing Then
                _serialPort.WriteLine(Command)
                answer = _serialPort.ReadLine()
            End If

        Catch ex As Exception

        End Try

        Return answer

    End Function

    'Private Sub SetText(ByVal newText As String)
    '    If SerPort.msgLbl.InvokeRequired Then
    '        ' It's on a different thread, so use Invoke.
    '        Dim d As New HDM_DigitalWorkshopUserControl.SetTextCallback(AddressOf SetText)
    '        SerPort.msgLbl.Invoke(d, New Object() {newText})
    '    Else
    '        ' It's on the same thread, no need for Invoke.
    '        SerPort.msgLbl.Text = newText
    '    End If

    'End Sub


    'Friend Sub DataReceivedHandler(
    '                ByVal sender As Object,
    '                ByVal e As SerialDataReceivedEventArgs) Handles _serialPort.DataReceived

    '    ' Dim sp As SerialPort = CType(sender, SerialPort)

    '    Dim indata As String = _serialPort.ReadExisting
    '    SetText(indata)


    '    Debug.Print(indata)
    '    'Console.WriteLine("Data Received:")
    '    Console.Write(indata)
    'End Sub

    'Public Sub Open(ByVal Device As CNC_Device)

    '    ' Create a new SerialPort object with default settings.
    '    _serialPort = New SerialPort()

    '    ' Allow the user to set the appropriate properties.
    '    _serialPort.PortName = Device.port
    '    _serialPort.BaudRate = Device.speed
    '    _serialPort.Parity = Device.parity
    '    _serialPort.DataBits = Device.databits
    '    _serialPort.StopBits = Device.stopbits
    '    _serialPort.Handshake = Device.handshake

    '    ' Set the read/write timeouts
    '    _serialPort.ReadTimeout = Device.readtimeout
    '    _serialPort.WriteTimeout = Device.writetimeout

    '    _serialPort.Open()
    '    ' _continue = True


    'End Sub
    Public Sub Open(ByVal sps As SerPortSetting)

        ' Create a new SerialPort object with default settings.
        _serialPort = New SerialPort()

        ' Allow the user to set the appropriate properties.
        _serialPort.PortName = sps.PortName
        _serialPort.BaudRate = sps.BaudRate
        _serialPort.Parity = sps.Parity
        _serialPort.DataBits = sps.DataBits
        _serialPort.StopBits = sps.StopBits
        _serialPort.Handshake = sps.Handshake

        ' Set the read/write timeouts
        _serialPort.ReadTimeout = sps.ReadTimeout
        _serialPort.WriteTimeout = sps.WriteTimeout

        _serialPort.Open()
        ' _continue = True
        _isopen = True

    End Sub

    ReadOnly Property isOpen() As Boolean
        Get
            Return _isopen
        End Get
    End Property


End Class
