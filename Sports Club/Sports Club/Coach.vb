Imports System.Data.SqlClient

Public Class Coach

    Dim conn As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kethaka\Documents\SportClubDB.mdf;Integrated Security=True;Connect Timeout=30")
    Dim gender As String

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        gender = "Male"

    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        gender = "Female"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim sport As String
        Dim dd As Date
        sport = ComboBox1.SelectedItem
        dd = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        Try
            conn.Open()
            Dim sql = "insert into CoachTbl values('" & txtId.Text & "','" & txtName.Text & "','" & txtMail.Text & "','" & txtTel.Text & "','" & txtAdd.Text & "','" & gender & "','" & sport & "','" & dd & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        Dim sport As String
        Dim dd As Date
        sport = ComboBox1.SelectedItem
        dd = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        Try
            conn.Open()
            Dim sql = "insert into CoachTbl values('" & txtId.Text & "','" & txtName.Text & "','" & txtMail.Text & "','" & txtTel.Text & "','" & txtAdd.Text & "','" & gender & "','" & sport & "','" & dd & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
End Class