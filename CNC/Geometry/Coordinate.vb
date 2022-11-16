''' <summary>
''' a coordinate is just a different word for a point
''' </summary>
Public Class Coordinate
    Inherits GeometryObject

    Private _x, _y As Double

    ''' <remarks>for easier debugging</remarks>
    Overrides Function ToString() As String

        Return X.ToString & "," & Y.ToString

    End Function

    Public ReadOnly Property X As Double

        Get

            Return _x

        End Get

    End Property

    Public ReadOnly Property Y As Double

        Get

            Return _y

        End Get

    End Property

    Sub New()

    End Sub

    ''' <summary>
    ''' to clone
    ''' </summary>
    Sub New(ByVal c As Coordinate)

        _x = c.X
        _y = c.Y

    End Sub

    Sub New(ByVal xValue As Double, ByVal yValue As Double)

        _x = xValue
        _y = yValue

    End Sub

    Public Function DistanceTo(ByVal [To] As Coordinate) As Double

        Dim DeltaCo As Coordinate = Me - [To]

        Dim Distance As Double

        Distance = Math.Sqrt(DeltaCo.X ^ 2 + DeltaCo.Y ^ 2)

        If Double.IsNaN(Distance) Then

            Distance = 0

        End If

        Return Distance

    End Function

#Region "Operators"

    Public Shared Operator =(ByVal C1 As Coordinate, ByVal C2 As Coordinate) As Boolean

        If C1.X = C2.X AndAlso C1.Y = C2.Y Then

            Return True

        Else

            Return False

        End If

    End Operator

    Public Shared Operator <>(ByVal C1 As Coordinate, ByVal C2 As Coordinate) As Boolean

        If C1 = C2 Then

            Return False

        Else

            Return True

        End If

    End Operator

    Public Shared Operator -(ByVal C1 As Coordinate, ByVal C2 As Coordinate) As Coordinate

        Dim retX, retY As Double

        retX = C1.X - C2.X

        retY = C1.Y - C2.Y

        Return New Coordinate(retX, retY)

    End Operator

#End Region

    ''' <summary>
    ''' a little poor but neccassary
    ''' </summary>

    Public Overrides ReadOnly Property FirstPoint() As Coordinate

        Get

            Return New Coordinate(_x, _y)

        End Get

    End Property

    Public Overrides ReadOnly Property LastPoint() As Coordinate

        Get

            Return New Coordinate(_x, _y)

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

            Return 0

        End Get

    End Property

    Overrides ReadOnly Property minPoint As Coordinate

        Get

            Return New Coordinate(_x, _y)

        End Get

    End Property

    Overrides ReadOnly Property maxPoint As Coordinate

        Get

            Return New Coordinate(_x, _y)

        End Get

    End Property

    ''' <summary>
    ''' the HPGL represantation of the Geometry
    ''' </summary>
    ''' <param name="Factor">the devicefactor between device units and mm</param>
    Public Overrides ReadOnly Property HPGL(ByVal Factor As Integer) As String
        Get
            Dim _Return As New Text.StringBuilder
            'just going to position an going down there
            _Return.AppendFormat("PU{0},{1};", Math.Round(_x * Factor), Math.Round(_y * Factor))
            _Return.AppendFormat("PD{0},{1};", Math.Round(_x * Factor), Math.Round(_y * Factor))

            Return _Return.ToString

        End Get

    End Property

    Public Overrides Sub Transform(ByVal MoveVector As Coordinate)

        _x += MoveVector.X
        _y += MoveVector.Y

    End Sub

End Class
