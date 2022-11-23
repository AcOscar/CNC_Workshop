Imports Rhino
Imports Rhino.DocObjects
Imports Rhino.Geometry

Public Class RhWorker

    ''' <summary>
    ''' the instance to our conduit
    ''' </summary>
    Public Conduit As RhDisplayConduit

    ''' <summary>
    ''' the key to identify tool assignment to a layer
    ''' </summary>
    Const ToolKey As String = "cnc_tool"

    ''' <summary>
    ''' instance for the optimizer class
    ''' </summary>
    Protected Friend Optimizer As New OptimizerByIndex

    ''' <summary>
    ''' list of hidden objects to remember for UnHideAllObjects
    ''' </summary>
    Private HiddenObjects As New List(Of RhinoObject)

    ''' <summary>
    ''' the list of layerindixices in right sort order
    ''' </summary>
    ''' <remarks></remarks>
    Private SortedLayerIndex As List(Of Integer)

    ' ''' <summary>
    ' ''' reference to some windows forms 
    ' ''' </summary>
    'Property InfoLabel As Label
    'Property PB_FileUpload As ProgressBar
    '  Property PB_JobProcess As ProgressBar

    ''' <summary>
    ''' converts a RhinoObject to a GeometryObject
    ''' </summary>
    ''' <param name="rhObj">the rhino object</param>
    ''' <param name="ZeroPoint">the zeropoint of the bench</param>
    Public Function RhToToolGeom(ByVal rhObj As RhinoObject, ByVal ZeroPoint As Coordinate) As GeometryObject

        Dim myObj As GeometryObject = Nothing

        Select Case rhObj.ObjectType
            ' Point
            Case Rhino.DocObjects.ObjectType.Point

                Dim myPoint As DocObjects.PointObject = CType(rhObj, PointObject)

                Dim Point As New Coordinate(myPoint.PointGeometry.Location.X - ZeroPoint.X,
                                            myPoint.PointGeometry.Location.Y - ZeroPoint.Y)

                myObj = Point

            Case Rhino.DocObjects.ObjectType.Curve

                Dim myCurve As DocObjects.CurveObject = CType(rhObj, CurveObject)

                Select Case myCurve.CurveGeometry.GetType

                    Case GetType(ArcCurve)

                        Dim myArc As ArcCurve = CType(myCurve.Geometry, ArcCurve)

                        If myArc.IsCompleteCircle Then

                            Dim mycncArc As New Arc With {
                                .Center = New Coordinate(myArc.Arc.Center.X - ZeroPoint.X, myArc.Arc.Center.Y - ZeroPoint.Y),
                                .Radius = myArc.Arc.Radius,
                                .StartPoint = New Coordinate(myArc.Arc.StartPoint.X - ZeroPoint.X, myArc.Arc.StartPoint.Y - ZeroPoint.Y),
                                .EndPoint = New Coordinate(myArc.Arc.EndPoint.X - ZeroPoint.X, myArc.Arc.EndPoint.Y - ZeroPoint.Y),
                                .IsCompleteCircle = True,
                                .AngleDegrees = myArc.Arc.AngleDegrees,
                                .Orientation = CType(myArc.ClosedCurveOrientation(), Arc.CurveOrientation)
                            }

                            myObj = mycncArc

                        Else

                            Dim mycncArc As New Arc

                            mycncArc.Center = New Coordinate(myArc.Arc.Center.X - ZeroPoint.X, myArc.Arc.Center.Y - ZeroPoint.Y)
                            mycncArc.Radius = myArc.Arc.Radius
                            mycncArc.StartPoint = New Coordinate(myArc.Arc.StartPoint.X - ZeroPoint.X, myArc.Arc.StartPoint.Y - ZeroPoint.Y)
                            mycncArc.EndPoint = New Coordinate(myArc.Arc.EndPoint.X - ZeroPoint.X, myArc.Arc.EndPoint.Y - ZeroPoint.Y)
                            mycncArc.IsCompleteCircle = False
                            mycncArc.AngleDegrees = myArc.Arc.AngleDegrees
                            mycncArc.Orientation = CType(myArc.ClosedCurveOrientation(), Arc.CurveOrientation)
                            myObj = mycncArc
                            'Dim mycncArc As New Arc With {
                            '    .Center = New Coordinate(myArc.Arc.Center.X - ZeroPoint.X, myArc.Arc.Center.Y - ZeroPoint.Y),
                            '    .Radius = myArc.Arc.Radius,
                            '    .StartPoint = New Coordinate(myArc.Arc.StartPoint.X - ZeroPoint.X, myArc.Arc.StartPoint.Y - ZeroPoint.Y),
                            '    .EndPoint = New Coordinate(myArc.Arc.EndPoint.X - ZeroPoint.X, myArc.Arc.EndPoint.Y - ZeroPoint.Y),
                            '    .IsCompleteCircle = False,
                            '    .AngleDegrees = myArc.Arc.AngleDegrees
                            '}
                            '.Orientation = CType(myArc.ClosedCurveOrientation(), Arc.CurveOrientation
                            ')

                            'alt
                            'LATER: teilkreise als eigene objecte und nicht als polylinien
                            'Dim myPoint As New Coordinate(myArc.PointAtStart.X, myArc.PointAtStart.Y)

                            'Dim mypline As New PolyLine

                            'mypline.Points.Add(CType(myPoint - ZeroPoint, Coordinate))

                            'mypline.Points.AddRange(PointsFromArc(myArc, ZeroPoint))

                            'myObj = mypline
                            '/alt
                        End If

                    Case GetType(NurbsCurve)

                        Dim myNurbsCurve As NurbsCurve = CType(myCurve.Geometry, NurbsCurve)

                        ' Dim myPoint As New Coordinate(myNurbsCurve.PointAtStart.X, myNurbsCurve.PointAtStart.Y)

                        Dim myNurbs As New Nurbs

                        ' mypline.Points.Add(CType(myPoint - ZeroPoint, Coordinate))

                        myNurbs.Points.AddRange(PointsFromNurbs(myNurbsCurve, ZeroPoint))

                        myObj = myNurbs

                    Case GetType(PolylineCurve)

                        Dim myPolylineCurve As PolylineCurve = CType(myCurve.Geometry, PolylineCurve)

                        Dim myPoint As New Coordinate(myPolylineCurve.Point(0).X, myPolylineCurve.Point(0).Y)

                        Dim mypline As New NPolyline

                        mypline.Points.Add(CType(myPoint - ZeroPoint, Coordinate))

                        mypline.Points.AddRange(PointsFromPolyline(myPolylineCurve, ZeroPoint))

                        myObj = mypline

                    Case GetType(PolyCurve)

                        Dim myPoint As New Coordinate

                        Dim PlCrv As PolyCurve = CType(myCurve.CurveGeometry, PolyCurve)

                        myPoint = New Coordinate(PlCrv.PointAtStart.X, PlCrv.PointAtStart.Y)

                        Dim mypline As New PolyLine

                        mypline.Points.Add(CType(myPoint - ZeroPoint, Coordinate))

                        For i = 0 To PlCrv.SegmentCount - 1

                            Dim mySegment As Curve = PlCrv.SegmentCurve(i)

                            Select Case mySegment.GetType

                                Case GetType(NurbsCurve)

                                    mypline.Points.AddRange(PointsFromNurbs(CType(mySegment, NurbsCurve), ZeroPoint))

                                Case GetType(LineCurve)

                                    mypline.Points.AddRange(PointsFromLine(CType(mySegment, LineCurve), ZeroPoint))

                                Case GetType(ArcCurve)

                                    mypline.Points.AddRange(PointsFromArc(CType(mySegment, ArcCurve), ZeroPoint))

                                Case GetType(PolylineCurve)

                                    mypline.Points.AddRange(PointsFromPolyline(CType(mySegment, PolylineCurve), ZeroPoint))

                            End Select

                        Next

                        myObj = mypline

                    Case GetType(LineCurve)

                        Dim LCrv As LineCurve = CType(myCurve.CurveGeometry, LineCurve)

                        Dim myPoint As New Coordinate

                        myPoint = New Coordinate(LCrv.PointAtStart.X - ZeroPoint.X, LCrv.PointAtStart.Y - ZeroPoint.Y)

                        Dim mypline As New PolyLine

                        mypline.Points.Add(myPoint)

                        mypline.Points.AddRange(PointsFromLine(LCrv, ZeroPoint))

                        myObj = mypline

                End Select

            Case Rhino.DocObjects.ObjectType.InstanceReference

                'Dim iref = TryCast(rhObj, Rhino.DocObjects.InstanceObject)

                'If iref IsNot Nothing Then

                '    Dim idef = iref.InstanceDefinition

                '    If idef IsNot Nothing Then

                '        Dim rhino_objects = idef.GetObjects()

                '        For Each obj In rhino_objects

                '            Rhino.RhinoApp.WriteLine("Object id={0}", obj.Id)

                '        Next

                '    End If

                'End If

        End Select

        Return myObj

    End Function

    ''' <summary>
    ''' handled a cellevent during modifing a layer propertiy
    ''' </summary>
    Friend Sub ToolForLayer(ByRef LayerName As String,
                         ByRef ToolName As String)

        If ToolName <> "" Then

            Dim doc As RhinoDoc

            doc = Rhino.RhinoDoc.ActiveDoc

            Dim layer_table As Tables.LayerTable = doc.Layers

#Disable Warning BC40000 ' Type or member is obsolete
            Dim layer_index As Integer = layer_table.Find(LayerName.TrimStart, True)
#Enable Warning BC40000 ' Type or member is obsolete

            layer_table(layer_index).SetUserString(ToolKey, ToolName)

        End If

    End Sub

    ''' <summary>
    ''' refresh the layer list after manipulating layer properties externaly like renaming or sort order
    ''' </summary>
    Public Sub RefreshLayerList(ByRef LayerGrid As System.Windows.Forms.DataGridView, ByVal ListVisibleOnly As Boolean)
        Dim cmb As New DataGridViewComboBoxColumn()

        cmb = CType(LayerGrid.Columns(1), DataGridViewComboBoxColumn)

        LayerGrid.Rows.Clear()

        Dim layer_table As Tables.LayerTable = RhinoDoc.ActiveDoc.Layers

        If layer_table.ActiveCount = 0 Then

            Exit Sub

        End If

        Dim n As Integer = 0

        For Each l As Layer In layer_table

            If l.IsDeleted Then

                Continue For

            End If

            If ListVisibleOnly Then

                If Not l.IsVisible Then

                    Continue For

                End If

            End If

            Dim LayerName As String = String.Empty

            'to get the prefix for sublayers
            LayerName = GetParentString(l)

            LayerName &= l.Name

            Dim userdata As String = String.Empty

            userdata = l.GetUserString(ToolKey)

            LayerGrid.Rows.Add()

            LayerGrid.Rows(n).Height = 40

            LayerGrid.Rows(n).Cells(0).Value = LayerName

            If userdata Is Nothing Then

                userdata = String.Empty

            End If

            If Not cmb.Items.Contains(userdata) Then

                LogFile.Write("unkown tool: " & userdata)
                cmb.Items.Add(userdata)

            End If

            If userdata = String.Empty Then

                LayerGrid.Rows(n).Cells(1).Value = "-"

            Else

                LayerGrid.Rows(n).Cells(1).Value = userdata

            End If

            'the 3. column is hidden, but we need them to sort it later
            LayerGrid.Rows(n).Cells(2).Value = l.SortIndex

            'the 4.colum is also hidden but we need the layerindex later for the selection process, and on this way we have a sorted list of the layer
#Disable Warning BC40000 ' Type or member is obsolete
            LayerGrid.Rows(n).Cells(3).Value = l.LayerIndex
#Enable Warning BC40000 ' Type or member is obsolete

            n += 1

        Next

        'sort into the right order
        LayerGrid.Sort(LayerGrid.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
        'debug: hier checken ob die sorted list richtig gesetzt wird
        SortedLayerIndex = New List(Of Integer)

        For Each row As DataGridViewRow In LayerGrid.Rows

            SortedLayerIndex.Add(CInt(row.Cells(3).Value))

        Next

    End Sub

    Function GetParentString(ByVal l As Layer) As String

        Dim Layername As String = String.Empty

        If l.ParentLayerId <> Guid.Empty Then

            'Layername = "    " & GetParentString(getLayerById(l.ParentLayerId))
#Disable Warning BC40000 ' Type or member is obsolete
            Dim parentindex As Integer = RhinoDoc.ActiveDoc.Layers.Find(l.ParentLayerId, True)
#Enable Warning BC40000 ' Type or member is obsolete

            Dim Parentlayer As Layer = RhinoDoc.ActiveDoc.Layers.Item(parentindex)

            Layername = "    " & GetParentString(Parentlayer)

        Else

            Return Layername

        End If

        Return Layername

    End Function

    ''' <summary>
    ''' gets all Points(Coordinates) from a PolylineCurve
    ''' </summary>
    Private Function PointsFromPolyline(ByVal Polyline As PolylineCurve, ByVal ZeroPoint As Coordinate) As List(Of Coordinate)

        Dim myPoints As New List(Of Coordinate)

        For i = 1 To Polyline.PointCount - 1

            myPoints.Add(New Coordinate(Polyline.Point(i).X - ZeroPoint.X, Polyline.Point(i).Y - ZeroPoint.Y))

        Next

        Return myPoints

    End Function

    ''' <summary>
    ''' gets all Points(Coordinates) from a LineCurve
    ''' </summary>
    Private Function PointsFromLine(ByVal Line As LineCurve, ByVal ZeroPoint As Coordinate) As List(Of Coordinate)
        Dim myPoints As New List(Of Coordinate) From {
            New Coordinate(Line.PointAtEnd.X - ZeroPoint.X, Line.PointAtEnd.Y - ZeroPoint.Y)
        }

        Return myPoints

    End Function

    ''' <summary>
    ''' gets all Points(Coordinates) from a ArcCurve
    ''' </summary>
    Private Function PointsFromArc(ByVal Arc As ArcCurve, ByVal ZeroPoint As Coordinate) As List(Of Coordinate)

        Dim myPoints As List(Of Coordinate)

        Dim Points() As Point3d = Nothing

        'das divide by length kann bei sehr kleinen arc keine punkte liefern daher so wie bei den nurbs
        'Arc.DivideByLength(1, True, Points)
        Dim myDividingCount As Integer

        myDividingCount = CInt((Arc.GetLength() + 10) / 0.5)

        Arc.DivideByCount(myDividingCount, points:=Points, includeEnds:=True)

        myPoints = ToCoordinateList(Points)

        myPoints.RemoveAt(0)

        For i As Integer = 0 To myPoints.Count - 1

            myPoints(i) = CType(myPoints(i) - ZeroPoint, Coordinate)

        Next

        Return (myPoints)

    End Function

    ''' <summary>
    ''' gets all Points(Coordinates) from a NurbsCurve
    ''' </summary>
    Private Function PointsFromNurbs(ByVal Nurbs As NurbsCurve, ByVal ZeroPoint As Coordinate) As List(Of Coordinate)

        Dim myPoints As List(Of Coordinate)

        Dim Points() As Point3d = Nothing

        'das ist mist und führt mitunter zu sichtbaren fehlern daher so wie in Kais original script
        'dblLength			= Abs((Rhino.CurveLength(arrElements(j))+10)/0.5)
        Dim myDividingCount As Integer

        myDividingCount = CInt((Nurbs.GetLength() + 10) / 0.5)

        Nurbs.DivideByCount(myDividingCount, points:=Points, includeEnds:=True)

        'check if its clamped the ends
        If Nurbs.IsClosed Then

            If Points(Points.Length - 1) <> Nurbs.PointAtStart Then

                ReDim Preserve Points(Points.Length)

                Points(Points.Length - 1) = Nurbs.PointAtStart

            End If

        End If

        myPoints = ToCoordinateList(Points)

        For i As Integer = 0 To myPoints.Count - 1

            myPoints(i) = CType(myPoints(i) - ZeroPoint, Coordinate)

        Next

        Return myPoints

    End Function

    ''' <summary>
    ''' converts an array of Point3D to a List of Coordinate
    ''' </summary>
    Private Function ToCoordinateList(ByVal Points() As Point3d) As List(Of Coordinate)

        Dim myPoints As New List(Of Coordinate)

        If Points IsNot Nothing Then

            For Each p As Point3d In Points

                myPoints.Add(New Coordinate(p.X, p.Y))

            Next

        End If

        Return myPoints

    End Function

    ''' <summary>
    ''' moves the job to a new position inside the device
    ''' </summary>
    Function NewJobPosition(ByVal Device As CNC_Device, ByVal FromPoint As Coordinate) As Boolean

        'save the current position we need this if we escape
        Dim myOldMoveto As Point3d = Conduit.MoveTo

        Conduit.MoveOffset = New Point3d
        'traceline is a line between frompoint and topoint 
        Conduit.DrawTraceLine = False

        'create temporaly objects to snap on it
        Dim myBenchSnapObject As List(Of Guid)
        myBenchSnapObject = DrawBenchSnapObjects(Device)

        Conduit.StartJobMoving()

        Dim gp = New Rhino.Input.Custom.GetPoint()

        gp.SetCommandPrompt("Point to move from")

        If FromPoint Is Nothing Then

            gp.Get()

            If gp.CommandResult() <> Rhino.Commands.Result.Success Then

                Conduit.EndMoving(Purging:=True)
                'delete the snap objects
                DeleteObjects(myBenchSnapObject)

                Return False

            End If

            Conduit.MoveOffset = gp.Point

            Conduit.MoveFrom = gp.Point

            Conduit.MoveTo = New Point3d

        Else

            Conduit.MoveFrom = New Point3d(FromPoint.X, FromPoint.Y, 0)

        End If

        Conduit.DrawTraceLine = True

        Dim myFeedback As New RhMouseFeedBack With {.Conduit = Conduit, .Enabled = True}

        gp = New Rhino.Input.Custom.GetPoint()

        gp.SetCommandPrompt("Point to move to")

        gp.Get()

        myFeedback.Enabled = False

        If gp.CommandResult() <> Rhino.Commands.Result.Success Then

            Conduit.EndMoving(Purging:=True)
            'delete the snap objects
            DeleteObjects(myBenchSnapObject)

            Conduit.MoveTo = myOldMoveto

            Return False

        End If

        Dim MoveVector As New Coordinate(gp.Point.X - Conduit.MoveOffset.X, gp.Point.Y - Conduit.MoveOffset.Y)

        'the new is the old so we can escape
        If MoveVector = New Coordinate Then

            Conduit.EndMoving(Purging:=True)
            'delete the snap objects
            DeleteObjects(myBenchSnapObject)

            Conduit.MoveTo = myOldMoveto

            Return False

        End If

        Device.TransformGeometry(MoveVector)

        'delete the snap objects
        DeleteObjects(myBenchSnapObject)

        Conduit.EndMoving(Purging:=True)

        'regenerate the conduit
        Conduit.PurgeJob(withZeropoint:=False)
        CreateConduit(Device, Conduit)

        Return True

    End Function

    ''' <summary>
    ''' moves the device to a new position inside the rhinodrawing
    ''' </summary>
    Function NewZero(ByVal Device As CNC_Device, ByVal ZeroPoint As Coordinate) As Boolean
        'save the current position we need this if we escape
        Dim myOldConduitMoveTo As Point3d = New Point3d(Conduit.MoveTo)
        Dim myOldDeviceZeroPoint As Coordinate = New Coordinate(Device.ZeroPoint)
        Dim myOldConduitZeroPoint As Point3d = New Point3d(Conduit.ZeroPoint)

        Conduit.MoveOffset = New Point3d
        'traceline is a line between cursor and a geometry
        Conduit.DrawTraceLine = False

        'create temporaly objects to snap on it
        Dim myBenchSnapObject As List(Of Guid)
        myBenchSnapObject = DrawBenchSnapObjects(Device)

        Conduit.StartDeviceMoving()

        Dim gp = New Rhino.Input.Custom.GetPoint()

        'ZeroPoint is only set if the command was right mous button called
        If ZeroPoint Is Nothing Then
            gp.SetCommandPrompt("Point to move from")

            gp.Get()

            'escape before we do any movement
            If gp.CommandResult() <> Rhino.Commands.Result.Success Then

                Conduit.EndMoving(Purging:=False)
                'delete the snap objects
                DeleteObjects(myBenchSnapObject)
                Conduit.ZeroPoint = myOldConduitMoveTo
                Return False

            End If

            Conduit.MoveOffset = CType(gp.Point - Conduit.ZeroPoint, Point3d)

            Conduit.MoveFrom = gp.Point

        Else

            Conduit.MoveOffset = CType(New Point3d(ZeroPoint.X, ZeroPoint.Y, 0) - Conduit.ZeroPoint, Point3d)

            Conduit.MoveFrom = New Point3d(ZeroPoint.X, ZeroPoint.Y, 0)

        End If

        Conduit.DrawTraceLine = True

        Dim myFeedback As New RhMouseFeedBack With {.Conduit = Conduit, .Enabled = True}

        gp = New Rhino.Input.Custom.GetPoint()

        gp.SetCommandPrompt("Point to move to")

        gp.Get()

        myFeedback.Enabled = False

        Dim _newZero As New Coordinate(gp.Point.X - Conduit.MoveOffset.X, gp.Point.Y - Conduit.MoveOffset.Y)

        'if escape the command orelse the new is the old point so we have to escape
        If gp.CommandResult() <> Rhino.Commands.Result.Success OrElse Device.ZeroPoint = _newZero Then

            Device.ZeroPoint = myOldDeviceZeroPoint

            Conduit.ZeroPoint = myOldConduitZeroPoint

            Conduit.MoveTo = myOldConduitMoveTo

            'delete the snap objects
            DeleteObjects(myBenchSnapObject)
            'Device.ZeroPoint = myOldZero
            Conduit.EndMoving(Purging:=False)

            Return False

        End If

        Device.ZeroPoint = _newZero

        Conduit.ZeroPoint = CType(gp.Point - Conduit.MoveOffset, Point3d)

        'delete the snap objects
        DeleteObjects(myBenchSnapObject)

        Conduit.EndMoving(Purging:=False)

        Return True

    End Function

#Region "Process"

    ''' <summary>
    ''' length of the currently cut object while tracing
    ''' </summary>
    Public CurrentObjectLength As Double

    ''' <summary>
    ''' recently cut length
    ''' </summary>
    Private ElapsedLength As Double

    ''' <summary>
    ''' Creates the job (HPGL or G-Code) commands for the entire job
    ''' </summary>
    Public Sub CreateJobString(ByVal Device As CNC_Device,
                                ByVal PreviewWasOn As Boolean,
                                ByVal withTrace As Boolean)

        If Not PreviewWasOn Then 'preview indicates that all objects are collected and optimized

            If Device.FromFile Then
                'just switch on, no collecting nor optimization is necesssary
                PreviewOn(Device)

            Else
                'create all new
                If CollectingObjects(Device) Then

                    Optimizer.OptimizePathesWithTimeout(Device)

                    'If Device.WithBBox Then

                    '    Device.CreateBBox()

                    'End If

                    If withTrace Then

                        CreateConduit(Device, Conduit)

                        HideAllObjects()

                        RhinoDoc.ActiveDoc.Views.Redraw()

                    End If

                End If

            End If

        End If

        ShowEstimatedTime(Device)

        If Device.TotalGeometryCount > 0 Then

            'Device.GenerateHPGL()
            Device.Generate_CodeJob()

        End If

    End Sub

    ''' <summary>
    ''' shows the duration of the job based on a simulated cutting forecast
    ''' </summary>
    Function ShowEstimatedTime(ByVal Device As CNC_Device) As String

        Dim myLabelText As String

        Device.CalculateProcessTime()

        myLabelText = String.Format("{0:0}h {1:00}m", Device.ProcessTime.Hours, Device.ProcessTime.Minutes + 1)

        myLabelText &= vbCrLf & String.Format("{0:0} mm traveling", Device.TravelLength)

        myLabelText &= vbCrLf & String.Format("{0:0} mm working", Device.WorkingLength)

        ElapsedLength = 0

        Return Device.TotalGeometryCount & " objects estimated in " & myLabelText

    End Function

    ''' <summary>
    ''' the job is done
    ''' </summary>
    Function GetFinishedTime(ByVal Device As CNC_Device) As String

        Dim myLabelText As String

        myLabelText = String.Format("{0:0}:{1:00}:{2:00}",
                                    CNC_Workshop.ProcessTimer.Elapsed.Hours,
                                    CNC_Workshop.ProcessTimer.Elapsed.Minutes,
                                    CNC_Workshop.ProcessTimer.Elapsed.Seconds)

        ElapsedLength = 0

        Return Device.TotalGeometryCount & " objects was finished in " & myLabelText

    End Function

    ''' <summary>
    ''' shows the finished time based off a projection between elapsed time and following length
    ''' </summary>
    Function GetProcessingTime(ByVal Device As CNC_Device) As String

        Dim myLabelText As String

        ElapsedLength += CurrentObjectLength

        Dim myElepsMilliSec As Long = CNC_Workshop.ProcessTimer.ElapsedMilliseconds

        Dim myAvMMpMS As Double = ElapsedLength / myElepsMilliSec

        Dim myTotalTimeMS As Double = Device.WorkingLength / myAvMMpMS

        myTotalTimeMS -= myElepsMilliSec

        Dim myTotaltime As New TimeSpan

        myTotaltime = TimeSpan.FromMilliseconds(myTotalTimeMS)

        Dim myTargetTime As New Date

        myTargetTime = Date.Now

        myTargetTime += myTotaltime

        myLabelText = myTargetTime.ToLocalTime.ToShortTimeString()

        If CNC_Workshop.ProcessTimer.IsRunning Then

            Return Device.CurrentObject & " of " & Device.TotalGeometryCount & " objects finished at " & myLabelText

        End If

        Return String.Empty

    End Function

    ''' <summary>
    ''' collect all objects inside of the device bench to current device and the right tool
    ''' </summary>
    Private Function CollectingObjects(ByVal Device As CNC_Device) As Boolean
        'delete all old geometry objects
        Device.PurgeOldObjectsFromTools()

        Dim p1 As Point3d = New Point3d(Device.ZeroPoint.X, Device.ZeroPoint.Y, Double.MinValue)

        Dim p2 As Point3d = New Point3d(Device.ZeroPoint.X + Device.BenchSize.X, Device.ZeroPoint.Y + Device.BenchSize.Y, Double.MaxValue)

        ' settings.ObjectTypeFilter = CType(ObjectType.Curve + ObjectType.Point, ObjectType)
        Dim settings As New Rhino.DocObjects.ObjectEnumeratorSettings With {
            .ObjectTypeFilter = CType(ObjectType.Curve + ObjectType.Point, ObjectType),
            .ActiveObjects = True,
            .DeletedObjects = False,
            .HiddenObjects = False
        }

        Dim WorkBBox As BoundingBox = New BoundingBox(p1, p2)

        Dim ToolName As String = String.Empty

        Dim myDoc As RhinoDoc = RhinoDoc.ActiveDoc

        Dim layer_table As Tables.LayerTable = RhinoDoc.ActiveDoc.Layers

        If Device.CutByLayerOrder Then

            For Each SortLayerInd As Integer In SortedLayerIndex

                settings.LayerIndexFilter = SortLayerInd

                ToolName = layer_table(SortLayerInd).GetUserString(ToolKey)

                If Not Device.SetGeometryBlock(SortLayerInd, ToolName) Then
                    'was auch immer toolname ist, wir können nichts damit anfange
                    Continue For

                End If

                For Each obj As RhinoObject In myDoc.Objects.GetObjectList(settings)

                    Dim myBox As BoundingBox = obj.Geometry.GetBoundingBox(accurate:=True)

                    If WorkBBox.Contains(myBox, strict:=False) Then

                        Dim myToolGeometryObj As GeometryObject = RhToToolGeom(obj, Device.ZeroPoint)

                        'Device.CurrentGBlock.Geometry.Add(myToolGeometryObj)

                        Device.AddPlotObject(ToolName, myToolGeometryObj)

                    End If

                Next

            Next

        Else

            For Each obj As RhinoObject In myDoc.Objects.GetObjectList(settings)

                Dim myBox As BoundingBox = obj.Geometry.GetBoundingBox(accurate:=True)

                If WorkBBox.Contains(myBox, strict:=False) Then

                    Dim objToolName As String = myDoc.Layers(obj.Attributes.LayerIndex).GetUserString(ToolKey)

                    Dim myToolGeometryObj As GeometryObject = RhToToolGeom(obj, Device.ZeroPoint)

                    Device.AddPlotObject(objToolName, myToolGeometryObj)

                End If

            Next

        End If

        If Device.TotalGeometryCount > 0 Then

            Return True

        Else

            Return False

        End If

    End Function

    ''' <summary>
    ''' hides all object and save the object in a list for later UnHideAllObjects
    ''' </summary>
    Private Sub HideAllObjects()

        Dim myDoc As RhinoDoc = RhinoDoc.ActiveDoc

        For Each obj As RhinoObject In myDoc.Objects

            If myDoc.Objects.Hide(obj, ignoreLayerMode:=True) Then

                HiddenObjects.Add(obj)

            End If

        Next

    End Sub

    ''' <summary>
    ''' unhide previous hided objects
    ''' </summary>
    Private Sub UnHideAllObjects()

        Dim myDoc As RhinoDoc = RhinoDoc.ActiveDoc

        For Each obj As RhinoObject In HiddenObjects

            myDoc.Objects.Show(obj, True)

        Next

        HiddenObjects = New List(Of RhinoObject)

    End Sub

#End Region

    ''' <summary>
    ''' create a preview including optimazation and switched the conduit on
    ''' </summary>
    Function PreviewOn(ByVal Device As CNC_Device) As String

        If Not Device.FromFile Then
            'objekte einsammeln
            If CollectingObjects(Device) Then

                Optimizer.OptimizePathesWithTimeout(Device)

                'If Device.WithBBox Then

                '    Device.CreateBBox()

                'End If

            End If

        End If
        'alle werkzeugpfade ins conduit
        CreateConduit(Device, Conduit)
        'alle rhinoobjekte ausschalten
        HideAllObjects()

        Dim myTime As String = ShowEstimatedTime(Device)

        RhinoDoc.ActiveDoc.Views.Redraw()

        Return myTime

    End Function

    ''' <summary>
    ''' switched the preview off
    ''' </summary>
    Sub PreviewOff(Optional ByVal withRedraw As Boolean = True)
        'das cunduit leeren
        Conduit.PurgeJob(withZeropoint:=False)

        Conduit.DisableDevice()

        'alle objekte die wir ausgeblendet haben wieder einblenden
        UnHideAllObjects()

        If withRedraw Then

            RhinoDoc.ActiveDoc.Views.Redraw()

        End If

    End Sub

    ''' <summary>
    ''' creates for every job geomtry elements for the conduit
    ''' </summary>
    Private Sub CreateConduit(ByRef device As CNC_Device, ByRef conduit As RhDisplayConduit) 'As Integer

        conduit.EnableJob(device.WithReferencePoint)

        device.GetFirstGBlock()

        If device.TotalGeometryCount = 0 Then
            Exit Sub
        End If

        Do

            For Each gInd As Integer In device.CurrentGBlock.ProcessOrder

                Dim g As GeometryObject

                g = device.CurrentGBlock.Geometry(Math.Abs(gInd) - 1)

                If device.TurnDirection Then

                    If gInd < 0 Then

                        If Not g.isReverted Then

                            g.ReversPointOrder()

                        End If

                    End If

                End If

                Select Case (g.GetType)

                    Case GetType(PolyLine)

                        Dim myRhPoly As New Rhino.Geometry.Polyline

                        Dim myCNCPoly As PolyLine = CType(g, PolyLine)

                        Select Case myCNCPoly.Points.Count
                            Case Is > 1

                                For Each p As Coordinate In myCNCPoly.Points

                                    myRhPoly.Add(p.X + conduit.ZeroPoint.X,
                                                 p.Y + conduit.ZeroPoint.Y, 0)

                                Next

                                Dim myNurbs As Curve = myRhPoly.ToNurbsCurve
#If DEBUG Then
                                If myNurbs Is Nothing Then
                                    Stop
                                End If
#End If
                                conduit.FutureObjects.Add(myNurbs)

                            Case 1


                                Dim myPoint As New Rhino.Geometry.Point3d(myCNCPoly.Points(0).X + conduit.ZeroPoint.X,
                                                                          myCNCPoly.Points(0).Y + conduit.ZeroPoint.Y, 0)

                                Dim myCrv As New Rhino.Geometry.Line(myPoint, myPoint)

                                Dim myNurbs As Curve = myCrv.ToNurbsCurve
#If DEBUG Then
                                If myNurbs Is Nothing Then
                                    Stop
                                End If
#End If
                                conduit.FutureObjects.Add(myNurbs)

                            Case 0

                        End Select

                    Case GetType(Arc)

                        Dim myCNCArc As Arc = CType(g, Arc)

                        Dim myRhArc As New Rhino.Geometry.Circle(New Point3d(myCNCArc.Center.X + conduit.ZeroPoint.X,
                                                                             myCNCArc.Center.Y + conduit.ZeroPoint.Y, 0),
                                                                         myCNCArc.Radius)

                        Dim myNurbs As Curve = myRhArc.ToNurbsCurve
#If DEBUG Then
                        If myNurbs Is Nothing Then
                            Stop
                        End If
#End If
                        conduit.FutureObjects.Add(myNurbs)

                    Case GetType(Coordinate)

                        Dim myCNCCoord As Coordinate = CType(g, Coordinate)

                        Dim myPoint As New Rhino.Geometry.Point3d(myCNCCoord.X + conduit.ZeroPoint.X,
                                                                  myCNCCoord.Y + conduit.ZeroPoint.Y, 0)

                        Dim myCrv As New Rhino.Geometry.Line(myPoint, myPoint)

                        Dim myNurbs As Curve = myCrv.ToNurbsCurve
#If DEBUG Then
                        If myNurbs Is Nothing Then
                            Stop
                        End If
#End If
                        conduit.FutureObjects.Add(myNurbs)

                End Select
            Next

        Loop While device.GetNextGBlock()

    End Sub

    ''' <summary>
    ''' create an object to snap an it, because we cant snap on conduit objects
    ''' </summary>
    ''' <remarks>we delete them after moving the conduit</remarks>
    Private Function DrawBenchSnapObjects(ByVal Device As CNC_Device) As List(Of Guid)

        Dim myGUID As New List(Of Guid)

        Dim doc As Rhino.RhinoDoc = RhinoDoc.ActiveDoc

        Dim myPoints As New Rhino.Collections.RhinoList(Of Point3d) From {
            New Point3d(Device.ZeroPoint.X, Device.ZeroPoint.Y, 0),
            New Point3d(Device.ZeroPoint.X + Device.BenchSize.X - 1, Device.ZeroPoint.Y, 0),
            New Point3d(Device.ZeroPoint.X + Device.BenchSize.X - 1, Device.ZeroPoint.Y + Device.BenchSize.Y - 1, 0),
            New Point3d(Device.ZeroPoint.X, Device.ZeroPoint.Y + Device.BenchSize.Y - 1, 0)
        }

        'the first point again to close a polyline
        myPoints.Add(myPoints(0))

        Dim v As Rhino.Geometry.Vector3d = myPoints(0) - myPoints(2)

        If v.IsTiny(Rhino.RhinoMath.ZeroTolerance) Then

            Return myGUID

        End If

        'to make the same behavior as a standard element during moving
        Dim myAttr As New ObjectAttributes With {
            .ObjectColor = Rhino.ApplicationSettings.AppearanceSettings.SelectedObjectColor, ' Color.Yellow
            .ColorSource = ObjectColorSource.ColorFromObject,
            .PlotWeight = 0,
            .LayerIndex = Rhino.RhinoDoc.ActiveDoc.Layers.CurrentLayerIndex
        }

        myGUID.Add(doc.Objects.AddPolyline(myPoints, myAttr))

        myGUID.Add(doc.Objects.AddPoint(New Point3d(Device.ZeroPoint.X + Device.ReferencePoint.X,
                                                    Device.ZeroPoint.Y + Device.ReferencePoint.Y, 0), myAttr))

        Return myGUID

    End Function

    ''' <summary>
    ''' deletes a objects by his GUIDs
    ''' </summary>
    Private Sub DeleteObjects(ByVal IdsToDelete As List(Of Guid))

        If IdsToDelete.Count > 0 Then

            Dim doc As Rhino.RhinoDoc = RhinoDoc.ActiveDoc

            doc.Objects.Delete(IdsToDelete, quiet:=True)

        End If

    End Sub

    Public Function LogInfo() As String

        Dim myFileName As String

        myFileName = RhinoDoc.ActiveDoc.Path

        Dim _Ret As String = String.Empty

        If myFileName IsNot Nothing Then

            Dim myParts As String() = myFileName.Split("\"c)

            If myParts.Length > 3 Then

                _Ret = myParts(1) & vbTab & myParts(3) & vbTab & myParts(myParts.Length - 1)

            Else

                _Ret = vbTab & vbTab & myFileName

            End If

            _Ret &= vbTab & Environment.UserName

        End If

        Return _Ret

    End Function

End Class
