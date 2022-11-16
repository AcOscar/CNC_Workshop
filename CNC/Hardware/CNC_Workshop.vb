Imports System.Collections.ObjectModel

Public Class CNC_Workshop

    ''' <summary>
    ''' a string that forces the cutter to recieved a command independly of the online offline status
    ''' </summary>
    Public Const FrontEnd As String = Chr(27) & ".["

    ''' <summary>
    ''' a refernce to the current (active) device
    ''' </summary>
    Public WithEvents CurrentDevice As CNC_Device
    Private ReadOnly NetSetting As Object

    ''' <summary>
    ''' zeigt den Empfang eines JB Befehl 
    ''' </summary>
    ''' <param name="JobNo">Nummer der JB</param>
    Public Event JBReceived(ByVal JobNo As Integer)

    Public Event NewRefrencePointDetected()

    ''' <summary>
    ''' name of the connection if we are a control computer  
    ''' </summary>
    ''' <remarks>difined in *.workshop.xml</remarks>
    Private Property CurrentConnection As String

    ' ''' <summary>
    ' ''' a wraped port
    ' ''' </summary>
    ' Private WithEvents ConnectionPort As CNC_Port

    Private WithEvents SerPort As CNC_SerPort

    ''' <summary>
    ''' a list of all available devices
    ''' </summary>
    ''' <remarks>given by the devices xml files</remarks>
    Public Devices As List(Of CNC_Device)

    ''' <summary>
    ''' a list of all materials from the materials.xml
    ''' </summary>
    Public Materials As List(Of CNC_Material)

    ''' <summary>
    ''' Id of a default device
    ''' </summary>
    ''' <remarks>*.workshop.xml</remarks>
    Public DefaultDevice As String

    ''' <summary>
    ''' means that we are seeing the job progress in rhino and the serport is open. Dont confuse with wwareinflow insde uiwraper
    ''' </summary>
    Public Property IsTracing As Boolean = False

    ''' <summary>
    ''' stop watch for the job and estimated time calculation
    ''' </summary>
    Public Shared ProcessTimer As New Stopwatch

    ''' <summary>
    ''' a list of all possible connections
    ''' </summary>
    ''' <remarks>this is the representation of the conector entities in the workshop.xml</remarks>
    Private Property Connectors As List(Of PortSetting)

    ''' <summary>
    ''' zeigt an das ein Datenblock über die serielle Schnittstelle versendet wurde
    ''' </summary>
    ''' <param name="no">nummer des aktuell gesendet Paktetes</param>
    ''' <param name="total">anzahl der zu sendenen Pakete</param>
    Public Event DataBlockSended(ByVal no As Integer, ByVal total As Integer)

    ''' <summary>
    ''' List of all control computers
    ''' </summary>
    ''' <remarks>this list is defined by the workshp.xml</remarks>
    Public Property Controllers As List(Of CNC_Controller)

    ''' <summary>
    ''' ID of the Device if its conneted to the computer
    ''' </summary>
    Private Property ControlledDevice As String


    ''' <summary>
    ''' it's True if we have to log all jobs
    ''' </summary>
    Public Property IsJobLogging As Boolean

    Public Sub New()

        Me.IsJobLogging = False

        Connectors = New List(Of PortSetting)

        Devices = New List(Of CNC_Device)

        Materials = New List(Of CNC_Material)

        Controllers = New List(Of CNC_Controller)

        ControlledDevice = String.Empty

        ReadSettings()

    End Sub

    ''' <summary>
    ''' True if we are the controlcomputer for the current device
    ''' </summary>
    Public ReadOnly Property IsControlComputer As Boolean
        Get

            If CurrentDevice.ID = ControlledDevice Then

                Return True

            Else

                Return False

            End If

        End Get

    End Property

    ''' <summary>
    ''' read the xml files with configuration
    ''' </summary>
    Private Function ReadSettings() As Boolean

        Dim directory As String = My.Computer.FileSystem.CombinePath(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.Location), "config")

        Dim files As ReadOnlyCollection(Of String)

        files = My.Computer.FileSystem.GetFiles(directory,
                                                Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                                "*.workshop.xml")

        Select Case files.Count

            Case Is > 1
                Messenger.Desaster("More than one workshop definition found.")

                Return False

            Case Is = 0
                Messenger.Desaster("No workshop definition found.")

                Return False

        End Select

        If Not ReadXML(files(0)) Then

            Messenger.Desaster("error reading workshop config: " & files(0))

            Return False

        End If

        files = My.Computer.FileSystem.GetFiles(directory,
                                                Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                                "*.device.xml")

        For Each File As String In files

            Dim myDevice As New CNC_Device

            Try

                If myDevice.ReadXML(File) Then

                    Devices.Add(myDevice)

                End If

            Catch ex As Exception

                Messenger.Desaster("error reading device config: " & File & vbCrLf & ex.ToString)

                Return False

            End Try

        Next

        'read materials
        files = My.Computer.FileSystem.GetFiles(directory,
                                                Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                                "*.material.xml")

        For Each File As String In files
            Try

                Dim xFile As XElement = XElement.Load(File)

                For Each xMaterial As XElement In xFile.Descendants("material")

                    Dim myMaterial As New CNC_Material

                    If myMaterial.ReadXML(xMaterial) Then

                        Materials.Add(myMaterial)

                    End If

                Next

            Catch ex As Exception

                Messenger.Desaster("error reading material config: " & File)

                Return False

            End Try

        Next

        Return True

    End Function

    ''' <summary>
    ''' set the DefaultDevice as CurrentDevice
    ''' </summary>
    Public Sub SetCurrentDefaultDevice()

        For Each Device As CNC_Device In Me.Devices

            If Device.ID = DefaultDevice Then

                CurrentDevice = Device

                CurrentDevice.ZeroPoint = New Coordinate

                Exit Sub

            End If

        Next

        CurrentDevice = Nothing

    End Sub

    ''' <summary>
    ''' set the CurrentDevice by a Name
    ''' </summary>
    ''' <remarks>see also at GetDeviceByID</remarks>
    Public Sub SetCurrentDeviceByName(ByVal DeviceName As String)

        For Each Device In Me.Devices

            If Device.DeviceName = DeviceName Then

                CurrentDevice = Device

                CurrentDevice.ZeroPoint = New Coordinate

                Exit Sub

            End If

        Next

        CurrentDevice = Nothing

    End Sub

    ''' <summary>
    ''' set the CurrentDevice by an ID
    ''' </summary>
    ''' <remarks>see also at GetDeviceByName</remarks>
    Public Sub SetCurrentdeviceByID(ByVal DeviceID As String)

        For Each Device In Me.Devices

            If Device.ID = DeviceID Then

                CurrentDevice = Device

                CurrentDevice.ZeroPoint = New Coordinate

                Exit Sub

            End If

        Next

        CurrentDevice = Nothing

    End Sub

    ''' <summary>
    ''' deliverd a list for all aplicable materials for the given device
    ''' </summary>
    Public Function MaterialsFor(ByVal Device As CNC_Device) As List(Of CNC_Material)

        Dim myList As New List(Of CNC_Material)

        For Each tool As CNC_Tool In Device.Tools

            For Each mat As CNC_Material In Materials

                If myList.Contains(mat) Then

                    Continue For

                End If

                For Each ts As CNC_ToolSetting In mat.ToolSettings

                    If tool.ID = ts.ID Then

                        myList.Add(mat)

                        Exit For

                    End If

                Next

            Next

        Next

        Return myList

    End Function

    ''' <summary>
    ''' replaced the placeholders in a property text like the prejob text with the rigth properties from the device
    ''' </summary>
    ''' <param name="ParseText">the text with the placeholders in { and } </param>
    ''' <param name="Properties">the properties to looking for</param>
    ''' <param name="id">if id is requeseted in the ParseText here is the place for this, because the id is not part of the Proerties</param>
    ''' <returns>a hopefully well formatede string without { and }</returns>
    ''' <remarks>this is shared public to use this in the devices adn tools too</remarks>
    Public Shared Function ParsePropertyText(ByVal ParseText As String, ByVal Properties As List(Of CNC_Property), Optional ByVal id As String = "") As String

        If ParseText = String.Empty Then

            Return ParseText

        End If

        Dim myRepl As String() = ParseText.Split(";"c)

        For Each ele As String In myRepl

            Do While ele.Contains("{")

                Dim start As Integer = ele.IndexOf("{")

                Dim ende As Integer = ele.IndexOf("}")

                If ende > -1 Then

                    Dim replid As String = ele.Substring(start + 1, ende - start - 1)

                    If replid = "id" Then

                        ParseText = ParseText.Replace("{" & replid & "}", id)

                        ele = ele.Replace("{" & replid & "}", id)

                    Else

                        For Each prop As CNC_Property In Properties

                            If prop.ID = replid Then

                                Dim repl As String = prop.Value.ToString

                                If replid = "username" Then
                                    'we need them for the last line in the display and there is just 12 cahracters left
                                    repl = prop.Text

                                    repl = repl.PadRight(12)

                                    repl = repl.Substring(0, 12)

                                End If

                                ParseText = ParseText.Replace("{" & replid & "}", repl)

                                ele = ele.Replace("{" & replid & "}", repl)

                                Exit For

                            End If

                        Next

                    End If

                End If

            Loop

        Next

        Return ParseText

    End Function

    ''' <summary>
    ''' read all settings from the *.workshop.xml
    ''' </summary>
    Private Function ReadXML(ByVal Filename As String) As Boolean

        Dim myConfig As XElement = XElement.Load(Filename)

        DefaultDevice = CStr(myConfig.Attribute("DefaultDevice"))

        CurrentConnection = ""

        For Each Connection As XElement In myConfig.Descendants("connector")

            Select Case CStr(Connection.Attribute("type"))

                Case "serial"

                    Dim mySerialSettings = New SerPortSetting

                    mySerialSettings.getConfig(Connection)

                    Connectors.Add(mySerialSettings)

                Case "network"

                    Dim myNetPortSetting = New NetPortSetting

                    myNetPortSetting.getConfig(Connection)

                    Connectors.Add(myNetPortSetting)

            End Select

        Next

        For Each xprop As XElement In myConfig.Descendants("controller")

            Dim myContr As New CNC_Controller

            If myContr.GetConfig(xprop) Then

                Controllers.Add(myContr)

            End If

        Next

        For Each xprop As XElement In myConfig.Descendants("property")

            Dim myProp As New CNC_Property

            If myProp.GetConfig(xprop) Then

                Select Case myProp.ID.ToLower

                    Case "joblog"

                        If myProp.Value = 1 Then
                            Me.IsJobLogging = True

                        Else
                            Me.IsJobLogging = False

                        End If

                    Case "jobloglocation"

                        If Not JobLog.SetLogLocation(myProp.Text) Then

                            Me.IsJobLogging = False

                        End If

                End Select

            End If

        Next

        Dim myComputername As String

        myComputername = Environment.MachineName

        For Each contr As CNC_Controller In Controllers

            If myComputername = contr.ControllComputer Then

                CurrentConnection = contr.Connection

                DefaultDevice = contr.DevicID

                ControlledDevice = contr.DevicID

            End If

        Next

        Return True

    End Function

    ''' <summary>
    ''' get the setting for the port
    ''' </summary>
    ''' <remarks>the device xml definiton can offer several settings</remarks>
    Private Function GetPortSetting() As PortSetting

        For Each Ps As PortSetting In Connectors

            If Ps.Id = CurrentConnection Then

                Return Ps

                Exit For

            End If

        Next

        Return Nothing

    End Function

    ''' <summary>
    ''' send a text direct without buffering to the serial port
    ''' </summary>
    Public Function SendDirect(ByVal Text As String) As Boolean

        Try
            If Connect() Then

                If SerPort IsNot Nothing Then

                    SerPort.SendDirect(Text)

                Else

                    Return False

                End If

            Else

                Return False

            End If

        Catch ex As Exception

            Messenger.Desaster(ex.ToString)

            Return False

        End Try

        Return True

    End Function

    ''' <summary>
    ''' open the port
    ''' </summary>
    Public Function Connect() As Boolean

        If SerPort Is Nothing Then

            Dim myPortsetting As PortSetting

            myPortsetting = GetPortSetting()

            Select Case myPortsetting.Type

                Case "serial"
                    SerPort = New CNC_SerPort

                Case "network"
                    ' ConnectionPort = New CNC_NetPort

                Case Else
                    Return False

            End Select

            Return SerPort.Open(myPortsetting)

        ElseIf SerPort.isOpen Then

            Return True

        Else

            Return False

        End If

    End Function

    Public Sub ReloadWorkshop()
        'close what is open becaus the new definiton can overwrite existing ons
        Disconnect()

        ReadSettings()

    End Sub

    ''' <summary>
    ''' close the serial port
    ''' </summary>
    Public Sub Disconnect()

        If SerPort IsNot Nothing Then

            SerPort.Close()

            SerPort = Nothing

        End If

    End Sub

    ''' <summary>
    ''' treat the data from the serialPort
    ''' </summary>
    Public Sub Handle_serialPort_DataRecieved(ByVal Input As String) Handles SerPort.DataReceived

        LogFile.Write(Input)

        Try

            If Input = "" Then

                Exit Sub

            End If

            If Input.Length < 3 Then

                Exit Sub

            End If

            Input = Input.Trim

            If Input.StartsWith("+") Then

                Dim x As Double = CDbl(Input.Split(","c)(0))

                Dim y As Double = CDbl(Input.Split(","c)(1))

                Dim myRef As New Coordinate(x / CurrentDevice.Factor, y / CurrentDevice.Factor)

                CurrentDevice.ReferencePoint = myRef

                RaiseEvent NewRefrencePointDetected()

            End If

            Select Case Input.Substring(0, 2).ToUpper

                Case "JB"

                    Dim JobNo As Integer

                    Try

                        JobNo = Convert.ToInt32(Input.Substring(2, Input.Length - 2))

                        RaiseEvent JBReceived(JobNo)

                    Catch ex As Exception

                        LogFile.Write("EXCEPTION: " & ex.ToString)

                    End Try

                Case Else

                    LogFile.Write("unkown command recieved: " & Input)

            End Select

        Catch ex As Exception

            LogFile.Write("EXCEPTION: " & ex.ToString)

        End Try

    End Sub

    ''' <summary>
    ''' send the job string with buffering to the serial port
    ''' </summary>
    Public Function SendJobToSerial() As Boolean

        LogFile.Write("Start Serial Transmision")

        LogFile.Write(CurrentDevice.JobBuffer.ToString)

        'starts stopwatch for estimated times
        CNC_Workshop.ProcessTimer.Restart()

        Try
            If Not Connect() Then
                LogFile.Write("Error connecting serial connection.")
            End If

            If SerPort IsNot Nothing Then

                IsTracing = True

                SerPort.SendIndirect2(CurrentDevice.JobBuffer.ToString)

                CurrentDevice.JobBuffer.Clear()

            End If

        Catch ex As Exception

            LogFile.Write("Error during Serial Transmision")

            Messenger.Desaster(ex.ToString)

            Return False

        End Try

        LogFile.Write("End Serial Transmision")

        Return True

    End Function

    ''' <summary>
    ''' just to pass-through to ui
    ''' </summary>
    Private Sub Handles_ConnectionPort_DataBlockSended(ByVal no As Integer, ByVal total As Integer) Handles SerPort.DataBlockSended

        RaiseEvent DataBlockSended(no, total)

    End Sub

End Class
