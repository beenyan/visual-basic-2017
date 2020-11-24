Imports System.Text.RegularExpressions
Imports System.Numerics
Module Module1
    Dim F As New Func(Of String)(Function() Regex.Replace(Console.ReadLine(), "\s+", ""))
    Dim L As New Func(Of String)(Function() Regex.Replace(Console.ReadLine(), "\s+", " "))
    Sub Main()
        Console.WriteLine("(快速冪)輸入2數: 數字 次方")
        While 1
            Dim S = L().Split(" ").ToList.ConvertAll(AddressOf Int64.Parse)
            MyPow(S(0), S(1))
        End While
        Stop
    End Sub
    Sub MyPow(N1 As BigInteger, N2 As Int64)
        Dim Ans = BigInteger.Parse(1)
        While N2 <> 0
            If N2 And 1 Then Ans *= N1
            N1 *= N1
            N2 >>= 1
        End While
        Console.WriteLine(Ans.ToString)
    End Sub
End Module