Imports System.Threading

Public Class OptimizerByIndex

    Dim myThread As Thread

    Private WaitHandle_Optimizer As New System.Threading.AutoResetEvent(False)

    Private Sub TimerAborter(ByVal state As Object)

        'code here will be executed when the time elapse
        myThread.Abort()

        WaitHandle_Optimizer.Set()

        Debug.Print("abort")

    End Sub

    Sub OptimizePathesWithTimeout(ByVal Device As CNC_Device)

        'at first a none optimisation to get at least a clean cut order even when we abort later the real path optimisation
        CreateProcessOrder(Device)

        OptimizePathes(Device)

    End Sub

    ''' <summary>
    ''' optimizing the path,
    ''' depending on the numbers of the geometry automaticaly a proper algorythm will by selected
    ''' </summary>
    Private Sub OptimizePathes(ByRef Device As CNC_Device)

        'setup a timeout here to call the sub callbk when the time elapse.
        'for example, something like this
        Dim SavePosition As Coordinate = Device.ToolPosition

        OptimizePathes_NearestNeighbour(Device)

        Device.ToolPosition = SavePosition

        WaitHandle_Optimizer.Set()

        Debug.Print("isOptimized")

    End Sub

#Region "No Optimization"
    ''' <summary>
    ''' this is not an optimization, it creats only a proper ProcessOrder for all geometry
    ''' </summary>
    ''' <param name="Device">the cnc_device with the collected gemotry</param>
    Public Sub CreateProcessOrder(ByVal Device As CNC_Device)

        For Each GBlock In Device.GeometryBlocks

            If GBlock.Geometry.Count > 0 Then

                CreateProcessOrder(GBlock)

            End If

        Next

    End Sub

    Private Sub CreateProcessOrder(ByRef GBlock As CNC_GeometryBlock)

        GBlock.ProcessOrder = New List(Of Integer)

        For i = 1 To GBlock.Geometry.Count

            GBlock.ProcessOrder.Add(i)

        Next

    End Sub

#End Region

#Region "NearestNeigbour"
    ''' <summary>
    ''' Nearest Neighbor implenetationn
    ''' per GeometryBlock
    ''' </summary>
    Private Sub OptimizePathes_NearestNeighbour(ByRef Device As CNC_Device)

        Device.GetFirstGBlock()

        Do

            If Device.CurrentGBlock.Geometry.Count > 0 Then

                OptimizeTool_NearestNeighbour(Device.CurrentGBlock, Device.ToolPosition)

                Two_Opt(Device.CurrentGBlock)

                Dim lastObjInd As Integer

                lastObjInd = Device.CurrentGBlock.ProcessOrder(Device.CurrentGBlock.ProcessOrder.Count - 1)

                If lastObjInd > 0 Then

                    Device.ToolPosition = Device.CurrentGBlock.Geometry(lastObjInd - 1).LastPoint

                Else

                    Device.ToolPosition = Device.CurrentGBlock.Geometry(-lastObjInd - 1).FirstPoint

                End If

            End If

        Loop While Device.GetNextGBlock

    End Sub

    ''' <summary>
    ''' tool-based nearest neighbor implementation
    ''' </summary>
    Private Sub OptimizeTool_NearestNeighbour(ByRef GBlock As CNC_GeometryBlock, ByRef startPoint As Coordinate)

        Dim myProcessOrder As New List(Of Integer)

        Dim LastPoint As Coordinate = startPoint

        While GBlock.Geometry.Count > myProcessOrder.Count

            Dim nextG As Integer = GetClosestObject(LastPoint, GBlock, myProcessOrder)

            If nextG > 0 Then

                LastPoint = GBlock.Geometry(nextG - 1).LastPoint

            Else

                LastPoint = GBlock.Geometry(-nextG - 1).FirstPoint

            End If

            myProcessOrder.Add(nextG)

        End While

        GBlock.ProcessOrder = myProcessOrder

    End Sub

    ''' <summary>
    ''' find the next closest object
    ''' </summary>
    Private Function GetClosestObject(ByRef point As Coordinate, ByRef GBlock As CNC_GeometryBlock, ByVal PreliminaryProcessorder As List(Of Integer)) As Integer

        Dim closestG As Integer

        Dim closestDistance As Double = Double.PositiveInfinity

        Dim Revers As Boolean = False

        For gi = 1 To GBlock.Geometry.Count

            If Not PreliminaryProcessorder.Contains(gi) And
                Not PreliminaryProcessorder.Contains(-gi) Then

                Dim Dist2First As Double = Double.PositiveInfinity

                Dist2First = point.DistanceTo(GBlock.Geometry(gi - 1).FirstPoint)

                If closestDistance > Dist2First Then

                    closestDistance = Dist2First

                    Revers = False

                    closestG = gi

                End If

                Dim Dist2Last As Double = Double.PositiveInfinity

                Dist2Last = point.DistanceTo(GBlock.Geometry(gi - 1).LastPoint)

                If closestDistance > Dist2Last Then

                    closestDistance = Dist2Last

                    Revers = True

                    closestG = gi

                End If

            End If

        Next

        If Revers Then

            closestG = -closestG

        End If

        Return closestG

    End Function

#End Region

#Region "2 opt Heuristik"

    ''' <summary>
    ''' eine schlichte Optimierung zum entflechten von Kreuzungen in den Leerfahrten
    ''' </summary>
    Private Sub Two_Opt(ByRef GBlock As CNC_GeometryBlock) 'As List(Of GeometryObject)
        ' - A   C -         - A - C -
        '     X       ==>     
        ' - D   B -         - D - B -

        Dim again As Boolean = False

        Dim A, B, C, D As Coordinate

        Dim LineAB, LineCD, LineAC, LineDB As PolyLine

        Dim myProcessOrder As New List(Of Integer)(GBlock.ProcessOrder)

        Do

            again = False

            For i = 1 To GBlock.Geometry.Count - 3

                For j = i + 2 To GBlock.Geometry.Count - 2

                    If myProcessOrder(i) > 0 Then

                        A = New Coordinate(GBlock.Geometry(myProcessOrder(i) - 1).LastPoint)

                    Else

                        A = New Coordinate(GBlock.Geometry(-myProcessOrder(i) - 1).FirstPoint)

                    End If

                    If myProcessOrder(i + 1) > 0 Then

                        B = New Coordinate(GBlock.Geometry(myProcessOrder(i + 1) - 1).FirstPoint)

                    Else

                        B = New Coordinate(GBlock.Geometry(-myProcessOrder(i + 1) - 1).LastPoint)

                    End If

                    If myProcessOrder(j) > 0 Then

                        C = New Coordinate(GBlock.Geometry(myProcessOrder(j) - 1).LastPoint)

                    Else

                        C = New Coordinate(GBlock.Geometry(-myProcessOrder(j) - 1).FirstPoint)

                    End If

                    If myProcessOrder(j + 1) > 0 Then

                        D = New Coordinate(GBlock.Geometry(myProcessOrder(j + 1) - 1).FirstPoint)

                    Else

                        D = New Coordinate(GBlock.Geometry(-myProcessOrder(j + 1) - 1).LastPoint)

                    End If

                    LineAB = New PolyLine(A, B)

                    LineCD = New PolyLine(C, D)

                    LineAC = New PolyLine(A, C)

                    LineDB = New PolyLine(D, B)

                    Dim ABCD As Double
                    Dim ACDB As Double

                    ABCD = LineAB.Length + LineCD.Length
                    ACDB = LineAC.Length + LineDB.Length

                    If ABCD > ACDB Then

                        If ACDB > 0 Then

                            TurnDirection(myProcessOrder, Math.Min(i, j) + 1, Math.Abs(i - j))

                            again = True

                        End If

                    End If

                Next

            Next

        Loop While again

        For i = 1 To GBlock.Geometry.Count - 2

            If myProcessOrder(i) > 0 Then

                A = New Coordinate(GBlock.Geometry(myProcessOrder(i) - 1).LastPoint)

            Else

                A = New Coordinate(GBlock.Geometry(-myProcessOrder(i) - 1).FirstPoint)

            End If

            If myProcessOrder(i + 1) > 0 Then

                B = New Coordinate(GBlock.Geometry(myProcessOrder(i + 1) - 1).FirstPoint)

            Else

                B = New Coordinate(GBlock.Geometry(-myProcessOrder(i + 1) - 1).LastPoint)

            End If

            If myProcessOrder(i - 1) > 0 Then

                C = New Coordinate(GBlock.Geometry(myProcessOrder(i - 1) - 1).LastPoint)

            Else

                C = New Coordinate(GBlock.Geometry(-myProcessOrder(i - 1) - 1).FirstPoint)

            End If

            If myProcessOrder(i) > 0 Then

                D = New Coordinate(GBlock.Geometry(myProcessOrder(i) - 1).FirstPoint)

            Else

                D = New Coordinate(GBlock.Geometry(-myProcessOrder(i) - 1).LastPoint)

            End If

            LineAB = New PolyLine(A, B)

            LineCD = New PolyLine(C, D)

            LineAC = New PolyLine(A, C)

            LineDB = New PolyLine(D, B)

            If ((LineAB.Length + LineCD.Length) > (LineAC.Length + LineDB.Length)) AndAlso (LineAC.Length + LineDB.Length) > 0 Then

                TurnDirection(myProcessOrder, i, 1)

                again = True

                i = 1
            End If

        Next

        'evtl. nochmal den letzten drehen?
        If GBlock.Geometry.Count > 2 Then
            'vorletztes object - letzter punkt
            If myProcessOrder(myProcessOrder.Count - 2) > 0 Then

                A = New Coordinate(GBlock.Geometry(myProcessOrder(myProcessOrder.Count - 2) - 1).LastPoint)

            Else

                A = New Coordinate(GBlock.Geometry(-myProcessOrder(myProcessOrder.Count - 2) - 1).FirstPoint)

            End If

            If myProcessOrder(myProcessOrder.Count - 1) > 0 Then
                'last object - first point 
                B = New Coordinate(GBlock.Geometry(myProcessOrder(myProcessOrder.Count - 1) - 1).FirstPoint)
                C = New Coordinate(GBlock.Geometry(myProcessOrder(myProcessOrder.Count - 1) - 1).LastPoint)

            Else
                'last object - end point 
                B = New Coordinate(GBlock.Geometry(-myProcessOrder(myProcessOrder.Count - 1) - 1).LastPoint)
                C = New Coordinate(GBlock.Geometry(-myProcessOrder(myProcessOrder.Count - 1) - 1).FirstPoint)

            End If

            LineAB = New PolyLine(A, B)
            LineAC = New PolyLine(A, C)

            If LineAC.Length < LineAB.Length Then
                myProcessOrder(myProcessOrder.Count - 1) *= -1
            End If

        End If

        GBlock.ProcessOrder = myProcessOrder

    End Sub

    Private Sub TurnDirection(ByRef Order As List(Of Integer), ByRef start As Integer, ByRef length As Integer)

        Dim myRange As List(Of Integer) = Order.GetRange(start, length)

        myRange.Reverse()

        For i = 0 To myRange.Count - 1
            myRange(i) = -myRange(i)
        Next

        Order.RemoveRange(start, myRange.Count)

        Order.InsertRange(start, myRange)

    End Sub

#End Region

End Class
