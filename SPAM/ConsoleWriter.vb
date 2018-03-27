Imports System.Text
''' <summary>
''' Inherets IO.writer
''' Overrides the normal control
''' to recieve CONSOLE write information
''' Didn't want to grab the console messages
''' fromt he DLL. THIS DOES THAT :) 
''' Foudn this on stack overflow somewhere
''' don't remember where it was a while back when
''' i first started working.. SO SO long ago
''' </summary>
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
