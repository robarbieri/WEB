Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Default_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Default].Load

        'Verifica se existe um usu�rio logado
        If Trim(Session("Usuario")) = "" Then
            'Caso n�o, redireciona para a p�gina de Login
            Response.Redirect("Login.aspx")
        End If

    End Sub

End Class
