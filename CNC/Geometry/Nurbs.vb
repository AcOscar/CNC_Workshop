Public Class Nurbs
    Inherits GeometryObject

    Private _isReverted As Boolean = False

    Public Points As New List(Of Coordinate)

    Public Overrides ReadOnly Property FirstPoint As Coordinate
        Get
            If Points.Count > 0 Then

                Return Points(0)

            Else

                Return New Coordinate(0, 0)

            End If

        End Get
    End Property

    Public Overrides ReadOnly Property LastPoint As Coordinate
        Get
            If Points.Count > 0 Then

                Return Points(Points.Count - 1)

            Else

                Return New Coordinate(0, 0)

            End If
        End Get
    End Property

    Public Overrides ReadOnly Property Length As Double
        Get
            Dim dx, dy, l As Double

            For i = 0 To Points.Count - 2

                dx = Points(i).X - Points(i + 1).X
                dy = Points(i).Y - Points(i + 1).Y

                l += Math.Sqrt(dx ^ 2 + dy ^ 2)

            Next

            Return l

        End Get
    End Property

    Public Overrides ReadOnly Property minPoint As Coordinate
        Get
            Dim retX, retY As Double

            retX = Double.PositiveInfinity
            retY = Double.PositiveInfinity

            For Each p As Coordinate In Points

                retX = Math.Min(p.X, retX)
                retY = Math.Min(p.Y, retY)

            Next

            Return New Coordinate(retX, retY)

        End Get
    End Property

    Public Overrides ReadOnly Property maxPoint As Coordinate
        Get
            Dim retX, retY As Double

            For Each p As Coordinate In Points

                retX = Math.Max(p.X, retX)
                retY = Math.Max(p.Y, retY)

            Next

            Return New Coordinate(retX, retY)
        End Get
    End Property

    Public Overrides ReadOnly Property isReverted As Boolean
        Get

            Return _isReverted

        End Get

    End Property

    Public Overrides ReadOnly Property HPGL(Factor As Integer) As String
        Get
            Dim _Return As New Text.StringBuilder

#If shortHPGL Then

            'move up and go to start of line and pen down
            _Return.AppendFormat("PU{0},{1};PD", Math.Round(Points(0).X * Factor), Math.Round(Points(0).Y * Factor))

            For i As Integer = 1 To Points.Count - 1
                'each point as simple pair
                _Return.AppendFormat("{0},{1},", Math.Round(Points(i).X * Factor), Math.Round(Points(i).Y * Factor))

            Next
            'remove the last ,
            _Return.Remove(_Return.Length - 1, 1)

            'close HPGL
            _Return.Append(";")

#Else

            'move up and go to start of line and pen down
            _Return.AppendFormat("PU{0},{1};", Math.Round(Points(0).X * Factor), Math.Round(Points(0).Y * Factor))

            For i As Integer = 1 To Points.Count - 1
                'each point as simple pair
                _Return.AppendFormat("PD{0},{1};", Math.Round(Points(i).X * Factor), Math.Round(Points(i).Y * Factor))

            Next

#End If

            Return _Return.ToString
        End Get
    End Property

    Public Overrides ReadOnly Property GC3(Factor As Integer, Digits As Integer) As String
        Get
            Dim _Return As New Text.StringBuilder

            'move up and go to start of line and pen down
            '_Return.AppendFormat("PU{0},{1};", Math.Round(Points(0).X * Factor), Math.Round(Points(0).Y * Factor))
            _Return.AppendFormat("G0X{0}Y{1}Z#1" & vbCrLf, Math.Round(Points(0).X * Factor, Digits), Math.Round(Points(0).Y * Factor, Digits))

            For i As Integer = 0 To Points.Count - 1
                'each point as simple pair
                _Return.AppendFormat("G1X{0}Y{1}Z#2" & vbCrLf, Math.Round(Points(i).X * Factor, Digits), Math.Round(Points(i).Y * Factor, Digits))

            Next

            _Return.Append("G0Z#1" & vbCrLf)

            Return _Return.ToString
        End Get
    End Property

    Public Overrides Sub ReversPointOrder()
        Points.Reverse()

        _isReverted = Not _isReverted
    End Sub

    Public Overrides Sub Transform(MoveVector As Coordinate)
        For i = 0 To Me.Points.Count - 1

            Dim p As Coordinate = Me.Points(i)

            Me.Points(i) = New Coordinate(p.X + MoveVector.X, p.Y + MoveVector.Y)

        Next
    End Sub
End Class
