Imports MySql.Data.MySqlClient
Public Class MasterBarang
    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        ComboBox1.Enabled = False

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True

        Button1.Text = "Tambah"
        Button2.Text = "Edit"
        Button3.Text = "Hapus"
        Button4.Text = "Tutup"

        Call koneksi()
        DA = New MySqlDataAdapter("Select * from tbl_mobil", CONN)
        DS = New DataSet
        DA.Fill(DS, "tbl_mobil")
        DataGridView1.DataSource = DS.Tables("tbl_mobil")
        DataGridView1.ReadOnly = True
        DataGridView1.Columns("jumlah").Width = 70
    End Sub

    Sub Ready()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ComboBox1.Enabled = True
    End Sub

    Sub AutomaticNumber()
        Call koneksi()
        CMD = New MySqlCommand("Select * from tbl_mobil where kodemobil in (select max(kodemobil) from tbl_mobil)", CONN)
        Dim UrutanKode As String
        Dim Hitung As Long
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            UrutanKode = "MBL" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(RD.GetString(0), 3) + 1
            UrutanKode = "MBL" + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        TextBox1.Text = UrutanKode
    End Sub

    Private Sub MasterBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call Ready()
            Call AutomaticNumber()
            TextBox1.Enabled = False
            TextBox2.Focus()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan ISi Semua Data")
            Else
                Call koneksi()
                Dim InputData As String = "Insert into tbl_mobil values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & ComboBox1.Text & "')"
                CMD = New MySqlCommand(InputData, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data Berhasil Disimpan")
                Call KondisiAwal()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Edit" Then
            Button2.Text = "Simpan"
            Button1.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call Ready()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan ISi Semua Data")
            Else
                Call koneksi()
                Dim UpdateData As String = "update tbl_mobil set merk= '" & TextBox2.Text & "', namamobil= '" & TextBox3.Text & "', harga= '" & TextBox4.Text & "', jumlah= '" & TextBox5.Text & "', satuan= '" & ComboBox1.Text & "' where kodemobil= '" & TextBox1.Text & "'"
                CMD = New MySqlCommand(UpdateData, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data Berhasil Diubah")
                Call KondisiAwal()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            CMD = New MySqlCommand("Select * from tbl_mobil where kodemobil= '" & TextBox1.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                MsgBox("Kode Mobil Tidak Tersedia")
            Else
                TextBox1.Text = RD.Item("kodemobil")
                TextBox2.Text = RD.Item("merk")
                TextBox3.Text = RD.Item("namamobil")
                TextBox4.Text = RD.Item("harga")
                TextBox5.Text = RD.Item("jumlah")
                ComboBox1.Text = RD.Item("satuan")
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "Hapus" Then
            Button3.Text = "Delete"
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Text = "Batal"
            Call Ready()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan ISi Semua Data")
            Else
                Call koneksi()
                Dim DeleteData As String = "Delete from tbl_mobil where kodemobil= '" & TextBox1.Text & "'"
                CMD = New MySqlCommand(DeleteData, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data Berhasil Dihapus")
                Call KondisiAwal()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Tutup" Then
            Me.Close()
        Else
            Call KondisiAwal()
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub


End Class