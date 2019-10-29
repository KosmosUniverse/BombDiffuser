Public Class Morse
    Dim all As New Dictionary(Of String, String)
    Dim morse As New Dictionary(Of String, String)

    Public Sub New()
        all.Add("beats", "3.600")
        all.Add("bistro", "3.552")
        all.Add("bombs", "3.565")
        all.Add("boxes", "3.535")
        all.Add("break", "3.572")
        all.Add("brick", "3.575")
        all.Add("flick", "3.555")
        all.Add("halls", "3.515")
        all.Add("leaks", "3.542")
        all.Add("shell", "3.505")
        all.Add("slick", "3.522")
        all.Add("steak", "3.582")
        all.Add("sting", "3.592")
        all.Add("strobe", "3.545")
        all.Add("trick", "3.532")
        all.Add("vector", "3.595")

        morse.Add(".-", "a")
        morse.Add("-...", "b")
        morse.Add("-.-.", "c")
        morse.Add(".", "e")
        morse.Add("..-.", "f")
        morse.Add("--.", "g")
        morse.Add("....", "h")
        morse.Add("..", "i")
        morse.Add("-.-", "k")
        morse.Add(".-..", "l")
        morse.Add("--", "m")
        morse.Add("---", "o")
        morse.Add(".-.", "r")
        morse.Add("...", "s")
        morse.Add("-", "t")
        morse.Add("...-", "v")
        morse.Add("-..-", "x")
    End Sub

    Public Function convert(str As String) As String
        If (morse.ContainsKey(str)) Then
            Return morse(str)
        Else
            Return ("False")
        End If
    End Function

    Public Function getFirst(str As String) As Dictionary(Of String, String)
        Dim lst As New Dictionary(Of String, String)

        For Each word In all
            If (str.ElementAt(0) = word.Key.ElementAt(0)) Then
                lst.Add(word.Key, word.Value)
            End If
        Next

        Return lst
    End Function

    Public Function getNext(str As String, before As Dictionary(Of String, String), pos As Integer) As Dictionary(Of String, String)
        Dim lst As New Dictionary(Of String, String)

        For Each word In before
            If (str.ElementAt(0) = word.Key.ElementAt(pos)) Then
                lst.Add(word.Key, word.Value)
            End If
        Next

        Return lst
    End Function
End Class
