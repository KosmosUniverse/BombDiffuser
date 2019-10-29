Public Class SeqWire
    Dim nbRed As Integer = -1
    Dim nbBlue As Integer = -1
    Dim nbBlack As Integer = -1
    Dim red(9) As String
    Dim blue(9) As String
    Dim black(9) As String

    Public Sub New()
        red(0) = "C"
        red(1) = "B"
        red(2) = "A"
        red(3) = "AC"
        red(4) = "B"
        red(5) = "AC"
        red(6) = "ABC"
        red(7) = "AB"
        red(8) = "B"
        blue(0) = "B"
        blue(1) = "AC"
        blue(2) = "B"
        blue(3) = "A"
        blue(4) = "B"
        blue(5) = "BC"
        blue(6) = "C"
        blue(7) = "AC"
        blue(8) = "A"
        black(0) = "ABC"
        black(1) = "AC"
        black(2) = "B"
        black(3) = "AC"
        black(4) = "B"
        black(5) = "BC"
        black(6) = "AB"
        black(7) = "C"
        black(8) = "C"
    End Sub

    Public Function cutRed(letter As String) As Boolean
        nbRed += 1
        Return (red(nbRed).Contains(letter))
    End Function

    Public Function cutBlue(letter As String) As Boolean
        nbBlue += 1
        Return (blue(nbBlue).Contains(letter))
    End Function

    Public Function cutBlack(letter As String) As Boolean
        nbBlack += 1
        Return (black(nbBlack).Contains(letter))
    End Function

    Public Sub reset()
        nbRed = -1
        nbBlue = -1
        nbBlack = -1
    End Sub
End Class