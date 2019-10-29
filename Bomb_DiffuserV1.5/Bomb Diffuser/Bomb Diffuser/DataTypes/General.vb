Public Class General
    Dim nbBat As Integer
    Dim frk As Boolean
    Dim car As Boolean
    Dim serialNum As Boolean
    Dim serialVoy As Boolean
    Dim portpara As Boolean

    Public Sub New(nbBat As Integer, frk As Boolean, car As Boolean, serialNum As Boolean, serialVoy As Boolean, portpara As Boolean)
        Me.nbBat = nbBat
        Me.frk = frk
        Me.car = car
        Me.serialNum = serialNum
        Me.serialVoy = serialVoy
        Me.portpara = portpara
    End Sub

    Public Function getBat() As Integer
        Return (nbBat)
    End Function

    Public Function getFrk() As Boolean
        Return (frk)
    End Function

    Public Function getCar() As Boolean
        Return (car)
    End Function

    Public Function getSerNum() As Boolean
        Return (serialNum)
    End Function

    Public Function getSerVoy() As Boolean
        Return (serialVoy)
    End Function

    Public Function getPort() As Boolean
        Return (portpara)
    End Function
End Class
