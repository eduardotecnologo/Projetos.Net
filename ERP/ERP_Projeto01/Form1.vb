Public Class Form1
    Private dblNota1 As Double
    Private dblNota2 As Double
    Private dblResultado As Double

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        If txtNota1.TextLength > 0 Then
            If IsNumeric(txtNota1.Text) = True Then
                dblNota1 = Convert.ToDouble(txtNota1.Text)
            End If
        End If
        If txtNota2.TextLength > 0 Then
            If IsNumeric(txtNota2.Text) = True Then
                dblNota2 = Convert.ToDouble(txtNota2.Text)
            End If
        End If
        If dblNota1 > 0 And dblNota2 > 0 Then
            dblResultado = (dblNota1 + dblNota2) / 2
            txtResultado.Text = FormatNumber(dblResultado, 2)
        End If
    End Sub
End Class
