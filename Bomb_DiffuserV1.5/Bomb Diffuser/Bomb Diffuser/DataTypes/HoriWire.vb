Public Class HoriWire

    Public Function count(str As String, s As Char) As Integer
        Dim nb As Integer = 0

        For Each c In str
            If (c = s) Then
                nb += 1
            End If
        Next
        Return (nb)
    End Function

    Public Function three(str As String) As String
        If (Not str.Contains("r")) Then
            Return "Cut the 2nd"
        ElseIf (str(2) = "w") Then
            Return "Cut the last"
        ElseIf (count(str, "b") > 1) Then
            Return "Cut the last Blue"
        Else
            Return "Cut the last"
        End If
    End Function

    Public Function four(str As String, odd As Boolean) As String
        If (count(str, "r") > 1 And odd) Then
            Return "Cut the last Red"
        ElseIf (count(str, "r") = 0 And str(3) = "j") Then
            Return "Cut the 1st"
        ElseIf (count(str, "b") = 1) Then
            Return "Cut the 1st"
        ElseIf (count(str, "y") > 1) Then
            Return "Cut the last"
        Else
            Return "Cut the 2nd"
        End If
    End Function

    Public Function five(str As String, odd As Boolean) As String
        If (str(4) = "n" And odd) Then
            Return "Cut the 4th"
        ElseIf (count(str, "r") = 1 And count(str, "j") > 1) Then
            Return "Cut the 1st"
        ElseIf (Not str.Contains("n")) Then
            Return "Cut the 2nd"
        Else
            Return "Cut the 1st"
        End If
    End Function

    Public Function six(str As String, odd As Boolean) As String
        If (Not str.Contains("j") And odd) Then
            Return "Cut the 3rd"
        ElseIf (count(str, "j") = 1 And count(str, "w") > 1) Then
            Return "Cut the 4th"
        ElseIf (Not str.Contains("r")) Then
            Return "Cut the last"
        Else
            Return "Cut the 4th"
        End If
    End Function
End Class
