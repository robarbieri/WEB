
Partial Class inSenha
    Inherits System.Web.UI.Page

    Private Mirror As New ConnectTo.Comando
    Private strSql As String

    Protected Sub AlteraSenha_CancelButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlteraSenha.CancelButtonClick

        Mirror.Banco = Session("DB")

        strSql = "prc_INS_AcessoLogin " & Session("Id_Usuario") & ", " & Session("Sistema")
        Mirror.Execute(strSql)

        Response.Redirect("inPagina.aspx")

    End Sub

    Protected Sub AlteraSenha_ChangingPassword(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles AlteraSenha.ChangingPassword

        Mirror.Banco = Session("DB")

        'If Not IsNumeric(Trim(AlteraSenha.NewPassword.ToString)) Then
        '    ShowMessage("Senha deve conter apenas caracteres numéricos.")
        '    Exit Sub
        'End If

        If Trim(AlteraSenha.NewPassword.ToString) <> "" And Trim(AlteraSenha.ConfirmNewPassword.ToString) <> "" Then

            'Atualiza a senha
            strSql = "prc_ATZ_Senha " & Session("Id_Usuario") & ", '" & Trim(AlteraSenha.NewPassword.ToString) & "'"
            Mirror.Execute(strSql)

            strSql = "prc_INS_AcessoLogin " & Session("Id_Usuario") & ", " & Session("Sistema")
            Mirror.Execute(strSql)

            Response.Redirect("inPagina.aspx")

        Else
            ShowMessage("Preencha corretamente os campos.")
        End If

    End Sub

    Public Sub ShowMessage(ByVal strMsg As String)

        Dim strScript As String = "<script language=JavaScript>alert('" & strMsg & "');</script>"

        If (Not Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then

            Page.ClientScript.RegisterStartupScript(Me.GetType, "clientScript", strScript)

        End If

    End Sub

End Class
