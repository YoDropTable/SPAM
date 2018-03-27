Imports ClassLibrary1
Module Module1
    Private myInstruction As ReadFile
    Sub Main()
        myInstruction = New ReadFile
        myInstruction.readFile(CurDir() + "\TestFile.txt")
        Dim mySPAM As New SPAM()
        For i = 0 To 4
            Dim temp As String
            temp = myInstruction.getInstruction
            Console.WriteLine(temp)
            mySPAM.ProcessInstruction(temp)
            Console.WriteLine(mySPAM.getMemoryState())
        Next
        Console.WriteLine("ENDOFLINE")
    End Sub
End Module
