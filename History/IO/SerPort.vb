Imports System.IO.Ports

Public Class SerPort

    Private WithEvents _serialPort As SerialPort

    Private _isopen As Boolean


    Private _HpglCommand As String = String.Empty

    ''' <summary>
    ''' raised if we get a coomand at _serialport
    ''' </summary>
    Public Event DataReceived(ByVal mySerInput As String)

    ''' <summary>
    ''' reached if a block was sended via _serialport
    ''' </summary>
    Public Event DataBlockSended(ByVal Number As Integer, ByVal Total As Integer)

    Public Sub Open()
        ' Create a new SerialPort object with default settings.
        _serialPort = New SerialPort()

    End Sub

    Public Sub Close()

        _isopen = False

        _serialPort.Close()

    End Sub

    Private _SendBuffer As String

    Public ReadOnly Property SendBuffer As String

        Get

            Return _SendBuffer

        End Get

    End Property

    Public Sub SendBufferToPort(ByVal Complete As Boolean)

        Try

            If _serialPort IsNot Nothing Then

                Dim sendstring As String = String.Empty

                Dim wBufferSize As Integer = _serialPort.WriteBufferSize

                Dim i As Integer = 0

                Dim Blocks2Send As Integer = SendBuffer.Length \ wBufferSize

                For i = 0 To Blocks2Send - 1

                    sendstring = SendBuffer.Substring(0, wBufferSize)

                    _serialPort.Write(sendstring)

                    RaiseEvent DataBlockSended(i + 1, Blocks2Send + 1)

                    _SendBuffer = SendBuffer.Substring(wBufferSize)

                Next

                If Complete Then

                    _serialPort.Write(SendBuffer)

                    RaiseEvent DataBlockSended(Blocks2Send + 1, Blocks2Send + 1)

                    _SendBuffer = String.Empty

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Sub SendDirect(ByVal Text As String)

        Try
            If _serialPort IsNot Nothing Then

                _serialPort.WriteLine(Text)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub WriteToBuffer(ByVal Text As String)

        _SendBuffer &= Text

        'If _SendBuffer.Length > _serialPort.WriteBufferSize Then

        '    SendBufferToPort(False)

        'End If

    End Sub

    Private Sub myComPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) _
        Handles _serialPort.DataReceived

        If e.EventType = SerialData.Chars Then

            Try

                Do While _serialPort.BytesToRead > 0

                    Dim Receiving As String = String.Empty

                    Dim _byte As Integer

                    Do

                        _byte = _serialPort.ReadByte

                        If _byte = 13 Then Exit Do 'wenn CR dann erst mal raus hier

                        Receiving = Convert.ToChar(_byte)

                        _HpglCommand &= Receiving

                    Loop Until _serialPort.BytesToRead = 0

                    'sind wir hier weil rausgesprungen oder Bytes =0?
                    ' If _byte = 13 Or _HpglCommand.EndsWith(";"c) Then
                    If _byte = 13 Then
                        'war CR also fertig und verarbeiten ansosnten warten bis der rest kommt
                        RaiseEvent DataReceived(_HpglCommand)

                        _HpglCommand = String.Empty

                    End If

                Loop

            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Sub Open(ByVal sps As SerPortSetting)

        ' Create a new SerialPort object with default settings.
        _serialPort = New SerialPort()

        ' Allow the user to set the appropriate properties.

        _serialPort.PortName = sps.PortName

        _serialPort.BaudRate = sps.BaudRate

        _serialPort.Parity = sps.parity

        _serialPort.DataBits = sps.databits

        _serialPort.StopBits = sps.stopbits

        _serialPort.Handshake = sps.handshake

        ' Set the read/write timeouts
        _serialPort.ReadTimeout = sps.readtimeout

        _serialPort.WriteTimeout = sps.writetimeout

        _serialPort.Open()

        _isopen = True

    End Sub

    ReadOnly Property isOpen() As Boolean

        Get

            Return _isopen

        End Get

    End Property

End Class
