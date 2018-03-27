Imports System.Text

Public Class ConsoleWriter
    Inherits IO.TextWriter
    Private textBox As Control

    Public Sub New(paramTextBox As Control)
        Me.textBox = paramTextBox
    End Sub

    Public Overrides ReadOnly Property Encoding As Encoding
        Get
            Return Encoding.ASCII
        End Get
    End Property

    Public Overrides Sub Write(value As Char)
        textBox.Text += value
    End Sub

    Public Overrides Sub Write(value As String)
        textBox.Text += value
    End Sub
End Class
