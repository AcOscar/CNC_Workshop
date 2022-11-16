Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class Edge
    Property Origin As Node
    Property Destination As Node
    Property Distance As Double

    ''' <summary>
    ''' Konstruktor
    ''' </summary>
    ''' <param name="origin">Startknoten</param>
    ''' <param name="destination">Zielknoten</param>
    ''' <param name="distance">Distanz</param>
    Public Sub New(ByVal origin As Node, ByVal destination As Node, ByVal distance As Double)
        Me._Origin = origin
        Me._Destination = destination
        Me._Distance = distance
    End Sub

End Class
