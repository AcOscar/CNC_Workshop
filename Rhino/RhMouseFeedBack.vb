Imports Rhino
Imports Rhino.Geometry

''' <summary>
''' a simple MousCallback implentation
''' </summary>
Public Class RhMouseFeedBack
    Inherits Rhino.UI.MouseCallback

    ''' <summary>
    ''' the conduit to display
    ''' </summary>
    ''' <remarks>make sure that is a simple conduit it will hang on the mouse</remarks>
    Property Conduit As rhDisplayConduit

    Protected Overrides Sub OnMouseMove(ByVal e As UI.MouseCallbackEventArgs)

        Dim pick_context As Input.Custom.PickContext = New Input.Custom.PickContext With {
            .View = e.View,
            .PickStyle = Input.Custom.PickStyle.PointPick
        }

        Dim xform As Transform = RhinoDoc.ActiveDoc.Views.ActiveView.ActiveViewport.GetPickTransform(e.ViewportPoint)

        pick_context.SetPickTransform(xform)

        Dim pick_line As Line

        pick_context.View.ActiveViewport.GetFrustumLine(e.ViewportPoint.X, e.ViewportPoint.Y, pick_line)

        pick_context.PickLine = pick_line

        pick_context.UpdateClippingPlanes()

        Conduit.MoveTo = CType(pick_context.PickLine.From - Conduit.MoveOffset, Point3d)

        MyBase.OnMouseMove(e)

    End Sub

End Class