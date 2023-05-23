Imports MySql.Data.MySqlClient
Public Class FormLogin
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Hide()
    End Sub

    Sub Terbuka()
        FormMainMenu.LoginToolStripMenuItem.Enabled = False
        FormMainMenu.LogoutToolStripMenuItem.Enabled = True
        FormMainMenu.MasterToolStripMenuItem.Enabled = True
        FormMainMenu.TransaksiToolStripMenuItem.Enabled = True
        FormMainMenu.LaporanToolStripMenuItem.Enabled = True
    End Sub

    Sub KondisiAwal()
        txtKode.Text = ""
        txtPass.Text = ""
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtKode.Text = "" Or txtPass.Text = "" Then
            MsgBox("Kode Admin dan Password tidak boleh kosong !")
        Else
            Call koneksi()
            CMD = New MySqlCommand("Select * from tbl_admin where kodeadmin='" & txtKode.Text & "' and password='" & txtPass.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                Me.Close()
                Call Terbuka()
                FormMainMenu.ToolStripStatusLabel2.Text = RD!kodeadmin
                FormMainMenu.ToolStripStatusLabel4.Text = RD!namaadmin
                FormMainMenu.ToolStripStatusLabel6.Text = RD!leveladmin
            Else
                MsgBox("Kode atau Password anda Salah")
            End If
        End If
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub
End Class
