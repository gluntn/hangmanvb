Module Module1

    ' The availiable words
    Dim words As String() = {"cat", "dog", "puppy", "computer", "hello-world"}
    ' The guessed letters
    Dim guessed As List(Of String)
    ' Contains the alphabet
    Dim letters As Char() = "abcdefghijklmnopqrstuvwxyz".ToCharArray()

    Dim play As Boolean = True
    Dim word As String ' choose a random word
    Dim attempt As Integer = 5
    Dim ran As Random = New Random

    Public Sub Main()

        ' Initialize it!
        guessed = New List(Of String)
        word = words(ran.Next(0, words.Length - 1))
        Console.Write("Welcome to Hangman!")
        Console.WriteLine(String.Format("Your word has {0} letters", word.Length))

        While play

            If attempt = 0 Then
                Console.Write("You have lost!")
                Console.ReadLine()
                Exit While
            End If

            Console.Write(vbCrLf & "Which letter would you like to guess?")
            Dim letter As Char = Console.ReadLine()

            If (Not letters.Contains(letter)) Then
                Console.Write("You did not input a viable letter.")
            Else
                If (Not word.Contains(letter)) Then
                    Console.Write(String.Format("{0} is not in the word!" & vbCrLf _
                    & " You have {1} attempts left", letter.ToString, attempt))
                    attempt -= 1
                Else
                    Console.Write(String.Format("{0} is in the word!", letter))
                End If
                guessed.Add(letter)
                Console.Write(vbCrLf & PrintWord())
            End If

            If String.Join("", PrintWord()) = word Then
                Console.Write("You have won!")
                Exit While
            End If

        End While
    End Sub

    Function PrintWord()
        Dim temp As List(Of String) = New List(Of String)
        ' For each n [as datatype]
        For Each c As String In word
            If ("- .,".Contains(c)) Then
                temp.Add(c)
            ElseIf (Not guessed.Contains(c)) Then
                temp.Add("*")
            Else
                temp.Add(c)
            End If
        Next
        Return String.Join("", temp)
    End Function

End Module
