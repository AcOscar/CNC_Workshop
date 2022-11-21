Public Class CNC_Property

    Public Property ID As String

    Public Property Name As String

    Public Property Value As Double

    Private _DefaultValue As Double

    Public Overrides Function ToString() As String

        Return ID

    End Function

    Public ReadOnly Property DefaultValue As Double

        Get

            Return _DefaultValue

        End Get

    End Property

    Public Property X As Double

    Public Property Y As Double

    Public Property Text As String

    Public Property Min As Double

    Public Property Max As Double

    Public Property IsHidden As Boolean

    Public Property DisplayFactor As Double

    Public Property DisplayIncrement As Decimal

    Public Property DisplayDecimalPlaces As Integer


    Function GetConfig(ByVal myProp As XElement) As Boolean

        For Each att As XAttribute In myProp.Attributes

            Select Case att.Name.ToString.ToLower

                Case "id"
                    ID = myProp.Attribute("id").Value.ToString

                Case "value"
                    Value = Convert.ToDouble(myProp.Attribute("value").Value.ToString)
                    _DefaultValue = Value

                Case "x"
                    X = Convert.ToDouble(myProp.Attribute("x").Value.ToString)

                Case "y"
                    Y = Convert.ToDouble(myProp.Attribute("y").Value.ToString)

                Case "text"
                    Text = myProp.Attribute("text").Value.ToString

                Case "language"
                    Text = myProp.Attribute("text").Value.ToString

                Case "min"
                    Min = Convert.ToDouble(myProp.Attribute("min").Value.ToString)

                Case "max"
                    Max = Convert.ToDouble(myProp.Attribute("max").Value.ToString)

                Case "ishidden"
                    IsHidden = Convert.ToBoolean(myProp.Attribute("ishidden").Value.ToString)

                Case "displayfactor"
                    DisplayFactor = Convert.ToDouble(myProp.Attribute("displayfactor").Value.ToString)

                Case "displayincrement"
                    DisplayIncrement = Convert.ToDecimal(myProp.Attribute("displayincrement").Value.ToString)

                Case "displaydecimalplaces"
                    DisplayDecimalPlaces = Convert.ToInt32(myProp.Attribute("displaydecimalplaces").Value.ToString)

            End Select

        Next

        If ID Is Nothing Then Return False Else Return True

    End Function

    Public Sub New()

        DisplayFactor = 1

    End Sub

End Class
