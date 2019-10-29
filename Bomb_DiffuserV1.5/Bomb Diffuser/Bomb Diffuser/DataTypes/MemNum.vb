Public Class MemNum
    Dim stage(4) As oneStage

    Structure oneStage
        Dim number As Integer
        Dim label As Integer
        Dim position As Integer
    End Structure

    Public Sub New()
        For Each st In stage
            st.label = 0
            st.number = 0
            st.position = 0
        Next
    End Sub

    Public Sub reset()
        For Each st In stage
            st.label = 0
            st.number = 0
            st.position = 0
        Next
    End Sub

    Public Function stage1(num As Integer) As Tuple(Of Boolean, Integer)
        Dim tmp As Integer

        stage(0).number = num

        If (num = 1 Or num = 2) Then
            tmp = 2
        ElseIf (num = 3) Then
            tmp = 3
        Else
            tmp = 4
        End If

        stage(0).position = tmp

        Return Tuple.Create(False, tmp)
    End Function

    Public Function stage2(num As Integer, type As Boolean, other As Integer) As Tuple(Of Boolean, Integer)
        Dim tmp As Integer
        Dim tmp2 As Boolean

        stage(1).number = num

        If (type) Then
            stage(0).label = other
        Else
            stage(0).position = other
        End If

        If (num = 2 Or num = 4) Then
            tmp = stage(0).position
            tmp2 = False
        ElseIf (num = 3) Then
            tmp = 1
            tmp2 = False
        Else
            tmp = 4
            tmp2 = True
        End If

        If (tmp2) Then
            stage(1).label = tmp
        Else
            stage(1).position = tmp
        End If

        Return Tuple.Create(tmp2, tmp)
    End Function

    Public Function stage3(num As Integer, type As Boolean, other As Integer) As Tuple(Of Boolean, Integer)
        Dim tmp As Integer
        Dim tmp2 As Boolean

        stage(2).number = num

        If (type) Then
            stage(1).label = other
        Else
            stage(1).position = other
        End If

        If (num = 1) Then
            tmp = stage(1).label
            tmp2 = True
        ElseIf (num = 2) Then
            tmp = stage(0).label
            tmp2 = True
        ElseIf (num = 3) Then
            tmp = 3
            tmp2 = False
        Else
            tmp = 4
            tmp2 = True
        End If

        If (tmp2) Then
            stage(2).label = tmp
        Else
            stage(2).position = tmp
        End If

        Return Tuple.Create(tmp2, tmp)
    End Function

    Public Function stage4(num As Integer, type As Boolean, other As Integer) As Tuple(Of Boolean, Integer)
        Dim tmp As Integer
        Dim tmp2 As Boolean

        stage(3).number = num

        If (type) Then
            stage(2).label = other
        Else
            stage(2).position = other
        End If

        If (num = 1) Then
            tmp = stage(0).position
            tmp2 = False
        ElseIf (num = 2) Then
            tmp = 1
            tmp2 = False
        Else
            tmp = stage(1).position
            tmp2 = False
        End If

        If (tmp2) Then
            stage(3).label = tmp
        Else
            stage(3).position = tmp
        End If

        Return Tuple.Create(tmp2, tmp)
    End Function

    Public Function stage5(num As Integer, type As Boolean, other As Integer) As Tuple(Of Boolean, Integer)
        Dim tmp As Integer
        Dim tmp2 As Boolean

        stage(4).number = num

        If (type) Then
            stage(3).label = other
        Else
            stage(3).position = other
        End If

        If (num = 1) Then
            tmp = stage(0).label
            tmp2 = True
        ElseIf (num = 2) Then
            tmp = stage(1).label
            tmp2 = True
        ElseIf (num = 3) Then
            tmp = stage(2).label
            tmp2 = True
        Else
            tmp = stage(3).label
            tmp2 = True
        End If

        If (tmp2) Then
            stage(4).label = tmp
        Else
            stage(4).position = tmp
        End If

        Return Tuple.Create(tmp2, tmp)
    End Function
End Class