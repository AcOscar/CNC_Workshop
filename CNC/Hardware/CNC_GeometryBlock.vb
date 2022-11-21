''' <summary>
''' 
''' </summary>
Public Class CNC_GeometryBlock

    ''' <summary>
    ''' the reference to the parent device
    ''' </summary>
    Private Device As CNC_Device

    Public Tool As CNC_Tool

    Public LayerKey As Integer

    ''' <summary>
    ''' the length auf all empty pathes
    ''' </summary>
    Public TravelLength As Double

    ''' <summary>
    ''' die Geomtry die die bearbeitet werden muss 
    ''' </summary>
    Property Geometry As List(Of GeometryObject)

    ''' <summary>
    ''' Reihenfolge in der gearbeitet wird
    ''' </summary>
    ''' <remarks>1-based, negative werte zeigen umgekehrte schnittrichtung an</remarks>
    Public ProcessOrder As New List(Of Integer)

    Sub New(ByVal newLayerKey As Integer, ByRef newTool As CNC_Tool, ByRef newDevice As CNC_Device)

        Device = newDevice

        LayerKey = newLayerKey

        Tool = newTool

        Geometry = New List(Of GeometryObject)

    End Sub

    ''' <summary>
    ''' calculate the estimated time to work with all geometry inside this geometry block
    ''' </summary>
    Sub CalculateProcessTime(ByVal Spawn As TimeSpan)

        TravelLength = 0

        For i = 1 To Me.ProcessOrder.Count - 1

            Dim myToGeometry As GeometryObject

            myToGeometry = Me.Geometry(Math.Abs(Me.ProcessOrder(i)) - 1)

            Dim myLength As Double

            myLength = myToGeometry.Length

            Dim myInterroptions As Integer

            myInterroptions = GetInteruptions(myToGeometry)

            Dim myTravelDistance As Double

            Dim myToPpoint As Coordinate

            If Me.ProcessOrder(i) < 0 Then

                myToPpoint = myToGeometry.LastPoint

            Else

                myToPpoint = myToGeometry.FirstPoint

            End If

            If i > 1 Then

                Dim myFromGeometry As GeometryObject

                myFromGeometry = Me.Geometry(Math.Abs(Me.ProcessOrder(i - 1)) - 1)

                Dim myFromPpoint As Coordinate

                If Me.ProcessOrder(i - 1) < 0 Then

                    myFromPpoint = myFromGeometry.FirstPoint

                Else

                    myFromPpoint = myFromGeometry.LastPoint

                End If

                myTravelDistance = myFromPpoint.DistanceTo(myToPpoint)

            End If

            TravelLength += myTravelDistance

            Spawn += GetTime4Travel(myTravelDistance)

            Spawn += GetTime4Work(myLength)

            Spawn += GetTime4Interruptions(myInterroptions)

        Next

    End Sub

    ''' <summary>
    ''' calculates the time for all working pathes
    ''' </summary>
    ''' <remarks>curently all pathes at once and not path by path</remarks>
    Private Function GetTime4Work(ByVal Distance As Double) As TimeSpan
        'LATER: getTime4Work path by path and not all pathes at once
        Dim myTime As New TimeSpan

        myTime = GetTime(Distance, Tool.GetProperty("speeddown").Value, Tool.DownAcceleration)

        Return myTime

    End Function

    ''' <summary>
    ''' calculates the time for interuptions
    ''' </summary>
    Private Function GetTime4Interruptions(ByVal myInterroptions As Integer) As TimeSpan

        Dim myinteruptions As Long = CLng(Tool.GetProperty("interuptiontime").Value * myInterroptions * 10000)

        Dim myTime As New TimeSpan(myinteruptions)

        Return myTime

    End Function

    ''' <summary>
    ''' calculates the time for traveling
    ''' </summary>
    Private Function GetTime4Travel(ByVal Distance As Double) As TimeSpan
        'LATER: getTime4Work path by path and not all pathes at once
        Dim myTime As New TimeSpan

        myTime = GetTime(Distance, Tool.GetProperty("speeddown").Value, Tool.UpAcceleration)

        Return myTime

    End Function

    Private Function GetInteruptions(ByVal Geometry As GeometryObject) As Integer
        'LATER: getInteruptions
        Return 1

    End Function

    ''' <summary>
    ''' generates the HPGL code from all geometry from this geometry block and put them into the Device.JobBuffer
    ''' </summary>
    ''' <param name="turnDirection"></param>
    Sub GenerateCode(ByVal turnDirection As Boolean)

        If Geometry Is Nothing Then

            Exit Sub

        End If

        For Each gInd As Integer In ProcessOrder

            Dim g As GeometryObject

            g = Geometry(Math.Abs(gInd) - 1)

            Curtool_ObjectBegin(g)

            If turnDirection Then

                If gInd < 0 Then

                    If Not g.isReverted Then

                        g.ReversPointOrder()

                    End If

                End If

            End If

            If Device.Language = "GCODEM3" Then

                Device.JobBuffer.Append(g.GC3(CInt(Device.Factor), Device.Digits))

            Else
                Device.JobBuffer.Append(g.HPGL(CInt(Device.Factor)))

            End If

        Next

    End Sub

    ''' <summary>
    ''' the begin of a geometry object
    ''' </summary>
    Private Sub Curtool_ObjectBegin(ByRef GeomObj As GeometryObject)
        Device.CounterItem += 1

        If Me.Device.Language = "HPGL" Then

            Device.JobBuffer.Append("JB" & Device.CounterItem & ";")


            If LayerKey > Integer.MinValue Then

                Dim myPercent As Integer

                'only if we cut one point
                If Device.WorkingLength > 0 Then

                    myPercent = CInt(CLng(Device.CounterLength * 100) \ CLng(Device.WorkingLength))
                Else

                    myPercent = 0

                End If

                Dim myDisplayText As String = myPercent & " %" ' myPercent & "% of " & Device.EstimatenTotalMinutes & " min"

                Device.JobBuffer.Append("XX12,2;MS" & myDisplayText & ";")

                Device.CounterLength += GeomObj.Length

            Else

                'todo: BBOX
                Device.JobBuffer.Append("XX12,2;MSBounding Box;")

            End If
        End If

    End Sub

    ''' <summary>
    ''' moves all geometry
    ''' </summary>
    ''' <param name="MoveVector">this is the To point for the move transformation, the From point is 0,0</param>
    Sub TransformGeometry(ByVal MoveVector As Coordinate)

        If Me.Geometry.Count > 0 Then

            For Each g As GeometryObject In Me.Geometry

                g.Transform(MoveVector)

            Next

        End If

    End Sub

    ''' <summary>
    ''' the total length of all geometries
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property WorkingLength As Double
        Get
            Dim _ret As Double

            For Each g As GeometryObject In Geometry

                _ret += g.Length

            Next

            Return _ret

        End Get
    End Property

    ''' <summary>
    ''' calculates the time for a distance by recognizing speed and acceloration
    ''' </summary>
    ''' <param name="Distance">in mm</param>
    ''' <param name="Speed">in cm/s</param>
    ''' <param name="Acceleration">given in Plotter units, get get 1 to 4</param>
    Private Function GetTime(ByVal Distance As Double, ByVal Speed As Double, ByVal Acceleration As Integer) As TimeSpan

        Dim myTime As TimeSpan

        Dim _acceleration As Double

        Select Case Acceleration
            Case 1
                _acceleration = 125

            Case 2
                _acceleration = 250

            Case 3
                _acceleration = 500

            Case 4
                _acceleration = 1000

            Case Else
                _acceleration = 0

        End Select

        If _acceleration <> 0 Then

            'TimeToFullSpeed
            Dim T2FS As TimeSpan
            'T2FS = TimeSpan.FromSeconds((SpeedDown * 10) / (_acceleration * 10))
            T2FS = TimeSpan.FromSeconds((Speed * 10) / _acceleration)
            'Distance to FullSpeed
            Dim D2FS As Double

            D2FS = 0.5 * _acceleration * (T2FS.TotalSeconds) ^ 2

            If Distance > D2FS Then

                myTime = TimeSpan.FromSeconds((Distance - D2FS) / (Speed * 10))

                myTime += T2FS

            Else

                myTime = TimeSpan.FromSeconds(Math.Sqrt(2 * Distance / _acceleration))

            End If

        Else

            myTime = TimeSpan.FromSeconds(Distance / (Speed * 10))

        End If

        Return myTime

    End Function

    ''' <summary>
    ''' returns the bottom right corner
    ''' </summary>
    ''' <remarks>make sure thats SetExtends was called before</remarks>
    ReadOnly Property Min As Coordinate

        Get

            Return New Coordinate(MinX, MinY)

        End Get

    End Property

    ''' <summary>
    ''' returns the top left corner
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property Max As Coordinate

        Get

            Return New Coordinate(MaxX, MaxY)

        End Get

    End Property

    Private MinX As Double = Double.MaxValue

    Private MinY As Double = Double.MaxValue

    Private MaxX As Double = Double.MinValue

    Private MaxY As Double = Double.MinValue

    ''' <summary>
    ''' calculate the gemoetrically extends 
    ''' </summary>
    Sub SetExtends(ByVal Gobject As GeometryObject)

        MinX = Math.Min(MinX, Gobject.minPoint.X)

        MinY = Math.Min(MinY, Gobject.minPoint.Y)

        MaxX = Math.Max(MaxX, Gobject.maxPoint.X)

        MaxY = Math.Max(MaxY, Gobject.maxPoint.Y)

    End Sub

End Class
