Imports System.IO.Ports
Imports System.Threading

Public Class CNC_SerPort : Inherits CNC_Port

    Private WithEvents _serialPort As SerialPort

    Private _InputCommand As String = String.Empty

    Private FileSaverThread As Thread

    ''' <summary>
    ''' raised if we get a coomand at _serialport
    ''' </summary>
    Public Shadows Event DataReceived(ByVal mySerInput As String)

    ''' <summary>
    ''' reached if a block was sended via _serialport
    ''' </summary>
    Public Shadows Event DataBlockSended(ByVal Number As Integer, ByVal Total As Integer)

    ''' <summary>
    ''' Opens a new serial port connection.
    ''' </summary>
    Public Overrides Function Open(ByVal ps As PortSetting) As Boolean

        Dim sps As SerPortSetting

        If TypeOf (ps) Is SerPortSetting Then

            sps = CType(ps, SerPortSetting)

        Else

            Return False

        End If

        ' Create a new SerialPort object with default settings.
        ' Allow the user to set the appropriate properties.
        ' Set the read/write timeouts
        _serialPort = New SerialPort With {
            .PortName = sps.PortName,
            .BaudRate = sps.BaudRate,
            .Parity = CType(sps.parity, Parity),
            .DataBits = sps.databits,
            .StopBits = CType(sps.stopbits, StopBits),
            .Handshake = CType(sps.handshake, Handshake),
            .ReadTimeout = sps.readtimeout,
            .WriteTimeout = sps.writetimeout
        }

        If Not _serialPort.IsOpen Then

            Try

                _serialPort.Open()

                LogFile.Write("open Serport sucess")

            Catch ex As Exception

                LogFile.Write("open Serport failed" & ex.ToString)

                Messenger.Desaster("Rhino could not open a connection to the cutter." & vbCrLf &
                                   "Probably another current open Rhino session is connected to the device." & vbCrLf &
                                   "You have to close the other Rhino session or at least click ""Stop Trace"" there." & vbCrLf &
                                   "In worst case you can try to restart the computer.")

                Return False

            End Try

        End If

        Return True

    End Function

    ''' <summary>
    ''' Closes the port connection, sets the System.IO.Ports.SerialPort.IsOpen property to false, and disposes of the internal System.IO.Stream object.
    ''' </summary>
    ''' <remarks>System.IO.IOException: The port is in an invalid state.- or -An attempt to set 
    ''' the state of the underlying port failed. For example, the parameters passed from this 
    ''' System.IO.Ports.SerialPort object were invalid.</remarks>
    Public Overrides Sub Close()

        LogFile.Write("Close Serport")

        _serialPort.Close()

    End Sub

    Public Overrides Sub SendIndirect2(ByRef Text As String)

        Dim mySerSender As New SerialSender(_serialPort, Text)

        AddHandler mySerSender.SenderDataBlockSended, AddressOf Handle_SerSender_DataBlockSended

        FileSaverThread = New Thread(AddressOf mySerSender.Write)

        FileSaverThread.Start()

    End Sub

    Sub Handle_SerSender_DataBlockSended(ByVal Number As Integer, ByVal Total As Integer)

        RaiseEvent DataBlockSended(Number, Total)

    End Sub

    ''' <summary>
    ''' Writes the Text string and the System.IO.Ports.SerialPort.NewLine value to the output buffer.
    ''' </summary>
    Overrides Sub SendDirect(ByVal Text As String)

        Try

            If _serialPort IsNot Nothing Then

                _serialPort.WriteLine(Text)

            End If

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Represents the method that will handle the data received event of a System.IO.Ports.SerialPort object.
    ''' </summary>
    Private Sub Handle_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles _serialPort.DataReceived

        If e.EventType = SerialData.Chars Then

            Try

                If Not _serialPort.IsOpen Then

                    Exit Sub

                End If

                Do While _serialPort.BytesToRead > 0

                    Dim Receiving As String = String.Empty

                    Dim _byte As Integer

                    Do

                        _byte = _serialPort.ReadByte

                        If _byte = 13 Then Exit Do 'wenn CR dann erst mal raus hier

                        Receiving = Convert.ToChar(_byte)

                        _InputCommand &= Receiving

                    Loop Until _serialPort.BytesToRead = 0

                    'sind wir hier weil rausgesprungen oder Bytes =0?
                    If _byte = 13 Then
                        'war CR also fertig und verarbeiten ansosnten warten bis der rest kommt
                        RaiseEvent DataReceived(_InputCommand)

                        _InputCommand = String.Empty

                    End If

                Loop

            Catch ex As Exception

            End Try

        End If

    End Sub

    ''' <summary>
    ''' Gets a value indicating the open or closed status of the System.IO.Ports.SerialPort object.
    ''' </summary>
    ''' <returns>true if the serial port is open; otherwise, false. The default is false.</returns>
    Overrides ReadOnly Property isOpen() As Boolean

        Get

            Return _serialPort.IsOpen

        End Get

    End Property

    Public Class SerialSender

        Public Event SenderDataBlockSended(ByVal Number As Integer, ByVal Total As Integer)

        Private _Text As String

        Private _serialPort As SerialPort

        Public Sub New(ByVal Serpot As SerialPort, ByVal Text As String)

            Me._Text = Text

            Me._serialPort = Serpot

        End Sub

        Public Sub Write()
            Try

                If _serialPort IsNot Nothing Then

                    Dim sendstring As String = String.Empty

                    Dim wBufferSize As Integer = _serialPort.WriteBufferSize

                    Dim i As Integer = 0

                    Dim Blocks2Send As Integer = _Text.Length \ wBufferSize

                    For i = 0 To Blocks2Send - 1

                        sendstring = _Text.Substring(0, wBufferSize)

                        _serialPort.Write(sendstring)

                        RaiseEvent SenderDataBlockSended(i + 1, Blocks2Send + 1)

                        _Text = _Text.Substring(wBufferSize)

                    Next

                    _serialPort.Write(_Text)

                    RaiseEvent SenderDataBlockSended(Blocks2Send + 1, Blocks2Send + 1)

                    _Text = String.Empty

                End If

            Catch ex As Exception

            End Try
        End Sub

    End Class

End Class
