''' <summary>
''' a cnc device to cut or engrave materials
''' </summary>
Public Class CNC_Device
    Private _withBBox As Boolean

    ''' <summary>
    ''' indicates that the current job comes from a plt file
    ''' </summary>
    Public Property FromFile As Boolean

    ''' <summary>
    ''' list with all available tools
    ''' </summary>
    Public Tools As List(Of CNC_Tool)

    Public Property GeometryBlocks As New List(Of CNC_GeometryBlock)

    Private CurrentGBlockIndex As Integer = 0

    ''' <summary>
    ''' counts objects already cut
    ''' </summary>
    Public CounterItem As Integer

    ''' <summary>
    ''' counts laready cut length
    ''' </summary>
    ''' <remarks >need this for caluclating the progress percentes</remarks>
    Public CounterLength As Double

    ''' <summary>
    ''' list of all properties given from the *.device.xml
    ''' </summary>
    Public Properties As List(Of CNC_Property)

    ''' <summary>
    ''' factor device units to millimeter
    ''' </summary>
    ''' <remarks>defined in device.xml</remarks>
    Public Factor As Double

    ''' <summary>
    ''' the order of tools to cut the object, given in *.device.xml 
    ''' </summary>
    Public ToolOrder As List(Of String)

    ''' <summary>
    ''' place for the HPGL Code for later sending to a file or to the serial port
    ''' </summary>
    ''' <remarks>stringbuild is mucher faster then a string (here about factor 30)</remarks>
    Public JobBuffer As New Text.StringBuilder

    ''' <summary>
    ''' the id of the bounding box toolname
    ''' </summary>
    ''' <remarks>defined in device.xml</remarks>
    Public Property BBoxToolID As String

    ''' <summary>
    ''' the latest position for the tool 
    ''' </summary>
    Public Property ToolPosition As Coordinate

    ''' <summary>
    ''' switch on(1) /off(0) the Reference point feature, check that the pretool or prejob properties setup right 
    ''' </summary>
    Public Property WithReferencePoint As Boolean

    Public Property ReferencePoint As Coordinate = New Coordinate

    ''' <summary>
    '''  the command to switch the device online this will be send as frontend command 
    ''' </summary>
    Public Property SwitchOnlineCommand As String

    ''' <summary>
    ''' 
    ''' </summary>
    Public Property DeleteCutterBuffer As String

    ''' <summary>
    ''' switch on(1) /off(0) the turning the direction from paths during path optimazation if its a shorter path.  
    ''' caused by the eccentricity of the tip of the knife if its switched on the precsision can by lower
    ''' </summary>
    Public Property TurnDirection As Boolean

    ''' <summary>
    ''' a warning before you cut if the default material is still loaded
    ''' </summary>
    Public Property DefaultMaterialWarning As Boolean

    ''' <summary>
    ''' after a job was send to the device, the default material is reselected
    ''' </summary>
    Public Property SwitchDefaultMaterialAtEnd As Boolean

    ''' <summary>
    ''' define to switch on or off the camera picture
    ''' </summary>
    Public Property DisplayBitmap As Boolean

    ''' <summary>
    ''' the path to the camera picture
    ''' </summary>
    Public Property BitmapPath As String

    ''' <summary>
    ''' the size in world units for the square of the bitmap to show
    ''' </summary>
    Public Property BitmapSize As Single

    '''' <summary>
    ''''the size for the bitmap in in pixel
    '''' </summary>
    'Property BitmapResolution As Single

    ''' <summary>
    ''' the x,y 
    ''' </summary>
    Public Property BitmapPosition As Coordinate

    ''' <summary>
    ''' the x,y value in pixels of the top left corrcetion
    ''' </summary>
    Public Property BitmapCorrectionTL As Coordinate

    ''' <summary>
    ''' the x,y value in pixels of the top right corrcetion
    ''' </summary>
    Public Property BitmapCorrectionTR As Coordinate

    ''' <summary>
    ''' the x,y value in pixels of the bottom left corrcetion
    ''' </summary>
    Public Property BitmapCorrectionBL As Coordinate

    ''' <summary>
    ''' the x,y value in pixels of the bottom right corrcetion
    ''' </summary>
    Public Property BitmapCorrectionBR As Coordinate

    ''' <summary>
    ''' the name of the camera device
    ''' </summary>
    Public Property CameraName As String

    ''' <summary>
    ''' the resolution of the camera device in pixels
    ''' </summary>
    Public Property CameraResolution As String

    ''' <summary>
    ''' the estimated time
    ''' </summary>
    ''' <remarks>it will be calculatetd by a call of the CalculateProcessTime sub</remarks>
    Public Property ProcessTime As TimeSpan

    ''' <summary>
    ''' the estimated time as string rounded up to full 5 minutes for showing in the plotter display during the job run
    ''' </summary>
    ''' <remarks>it will be calculatetd by a call of the CalculateProcessTime sub</remarks>
    Public Property EstimatenTotalMinutes As String

    ''' <summary>
    ''' the current working block of geomtry
    ''' </summary>
    Public ReadOnly Property CurrentGBlock As CNC_GeometryBlock

        Get

            If GeometryBlocks.Count = 0 Then

                Return Nothing

            End If

            Return GeometryBlocks(CurrentGBlockIndex)

        End Get

    End Property

    ''' <summary>
    ''' the current working tool
    ''' </summary>
    Private Property CurrentTool As CNC_Tool

    ''' <summary>
    ''' indicates that the cut order is controlled by the layerorder and not by the default order given by the device configusration file
    ''' </summary>
    Public Property CutByLayerOrder As Boolean

    ''' <remarks>for debugging it's more readable</remarks>
    Public Overrides Function ToString() As String

        Return Me.DeviceName

    End Function

    ''' <summary>
    ''' the total number of geometries
    ''' </summary>
    ''' <remarks>the boundingbox counts one</remarks>
    Public ReadOnly Property TotalGeometryCount As Integer

        Get

            Dim myObjects As Integer

            For Each GBlock In GeometryBlocks

                myObjects += GBlock.Geometry.Count

            Next

            If myObjects > 0 Then

                If Me._withBBox Then

                    myObjects += 1

                End If

            End If

            Return myObjects

        End Get

    End Property

    ''' <summary>
    ''' the number of the current cutted object
    ''' </summary>
    Public Property CurrentObject As Integer

        Get

            Return _currentObjectIndex

        End Get

        Set(ByVal value As Integer)

            _currentObjectIndex = value

        End Set

    End Property

    Private _currentObjectIndex As Integer

    ''' <summary>
    ''' graphic to display in the conduit
    ''' </summary>
    ''' <remarks>
    ''' see also displayconduit
    ''' defined in device.xml
    ''' </remarks>
    Public Property ProxyGraphic As List(Of GeometryObject)

    'Private _ProxyRefPoint As List(Of GeometryObject)
    Public Property ProxyRefPoint As List(Of GeometryObject)

    ''' <summary>
    ''' the device id
    ''' </summary>
    ''' <remarks>defined in device.xml</remarks>
    Public Property ID As String

    ''' <summary>
    ''' the readable name of the device
    ''' </summary>
    ''' <remarks>defined in device.xml</remarks>
    Public Property DeviceName As String

    ''' <summary>
    ''' size of the workzone
    ''' </summary>
    ''' <remarks>defined in device.xml</remarks>
    Public Property BenchSize As Coordinate

    '''' <summary>
    '''' indicates the the job will/is cutting a boundingbox
    '''' </summary>
    'Public Property WithBBox As Boolean

    '    Get

    '        If Me.TotalGeometryCount = 0 Then

    '            Return False

    '        Else

    '            Return _withBBox

    '        End If

    '    End Get

    '    Set(ByVal value As Boolean)

    '        _withBBox = value

    '    End Set

    'End Property

    ''' <summary>
    ''' the zeropoint of the device in the current rhino coordinaten system
    ''' </summary>
    Public Property ZeroPoint As New Coordinate

    ''' <summary>
    ''' deletes all geometry object from all tools
    ''' </summary>
    Public Sub PurgeOldObjectsFromTools()

        Me.GeometryBlocks = New List(Of CNC_GeometryBlock)

        _WorkingLength = 0

    End Sub

    ''' <summary>
    ''' set a Device Property
    ''' </summary>
    ''' <param name="Id">the id of the property</param>
    ''' <param name="Name">the Name of the attribute</param>
    ''' <param name="Value">just the value</param>
    Public Sub SetDeviceProperty(ByVal Id As String, ByVal Name As String, ByVal Value As String)

        For Each cProp As CNC_Property In Properties

            If cProp.ID = Id Then

                CallByName(cProp, Name, CallType.Set, Value)

                Exit For

            End If

        Next

    End Sub

    Public Sub New()

        ToolPosition = New Coordinate

        BenchSize = New Coordinate

        ProxyGraphic = New List(Of GeometryObject)

        ProxyRefPoint = New List(Of GeometryObject)

        ID = "--"

    End Sub

    ''' <summary>
    ''' read a *.device.xml
    ''' </summary>
    Public Function ReadXML(ByVal File As String) As Boolean

        Properties = New List(Of CNC_Property)

        Tools = New List(Of CNC_Tool)

        Dim myConfig As XElement = XElement.Load(File)

        ID = CStr(myConfig.Attribute("id"))

        DeviceName = CStr(myConfig.Attribute("text"))

        For Each xtool As XElement In myConfig.Descendants("tool")

            Dim myTool As New CNC_Tool

            If myTool.getConfig(xtool) Then

                myTool.Device = Me

                Tools.Add(myTool)

            End If

        Next

        For Each xconduit As XElement In myConfig.Elements("conduit")

            For Each xConEle As XElement In xconduit.Descendants

                Select Case xConEle.Name.ToString.ToLower

                    Case "line"

                        Dim x1, x2, y1, y2 As Double

                        x1 = CDbl(xConEle.Attribute("x1"))

                        x2 = CDbl(xConEle.Attribute("x2"))

                        y1 = CDbl(xConEle.Attribute("y1"))

                        y2 = CDbl(xConEle.Attribute("y2"))

                        Dim aLine As New PolyLine(x1, y1, x2, y2)

                        Select Case xconduit.Attribute("id").Value.ToString.ToLower
                            Case "absolute"
                                ProxyGraphic.Add(aLine)

                            Case "refpoint"

                                ProxyRefPoint.Add(aLine)

                        End Select

                End Select

            Next

        Next

        For Each xprop As XElement In myConfig.Descendants("property")

            Dim myProp As New CNC_Property

            If myProp.GetConfig(xprop) Then

                Me.Properties.Add(myProp)

                Select Case myProp.ID.ToLower

                    Case "workzone"

                        Me.BenchSize = New Coordinate(myProp.X, myProp.Y)

                    Case "factor"

                        If myProp.Value = 0 Then

                            Me.Factor = 1

                        Else

                            Me.Factor = myProp.Value

                        End If

                    Case "toolorder"

                        Me.ToolOrder = New List(Of String)(myProp.Text.Split(","c))

                    Case "switchonline"

                        Me.SwitchOnlineCommand = myProp.Text

                    Case "deletebuffer"
                        Me.DeleteCutterBuffer = myProp.Text

                    Case "referencepoint"

                        If myProp.Value = 1 Then
                            Me.WithReferencePoint = True

                        Else
                            Me.WithReferencePoint = False

                        End If

                    Case "turndirection"

                        If myProp.Value = 1 Then
                            Me.TurnDirection = True

                        Else
                            Me.TurnDirection = False

                        End If

                    Case "defaultmaterialwarning"

                        If myProp.Value = 1 Then
                            Me.DefaultMaterialWarning = True

                        Else
                            Me.DefaultMaterialWarning = False

                        End If

                    Case "switchdefaultmaterialatend"

                        If myProp.Value = 1 Then
                            Me.SwitchDefaultMaterialAtEnd = True

                        Else
                            Me.SwitchDefaultMaterialAtEnd = False

                        End If

                    Case "bitmap"
                        If myProp.Value = 1 Then
                            Me.DisplayBitmap = True

                        Else
                            Me.DisplayBitmap = False

                        End If

                    Case "bitmappath"
                        Me.BitmapPath = myProp.Text

                    Case "bitmapsize"
                        Me.BitmapSize = CSng(myProp.Value)

                    'Case "bitmapresolution"
                    '    Me.BitmapResolution = CSng(myProp.Value)

                    Case "bitmapposition"
                        Me.BitmapPosition = New Coordinate(myProp.X, myProp.Y)

                    Case "bitmapcorrectiontl"
                        Me.BitmapCorrectionTL = New Coordinate(myProp.X, myProp.Y)

                    Case "bitmapcorrectiontr"
                        Me.BitmapCorrectionTR = New Coordinate(myProp.X, myProp.Y)

                    Case "bitmapcorrectionbl"
                        Me.BitmapCorrectionBL = New Coordinate(myProp.X, myProp.Y)

                    Case "bitmapcorrectionbr"
                        Me.BitmapCorrectionBR = New Coordinate(myProp.X, myProp.Y)

                    Case "cameraname"
                        Me.CameraName = myProp.Text

                    Case "cameraresolution"
                        Me.CameraResolution = myProp.Text

                End Select

            End If

        Next

        Properties.Add(New CNC_Property With {.ID = "username", .Text = Environment.UserName})

        'getFirstTool()

        If ID Is Nothing Then Return False

        Return True

    End Function

    ''' <summary>
    ''' create the HPGL string for the entire job
    ''' </summary>
    Public Sub GenerateHPGL()

        CounterItem = 0

        CounterLength = 0

        GenerateHPGL_PreJob()

        Dim LastToolID As String = Me.GeometryBlocks(0).Tool.ID

        Me.GeometryBlocks(0).Tool.GenerateHPGL_PreTool()

        ' Do
        For i As Integer = 0 To Me.GeometryBlocks.Count - 1

            If LastToolID <> Me.GeometryBlocks(i).Tool.ID Then

                'close the previous tool
                Me.GeometryBlocks(i - 1).Tool.GenerateHPGL_PostTool()
                'open the new tool
                Me.GeometryBlocks(i).Tool.GenerateHPGL_PreTool()

            End If

            'CurrentGBlock.GenerateHPGL(Me.turnDirection)
            Me.GeometryBlocks(i).GenerateHPGL(Me.TurnDirection)

            LastToolID = Me.GeometryBlocks(i).Tool.ID

        Next
        'close the last tool
        Me.GeometryBlocks(Me.GeometryBlocks.Count - 1).Tool.GenerateHPGL_PostTool()

        GenerateHPGL_Postjob()

    End Sub

    ''' <summary>
    ''' create the HPGL output for the beginnig of job commands
    ''' </summary>
    Private Sub GenerateHPGL_PreJob()
        '<property id="prejob" text="PU;PA;PB2,1;SD300;AS2,4;"></property>
        Dim JobString As String

        JobString = CNC_Workshop.ParsePropertyText(DeviceProperty("prejob").Text, Properties)

        If JobString <> String.Empty Then

            JobBuffer.Append(JobString)

        End If

    End Sub

    ''' <summary>
    ''' create the HPGL output for the end of job commands
    ''' </summary>
    Private Sub GenerateHPGL_Postjob()
        '<property id="postjob" text="PU 100000,100000;PB2,0;JB0;XX12,2;MSDone by {username};NR;"/>
        Dim JobString As String

        JobString = CNC_Workshop.ParsePropertyText(DeviceProperty("postjob").Text, Properties)

        If JobString <> String.Empty Then

            JobBuffer.Append(JobString)

        End If

    End Sub

    ''' <summary>
    ''' calculate the procestime for the entire device based on a simulation of the cutting process
    ''' including BBOX time if exits
    ''' </summary>
    Public Sub CalculateProcessTime()

        ProcessTime = Me.PreProcessTime

        For Each GBlock As CNC_GeometryBlock In Me.GeometryBlocks

            GBlock.CalculateProcessTime(ProcessTime)

        Next

        ProcessTime += Me.PostProcessTime

        'one minute more to prevent zero minutes
        ProcessTime += New TimeSpan(0, 1, 0)

        EstimatenTotalMinutes = CStr(Math.Ceiling(CInt((ProcessTime.TotalMinutes)) * 0.2) / 0.2)

    End Sub

    ''' <summary>
    ''' timespan at the begining of every job
    ''' </summary>
    Private Function PreProcessTime() As TimeSpan

        'this is related to the SD300; command in the prejobstring
        'and the another 10 seconds before the device start with the job
        Return New TimeSpan(0, 0, 13)

    End Function

    ''' <summary>
    ''' timespan at the end of every job
    ''' </summary>
    Private Function PostProcessTime() As TimeSpan

        Return New TimeSpan

    End Function

    ''' <summary>
    ''' length of all travel pathes
    ''' </summary>
    Public ReadOnly Property TravelLength As Double

        Get

            Dim myLength As Double = 0

            For Each GBlock In Me.GeometryBlocks

                myLength += GBlock.TravelLength

            Next

            Return myLength

        End Get

    End Property

    ''' <summary>
    ''' length of all working(cutting) pathes including BBoxPathe if exists
    ''' </summary>
    ''' <remarks>make sure that you call CalculateLength before you use this</remarks>
    Public Property WorkingLength As Double

        Get
            If _WorkingLength = 0 Then

                CalculateLength()

            End If

            Return _WorkingLength

        End Get

        Set(ByVal value As Double)

            _WorkingLength = value

        End Set

    End Property

    Private _WorkingLength As Double

    ''' <summary>
    ''' for lower time consumption we call this one time before we use the workinglength property
    ''' </summary>
    Private Sub CalculateLength()

        _WorkingLength = 0

        For Each GBlock In Me.GeometryBlocks

            _WorkingLength += GBlock.WorkingLength

        Next

    End Sub

    ''' <summary>
    ''' sets the bbox tool to the first available from the given list
    ''' </summary>
    Public Sub SetBBoxTool(ByVal list As List(Of String))

        For Each ToolName In list

            For Each t In Tools

                If t.ID = ToolName Then

                    BBoxToolID = ToolName

                    Exit Sub

                End If

            Next

        Next

        'we are here only if the loop didnt find toolname,
        'this is only to prevent toolboxtool is Nothing
        BBoxToolID = DeviceProperty("BoundingTool").Text

    End Sub

    '''' <summary>
    '''' calculates the boundingbox geomtry
    '''' </summary>
    'Public Sub CreateBBox()

    '    Dim offset As Decimal = CDec(Me.DeviceProperty("BBoxOffset").Value)

    '    Dim minX As Double = Double.PositiveInfinity

    '    Dim minY As Double = Double.PositiveInfinity

    '    Dim maxX As Double = Double.NegativeInfinity

    '    Dim maxY As Double = Double.NegativeInfinity

    '    Dim BBoxTool As CNC_Tool = Me.GetTool(BBoxToolID)

    '    Dim BBoxGeometry As CNC_GeometryBlock = New CNC_GeometryBlock(Integer.MinValue, BBoxTool, Me)

    '    'get the closest point to our last position
    '    Dim lastPoint As New Coordinate

    '    For Each GBlock In GeometryBlocks

    '        minX = Math.Min(GBlock.Min.X, minX)

    '        minY = Math.Min(GBlock.Min.Y, minY)

    '        maxX = Math.Max(GBlock.Max.X, maxX)

    '        maxY = Math.Max(GBlock.Max.Y, maxY)

    '    Next

    '    'lastpoint is the last geomtry in the last geometryblock
    '    Dim myGBlocksIndex As Integer = Me.GeometryBlocks.Count - 1

    '    Dim myLastElementindex As Integer = Me.GeometryBlocks(myGBlocksIndex).Geometry.Count - 1

    '    myLastElementindex = Math.Abs(Me.GeometryBlocks(myGBlocksIndex).ProcessOrder(myLastElementindex))

    '    Dim myLastElement As GeometryObject = Me.GeometryBlocks(myGBlocksIndex).Geometry(myLastElementindex - 1)

    '    lastPoint = myLastElement.LastPoint

    '    'offset 
    '    minX -= offset
    '    minY -= offset

    '    maxX += offset
    '    maxY += offset

    '    'inside of the bench 
    '    minX = Math.Max(minX, 0)
    '    minY = Math.Max(minY, 0)

    '    maxX = Math.Min(maxX, BenchSize.X)
    '    maxY = Math.Min(maxY, BenchSize.Y)

    '    'create a closed Polyline
    '    Dim myBBox As New PolyLine

    '    Dim myPoints As New List(Of Coordinate) From {
    '        New Coordinate(minX, minY),
    '        New Coordinate(minX, maxY),
    '        New Coordinate(maxX, maxY),
    '        New Coordinate(maxX, minY)
    '    }

    '    myBBox.Points = myPoints

    '    'not realy an optimazation but find the closest point and reorder the points for the BBox

    '    Dim DistToNextBBoxPoint As Double = Double.PositiveInfinity

    '    Dim closestpointindex As Integer

    '    For i As Integer = 0 To myBBox.Points.Count - 1

    '        Dim Dist As Double = lastPoint.DistanceTo(myBBox.Points(i))

    '        If Dist < DistToNextBBoxPoint Then

    '            DistToNextBBoxPoint = Dist

    '            closestpointindex = i

    '        End If

    '    Next

    '    For i As Integer = 0 To closestpointindex - 1

    '        myBBox.Points.Add(myBBox.Points(0))

    '        myBBox.Points.RemoveAt(0)

    '    Next

    '    'add the first point again to close the polyline
    '    myBBox.Points.Add(myBBox.Points(0))

    '    BBoxGeometry.Geometry.Add(myBBox)

    '    BBoxGeometry.ProcessOrder = New List(Of Integer) From {
    '        1
    '    }

    '    Me.GeometryBlocks.Add(BBoxGeometry)

    'End Sub

    ''' <summary>
    ''' set a tool to the CurrentTool
    ''' </summary>
    Public Function GetTool(ByVal ToolID As String) As CNC_Tool

        For Each t As CNC_Tool In Me.Tools

            If t.ID = ToolID Then

                Return t

            End If

        Next

        Return Nothing

    End Function

    ''' <summary>
    ''' get a Device Property by his ID
    ''' </summary>
    ''' <param name="Id">the id as in the *.device.xml file used</param>
    Public Function DeviceProperty(ByVal ID As String) As CNC_Property

        For Each prop As CNC_Property In Properties

            If prop.ID = ID Then

                Return prop

            End If

        Next

        Return Nothing

    End Function

    ''' <summary>
    ''' moves the geomtry
    ''' </summary>
    Public Sub TransformGeometry(ByVal MoveVector As Coordinate)

        For Each GBlock As CNC_GeometryBlock In Me.GeometryBlocks

            GBlock.TransformGeometry(MoveVector)

        Next

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="SortLayerInd"></param>
    ''' <param name="ToolId"></param>
    ''' <returns></returns>
    Public Function SetGeometryBlock(ByVal SortLayerInd As Integer, ByVal ToolId As String) As Boolean

        For i As Integer = 0 To GeometryBlocks.Count - 1

            If GeometryBlocks(i).LayerKey = SortLayerInd Then

                CurrentGBlockIndex = i

                Exit For

            End If

        Next

        Dim myTool As CNC_Tool = Me.GetTool(ToolId)

        If myTool Is Nothing Then

            Return False

        End If

        GeometryBlocks.Add(New CNC_GeometryBlock(SortLayerInd, myTool, Me))

        CurrentGBlockIndex = GeometryBlocks.Count - 1

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub GetFirstGBlock()

        CurrentGBlockIndex = 0

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function GetNextGBlock() As Boolean
        'debug: chek das das wirklich der nächste block ist
        If GeometryBlocks.Count - 1 > CurrentGBlockIndex Then

            CurrentGBlockIndex += 1

            Return True

        End If

        Return False

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ToolName"></param>
    ''' <returns></returns>
    Public Function SetGeometryBlock(ByVal ToolName As String) As Boolean

        'CurrentGBlockIndex = -1

        For i As Integer = 0 To GeometryBlocks.Count - 1

            If GeometryBlocks(i).Tool.ID = ToolName Then

                CurrentGBlockIndex = i

                Exit For

            End If

        Next

        'if we are here and we couldn't find a gblock, lets test that the tool exist
        Dim myTool As CNC_Tool = Me.GetTool(ToolName)

        If myTool Is Nothing Then

            Return False

        End If

        'so the tool exist we didn't found a gblock, then lets create a new one

        GeometryBlocks.Add(New CNC_GeometryBlock(0, myTool, Me))

        CurrentGBlockIndex = GeometryBlocks.Count - 1

        Return True

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objToolName"></param>
    ''' <param name="Gobject"></param>
    Public Sub AddPlotObject(ByVal objToolName As String, ByVal Gobject As GeometryObject)

        For Each GBlock In Me.GeometryBlocks

            If objToolName = GBlock.Tool.ID Then

                GBlock.Geometry.Add(Gobject)

                GBlock.SetExtends(Gobject)

                Exit Sub

            End If

        Next

        Dim myTool As CNC_Tool = Me.GetTool(objToolName)

        If myTool IsNot Nothing Then

            Dim myGblock As New CNC_GeometryBlock(-1, myTool, Me)

            myGblock.Geometry.Add(Gobject)

            myGblock.SetExtends(Gobject)

            Me.GeometryBlocks.Add(myGblock)

        End If

    End Sub

    ''' <summary>
    ''' returns the last geometry block from all geometry blocks
    ''' </summary>
    Public Sub GetLastGBlock()

        CurrentGBlockIndex = Me.GeometryBlocks.Count - 1

    End Sub

    ''' <summary>
    ''' put an object to cut onto the big stack
    ''' </summary>
    Public Sub AddPlotObject(ByVal GObject As GeometryObject)

        Me.CurrentGBlock.Geometry.Add(GObject)

        Me.CurrentGBlock.SetExtends(GObject)

    End Sub

End Class
