Public Class Line
    Inherits NPolyline
    Sub New(ByVal Starpoint As Coordinate, ByVal EndPoint As Coordinate)
        Points = New List(Of Coordinate) From {
            New Coordinate(Starpoint),
            New Coordinate(EndPoint)
        }

    End Sub
    ''' <summary>
    ''' creates a simple line with a start and a end point
    ''' </summary>
    Sub New(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
        Points = New List(Of Coordinate) From {
            New Coordinate(x1, y1),
            New Coordinate(x2, y2)
        }

    End Sub
    Sub New()



    End Sub

End Class
