Public Class Stopwatch
    Inherits Label

    Private timer As Timer
    Private startTime As Date

    Public Sub New()
        timer = New Timer
        timer.Interval = 1
        AddHandler timer.Tick, AddressOf Timer_Tick
    End Sub

    Public Sub Timer_Tick()
        Dim timeSpan As TimeSpan = Now.Subtract(startTime)

        Me.Text = timeSpan.Hours & ":" & timeSpan.Minutes & ":" & timeSpan.Seconds & ":" & timeSpan.Milliseconds

    End Sub

    Public Sub StartStopwatch()
        startTime = Now
        timer.Enabled = True
        timer.Start()

    End Sub

    Public Sub StopStopwatch()
        timer.Enabled = False
        timer.Stop()

    End Sub
End Class
