Public Class Simon
    Dim vowel As New Dictionary(Of String, String)
    Dim NotVowel As New Dictionary(Of String, String)

    Public Sub New()
        vowel.Add("0R", "Blue")
        vowel.Add("0B", "Red")
        vowel.Add("0G", "Yellow")
        vowel.Add("0Y", "Green")
        vowel.Add("1R", "Yellow")
        vowel.Add("1B", "Green")
        vowel.Add("1G", "Blue")
        vowel.Add("1Y", "Red")
        vowel.Add("2R", "Green")
        vowel.Add("2B", "Red")
        vowel.Add("2G", "Yellow")
        vowel.Add("2Y", "Blue")

        NotVowel.Add("0R", "Blue")
        NotVowel.Add("0B", "Yellow")
        NotVowel.Add("0G", "Green")
        NotVowel.Add("0Y", "Red")
        NotVowel.Add("1R", "Red")
        NotVowel.Add("1B", "Blue")
        NotVowel.Add("1G", "Yellow")
        NotVowel.Add("1Y", "Green")
        NotVowel.Add("2R", "Yellow")
        NotVowel.Add("2B", "Green")
        NotVowel.Add("2G", "Blue")
        NotVowel.Add("2Y", "Red")
    End Sub

    Public Function getColor(color As String, vow As Boolean) As String
        If (vow) Then
            Return vowel(color)
        Else
            Return NotVowel(color)
        End If
    End Function
End Class
