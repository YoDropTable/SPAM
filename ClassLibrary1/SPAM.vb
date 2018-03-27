Public Class SPAM
    Private myMemory As PhysicalMemory
    Private tableLkUp As PageTable
    Public Sub New()
        myMemory = New PhysicalMemory
        tableLkUp = New PageTable
    End Sub
    Public Sub New(ByVal size As Integer, numOfBlocks As Integer)
        myMemory = New PhysicalMemory(size, numOfBlocks)
        tableLkUp = New PageTable
    End Sub
    Public Sub ProcessInstruction(ByVal command As String)
        Dim splitString() As String
        splitString = command.Split(" ")
        If splitString.Count = 3 Then
            addMemory(splitString(0), splitString(1), splitString(2))
            Exit Sub
        ElseIf splitString.Count = 2 Then
            Dim myId As Integer = splitString(0)
            If splitString(1).Equals("-1") Then
                freeUpMemory(myId)
                Exit Sub
            End If
        End If
        Throw New ArgumentException("Bad Command")
    End Sub
    Private Sub freeUpMemory(ByVal processID As Integer)
        Console.WriteLine("Freeing up Memory PID {0}", processID)
        If tableLkUp.findProcess(processID) Then
            Dim addressesToRemove As List(Of Integer) = tableLkUp.getMemoryAddress(processID)
            myMemory.freeMemory(addressesToRemove)
            tableLkUp.removeProcess(processID)
        Else
            Throw New ArgumentException("Process Not In Memory")
        End If
    End Sub
    Private Sub addMemory(ByVal processID As Integer, codeSize As Integer, dataSize As Integer)
        Dim codePages As Integer = Math.Ceiling(codeSize / myMemory.getBlockSize)
        Dim dataPages As Integer = Math.Ceiling(dataSize / myMemory.getBlockSize)
        If Not tableLkUp.findProcess(processID) Then
            If (dataPages + codePages) <= myMemory.getFreeBlocks Then
                Dim myPageTable As List(Of Integer) = myMemory.AddProcessToMemory(processID, codePages, dataPages)
                tableLkUp.addProcces(processID, myPageTable)
            Else
                Throw New ArgumentException("No Free Memory")
            End If
        Else
            Throw New ArgumentException("Process already in memory")
        End If
        Console.WriteLine("PID: {0} arrives: {1} Pages of Code {2} Pages of data", processID, codePages, dataPages)
    End Sub
    Public Function getMemoryState() As String
        Return myMemory.ToString
    End Function
End Class
