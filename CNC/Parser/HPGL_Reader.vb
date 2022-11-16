Imports WrkShp.CNC_WorkShop

Public Class HPGL_Reader

    ''' <summary>
    ''' try to read a plt file
    ''' </summary>
    ''' <param name="FileName">the fq file names</param>
    ''' <param name="MachinePark">the workshop with all devices</param>
    Public Function ParseHPGLFile(ByRef FileName As String, ByRef MachinePark As WrkShp.CNC_Workshop) As String
        'later implemtn unit factor from device to avoid the hard coded 100 values
        If FileName Is Nothing Then

            Return String.Empty

        End If

        LogFile.Write("Start File Reading")

        'get the filestream
        Dim ioStream As IO.Stream = IO.File.OpenRead(FileName)

        GetDeviceFromHPGL(ioStream, MachinePark)

        'if there was no exception before, at latest now 
        If MachinePark.CurrentDevice Is Nothing Then

            MachinePark.SetCurrentDefaultDevice()

            Return String.Empty

        End If

        ParseHPGL(ioStream, MachinePark.CurrentDevice)

        MachinePark.CurrentDevice.FromFile = True

        'we have to close 
        ioStream.Close()

        LogFile.Write("found hpgl file for: " & MachinePark.CurrentDevice.ID)

        LogFile.Write("End File Reading")

        Return MachinePark.CurrentDevice.ID

    End Function

    ''' <summary>
    ''' Convert a plt to geometry
    ''' </summary>
    ''' <param name="Job">a filestream</param>
    ''' <param name="Device">the device to attach the geomtry</param>
    Private Sub ParseHPGL(ByVal Job As IO.Stream, ByRef Device As CNC_Device)

        Dim CurrentTool As CNC_Tool = New CNC_Tool

        Dim LastHPGL As String = GetNextHpgl(Job)

        Dim myPoly As PolyLine = Nothing

        Dim myCirc As Arc = Nothing

        'Dim isBBox As Boolean = False

        Dim toolselectionstart As Boolean = False


        Dim virtualLayerindex As Integer = 0

        Do Until LastHPGL = "JB0"

            If LastHPGL.Length < 2 Then

                Messenger.Desaster("There is an plt file error: " & LastHPGL & " at position: " & Job.Position)
                Exit Sub

            End If

            Select Case LastHPGL.Substring(startIndex:=0, length:=2)

                Case "PU" 'TOOL UP
                    ' a new object begin
                    ' If isBBox Then

                    ' ''todo:HPGL-Reader If Device.BBoxGeometry.Count = 0 Then

                    ' ''todo:HPGL-Reader     Device.withBBox = True

                    ' ''todo:HPGL-Reader     Device.BBoxGeometry.Add(GetCoordinate(LastHPGL))

                    ' ''todo:HPGL-Reader Else

                    ' ''todo:HPGL-Reader     isBBox = False

                    ' ''todo:HPGL-Reader End If

                    ' Else

                    If myPoly IsNot Nothing Then

                        ''todo:HPGL-Reader  Device.CurrentTool.Geometry.Add(myPoly)
                        Device.AddPlotObject(myPoly)
                        myPoly = Nothing

                    End If

                    If LastHPGL.Length > 2 Then 'kein leere PU;

                        myPoly = New PolyLine

                        Dim myCoord As Coordinate

                        myCoord = GetCoordinate(LastHPGL)

                        myPoly.Points.Add(myCoord)

                    End If

                    'End If

                Case "PD" 'TOOL DOWN

                    'If isBBox Then

                    ''todo:HPGL-Reader If Device.BBoxGeometry.Count < 4 Then

                    ''todo:HPGL-Reader     Dim myPoints As List(Of Coordinate)

                    ''todo:HPGL-Reader     myPoints = GetCoordinates(LastHPGL)

                    ''todo:HPGL-Reader     Device.BBoxGeometry.AddRange(myPoints)

                    ''todo:HPGL-Reader End If

                    'Else

                    Dim myPoints As List(Of Coordinate)

                    myPoints = GetCoordinates(LastHPGL)

                    myPoly.Points.AddRange(myPoints)

                    'End If

                Case "CI"

                    myCirc = New Arc With {
                        .Center = New Coordinate(myPoly.FirstPoint),
                        .Radius = CDbl(GetHPGLValue(LastHPGL)) / 100
                    }

                    ''todo:HPGL-Reader Device.CurrentTool.Geometry.Add(myCirc)
                    Device.AddPlotObject(myCirc)

                    myPoly = Nothing

                Case "ZP" 'Z-AXIS POSITION
                    ''todo:HPGL-Reader setToolValue(Device.CurrentTool, LastHPGL, "zposup", "zposdown")
                    setToolValue(CurrentTool, LastHPGL, "zposup", "zposdown")

                Case "VS" 'VELOCITY SELECT

                    ''todo:HPGL-Reader setToolValue(Device.CurrentTool, LastHPGL, "speeddown", "speedup")
                    setToolValue(CurrentTool, LastHPGL, "speeddown", "speedup")

                Case "JB" 'JOB ECHO

                    Dim JobNo As Integer

                    JobNo = CInt(GetHPGLValue(LastHPGL))

                    If JobNo = 0 Then
                        'this is the end of our job
                        Exit Sub

                    End If

                    If myPoly IsNot Nothing Then
                        'this is the previous, we put them into the stack and reset a new one
                        ''todo:HPGL-Reader Device.CurrentTool.Geometry.Add(myPoly)

                        Device.AddPlotObject(myPoly)

                        myPoly = Nothing

                    End If

                Case "MS" 'MESSAGE - very important to select tool 
                    Dim HpglVal As String = GetHPGLValue(LastHPGL)

                    If HpglVal.Length > 5 Then

                        ' isBBox = False 'ggf wirds dann true

                        Select Case HpglVal.Substring(0, 5)

                            Case "Bound" 'ing Box"

                                ' isBBox = True

                                ''todo:HPGL-Reader         Device.BBoxGeometry = New List(Of GeometryObject)

                                ''todo:HPGL-Reader  Device.BBoxToolID = Device.CurrentTool.ID

                                'CurrentTool = Device.GetTool(Device.BBoxToolID)

                                'Dim myNewGBlock As New CNC_GeometryBlock(Integer.MinValue, CurrentTool, Device)

                                'Device.GeometryBlocks.Add(myNewGBlock)

                                'Device.getLastGBlock()

                                Device.CurrentGBlock.LayerKey = Integer.MinValue

                            Case "Tool:"
                                'select tool
                                Dim ToolID As String

                                ToolID = HpglVal.Substring(5)

                                'Device.CurrentTool = Device.GetTool(Device.GetProperty("BoundingTool").Text)
                                ''todo:HPGL-Reader Device.CurrentTool = Device.GetTool(ToolID)

                                CurrentTool = Device.GetTool(ToolID)

                                Dim myNewGBlock As New CNC_GeometryBlock(virtualLayerindex, CurrentTool, Device)

                                virtualLayerindex += 1

                                Device.GeometryBlocks.Add(myNewGBlock)

                                Device.GetLastGBlock()

                        End Select

                    End If

                Case "LL" 'LASER POWER
                    ''todo:HPGL-Reader setToolValue(Device.CurrentTool, LastHPGL, "powerwork")
                    setToolValue(CurrentTool, LastHPGL, "powerwork")

                Case "ML" 'LASER MINIMAL POWER
                    ''todo:HPGL-Reader setToolValue(Device.CurrentTool, LastHPGL, "powermin")
                    setToolValue(CurrentTool, LastHPGL, "powermin")

                Case "EL" 'RECESS POWER
                    ''todo:HPGL-Reader setToolValue(Device.CurrentTool, LastHPGL, "powerrecess")
                    setToolValue(CurrentTool, LastHPGL, "powerrecess")


                Case "SP" 'SELECT TOOL - ignore, we use a special formated MS because this way is the same for the laser and the cutter
                Case "PB" 'POWERSWITCH BOX - ignore
                Case "SD" 'SET DELAY - igonore
                Case "AS" 'ACCELERATION SELECT - ignore
                Case "CR" 'CIRCLE RESOLUTION - ignore
                Case "XX" 'UNIVERSAL SYNTAX - ignore
                Case "PA" 'PLOT ABSOLUTE - ignore
                Case "NR" 'NOT READY - ignore
                Case "QU" 'SET QUALITY - ignore
                Case "LF" 'LASER FREQUENCY - ignore
                Case "PW" 'TOOL WAITING TIMES - ignore
                Case "EG" 'EXTERNAL GAS - ignore

            End Select

            LastHPGL = GetNextHpgl(Job)

        Loop

    End Sub

    ''' <summary>
    ''' read interesting things from a prejob string
    ''' </summary>
    Private Sub ReadPreJob(ByVal PreString As String, ByRef Device As CNC_Device)

        Dim PreArray() As String = PreString.Split(";"c)

        For Each pa As String In PreArray

            If pa.Length > 1 Then

                Dim Mnem As String = pa.Substring(0, 2)

                Select Case Mnem
                    Case "PU", "PA", "PB", "SD"
                        'ignore

                    Case "AS"
                        Dim DownAcc, UpAcc As String
                        Dim DelimiterPos As Integer

                        DelimiterPos = pa.IndexOf(","c)

                        If DelimiterPos > 0 Then

                            DownAcc = pa.Substring(2, DelimiterPos - 2).Trim

                            Device.SetDeviceProperty("downacceleration", "Value", DownAcc)

                            If pa.Length > DelimiterPos + 1 Then

                                UpAcc = pa.Substring(DelimiterPos + 1)

                                Device.SetDeviceProperty("upacceleration", "Value", UpAcc)

                            End If

                        End If

                End Select

            End If

        Next

    End Sub

    ''' <summary>
    ''' get the first Value from a hpgl command
    ''' </summary>
    Private Function GetHPGLValue(ByVal HPGL As String) As String

        Dim Val1 As String = String.Empty

        Dim Val2 As String = String.Empty

        GetHPGLValues(HPGL, Val1, Val2)

        Return Val1

    End Function

    ''' <summary>
    ''' returns a coordiante from the two values of the HPGL command
    ''' </summary>
    Private Function GetCoordinate(ByVal HPGL As String) As Coordinate

        Dim X As String = String.Empty

        Dim Y As String = String.Empty

        GetHPGLValues(HPGL, X, Y)

        Return New Coordinate(CDbl(X) / 100, CDbl(Y) / 100)

    End Function

    ''' <summary>
    ''' returns two values of a HPGL command
    ''' </summary>
    Private Sub GetHPGLValues(ByVal HPGL As String, ByRef Value1 As String, ByRef Value2 As String)

        Dim DelimiterPos As Integer

        DelimiterPos = HPGL.IndexOf(","c)

        Select Case DelimiterPos

            Case Is > 0

                Value1 = HPGL.Substring(2, DelimiterPos - 2).Trim

                If HPGL.Length > DelimiterPos + 1 Then

                    Value2 = HPGL.Substring(DelimiterPos + 1, HPGL.Length - (DelimiterPos + 1))

                End If

            Case -1

                If HPGL.Length > 2 Then

                    Value1 = HPGL.Substring(2)

                End If

        End Select

    End Sub

    ''' <summary>
    ''' return the next available HPGL command
    ''' </summary>
    Private Function GetNextHpgl(ByRef stream As IO.Stream) As String

        Dim ReadChar As Char

        Dim CommandString As String = String.Empty

        Do While stream.CanRead

            ReadChar = Convert.ToChar(stream.ReadByte)

            If ReadChar <> ";" Then

                CommandString &= ReadChar

            Else

                Return CommandString

            End If

        Loop

        Return Nothing

    End Function

    ''' <summary>
    ''' determine for which device is the plt file
    ''' </summary>
    Private Sub GetDeviceFromHPGL(ByRef HPGLStream As IO.Stream, ByRef MachinePark As CNC_Workshop) 'As CNC_Device

        Dim firstCommand As String = GetNextHpgl(HPGLStream)

        Dim PreString As String = String.Empty

        Dim wasFound As Boolean = False

        For Each Device As CNC_Device In MachinePark.Devices

            PreString = CNC_Workshop.ParsePropertyText(Device.DeviceProperty("prejob").Text, Device.Properties)

            If PreString.StartsWith(firstCommand) Then

                ReadPreJob(PreString, Device)

                wasFound = True

                MachinePark.CurrentDevice = Device
                MachinePark.CurrentDevice.ZeroPoint = New Coordinate

                Exit Sub

            End If

        Next

        If Not wasFound Then

            Messenger.Desaster("This is not a Plot File for one of the given devices.")

        End If

        MachinePark.CurrentDevice = Nothing

    End Sub

    ''' <summary>
    ''' sets a value to a tool property
    ''' </summary>
    Private Sub setToolValue(ByRef Tool As CNC_Tool, ByVal HPGL As String, ByVal FirstValueName As String, Optional ByVal SecondValueName As String = "")

        Dim FirstValue As String = String.Empty

        Dim SecondValue As String = String.Empty

        GetHPGLValues(HPGL, FirstValue, SecondValue)

        Tool.SetToolProperty(FirstValueName, Type:="Value", Value:=FirstValue)

        If SecondValue.Length > 0 Then

            Tool.SetToolProperty(SecondValueName, Type:="Value", Value:=SecondValue)

        Else

            Tool.SetToolProperty(SecondValueName, Type:="Value", Value:=FirstValue)

        End If

    End Sub

    ''' <summary>
    ''' returns a list of coordiante from a list of hpgl coordinates
    ''' </summary>
    Private Function GetCoordinates(ByVal HPGL As String) As List(Of Coordinate)

        Dim myPoints As New List(Of Coordinate)

        Dim Points As String() = HPGL.Substring(2).Split(","c)

        Dim x, y As Integer

        Dim myCoord As Coordinate

        For i As Integer = 0 To Points.Length - 1 Step 2

            x = CInt(Points(i))
            y = CInt(Points(i + 1))

            myCoord = New Coordinate(x / 100, y / 100)

            myPoints.Add(myCoord)

        Next

        Return myPoints

    End Function

End Class
