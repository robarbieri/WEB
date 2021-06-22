Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Default_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Default].Load

        'Verifica se existe um usuário logado
        If Trim(Session("Usuario")) = "" Then
            'Caso não, redireciona para a página de Login
            Response.Redirect("Login.aspx")
        End If

    End Sub

End Class
