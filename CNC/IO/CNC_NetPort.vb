Imports System.Net.Sockets
Imports System.Net
Imports System.IO

Public Class CNC_NetPort : Inherits CNC_Port

    Private WithEvents CNC_TCPListener As TcpListener
    Public CNC_TCPClient As New TcpClient

    Private IpAddr As IPAddress  ' = New IPEndPoint(IPAddress.Any, 8000)

    Private ReadOnly HPGLPort As Integer = 50000

    Private ReadOnly StatusPort As Integer = 50002

    Private NetStream As NetworkStream

    ''' <summary>
    ''' raised if we get a coomand at port
    ''' </summary>
    Public Shadows Event DataReceived(ByVal Input As String)

    ''' <summary>
    ''' reached if a block was sended via port
    ''' </summary>
    Public Shadows Event DataBlockSended(ByVal Number As Integer, ByVal Total As Integer)

    Public Sub New()

    End Sub

    Public Overrides Function Open(ByVal ps As PortSetting) As Boolean

        Dim nps As NetPortSetting

        If TypeOf ps Is NetPortSetting Then

            nps = CType(ps, NetPortSetting)

        Else

            Return False

        End If

        Try
            IpAddr = IPAddress.Parse(nps.IPv4)

            CNC_TCPClient.Connect(IpAddr, CInt(nps.HPGLPort))
            'todo statusport
            If CNC_TCPClient.Connected Then

                NetStream = CNC_TCPClient.GetStream

            Else

                Return False

            End If

        Catch ex As Exception

            Return False

        End Try

        If NetStream.CanRead Then

            Dim myReadBuffer(1024) As Byte
            NetStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, New AsyncCallback(AddressOf MyReadCallBack), NetStream)

        Else

            Console.WriteLine("Sorry.  You cannot read from this NetworkStream.")

        End If

        Return True

    End Function

    Public Sub MyReadCallBack(ar As IAsyncResult)

        Dim myNetworkStream As NetworkStream = CType(ar.AsyncState, NetworkStream)
        Dim myReadBuffer(1024) As Byte
        Dim myCompleteMessage As [String] = ""
        Dim numberOfBytesRead As Integer

        numberOfBytesRead = myNetworkStream.EndRead(ar)
        myCompleteMessage = [String].Concat(myCompleteMessage, Text.Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead))

        ' message received may be larger than buffer size so loop through until you have it all.
        While myNetworkStream.DataAvailable

            myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, New AsyncCallback(AddressOf MyReadCallBack), myNetworkStream)

        End While

        ' Print out the received message to the console.
        Debug.Print(("You received the following message : " + myCompleteMessage))

        RaiseEvent DataReceived(myCompleteMessage)

    End Sub 'myReadCallBack


    Public Overrides Sub SendDirect(ByVal Text As String)
        'todo Sub SendDirect(ByVal Text As String)
    End Sub

    Public Overrides Sub SendIndirect2(ByRef Text As String)
        'todo Sub SendIndirect2(ByRef Text As String)
    End Sub

    Public Overrides Sub Close()
        'todo Sub Close()
    End Sub

    Public Overrides ReadOnly Property isOpen() As Boolean

        'todo Property isOpen() As Boolean
        Get

            Return False

        End Get

    End Property

End Class
