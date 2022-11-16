''' <summary>
''' this is computer to control a cnc device with an interface
''' </summary>
Public Class CNC_Controller

    ''' <summary>
    ''' the kind of the connection from the computer to the cnc device
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property Connection As String
        Get

            Return _Connection

        End Get

    End Property

    ''' <summary>
    ''' the hostname of the controling computer
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property ControllComputer As String
        Get

            Return _ControllComputer

        End Get

    End Property

    ''' <summary>
    ''' the id of the cnc device to controle for
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property DevicID As String
        Get

            Return _DevicID

        End Get

    End Property

    Private _Connection As String
    Private _ControllComputer As String
    Private _DevicID As String

    ''' <summary>
    ''' read the configuration from xml
    ''' </summary>
    Function GetConfig(ByVal myProp As XElement) As Boolean

        For Each att As XAttribute In myProp.Attributes

            Select Case att.Name.ToString.ToLower

                Case "pair"
                    Dim myPair As String
                    myPair = myProp.Attribute("pair").Value.ToString

                    _DevicID = myPair.Split("@"c)(0)

                    _ControllComputer = myPair.Split("@"c)(1)

                Case "connnection"
                    _Connection = myProp.Attribute("connnection").Value.ToString

            End Select

        Next

        If Connection = "" OrElse ControllComputer = "" OrElse DevicID = "" Then

            Return False

        Else

            Return True

        End If

    End Function

End Class
