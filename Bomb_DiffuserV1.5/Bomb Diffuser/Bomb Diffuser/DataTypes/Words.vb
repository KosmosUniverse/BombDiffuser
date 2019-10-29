Public Class Words
    Dim dic As New Dictionary(Of String, String)
    Dim TL As New List(Of String)
    Dim TR As New List(Of String)
    Dim ML As New List(Of String)
    Dim MR As New List(Of String)
    Dim BL As New List(Of String)
    Dim BR As New List(Of String)

    Public Sub New()

        dic = New Dictionary(Of String, String)

        dic.Add("ready", "YES,OKAY,WHAT,MIDDLE,LEFT,PRESS,RIGHT,BLANK,READY,NO,FIRST,UHHH,NOTHING,WAIT")
        dic.Add("first", "LEFT,OKAY,YES,MIDDLE,NO,RIGHT,NOTHING,UHHH,WAIT,READY,BLANK,WHAT,PRESS,FIRST")
        dic.Add("no", "BLANK,UHHH,WAIT,FIRST,WHAT,READY,RIGHT,YES,NOTHING,LEFT,PRESS,OKAY,NO,MIDDLE")
        dic.Add("blank", "WAIT,RIGHT,OKAY,MIDDLE,BLANK,PRESS,READY,NOTHING,NO,WHAT,LEFT,UHHH,YES,FIRST")
        dic.Add("nothing", "UHHH,RIGHT,OKAY,MIDDLE,YES,BLANK,NO,PRESS,LEFT,WHAT,WAIT,FIRST,NOTHING,READY")
        dic.Add("yes", "OKAY,RIGHT,UHHH,MIDDLE,FIRST,WHAT,PRESS,READY,NOTHING,YES,LEFT,BLANK,NO,WAIT")
        dic.Add("what", "UHHH,WHAT,LEFT,NOTHING,READY,BLANK,MIDDLE,NO,OKAY,FIRST,WAIT,YES,PRESS,RIGHT")
        dic.Add("uhhh", "READY,NOTHING,LEFT,WHAT,OKAY,YES,RIGHT,NO,PRESS,BLANK,UHHH,MIDDLE,WAIT,FIRST")
        dic.Add("left", "RIGHT,LEFT,FIRST,NO,MIDDLE,YES,BLANK,WHAT,UHHH,WAIT,PRESS,READY,OKAY,NOTHING")
        dic.Add("right", "YES,NOTHING,READY,PRESS,NO,WAIT,WHAT,RIGHT,MIDDLE,LEFT,UHHH,BLANK,OKAY,FIRST")
        dic.Add("middle", "BLANK,READY,OKAY,WHAT,NOTHING,PRESS,NO,WAIT,LEFT,MIDDLE,RIGHT,FIRST,UHHH,YES")
        dic.Add("okay", "MIDDLE,NO,FIRST,YES,UHHH,NOTHING,WAIT,OKAY,LEFT,READY,BLANK,PRESS,WHAT,RIGHT")
        dic.Add("wait", "UHHH,NO,BLANK,OKAY,YES,LEFT,FIRST,PRESS,WHAT,WAIT,NOTHING,READY,RIGHT,MIDDLE")
        dic.Add("press", "RIGHT,MIDDLE,YES,READY,PRESS,OKAY,NOTHING,UHHH,BLANK,LEFT,FIRST,WHAT,NO,WAIT")
        dic.Add("you", "SURE,YOU ARE,YOUR,YOU'RE,NEXT,UH HUH,UR,HOLD,WHAT?,YOU,UH UH,LIKE,DONE,U")
        dic.Add("you are", "YOUR,NEXT,LIKE,UH HUH,WHAT?,DONE,UH UH,HOLD,YOU,U,YOU'RE,SURE,UR,YOU ARE")
        dic.Add("your", "UH UH,YOU ARE,UH HUH,YOUR,NEXT,UR,SURE,U,YOU'RE,YOU,WHAT?,HOLD,LIKE,DONE")
        dic.Add("you're", "YOU,YOU'RE,UR,NEXT,UH UH,YOU ARE,U,YOUR,WHAT?,UH HUH,SURE,DONE,LIKE,HOLD")
        dic.Add("ur", "DONE,U,UR,UH HUH,WHAT?,SURE,YOUR,HOLD,YOU'RE,LIKE,NEXT,UH UH,YOU ARE,YOU")
        dic.Add("u", "UH HUH,SURE,NEXT,WHAT?,YOU'RE,UR,UH UH,DONE,U,YOU,LIKE,HOLD,YOU ARE,YOUR")
        dic.Add("uh huh", "UH HUH,YOUR,YOU ARE,YOU,DONE,HOLD,UH UH,NEXT,SURE,LIKE,YOU'RE,UR,U,WHAT?")
        dic.Add("uh uh", "UR,U,YOU ARE,YOU'RE,NEXT,UH UH,DONE,YOU,UH HUH,LIKE,YOUR,SURE,HOLD,WHAT?")
        dic.Add("what?", "YOU,HOLD,YOU'RE,YOUR,U,DONE,UH UH,LIKE,YOU ARE,UH HUH,UR,NEXT,WHAT?,SURE")
        dic.Add("done", "SURE,UH HUH,NEXT,WHAT?,YOUR,UR,YOU'RE,HOLD,LIKE,YOU,U,YOU ARE,UH UH,DONE")
        dic.Add("next", "WHAT?,UH HUH,UH UH,YOUR,HOLD,SURE,NEXT,LIKE,DONE,YOU ARE,UR,YOU'RE,U,YOU")
        dic.Add("hold", "YOU ARE,U,DONE,UH UH,YOU,UR,SURE,WHAT?,YOU'RE,NEXT,HOLD,UH HUH,YOUR,LIKE")
        dic.Add("sure", "YOU ARE,DONE,LIKE,YOU'RE,YOU,HOLD,UH HUH,UR,SURE,U,WHAT?,NEXT,YOUR,UH UH")
        dic.Add("like", "YOU'RE,NEXT,U,UR,HOLD,DONE,UH UH,WHAT?,UH HUH,YOU,LIKE,SURE,YOU ARE,YOUR")

        TL.Add("ur")

        TR.Add("first")
        TR.Add("okay")
        TR.Add("c")

        ML.Add("yes")
        ML.Add("nothing")
        ML.Add("led")
        ML.Add("they are")

        MR.Add("blank")
        MR.Add("read")
        MR.Add("red")
        MR.Add("you")
        MR.Add("your")
        MR.Add("you're")
        MR.Add("their")

        BL.Add(" ")
        BL.Add("reed")
        BL.Add("leed")
        BL.Add("they're")

        BR.Add("display")
        BR.Add("says")
        BR.Add("no")
        BR.Add("lead")
        BR.Add("hold on")
        BR.Add("you are")
        BR.Add("there")
        BR.Add("see")
        BR.Add("cee")
    End Sub

    Public Function getPosition(word As String) As String
        If (TL.Contains(word)) Then
            Return "Top Left"
        ElseIf (TR.Contains(word)) Then
            Return "Top Right"
        ElseIf (ML.Contains(word)) Then
            Return "Middle Left"
        ElseIf (MR.Contains(word)) Then
            Return "Middle Right"
        ElseIf (BL.Contains(word)) Then
            Return "Bottom Left"
        ElseIf (BR.Contains(word)) Then
            Return "Bottom Right"
        Else
            Return "No position found"
        End If
    End Function

    Public Function getList(word As String) As String
        Return (dic(word))
    End Function
End Class
