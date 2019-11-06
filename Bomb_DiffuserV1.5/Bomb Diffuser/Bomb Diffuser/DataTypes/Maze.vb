Imports System.IO

Public Class Maze
    Protected Maze1(12, 12) As Integer
    Protected Maze2(12, 12) As Integer
    Protected Maze3(12, 12) As Integer
    Protected Maze4(12, 12) As Integer
    Protected Maze5(12, 12) As Integer
    Protected Maze6(12, 12) As Integer
    Protected Maze7(12, 12) As Integer
    Protected Maze8(12, 12) As Integer
    Protected Maze9(12, 12) As Integer
    Protected selectedMaze(12, 12) As Integer
    Protected Goal As Pos
    Protected Moi As Pos
    Protected steps As List(Of String)

    Structure Pos
        Dim x As Integer
        Dim y As Integer
    End Structure

    Public Sub New()
        convertFileToArray(My.Resources.Maze1, 1)
        convertFileToArray(My.Resources.Maze2, 2)
        convertFileToArray(My.Resources.Maze3, 3)
        convertFileToArray(My.Resources.Maze4, 4)
        convertFileToArray(My.Resources.Maze5, 5)
        convertFileToArray(My.Resources.Maze6, 6)
        convertFileToArray(My.Resources.Maze7, 7)
        convertFileToArray(My.Resources.Maze8, 8)
        convertFileToArray(My.Resources.Maze9, 9)
    End Sub

    Private Sub convertFileToArray(mazeFile As String, which As Integer)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim ret As Boolean = False

        For Each letter In mazeFile
            If (letter.Equals("0"c) Or letter.Equals("1"c) Or letter.Equals("2"c) Or letter.Equals("3"c)) Then
                ret = False
                Select Case which
                    Case 1
                        Maze1(i, j) = Integer.Parse(letter)
                    Case 2
                        Maze2(i, j) = Integer.Parse(letter)
                    Case 3
                        Maze3(i, j) = Integer.Parse(letter)
                    Case 4
                        Maze4(i, j) = Integer.Parse(letter)
                    Case 5
                        Maze5(i, j) = Integer.Parse(letter)
                    Case 6
                        Maze6(i, j) = Integer.Parse(letter)
                    Case 7
                        Maze7(i, j) = Integer.Parse(letter)
                    Case 8
                        Maze8(i, j) = Integer.Parse(letter)
                    Case 9
                        Maze9(i, j) = Integer.Parse(letter)
                End Select
                j += 1
            Else
                If Not (ret) Then
                    i += 1
                    j = 0
                End If
                ret = True
            End If
        Next
    End Sub

    Public Function selectMaze(firstCircle As Pos, secondCircle As Pos) As Boolean
        Dim newFirstCircle As Pos
        Dim newSecondCircle As Pos

        With newFirstCircle
            .x = firstCircle.x * 2 - 1
            .y = firstCircle.y * 2 - 1
        End With

        With newSecondCircle
            .x = secondCircle.x * 2 - 1
            .y = secondCircle.y * 2 - 1
        End With

        If (Maze1(newFirstCircle.y, newFirstCircle.x) = 3 And Maze1(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze1
        ElseIf (Maze2(newFirstCircle.y, newFirstCircle.x) = 3 And Maze2(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze2
        ElseIf (Maze3(newFirstCircle.y, newFirstCircle.x) = 3 And Maze3(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze3
        ElseIf (Maze4(newFirstCircle.y, newFirstCircle.x) = 3 And Maze4(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze4
        ElseIf (Maze5(newFirstCircle.y, newFirstCircle.x) = 3 And Maze5(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze5
        ElseIf (Maze6(newFirstCircle.y, newFirstCircle.x) = 3 And Maze6(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze6
        ElseIf (Maze7(newFirstCircle.y, newFirstCircle.x) = 3 And Maze7(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze7
        ElseIf (Maze8(newFirstCircle.y, newFirstCircle.x) = 3 And Maze8(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze8
        ElseIf (Maze9(newFirstCircle.y, newFirstCircle.x) = 3 And Maze9(newSecondCircle.y, newSecondCircle.x) = 3) Then
            selectedMaze = Maze9
        Else
            Return False
        End If

        Return True
    End Function

    Public Sub searchPath(triangle As Pos, square As Pos, result As TextBox)
        Dim newTriangle As New Pos
        Dim newSquare As New Pos
        Dim isGood As Boolean = False
        Dim ret As New List(Of Pos)
        Dim tmpPos As New Pos

        With newTriangle
            .x = triangle.x * 2 - 1
            .y = triangle.y * 2 - 1
        End With

        With newSquare
            .x = square.x * 2 - 1
            .y = square.y * 2 - 1
        End With

        Goal = newTriangle
        Moi = newSquare

        With recurPath(Moi, Moi)
            isGood = .Item1
            ret = .Item2
        End With

        If (isGood) Then
            Dim i As Integer = 0
            tmpPos = Moi
            For Each way In ret
                If Not (i = 0) Then
                    result.Text += i & " - "
                End If
                If (way.y - 2 = tmpPos.y) Then
                    result.Text += "DOWN" & vbNewLine
                ElseIf (way.x - 2 = tmpPos.x) Then
                    result.Text += "RIGHT" & vbNewLine
                ElseIf (way.x + 2 = tmpPos.x) Then
                    result.Text += "LEFT" & vbNewLine
                ElseIf (way.y + 2 = tmpPos.y) Then
                    result.Text += "UP" & vbNewLine
                End If
                tmpPos = way
                i += 1
            Next
        Else
            result.Text = "No good path to reach goal"
        End If
    End Sub

    Private Function recurPath(posParent As Pos, posCurent As Pos) As Tuple(Of Boolean, List(Of Pos))
        Dim isGood As Boolean = False
        Dim open As New List(Of Pos)
        Dim tmp As New List(Of Pos)
        Dim ret As New List(Of Pos)

        If (Not selectedMaze(posCurent.y - 1, posCurent.x) = 1 And Not (posCurent.y - 2 = posParent.y And posCurent.x = posParent.x)) Then
            open.Add(New Pos With {.y = posCurent.y - 2, .x = posCurent.x})
        End If
        If (Not selectedMaze(posCurent.y, posCurent.x - 1) = 1 And Not (posCurent.y = posParent.y And posCurent.x - 2 = posParent.x)) Then
            open.Add(New Pos With {.y = posCurent.y, .x = posCurent.x - 2})
        End If
        If (Not selectedMaze(posCurent.y, posCurent.x + 1) = 1 And Not (posCurent.y = posParent.y And posCurent.x + 2 = posParent.x)) Then
            open.Add(New Pos With {.y = posCurent.y, .x = posCurent.x + 2})
        End If
        If (Not selectedMaze(posCurent.y + 1, posCurent.x) = 1 And Not (posCurent.y + 2 = posParent.y And posCurent.x = posParent.x)) Then
            open.Add(New Pos With {.y = posCurent.y + 2, .x = posCurent.x})
        End If

        If (open.Count = 0) Then
            Return (Tuple.Create(False, open))
        End If
        For Each way In open
            If (way.y = Goal.y And way.x = Goal.x) Then
                ret.Add(posCurent)
                ret.Add(New Pos With {.y = way.y, .x = way.x})
                Return (Tuple.Create(True, ret))
            End If
        Next

        For Each way In open
            With recurPath(posCurent, way)
                isGood = .Item1
                tmp = .Item2
            End With

            If (isGood) Then
                ret.Add(posCurent)
                ret.AddRange(tmp)
                Return (Tuple.Create(True, ret))
            End If
        Next
        Return (Tuple.Create(False, open))
    End Function
End Class
