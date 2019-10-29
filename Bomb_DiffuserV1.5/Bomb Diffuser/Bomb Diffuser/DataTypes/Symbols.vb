Public Class Symbols
    Dim lst1 As New List(Of Integer)
    Dim lst2 As New List(Of Integer)
    Dim lst3 As New List(Of Integer)
    Dim lst4 As New List(Of Integer)
    Dim lst5 As New List(Of Integer)
    Dim lst6 As New List(Of Integer)

    Public resource As New Dictionary(Of Integer, Image)

    Public Sub New()
        lst1.Add(1)
        lst1.Add(2)
        lst1.Add(3)
        lst1.Add(4)
        lst1.Add(5)
        lst1.Add(6)
        lst1.Add(7)

        lst2.Add(11)
        lst2.Add(1)
        lst2.Add(7)
        lst2.Add(10)
        lst2.Add(9)
        lst2.Add(6)
        lst2.Add(8)

        lst3.Add(12)
        lst3.Add(13)
        lst3.Add(10)
        lst3.Add(14)
        lst3.Add(15)
        lst3.Add(3)
        lst3.Add(9)

        lst4.Add(18)
        lst4.Add(17)
        lst4.Add(16)
        lst4.Add(5)
        lst4.Add(14)
        lst4.Add(8)
        lst4.Add(19)

        lst5.Add(25)
        lst5.Add(19)
        lst5.Add(16)
        lst5.Add(22)
        lst5.Add(17)
        lst5.Add(21)
        lst5.Add(20)

        lst6.Add(18)
        lst6.Add(11)
        lst6.Add(23)
        lst6.Add(24)
        lst6.Add(25)
        lst6.Add(26)
        lst6.Add(27)

        resource.Add(0, My.Resources.pic1)
        resource.Add(1, My.Resources.pic2)
        resource.Add(2, My.Resources.pic3)
        resource.Add(3, My.Resources.pic4)
        resource.Add(4, My.Resources.pic5)
        resource.Add(5, My.Resources.pic6)
        resource.Add(6, My.Resources.pic7)
        resource.Add(7, My.Resources.pic8)
        resource.Add(8, My.Resources.pic9)
        resource.Add(9, My.Resources.pic10)
        resource.Add(10, My.Resources.pic11)
        resource.Add(11, My.Resources.pic12)
        resource.Add(12, My.Resources.pic13)
        resource.Add(13, My.Resources.pic14)
        resource.Add(14, My.Resources.pic15)
        resource.Add(15, My.Resources.pic16)
        resource.Add(16, My.Resources.pic17)
        resource.Add(17, My.Resources.pic18)
        resource.Add(18, My.Resources.pic19)
        resource.Add(19, My.Resources.pic20)
        resource.Add(20, My.Resources.pic21)
        resource.Add(21, My.Resources.pic22)
        resource.Add(22, My.Resources.pic23)
        resource.Add(23, My.Resources.pic24)
        resource.Add(24, My.Resources.pic25)
        resource.Add(25, My.Resources.pic26)
        resource.Add(26, My.Resources.pic27)
    End Sub

    Public Function contain(lst As List(Of Integer), input As List(Of Integer)) As Boolean
        For Each item In input
            If (Not lst.Contains(item)) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function getLstOrder(lst As List(Of Integer), input As List(Of Integer)) As List(Of Integer)
        Dim res As New List(Of Integer)

        For Each item In lst
            If (input.Contains(item)) Then
                res.Add(item - 1)
            End If
        Next
        Return (res)
    End Function

    Public Function getImage(nb As Integer) As Image
        Return resource.ElementAt(nb).Value
    End Function

    Public Function getOrder(input As List(Of Integer)) As List(Of Integer)
        If (contain(lst1, input)) Then
            Return getLstOrder(lst1, input)
        ElseIf (contain(lst2, input)) Then
            Return getLstOrder(lst2, input)
        ElseIf (contain(lst3, input)) Then
            Return getLstOrder(lst3, input)
        ElseIf (contain(lst4, input)) Then
            Return getLstOrder(lst4, input)
        ElseIf (contain(lst5, input)) Then
            Return getLstOrder(lst5, input)
        Else
            Return getLstOrder(lst6, input)
        End If
    End Function
End Class
