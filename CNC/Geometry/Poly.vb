''' <summary>
''' a polyl is a collection of different other types
''' </summary>
Public Class Poly
    Inherits GeometryObject

    Private _isReverted As Boolean = False

    'Public Points As New List(Of Coordinate)
    Public Segments As New List(Of GeometryObject)

    Public Overrides ReadOnly Property FirstPoint As Coordinate
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property LastPoint As Coordinate
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property Length As Double
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property minPoint As Coordinate
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property maxPoint As Coordinate
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property isReverted As Boolean
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property HPGL(Factor As Integer) As String
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property GC3(Factor As Integer, Digits As Integer) As String
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides Sub ReversPointOrder()
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Transform(MoveVector As Coordinate)
        Throw New NotImplementedException()
    End Sub
End Class
