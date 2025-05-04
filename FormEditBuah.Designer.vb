<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditBuah
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nama_buah = New System.Windows.Forms.TextBox()
        Me.harga_buah = New System.Windows.Forms.TextBox()
        Me.stok_buah = New System.Windows.Forms.TextBox()
        Me.simpan = New System.Windows.Forms.Button()
        Me.Batal = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nama buah"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "harga buah"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "stok buah"
        '
        'nama_buah
        '
        Me.nama_buah.Location = New System.Drawing.Point(160, 52)
        Me.nama_buah.Name = "nama_buah"
        Me.nama_buah.Size = New System.Drawing.Size(217, 22)
        Me.nama_buah.TabIndex = 3
        '
        'harga_buah
        '
        Me.harga_buah.Location = New System.Drawing.Point(160, 111)
        Me.harga_buah.Name = "harga_buah"
        Me.harga_buah.Size = New System.Drawing.Size(217, 22)
        Me.harga_buah.TabIndex = 4
        '
        'stok_buah
        '
        Me.stok_buah.Location = New System.Drawing.Point(160, 174)
        Me.stok_buah.Name = "stok_buah"
        Me.stok_buah.Size = New System.Drawing.Size(217, 22)
        Me.stok_buah.TabIndex = 5
        '
        'simpan
        '
        Me.simpan.Location = New System.Drawing.Point(191, 225)
        Me.simpan.Name = "simpan"
        Me.simpan.Size = New System.Drawing.Size(84, 35)
        Me.simpan.TabIndex = 6
        Me.simpan.Text = "Simpan"
        Me.simpan.UseVisualStyleBackColor = True
        '
        'Batal
        '
        Me.Batal.Location = New System.Drawing.Point(293, 225)
        Me.Batal.Name = "Batal"
        Me.Batal.Size = New System.Drawing.Size(84, 35)
        Me.Batal.TabIndex = 7
        Me.Batal.Text = "Batal"
        Me.Batal.UseVisualStyleBackColor = True
        '
        'FormEditBuah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Batal)
        Me.Controls.Add(Me.simpan)
        Me.Controls.Add(Me.stok_buah)
        Me.Controls.Add(Me.harga_buah)
        Me.Controls.Add(Me.nama_buah)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormEditBuah"
        Me.Text = "FormEditBuah"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents nama_buah As TextBox
    Friend WithEvents harga_buah As TextBox
    Friend WithEvents stok_buah As TextBox
    Friend WithEvents simpan As Button
    Friend WithEvents Batal As Button
End Class
