Imports System.Data.SqlClient

Public Class FeeSettings

    Dim conn As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kethaka\Documents\SportClubDB.mdf;Integrated Security=True;Connect Timeout=30")
    Dim fees As Double
    Dim Rate As Double


    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Me.Hide()
        FView.Show()
    End Sub

    Private Sub FLoad()
        Try

            conn.Open()
            Dim sql = "select * from FeesSet where id=1"
            Dim cmd As New SqlCommand(sql, conn)
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader

            myreader.Read()
            fees = myreader("MonthlyFees")
            Rate = myreader("DisRate5")

            txtMFee.Text = fees
            txtRate.Text = Rate

            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub FeeSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FLoad()
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        conn.Open()
        Dim sql = "update FeesSet set MonthlyFees='" & txtMFee.Text & "',DisRate5='" & txtRate.Text & "'  where Id=1"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Update Successful")
        conn.Close()
    End Sub
End Class