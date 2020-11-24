Imports System.Text.RegularExpressions
Imports System.Numerics
Module Module1
    Dim F As New Func(Of String)(Function() Regex.Replace(Console.ReadLine(), "\s+", ""))
    Dim L As New Func(Of String)(Function() Regex.Replace(Console.ReadLine(), "\s+", " "))
    Sub Main()
        Dim S = Regex.Replace(F(), "[^0-9]", " $0 ").Split(" ", options:=1).ToList
        Dim Result As New List(Of String), Stack As New Stack
        For Each X In S
            If IsNumeric(X) Then
                Result.Add(X)
            Else
                If Stack.Count = 0 Then Stack.Push(X) : Continue For
                If X = "(" Then
                    Stack.Push(X)
                ElseIf X = ")" Then
                    While Stack.Peek <> "("
                        Result.Add(Stack.Pop)
                    End While
                    Stack.Pop()
                Else
                    While Stack.Count AndAlso D(Stack.Peek) >= D(X)
                        Result.Add(Stack.Pop)
                    End While
                    Stack.Push(X)
                End If
            End If
        Next
        While Stack.Count
            Result.Add(Stack.Pop)
        End While
        Dim Ans As New Stack(Of Int32)
        Dim T
        For Each X In Result
            If IsNumeric(X) Then
                Ans.Push(X)
            ElseIf X = "+" Then
                Ans.Push(Ans.Pop() + Ans.Pop())
            ElseIf X = "-" Then
                T = Ans.Pop()
                Ans.Push(Ans.Pop() - T)
            ElseIf X = "*" Then
                Ans.Push(Ans.Pop() * Ans.Pop())
            ElseIf X = "/" Then
                T = Ans.Pop()
                Ans.Push(Ans.Pop() / T)
            ElseIf X = "%" Then
                T = Ans.Pop()
                Ans.Push(Ans.Pop() Mod T)
            End If
        Next
        Console.WriteLine(Ans.Pop())
        Stop
    End Sub
    Function D(S$) As Int32 ' 權重
        Return If(S = "+" OrElse S = "-", 1, If(S = "*" OrElse S = "/" OrElse S = "%", 2, 0))
    End Function
End Module