''' <summary>
''' //============================================================================================================
''' System  : SPAM
''' File    : ReadFile.vb
''' Author  : PhilGarza (garzap@mail.gvsu.edu)
''' Updated : 3/26/2018
''' 
''' ReadFile Class is kind of the driver
''' It reads the file of commands
''' It was initally going to do only that
''' has been modified to house the lines of each 
''' command and grab them as needed
''' ==============================================================================================================
''' </summary>
Public Class ReadFile
    ''List of instructions borken down by line
    Private processInstructions As List(Of String)

    ''Index of the command we are one
    Private index As Integer

    ''Used to flag the GUI that instructions were read
    Public Event fileRead As EventHandler(Of myEventArgs)


    ''' <summary>
    ''' Reads the file and loads the instructions
    ''' into the list of instructions
    ''' </summary>
    ''' <param name="filename"></param>
    ''' the filename to read
    Public Sub readFile(ByVal filename As String)
        ''creates a stream reader
        Dim reader As IO.StreamReader

        ''oepsn the file for the stream reader
        reader = My.Computer.FileSystem.OpenTextFileReader(filename)

        ''Temp string for each line of text
        Dim lineOfFile As String

        ''Iniitiazlies a new list of commands
        processInstructions = New List(Of String)

        ''While loop to read until end of file
        While Not reader.EndOfStream
            ''reads line
            lineOfFile = reader.ReadLine
            ''Adds to list of instructions
            processInstructions.Add(lineOfFile)
        End While
        ''close the file
        reader.Close()
        ''deallocate resources from stream reader
        reader.Dispose()

        ''This is used for the GUI
        ''Was more of me messing around with something
        ''to see how it works
        ''Create new event argument to pass as an event
        ''Thought i would need this for memory changes
        ''but went another way with that
        Dim e As New myEventArgs
        ''Basiaclly all the insturctions are passed as an event
        e.theInstructions = processInstructions
        ''Raise the event for the GUI
        RaiseEvent fileRead(Me, e)
    End Sub

    ''' <summary>
    ''' Overrides the normal To String
    ''' gets all the instructions in one big text
    ''' used for testing
    ''' </summary>
    ''' <returns>All the instructions in on string</returns>
    Public Overrides Function ToString() As String
        Dim returnString As String = ""
        For Each value In processInstructions
            returnString += value + Environment.NewLine
        Next
        Return returnString
    End Function

    ''' <summary>
    ''' Gets the instruction
    ''' and increments the index
    ''' Will throw an outof bounds error
    ''' Does not remeove it
    ''' may need it for undo method
    ''' </summary>
    ''' <returns>the instruction at the next index</returns>
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

''' <summary>
''' New Event that inherents EventArgs
''' Used to pass the instruction list as
''' an event tot he GUI
''' </summary>
Public Class myEventArgs
    Inherits EventArgs
    Public Property theInstructions As List(Of String)
End Class
