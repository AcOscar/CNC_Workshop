Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text


Public Class Dijkstra

    Property Nodes As List(Of Node)

    Property Edges As List(Of Edge)

    Property Basis As List(Of Node)

    Property Dist As Dictionary(Of String, Double)

    Property Previous As Dictionary(Of String, Node)

    ''' <summary>
    ''' Konstruktor
    ''' </summary>
    ''' <param name="edges">Liste aller Kanten</param>
    ''' <param name="nodes">Liste aller Knoten</param>
    Public Sub New(ByVal edges As List(Of Edge), ByVal nodes As List(Of Node))
        MyBase.New()
        _Edges = edges

        _Nodes = nodes
        _Basis = New List(Of Node)
        _Dist = New Dictionary(Of String, Double)
        _Previous = New Dictionary(Of String, Node)
        ' Knoten aufnehmen
        For Each n As Node In nodes
            Previous.Add(n.Name, Nothing)
            Basis.Add(n)
            Dist.Add(n.Name, Double.MaxValue)
        Next
    End Sub

    ''' <summary>
    ''' Berechnet die kürzesten Wege vom start
    ''' Knoten zu allen anderen Knoten
    ''' </summary>
    ''' <param name="start">Startknoten</param>
    Public Sub calculateDistance(ByVal start As Node)
        _Dist(start.Name) = 0

        While (_Basis.Count > 0)
            Dim u As Node = getNodeWithSmallestDistance()
            If (u Is Nothing) Then
                _Basis.Clear()
            Else
                For Each v As Node In getNeighbors(u)
                    Dim alt As Double = (_Dist(u.Name) + getDistanceBetween(u, v))
                    If (alt < _Dist(v.Name)) Then
                        Dist(v.Name) = alt
                        Previous(v.Name) = u
                    End If
                Next
                Basis.Remove(u)
            End If

        End While
    End Sub

    ''' <summary>
    ''' Liefert den Pfad zum Knoten d
    ''' </summary>
    ''' <param name="d">Zielknoten</param>
    ''' <returns></returns>
    Public Function getPathTo(ByVal d As Node) As List(Of Node)
        Dim path As List(Of Node) = New List(Of Node)
        path.Insert(0, d)

        While (Not (_Previous(d.Name)) Is Nothing)
            d = Previous(d.Name)
            path.Insert(0, d)

        End While
        Return path
    End Function

    ''' <summary>
    ''' Liefert den Knoten mit der kürzesten Distanz
    ''' </summary>
    ''' <returns></returns>
    Public Function getNodeWithSmallestDistance() As Node
        Dim distance As Double = Double.MaxValue
        Dim smallest As Node = Nothing
        For Each n As Node In Basis
            If (Dist(n.Name) < distance) Then
                distance = Dist(n.Name)
                smallest = n
            End If
        Next
        Return smallest
    End Function

    ''' <summary>
    ''' Liefert alle Nachbarn von n die noch in der Basis sind
    ''' </summary>
    ''' <param name="n">Knoten</param>
    ''' <returns></returns>
    Public Function getNeighbors(ByVal n As Node) As List(Of Node)
        Dim neighbors As List(Of Node) = New List(Of Node)
        For Each e As Edge In Edges
            If (e.Origin.Equals(n) AndAlso Basis.Contains(n)) Then
                neighbors.Add(e.Destination)
            End If
        Next
        Return neighbors
    End Function

    ''' <summary>
    ''' Liefert die Distanz zwischen zwei Knoten
    ''' </summary>
    ''' <param name="o">Startknoten</param>
    ''' <param name="d">Endknoten</param>
    ''' <returns></returns>
    Public Function getDistanceBetween(ByVal o As Node, ByVal d As Node) As Double
        For Each e As Edge In Edges
            If (e.Origin.Equals(o) AndAlso e.Destination.Equals(d)) Then
                Return e.Distance
            End If
        Next
        Return 0
    End Function
End Class
