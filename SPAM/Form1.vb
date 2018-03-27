''Imports my SPAM DLL
Imports ClassLibrary1

''' <summary>
''' Main Form Class
''' </summary>
Public Class Form1
    ''The BRAINS behind the hole thing
    Private myProgram As ClassLibrary1.SPAM

    ''Index of what instruction we are one
    ''Used to track GUI highlighting
    Private instructionIndex As Integer = -1
    ''Index for the number of instructions
    ''Tired of checking the main class or
    '' the count inside of the panal
    Private instructionLength As Integer = 0

    ''Default system control color
    Private defaultColor As Color = SystemColors.Control

    ''Color used for highlighting label control
    Private highlightColor As Color = SystemColors.Highlight

    ''Gets the instructions from a file
    Private WithEvents myInstructions As ReadFile

    ''' <summary>
    ''' Used to handle the click event on the open button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' What clicked it
    ''' <param name="e"></param>
    ''' event arguments
    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileToolStripMenuItem.Click
        Dim findFile As New OpenFileDialog
        findFile.Title = "Find Instruction File"
        findFile.Filter = "Text Files(*.txt)|*.txt"
        findFile.FilterIndex = 2
        If findFile.ShowDialog = DialogResult.OK Then
            myProgram = New ClassLibrary1.SPAM(sizeControl.Value, pagesControl.Value)
            progStart()
            TextBox1.Text = ""
            TextBox1.Text = String.Format("Starting SPAM on {0}" & Environment.NewLine, findFile.FileName)
            myInstructions = New ReadFile
            myInstructions.readFile(findFile.FileName)
        End If
    End Sub


    ''' <summary>
    ''' Redraw instruction box.
    ''' Picks up the event from readFile and draws
    ''' the control and highlights the first label
    ''' and process the instrucion
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub redrawBox(ByVal sender As Object, e As myEventArgs) Handles myInstructions.fileRead
        ''Clears Panal in case this is a ReRun of something
        instructionPanal.Controls.Clear()

        ''For every command inside of instructions
        ''we create a label and add it to the paanl
        For Each value In e.theInstructions
            Dim label As New Label
            label.Text = value
            instructionPanal.Controls.Add(label)
        Next

        ''Set the Index and number of instructions
        instructionIndex = 0
        instructionLength = instructionPanal.Controls.Count - 1

        ''Process first insturction
        processInstruction(instructionIndex)
    End Sub

    ''' <summary>
    ''' Handles the form load event
    ''' its when the form is first createed but after a new event
    ''' used to grab the console write events and push them to the 
    ''' text box with the consolewrite class
    ''' </summary>
    ''' <param name="sender"></param>
    ''' The thing that does it? Google it yo
    ''' <param name="e"></param>
    ''' Event arguments
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Console.SetOut(New ConsoleWriter(TextBox1))
    End Sub

    ''' <summary>
    ''' Handles the next button click
    ''' Grabs the next instruction
    ''' does a little checking
    ''' </summary>
    ''' <param name="sender"></param>
    ''' the thing that raised the action
    ''' normally a mouse cilck. its a thing
    ''' <param name="e"></param>
    ''' event argumetns like where the mouse is
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles NextBTN.Click
        ''Check if there is instructions loaded
        ''-1 is nothing
        If instructionIndex < 0 Then
            MessageBox.Show("No Program Loaded")
            Exit Sub
            ''Check if we have done everything we needed to
        ElseIf instructionIndex > instructionLength Then
            MessageBox.Show("All out of instructions. Load a new program")
            Exit Sub
        End If
        ''Process Next Instruction
        processInstruction(instructionIndex)
    End Sub

    ''' <summary>
    ''' Process the instruction we are on
    ''' then increment index so we process the next one
    ''' will catch exceptions thrown by SPAM and report them
    ''' to the user. If there is an exception it stops SPAM
    ''' so you can run another one
    ''' </summary>
    ''' <param name="index"></param>
    ''' Index of the instruction we are one
    Private Sub processInstruction(index As Integer)

        '' if we are not on the first index we can make the previous
        ''index the default color. Used for highlighting
        If index > 0 Then
            instructionPanal.Controls.Item(index - 1).BackColor = defaultColor
        End If

        ''Didn't want to type something instructionPanal.Controls.Item(index) each time
        ''Made a temporary point to the control. Realize now i could have just typed
        ''it and not have to comment on it. This is the very definiation of irony
        '' i'm laughing i hope you are too. 
        Dim myControl As Control = instructionPanal.Controls.Item(index)

        ''Highlights the new instruction
        myControl.BackColor = highlightColor

        ''Process the instruction
        ''reports an error if encoutered
        ''SPAM normally throws ArgumentException
        ''all other errors need to be dealt with
        Try
            myProgram.ProcessInstruction(myControl.Text)
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message)
            progEnd()
        End Try

        ''Redraws the memory from the memory printout
        redrawMemroy()

        ''increment instruciton
        instructionIndex += 1

        ''If we are at the end of the program
        ''we need to enable and disable some buttons
        If instructionIndex > instructionLength Then
            progEnd()
        End If
    End Sub

    ''' <summary>
    ''' I was kinda proud of this one
    ''' didn't want to have to pass all the memory objects back
    ''' but i had a string from testin on console
    ''' looped through the string and made some labels that go to the panal
    ''' boom output in a GUI
    ''' </summary>
    Private Sub redrawMemroy()
        ''Grabs the long string from Memory 
        ''Splits it by new line \n
        Dim splitString() As String = myProgram.getMemoryState.Split(Environment.NewLine)
        ''Clears any controls - Thus a redraw
        memoryPanal.Controls.Clear()

        ''craetes the label to add to the panal
        For Each memoryPage In splitString
            Dim label As New Label
            With label
                .Text = memoryPage
                .AutoSize = True
                .Padding = New Padding(5, 3, 5, 3)
            End With
            memoryPanal.Controls.Add(label)
        Next
    End Sub

    ''' <summary>
    ''' when the program is started it enables and disables
    ''' some buttons. I just like doing it. :) 
    ''' </summary>
    Private Sub progStart()
        NextBTN.Enabled = True
        sizeControl.Enabled = False
        pagesControl.Enabled = False
        StopBtn.Enabled = True
    End Sub

    ''' <summary>
    ''' When the program ends we reenable some buttons
    ''' don't want to error check on random clicks so this
    ''' is easier. GUI sucks. You have to program for window
    ''' lickers
    ''' </summary>
    Private Sub progEnd()
        NextBTN.Enabled = False
        StopBtn.Enabled = False
        sizeControl.Enabled = True
        pagesControl.Enabled = True
    End Sub


    ''' <summary>
    ''' Handles when the exit toolbar is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' Look above somewhere
    ''' <param name="e"></param>
    ''' event argumetns like where the mouse is
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub


    ''' <summary>
    ''' Handles whent eh stop button is clicked to 
    ''' enable and disable some buttons
    ''' </summary>
    ''' <param name="sender"></param>
    ''' I have no clue
    ''' <param name="e"></param>
    ''' Visual studio created this code for me
    ''' if i could not put it in there i wouldn't
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles StopBtn.Click
        progEnd()
    End Sub
End Class
