''' <summary>
''' //============================================================================================================
''' System  : SPAM
''' File    : PhysicalMemory.vb
''' Author  : PhilGarza (garzap@mail.gvsu.edu)
''' Updated : 3/26/2018
''' 
''' The PhysicalMemory class is the brains behind SPAM
''' it houses all the memory and manages it. 
''' ==============================================================================================================
''' </summary>
Public Class PhysicalMemory

    'Size in bytes of MemoryBlock
    Private memBlockSize As Integer

    'Number of memory blocks
    Private numberOfBlocks As Integer

    'List of memory page files
    Private pageFiles As List(Of String)

    'List of Free Page File
    'Its a Queue so i can use memroy FiFo
    Private freePageList As Queue(Of Integer)

    ''' <summary>
    ''' Default Constructor for memory class
    ''' The default values were used for testing
    ''' it will take any size for blocks and number
    ''' of memory blocks
    ''' </summary>
    ''' <param name="paramSize"></param>
    ''' Size for memory blocks. Default is 512
    ''' <param name="paramNumber"></param>
    ''' Number of physical Memory blocks default is 8
    Public Sub New(Optional paramSize As Integer = 512, Optional paramNumber As Integer = 8)
        'Do i really need to explain whats happening here?
        memBlockSize = paramSize
        'See Above
        numberOfBlocks = paramNumber
        ''Declare an array with number of blocks
        pageFiles = New List(Of String)(numberOfBlocks)
        'Allocate new Queue
        freePageList = New Queue(Of Integer)
        'assign default values of -1
        'Add blocks to free page list
        For index = 0 To numberOfBlocks - 1
            'Sets the description of memeory
            pageFiles.Add("Free")
            'Queues the memory as free
            freePageList.Enqueue(index)
        Next
    End Sub

    ''' <summary>
    ''' Adds Process to Memory
    ''' So you give it the process ID and number
    ''' of pages and it will put it into memory
    ''' If there isn't enough space this will cause 
    ''' an error or falut
    ''' this will be used to enabel Disk Access at a
    ''' later date
    ''' </summary>
    ''' <param name="processID"></param>
    ''' Process ID for the program
    ''' <param name="codePages"></param>
    ''' number of code Pages
    ''' <param name="datapages"></param>
    ''' number of Data Pages 
    ''' <returns>List of Integers used to put it inside the look up table</returns>
    Public Function AddProcessToMemory(processID As Integer, codePages As Integer, datapages As Integer) As List(Of Integer)
        ''Creates return list
        Dim returnMemoryPages As New List(Of Integer)

        ''Checks if there is enough free memory
        If (codePages + datapages) > freePageList.Count Then
            Throw New ArgumentOutOfRangeException("Not Enough Memory")
        End If

        ''Allocates Code Pages First
        For count = 0 To codePages - 1
            Dim page As Integer = freePageList.Dequeue()
            pageFiles.Item(page) = String.Format("Code-{1} of P{0}", processID, count)
            returnMemoryPages.Add(page)
        Next

        ''Now Allocate Data Pages
        For count = 0 To datapages - 1
            Dim page As Integer = freePageList.Dequeue()
            pageFiles.Item(page) = String.Format("Data-{1} of P{0}", processID, count)
            returnMemoryPages.Add(page)
        Next

        ''Returns Value
        Return returnMemoryPages
    End Function

    ''' <summary>
    ''' FreeMemory will free up all memory from
    ''' the list of physical memory addresses
    ''' these are normally supplied by the lookup table
    ''' </summary>
    ''' <param name="listOfPhyicalAddresses"></param>
    ''' List of physical memory addresses to remove
    Public Sub freeMemory(listOfPhyicalAddresses As List(Of Integer))
        For Each page In listOfPhyicalAddresses
            pageFiles.Item(page) = "Free"
            freePageList.Enqueue(page)
        Next
    End Sub

    ''' <summary>
    ''' Gets the Current Block Size
    ''' </summary>
    ''' <returns>Block Size</returns>
    Public ReadOnly Property getBlockSize As Integer
        Get
            Return memBlockSize
        End Get
    End Property

    ''' <summary>
    ''' Gets the page count
    ''' that is defined in the constructor
    ''' </summary>
    ''' <returns>Count of the number of memory blocks</returns>
    Public ReadOnly Property getPageFileCount As Integer
        Get
            Return pageFiles.Count
        End Get
    End Property

    ''' <summary>
    ''' Gets a count of the number of free blocks
    ''' Used to check if there is enough space
    ''' Useful before disk space is implemented
    ''' </summary>
    ''' <returns>The number of free blocks</returns>
    Public ReadOnly Property getFreeBlocks As Integer
        Get
            Return freePageList.Count
        End Get
    End Property

    ''' <summary>
    ''' Overrides Normal toString
    ''' used for dislpaying to console screen
    ''' </summary>
    ''' <returns>A string that has all the processes currently in memory</returns>
    Public Overrides Function ToString() As String
        Dim returnString As String = ""
        For Each value In pageFiles
            returnString += value + Environment.NewLine
        Next
        Return returnString
    End Function
End Class
