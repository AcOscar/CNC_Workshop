Imports System.Collections.Generic

Public Class OptimizerByIndex

    Public Property OptimizingStyle As PathOptimzing

    Enum PathOptimzing
        none

        byX

        NearestNeighbour

        NearestNeighbourPlus

        FarthestInsertion

        FarthestInsertionPlus

    End Enum

    Enum LastPositionStyle

        Last

        Start

        Parking

    End Enum

    Property LastPosition As LastPositionStyle

    Public Sub OptimizePathes(ByRef Device As CNC_Device)

        If Device.TotalGeometryCount > 10000 Then

            OptimizePathes_None(Device)

        Else

            Select Case OptimizingStyle

                Case PathOptimzing.byX

                    OptimizePathes_ByX(Device)

                Case PathOptimzing.NearestNeighbour

                    OptimizePathes_NearestNeighbour(Device, False)

                Case PathOptimzing.NearestNeighbourPlus


                    OptimizePathes_NearestNeighbour(Device, True)

                Case PathOptimzing.FarthestInsertion 'none

                    OptimizePathes_FarthestInsertion(Device, False)

                Case PathOptimzing.FarthestInsertionPlus

                    OptimizePathes_FarthestInsertion(Device, True)

                Case PathOptimzing.none 'none

                    OptimizePathes_None(Device)

            End Select

        End If

        Device.isOptimized = True

    End Sub

#Region "No Optimization"

    Private Sub OptimizePathes_None(ByVal Device As CNC_Device)

        For Each t In Device.Tools

            If t.Geometry.Count > 0 Then

                optimizeTool_None(t)

                t.ReorderGeometry()

            End If

        Next

    End Sub

    Private Sub optimizeTool_None(ByRef Tool As CNC_Tool)

        Tool.ProcessOrder = New List(Of Integer)

        For i = 1 To Tool.Geometry.Count

            Tool.ProcessOrder.Add(i)

        Next

    End Sub

#End Region

#Region "NearestNeigbour"

    ''' <summary>
    ''' Nearest Neighbor implenetationn
    ''' per tool
    ''' </summary>
    Private Sub OptimizePathes_NearestNeighbour(ByRef Device As CNC_Device, ByRef withPostOptimiztation As Boolean)

        Dim LastToolLocation As Coordinate

        LastToolLocation = Device.CurTool.Location

        For Each t In Device.Tools

            If t.Geometry.Count > 0 Then

                optimizeTool_NearestNeighbour(t, LastToolLocation)

                If withPostOptimiztation Then

                    two_Opt(t)
                    'two_Opt2(t)

                End If

                'End If

                'If t.Geometry.Count > 0 Then

                Dim lastObjInd As Integer

                lastObjInd = t.ProcessOrder(t.ProcessOrder.Count - 1)


                If lastObjInd > 0 Then

                    LastToolLocation = t.Geometry(lastObjInd - 1).LastPoint

                Else

                    LastToolLocation = t.Geometry(-lastObjInd - 1).FirstPoint

                End If

                t.ReorderGeometry()

            End If

        Next

    End Sub

    ''' <summary>
    ''' tool-based nearest neighbor implementation
    ''' </summary>
    Private Sub optimizeTool_NearestNeighbour(ByRef Tool As CNC_Tool, ByRef startPoint As Coordinate)

        Tool.ProcessOrder = New List(Of Integer)

        Dim LastPoint As Coordinate = startPoint

        While Tool.Geometry.Count > Tool.ProcessOrder.Count

            Dim nextG As Integer = getClosestObject(LastPoint, Tool)

            If nextG > 0 Then

                LastPoint = Tool.Geometry(nextG - 1).LastPoint

            Else

                LastPoint = Tool.Geometry(-nextG - 1).FirstPoint

            End If

            Tool.ProcessOrder.Add(nextG)

        End While

    End Sub

    ''' <summary>
    ''' sucht das nächste Objekt
    ''' </summary>
    ''' <param name="point"></param>
    ''' <param name="Tool"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getClosestObject(ByRef point As Coordinate, ByRef Tool As CNC_Tool) As Integer

        Dim closestG As Integer

        Dim closestDistance As Double = Double.PositiveInfinity

        Dim Revers As Boolean = False

        For gi = 1 To Tool.Geometry.Count

            If Not Tool.ProcessOrder.Contains(gi) And _
                 Not Tool.ProcessOrder.Contains(-gi) Then

                Dim Dist2First As Double = Double.PositiveInfinity

                Dist2First = point.DistanceTo(Tool.Geometry(gi - 1).FirstPoint)


                If closestDistance > Dist2First Then

                    closestDistance = Dist2First

                    Revers = False

                    closestG = gi

                End If

                Dim Dist2Last As Double = Double.PositiveInfinity

                Dist2Last = point.DistanceTo(Tool.Geometry(gi - 1).LastPoint)

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

#Region "SortByX"

    Private Sub OptimizePathes_ByX(ByRef Device As CNC_Device)

        For Each t In Device.Tools

            If t.Geometry.Count > 1 Then

                optimizeTool_SortX(t)

                t.ReorderGeometry()

            End If
        Next

    End Sub

    Private Sub optimizeTool_SortX(ByRef Tool As CNC_Tool)

        Dim vtemp

        optimizeTool_None(Tool)

        For j = Tool.Geometry.Count To 1 Step -1

            ' Alle links davon liegenden Zeichen auf richtige Sortierung 
            ' der jeweiligen Nachfolger überprüfen: 
            For i = 1 To j

                ' Ist das aktuelle Element seinem Nachfolger gegenüber korrekt sortiert? 
                Dim x1, x2 As Double

                If Tool.ProcessOrder(i - 1) > 0 Then

                    x1 = Tool.Geometry(Tool.ProcessOrder(i - 1) - 1).FirstPoint.X

                Else

                    x1 = Tool.Geometry(-Tool.ProcessOrder(i - 1) - 1).LastPoint.X

                End If


                If Tool.ProcessOrder(j - 1) > 0 Then

                    x2 = Tool.Geometry(Tool.ProcessOrder(j - 1) - 1).FirstPoint.X
                Else

                    x2 = Tool.Geometry(-Tool.ProcessOrder(j - 1) - 1).LastPoint.X

                End If

                If x1 > x2 Then

                    ' Element und seinen Nachfolger vertauschen. 
                    vtemp = Tool.ProcessOrder(i - 1)

                    Tool.ProcessOrder(i - 1) = Tool.ProcessOrder(j - 1)

                    Tool.ProcessOrder(j - 1) = vtemp

                End If

            Next i

        Next j

    End Sub

#End Region

#Region "FarthestInsertion"

    Private Sub OptimizePathes_FarthestInsertion(ByRef Device As CNC_Device, ByRef withPostOptimiztation As Boolean)

        Dim LastToolLocation As Coordinate

        LastToolLocation = Device.CurTool.Location

        For Each t In Device.Tools

            If t.Geometry.Count > 0 Then

                optimizeTool_FarthestInsertion(t, LastToolLocation)

                If withPostOptimiztation Then

                    two_Opt(t)
                    ' two_Opt2(t)

                End If

            End If

            If t.Geometry.Count > 0 Then

                Dim lastObjInd As Integer

                lastObjInd = t.ProcessOrder(t.ProcessOrder.Count - 1)


                If lastObjInd > 0 Then

                    LastToolLocation = t.Geometry(lastObjInd - 1).LastPoint

                Else

                    LastToolLocation = t.Geometry(-lastObjInd - 1).FirstPoint

                End If
            End If

            t.ReorderGeometry()

        Next

    End Sub

    Private Sub optimizeTool_FarthestInsertion(ByRef Tool As CNC_Tool, ByRef startPoint As Coordinate)
        Dim LookForward As Boolean = True
        Tool.ProcessOrder = New List(Of Integer)
        Dim buttumcounter As Integer
        Dim topcounter As Integer
        Dim LastPoint As Coordinate = startPoint

        Dim FirstG As Integer = getClosestObject(LastPoint, Tool)

        If FirstG > 0 Then

            LastPoint = Tool.Geometry(FirstG - 1).LastPoint

        Else

            LastPoint = Tool.Geometry(-FirstG - 1).FirstPoint

        End If

        Tool.ProcessOrder.Add(FirstG)

        While Tool.Geometry.Count > Tool.ProcessOrder.Count

            Dim nextG As Integer = getFarthestObject(LastPoint, Tool)

            If nextG > 0 Then

                '    LastPoint = Tool.Geometry(nextG - 1).LastPoint

                'Else

                '    LastPoint = Tool.Geometry(-nextG - 1).FirstPoint
                LastPoint = Tool.Geometry(nextG - 1).FirstPoint

            Else

                LastPoint = Tool.Geometry(-nextG - 1).LastPoint

            End If

            If LookForward Then

                Tool.ProcessOrder.Insert(buttumcounter + 1, nextG)

                buttumcounter += 1

            Else

                Tool.ProcessOrder.Insert(Tool.ProcessOrder.Count - 1 - topcounter, nextG)

                topcounter += 1

            End If

            LookForward = Not LookForward

        End While

    End Sub

    Private Function getFarthestObject(ByRef Point As Coordinate, ByRef Tool As CNC_Tool) As Integer

        Dim farthestInd As Integer

        Dim farthestDistance As Double = Double.NegativeInfinity

        Dim Revers As Boolean = False

        For gi = 1 To Tool.Geometry.Count

            If Not Tool.ProcessOrder.Contains(gi) And _
                 Not Tool.ProcessOrder.Contains(-gi) Then

                Dim Dist2First As Double = Double.PositiveInfinity

                Dist2First = Point.DistanceTo(Tool.Geometry(gi - 1).FirstPoint)

                If farthestDistance < Dist2First Then

                    farthestDistance = Dist2First

                    Revers = False

                    farthestInd = gi

                End If

                Dim Dist2Last As Double = Double.PositiveInfinity

                Dist2Last = Point.DistanceTo(Tool.Geometry(gi - 1).LastPoint)

                If farthestDistance < Dist2Last Then

                    farthestDistance = Dist2Last

                    Revers = True

                    farthestInd = gi

                End If

            End If

        Next

        If Revers Then

            farthestInd = -farthestInd

        End If

        Return farthestInd

    End Function

#End Region

#Region "2 opt Heuristik"

    ''' <summary>
    ''' eine schlichte Optimierung zum entflechten von Kreuzungen in den Leerfahrten
    ''' </summary>
    Private Sub two_Opt(ByRef Tool As CNC_Tool) 'As List(Of GeometryObject)
        ' - A   C -         - A - C -
        '     X       ==>     
        ' - D   B -         - D - B -

        Dim again As Boolean = False

        Dim A, B, C, D As Coordinate

        Dim LineAB, LineCD, LineAC, LineDB As Line

        Do

            again = False

            For i = 1 To Tool.Geometry.Count - 3

                For j = i + 2 To Tool.Geometry.Count - 2

                    If Tool.ProcessOrder(i) > 0 Then

                        A = New Coordinate(Tool.Geometry(Tool.ProcessOrder(i) - 1).LastPoint)

                    Else

                        A = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(i) - 1).FirstPoint)

                    End If

                    If Tool.ProcessOrder(i + 1) > 0 Then

                        B = New Coordinate(Tool.Geometry(Tool.ProcessOrder(i + 1) - 1).FirstPoint)

                    Else

                        B = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(i + 1) - 1).LastPoint)

                    End If

                    If Tool.ProcessOrder(j) > 0 Then

                        C = New Coordinate(Tool.Geometry(Tool.ProcessOrder(j) - 1).LastPoint)

                    Else

                        C = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(j) - 1).FirstPoint)

                    End If

                    If Tool.ProcessOrder(j + 1) > 0 Then

                        D = New Coordinate(Tool.Geometry(Tool.ProcessOrder(j + 1) - 1).FirstPoint)

                    Else

                        D = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(j + 1) - 1).LastPoint)

                    End If

                    LineAB = New Line(A, B)

                    LineCD = New Line(C, D)

                    LineAC = New Line(A, C)

                    LineDB = New Line(D, B)

                    Dim ABCD As Double
                    Dim ACDB As Double

                    ABCD = LineAB.Length + LineCD.Length
                    ACDB = LineAC.Length + LineDB.Length

                    If ABCD > ACDB Then

                        If ACDB > 0 Then

                            turnDirection(Tool.ProcessOrder, Math.Min(i, j) + 1, Math.Abs(i - j))

                            again = True

                        End If

                    End If

                Next

            Next

        Loop While again

        For i = 1 To Tool.Geometry.Count - 2

            If Tool.ProcessOrder(i) > 0 Then

                A = New Coordinate(Tool.Geometry(Tool.ProcessOrder(i) - 1).LastPoint)

            Else

                A = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(i) - 1).FirstPoint)

            End If

            If Tool.ProcessOrder(i + 1) > 0 Then

                B = New Coordinate(Tool.Geometry(Tool.ProcessOrder(i + 1) - 1).FirstPoint)

            Else

                B = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(i + 1) - 1).LastPoint)

            End If

            If Tool.ProcessOrder(i - 1) > 0 Then

                C = New Coordinate(Tool.Geometry(Tool.ProcessOrder(i - 1) - 1).LastPoint)

            Else

                C = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(i - 1) - 1).FirstPoint)

            End If

            If Tool.ProcessOrder(i) > 0 Then

                D = New Coordinate(Tool.Geometry(Tool.ProcessOrder(i) - 1).FirstPoint)

            Else

                D = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(i) - 1).LastPoint)

            End If

            LineAB = New Line(A, B)

            LineCD = New Line(C, D)

            LineAC = New Line(A, C)

            LineDB = New Line(D, B)

            If ((LineAB.Length + LineCD.Length) > (LineAC.Length + LineDB.Length)) AndAlso (LineAC.Length + LineDB.Length) > 0 Then

                turnDirection(Tool.ProcessOrder, i, 1)

                again = True

                i = 1
            End If

        Next

        'evtl. nochmal den letzten drehen?
        If Tool.Geometry.Count > 2 Then
            'vorletztes object - letzter punkt
            If Tool.ProcessOrder(Tool.ProcessOrder.Count - 2) > 0 Then

                A = New Coordinate(Tool.Geometry(Tool.ProcessOrder(Tool.ProcessOrder.Count - 2) - 1).LastPoint)

            Else

                A = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(Tool.ProcessOrder.Count - 2) - 1).FirstPoint)

            End If

            If Tool.ProcessOrder(Tool.ProcessOrder.Count - 1) > 0 Then
                'last object - first point 
                B = New Coordinate(Tool.Geometry(Tool.ProcessOrder(Tool.ProcessOrder.Count - 1) - 1).FirstPoint)
                C = New Coordinate(Tool.Geometry(Tool.ProcessOrder(Tool.ProcessOrder.Count - 1) - 1).LastPoint)

            Else
                'last object - end point 
                B = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(Tool.ProcessOrder.Count - 1) - 1).LastPoint)
                C = New Coordinate(Tool.Geometry(-Tool.ProcessOrder(Tool.ProcessOrder.Count - 1) - 1).FirstPoint)

            End If

            LineAB = New Line(A, B)
            LineAC = New Line(A, C)

            If LineAC.Length < LineAB.Length Then
                Tool.ProcessOrder(Tool.ProcessOrder.Count - 1) *= -1
            End If

        End If

    End Sub


    Private Sub two_Opt2(ByRef Tool As CNC_Tool)

        'repeat until no improvement is made {
        '    start_again:
        '    best_distance = calculateTotalDistance(existing_route)
        '    for (i = 0; i < number of nodes eligible to be swapped - 1; i++) {
        '        for (k = i + 1; k < number of nodes eligible to be swapped; k++) {
        '            new_route = 2optSwap(existing_route, i, k)
        '            new_distance = calculateTotalDistance(new_route)
        '            if (new_distance < best_distance) {
        '                existing_route = new_route
        '                goto start_again
        '            }
        '        }
        '    }
        '}

        Dim existing_route As List(Of Integer) = Tool.ProcessOrder

        Dim noImprovement As Boolean = False

        Dim best_distance, new_distance As Double

        Do Until noImprovement

            best_distance = calculateTotalDistance(Tool, existing_route)

            For i As Integer = 0 To Tool.Geometry.Count - 2

                For k = i + 1 To Tool.Geometry.Count - 1

                    Dim new_route As List(Of Integer) = TwoOptSwap(existing_route, i, k)

                    new_distance = calculateTotalDistance(Tool, new_route)

                    If new_distance < best_distance Then

                        existing_route = new_route

                        noImprovement = False

                        Continue Do

                    End If

                Next

            Next

            noImprovement = True

        Loop

        Tool.ProcessOrder = existing_route

    End Sub


    Private Sub turnDirection(ByRef Order As List(Of Integer), ByRef start As Integer, ByRef length As Integer)

        Dim myRange As List(Of Integer) = Order.GetRange(start, length)

        myRange.Reverse()

        For i = 0 To myRange.Count - 1
            myRange(i) = -myRange(i)
        Next

        Order.RemoveRange(start, myRange.Count)

        Order.InsertRange(start, myRange)

    End Sub

#End Region

    Private Function calculateTotalDistance(ByVal Tool As CNC_Tool, ByVal Route As List(Of Integer)) As Double

        Dim myLength As Double = 0

        For i As Integer = 0 To Tool.Geometry.Count - 2

            Dim FirstOLastP, SecondOFirstP As Coordinate

            FirstOLastP = Tool.Geometry(Math.Abs(Route(i)) - 1).GetLast(Math.Abs(Route(i)) - 1)
            SecondOFirstP = Tool.Geometry(Math.Abs(Route(i + 1)) - 1).GetFirst(Math.Abs(Route(i + 1)) - 1)

            Dim Line As New Line(FirstOLastP, SecondOFirstP)

            myLength += Line.Length

        Next

        Return myLength

    End Function

    Private Function TwoOptSwap(ByVal existing_route As List(Of Integer), ByVal i As Integer, ByVal k As Integer) As List(Of Integer)

        Dim swaped_route As New List(Of Integer)

        swaped_route.AddRange(existing_route.GetRange(0, i))

        Dim swapPart As List(Of Integer) = existing_route.GetRange(i, k - i)

        swapPart.Reverse()

        For j As Integer = 0 To swapPart.Count - 1

            swapPart(j) = -swapPart(j)

        Next

        swaped_route.AddRange(swapPart)

        swaped_route.AddRange(existing_route.GetRange(k, existing_route.Count - k))

        Return swaped_route

    End Function

End Class

