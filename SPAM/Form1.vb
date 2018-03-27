
Imports ClassLibrary1
Public Class Form1
    Private myProgram As ClassLibrary1.SPAM
    Private instructionIndex As Integer = -1
    Private instructionLength As Integer = 0
    Private defaultColor As Color = SystemColors.Control
    Private highlightColor As Color = SystemColors.Highlight
    Private WithEvents myInstructions As ReadFile
    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileToolStripMenuItem.Click
        Dim findFile As New OpenFileDialog
        findFile.Title = "Find Instruction File"
        findFile.Filter = "Text Files(*.txt)|*.txt"
        findFile.FilterIndex = 2
        If findFile.ShowDialog = DialogResult.OK Then
            myProgram = New ClassLibrary1.SPAM
            progStart()
            TextBox1.Text = ""
            TextBox1.Text = String.Format("Starting SPAM on {0}" & Environment.NewLine, findFile.FileName)
            myInstructions = New ReadFile
            myInstructions.readFile(findFile.FileName)
        End If

    End Sub
    Private Sub redrawBox(ByVal sender As Object, e As myEventArgs) Handles myInstructions.fileRead
        instructionPanal.Controls.Clear()
        For Each value In e.theInstructions
            Dim label As New Label
            label.Text = value
            instructionPanal.Controls.Add(label)
        Next
        instructionIndex = 0
        instructionLength = instructionPanal.Controls.Count - 1
        processInstruction(instructionIndex)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Console.SetOut(New ConsoleWriter(TextBox1))
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If instructionIndex < 0 Then
            MessageBox.Show("No Program Loaded")
            Exit Sub
        ElseIf instructionIndex > instructionLength Then
            MessageBox.Show("All out of instructions. Load a new program")
            Exit Sub
        End If
        processInstruction(instructionIndex)
    End Sub
    Private Sub processInstruction(index As Integer)
        If index > 0 Then
            instructionPanal.Controls.Item(index - 1).BackColor = defaultColor
        End If
        Dim myControl As Control = instructionPanal.Controls.Item(index)
        myControl.BackColor = highlightColor
        Try
            myProgram.ProcessInstruction(myControl.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            progEnd()
        End Try
        redrawMemroy()
        instructionIndex += 1
        If instructionIndex > instructionLength Then
            progEnd()
        End If
    End Sub
    Private Sub redrawMemroy()
        Dim splitString() As String = myProgram.getMemoryState.Split(Environment.NewLine)
        memoryPanal.Controls.Clear()
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
    Private Sub progStart()
        Button1.Enabled = True
        sizeControl.Enabled = False
        pagesControl.Enabled = False
    End Sub
    Private Sub progEnd()
        Button1.Enabled = False
        sizeControl.Enabled = True
        pagesControl.Enabled = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class
