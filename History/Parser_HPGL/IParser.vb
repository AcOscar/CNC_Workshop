Public Interface IParser

    ''' <summary>
    ''' device units for one milimeter
    ''' </summary>
    Property DeviceUnits As Double

    ''' <summary>
    ''' moves to the coordinate
    ''' </summary>
    ''' <remarks>dosn't changed the tool status</remarks>
    Function AbsoluteMove(ByVal coordinate As WrkShp.Coordinate) As String

    ''' <summary>
    ''' moves to the coordinate
    ''' </summary>
    ''' <remarks>dosn't changed the tool status</remarks>
    Function AbsoluteMove(ByVal X As Double, ByVal Y As Double) As String

    ''' <summary>
    ''' moves the current tool relative
    ''' </summary>
    ''' <remarks>dosn't change the tool status, usaly shorter then an absulute move</remarks>
    Function RelativeMove(ByVal fromCoordinate As WrkShp.Coordinate, ByVal toCoordinate As WrkShp.Coordinate) As String

    ''' <summary>
    ''' moves the current tool relative
    ''' </summary>
    ''' <remarks>dosn't change the tool status, usaly shorter then an absulute move</remarks>
    Function RelativeMove(ByVal DeltaX As Double, ByVal DeltaY As Double) As String
    ''' <summary>
    ''' activate the current tool 
    ''' </summary>
    ''' <remarks>Pen Down</remarks>
    Function ToolOn() As String

    ''' <summary>
    ''' deactivate the current tool 
    ''' </summary>
    ''' <remarks>Pen Up</remarks>
    Function ToolOff() As String

End Interface

