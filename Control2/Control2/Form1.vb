Public Class Form1
    Public _images(16) As Integer
    Public _tag(4, 4) As String
    Public mbReset As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Stopwatch1.StartStopwatch()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Stopwatch1.StopStopwatch()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nTag As Integer = 0

        For i As Integer = 1 To 4
            For j As Integer = 1 To 4
                Dim plant As New Plant()

                nTag = nTag + 1

                _tag(i, j) = nTag.ToString
                plant.Tag = nTag.ToString

                grd1.Controls.Add(plant)

            Next
        Next
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        mbReset = Not mbReset

    End Sub
End Class
