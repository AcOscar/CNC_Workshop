Public Class HPGL_Parser
    Inherits Parser
    Implements IParser

    Property DeviceUnits As Double Implements IParser.DeviceUnits

    Function AbsoluteMove(ByVal coordinate As WrkShp.Coordinate) As String Implements IParser.AbsoluteMove

        Dim myString As String = String.Empty

        Dim myX, myY As Double

        myX = coordinate.X * DeviceUnits
        myY = coordinate.Y * DeviceUnits

        myString = String.Format("PA {0},{1};", coordinate.X, coordinate.Y)

        Return myString

    End Function

    ''' <summary>
    ''' moves to the coordinate
    ''' </summary>
    ''' <remarks>dosn't changed the tool status</remarks>
    Function AbsoluteMove(ByVal X As Double, ByVal Y As Double) As String Implements IParser.AbsoluteMove

        Dim myString As String = String.Empty

        Dim myX, myY As Double

        myX = X * DeviceUnits
        myY = Y * DeviceUnits

        myString = String.Format("PA {0},{1};", X, Y)

        Return myString

    End Function

    ''' <summary>
    ''' moves the current tool relative
    ''' </summary>
    ''' <remarks>dosn't change the tool status, usaly shorter then an absulute move</remarks>
    Function RelativeMove(ByVal fromCoordinate As WrkShp.Coordinate, ByVal toCoordinate As WrkShp.Coordinate) As String Implements IParser.RelativeMove

        Dim myString As String = String.Empty

        Dim myDX, myDY As Double

        myDX = toCoordinate.X - fromCoordinate.X * DeviceUnits
        myDY = toCoordinate.Y - fromCoordinate.Y * DeviceUnits

        myString = String.Format("PR {0},{1};", myDX, myDY)

        Return myString

    End Function

    ''' <summary>
    ''' moves the current tool relative
    ''' </summary>
    ''' <remarks>dosn't change the tool status, usaly shorter then an absulute move</remarks>
    Function RelativeMove(ByVal DeltaX As Double, ByVal DeltaY As Double) As String Implements IParser.RelativeMove

        Dim myString As String = String.Empty

        Dim myDX, myDY As Double

        myDX = DeltaX * DeviceUnits
        myDY = DeltaY * DeviceUnits

        myString = String.Format("PR {0},{1};", myDX, myDY)

        Return myString

    End Function

    ''' <summary>
    ''' activate the current tool 
    ''' </summary>
    ''' <remarks>Pen Down</remarks>
    Function ToolOn() As String Implements IParser.ToolOn

        Dim myString As String = String.Empty

        myString = "PD;"

        Return myString

    End Function

    ''' <summary>
    ''' deactivate the current tool 
    ''' </summary>
    ''' <remarks>Pen Up</remarks>
    Function ToolOff() As String Implements IParser.ToolOff

        Dim myString As String = String.Empty

        myString = "PU;"

        Return myString

    End Function

End Class
