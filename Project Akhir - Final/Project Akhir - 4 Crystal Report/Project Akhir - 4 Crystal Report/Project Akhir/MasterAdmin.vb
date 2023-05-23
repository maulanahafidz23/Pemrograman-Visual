Imports MySql.Data.MySqlClient
Public Class MasterAdmin
    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Items.Clear()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False

        Button1.Enabled = True


        Button1.Text = "Tambah"
        Button4.Text = "Tutup"

        Call koneksi()
        DA = New MySqlDataAdapter("Select KodeAdmin,NamaAdmin,LevelAdmin from tbl_admin", CONN)
        DS = New DataSet
        DA.Fill(DS, "tbl_admin")
        DataGridView1.DataSource = DS.Tables("tbl_admin")
        DataGridView1.ReadOnly = True
        DataGridView1.Columns("KodeAdmin").Width = 150
        DataGridView1.Columns("NamaAdmin").Width = 200
        DataGridView1.Columns("Leveladmin").Width = 120
    End Sub

    Sub Ready()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox1.Items.Add("Admin")
        ComboBox1.Items.Add("User")
    End Sub

    Sub AutomaticNumber()
        Call koneksi()
        CMD = New MySqlCommand("Select * from tbl_admin where kodeadmin in (select max(kodeadmin) from tbl_admin)", CONN)
        Dim UrutanKode As String
        Dim Hitung As Long
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            UrutanKode = "ADM" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(RD.GetString(0), 3) + 1
            UrutanKode = "ADM" + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        TextBox1.Text = UrutanKode
    End Sub

    Private Sub MasterAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            Button1.Text = "Simpan"
            Button4.Text = "Batal"
            Call Ready()
            Call AutomaticNumber()
            TextBox1.Enabled = False
            TextBox2.Focus()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan Isi Semua Data")
            Else
                Call koneksi()
                Dim InputData As String = "Insert into tbl_admin values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & ComboBox1.Text & "')"
                CMD = New MySqlCommand(InputData, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data Berhasil Disimpan")
                Call KondisiAwal()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub


End Class