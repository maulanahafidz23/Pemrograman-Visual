Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class FormTransaksi
    Dim TglSql
    Sub KondisiAwal()
        LBLNP.Text = ""
        LBLAlamat.Text = ""
        LBLNT.Text = ""
        LBLTanggal.Text = Today
        LBLAdmin.Text = FormMainMenu.ToolStripStatusLabel4.Text
        LBLTotal.Text = ""
        TextBox1.Text = ""
        LBLMerk.Text = ""
        LBLNamaMobil.Text = ""
        LBLHargaMobil.Text = ""
        TextBox2.Text = ""
        TextBox2.Enabled = False
        Call ShowDataPembeli()
        Call AutomaticNumber()
        Call BuatKolom()
        LBLTotal.Text = "0"
        DataGridView1.Columns("Kode").Width = 95
        DataGridView1.Columns("Jumlah").Width = 80
    End Sub

    Sub ShowDataPembeli()
        Call koneksi()
        ComboBox1.Items.Clear()
        CMD = New MySqlCommand("Select * From tbl_Pelanggan", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            ComboBox1.Items.Add(RD.Item(0))
        Loop
    End Sub

    Sub BuatKolom()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("Kode", "Kode")
        DataGridView1.Columns.Add("Merk", "Merk")
        DataGridView1.Columns.Add("Nama", "Nama Mobil")
        DataGridView1.Columns.Add("Harga", "Harga")
        DataGridView1.Columns.Add("Jumlah", "Jumlah")
        DataGridView1.Columns.Add("Total", "Total")
    End Sub

    Sub AutomaticNumber()
        Call koneksi()
        CMD = New MySqlCommand("Select * from tbl_jual where nojual in (select max(nojual) from tbl_jual)", CONN)
        Dim UrutanKode As String
        Dim Hitung As Long
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            UrutanKode = "T" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(RD.GetString(0), 3) + 1
            UrutanKode = "T" + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        LBLNT.Text = UrutanKode
    End Sub

    Sub HitungTotal()
        Dim Hitung As Long
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Hitung = Hitung + DataGridView1.Rows(i).Cells(5).Value
            LBLTotal.Text = Hitung
        Next
    End Sub

    Sub HitungItem()
        Dim HitungItem As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            HitungItem = HitungItem + DataGridView1.Rows(i).Cells(4).Value
            LBLItem.Text = HitungItem
        Next
    End Sub

    Private Sub FormTransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call koneksi()
        CMD = New MySqlCommand("Select * From tbl_Pelanggan where kodepembeli ='" & ComboBox1.Text & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            ComboBox1.Text = RD!kodepembeli
            LBLNP.Text = RD!namapembeli
            LBLAlamat.Text = RD!alamat
            LBLTelephone.Text = RD!nomor
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            CMD = New MySqlCommand("Select * from tbl_mobil where kodemobil= '" & TextBox1.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                MsgBox("Kode Mobil Tidak Tersedia")
            Else
                TextBox1.Text = RD.Item("kodemobil")
                LBLMerk.Text = RD.Item("merk")
                LBLNamaMobil.Text = RD.Item("namamobil")
                LBLHargaMobil.Text = RD.Item("harga")
                'TextBox5.Text = RD.Item("jumlah")
                'ComboBox1.Text = RD.Item("satuan")
                TextBox2.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If LBLNamaMobil.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Masukan Kode Barang Lalu Enter")
        Else
            DataGridView1.Rows.Add(New String() {TextBox1.Text, LBLMerk.Text, LBLNamaMobil.Text, LBLHargaMobil.Text, TextBox2.Text, Val(LBLHargaMobil.Text) * Val(TextBox2.Text)})
            Call HitungTotal()
            Call HitungItem()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Transaksi gagal, Silahkan lengkapi data terlebih dahulu")
        Else
            TglSql = Format(Today, "yyyy-MM-dd")
            Call koneksi()
            Dim SimpanJual As String = "Insert into tbl_jual values ('" & LBLNT.Text & "' , '" & TglSql & "' , '" & LBLItem.Text & "' , '" & LBLTotal.Text & "' , '" & ComboBox2.Text & "' , '" & ComboBox1.Text & "' , '" & FormMainMenu.ToolStripStatusLabel2.Text & "')"
            CMD = New MySqlCommand(SimpanJual, CONN)
            CMD.ExecuteNonQuery()

            'For Baris As Integer = 0 To DataGridView1.Rows.Count - 2
            '    If RD IsNot Nothing AndAlso Not RD.IsClosed Then
            '        RD.Close()
            '    End If
            '    Dim SimpanDetail As String = "Insert into tbl_detail values ('" & LBLNT.Text & "' , '" & DataGridView1.Rows(Baris).Cells(0).Value & "' , '" & DataGridView1.Rows(Baris).Cells(2).Value & "' , '" & DataGridView1.Rows(Baris).Cells(3).Value & "' , '" & DataGridView1.Rows(Baris).Cells(4).Value & "', '" & DataGridView1.Rows(Baris).Cells(5).Value & "')"
            '    CMD = New MySqlCommand(SimpanDetail, CONN)
            '    CMD.ExecuteNonQuery()

            '    CMD = New MySqlCommand("Select * from tbl_mobil where kodemobil = '" & DataGridView1.Rows(Baris).Cells(0).Value & "'", CONN)
            '    RD = CMD.ExecuteReader
            '    RD.Read()
            '    If RD.Read() Then
            '        RD.Close()
            '        Dim KurangStok As String = "Update tbl_mobil set jumlah = '" & RD.Item("jumlah") - DataGridView1.Rows(Baris).Cells(4).Value & "' where kodemobil = '" & DataGridView1.Rows(Baris).Cells(0).Value & "'"
            '        CMD = New MySqlCommand(KurangStok, CONN)
            '        CMD.ExecuteNonQuery()
            '    End If
            'Next
            For Baris As Integer = 0 To DataGridView1.Rows.Count - 2
                If RD IsNot Nothing AndAlso Not RD.IsClosed Then
                    RD.Close()
                End If

                Dim SimpanDetail As String = "INSERT INTO tbl_detail (Nojual, KodeMobil, NamaMobil, Harga, JumlahJual, Subtotal) VALUES (@LBLNT, @Kode, @Nama, @Harga, @Jumlah, @Total)"
                CMD = New MySqlCommand(SimpanDetail, CONN)
                CMD.Parameters.AddWithValue("@LBLNT", LBLNT.Text)
                CMD.Parameters.AddWithValue("@Kode", DataGridView1.Rows(Baris).Cells(0).Value)
                CMD.Parameters.AddWithValue("@Nama", DataGridView1.Rows(Baris).Cells(2).Value)
                CMD.Parameters.AddWithValue("@Harga", DataGridView1.Rows(Baris).Cells(3).Value)
                CMD.Parameters.AddWithValue("@Jumlah", DataGridView1.Rows(Baris).Cells(4).Value)
                CMD.Parameters.AddWithValue("@Total", DataGridView1.Rows(Baris).Cells(5).Value)
                CMD.ExecuteNonQuery()

                Dim KurangStok As String = "UPDATE tbl_mobil SET jumlah = jumlah - @Jumlah WHERE kodemobil = @Kode"
                CMD = New MySqlCommand(KurangStok, CONN)
                CMD.Parameters.AddWithValue("@Jumlah", DataGridView1.Rows(Baris).Cells(4).Value)
                CMD.Parameters.AddWithValue("@Kode", DataGridView1.Rows(Baris).Cells(0).Value)
                CMD.ExecuteNonQuery()
            Next
            MsgBox("Data Transaksi Berhasil Ditambahkan")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class