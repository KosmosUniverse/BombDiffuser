﻿Public Class Form1
    Dim gen As General
    Dim memNum As New MemNum
    Dim words As New Words
    Dim seqWire As New SeqWire
    Dim pass As New Pass
    Dim mors As New Morse
    Dim hori As New HoriWire
    Dim sim As New Simon
    Dim maze As New Maze
    Dim type As Boolean
    Dim lst As New List(Of String)
    Dim lst2 As New Dictionary(Of String, String)
    Dim pics As New List(Of Boolean)
    Dim sym As New Symbols

    Private Sub Bload_Click(sender As Object, e As EventArgs) Handles Bload.Click
        Try
            Dim tmp As Integer = Integer.Parse(TBnbBat.Text)
        Catch ex As Exception
            MsgBox("[ERROR]: Cannot load, battery have to be a number", vbOKOnly + vbObjectError, "Error")
            TBnbBat.Text = ""
            Return
        End Try
        gen = New General(Integer.Parse(TBnbBat.Text), CBfrk.Checked, CBcar.Checked, CBserNum.Checked, CBserVoy.Checked, CBport.Checked)

        GBbut.Enabled = True
        GBcolor.Enabled = True
        GBmorse.Enabled = True
        GBnumMem.Enabled = True
        GBpass.Enabled = True
        GBseqWire.Enabled = True
        GBtext.Enabled = True
        GBvertWire.Enabled = True
        GBword.Enabled = True
        GBhoriz.Enabled = True
        GBsimon.Enabled = True
        GBsymbol.Enabled = True
        GBMaze.Enabled = True

        For i As Integer = 0 To 26
            pics.Add(False)
        Next

        buttonChanged()
        vertWireChanged()
    End Sub

    Private Sub GeneralEnter(sender As Object, e As KeyEventArgs) Handles TBnbBat.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Bload.PerformClick()
        End If
    End Sub

    Private Sub buttonChanged()
        If (RBblue.Checked And RBabort.Checked) Then
            TBresult.Text = "Hold"
        ElseIf (RBdetonate.Checked And gen.getBat() > 1) Then
            TBresult.Text = "Click"
        ElseIf (RBwhite.Checked And gen.getCar()) Then
            TBresult.Text = "Hold"
        ElseIf (gen.getBat() > 2 And gen.getFrk()) Then
            TBresult.Text = "Click"
        ElseIf (RByellow.Checked) Then
            TBresult.Text = "Hold"
        ElseIf (RBred.Checked And RBhold.Checked) Then
            TBresult.Text = "Click"
        Else
            TBresult.Text = "Hold"
        End If
    End Sub

    Private Sub ButtonCheckedChanged(sender As Object, e As EventArgs) Handles RBblue.CheckedChanged, RBred.CheckedChanged, RBwhite.CheckedChanged, RByellow.CheckedChanged, RBhold.CheckedChanged, RBdetonate.CheckedChanged, RBabort.CheckedChanged, RBother.CheckedChanged
        buttonChanged()
    End Sub

    Private Sub vertWireChanged()
        If ((Not (CBblue.Checked Or CBred.Checked Or CBstar.Checked Or CBled.Checked)) Or
            (Not (CBblue.Checked Or CBled.Checked) And CBred.Checked And CBstar.Checked) Or
            (Not (CBred.Checked Or CBblue.Checked Or CBled.Checked) And CBstar.Checked)) Then
            TBresult2.Text = "Cut"
        ElseIf (gen.getPort() And
                ((Not (CBred.Checked Or CBstar.Checked) And CBblue.Checked And CBled.Checked) Or
                (Not CBred.Checked And CBblue.Checked And CBstar.Checked And CBled.Checked) Or
                (Not CBled.Checked And CBblue.Checked And CBstar.Checked And CBred.Checked))) Then
            TBresult2.Text = "Cut"
        ElseIf (gen.getSerNum() And
                ((Not (CBred.Checked Or CBstar.Checked Or CBled.Checked) And CBblue.Checked) Or
                (Not (CBblue.Checked Or CBstar.Checked Or CBled.Checked) And CBred.Checked) Or
                (Not (CBstar.Checked Or CBled.Checked) And CBblue.Checked And CBred.Checked) Or
                (Not CBstar.Checked And CBblue.Checked And CBred.Checked And CBled.Checked))) Then
            TBresult2.Text = "Cut"
        ElseIf (gen.getBat() > 1 And
                ((Not (CBblue.Checked Or CBstar.Checked) And CBred.Checked And CBled.Checked) Or
                (Not CBblue.Checked And CBred.Checked And CBled.Checked And CBstar.Checked) Or
                (Not (CBred.Checked And CBblue.Checked) And CBstar.Checked And CBled.Checked))) Then
            TBresult2.Text = "Cut"
        Else
            TBresult2.Text = "Do Not Cut"
        End If
    End Sub

    Private Sub VertWireCheckedChanged(sender As Object, e As EventArgs) Handles CBblue.CheckedChanged, CBred.CheckedChanged, CBled.CheckedChanged, CBstar.CheckedChanged
        vertWireChanged()
    End Sub

    Private Sub Bred_Click(sender As Object, e As EventArgs) Handles Bred.Click
        Dim tmp As Boolean = False

        If (RBa.Checked) Then
            tmp = seqWire.cutRed("A")
        ElseIf (RBb.Checked) Then
            tmp = seqWire.cutRed("B")
        ElseIf (RBc.Checked) Then
            tmp = seqWire.cutRed("C")
        End If

        If (tmp) Then
            TBresult3.Text = "Cut"
        Else
            TBresult3.Text = "Do Not Cut"
        End If

        RBa.Checked = False
        RBb.Checked = False
        RBc.Checked = False
        Bred.Enabled = False
        Bblack.Enabled = False
        Bblue.Enabled = False
    End Sub

    Private Sub Bblue_Click(sender As Object, e As EventArgs) Handles Bblue.Click
        Dim tmp As Boolean = False

        If (RBa.Checked) Then
            tmp = seqWire.cutBlue("A")
        ElseIf (RBb.Checked) Then
            tmp = seqWire.cutBlue("B")
        ElseIf (RBc.Checked) Then
            tmp = seqWire.cutBlue("C")
        End If

        If (tmp) Then
            TBresult3.Text = "Cut"
        Else
            TBresult3.Text = "Do Not Cut"
        End If

        RBa.Checked = False
        RBb.Checked = False
        RBc.Checked = False
        Bred.Enabled = False
        Bblack.Enabled = False
        Bblue.Enabled = False
    End Sub

    Private Sub Bblack_Click(sender As Object, e As EventArgs) Handles Bblack.Click
        Dim tmp As Boolean = False

        If (RBa.Checked) Then
            tmp = seqWire.cutBlack("A")
        ElseIf (RBb.Checked) Then
            tmp = seqWire.cutBlack("B")
        ElseIf (RBc.Checked) Then
            tmp = seqWire.cutBlack("C")
        End If

        If (tmp) Then
            TBresult3.Text = "Cut"
        Else
            TBresult3.Text = "Do Not Cut"
        End If

        RBa.Checked = False
        RBb.Checked = False
        RBc.Checked = False
        Bred.Enabled = False
        Bblack.Enabled = False
        Bblue.Enabled = False
    End Sub

    Private Sub RB_CheckedChanged(sender As Object, e As EventArgs) Handles RBa.CheckedChanged, RBb.CheckedChanged, RBc.CheckedChanged
        If (RBa.Checked Or RBb.Checked Or RBc.Checked) Then
            Bred.Enabled = True
            Bblue.Enabled = True
            Bblack.Enabled = True
        End If
    End Sub

    Private Sub Bsearch_Click(sender As Object, e As EventArgs) Handles Bsearch1.Click
        TBinput2.Text = ""
        TBlist.Text = ""

        If Not (TBinput.Text.Length = 0) Then
            Dim isGood As Boolean
            Dim str As String
            With words.getPosition(TBinput.Text)
                isGood = .Item1
                str = .Item2
            End With

            If (isGood) Then
                TBresult8.Text = str
            Else
                TBresult8.Text = "No position found."
            End If
        Else
            MsgBox("[ERROR]: you forgot to fulfill the above field", vbOKOnly + vbObjectError, "Error")
        End If
    End Sub

    Private Sub TBinput_Enter(sender As Object, e As KeyEventArgs) Handles TBinput.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Bsearch1.PerformClick()
        End If
    End Sub

    Private Sub Bsearch2_Click(sender As Object, e As EventArgs) Handles Bsearch2.Click
        TBinput.Text = ""
        If (TBinput2.Text.Length = 0) Then
            MsgBox("[ERROR]: you forgot to fulfill the above field", vbOKOnly + vbObjectError, "Error")
            Return
        End If

        Dim tmp As String
        Dim isGood As Boolean

        With words.getList(TBinput2.Text)
            isGood = .Item1
            tmp = .Item2
        End With

        If (isGood) Then
            Dim tab As String() = tmp.Split(", ")

            TBlist.Text = ""

            For Each word In tab
                TBlist.Text += word + vbNewLine
            Next
        Else
            TBlist.Text = "No list found, please retry with a good word."
        End If
    End Sub

    Private Sub TBinput2_Enter(sender As Object, e As KeyEventArgs) Handles TBinput2.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Bsearch2.PerformClick()
        End If
    End Sub

    Private Sub Breset_Click(sender As Object, e As EventArgs) Handles Breset.Click
        seqWire.reset()
        RBa.Checked = False
        RBb.Checked = False
        RBc.Checked = False
        Bred.Enabled = False
        Bblack.Enabled = False
        Bblue.Enabled = False
        TBresult3.Text = ""
    End Sub

    Private Sub TBnum_TextChanged(sender As Object, e As EventArgs) Handles TBnum.TextChanged
        Dim num As Integer
        Dim numCheck As Integer

        TBlab.Text = ""
        TBpos.Text = ""

        If (Not TBnum.Text.Length = 0 And Not TBnum.Text.Contains(" ")) Then
            numCheck = Integer.Parse(TBnum.Text)
            If Not (numCheck <= 4 And numCheck >= 1) Then
                TBlab.Text = ""
                TBpos.Text = ""
                MsgBox("[ERROR]: the number you entered have to be 1, 2, 3, or 4", vbOKOnly + vbObjectError, "Error")
                Return
            End If
            With memNum.stage1(numCheck)
                type = .Item1
                num = .Item2
            End With

            If (type) Then
                TBlab.Text = num
            Else
                TBpos.Text = num
            End If
        End If
    End Sub

    Private Sub TBnum2_TextChanged(sender As Object, e As EventArgs) Handles TBnum2.TextChanged

        TBlab2.Text = ""
        TBpos2.Text = ""

        memNum.TBNext(2, type, TBnum2, TBpos2, TBlab2, TBpos, TBlab)
    End Sub

    Private Sub TBnum3_TextChanged(sender As Object, e As EventArgs) Handles TBnum3.TextChanged

        TBlab3.Text = ""
        TBpos3.Text = ""

        memNum.TBNext(3, type, TBnum3, TBpos3, TBlab3, TBpos2, TBlab2)
    End Sub

    Private Sub TBnum4_TextChanged(sender As Object, e As EventArgs) Handles TBnum4.TextChanged

        TBlab4.Text = ""
        TBpos4.Text = ""

        memNum.TBNext(4, type, TBnum4, TBpos4, TBlab4, TBpos3, TBlab3)
    End Sub

    Private Sub TBnum5_TextChanged(sender As Object, e As EventArgs) Handles TBnum5.TextChanged

        TBlab5.Text = ""
        TBpos5.Text = ""

        memNum.TBNext(5, type, TBnum5, TBpos5, TBlab5, TBpos4, TBlab4)
    End Sub

    Private Sub Breset2_Click(sender As Object, e As EventArgs) Handles Breset2.Click
        memNum.reset()
        TBnum.Text = ""
        TBlab.Text = ""
        TBpos.Text = ""
        TBnum2.Text = ""
        TBlab2.Text = ""
        TBpos2.Text = ""
        TBnum3.Text = ""
        TBlab3.Text = ""
        TBpos3.Text = ""
        TBnum4.Text = ""
        TBlab4.Text = ""
        TBpos4.Text = ""
        TBnum5.Text = ""
        TBlab5.Text = ""
        TBpos5.Text = ""
    End Sub

    Private Sub ButtonHoldCheckedChanged(sender As Object, e As EventArgs) Handles RByellow2.CheckedChanged, RBblue2.CheckedChanged, RBother2.CheckedChanged
        If (RByellow2.Checked) Then
            TBresult6.Text = "5"
        ElseIf (RBblue2.Checked) Then
            TBresult6.Text = "4"
        ElseIf (RBother2.Checked) Then
            TBresult6.Text = "1"
        End If
    End Sub

    Private Sub TBline1_TextChanged(sender As Object, e As EventArgs) Handles TBline1.TextChanged
        If (TBline1.Text.Length = 6) Then
            lst = pass.getFirst(TBline1.Text)
            TBline2.Enabled = True
            If (lst.Count() < 5) Then
                TBresult4.Text = ""
                For Each possib In lst
                    TBresult4.Text += possib + "; "
                Next
            End If
        End If
    End Sub

    Private Sub TBline2_TextChanged(sender As Object, e As EventArgs) Handles TBline2.TextChanged
        If (TBline2.Text.Length = 6) Then
            lst = pass.getNext(TBline2.Text, lst, 1)
            TBline3.Enabled = True
            If (lst.Count() < 5) Then
                TBresult4.Text = ""
                For Each possib In lst
                    TBresult4.Text += possib + "; "
                Next
            End If
        End If
    End Sub

    Private Sub TBline3_TextChanged(sender As Object, e As EventArgs) Handles TBline3.TextChanged
        If (TBline3.Text.Length = 6) Then
            lst = pass.getNext(TBline3.Text, lst, 2)
            If (lst.Count() < 5) Then
                TBresult4.Text = ""
                For Each possib In lst
                    TBresult4.Text += possib + "; "
                Next
            End If
        End If
    End Sub

    Private Sub BresetPass_Click(sender As Object, e As EventArgs) Handles BresetPass.Click
        TBline1.Text = ""
        TBline2.Text = ""
        TBline3.Text = ""
        TBresult4.Text = ""
    End Sub

    Private Sub Bok_Click(sender As Object, e As EventArgs) Handles Bok.Click
        If Not (mors.convert(TBletter1.Text) = "False") Then
            lst2 = mors.getFirst(mors.convert(TBletter1.Text))
            If (lst2.Count() = 1) Then
                TBresult5.Text = ""
                TBresult5.Text = lst2.ElementAt(0).Value
            ElseIf (lst2.Count() > 0) Then
                TBletter2.Enabled = True
                Bok2.Enabled = True
                If (lst2.Count() < 5) Then
                    TBresult5.Text = ""
                    For Each item In lst2
                        TBresult5.Text += item.Value + "; "
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub TBletter1_Enter(sender As Object, e As KeyEventArgs) Handles TBletter1.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Bok.PerformClick()
        End If
    End Sub

    Private Sub Bok2_Click(sender As Object, e As EventArgs) Handles Bok2.Click
        If Not (mors.convert(TBletter2.Text) = "False") Then
            lst2 = mors.getNext(mors.convert(TBletter2.Text), lst2, 1)
            If (lst2.Count() = 1) Then
                TBresult5.Text = ""
                For Each item In lst2
                    TBresult5.Text = lst2.ElementAt(0).Value
                Next
            ElseIf (lst2.Count() > 0) Then
                TBletter3.Enabled = True
                Bok3.Enabled = True
                If (lst2.Count() < 5) Then
                    TBresult5.Text = ""
                    For Each item In lst2
                        TBresult5.Text += item.Value + "; "
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub TBletter2_Enter(sender As Object, e As KeyEventArgs) Handles TBletter2.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Bok2.PerformClick()
        End If
    End Sub

    Private Sub Bok3_Click(sender As Object, e As EventArgs) Handles Bok3.Click
        If Not (mors.convert(TBletter3.Text) = "False") Then
            lst2 = mors.getNext(mors.convert(TBletter3.Text), lst2, 2)
            If (lst2.Count() = 1) Then
                TBresult5.Text = ""
                TBresult5.Text += lst2.ElementAt(0).Value
            ElseIf (lst2.Count() > 0) Then
                If (lst2.Count() < 5) Then
                    TBresult5.Text = ""
                    For Each item In lst2
                        TBresult5.Text += item.Value + "; "
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub TBletter3_Enter(sender As Object, e As KeyEventArgs) Handles TBletter3.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Bok3.PerformClick()
        End If
    End Sub

    Private Sub BresetMors_Click(sender As Object, e As EventArgs) Handles BresetMors.Click
        TBletter1.Text = ""
        TBletter2.Text = ""
        TBletter3.Text = ""
        TBresult5.Text = ""
    End Sub

    Private Sub Bcolor_Click(sender As Object, e As EventArgs) Handles Bcolor.Click
        Dim len As Integer = TBcolor.Text.Length
        If (Not len = 0 And len > 2 And len < 7) Then
            If (len = 3) Then
                TBcut.Text = hori.three(TBcolor.Text)
            ElseIf (len = 4) Then
                TBcut.Text = hori.four(TBcolor.Text, Not gen.getSerNum)
            ElseIf (len = 5) Then
                TBcut.Text = hori.five(TBcolor.Text, Not gen.getSerNum)
            ElseIf (len = 6) Then
                TBcut.Text = hori.six(TBcolor.Text, Not gen.getSerNum)
            End If
        End If
    End Sub

    Private Sub Bred2_Click(sender As Object, e As EventArgs) Handles Bred2.Click
        If (TBstrike.Text = "0" Or TBstrike.Text = "1" Or TBstrike.Text = "2") Then
            TBresult7.Text += sim.getColor(TBstrike.Text + "R", gen.getSerVoy()) + "; "
        End If
    End Sub

    Private Sub Bblue2_Click(sender As Object, e As EventArgs) Handles Bblue2.Click
        If (TBstrike.Text = "0" Or TBstrike.Text = "1" Or TBstrike.Text = "2") Then
            TBresult7.Text += sim.getColor(TBstrike.Text + "B", gen.getSerVoy()) + "; "
        End If
    End Sub

    Private Sub Byellow2_Click(sender As Object, e As EventArgs) Handles Byellow2.Click
        If (TBstrike.Text = "0" Or TBstrike.Text = "1" Or TBstrike.Text = "2") Then
            TBresult7.Text += sim.getColor(TBstrike.Text + "Y", gen.getSerVoy()) + "; "
        End If
    End Sub

    Private Sub Bgreen2_Click(sender As Object, e As EventArgs) Handles Bgreen2.Click
        If (TBstrike.Text = "0" Or TBstrike.Text = "1" Or TBstrike.Text = "2") Then
            TBresult7.Text += sim.getColor(TBstrike.Text + "G", gen.getSerVoy()) + "; "
        End If
    End Sub

    Private Sub Breset3_Click(sender As Object, e As EventArgs) Handles Breset3.Click
        TBresult7.Text = ""
        TBstrike.Text = ""
    End Sub

    Private Sub TBstrike_TextChanged(sender As Object, e As EventArgs) Handles TBstrike.TextChanged
        TBresult7.Text = ""
    End Sub

    Private Sub PB1_Click(sender As Object, e As EventArgs) Handles PB1.Click
        pics(0) = Not pics.ElementAt(0)
        If (pics(0)) Then
            PB1.Image = My.Resources.Gpic1
        Else
            PB1.Image = My.Resources.pic1
        End If
    End Sub

    Private Sub PB2_Click(sender As Object, e As EventArgs) Handles PB2.Click
        pics(1) = Not pics.ElementAt(1)
        If (pics(1)) Then
            PB2.Image = My.Resources.Gpic2
        Else
            PB2.Image = My.Resources.pic2
        End If
    End Sub

    Private Sub PB3_Click(sender As Object, e As EventArgs) Handles PB3.Click
        pics(2) = Not pics.ElementAt(2)
        If (pics(2)) Then
            PB3.Image = My.Resources.Gpic3
        Else
            PB3.Image = My.Resources.pic3
        End If
    End Sub

    Private Sub PB4_Click(sender As Object, e As EventArgs) Handles PB4.Click
        pics(3) = Not pics.ElementAt(3)
        If (pics(3)) Then
            PB4.Image = My.Resources.Gpic4
        Else
            PB4.Image = My.Resources.pic4
        End If
    End Sub

    Private Sub PB5_Click(sender As Object, e As EventArgs) Handles PB5.Click
        pics(4) = Not pics.ElementAt(4)
        If (pics(4)) Then
            PB5.Image = My.Resources.Gpic5
        Else
            PB5.Image = My.Resources.pic5
        End If
    End Sub

    Private Sub PB6_Click(sender As Object, e As EventArgs) Handles PB6.Click
        pics(5) = Not pics.ElementAt(5)
        If (pics(5)) Then
            PB6.Image = My.Resources.Gpic6
        Else
            PB6.Image = My.Resources.pic6
        End If
    End Sub

    Private Sub PB7_Click(sender As Object, e As EventArgs) Handles PB7.Click
        pics(6) = Not pics.ElementAt(6)
        If (pics(6)) Then
            PB7.Image = My.Resources.Gpic7
        Else
            PB7.Image = My.Resources.pic7
        End If
    End Sub

    Private Sub PB8_Click(sender As Object, e As EventArgs) Handles PB8.Click
        pics(7) = Not pics.ElementAt(7)
        If (pics(7)) Then
            PB8.Image = My.Resources.Gpic8
        Else
            PB8.Image = My.Resources.pic8
        End If
    End Sub

    Private Sub PB9_Click(sender As Object, e As EventArgs) Handles PB9.Click
        pics(8) = Not pics.ElementAt(8)
        If (pics(8)) Then
            PB9.Image = My.Resources.Gpic9
        Else
            PB9.Image = My.Resources.pic9
        End If
    End Sub

    Private Sub PB10_Click(sender As Object, e As EventArgs) Handles PB10.Click
        pics(9) = Not pics.ElementAt(9)
        If (pics(9)) Then
            PB10.Image = My.Resources.Gpic10
        Else
            PB10.Image = My.Resources.pic10
        End If
    End Sub

    Private Sub PB11_Click(sender As Object, e As EventArgs) Handles PB11.Click
        pics(10) = Not pics.ElementAt(10)
        If (pics(10)) Then
            PB11.Image = My.Resources.Gpic11
        Else
            PB11.Image = My.Resources.pic11
        End If
    End Sub

    Private Sub PB12_Click(sender As Object, e As EventArgs) Handles PB12.Click
        pics(11) = Not pics.ElementAt(11)
        If (pics(11)) Then
            PB12.Image = My.Resources.Gpic12
        Else
            PB12.Image = My.Resources.pic12
        End If
    End Sub

    Private Sub PB13_Click(sender As Object, e As EventArgs) Handles PB13.Click
        pics(12) = Not pics.ElementAt(12)
        If (pics(12)) Then
            PB13.Image = My.Resources.Gpic13
        Else
            PB13.Image = My.Resources.pic13
        End If
    End Sub

    Private Sub PB14_Click(sender As Object, e As EventArgs) Handles PB14.Click
        pics(13) = Not pics.ElementAt(13)
        If (pics(13)) Then
            PB14.Image = My.Resources.Gpic14
        Else
            PB14.Image = My.Resources.pic14
        End If
    End Sub

    Private Sub PB15_Click(sender As Object, e As EventArgs) Handles PB15.Click
        pics(14) = Not pics.ElementAt(14)
        If (pics(14)) Then
            PB15.Image = My.Resources.Gpic15
        Else
            PB15.Image = My.Resources.pic15
        End If
    End Sub

    Private Sub PB16_Click(sender As Object, e As EventArgs) Handles PB16.Click
        pics(15) = Not pics.ElementAt(15)
        If (pics(15)) Then
            PB16.Image = My.Resources.Gpic16
        Else
            PB16.Image = My.Resources.pic16
        End If
    End Sub

    Private Sub PB17_Click(sender As Object, e As EventArgs) Handles PB17.Click
        pics(16) = Not pics.ElementAt(16)
        If (pics(16)) Then
            PB17.Image = My.Resources.Gpic17
        Else
            PB17.Image = My.Resources.pic17
        End If
    End Sub

    Private Sub PB18_Click(sender As Object, e As EventArgs) Handles PB18.Click
        pics(17) = Not pics.ElementAt(17)
        If (pics(17)) Then
            PB18.Image = My.Resources.Gpic18
        Else
            PB18.Image = My.Resources.pic18
        End If
    End Sub

    Private Sub PB19_Click(sender As Object, e As EventArgs) Handles PB19.Click
        pics(18) = Not pics.ElementAt(18)
        If (pics(18)) Then
            PB19.Image = My.Resources.Gpic19
        Else
            PB19.Image = My.Resources.pic19
        End If
    End Sub

    Private Sub PB20_Click(sender As Object, e As EventArgs) Handles PB20.Click
        pics(19) = Not pics.ElementAt(19)
        If (pics(19)) Then
            PB20.Image = My.Resources.Gpic20
        Else
            PB20.Image = My.Resources.pic20
        End If
    End Sub

    Private Sub PB21_Click(sender As Object, e As EventArgs) Handles PB21.Click
        pics(20) = Not pics.ElementAt(20)
        If (pics(20)) Then
            PB21.Image = My.Resources.Gpic21
        Else
            PB21.Image = My.Resources.pic21
        End If
    End Sub

    Private Sub PB22_Click(sender As Object, e As EventArgs) Handles PB22.Click
        pics(21) = Not pics.ElementAt(21)
        If (pics(21)) Then
            PB22.Image = My.Resources.Gpic22
        Else
            PB22.Image = My.Resources.pic22
        End If
    End Sub

    Private Sub PB23_Click(sender As Object, e As EventArgs) Handles PB23.Click
        pics(22) = Not pics.ElementAt(22)
        If (pics(22)) Then
            PB23.Image = My.Resources.Gpic23
        Else
            PB23.Image = My.Resources.pic23
        End If
    End Sub

    Private Sub PB24_Click(sender As Object, e As EventArgs) Handles PB24.Click
        pics(23) = Not pics.ElementAt(23)
        If (pics(23)) Then
            PB24.Image = My.Resources.Gpic24
        Else
            PB24.Image = My.Resources.pic24
        End If
    End Sub

    Private Sub PB25_Click(sender As Object, e As EventArgs) Handles PB25.Click
        pics(24) = Not pics.ElementAt(24)
        If (pics(24)) Then
            PB25.Image = My.Resources.Gpic25
        Else
            PB25.Image = My.Resources.pic25
        End If
    End Sub

    Private Sub PB26_Click(sender As Object, e As EventArgs) Handles PB26.Click
        pics(25) = Not pics.ElementAt(25)
        If (pics(25)) Then
            PB26.Image = My.Resources.Gpic26
        Else
            PB26.Image = My.Resources.pic26
        End If
    End Sub

    Private Sub PB27_Click(sender As Object, e As EventArgs) Handles PB27.Click
        pics(26) = Not pics.ElementAt(26)
        If (pics(26)) Then
            PB27.Image = My.Resources.Gpic27
        Else
            PB27.Image = My.Resources.pic27
        End If
    End Sub

    Private Sub Bprocess_Click(sender As Object, e As EventArgs) Handles Bprocess.Click
        Dim nb As Integer = 0
        Dim idx As Integer = 0
        Dim lstTrue As New List(Of Integer)

        For Each pic In pics
            If (pic) Then
                nb += 1
                lstTrue.Add(idx + 1)
            End If
            idx += 1
        Next

        If (nb = 4) Then
            lstTrue = sym.getOrder(lstTrue)
            If (lstTrue.Count = 4) Then
                PBres1.Image = sym.getImage(lstTrue(0))
                PBres2.Image = sym.getImage(lstTrue(1))
                PBres3.Image = sym.getImage(lstTrue(2))
                PBres4.Image = sym.getImage(lstTrue(3))
            End If
        Else
            MsgBox("[ERROR]: You have selected more or less than 4 images" & nb, vbOKOnly + vbObjectError, "Error")
        End If

        resetSymbols()

    End Sub

    Private Sub resetSymbols()

        For i As Integer = 0 To 26
            pics(i) = False
        Next

        PB1.Image = My.Resources.pic1
        PB2.Image = My.Resources.pic2
        PB3.Image = My.Resources.pic3
        PB4.Image = My.Resources.pic4
        PB5.Image = My.Resources.pic5
        PB6.Image = My.Resources.pic6
        PB7.Image = My.Resources.pic7
        PB8.Image = My.Resources.pic8
        PB9.Image = My.Resources.pic9
        PB10.Image = My.Resources.pic10
        PB11.Image = My.Resources.pic11
        PB12.Image = My.Resources.pic12
        PB13.Image = My.Resources.pic13
        PB14.Image = My.Resources.pic14
        PB15.Image = My.Resources.pic15
        PB16.Image = My.Resources.pic16
        PB17.Image = My.Resources.pic17
        PB18.Image = My.Resources.pic18
        PB19.Image = My.Resources.pic19
        PB20.Image = My.Resources.pic20
        PB21.Image = My.Resources.pic21
        PB22.Image = My.Resources.pic22
        PB23.Image = My.Resources.pic23
        PB24.Image = My.Resources.pic24
        PB25.Image = My.Resources.pic25
        PB26.Image = My.Resources.pic26
        PB27.Image = My.Resources.pic27
    End Sub

    Private Function checkInput(str As String) As Boolean
        If (str.Length = 0) Then
            MsgBox("[ERROR]: You forgot to fulfill one or more of the 4 field above.", vbOKOnly + vbObjectError, "Error")
            Return True
        ElseIf (Integer.Parse(str) > 6 Or Integer.Parse(str) < 1) Then
            MsgBox("[ERROR]: The value youn entered in one of the above field is not between 1 and 6 included.", vbOKOnly + vbObjectError, "Error")
            Return True
        End If
        Return False
    End Function

    Private Sub BSearchMaze_Click(sender As Object, e As EventArgs) Handles BSearchMaze.Click
        If (checkInput(TBxcricle1.Text) Or checkInput(TBycircle1.Text) Or checkInput(TBxcircle2.Text) Or checkInput(TBycircle2.Text)) Then
            Return
        End If

        Dim firstCircle As New Maze.Pos
        Dim secondCircle As New Maze.Pos

        With firstCircle
            .x = Integer.Parse(TBxcricle1.Text)
            .y = Integer.Parse(TBycircle1.Text)
        End With

        With secondCircle
            .x = Integer.Parse(TBxcircle2.Text)
            .y = Integer.Parse(TBycircle2.Text)
        End With

        If (maze.selectMaze(firstCircle, secondCircle)) Then
            TBxsquare.Enabled = True
            TBysquare.Enabled = True
            TBxtriangle.Enabled = True
            TBytriangle.Enabled = True
            BPath.Enabled = True
        Else
            TBxsquare.Enabled = False
            TBysquare.Enabled = False
            TBxtriangle.Enabled = False
            TBytriangle.Enabled = False
            BPath.Enabled = False
            MsgBox("[ERROR]: Cannot find your maze, please verify circle coordonates.", vbOKOnly + vbObjectError, "Error")
            Return
        End If
    End Sub

    Private Sub BPath_Click(sender As Object, e As EventArgs) Handles BPath.Click
        If (checkInput(TBxtriangle.Text) Or checkInput(TBytriangle.Text) Or checkInput(TBxsquare.Text) Or checkInput(TBysquare.Text)) Then
            Return
        End If

        Dim triangle As New Maze.Pos
        Dim square As New Maze.Pos

        With triangle
            .x = Integer.Parse(TBxtriangle.Text)
            .y = Integer.Parse(TBytriangle.Text)
        End With

        With square
            .x = Integer.Parse(TBxsquare.Text)
            .y = Integer.Parse(TBysquare.Text)
        End With

        maze.searchPath(triangle, square, TBPath)
    End Sub

    Private Sub BresetMaze_Click(sender As Object, e As EventArgs) Handles BresetMaze.Click
        TBxcricle1.Text = ""
        TBycircle1.Text = ""
        TBxcircle2.Text = ""
        TBycircle2.Text = ""
        TBxtriangle.Text = ""
        TBytriangle.Text = ""
        TBxsquare.Text = ""
        TBysquare.Text = ""
        TBPath.Text = ""
        TBxsquare.Enabled = False
        TBysquare.Enabled = False
        TBxtriangle.Enabled = False
        TBytriangle.Enabled = False
        BPath.Enabled = False
    End Sub
End Class
