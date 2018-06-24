'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System.Collections

'Represents a first-in, first-out collection of objects
'Queue in the System.Collections is currently unsupported in SDE BETA 1 (.NET Compact Framework)

Public Class Queue

  Private myQueue As ArrayList

  Friend Sub New()
  ' Minimal constructor for now
    myQueue = New ArrayList()
  End Sub

  ' Properties
  Friend ReadOnly Property Count() As Integer
  Get
    Count = myQueue.Count()
  End Get
  End Property

  ' Methods
  Friend Sub Clear()
    myQueue.Clear()
  End Sub

  Friend Sub Enqueue(ByVal obj As Object)
    myQueue.Add(obj)
  End Sub

  Friend Function Dequeue() As Object
    Dequeue = myQueue.Item(0)
    myQueue.RemoveAt(0)
  End Function

  Friend Function Peek() As Object
    Peek = myQueue.Item(0)
  End Function

End Class
