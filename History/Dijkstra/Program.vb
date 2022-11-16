Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Programm

    Class Program

        Private Shared Sub Main(ByVal args() As String)
            Dim _dictNodes As Dictionary(Of String, Node) = New Dictionary(Of String, Node)
            _dictNodes.Add("A", New Node("A"))
            _dictNodes.Add("B", New Node("B"))
            _dictNodes.Add("C", New Node("C"))
            _dictNodes.Add("D", New Node("D"))
            _dictNodes.Add("E", New Node("E"))
            _dictNodes.Add("F", New Node("F"))
            Dim _nodes As List(Of Node) = New List(Of Node)
            For Each n As Node In _dictNodes.Values
                _nodes.Add(n)
            Next
            Dim _edges As List(Of Edge) = New List(Of Edge)
            _edges.Add(New Edge(_dictNodes("A"), _dictNodes("B"), 7))
            _edges.Add(New Edge(_dictNodes("A"), _dictNodes("C"), 14))
            _edges.Add(New Edge(_dictNodes("A"), _dictNodes("D"), 9))
            _edges.Add(New Edge(_dictNodes("B"), _dictNodes("A"), 7))
            _edges.Add(New Edge(_dictNodes("B"), _dictNodes("D"), 10))
            _edges.Add(New Edge(_dictNodes("B"), _dictNodes("E"), 15))
            _edges.Add(New Edge(_dictNodes("C"), _dictNodes("A"), 14))
            _edges.Add(New Edge(_dictNodes("C"), _dictNodes("D"), 2))
            _edges.Add(New Edge(_dictNodes("C"), _dictNodes("F"), 9))
            _edges.Add(New Edge(_dictNodes("D"), _dictNodes("C"), 2))
            _edges.Add(New Edge(_dictNodes("D"), _dictNodes("A"), 9))
            _edges.Add(New Edge(_dictNodes("D"), _dictNodes("B"), 10))
            _edges.Add(New Edge(_dictNodes("D"), _dictNodes("E"), 11))
            _edges.Add(New Edge(_dictNodes("E"), _dictNodes("B"), 15))
            _edges.Add(New Edge(_dictNodes("E"), _dictNodes("D"), 11))
            _edges.Add(New Edge(_dictNodes("E"), _dictNodes("F"), 6))
            _edges.Add(New Edge(_dictNodes("F"), _dictNodes("C"), 9))
            _edges.Add(New Edge(_dictNodes("F"), _dictNodes("E"), 6))
            ' Neues Objekt der Klasse Dijkstra erstellen
            Dim d As Dijkstra = New Dijkstra(_edges, _nodes)
            ' Startknoten festlegen und Distanzen berechnen
            d.calculateDistance(_dictNodes("A"))
            ' Pfad zu einem bestimmten Knoten ausgeben
            Dim path As List(Of Node) = d.getPathTo(_dictNodes("F"))
            If (path.Count > 0) Then
                For Each n As Node In path
                    Console.Write((n.Name + " "))
                Next
                Console.WriteLine("")
            End If
            Console.WriteLine("Bitte eine Taste drücken")
            Console.ReadKey()
        End Sub
    End Class
End Namespace