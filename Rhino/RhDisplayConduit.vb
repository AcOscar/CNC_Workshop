Imports Rhino
Imports Rhino.Geometry

Public Class RhDisplayConduit
    Inherits Rhino.Display.DisplayConduit

    ''' <summary>
    ''' objects there was already cutted
    ''' </summary>
    ''' <remarks>when we finished all objects are here</remarks>
    Public HistoryObjects As Rhino.Collections.RhinoList(Of Geometry.Curve)

    ''' <summary>
    ''' objects to be cutted
    ''' </summary>
    ''' <remarks>as we start here are all objects</remarks>
    Public FutureObjects As Rhino.Collections.RhinoList(Of Geometry.Curve)

    ''' <summary>
    ''' the current cutted object
    ''' </summary>
    Public CurrentObject As Geometry.Curve

    ''' <summary>
    ''' fixed objects
    ''' </summary>
    Public DeviceFixObjects As Rhino.Collections.RhinoList(Of Geometry.Curve)

    ''' <summary>
    ''' the geometry for the reference point, usaly a small cross
    ''' </summary>
    Public DeviceReferencePointObjects As Rhino.Collections.RhinoList(Of Geometry.Curve)

    ''' <summary>
    ''' objects visible while moving for a new defice positon or new job position
    ''' </summary>
    Private MovingPreviewObjects As Rhino.Collections.RhinoList(Of Geometry.Curve)

    ''' <summary>
    ''' distance between MoveFrom and zeropoint
    ''' </summary>
    Public MoveOffset As Point3d

    ''' <summary>
    ''' point from where we want to move
    ''' </summary>
    Public MoveFrom As Point3d

    ''' <summary>
    ''' should we draw a traceline while moving from frompoint to topoint
    ''' </summary>
    Public DrawTraceLine As Boolean = False

    ''' <summary>
    ''' a move command is runnig and the conduit is moving on the screen
    ''' </summary>
    Private isMoving As Boolean

    Private _MoveTo As Point3d

    Private _TmpPath As String = String.Empty

    ''' <summary>
    ''' the device is visible in the conduit
    ''' </summary>
    Private ShowDevice As Boolean

    ''' <summary>
    ''' the job is visible in the conduit
    ''' </summary>
    Private ShowJob As Boolean

    ''' <summary>
    ''' this will create a new empty conduit
    ''' </summary>
    Public Sub New()

        DeviceFixObjects = New Rhino.Collections.RhinoList(Of Geometry.Curve)

        DeviceReferencePointObjects = New Rhino.Collections.RhinoList(Of Geometry.Curve)

        MoveOffset = New Point3d

        MoveFrom = New Point3d

        _MoveTo = New Point3d

        PurgeJob(withZeropoint:=True)

    End Sub

    Private Property RhCwithRefPoint As Boolean

    ''' <summary>
    ''' loads a device into the conduit
    ''' </summary>
    Public Sub LoadNewDevice(ByVal Device As CNC_Device)

        DeviceFixObjects = GetConduitObj(Device.ProxyGraphic)

        If Device.WithReferencePoint Then

            DeviceReferencePointObjects = GetConduitObj(Device.ProxyRefPoint)

        End If

        MoveOffset = New Point3d

        MoveFrom = New Point3d

        _MoveTo = New Point3d

        _zeropoint = New Point3d

        If Device.DisplayBitmap Then

            _center = New Point3d(Device.BitmapPosition.X, Device.BitmapPosition.Y, 0)

            _size = Device.BitmapSize

            If IO.File.Exists(Device.BitmapPath) Then

                _path = Device.BitmapPath

                _withBitmap = True

            Else
                _withBitmap = False

            End If

        End If

        PurgeJob(withZeropoint:=True)

    End Sub

    ''' <summary>
    ''' converts GeometryObjects To rhinocurves
    ''' </summary>
    Private Function GetConduitObj(ByVal ProxyList As List(Of GeometryObject)) As Rhino.Collections.RhinoList(Of Curve)

        Dim myRhobj As New Rhino.Collections.RhinoList(Of Curve)

        For Each obj As GeometryObject In ProxyList

            Select Case obj.GetType

                Case GetType(Line)

                    Dim myProxyLine As WrkShp.Line = CType(obj, WrkShp.Line)

                    Dim myLineGeom As New Rhino.Geometry.Line(myProxyLine.FirstPoint.X, myProxyLine.FirstPoint.Y, 0.1, myProxyLine.LastPoint.X, myProxyLine.LastPoint.Y, 0.1)

                    myRhobj.Add(myLineGeom.ToNurbsCurve)

            End Select

        Next

        Return myRhobj

    End Function

    ''' <summary>
    ''' the point in rhino to indicate the zero poit of the device bench
    ''' </summary>
    Public Property ZeroPoint As Point3d

        Get

            Return _zeropoint

        End Get

        Set(ByVal value As Point3d)

            If value <> _zeropoint Then

                'Dim myVector As New Vector3d(value - _zeropoint)
                ''myVector = value - _zeropoint

                'For Each crv As Curve In DeviceFixObjects

                '    crv.Translate(myVector)

                'Next

                'For Each crv As Curve In DeviceReferencePointObjects

                '    crv.Translate(myVector)

                'Next

                _zeropoint = value
                Me.MoveTo = _zeropoint
            End If

        End Set

    End Property
    Private _zeropoint As Point3d

    ''' <summary>
    ''' the centerpoint from the workbench
    ''' </summary>
    Private _center As Point3d
    ''' <summary>
    ''' the bigest value of he x and y direction from the workbench
    ''' </summary>
    Private _size As Single

    ''' <summary>
    ''' the path to the camera preview bitmap
    ''' </summary>
    Private _path As String

    Private _withBitmap As Boolean = False


    ''' <summary>
    ''' target point while moving
    ''' </summary>
    Public Property MoveTo As Point3d
        Get

            Return _MoveTo

        End Get

        Set(ByVal value As Point3d)

            If value <> _MoveTo Then

                Dim myVector As New Vector3d(value - _MoveTo)

                If MovingPreviewObjects IsNot Nothing Then

                    For Each crv As Curve In MovingPreviewObjects

                        crv.Translate(myVector)

                    Next

                End If

                _center.Transform(Transform.Translation(myVector))

                _MoveTo = value

            End If

        End Set

    End Property

    Sub SetNewReferencePoint(ByVal Device As CNC_Device)

        DeviceReferencePointObjects = GetConduitObj(Device.ProxyRefPoint)

        For Each crv As Curve In DeviceReferencePointObjects

            crv.Translate(New Vector3d(Device.ReferencePoint.X + Device.ZeroPoint.X, Device.ReferencePoint.Y + Device.ZeroPoint.Y, 0))

        Next

    End Sub

    ''' <summary>
    ''' switch the conduit on without job geomtry
    ''' </summary>
    Sub EnableDevice(ByVal withRefPoint As Boolean)

        If _withBitmap Then
            'Dim myBitmap = New System.Drawing.Bitmap(_path)
            If IO.File.Exists(_path) Then

                Dim mySize As Size = New Size(2304, 1536)


                _TmpPath = IO.Path.GetTempFileName()
                'copy to pretend sharing confilcts
                IO.File.Copy(_path, _TmpPath, True)

                Dim myImage As Image = Image.FromFile(_TmpPath)

                ' m_display_bitmap = New Display.DisplayBitmap(New System.Drawing.Bitmap(_TmpPath, mySize))
                Dim myBitmap As Bitmap = New Bitmap(myImage, mySize)

                m_display_bitmap = New Display.DisplayBitmap(myBitmap)

            End If

        End If

        ShowDevice = True

        RhCwithRefPoint = withRefPoint

        Me.Enabled = True

        RhinoDoc.ActiveDoc.Views.Redraw()

    End Sub

    ''' <summary>
    ''' switch the conduit including the job gemotry on
    ''' </summary>
    Sub EnableJob(ByVal withRefPoint As Boolean)

        ShowDevice = True

        RhCwithRefPoint = withRefPoint

        ShowJob = True

        Me.Enabled = True

        RhinoDoc.ActiveDoc.Views.Redraw()

    End Sub

    ''' <summary>
    ''' hide just the job - not the device
    ''' </summary>
    Sub DisableJob()

        ShowJob = False

        RhCwithRefPoint = False

        RhinoDoc.ActiveDoc.Views.Redraw()

        If IO.File.Exists(_TmpPath) Then
            IO.File.Delete(_TmpPath)
        End If

    End Sub

    ''' <summary>
    ''' hide device and job
    ''' </summary>
    Sub DisableDevice()

        ShowJob = False

        ShowDevice = False
        RhCwithRefPoint = False
        Me.Enabled = False

        RhinoDoc.ActiveDoc.Views.Redraw()

    End Sub

    Private m_display_bitmap As Display.DisplayBitmap
    Protected Overrides Sub DrawOverlay(ByVal e As Display.DrawEventArgs)
        If isMoving Then
            'If _withBitmap AndAlso (m_display_bitmap IsNot Nothing) Then

            '    e.Display.DrawSprite(m_display_bitmap, _center, _size, True)

            'End If

            For Each crv As Curve In MovingPreviewObjects
                ' yellow  is the selection color
                'e.Display.DrawCurve(crv, Color.Yellow, 2)
                e.Display.DrawCurve(crv, Rhino.ApplicationSettings.AppearanceSettings.SelectedObjectColor, 2)

            Next

            If DrawTraceLine Then

                Dim movCrv As New Geometry.Line(MoveFrom, MoveTo + MoveOffset)

                e.Display.DrawLine(movCrv, Color.Black)

            End If
        End If

    End Sub

    ''' <summary>
    ''' this is what will be called when the cunduit is active
    ''' </summary>
    Protected Overrides Sub PostDrawObjects(ByVal e As Display.DrawEventArgs)

        Dim LastPoint As Point3d = _zeropoint

        If ShowJob Then
            'the current object
            If CurrentObject IsNot Nothing Then

                e.Display.DrawCurve(CurrentObject, Color.Purple, 5)

                LastPoint = CurrentObject.PointAtEnd

            End If

            For Each crv As Curve In FutureObjects
                'the furutre is yellow like selected objects

                e.Display.DrawCurve(crv, Color.Yellow)

                Dim aLine As New Rhino.Geometry.Line(crv.PointAtStart, LastPoint)

                'if an object is touching another one, no connection is necassery
                If aLine.Length > 0 Then
                    'the traveling path in gray 
                    e.Display.DrawLine(aLine, Color.Gray)
                    '  e.Display.DrawArrowHead(aLine.PointAt(0), New Vector3d(aLine.PointAt(0) - aLine.PointAt(1)), Color.Gray, 20, 20)

                End If

                LastPoint = crv.PointAtEnd

            Next

            For Each crv As Geometry.Curve In HistoryObjects

                If crv IsNot Nothing Then
                    ' the already cutted objects in  darkgreen 
                    e.Display.DrawCurve(crv, Color.DarkGreen)

                End If

            Next
        End If

        If ShowDevice Then

            If isMoving Then

                'For Each crv As Curve In MovingPreviewObjects
                '    ' yellow  is the selection color
                '    'e.Display.DrawCurve(crv, Color.Yellow, 2)
                '    e.Display.DrawCurve(crv, Rhino.ApplicationSettings.AppearanceSettings.SelectedObjectColor, 2)

                'Next

                'If DrawTraceLine Then

                '    Dim movCrv As New Geometry.Line(MoveFrom, MoveTo + MoveOffset)

                '    e.Display.DrawLine(movCrv, Color.Black)

                'End If
            Else
                For Each crv As Curve In DeviceFixObjects

                    e.Display.DrawCurve(crv, Color.AliceBlue, 2)

                Next

                If RhCwithRefPoint Then

                    For Each crv As Curve In DeviceReferencePointObjects

                        e.Display.DrawCurve(crv, Color.AliceBlue, 2)

                    Next

                End If

            End If
            'e.Display.DrawBitmap(m_display_bitmap, 50, 50)
            If _withBitmap AndAlso (m_display_bitmap IsNot Nothing) Then

                e.Display.DrawSprite(m_display_bitmap, _center, _size, True)

            End If

        End If

    End Sub

    ''' <summary>
    ''' purge all working itmes like paths objets and so
    ''' </summary>
    Sub PurgeJob(ByVal withZeropoint As Boolean)

        HistoryObjects = New Rhino.Collections.RhinoList(Of Geometry.Curve)

        FutureObjects = New Rhino.Collections.RhinoList(Of Geometry.Curve)

        CurrentObject = Nothing

        If withZeropoint Then

            _zeropoint = New Point3d(0, 0, 0)

        End If

        RhinoDoc.ActiveDoc.Views.Redraw()

    End Sub

    ''' <summary>
    ''' creates the preview objects of the device during moving for a new zeropoint
    ''' </summary>
    Sub StartDeviceMoving()

        MovingPreviewObjects = New Rhino.Collections.RhinoList(Of Geometry.Curve)(DeviceFixObjects)

        'For Each crv As Curve In DeviceFixObjects

        '    MovingPreviewObjects.Add(crv.DuplicateCurve)

        'Next

        MovingPreviewObjects.AddRange(DeviceReferencePointObjects)

        'For Each crv As Curve In DeviceReferencePointObjects

        '    MovingPreviewObjects.Add(crv.DuplicateCurve)

        'Next

        isMoving = True

        RhinoDoc.ActiveDoc.Views.Redraw()

    End Sub

    ''' <summary>
    ''' switch the moving Preview objects off
    ''' </summary>
    Sub EndMoving(ByVal Purging As Boolean)

        isMoving = False

        MovingPreviewObjects = Nothing

        If Purging Then

            Me.MoveOffset = New Point3d
            Me.MoveFrom = New Point3d
            Me.MoveTo = New Point3d

        End If

        RhinoDoc.ActiveDoc.Views.Redraw()

    End Sub

    ''' <summary>
    ''' prepares the conduit for working with a mousecallback inside the move job procedere
    ''' </summary>
    Sub StartJobMoving()

        MovingPreviewObjects = New Rhino.Collections.RhinoList(Of Geometry.Curve)

        For Each crv As Curve In FutureObjects

            MovingPreviewObjects.Add(crv.DuplicateCurve)

        Next

        isMoving = True

        RhinoDoc.ActiveDoc.Views.Redraw()

    End Sub

    ''' <summary>
    ''' put the current object to the history
    ''' </summary>
    Sub ObjectFinished()

        Me.HistoryObjects.Add(Me.CurrentObject)

        Me.CurrentObject = Nothing

    End Sub

    ''' <summary>
    ''' sets the next object to curront fur purple colored display and removed them from the future objects
    ''' </summary>
    ''' <returns>the length of the current object for further calculating</returns>
    Function SwitchObjectsInProgressBegin() As Double

        Dim CurrentObjectLength As Double

        Me.CurrentObject = Me.FutureObjects.First

        CurrentObjectLength = Me.CurrentObject.GetLength()

        Me.FutureObjects.Remove(Me.FutureObjects.First)

        RhinoDoc.ActiveDoc.Views.Redraw()

        Return CurrentObjectLength

    End Function

End Class
