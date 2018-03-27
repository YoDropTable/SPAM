


Public Class PageTable
    Private Structure PageTableItems
        Public ProcessID As Integer
        Public myPageTable As List(Of Integer)
    End Structure
    Private myTable As List(Of PageTableItems)

    Public Sub New()
        myTable = New List(Of PageTableItems)
    End Sub
    Public Function findProcess(ProcessID As Integer) As Boolean
        For Each item In myTable
            If item.ProcessID = ProcessID Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function getMemoryAddress(processID As Integer) As List(Of Integer)
        For Each item In myTable
            If item.ProcessID = processID Then
                Return item.myPageTable
            End If
        Next
        Throw New ArgumentException("No Process in Memory")
    End Function
    Public Sub addProcces(processID As Integer, listOfPhysicalAddresses As List(Of Integer))
        Dim myItem As New PageTableItems
        myItem.ProcessID = processID
        myItem.myPageTable = listOfPhysicalAddresses
        myTable.Add(myItem)
    End Sub
    Public Sub removeProcess(processID As Integer)
        For Each item In myTable.ToList
            If item.ProcessID = processID Then
                myTable.Remove(item)
            End If
        Next
    End Sub
    Public Sub updateProcess(processID As Integer, listOfPhysicalAddreses As List(Of Integer))
        For Each item In myTable
            If item.ProcessID = processID Then
                item.myPageTable = listOfPhysicalAddreses
            End If
        Next
    End Sub
End Class
