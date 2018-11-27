Public Class Plant
    Inherits PictureBox

    Private nWidth = 200

    Public Sub New()
        MyBase.New()

        Dim rnd1 As Random = New Random()
        Dim nImage As Integer = rnd1.Next(1, 4)

        Select Case nImage
            Case 1
                Me.Image = My.Resources.car
            Case 2
                Me.Image = My.Resources.house
            Case 3
                Me.Image = My.Resources.plant
        End Select
        Me.Size = New System.Drawing.Size(nWidth, nWidth)
        Me.SizeMode = PictureBoxSizeMode.StretchImage
        Form1._images(Val(Me.Tag)) = nImage

    End Sub

    Public Sub fClick()
        Me.Image = My.Resources.plant
    End Sub

    Private Sub Plant_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Dim rnd1 As Random = New Random()
        Dim nImage As Integer = rnd1.Next(1, 4)

        If Form1.mbReset = True Then
            fClick()
            Exit Sub
        End If

        Select Case nImage
            Case 1
                Me.Image = My.Resources.car
            Case 2
                Me.Image = My.Resources.house
            Case 3
                Me.Image = My.Resources.plant
        End Select
        Form1._images(Val(Me.Tag)) = nImage
        Form1.lblGrid.Text = Me.Tag
        Form1.lblGrid2.Text = nImage.ToString


    End Sub
End Class
