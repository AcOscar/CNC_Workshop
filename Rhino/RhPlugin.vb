Imports Rhino

Public Class RhPlugin

    Inherits Rhino.PlugIns.PlugIn

    Shared _instance As RhPlugin

    Public Shared WrapperGUID As Guid

    Public Sub New()

        _instance = Me

        WrapperGUID = GetType(UIWrapper).GUID

    End Sub

    Protected Overrides Function OnLoad(ByRef errorMessage As String) As Rhino.PlugIns.LoadReturnCode

        Rhino.UI.Panels.RegisterPanel(Me, GetType(UIWrapper), "CNC Workshop", My.Resources.CNC)

        Return Rhino.PlugIns.LoadReturnCode.Success

    End Function

    Public Shared ReadOnly Property Instance() As RhPlugin

        Get

            Return _instance

        End Get

    End Property

    Public Sub ToogleMainPanel()

        If Rhino.UI.Panels.IsPanelVisible(WrapperGUID) Then

            ClosePanel()

        Else

            OpenPanel()

        End If

    End Sub

    Sub OpenPanel()

        If Not Rhino.UI.Panels.IsPanelVisible(WrapperGUID) Then

            Rhino.UI.Panels.OpenPanel(WrapperGUID)

        End If

    End Sub

    Function ClosePanel() As UIWrapper

        Dim myPanel As UIWrapper

#Disable Warning BC40000 ' Type or member is obsolete
        myPanel = CType(Rhino.UI.Panels.GetPanel(WrapperGUID), UIWrapper)
#Enable Warning BC40000 ' Type or member is obsolete


        If myPanel IsNot Nothing Then

            If myPanel.WorkShop IsNot Nothing Then

                myPanel.WorkShop.Disconnect()


            End If

        End If

        Rhino.UI.Panels.ClosePanel(WrapperGUID)

        Return myPanel

    End Function

    Sub ReloadWorkshop()

        Dim myPanel As UIWrapper

        myPanel = ClosePanel()

        LogFile.Close()

        ReloadWorkshop(myPanel)

        OpenPanel()

    End Sub

    Sub ReloadWorkshop(UIPanel As UIWrapper)

        If UIPanel IsNot Nothing Then

            UIPanel.RhinoWorker.Conduit.DisableDevice()

            UIPanel.Initialize()

            UIPanel.RefreshControls()

        End If

    End Sub

    'HOR leaving remove the camera stuff
    'Friend Sub Camera()

    '    Dim myPanel As UIWrapper

    '    myPanel = ClosePanel()

    '    ReloadWorkshop(myPanel)

    '    Dim myCamFrm As New RhCameraSetup With {
    '        .Device = myPanel.WorkShop.CurrentDevice
    '    }

    '    myCamFrm.ShowDialog()

    'End Sub

End Class
