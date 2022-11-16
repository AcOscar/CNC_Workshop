Imports Rhino

<System.Runtime.InteropServices.Guid("ABF1E6BE-ED58-4A13-8226-FADFECC884B1")>
Public Class Command_CNC_WorkShop
    Inherits Rhino.Commands.Command

    Shared _instance As Command_CNC_WorkShop

    Public Sub New()
        _instance = Me
    End Sub

    Public Shared ReadOnly Property Instance() As Command_CNC_WorkShop
        Get
            Return _instance
        End Get
    End Property

    Public Overrides ReadOnly Property EnglishName() As String
        Get
            Return "CNC_WorkShop"
        End Get
    End Property

    Protected Overrides Function RunCommand(ByVal doc As Rhino.RhinoDoc, ByVal mode As Rhino.Commands.RunMode) As Rhino.Commands.Result
        WrkShp.RhPlugin.Instance.ToogleMainPanel()
        Return Rhino.Commands.Result.Success
    End Function


End Class

<System.Runtime.InteropServices.Guid("b7df7d34-361a-4dcd-a7b8-2417fecf1703")>
Public Class Command_CNC_OpenPanel
    Inherits Rhino.Commands.Command
    'Test
    Shared _instance As Command_CNC_OpenPanel

    Public Sub New()
        _instance = Me
    End Sub

    Public Shared ReadOnly Property Instance() As Command_CNC_OpenPanel
        Get
            Return _instance
        End Get
    End Property

    Public Overrides ReadOnly Property EnglishName() As String
        Get
            Return "CNC_OpenPanel"
        End Get
    End Property

    Protected Overrides Function RunCommand(ByVal doc As Rhino.RhinoDoc, ByVal mode As Rhino.Commands.RunMode) As Rhino.Commands.Result

        WrkShp.RhPlugin.Instance.OpenPanel()

        Return Rhino.Commands.Result.Success

    End Function

End Class

<System.Runtime.InteropServices.Guid("e4e2db57-8071-4755-ad82-8fee6f6e0e97")>
Public Class Command_CNC_ReloadWorkshop
    Inherits Rhino.Commands.Command

    Shared _instance As Command_CNC_ReloadWorkshop

    Public Sub New()
        _instance = Me
    End Sub

    Public Shared ReadOnly Property Instance() As Command_CNC_ReloadWorkshop
        Get
            Return _instance
        End Get
    End Property

    Public Overrides ReadOnly Property EnglishName() As String
        Get
            Return "CNC_ReloadWorkshop"
        End Get
    End Property

    Protected Overrides Function RunCommand(ByVal doc As Rhino.RhinoDoc, ByVal mode As Rhino.Commands.RunMode) As Rhino.Commands.Result

        WrkShp.RhPlugin.Instance.ReloadWorkshop()

        Return Rhino.Commands.Result.Success

    End Function

End Class

'HOR leaving remove the camera stuff

'<Guid("3AB23D3F-D5F2-4EEC-9982-219AFBBF3BC7")>
'Public Class Command_CNC_Camera
'    Inherits Rhino.Commands.Command

'    Shared _instance As Command_CNC_Camera

'    Public Sub New()
'        _instance = Me
'    End Sub

'    Public Shared ReadOnly Property Instance() As Command_CNC_Camera
'        Get
'            Return _instance
'        End Get
'    End Property

'    Public Overrides ReadOnly Property EnglishName() As String
'        Get
'            Return "CNC_Camera"
'        End Get
'    End Property

'    Protected Overrides Function RunCommand(ByVal doc As Rhino.RhinoDoc, ByVal mode As Rhino.Commands.RunMode) As Rhino.Commands.Result

'        WrkShp.RhPlugin.Instance.Camera()

'        Return Rhino.Commands.Result.Success

'    End Function

'End Class

