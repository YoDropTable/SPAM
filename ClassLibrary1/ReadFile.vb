
Public Class ReadFile
    Private processInstructions As List(Of String)
    Private index As Integer
    Public Event fileRead As EventHandler(Of myEventArgs)

    Public Sub readFile(ByVal filename As String)
        Dim reader As IO.StreamReader
        reader = My.Computer.FileSystem.OpenTextFileReader(filename)
        Dim lineOfFile As String
        processInstructions = New List(Of String)
        While Not reader.EndOfStream
            lineOfFile = reader.ReadLine
            processInstructions.Add(lineOfFile)
        End While
        reader.Close()
        reader.Dispose()
        Dim e As New myEventArgs
        e.theInstructions = processInstructions
        RaiseEvent fileRead(Me, e)
    End Sub
    Public Overrides Function ToString() As String
        Dim returnString As String = ""
        For Each value In processInstructions
            returnString += value + Environment.NewLine
        Next
        Return returnString
    End Function
    Public Function getInstruction() As String
        If index = processInstructions.Count - 1 Then
            Throw New IndexOutOfRangeException("No More Instructions")
        End If
        Dim returnString As String
        returnString = processInstructions.Item(index)
        index += 1
        Return returnString
    End Function
End Class
Public Class myEventArgs
    Inherits EventArgs
    Public Property theInstructions As List(Of String)
End Class
