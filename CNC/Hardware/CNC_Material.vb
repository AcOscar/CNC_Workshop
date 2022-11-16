''' <summary>
''' a material to work with it
''' </summary>
Public Class CNC_Material

    ''' <summary>
    ''' the well readable name for the material, it is not unique
    ''' </summary>
    ReadOnly Property Name As String
        Get

            Return _Name

        End Get

    End Property

    ''' <summary>
    ''' a short unique id for the matrial
    ''' </summary>
    ReadOnly Property ID As String
        Get

            Return _ID

        End Get

    End Property

    ''' <summary>
    ''' a list with all (ids) of applicable tools to cut the material
    ''' </summary>
    ReadOnly Property BBoxTool As List(Of String)
        Get

            Return _BBoxTool

        End Get

    End Property

    ''' <summary>
    ''' settings 
    ''' </summary>
    ReadOnly Property ToolSettings As List(Of CNC_ToolSetting)
        Get

            Return _ToolSettings

        End Get

    End Property

    Private _ID As String
    Private _Name As String
    Private _BBoxTool As List(Of String)
    Private _ToolSettings As List(Of CNC_ToolSetting)

    ''' <summary>
    ''' read all material settings from a xml
    ''' </summary>
    Function ReadXML(ByVal xMaterial As XElement) As Boolean

        ReadXML = False

        _ID = xMaterial.Attribute("id").Value

        _Name = xMaterial.Attribute("display").Value

        _BBoxTool = New List(Of String)

        Dim myTools As String = xMaterial.Attribute("BoundBoxTool").Value

        For Each bbt As String In myTools.Split(","c)

            BBoxTool.Add(bbt)

        Next

        _ToolSettings = New List(Of CNC_ToolSetting)

        For Each xtoolsetting As XElement In xMaterial.Descendants("toolsettings")

            Dim myToolSetting As New CNC_ToolSetting

            If myToolSetting.GetConfig(xtoolsetting) Then

                ToolSettings.Add(myToolSetting)

            End If
        Next

        If ID Is Nothing Then Return False Else Return True

    End Function

    ''' <summary>
    ''' returns a string representing the object
    ''' </summary>
    ''' <returns>the material name as string</returns>
    Overrides Function ToString() As String

        Return Name

    End Function

End Class
