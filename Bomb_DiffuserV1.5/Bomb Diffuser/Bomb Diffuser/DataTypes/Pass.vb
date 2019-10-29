Public Class Pass
    Dim words As New List(Of String)

    Public Sub New()
        words.Add("about")
        words.Add("after")
        words.Add("again")
        words.Add("below")
        words.Add("could")
        words.Add("every")
        words.Add("first")
        words.Add("found")
        words.Add("great")
        words.Add("house")
        words.Add("large")
        words.Add("learn")
        words.Add("never")
        words.Add("other")
        words.Add("place")
        words.Add("plant")
        words.Add("point")
        words.Add("right")
        words.Add("small")
        words.Add("sound")
        words.Add("spell")
        words.Add("still")
        words.Add("study")
        words.Add("their")
        words.Add("there")
        words.Add("these")
        words.Add("thing")
        words.Add("think")
        words.Add("three")
        words.Add("water")
        words.Add("where")
        words.Add("which")
        words.Add("wolrd")
        words.Add("would")
        words.Add("write")
    End Sub

    Public Function getFirst(str As String) As List(Of String)
        Dim valid As New List(Of String)

        For Each word In words
            For Each c In str
                If (word.ElementAt(0) = c) Then
                    valid.Add(word)
                End If
            Next
        Next

        Return valid
    End Function

    Public Function getNext(str As String, before As List(Of String), pos As Integer) As List(Of String)
        Dim valid As New List(Of String)

        For Each word In before
            For Each c In str
                If (word.ElementAt(pos) = c) Then
                    valid.Add(word)
                End If
            Next
        Next

        Return valid
    End Function
End Class
