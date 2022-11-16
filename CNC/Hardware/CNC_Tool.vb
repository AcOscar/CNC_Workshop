
Public Class CNC_Tool

    ''' <summary>
    ''' the reference to the parent device
    ''' </summary>
    Public Device As CNC_Device

    ''' <summary>
    ''' the ID as in the *.device.xml tool sectine given
    ''' </summary>
    Public Property ID As String

    ' ''' <summary>
    ' ''' the name of the tool in the UI
    ' ''' </summary>
    'Public Property DisplayName As String

    ' ''' <summary>
    ' ''' the ID of the tool for HPGL comands
    ' ''' </summary>
    'Public Property CommandID As String

    ''' <summary>
    ''' a list of propertier inside the tool section in the *.device.xml
    ''' </summary>
    Property Properties As List(Of CNC_Property)

    ''' <summary>
    ''' die Geomtry die die bearbeitet werden muss 
    ''' </summary>
    Property Geometry As List(Of GeometryObject)

    ''' <summary>
    ''' the value for the accelaration if the tool is down, if its not given by the tool defioniton the devie setting will by used
    ''' </summary>
    Public ReadOnly Property DownAcceleration As Integer

        Get
            Dim myprop As CNC_Property = GetProperty("downacceleration")

            If myprop Is Nothing Then
                'properly is given by device
                myprop = Device.DeviceProperty("downacceleration")

                If myprop Is Nothing Then
                    ' this is the lowest allowed value
                    Return 1

                End If

            End If

            Dim myRet As Double = myprop.Value

            Return CType(myRet, Integer)

        End Get

    End Property

    ''' <summary>
    ''' the value for the accelaration if the tool is ip, if its not available the DownAcceleration will be used
    ''' </summary>
    Public ReadOnly Property UpAcceleration As Integer

        Get
            Dim myprop As CNC_Property = GetProperty("upacceleration")

            If myprop Is Nothing Then
                'properly is given by device
                myprop = Device.DeviceProperty("upacceleration")

                If myprop Is Nothing Then
                    ' this is the lowest allowed value
                    Return 1

                End If

            End If

            Dim myRet As Double = myprop.Value

            Return CType(myRet, Integer)

        End Get

    End Property

    ' ''' <summary>
    ' ''' Reihenfolge in der gearbeitet wird
    ' ''' </summary>
    ' ''' <remarks>1-based, negative werte zeigen umgekehrte schnittrichtung an</remarks>
    'Public ProcessOrder As New List(Of Integer)

    ''' <summary>
    ''' get's the configuration from a XML element
    ''' </summary>
    Function getConfig(ByVal xtool As Xml.Linq.XElement) As Boolean

        _Properties = New List(Of CNC_Property)

        ID = CStr(xtool.Attribute("id"))

        For Each xprop As XElement In xtool.Descendants("property")

            Dim myProp As New CNC_Property

            If myProp.GetConfig(xprop) Then

                _Properties.Add(myProp)

            End If

        Next

        If ID Is Nothing Then Return False Else Return True

    End Function

    ''' <summary>
    ''' HPGL commands to initailize the tool
    ''' </summary>
    Public Sub GenerateHPGL_PreTool()

        Dim JobString As String

        JobString = WrkShp.CNC_Workshop.ParsePropertyText(GetProperty("pretool").Text, Properties, Me.ID)

        If JobString <> String.Empty Then

            Device.JobBuffer.Append(JobString)

        End If

    End Sub

    ''' <summary>
    ''' HPGL commands to shutdown the tool
    ''' </summary>
    Public Sub GenerateHPGL_PostTool()

        Dim JobString As String

        JobString = CNC_Workshop.ParsePropertyText(GetProperty("posttool").Text, Properties, Me.ID)

        If JobString <> String.Empty Then

            Device.JobBuffer.Append(JobString)

        End If

    End Sub

    Public Sub New()

        ' Geometry = New List(Of GeometryObject)

    End Sub

    Public Overrides Function ToString() As String

        Return ID

    End Function

    ' ''' <summary>
    ' ''' generates the complete HPGL Command for initailize the tool, the tool geomtries and tool shutdown commands
    ' ''' </summary>
    'Sub GenerateHPGL(ByVal turnDirection As Boolean)

    '    If Me.Geometry.Count = 0 Then Exit Sub

    '    GenerateHPGL_PreTool()

    '    GenerateHPGL_ToolGeometry(turnDirection)

    '    GenerateHPGL_PostTool()

    'End Sub

    ' ''' <summary>
    ' ''' generate the tool geometrie HPGL Commands
    ' ''' </summary>
    'Private Sub GenerateHPGL_ToolGeometry(ByVal turnDirection As Boolean)

    '    If Geometry Is Nothing Then

    '        Exit Sub

    '    End If

    '    For Each gInd As Integer In ProcessOrder

    '        Dim g As GeometryObject

    '        g = Geometry(Math.Abs(gInd) - 1)

    '        curtool_ObjectBegin(g)

    '        If turnDirection Then

    '            If gInd < 0 Then

    '                If Not g.isReverted Then

    '                    g.ReversPointOrder()

    '                End If

    '            End If

    '        End If

    '        Device.JobBuffer.Append(g.HPGL(CInt(Device.Factor)))

    '    Next

    'End Sub

    ''' <summary>
    ''' set a property given by an external cnc_Toolseting
    ''' </summary>
    Sub setPropertyBySetting(ByVal ts As CNC_ToolSetting)

        If ts.PostTool IsNot Nothing Then

            setProperty("posttol", ts.PostTool, wasDisplayed:=False)

        End If

        If ts.PowerMin IsNot Nothing Then

            setProperty("powermin", ts.PowerMin, wasDisplayed:=False)

        End If

        If ts.PowerRecess IsNot Nothing Then

            setProperty("powerrecess", ts.PowerRecess, wasDisplayed:=False)

        End If

        If ts.PowerWork IsNot Nothing Then

            setProperty("powerwork", ts.PowerWork, wasDisplayed:=False)

        End If

        If ts.PreTool IsNot Nothing Then

            setProperty("pretool", ts.PreTool, wasDisplayed:=False)

        End If

        If ts.SpeedDown IsNot Nothing Then

            setProperty("speeddown", ts.SpeedDown, wasDisplayed:=False)

        End If

        If ts.SpeedUp IsNot Nothing Then

            setProperty("speedup", ts.SpeedUp, wasDisplayed:=False)

        End If

        If ts.Text IsNot Nothing Then

            setProperty("Text", ts.Text, wasDisplayed:=False)

        End If

        If ts.ZposDown IsNot Nothing Then

            setProperty("zposdown", ts.ZposDown, wasDisplayed:=False)

        End If

        If ts.ZposUp IsNot Nothing Then

            setProperty("zposup", ts.ZposUp, wasDisplayed:=False)

        End If

    End Sub

    ''' <summary>
    ''' sets a cnc_property identify by ID with a Value
    ''' </summary>
    Public Sub setProperty(ByVal PropertyID As String, ByVal Value As String, ByVal wasDisplayed As Boolean)

        For Each p As CNC_Property In Properties

            If p.ID = PropertyID Then

                If wasDisplayed Then

                    p.Value = CDbl(Value) / p.DisplayFactor

                Else

                    p.Value = CDbl(Value)

                End If

                Exit Sub

            End If

        Next

    End Sub

    ''' <summary>
    ''' sets a cnc_property identify by ID with a text
    ''' </summary>
    Public Sub setPropertyText(ByVal PropertyID As String, ByVal Text As String)

        For Each p As CNC_Property In Properties

            If p.ID = PropertyID Then

                p.Text = Text

                Exit Sub

            End If

        Next

    End Sub

    ''' <summary>
    ''' setzt den wert eines cnc_proerties
    ''' </summary>
    ''' <param name="PropertyID">der name des properties</param>
    ''' <param name="Type">der name des wertes</param>
    ''' <param name="Value">der wert der schreiben wird</param>
    Public Sub SetToolProperty(ByVal PropertyID As String, ByVal Type As String, ByVal Value As String)

        For Each Prop As CNC_Property In Properties

            If Prop.ID = PropertyID Then

                CallByName(Prop, Type, CallType.Set, Value)

                Exit For

            End If

        Next

    End Sub

    ''' <summary>
    ''' sets all tool properties to the default values given in the *.device.xml
    ''' </summary>
    Sub setDefault()

        For Each p As CNC_Property In Properties

            p.Value = p.DefaultValue

        Next

    End Sub

    ' ''' <summary>
    ' ''' calculate the procestime for the entire tool based on a simulation of the cutting process
    ' ''' </summary>
    ' ''' <param name="Spawn">a refernce to a timespan</param>
    'Sub CalculateProcessTime(ByRef Spawn As TimeSpan)
    '    TravelLength = 0
    '    For i = 1 To Me.ProcessOrder.Count - 1

    '        Dim myToGeometry As GeometryObject

    '        myToGeometry = Me.Geometry(Math.Abs(Me.ProcessOrder(i)) - 1)

    '        Dim myLength As Double

    '        myLength = myToGeometry.Length

    '        Dim myInterroptions As Integer

    '        myInterroptions = getInteruptions(myToGeometry)

    '        Dim myTravelDistance As Double

    '        Dim myToPpoint As Coordinate

    '        If Me.ProcessOrder(i) < 0 Then

    '            myToPpoint = myToGeometry.LastPoint

    '        Else

    '            myToPpoint = myToGeometry.FirstPoint

    '        End If

    '        Dim myFromGeometry As GeometryObject

    '        myFromGeometry = Me.Geometry(Math.Abs(Me.ProcessOrder(i - 1)) - 1)

    '        Dim myFromPpoint As Coordinate

    '        If Me.ProcessOrder(i - 1) < 0 Then

    '            myFromPpoint = myFromGeometry.FirstPoint

    '        Else

    '            myFromPpoint = myFromGeometry.LastPoint

    '        End If

    '        myTravelDistance = myFromPpoint.DistanceTo(myToPpoint)

    '        TravelLength += myTravelDistance

    '        Spawn += getTime4Travel(myTravelDistance)

    '        Spawn += getTime4Work(myLength)

    '        Spawn += getTime4Interruptions(myInterroptions)

    '    Next

    'End Sub

    ' ''' <summary>
    ' ''' delivers the length of all geometries to cut
    ' ''' </summary>
    'Public ReadOnly Property WorkingLength As Double
    '    Get

    '        Dim _ret As Double

    '        For Each g As GeometryObject In Geometry

    '            _ret += g.Length

    '        Next

    '        Return _ret

    '    End Get

    'End Property

    ' ''' <summary>
    ' ''' the length auf all empty pathes
    ' ''' </summary>
    'Public TravelLength As Double

    ' ''' <summary>
    ' ''' numbers of interuption (Tool Up and Downs) inside of a geometry
    ' ''' this depends on the tool and the cutted angle
    ' ''' </summary>
    ' ''' <remarks>currently not proper implamented </remarks>
    'Private Function getInteruptions(ByVal Geometry As GeometryObject) As Integer
    '    'LATER: getInteruptions
    '    Return 1

    'End Function

    ' ''' <summary>
    ' ''' calculates the time for all working pathes
    ' ''' </summary>
    ' ''' <remarks>curently all pathes at once and not path by path</remarks>
    'Private Function getTime4Work(ByVal Distance As Double) As TimeSpan
    '    'LATER: getTime4Work path by path and not all pathes at once
    '    Dim myTime As New TimeSpan

    '    myTime = getTime(Distance, GetProperty("speeddown").Value, DownAcceleration)

    '    Return myTime

    'End Function

    ' ''' <summary>
    ' ''' calculates the time for interuptions
    ' ''' </summary>
    'Private Function getTime4Interruptions(ByVal myInterroptions As Integer) As TimeSpan

    '    Dim myinteruptions As Long = CLng(GetProperty("interuptiontime").Value * myInterroptions * 10000)

    '    Dim myTime As New TimeSpan(myinteruptions)

    '    Return myTime

    'End Function

    ' ''' <summary>
    ' ''' calculates the time for traveling
    ' ''' </summary>
    'Private Function getTime4Travel(ByVal Distance As Double) As TimeSpan
    '    'LATER: getTime4Work path by path and not all pathes at once
    '    Dim myTime As New TimeSpan

    '    myTime = getTime(Distance, GetProperty("speeddown").Value, UpAcceleration)

    '    Return myTime

    'End Function

    ' ''' <summary>
    ' ''' calculates the time for a distance by recognizing speed and acceloration
    ' ''' </summary>
    ' ''' <param name="Distance">in mm</param>
    ' ''' <param name="Speed">in cm/s</param>
    ' ''' <param name="Acceleration">given in Plotter units, get get 1 to 4</param>
    'Private Function getTime(ByVal Distance As Double, ByVal Speed As Double, ByVal Acceleration As Integer) As TimeSpan

    '    Dim myTime As TimeSpan

    '    Dim _acceleration As Double

    '    Select Case Acceleration
    '        Case 1
    '            _acceleration = 125

    '        Case 2
    '            _acceleration = 250

    '        Case 3
    '            _acceleration = 500

    '        Case 4
    '            _acceleration = 1000

    '        Case Else
    '            _acceleration = 0

    '    End Select

    '    If _acceleration <> 0 Then

    '        'TimeToFullSpeed
    '        Dim T2FS As TimeSpan
    '        ' T2FS = TimeSpan.FromSeconds((SpeedDown * 10) / (_acceleration * 10))
    '        T2FS = TimeSpan.FromSeconds((Speed * 10) / _acceleration)
    '        'Distance to FullSpeed
    '        Dim D2FS As Double

    '        D2FS = 0.5 * _acceleration * (T2FS.TotalSeconds) ^ 2

    '        If Distance > D2FS Then

    '            myTime = TimeSpan.FromSeconds((Distance - D2FS) / (Speed * 10))

    '            myTime += T2FS

    '        Else

    '            myTime = TimeSpan.FromSeconds(Math.Sqrt(2 * Distance / _acceleration))

    '        End If

    '    Else

    '        myTime = TimeSpan.FromSeconds(Distance / (Speed * 10))

    '    End If

    '    Return myTime

    'End Function

    ' ''' <summary>
    ' ''' generates hpgl code for the bbox
    ' ''' </summary>
    'Public Sub GenerateHPGL_BBox(ByVal bbox As List(Of GeometryObject))

    '    If bbox Is Nothing Then

    '        Exit Sub

    '    End If

    '    If bbox.Count = 0 Then

    '        Exit Sub

    '    End If

    '    GenerateHPGL_PreTool()

    '    curtool_ObjectBegin(Nothing)

    '    Dim myLine As New PolyLine

    '    For i = 0 To 3

    '        myLine.Points.Add(CType(bbox(i), Coordinate))

    '    Next

    '    'to close thwe polyline
    '    myLine.Points.Add(myLine.Points(0))

    '    Device.JobBuffer.Append(myLine.HPGL(CInt(Device.Factor)))

    '    GenerateHPGL_PostTool()

    'End Sub

    ''' <summary>
    ''' get the cnc property by his ID
    ''' </summary>
    Function GetProperty(ByVal ID As String) As CNC_Property

        For Each prop As CNC_Property In _Properties

            If prop.ID = ID Then

                Return prop

            End If

        Next

        Return Nothing

    End Function

    ' ''' <summary>
    ' ''' the begin of a geometry object
    ' ''' </summary>
    'Private Sub curtool_ObjectBegin(ByRef GeomObj As GeometryObject)

    '    Device.CounterItem += 1

    '    Device.JobBuffer.Append("JB" & Device.CounterItem & ";")

    '    If GeomObj IsNot Nothing Then

    '        Dim myPercent As Integer = CInt(CLng(Device.CounterLength * 100) \ CLng(Device.WorkingLength))

    '        Dim myDisplayText As String = myPercent & "% of " & Device.EstimatenTotalMinutes & " min"

    '        'right bound
    '        myDisplayText = myDisplayText.PadLeft(20)
    '        'make sure that it's not too long
    '        myDisplayText = myDisplayText.Substring(0, 20)

    '        'Device.JobBuffer.Append("XX12,2;MSProcessed: " & myPercent & "%;")
    '        Device.JobBuffer.Append("XX12,2;MS" & myDisplayText & ";")

    '        Device.CounterLength += GeomObj.Length

    '    Else

    '        Device.JobBuffer.Append("XX12,2;MSBounding Box;")

    '    End If

    'End Sub

    ' ''' <summary>
    ' ''' calculate the procestime for the bbox based on a simulation of the cutting process
    ' ''' </summary>
    'Sub CalculateProcessTimeBBox(ByRef ProcessTime As TimeSpan, ByVal bbox As List(Of GeometryObject))

    '    ProcessTime += getTime4Work(BBoxLength(bbox))

    'End Sub

    'this is familar to generat bbox hpgl but we need the lenght
    'unfurtantly we generate the hpglcode (much)later than we need thr length(time)
    ReadOnly Property BBoxLength(ByVal bbox As List(Of GeometryObject)) As Double

        Get

            Dim myLength As Double = 0

            If bbox Is Nothing Then

                Return myLength

            End If

            If bbox.Count = 0 Then

                Return myLength

            End If

            Dim g As GeometryObject = Nothing

            'for a smother run the following loop
            bbox.Add(bbox(0))

            For i = 0 To 3

                Dim myLine As New PolyLine(CType(bbox(i), Coordinate), CType(bbox(i + 1), Coordinate))

                'avoid lines along edges
                If myLine.FirstPoint.X = 0 AndAlso myLine.LastPoint.X = 0 Then

                    Continue For

                End If

                If myLine.FirstPoint.Y = 0 AndAlso myLine.LastPoint.Y = 0 Then

                    Continue For

                End If

                If myLine.FirstPoint.X = Me.Device.BenchSize.X AndAlso myLine.LastPoint.X = Me.Device.BenchSize.X Then

                    Continue For

                End If

                If myLine.FirstPoint.Y = Me.Device.BenchSize.Y AndAlso myLine.LastPoint.Y = Me.Device.BenchSize.Y Then

                    Continue For

                End If

                myLength += myLine.Length

            Next

            bbox.RemoveAt(bbox.Count - 1)

            Return myLength

        End Get

    End Property

    'Sub TransformGeometry(ByVal MoveVector As Coordinate)

    '    If Me.Geometry.Count > 0 Then

    '        For Each g As GeometryObject In Me.Geometry

    '            g.Transform(MoveVector)

    '        Next

    '    End If

    'End Sub

End Class
