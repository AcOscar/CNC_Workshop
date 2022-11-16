Imports System.Collections.Generic

Public Class Optimizer

    Public Property Optimizing As PathOptimzing

    Enum PathOptimzing
        none

        byX

        NearestNeighbour

        NearestNeighbourPlus

        FarthestInsertion

        FarthestInsertionPlus

        CheapestInsertion

        CheapestInsertionPlus

    End Enum

    Public Sub OptimizePathes(ByRef Device As CNC_Device)

        Select Case Optimizing

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

            Case PathOptimzing.CheapestInsertion

                OptimizePathes_CheapestInsertion(Device, False)

            Case PathOptimzing.CheapestInsertionPlus

                OptimizePathes_CheapestInsertion(Device, True)

            Case PathOptimzing.none 'none

        End Select


    End Sub

    'Public Function OptimizePathesWithBest(ByRef Device As CNC_Device, ByRef Style As String) As TimeSpan

    '    Dim myDummyDevice As New CNC_Device

    '    Dim bestTime As New TimeSpan(0)

    '    Dim tnn As TimeSpan = New TimeSpan(0)

    '    Dim tci As TimeSpan = New TimeSpan(0)

    '    'byx
    '    myDummyDevice = Device.Clone

    '    OptimizePathes_ByX(Device)

    '    bestTime = myDummyDevice.EstimatedWorkingTime

    '    Style = "byX"

    '    'nene+
    '    myDummyDevice.Tools = Device.Tools

    '    OptimizePathes_CheapestInsertion(Device, True)

    '    tnn = myDummyDevice.EstimatedWorkingTime

    '    If tnn < bestTime Then
    '        bestTime = tnn
    '        Style = "NENE & 2-opt"
    '    End If

    '    'cin+
    '    myDummyDevice.Tools = Device.Tools

    '    OptimizePathes_CheapestInsertion(Device, True)

    '    tci = myDummyDevice.EstimatedWorkingTime

    '    If tci < bestTime Then

    '        bestTime = tnn

    '        Style = "CIN & 2-opt"

    '    End If

    '    Return bestTime

    'End Function

#Region "NearestNeigbour"

    Private Sub OptimizePathes_NearestNeighbour(ByRef Device As CNC_Device, ByRef withPostOptimiztation As Boolean)

        For Each t In Device.Tools

            If t.Geometry.Count > 1 Then

                optimizeTool_NearestNeighbour(t, Device.CurToolPosition, withPostOptimiztation)

            End If

        Next

    End Sub

    Private Sub optimizeTool_NearestNeighbour(ByRef Tool As CNC_Tool, ByRef startPoint As Coordinate, ByRef withPostOptimiztation As Boolean)

        Dim newOrdered As New List(Of GeometryObject)

        Dim LastPoint As Coordinate = startPoint

        While Tool.Geometry.Count > 0

            Dim nextG As GeometryObject = getClosestObject(LastPoint, Tool.Geometry)

            newOrdered.Add(nextG)

            LastPoint = nextG.LastPoint

        End While

        If withPostOptimiztation Then

            two_Opt(newOrdered)

        End If

        Tool.Geometry = newOrdered

    End Sub

    ''' <summary>
    ''' sucht das nächste Objekt
    ''' </summary>
    ''' <param name="point">Punkt von dem gesucht wird</param>
    ''' <param name="Geometry">die objekte die abgesucht werden</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getClosestObject(ByRef point As Coordinate, ByRef Geometry As List(Of GeometryObject)) As GeometryObject

        Dim closestG As GeometryObject = Geometry(0)

        Dim closestDistance As Double = Double.PositiveInfinity

        Dim Revers As Boolean = False

        For Each g In Geometry

            Dim Dist2First As Double = Double.PositiveInfinity

            Dist2First = point.DistanceTo(g.FirstPoint)

            If closestDistance > Dist2First Then

                closestDistance = Dist2First
                'Geometries.Remove(g)

                closestG = g

            End If

            Dim Dist2Last As Double = Double.PositiveInfinity

            Dist2Last = point.DistanceTo(g.LastPoint)

            If closestDistance > Dist2Last Then

                closestDistance = Dist2First

                'Geometries.Remove(g)
                Revers = True     'g.ReversPointOrder()

                closestG = g

            End If

        Next

        Geometry.Remove(closestG)

        If Revers Then

            closestG.ReversPointOrder()

        End If

        Return closestG

    End Function

#End Region

#Region "SortByX"

    Private Sub OptimizePathes_ByX(ByRef Device As CNC_Device)

        For Each t In Device.Tools

            If t.Geometry.Count > 1 Then

                t.Geometry.Sort(AddressOf CompareEntitiesByX)

            End If
        Next

    End Sub

    Shared Function CompareEntitiesByX(ByVal A As GeometryObject, ByVal B As GeometryObject) As Integer

        Dim StartPointA As Coordinate

        Dim StartPointB As Coordinate

        StartPointA = A.FirstPoint

        StartPointB = B.FirstPoint

        Dim retval As Integer = StartPointA.X.CompareTo(StartPointB.X)

        If retval <> 0 Then

            Return retval

        Else

            Return StartPointA.Y.CompareTo(StartPointB.Y)

        End If

    End Function

#End Region

#Region "FarthestInsertion"

    Private Sub OptimizePathes_FarthestInsertion(ByRef Device As CNC_Device, ByRef withPostOptimiztation As Boolean)

        For Each t In Device.Tools

            If t.Geometry.Count > 0 Then

                optimizeTool_FarthestInsertion(t, Device.CurToolPosition, withPostOptimiztation)

            End If

        Next

    End Sub

    Private Sub optimizeTool_FarthestInsertion(ByRef Tool As CNC_Tool, ByRef startPoint As Coordinate, ByRef withPostOptimiztation As Boolean)

        Dim Endpoint As New Coordinate

        Dim EndObject As GeometryObject = GetFarthestObject(startPoint, Tool.Geometry)

        Dim toFirst, toLast As Double

        toFirst = startPoint.DistanceTo(EndObject.FirstPoint)

        toLast = startPoint.DistanceTo(EndObject.LastPoint)

        If toFirst > toLast Then

            EndObject.ReversPointOrder()

            Endpoint = EndObject.FirstPoint

        Else

            Endpoint = EndObject.LastPoint

        End If

        Dim newOrdered As New List(Of GeometryObject)

        'hilfsweise den starpunkt, ist kein ectses obkect daher nachher wieder raus
        newOrdered.Add(startPoint)

        newOrdered.Add(EndObject)

        Dim PointAtoInsert As Coordinate = startPoint

        Dim PointBtoInsert As Coordinate = Endpoint

        While Tool.Geometry.Count > 0

            Dim Longest As Double = Double.NegativeInfinity

            Dim ObjectBeforeInsertIndex As Integer = 0

            For i = 1 To newOrdered.Count - 1

                Dim Dist As Double = Double.NegativeInfinity

                Dist = Math.Max( _
                    Math.Max(newOrdered(i - 1).FirstPoint.DistanceTo(newOrdered(i).FirstPoint), _
                             newOrdered(i - 1).LastPoint.DistanceTo(newOrdered(i).FirstPoint)), _
                    Math.Max(newOrdered(i - 1).FirstPoint.DistanceTo(newOrdered(i).LastPoint), _
                             newOrdered(i - 1).LastPoint.DistanceTo(newOrdered(i).LastPoint)))

                If Longest < Dist Then

                    Longest = Dist

                    ObjectBeforeInsertIndex = i - 1

                End If

            Next

            Dim ObjectBeforInsert As GeometryObject = newOrdered(ObjectBeforeInsertIndex)

            Dim ObjectAfterInsert As GeometryObject = newOrdered(ObjectBeforeInsertIndex + 1)

            Dim nextG As GeometryObject = GetFarthestObject(ObjectBeforInsert, ObjectAfterInsert, Tool.Geometry)

            newOrdered.Insert(ObjectBeforeInsertIndex, nextG)

        End While

        'den ersten wieder raus siehe oben
        newOrdered.Remove(startPoint)

        If withPostOptimiztation Then

            two_Opt(newOrdered)

        End If

        Tool.Geometry = newOrdered

    End Sub

    Private Function GetFarthestObject(ByRef ObjA As GeometryObject, ByRef ObjB As GeometryObject, ByRef Geometry As List(Of GeometryObject))

        Dim farthestG As GeometryObject = Nothing

        Dim farthestDistance As Double = Double.NegativeInfinity

        Dim Revers As Boolean = False

        For Each g In Geometry

            Dim DistFromA As Double = Double.NegativeInfinity

            DistFromA = ObjA.MiddlePoint.DistanceTo(g.MiddlePoint)


            Dim DistFromB As Double = Double.NegativeInfinity

            DistFromB = ObjB.MiddlePoint.DistanceTo(g.MiddlePoint)

            If farthestDistance < (DistFromA + DistFromB) Then

                farthestDistance = (DistFromA + DistFromB)

                farthestG = g
            End If

        Next

        Geometry.Remove(farthestG)

        Return farthestG

    End Function

    Private Function GetFarthestObject(ByRef Point As Coordinate, ByRef Geometry As List(Of GeometryObject)) As GeometryObject

        Dim farthestG As GeometryObject = Nothing

        Dim farthestDistance As Double = Double.NegativeInfinity

        Dim toFirst, toLast As Double


        For Each g In Geometry

            Dim Dist As Double = Double.NegativeInfinity

            toFirst = Point.DistanceTo(g.FirstPoint)

            toLast = Point.DistanceTo(g.LastPoint)

            Dist = Math.Max(toFirst, toLast)

            If farthestDistance < Dist Then

                farthestDistance = Dist

                If toLast > toFirst Then
                    g.ReversPointOrder()
                End If

                farthestG = g

            End If

        Next

        Geometry.Remove(farthestG)

        Return farthestG

    End Function

#End Region

#Region "2 opt Heuristik"

    ''' <summary>
    ''' eine schlichte Optimierung zum entflechten von Kreuzungen  in den Leerfahrten
    ''' </summary>
    ''' <param name="Geometry"></param>
    ''' <remarks></remarks>
    Private Sub two_Opt(ByRef Geometry As List(Of GeometryObject)) 'As List(Of GeometryObject)
        ' - A   C -         - A - C -
        '     X       ==>     
        ' - D   B -         - D - B -

        Dim again As Boolean = False

        Dim A, B, C, D As Coordinate

        Dim LineAB, LineCD, LineAC, LineDB As Line

        Do

            again = False

            For i = 0 To Geometry.Count - 2

                For j = 0 To Geometry.Count - 2

                    If j = i - 1 Or j = i + 1 Then
                        Continue For
                    End If

                    A = New Coordinate(Geometry(i).LastPoint)
                    B = New Coordinate(Geometry(i + 1).FirstPoint)

                    C = New Coordinate(Geometry(j).LastPoint)
                    D = New Coordinate(Geometry(j + 1).FirstPoint)

                    LineAB = New Line(A, B)
                    LineCD = New Line(C, D)

                    LineAC = New Line(A, C)
                    LineDB = New Line(D, B)

                    If (LineAB.Length + LineCD.Length > LineAC.Length + LineDB.Length) AndAlso (LineAC.Length + LineDB.Length) > 0 Then

                        turnDirection(Geometry, Math.Min(i, j) + 1, Math.Abs(i - j))

                        again = True

                        'Continue Do

                    End If

                Next

            Next

        Loop While again

        For i = 1 To Geometry.Count - 2

            A = New Coordinate(Geometry(i).LastPoint)
            B = New Coordinate(Geometry(i + 1).FirstPoint)

            C = New Coordinate(Geometry(i - 1).LastPoint)
            D = New Coordinate(Geometry(i).FirstPoint)

            LineAB = New Line(A, B)
            LineCD = New Line(C, D)

            LineAC = New Line(A, C)
            LineDB = New Line(D, B)

            If ((LineAB.Length + LineCD.Length) > (LineAC.Length + LineDB.Length)) AndAlso (LineAC.Length + LineDB.Length) > 0 Then

                turnDirection(Geometry, i, 1)

                again = True

                i = 1
            End If

        Next

    End Sub

    Private Sub turnDirection(ByRef Geometry As List(Of GeometryObject), ByRef start As Integer, ByRef length As Integer)

        Dim myRange As List(Of GeometryObject) = Geometry.GetRange(start, length)

        myRange.Reverse()

        For Each g In myRange

            g.ReversPointOrder()

        Next

        Geometry.RemoveRange(start, myRange.Count)

        Geometry.InsertRange(start, myRange)

    End Sub

#End Region

#Region "CheapestInsertion"

    Private Sub OptimizePathes_CheapestInsertion(ByRef Device As CNC_Device, ByRef withPostOptimiztation As Boolean)

        For Each t In Device.Tools

            If t.Geometry.Count > 0 Then

                optimizeTool_CheapestInsertion(t, Device.CurToolPosition, withPostOptimiztation)

            End If

        Next

    End Sub

    Private Sub optimizeTool_CheapestInsertion(ByRef Tool As CNC_Tool, ByRef startPoint As Coordinate, ByRef withPostOptimiztation As Boolean)

        'da wir keine Rundreise machen benötigen wir einen Endpunkt,
        'bos auf weiteres ist das der weitest entfernet Punkt
        'später evtl. auch sie Tool Homeposition, o. ä.
        Dim Endpoint As New Coordinate
        Dim EndObject As GeometryObject = GetFarthestObject(startPoint, Tool.Geometry)

        Dim toFirst, toLast As Double

        toFirst = startPoint.DistanceTo(EndObject.FirstPoint)

        toLast = startPoint.DistanceTo(EndObject.LastPoint)

        If toFirst > toLast Then

            EndObject.ReversPointOrder()

            Endpoint = EndObject.FirstPoint

        Else

            Endpoint = EndObject.LastPoint

        End If

        'die Liste mit unseren neu sortieren Objekten
        Dim newOrdered As New List(Of GeometryObject)

        'hilfsweise den starpunkt, ist kein ectses object daher nachher wieder raus
        newOrdered.Add(startPoint)

        newOrdered.Add(EndObject)

        Dim objectToInsert As GeometryObject = Nothing

        While Tool.Geometry.Count > 0

            Dim Cheapest As Double = Double.PositiveInfinity

            Dim ObjectBeforeInsertIndex As Integer = 0

            For i = 1 To newOrdered.Count - 1
                'für jeden pafd den billigste Einfügung finden

                Dim Dist As Double

                For j = 0 To Tool.Geometry.Count - 1

                    Dist = Math.Min( _
                       newOrdered(i - 1).LastPoint.DistanceTo(Tool.Geometry(j).FirstPoint) + _
                        newOrdered(i).FirstPoint.DistanceTo(Tool.Geometry(j).LastPoint), _
                        newOrdered(i - 1).LastPoint.DistanceTo(Tool.Geometry(j).LastPoint) + _
                        newOrdered(i).FirstPoint.DistanceTo(Tool.Geometry(j).FirstPoint))

                    If Cheapest > Dist Then

                        Cheapest = Dist

                        ObjectBeforeInsertIndex = i - 1

                        objectToInsert = Tool.Geometry(j)

                    End If

                Next

            Next

            Tool.Geometry.Remove(objectToInsert)

            newOrdered.Insert(ObjectBeforeInsertIndex, objectToInsert)

        End While

        'den ersten wieder raus siehe oben
        newOrdered.Remove(startPoint)

        If withPostOptimiztation Then

            two_Opt(newOrdered)

        End If

        Tool.Geometry = newOrdered

    End Sub

#End Region

End Class

