Imports System

Module Program
    Sub Main(args As String())

        Dim IterationsTotal As Integer = 10000
        Dim Debug As Boolean = False

        Dim GuessedCorrect As Integer = 0

        Dim SecretCard As Integer = 0
        Dim UpperBound As Integer = 3
        Dim LowerBound As Integer = 1

        Console.WriteLine("What are the odds of choosing a secret card?")


        '******************************************************************************

        Console.WriteLine("1. Pick one card out of three")

        For i = 1 To IterationsTotal

            SecretCard = CInt(Math.Floor((UpperBound - LowerBound + 1) * Rnd())) + LowerBound

            Dim UserChoice As Integer = CInt(Math.Floor((UpperBound - LowerBound + 1) * Rnd())) + LowerBound

            If Debug Then
                Console.WriteLine(String.Format("The secret card is {0}. The user choice is {1}", SecretCard, UserChoice))
            End If

            If SecretCard = UserChoice Then
                GuessedCorrect += 1
            End If

        Next

        Console.WriteLine(String.Format("Guessed {1} out of {0} correct = {2}%", IterationsTotal, GuessedCorrect, GuessedCorrect / IterationsTotal * 100))

        '******************************************************************************

        Console.WriteLine("2. Pick two cards out of three")

        GuessedCorrect = 0


        For i = 1 To IterationsTotal

            SecretCard = CInt(Math.Floor((UpperBound - LowerBound + 1) * Rnd())) + LowerBound

            Dim UserChoice2 As Integer = 100

            Dim UserChoice1 As Integer = CInt(Math.Floor((UpperBound - LowerBound + 1) * Rnd())) + LowerBound
            While UserChoice1 = UserChoice2 Or UserChoice2 = 100
                UserChoice2 = CInt(Math.Floor((UpperBound - LowerBound + 1) * Rnd())) + LowerBound
            End While

            If Debug Then
                Console.WriteLine(String.Format("The secret card is {0}. The user choice is {1} & {2}", SecretCard, UserChoice1, UserChoice2))
            End If

            If SecretCard = UserChoice1 Or SecretCard = UserChoice2 Then
                GuessedCorrect += 1
            End If

        Next

        Console.WriteLine(String.Format("Guessed {1} out of {0} correct = {2}%", IterationsTotal, GuessedCorrect, GuessedCorrect / IterationsTotal * 100))

        '******************************************************************************

        GuessedCorrect = 0

        Console.WriteLine("3. Pick one card out of three - change your pick after one incorrect card is revealed")

        For i = 1 To IterationsTotal

            Dim EmptyCards As List(Of Integer) = New List(Of Integer) From {1, 2, 3}

            SecretCard = CInt(Math.Floor((UpperBound - LowerBound + 1) * Rnd())) + LowerBound

            EmptyCards.Remove(SecretCard)

            Dim FirstUserChoice As Integer = CInt(Math.Floor((UpperBound - LowerBound + 1) * Rnd())) + LowerBound

            EmptyCards.Remove(FirstUserChoice)

            ' come up with the card to reveal - the list may have one or two items 
            Dim CardToReveal As Integer = 0
            While True

                CardToReveal = CInt(Math.Floor((UpperBound - LowerBound + 1) * Rnd())) + LowerBound

                If EmptyCards.Contains(CardToReveal) Then
                    Exit While
                End If

            End While

            Dim NewUserChoice As Integer = 0

            Dim AllOptions = New List(Of Integer) From {1, 2, 3}
            AllOptions.Remove(FirstUserChoice)
            AllOptions.Remove(CardToReveal)

            NewUserChoice = AllOptions.Item(0)

            If Debug Then
                Console.WriteLine(String.Format("The secret card is {0}. The user choice was {1} & {2}. Card to reveal = {3}", SecretCard, FirstUserChoice, NewUserChoice, CardToReveal))
            End If

            If SecretCard = NewUserChoice Then
                GuessedCorrect += 1
            End If

        Next



        Console.WriteLine(String.Format("Guessed {1} out of {0} correct = {2}%", IterationsTotal, GuessedCorrect, GuessedCorrect / IterationsTotal * 100))





        Console.ReadLine()


    End Sub
End Module
