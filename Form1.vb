Public Class Form1

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Try
            create("INSERT INTO Utilizadores(nome, utilizador, senha, nivel) VALUES ('" & txtNome.Text & "','" & txtUtilizador.Text & "','" & txtSenha.Text & "','" & CbNivel.SelectedIndex + 1 & ")")
        Catch ex As Exception
            'em caso de erro exibir o mesmo 
            MessageBox.Show("ERRO" & ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            reload("SELECT * FROM Utilizadores ORDER BY ID ASC", DGLista)
        Catch ex As Exception
            MessageBox.Show("ERRO" & ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            updates("UPDATE Utilizadores SET nome='" & txtNome.Text & "', " & "utilizador='" & txtUtilizador.Text & "', " & "senha='" & txtSenha.Text & "'," & "nivel=" & CbNivel.SelectedIndex & " WHERE ID=" & LblID.Text)
        Catch ex As Exception
            MessageBox.Show("ERRO" & ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            delete("DELETE FROM Utilizadores WHERE ID=" & LblID.Text)
        Catch ex As Exception
            MessageBox.Show("ERRO" & ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgLista_DoubleClick(sender As Object, e As EventArgs) Handles DGLista.DoubleClick
        LblID.Text = DGLista.CurrentRow.Cells(0).Value
        txtNome.Text = DGLista.CurrentRow.Cells(1).Value
        txtUtilizador.Text = DGLista.CurrentRow.Cells(2).Value
        txtSenha.Text = DGLista.CurrentRow.Cells(3).Value
        CbNivel.SelectedIndex = DGLista.CurrentRow.Cells(4).Value
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNome.Select()
        Me.btnReload.PerformClick()
    End Sub
End Class
