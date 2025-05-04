Imports MySql.Data.MySqlClient
Imports Mysqlx


Public Class Form1

    ' Deklarasi objek koneksi sebagai variabel tingkat kelas
    Private connectionString As String = "Server=localhost;Database=toko_buah;Uid=root;Pwd=;"
    Private dataAdapter As MySqlDataAdapter
    Private dataTable As New DataTable()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataBuah()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Pastikan koneksi tertutup saat form ditutup
        If Connection IsNot Nothing AndAlso Connection.State = ConnectionState.Open Then
            Connection.Close()
        End If
    End Sub

    Private Sub LoadDataBuah()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT id_buah, nama_buah, harga_satuan, stok FROM buah"
                dataAdapter = New MySqlDataAdapter(query, connection)
                dataTable.Clear()
                dataAdapter.Fill(dataTable)
                DataGridView1.DataSource = dataTable
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"Terjadi kesalahan saat memuat data buah: {ex.Message}", "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tambah_Click(sender As Object, e As EventArgs) Handles tambah.Click
        Dim namaBuah As String = nama_buah.Text.Trim()
        Dim hargaBuah As Decimal
        Dim stokBuah As Integer

        If Not Decimal.TryParse(harga_buah.Text, hargaBuah) Then
            MessageBox.Show("Harga buah harus berupa angka yang valid.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Integer.TryParse(stok.Text, stokBuah) Then
            MessageBox.Show("Stok harus berupa angka bulat yang valid.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim insertQuery As String = "INSERT INTO buah (nama_buah, harga_satuan, stok) VALUES (@nama, @harga, @stok)"
                Using command As New MySqlCommand(insertQuery, connection)
                    command.Parameters.AddWithValue("@nama", namaBuah)
                    command.Parameters.AddWithValue("@harga", hargaBuah)
                    command.Parameters.AddWithValue("@stok", stokBuah)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Data buah berhasil ditambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        nama_buah.Clear()
                        harga_buah.Clear()
                        stok.Clear()
                        LoadDataBuah()
                    Else
                        MessageBox.Show("Gagal menambahkan data buah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"Terjadi kesalahan saat menambahkan data: {ex.Message}", "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub edit_Click(sender As Object, e As EventArgs) Handles edit.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih baris data yang ingin diedit.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedIdBuah As Integer = DataGridView1.CurrentRow.Cells("id_buah").Value
        Dim selectedNamaBuah As String = DataGridView1.CurrentRow.Cells("nama_buah").Value
        Dim selectedHargaSatuan As Decimal = DataGridView1.CurrentRow.Cells("harga_satuan").Value
        Dim selectedStok As Integer = DataGridView1.CurrentRow.Cells("stok").Value

        Using editForm As New FormEditBuah(connectionString)
            editForm.IdBuah = selectedIdBuah
            editForm.NamaBuah = selectedNamaBuah
            editForm.HargaSatuan = selectedHargaSatuan
            editForm.Stok = selectedStok

            If editForm.ShowDialog() = DialogResult.OK Then
                LoadDataBuah()
            End If
        End Using
    End Sub

    Private Sub cari_Click(sender As Object, e As EventArgs) Handles cari.Click
        Dim keyword As String = mencari_data_buah.Text.Trim()
        SearchDataBuah(keyword)
    End Sub

    Private Sub SearchDataBuah(keyword As String)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT id_buah, nama_buah, harga_satuan, stok FROM buah " &
                                   "WHERE CAST(id_buah AS CHAR) LIKE @keyword OR " &
                                   "nama_buah LIKE @keyword OR " &
                                   "CAST(harga_satuan AS CHAR) LIKE @keyword OR " &
                                   "CAST(stok AS CHAR) LIKE @keyword"

                Using dataAdapter As New MySqlDataAdapter(query, connection)
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" & keyword & "%")
                    Dim searchDataTable As New DataTable()
                    searchDataTable.Clear()
                    dataAdapter.Fill(searchDataTable)
                    DataGridView1.DataSource = searchDataTable
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"Terjadi kesalahan saat mencari data: {ex.Message}", "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub hapus_Click(sender As Object, e As EventArgs) Handles hapus.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih baris data yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedIdBuah As Integer = DataGridView1.CurrentRow.Cells("id_buah").Value
        Dim namaBuah As String = DataGridView1.CurrentRow.Cells("nama_buah").Value

        Dim confirmResult As DialogResult = MessageBox.Show($"Apakah Anda yakin ingin menghapus buah '{namaBuah}' (ID: {selectedIdBuah})?",
                                                            "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmResult = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()
                    Dim deleteQuery As String = "DELETE FROM buah WHERE id_buah = @id"
                    Using command As New MySqlCommand(deleteQuery, connection)
                        command.Parameters.AddWithValue("@id", selectedIdBuah)
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            MessageBox.Show($"Data buah '{namaBuah}' berhasil dihapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadDataBuah()
                        Else
                            MessageBox.Show($"Gagal menghapus data buah '{namaBuah}'.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                MessageBox.Show($"Terjadi kesalahan saat menghapus data: {ex.Message}", "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub mencari_data_buah_TextChanged(sender As Object, e As EventArgs) Handles mencari_data_buah.TextChanged
        ' Anda bisa menambahkan logika live search di sini jika diinginkan
        ' Dim keyword As String = mencari_data_buah.Text.Trim()
        ' SearchDataBuah(keyword)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Anda bisa menambahkan logika di sini jika ada tombol atau kontrol lain di dalam sel DataGridView
    End Sub
End Class