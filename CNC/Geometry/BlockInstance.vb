Public Class BlockInstance
    Inherits GeometryObject
    Private _x, _y As Double

    Public Overrides ReadOnly Property FirstPoint As Coordinate
        Get
            Return New Coordinate(_x, _y)
        End Get
    End Property

    Public Overrides ReadOnly Property HPGL(Factor As Integer) As String
        Get
            Dim _Return As New Text.StringBuilder
            'just going to position an going down there
            _Return.AppendFormat("PU{0},{1};", Math.Round(_x * Factor), Math.Round(_y * Factor))
            _Return.AppendFormat("PD{0},{1};", Math.Round(_x * Factor), Math.Round(_y * Factor))
            Return _Return.ToString
        End Get
    End Property
    Public Overrides ReadOnly Property GC3(Factor As Integer, digits As Integer) As String
        Get
            Dim _Return As New Text.StringBuilder
            'just going to position an going down there
            _Return.AppendFormat("G0X{0}Y{1}", Math.Round(_x * Factor, digits), Math.Round(_y * Factor, digits))
            _Return.AppendFormat("G1X{0}Y{1}", Math.Round(_x * Factor, digits), Math.Round(_y * Factor, digits))
            Return _Return.ToString
        End Get
    End Property

    Public Overrides ReadOnly Property isReverted As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property LastPoint As Coordinate
        Get
            Return New Coordinate(_x, _y)
        End Get
    End Property

    Public Overrides ReadOnly Property Length As Double
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property maxPoint As Coordinate
        Get
            Return New Coordinate(_x, _y)
        End Get
    End Property

    Public Overrides ReadOnly Property minPoint As Coordinate
        Get
            Return New Coordinate(_x, _y)
        End Get
    End Property

    Public Overrides Sub ReversPointOrder()

    End Sub

    Public Overrides Sub Transform(MoveVector As Coordinate)
        _x += MoveVector.X
        _y += MoveVector.Y

    End Sub
End Class
