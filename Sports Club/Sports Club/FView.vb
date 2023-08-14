Imports System.Data.SqlClient

Public Class FView

    'Public Sub New()
    ' switchPanel(Home)
    'End Sub

    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click

        switchPanel(Members)
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs)
        switchPanel(Coach)
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do You Really Want To LogOut?", "LogOut", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            'e.Cancel = True
        Else
            Login.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        switchPanel(Home)
    End Sub

    Private Sub BunifuGradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles BunifuGradientPanel2.Paint

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FView_Load(sender As Object, e As EventArgs)
        switchPanel(Home)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        'switchPanel(Home)
    End Sub

    Private Sub BunifuThinButton25_Click(sender As Object, e As EventArgs) Handles BunifuThinButton25.Click
        switchPanel(MemberFees)
    End Sub

    Private Sub BunifuThinButton26_Click(sender As Object, e As EventArgs) Handles BunifuThinButton26.Click
        FeeSettings.Show()
        Me.Hide()

    End Sub

    Private Sub FView_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
