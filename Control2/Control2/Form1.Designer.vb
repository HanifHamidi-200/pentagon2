<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.grd1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblGrid = New System.Windows.Forms.Label()
        Me.lblGrid2 = New System.Windows.Forms.Label()
        Me.Stopwatch1 = New Control2.Stopwatch()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(73, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(241, 240)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Stop"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'grd1
        '
        Me.grd1.ColumnCount = 4
        Me.grd1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.75281!))
        Me.grd1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.24719!))
        Me.grd1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.grd1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.grd1.Location = New System.Drawing.Point(384, 32)
        Me.grd1.Name = "grd1"
        Me.grd1.RowCount = 4
        Me.grd1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.70454!))
        Me.grd1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.29546!))
        Me.grd1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88.0!))
        Me.grd1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.grd1.Size = New System.Drawing.Size(391, 384)
        Me.grd1.TabIndex = 4
        '
        'lblGrid
        '
        Me.lblGrid.AutoSize = True
        Me.lblGrid.Location = New System.Drawing.Point(304, 52)
        Me.lblGrid.Name = "lblGrid"
        Me.lblGrid.Size = New System.Drawing.Size(32, 13)
        Me.lblGrid.TabIndex = 5
        Me.lblGrid.Text = "Grid1"
        '
        'lblGrid2
        '
        Me.lblGrid2.AutoSize = True
        Me.lblGrid2.Location = New System.Drawing.Point(304, 80)
        Me.lblGrid2.Name = "lblGrid2"
        Me.lblGrid2.Size = New System.Drawing.Size(32, 13)
        Me.lblGrid2.TabIndex = 6
        Me.lblGrid2.Text = "Grid2"
        '
        'Stopwatch1
        '
        Me.Stopwatch1.AutoSize = True
        Me.Stopwatch1.Location = New System.Drawing.Point(154, 181)
        Me.Stopwatch1.Name = "Stopwatch1"
        Me.Stopwatch1.Size = New System.Drawing.Size(64, 13)
        Me.Stopwatch1.TabIndex = 3
        Me.Stopwatch1.Text = "Stopwatch1"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(261, 96)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.lblGrid2)
        Me.Controls.Add(Me.lblGrid)
        Me.Controls.Add(Me.grd1)
        Me.Controls.Add(Me.Stopwatch1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Stopwatch1 As Stopwatch
    Friend WithEvents grd1 As TableLayoutPanel
    Friend WithEvents lblGrid As Label
    Friend WithEvents lblGrid2 As Label
    Friend WithEvents btnReset As Button
End Class
