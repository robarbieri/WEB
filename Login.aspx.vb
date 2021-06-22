Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports XMail

Partial Class _Login
    Inherits System.Web.UI.Page

    'Autenticação do Login
    Protected Sub Login_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login.Authenticate

        'Variáveis
        Dim intGrupo As Short
        Dim intSistema As Short
        Dim blnValidado As Boolean
        Dim blnPesquisa As Boolean
        Dim strSql As String = ""
        Dim objDR As SqlDataReader = Nothing
        Dim objDRUsuario As SqlDataReader = Nothing
        Dim Mirror As New ConnectTo.Comando

        'Seta variável de Validação como FALSA
        blnValidado = False

        'Seta variável de Login da Pesquisa X como FALSA
        blnPesquisa = False

        'Sistema = Intranet/Extranet
        intSistema = 1

        'Verifica se é para efetuar o Login da Pesquisa ou da Intranet/Extranet
        If Trim(UCase(Request("Id"))) = "PESQUISA" Then

            blnPesquisa = True

            If Trim(Login.UserName) = "credicard1" And Trim(Login.Password) = "caneta" Then
                blnValidado = True
            End If

            intSistema = 3 'Pesquisa X

        End If

        Session("Sistema") = intSistema

        If blnPesquisa = False Then

            'INTRANET/EXTRANET

            'Conecta no Banco de Dados
            'Mirror.Connect(Session("DB"))
            Mirror.Banco = Session("DB")
            'Mirror.ConnectSTR("Sistemas", "sa", "hargos", "DESENVOLVIMENTO")

            'Consulta o Login no Banco de Dados
            strSql = "prc_SEL_VerificaLogin '" & Login.UserName & "', '" & Login.Password & "'," & intSistema
            objDR = Mirror.ExecuteQuery(strSql)

            'Verifica se foram retornados dados - se o Login é válido
            If objDR.Read() Then

                'Caso seja, descobre o Perfil/Grupo que este usuário pertence
                'para definir o seu nível de acesso 
                intGrupo = objDR.Item("Grupo")
                Session("NomeUser") = Trim(objDR.Item("NomeUser"))
                'Variavel de Validacao como VERDADEIRA
                blnValidado = True

            End If

        End If

        'Verifica se a variavel de validacao possui valor VERDADEIRO - dados de Login validos
        If blnValidado = True Then

            'Guarda em uma sessão o usuário logado, sua senha e o grupo
            'ao qual ele pertence

            'Verifica se é Login da Extranet
            If Trim(UCase(Session("Source"))) = "EXTRANET" Then

                'Verifica usuário
                Select Case Trim(UCase(Login.UserName))

                    'Caso não tenha permissão para acessar Extranet
                    Case Is <> "ADM", "DECIO", "MARA", "ANDRE", "RODRIGO"

                        'Manda e-mail para desenvolvimeto
                        SendMail("Tentativa de acesso à Extranet pelo usuário <b>" & Trim(UCase(Login.UserName)) & "</b> bloqueada dia <b>" & Format(CDate(Now), "dd/MM/yyy") & " às " & Format(CDate(Now), "hh:mm:ss") & "</b>.")
                        'Avisa usuário que ele não tem permissão
                        ShowMessage("Este usuário não tem permissão de acesso à Extranet.")
                        Exit Sub

                End Select

            End If

            If blnPesquisa = False Then

                Session("Usuario") = Trim(Login.UserName)
                Session("Password") = Trim(Login.Password)
                Session("Grupo") = intGrupo

            Else

                Session("UsuarioX") = Trim(Login.UserName)
                Session("PasswordX") = Trim(Login.Password)

            End If

            'Fecha o Leitor de Dados do SQL
            If blnPesquisa = False Then objDR.Close()

            'Verifica o Id do Usuario
            strSql = "prc_SEL_UserId '" & Session("Usuario") & "'"
            objDR = Mirror.ExecuteQuery(strSql)

            If objDR.Read Then

                'Guarda o Id do Usuário
                Session("Id_Usuario") = objDR.Item("USER_Id")

                'Fecha o Leitor de Dados do SQL
                objDR.Close()

            End If

            'Verifica se é um login do Pesquisa X ou da Intranet/Extranet
            If blnPesquisa = False Then
                'Verifica se é 1º acesso e redireciona p/ alterar senha
                'Caso não, redireciona para a Tela Padrão da Intranet/Extranet
                'strSql = "prc_SEL_Acesso " & Session("Id_Usuario")
                'objDR = Mirror.ExecuteQuery(strSql)

                'If objDR.Read Then
                If Session("Password") <> "123" Then
                    'Registra o Acesso
                    strSql = "prc_INS_AcessoLogin " & Session("Id_Usuario") & ", " & intSistema
                    Mirror.Execute(strSql)
                    Session("Pagina") = ""
                Else
                    Session("Pagina") = "inSenha"
                End If

                objDR.Close()

                Response.Redirect("Default.aspx")

            Else
                'Redireciona o Usuário para a Tela do Pesquisa X
                Response.Redirect("Pesquisa.aspx")
            End If

        End If

        'Fim da Autenticação do Login
    End Sub

    'Carregar Página de Login
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Mirror As New ConnectTo.Comando
        Dim strSql As String = ""
        Dim objDR As SqlDataReader = Nothing
        Dim intSistema As Short = 0

        'Carrega em uma sessão à fonte do acesso - Intranet ou Extranet
        Session("Source") = Trim(Request("Source"))
        If Trim(Session("Source")) = "" Then Session("Source") = "Intranet"

        If Trim(UCase(Session("Source"))) = "EXTRANET" Then Session("Link") = "hargos.dnsalias.com:81"

        Login.Focus()

        Login.UserNameLabelText = "Usuário:"
        Login.PasswordLabelText = "Senha:"

        If Trim(UCase(Request("Id"))) = "PESQUISA" Then

            intSistema = 3

            Mirror.Banco = Session("DB")

            strSql = "prc_INS_AcessoLogin " & Session("Id_Usuario") & ", " & intSistema
            Mirror.Execute(strSql)

            Session("UsuarioX") = "credicard1"
            Session("PasswordX") = "caneta"

            Response.Redirect("Pesquisa.aspx")

            Login.UserNameLabelText = "PESQUISA - Usuário:"
            Login.PasswordLabelText = "PESQUISA - Senha:"

        End If

        'Fim do Carregar Página de Login
    End Sub

    'Envia e-Mail
    Protected Sub SendMail(ByVal strDescricao As String)

        Dim eMail As New XMail.SendMail

        With eMail
            .From = "x_mail@hargos.com.br"
            .HighPriority = True
            .Sender = "Extranet - Hargos"
            .ToAddress = "rodrigo.barbieri@hargos.com.br"
            .ToName = "Desenvolvimento"
            .CC = "decio.souza@hargos.com.br"
            .CCName = "Décio Souza"
            .IsBodyHTML = True
            .Subject = "Tentativa de Login não Autorizado na Extranet"
            .Body = Trim(strDescricao)
        End With
        eMail.Send()

    End Sub

    'Mostra MsgBox
    Protected Sub ShowMessage(ByVal strMsg As String)

        Dim strScript As String = "<script language=JavaScript>alert('" & strMsg & "');</script>"

        If (Not Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then

            Page.ClientScript.RegisterStartupScript(Me.GetType, "clientScript", strScript)

        End If

    End Sub

End Class
