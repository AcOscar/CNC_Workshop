Public Class Arc

    Inherits GeometryObject

    Public Property Center As Coordinate
    Public Property EndPoint As Coordinate
    Public Property StartPoint As Coordinate

    Public Property Radius As Double

    Public Property AngleDegrees As Double
    Public Property IsCompleteCircle As Boolean

    Public Enum CurveOrientation
        Undefined = 0
        Clockwise = -1
        CounterClockwise = 1
    End Enum

    Public Property Orientation As CurveOrientation


    Public Overrides ReadOnly Property FirstPoint() As Coordinate

        Get

            Return Center

        End Get

    End Property

    Public Overrides ReadOnly Property LastPoint() As Coordinate

        Get

            Return Center

        End Get

    End Property

    Overrides Sub ReversPointOrder()
        'there is nothing to revert
    End Sub

    Public Overrides ReadOnly Property isReverted As Boolean
        Get

            Return False

        End Get

    End Property


    Overrides ReadOnly Property Length As Double

        Get

            Return 2 * Math.PI * Radius

        End Get

    End Property

    Overrides ReadOnly Property minPoint As Coordinate

        Get

            Dim retX, retY As Double

            retX = Center.X - Radius
            retY = Center.Y - Radius

            Return New Coordinate(retX, retY)

        End Get

    End Property

    Overrides ReadOnly Property maxPoint As Coordinate

        Get

            Dim retX, retY As Double

            retX = Center.X + Radius
            retY = Center.Y + Radius

            Return New Coordinate(retX, retY)

        End Get

    End Property

    ''' <summary>
    ''' the HPGL represantation of the Geometry
    ''' </summary>
    ''' <param name="Factor">the devicefactor between device units and mm</param>
    Public Overrides ReadOnly Property HPGL(ByVal Factor As Integer) As String

        Get
            'UNTESTED:
            Dim _Return As New Text.StringBuilder
            If IsCompleteCircle Then

                _Return.AppendFormat("PU{0},{1};", Math.Round(Center.X * Factor), Math.Round(Center.Y * Factor))

                _Return.AppendFormat("CI{0};", Math.Round(Radius * Factor))

            Else
                _Return.AppendFormat("PU{0},{1};", Math.Round(StartPoint.X * Factor), Math.Round(StartPoint.Y * Factor))

                _Return.AppendFormat("AA{0},{1},{2};", Math.Round(Center.X * Factor), Math.Round(Center.Y * Factor), AngleDegrees)

            End If

            Return _Return.ToString

        End Get

    End Property
    Public Overrides ReadOnly Property GC3(ByVal Factor As Integer, Digits As Integer) As String

        Get
            'todo: here the arc
            Dim _Return As New Text.StringBuilder

            _Return.AppendFormat("G0X{0}Y{1}Z#1" & vbCrLf, Math.Round(StartPoint.X * Factor, Digits), Math.Round(StartPoint.Y * Factor, Digits))
            _Return.AppendFormat("G1X{0}Y{1}Z#2" & vbCrLf, Math.Round(StartPoint.X * Factor, Digits), Math.Round(StartPoint.Y * Factor, Digits))
            Select Case Orientation
                Case CurveOrientation.Clockwise
                    _Return.AppendFormat("G2X{0}Y{1}Z#2I{2}J{3}" & vbCrLf, Math.Round(EndPoint.X * Factor, Digits), Math.Round(EndPoint.Y * Factor, Digits),
                    Math.Round(Center.X * Factor, Digits) - Math.Round(StartPoint.X * Factor, Digits),
                    Math.Round(Center.Y * Factor, Digits) - Math.Round(StartPoint.Y * Factor, Digits))

                Case CurveOrientation.CounterClockwise
                    _Return.AppendFormat("G3X{0}Y{1}Z#2I{2}J{3}" & vbCrLf, Math.Round(EndPoint.X * Factor, Digits), Math.Round(EndPoint.Y * Factor, Digits),
                    Math.Round(Center.X * Factor, Digits) - Math.Round(StartPoint.X * Factor, Digits),
                    Math.Round(Center.Y * Factor, Digits) - Math.Round(StartPoint.Y * Factor, Digits))

            End Select

            _Return.AppendFormat("G0X{0}Y{1}Z#1" & vbCrLf, Math.Round(EndPoint.X * Factor, Digits), Math.Round(EndPoint.Y * Factor, Digits))
            '_Return.Append("(to center)")
            '_Return.AppendFormat("G0X{0}Y{1}Z#1" & vbCrLf, Math.Round(Center.X * Factor, Digits), Math.Round(Center.Y * Factor, Digits))

            Return _Return.ToString

        End Get

    End Property

    Public Overrides Sub Transform(ByVal MoveVector As Coordinate)

        Center = New Coordinate(Center.X + MoveVector.X, Center.Y + MoveVector.Y)

    End Sub

End Class
