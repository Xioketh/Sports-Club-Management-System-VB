Imports System.Data.SqlClient

Public Class Login

    Dim conn As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kethaka\Documents\SportClubDB.mdf;Integrated Security=True;Connect Timeout=30")



    Private Sub Button2_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        Dim uname As String = txtUserName.Text
        Dim pswrd As String = txtPswrd.Text
        Dim dbuname As String
        Dim dbPswrd As String
        Dim id As Integer = 1

        Try

            conn.Open()
            Dim sql = "select * from Log where id= 1"
            Dim cmd As New SqlCommand(sql, conn)
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            dbuname = myreader("UserName")
            dbPswrd = myreader("Password")
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        End
    End Sub
End Class