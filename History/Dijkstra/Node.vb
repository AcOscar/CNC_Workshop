Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class Node
    Property Name As String

    ''' <summary>
    ''' Konstruktor
    ''' </summary>
    ''' <param name="name">Name des Knotens</param>
    Public Sub New(ByVal name As String)
        Me._name = name
    End Sub

End Class
