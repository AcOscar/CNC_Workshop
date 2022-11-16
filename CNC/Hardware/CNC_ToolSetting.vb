''' <summary>
''' 
''' </summary>
Public Class CNC_ToolSetting

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property ID As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property Text As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property SpeedUp As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property SpeedDown As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property ZposUp As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property ZposDown As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property PreTool As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property PostTool As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property PowerWork As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property PowerMin As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property PowerRecess As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property InteruptionTime As String = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="override"></param>
    ''' <returns></returns>
    Function GetConfig(ByVal override As Xml.Linq.XElement) As Boolean

        For Each att In override.Attributes
            Select Case att.Name.ToString.ToLower

                Case "id"
                    ID = att.Value.ToString

                Case "text"
                    Text = att.Value.ToString

                Case "speedup"
                    SpeedUp = att.Value.ToString

                Case "speeddown"
                    SpeedDown = att.Value.ToString

                Case "zposup"
                    ZposUp = att.Value.ToString

                Case "zposdown"
                    ZposDown = att.Value.ToString

                Case "pretool"
                    PreTool = att.Value.ToString

                Case "posttool"
                    PostTool = att.Value.ToString

                Case "powerwork"
                    PowerWork = att.Value.ToString

                Case "powermin"
                    PowerMin = att.Value.ToString

                Case "powerrecess"
                    PowerRecess = att.Value.ToString

                Case "interuptiontime"
                    InteruptionTime = att.Value.ToString

            End Select

        Next

        If ID Is Nothing Then Return False Else Return True

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String

        Return ID

    End Function

End Class
