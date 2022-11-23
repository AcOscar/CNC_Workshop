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
            If Segments.Count = 0 Then

                Return New Coordinate(0, 0)

            Else

                Return Segments(0).FirstPoint

            End If

        End Get

    End Property

    Public Overrides ReadOnly Property LastPoint As Coordinate
        Get
            If Segments.Count = 0 Then

                Return New Coordinate(0, 0)

            Else

                Return Segments(Segments.Count - 1).LastPoint

            End If
        End Get
    End Property

    Public Overrides ReadOnly Property Length As Double
        Get
            Dim l As Double = 0

            For Each seg As GeometryObject In Segments

                l += seg.Length

            Next

            Return l

        End Get
    End Property

    Public Overrides ReadOnly Property minPoint As Coordinate
        Get
            Dim retX, retY As Double

            retX = Double.PositiveInfinity
            retY = Double.PositiveInfinity

            For Each seg As GeometryObject In Segments

                Select Case seg.GetType

                    Case GetType(Nurbs)
                        Dim myNurbs As Nurbs = CType(seg, Nurbs)

                        retX = Math.Min(myNurbs.minPoint.X, retX)
                        retY = Math.Min(myNurbs.minPoint.Y, retY)

                    Case GetType(Arc)
                        Dim myArc As Arc = CType(seg, Arc)

                        retX = Math.Min(myArc.minPoint.X, retX)
                        retY = Math.Min(myArc.minPoint.Y, retY)

                    Case GetType(Line)
                        Dim myLine As Line = CType(seg, Line)

                        retX = Math.Min(myLine.minPoint.X, retX)
                        retY = Math.Min(myLine.minPoint.Y, retY)

                    Case GetType(NPolyline)
                        Dim myNPolyline As NPolyline = CType(seg, NPolyline)

                        retX = Math.Min(myNPolyline.minPoint.X, retX)
                        retY = Math.Min(myNPolyline.minPoint.Y, retY)

                    Case Else

                End Select

            Next

            Return New Coordinate(retX, retY)

        End Get
    End Property

    Public Overrides ReadOnly Property maxPoint As Coordinate
        Get
            Dim retX, retY As Double

            For Each seg As GeometryObject In Segments

                Select Case seg.GetType

                    Case GetType(Nurbs)
                        Dim myNurbs As Nurbs = CType(seg, Nurbs)

                        retX = Math.Max(myNurbs.minPoint.X, retX)
                        retY = Math.Max(myNurbs.minPoint.Y, retY)

                    Case GetType(Arc)
                        Dim myArc As Arc = CType(seg, Arc)

                        retX = Math.Max(myArc.minPoint.X, retX)
                        retY = Math.Max(myArc.minPoint.Y, retY)

                    Case GetType(Line)
                        Dim myLine As Line = CType(seg, Line)

                        retX = Math.Max(myLine.minPoint.X, retX)
                        retY = Math.Max(myLine.minPoint.Y, retY)

                    Case GetType(NPolyline)
                        Dim myNPolyline As NPolyline = CType(seg, NPolyline)

                        retX = Math.Max(myNPolyline.minPoint.X, retX)
                        retY = Math.Max(myNPolyline.minPoint.Y, retY)

                    Case Else

                End Select

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

            For Each seg As GeometryObject In Segments

                _Return.Append(seg.HPGL(Factor))

            Next

            Return _Return.ToString

        End Get
    End Property

    Public Overrides ReadOnly Property GC3(Factor As Integer, Digits As Integer) As String
        Get
            Dim _Return As New Text.StringBuilder

            For Each seg As GeometryObject In Segments

                _Return.Append(seg.GC3(Factor, Digits))

            Next

            Return _Return.ToString

        End Get
    End Property

    Public Overrides Sub ReversPointOrder()

        For Each seg As GeometryObject In Segments

            seg.ReversPointOrder()

        Next

        _isReverted = Not _isReverted

    End Sub

    Public Overrides Sub Transform(MoveVector As Coordinate)

        For Each seg As GeometryObject In Segments

            seg.Transform(MoveVector)

        Next

    End Sub
End Class
