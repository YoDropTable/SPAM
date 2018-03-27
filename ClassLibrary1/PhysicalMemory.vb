Public Class PhysicalMemory
    'Size in bytes of MemoryBlock
    Private memBlockSize As Integer
    'Number of memory blocks
    Private numberOfBlocks As Integer
    Private pageFiles As List(Of String)
    Private freePageList As Queue(Of Integer)
    ''' <summary>
    ''' Default Constructor for memory class
    ''' </summary>
    ''' <param name="paramSize"></param>
    ''' Size for memory blocks. Default is 512
    ''' <param name="paramNumber"></param>
    ''' Number of physical Memory
    Public Sub New(Optional paramSize As Integer = 512, Optional paramNumber As Integer = 8)
        memBlockSize = paramSize
        numberOfBlocks = paramNumber
        ''Declare an array with number of blocks
        pageFiles = New List(Of String)(numberOfBlocks)
        freePageList = New Queue(Of Integer)
        'assign default values of -1
        'Add blocks to free page list
        For index = 0 To numberOfBlocks - 1
            pageFiles.Add("Free")
            freePageList.Enqueue(index)
        Next
    End Sub
    Public Function AddProcessToMemory(processID As Integer, codePages As Integer, datapages As Integer) As List(Of Integer)
        Dim returnMemoryPages As New List(Of Integer)
        If (codePages + datapages) > freePageList.Count Then
            Throw New ArgumentOutOfRangeException("Not Enough Memory")
        End If
        For count = 0 To codePages - 1
            Dim page As Integer = freePageList.Dequeue()
            pageFiles.Item(page) = String.Format("Code-{1} of P{0}", processID, count)
            returnMemoryPages.Add(page)
        Next
        For count = 0 To datapages - 1
            Dim page As Integer = freePageList.Dequeue()
            pageFiles.Item(page) = String.Format("Data-{1} of P{0}", processID, count)
            returnMemoryPages.Add(page)
        Next
        Return returnMemoryPages
    End Function
    Public Sub freeMemory(listOfPhyicalAddresses As List(Of Integer))
        For Each page In listOfPhyicalAddresses
            pageFiles.Item(page) = "Free"
            freePageList.Enqueue(page)
        Next
    End Sub
    Public ReadOnly Property getBlockSize As Integer
        Get
            Return memBlockSize
        End Get
    End Property
    Public ReadOnly Property getPageFileCount As Integer
        Get
            Return pageFiles.Count
        End Get
    End Property
    Public ReadOnly Property getFreeBlocks As Integer
        Get
            Return freePageList.Count
        End Get
    End Property
    ''' <summary>
    ''' Overrides Normal toString
    ''' used for dislpaying to console screen
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        Dim returnString As String = ""
        For Each value In pageFiles
            returnString += value + Environment.NewLine
        Next
        Return returnString
    End Function
End Class
