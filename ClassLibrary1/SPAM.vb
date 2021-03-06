﻿''' <summary>
''' //============================================================================================================
''' System  : SPAM
''' File    : SPAM.vb
''' Author  : PhilGarza (garzap@mail.gvsu.edu)
''' Updated : 3/26/2018
''' 
''' This is the whole brian behind everything
''' When a instrucxtion comes in it parses it and sees what you want todo
''' then it checks the pageTable to see where its at
''' then it does stuff to memory
''' ==============================================================================================================
''' </summary>
Public Class SPAM
    ''Phyiscal Memory Variable
    Private myMemory As PhysicalMemory

    ''Page Table Variable
    Private memoryTableLookUP As PageTable
    Private swapSpace As List(Of PageTable.PageTableItems)

    ''' <summary>
    ''' Initiazlies a new run of SPAM
    ''' Using default values. used for console
    ''' and testing
    ''' </summary>
    Public Sub New()
        myMemory = New PhysicalMemory
        memoryTableLookUP = New PageTable
        swapSpace = New List(Of PageTable.PageTableItems)
    End Sub

    ''' <summary>
    ''' Creates a new run of SMAP with 
    ''' non default values
    ''' </summary>
    ''' <param name="size"></param>
    ''' size of each page file
    ''' <param name="numOfBlocks"></param>
    ''' number of page files
    Public Sub New(ByVal size As Integer, numOfBlocks As Integer)
        myMemory = New PhysicalMemory(size, numOfBlocks)
        memoryTableLookUP = New PageTable
        swapSpace = New List(Of PageTable.PageTableItems)
    End Sub

    ''' <summary>
    ''' Parses the command to see what you are tyring todo
    ''' </summary>
    ''' <param name="command"></param>
    Public Sub ProcessInstruction(ByVal command As String)
        ''Takes the command and splits it by the spaces
        Dim splitString() As String
        splitString = command.Split(" ")

        ''If there are 3 arguemtns its a fill command
        If splitString.Count = 3 Then
            Dim processID, codesize, datasize As Integer
            Try
                ''Because we are reading from a file
                ''it sometimes had a bad file. i did this
                '' so that it schecks to make sure nothing
                '' bad happened like a space to a integer
                '' that breaks applications
                processID = Convert.ToInt32(splitString(0))
                codesize = Convert.ToInt32(splitString(1))
                datasize = Convert.ToInt32(splitString(2))
            Catch ex As InvalidCastException
                '' Throws a new argument exception if its bad
                ''and tells you which command threw the error
                Throw New ArgumentException(String.Format("Problem with file command {0}", command))
            End Try
            ''Runs the add memory routine
            addMemory(processID, codesize, datasize)
            Exit Sub
            ''If there are 2 and the second one is -1 then its a remove memory
        ElseIf splitString.Count = 2 Then
            Dim myId As Integer = splitString(0)
            If splitString(1).Equals("-1") Then
                ''runs the free memroy routine
                freeUpMemory(myId)
                Exit Sub
            End If
        End If
        ''if it gets here it errored
        ''Everything else is an error
        Throw New ArgumentException("Bad Command")
    End Sub

    ''' <summary>
    ''' Frees up memory from the Physical Memory
    ''' Looks at the table lookup
    ''' gets all the physical addresses for that process
    ''' and sends them to physical memory to free them
    ''' </summary>
    ''' <param name="processID"></param>
    ''' Process we are tyring to free up memory for
    Private Sub freeUpMemory(ByVal processID As Integer)
        ''Writes what we are doing to the console
        Console.WriteLine("Freeing up Memory PID {0}", processID)
        ''Looks up the process id in the look up table
        If memoryTableLookUP.findProcess(processID) Then
            ''grabs all of its addresses
            Dim addressesToRemove As List(Of Integer) = memoryTableLookUP.getMemoryAddress(processID)
            ''frees up those addresses
            myMemory.freeMemory(addressesToRemove)
            ''removes it from the look up table
            ''forgot this once it broke
            memoryTableLookUP.removeProcess(processID)
        ElseIf findDiskProcess(processID) Then
            For Each item In swapSpace.ToList
                If item.ProcessID = processID Then
                    Console.WriteLine("Removing from Disk PID {0} ", processID)
                    swapSpace.Remove(item)
                End If
            Next
        Else
            ''If it wasn't in the table something was wrong
            Throw New ArgumentException("Process Not In Memory")
        End If
    End Sub

    ''' <summary>
    ''' Adds a process to phyiscal memory
    ''' Check the process table so their isn't 2
    ''' with the same name
    ''' then grabs the number of pages for code and data
    ''' adds them to moemory
    ''' Checks the amount of free memory
    ''' will no longer need this when disk access is used
    ''' </summary>
    ''' <param name="processID"></param>
    ''' Process ID of the application we are adding
    ''' <param name="codeSize"></param>
    ''' size in bytes of the code
    ''' <param name="dataSize"></param>
    ''' size in bytes of the data
    Private Sub addMemory(ByVal processID As Integer, codeSize As Integer, dataSize As Integer)
        ''Sees how many pages we need for code
        Dim codePages As Integer = Math.Ceiling(codeSize / myMemory.getBlockSize)
        ''sees how many pages we need for data
        Dim dataPages As Integer = Math.Ceiling(dataSize / myMemory.getBlockSize)

        ''Checks the table and make sure it isn't in there
        If Not memoryTableLookUP.findProcess(processID) Then
            ''Check if we have enough memory.
            If (dataPages + codePages) <= myMemory.getPageFileCount Then
                ''Adds it to free emmeory and gets the addresses we added it to
                While (dataPages + codePages) > myMemory.getFreeBlocks
                    Dim swapToDisk As PageTable.PageTableItems = memoryTableLookUP.freeUpMemory
                    freeUpMemory(swapToDisk.ProcessID)
                    Console.WriteLine("Moving PID {0} to Disk Space {1} Pages of Code {2} Pages of data", swapToDisk.ProcessID, swapToDisk.myPageTableCode.Count, swapToDisk.myPageTableData.Count)
                    swapSpace.Add(swapToDisk)
                End While
                Dim codePagesList As List(Of Integer) = myMemory.AddProcessCodeToMemory(processID, codePages)
                Dim dataPagesList As List(Of Integer) = myMemory.AddProcessDataToMemory(processID, dataPages)
                ''puts them in the look up table
                memoryTableLookUP.addProcces(processID, codePagesList, dataPagesList)
            Else
                Throw New ArgumentException("No Enough Total Memory")
            End If
        Else
            Throw New ArgumentException("Process already in memory")
        End If
        ''writes what its doing to the console
        Console.WriteLine("PID: {0} arrives: {1} Pages of Code {2} Pages of data", processID, codePages, dataPages)
    End Sub


    ''' <summary>
    ''' Finds the associated process in the disk space
    ''' </summary>
    ''' <returns>True or false depnding if it finds the value</returns>
    Public Function findDiskProcess(processID As Integer) As Boolean
        For Each item In swapSpace
            If item.ProcessID = processID Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Gets a readout of the current memory state to print out to console
    ''' also used in the GUI :) 
    ''' </summary>
    ''' <returns>a string of all the memory states</returns>
    Public Function getMemoryState() As String
        Return myMemory.ToString
    End Function

    ''' <summary>
    ''' Gets a readout of the current memory state to print out to console
    ''' also used in the GUI :) 
    ''' </summary>
    ''' <returns>a string of all the memory states</returns>
    Public Function getDiskState() As String
        Dim returnString As String = ""
        For Each item In swapSpace
            returnString += String.Format("PID: {0} CodePages: {1} DataPages: {2}", item.ProcessID, item.myPageTableCode.Count, item.myPageTableData.Count) & vbNewLine
        Next
        Return returnString
    End Function
End Class
