Imports System.Data.SqlClient

Public Class MemberFees
    Dim fees As Double
    Dim Rate As Double
    Dim finalfeedis As Double
    Dim finalfeeNdis As Double
    Dim runtime As Integer = 0
    Dim months As String
    Dim disamount As Double

    Dim conn As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kethaka\Documents\SportClubDB.mdf;Integrated Security=True;Connect Timeout=30")


    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click


        Dim id As String = txtId.Text
        months = cmbMonths.SelectedItem
        Dim dmonths As Double = Convert.ToDouble(months)

        If months Is Nothing Then
            MsgBox("Please Select Months")
        Else
            Try

                conn.Open()
                Dim sql = "select * from FeesSet where id=1"
                Dim cmd As New SqlCommand(sql, conn)
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader

                myreader.Read()
                fees = myreader("MonthlyFees")
                Rate = myreader("DisRate5")

                Dim tot As Double = fees * dmonths
                lblTot.Text = tot
                lblMonthlyFee.Text = fees
                disamount = (tot * Rate) / 100

                If dmonths >= 6 Then

                    lblrate.Text = Rate
                    lblPer.Text = "%"
                    lblDisAmount.Text = disamount
                    finalfeedis = tot - disamount
                    lblFinalFee.Text = finalfeedis
                    runtime = runtime + 1
                Else

                    lblrate.Text = "There is no discount"
                    lblDisAmount.Text = "0.00"
                    finalfeeNdis = tot
                    lblFinalFee.Text = tot
                    lblPer.Text = ""
                End If

                conn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try

                conn.Open()
                Dim sql = "select Member_Name from MemberTbl where Member_ID= '" & txtId.Text & "' "
                Dim cmd As New SqlCommand(sql, conn)
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader
                myreader.Read()
                lblMemName.Text = myreader("Member_Name")
                conn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If



    End Sub

    Private Sub MemberFees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayItems()
    End Sub
    Private Sub DisplayItems()
        conn.Open()
        Dim query = "Select * from FeeTbl"
        Dim cmd1 = New SqlCommand(query, conn)
        Dim adapter = New SqlDataAdapter(cmd1)
        Dim builder = New SqlCommandBuilder(adapter)
        builder = New SqlCommandBuilder(adapter)
        Dim ds = New DataSet()
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
    End Sub
    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        Dim paidAmount As Double = txtPaid.Text

        If runtime = 1 Then
            lblbalance.Text = paidAmount - finalfeedis

            conn.Open()
            Dim sql = "insert into FeeTbl values((Select ISNULL (MAX(id)+1,1) from FeeTbl),'" & txtId.Text & "', '" & fees & "','" & months & "','" & disamount & "','" & finalfeedis & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Insert Successful")
            conn.Close()
            DisplayItems()
        Else
            lblbalance.Text = paidAmount - finalfeeNdis
            disamount = 0.00

            conn.Open()
            Dim sql = "insert into FeeTbl values((Select ISNULL (MAX(id)+1,1) from FeeTbl),'" & txtId.Text & "', '" & fees & "','" & months & "','" & disamount & "','" & finalfeeNdis & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Insert Successful")
            conn.Close()
            DisplayItems()
        End If

    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        txtId.Text = ""
        cmbMonths.SelectedIndex = 0
        lblMemName.Text = ".."
        lblMonthlyFee.Text = ".."
        lblTot.Text = ".."
        lblrate.Text = ".."
        lblDisAmount.Text = ".."
        lblFinalFee.Text = ".."
        txtPaid.Text = ""
        lblbalance.Text = ".."

    End Sub
End Class