''' <summary>
''' //============================================================================================================
''' System  : SPAM
''' File    : PageTable.vb
''' Author  : PhilGarza (garzap@mail.gvsu.edu)
''' Updated : 3/26/2018
''' 
''' The Page Table Class
''' Holds all process currenly in 
''' physical memory
''' 
''' Its is defined as a list of
''' PageTableItems Sctructures
''' ==============================================================================================================
''' </summary>
Public Class PageTable
    ''' <summary>
    ''' Page Table Item That holds
    ''' the Process ID and a list of 
    ''' pages in Physical Memory
    ''' Split into Code and Data 
    ''' Segements
    ''' </summary>
    Public Structure PageTableItems
        Public ProcessID As Integer
        Public myPageTableCode As List(Of Integer)
        Public myPageTableData As List(Of Integer)
    End Structure

    ''' <summary>
    ''' List of PageTableItems that hold all
    ''' information
    ''' </summary>
    Private myTable As List(Of PageTableItems)

    ''' <summary>
    ''' New Constructor
    ''' initialezes the list
    ''' </summary>
    Public Sub New()
        myTable = New List(Of PageTableItems)
    End Sub

    ''' <summary>
    ''' findProcess
    ''' Looks for the processID within the list
    ''' if its found it returns true
    ''' otherwise false
    ''' </summary>
    ''' <param name="ProcessID"></param>
    ''' Process ID to search for
    ''' <returns>True if process id is found false if not</returns>
    Public Function findProcess(ProcessID As Integer) As Boolean
        For Each item In myTable
            If item.ProcessID = ProcessID Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Searches through the list and gets all
    ''' the physical memory addresses located within
    ''' </summary>
    ''' <param name="processID"></param>
    ''' process id to search for
    ''' <returns>List of physical Memory pages for process</returns>
    Public Function getMemoryAddress(processID As Integer) As List(Of Integer)
        Dim returnList As New List(Of Integer)
        For Each item In myTable
            If item.ProcessID = processID Then
                returnList.AddRange(item.myPageTableCode)
                returnList.AddRange(item.myPageTableData)
                Return returnList
            End If
        Next
        Throw New ArgumentException("No Process in Memory")
    End Function

    ''' <summary>
    ''' This will add the process ID and the physical addresses
    ''' to the list.
    ''' </summary>
    ''' <param name="processID"></param>
    ''' value of the process id
    ''' <param name="listofCodeAddress"></param>
    ''' list of physical addresses for the code of the process id
    ''' <param name="listofDataAddress"></param>
    ''' list of physical addresses for the data of the process id
    Public Sub addProcces(processID As Integer, listofCodeAddress As List(Of Integer), listofDataAddress As List(Of Integer))
        Dim myItem As New PageTableItems
        myItem.ProcessID = processID
        myItem.myPageTableCode = listofCodeAddress
        myItem.myPageTableData = listofDataAddress
        myTable.Add(myItem)
    End Sub

    ''' <summary>
    ''' Searches through the list and removes the process id
    ''' from the list
    ''' </summary>
    ''' <param name="processID"></param>
    Public Sub removeProcess(processID As Integer)
        For Each item In myTable.ToList
            If item.ProcessID = processID Then
                myTable.Remove(item)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Removes the first item inserted into the list
    ''' To free up memory to move to disk space
    ''' </summary>
    ''' <returns>A structre containing ProcessID and Page Count</returns>
    Public Function freeUpMemory() As PageTableItems
        If myTable.Count = 0 Then
            Return Nothing
        End If
        Dim returnItem As PageTableItems
        returnItem = myTable.ElementAt(0)
        Return returnItem
    End Function

    ''' <summary>
    ''' Will update the list of process ID with a new list
    ''' of memory addresses
    ''' Do Not Think this will be used unless we are doing
    ''' memory management in some way. 
    ''' created cause ... better safe than sorry
    ''' </summary>
    ''' <param name="processID"></param>
    ''' Process ID to search for
    ''' <param name="listOfCodePages"></param>
    ''' list of phyiscal addresses that will be udpated to
    ''' for code
    '''  <param name="listOfDataPages"></param>
    '''  list of physical addresses that will be updated 
    '''  for data
    Public Sub updateProcess(processID As Integer, listOfCodePages As List(Of Integer), listOfDataPages As List(Of Integer))
        For Each item In myTable
            If item.ProcessID = processID Then
                item.myPageTableCode = listOfCodePages
                item.myPageTableData = listOfDataPages
            End If
        Next
    End Sub
End Class
