
Public MustInherit Class GeometryObject

    MustOverride ReadOnly Property FirstPoint As Coordinate

    MustOverride ReadOnly Property LastPoint As Coordinate

    Public MustOverride ReadOnly Property Length As Double

    ''' <summary>
    ''' turns the cutting direction
    ''' </summary>
    Public MustOverride Sub ReversPointOrder()

    ''' <summary>
    ''' the smallest x und y value as coordiante 
    ''' </summary>
    ''' <remarks>very usefull for Bounding Boxes</remarks>
    MustOverride ReadOnly Property minPoint As Coordinate

    ''' <summary>
    ''' the greates x und y value as coordiante 
    ''' </summary>
    ''' <remarks>very usefull for Bounding Boxes</remarks>
    MustOverride ReadOnly Property maxPoint As Coordinate

    ''' <summary>
    ''' get the last point of the object depending an indx
    ''' </summary>
    ''' <param name="indx">if its negative the first point is the the last and vice versa</param>
    ''' <remarks> this is usefull if you use as indx the sortordernumber</remarks>
    Public ReadOnly Property GetLast(ByVal indx As Integer) As Coordinate

        Get
            If indx > 0 Then

                Return LastPoint

            Else

                Return FirstPoint

            End If

        End Get

    End Property

    ''' <summary>
    ''' get the first point of the object depending an indx
    ''' </summary>
    ''' <param name="indx">if its negative the first point is the the last and vice versa</param>
    ''' <remarks> this is usefull if you use as indx the sortordernumber</remarks>
    Public ReadOnly Property GetFirst(ByVal indx As Integer) As Coordinate

        Get
            If indx > 0 Then

                Return FirstPoint

            Else

                Return LastPoint

            End If

        End Get

    End Property

    ''' <summary>
    ''' indicates that the object has a reverted point order in compartion to the original curve
    ''' </summary>
    Public MustOverride ReadOnly Property isReverted As Boolean

    ''' <summary>
    ''' the HPGL represantation of the Geometry
    ''' </summary>
    ''' <param name="Factor">the devicefactor between device units and mm</param>
    Public MustOverride ReadOnly Property HPGL(ByVal Factor As Integer) As String
    Public MustOverride ReadOnly Property GC3(ByVal Factor As Integer, ByVal Digits As Integer) As String

    Public MustOverride Sub Transform(ByVal MoveVector As Coordinate)

End Class
