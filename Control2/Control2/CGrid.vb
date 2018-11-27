Public Class CGrid
    Inherits TableLayoutPanel

    Public Sub New()
        MyBase.New()

        Me.ColumnCount = 4
        Me.RowCount = 4

        '  Me.ColumnStyles(0).Width = 240
        'Me.ColumnStyles(1).Width = 240
        'Me.ColumnStyles(2).Width = 240
        'Me.ColumnStyles(3).Width = 240

        ' Me.RowStyles(0).Height = 240
        '        Me.RowStyles(1).Height = 240
        '        Me.RowStyles(2).Height = 240
        '        Me.RowStyles(3).Height = 240

    End Sub

End Class
