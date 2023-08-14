Imports System.Data.SqlClient

Public Class Members

    Dim conn As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kethaka\Documents\SportClubDB.mdf;Integrated Security=True;Connect Timeout=30")
    Dim gender As String
    Dim index As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Dim sport1 As String
        Dim DOB As Date

        If ckbxSwim.Checked = True Then
            sport1 = "Swim "
        End If

        If ckbxFtball.Checked = True Then
            sport1 = sport1 & "Foot Ball "
        End If

        If ckbxC.Checked = True Then
            sport1 = sport1 & "Cricket "
        End If

        If ckbxVB.Checked = True Then
            sport1 = sport1 & "volly ball"
        End If
        DOB = Format(DateTimePicker1.Value, "yyyy/MM/dd")

        conn.Open()
        Dim sql = "insert into MemberTbl values('" & txtId.Text & "','" & txtName.Text & "','" & txtMail.Text & "','" & txtTel.Text & "','" & txtAdd.Text & "','" & gender & "','" & sport1 & "','" & DOB & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Insert Successful")
        conn.Close()
        DisplayItems()


    End Sub

    Private Sub DisplayItems()
        conn.Open()
        Dim query = "Select * from MemberTbl"
        Dim cmd1 = New SqlCommand(query, conn)
        Dim adapter = New SqlDataAdapter(cmd1)
        Dim builder = New SqlCommandBuilder(adapter)
        builder = New SqlCommandBuilder(adapter)
        Dim ds = New DataSet()
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rbMale.CheckedChanged
        gender = "Male"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemale.CheckedChanged
        gender = "Female"
    End Sub

    Private Sub Members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayItems()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        index = e.RowIndex
        Dim SelectedRow As DataGridViewRow = DataGridView1.Rows(index)
        Dim gen As String = SelectedRow.Cells(5).Value.ToString()
        'MsgBox(gen)

        If String.Compare(gen, "Male") = 1 Then
            rbMale.Checked = True
            rbFemale.Checked = False
        Else
            rbFemale.Checked = True
            rbMale.Checked = False


        End If
        txtId.Text = SelectedRow.Cells(0).Value.ToString()
        txtName.Text = SelectedRow.Cells(1).Value.ToString()
        txtMail.Text = SelectedRow.Cells(2).Value.ToString()
        txtTel.Text = SelectedRow.Cells(3).Value.ToString()
        txtAdd.Text = SelectedRow.Cells(4).Value.ToString()
        'c.Text = SelectedRow.Cells(0).Value.ToString()
        'txtId.Text = SelectedRow.Cells(0).Value.ToString()
        DateTimePicker1.Value = SelectedRow.Cells(7).Value
        'txtId.Text = SelectedRow.Cells(0).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim sport1 As String
        Dim DOB As Date

        If ckbxSwim.Checked = True Then
            sport1 = "Swim "
        End If

        If ckbxFtball.Checked = True Then
            sport1 = sport1 & "Foot Ball "
        End If

        If ckbxC.Checked = True Then
            sport1 = sport1 & "Cricket "
        End If

        If ckbxVB.Checked = True Then
            sport1 = sport1 & "volly ball"
        End If
        DOB = Format(DateTimePicker1.Value, "yyyy/MM/dd")

        conn.Open()
        Dim sql = "update MemberTbl set Member_Name='" & txtName.Text & "',Member_Email='" & txtMail.Text & "',MemberTel='" & txtTel.Text & "',MemberAddress='" & txtAdd.Text & "',Gender='" & gender & "',Sport='" & sport1 & "',DateOfBirth='" & DOB & "' where Member_ID='" & txtId.Text & "'"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Update Successful")
        conn.Close()
        DisplayItems()
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click

        Dim sport1 As String
        Dim DOB As Date

        If ckbxSwim.Checked = True Then
            sport1 = "Swim "
        End If

        If ckbxFtball.Checked = True Then
            sport1 = sport1 & "Foot Ball "
        End If

        If ckbxC.Checked = True Then
            sport1 = sport1 & "Cricket "
        End If

        If ckbxVB.Checked = True Then
            sport1 = sport1 & "volly ball"
        End If
        DOB = Format(DateTimePicker1.Value, "yyyy/MM/dd")

        conn.Open()
        Dim sql = "insert into MemberTbl values('" & txtId.Text & "','" & txtName.Text & "','" & txtMail.Text & "','" & txtTel.Text & "','" & txtAdd.Text & "','" & gender & "','" & sport1 & "','" & DOB & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Registered")
        conn.Close()
        DisplayItems()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Dim sport1 As String
        Dim DOB As Date

        If ckbxSwim.Checked = True Then
            sport1 = "Swim "
        End If

        If ckbxFtball.Checked = True Then
            sport1 = sport1 & "Foot Ball "
        End If

        If ckbxC.Checked = True Then
            sport1 = sport1 & "Cricket "
        End If

        If ckbxVB.Checked = True Then
            sport1 = sport1 & "volly ball"
        End If
        DOB = Format(DateTimePicker1.Value, "yyyy/MM/dd")

        conn.Open()
        Dim sql = "update MemberTbl set Member_Name='" & txtName.Text & "',Member_Email='" & txtMail.Text & "',MemberTel='" & txtTel.Text & "',MemberAddress='" & txtAdd.Text & "',Gender='" & gender & "',Sport='" & sport1 & "',DateOfBirth='" & DOB & "' where Member_ID='" & txtId.Text & "'"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Update Successful")
        conn.Close()
        DisplayItems()
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        conn.Open()
        Dim sql = "delete from MemberTbl where Member_ID='" & txtId.Text & "'"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else
            cmd.ExecuteNonQuery()
            MsgBox("Delete Successful")
            conn.Close()
            DisplayItems()
        End If
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        txtId.Text = ""
        txtMail.Text = ""
        txtTel.Text = ""
        txtAdd.Text = ""
        txtName.Text = ""
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class