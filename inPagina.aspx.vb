Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class _inPagina
    Inherits System.Web.UI.Page

    'Carregar Página Padrão
    Protected Sub Pagina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pagina.Load

        'If MenuLeft.Items.Count = 0 Then

        'Variáveis
        'Dim MenuItens As MenuItemCollection
        Dim MenuItem(20) As MenuItem
        Dim MenuChildItem(20) As MenuItem
        Dim MenuChildChildItem(20) As MenuItem
        Dim objDR As SqlDataReader
        Dim objDRSub1 As SqlDataReader
        Dim objDRSub2 As SqlDataReader
        Dim x As Short
        Dim y As Short
        Dim z As Short
        Dim strSql As String = ""
        Dim Mirror As New ConnectTo.Comando

        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientScript", "<script language=javascript src=http://DBMIRROR/Intranet/Funcoes.js></script>")

        'Limpa o menu esquerdo
        MenuLeft.Items.Clear()

        'Conecta ao Banco de Dados
        Mirror.Banco = Session("DB")

        'Executa e Stored Procedure que retorna os itens do Menu Principal
        'que podem ser vistos por este perfíl/grupo de usuários
        strSql = "prc_SEL_MenuItens " & Trim(UCase(Session("Grupo")))
        objDR = Mirror.ExecuteQuery(strSql)

        'Verifica se foram retornados - Se não foram, significa que
        'este usuário não possui acesso a este sistema ou que
        'por algum motivo inesperado, a sessão foi perdida.
        'O usuário é redirecionado à tela de login
        If Not objDR.HasRows Then Response.Redirect("Login.aspx")

        'MenuItens = New MenuItemCollection

        'Zera o Contador de Itens
        x = 0

        'Faça enquanto houverem dados no Leitor de dados
        '= Enquanto houverem itens de menu à serem
        'inseridos
        Do While objDR.Read

            'Cria um novo Item
            MenuItem(x) = New MenuItem

            'Seta o Texto do Item = ao campo Nome da tabela de Itens do Menu
            MenuItem(x).Text = objDR.Item("Nome").ToString

            'Seta o ToolTip(Dica) do Item = ao campo Descricao
            MenuItem(x).ToolTip = Trim(objDR.Item("Descricao").ToString)

            'Seta o Link do Item = ao campo Link
            MenuItem(x).NavigateUrl = Trim(objDR.Item("Link").ToString)
            MenuItem(x).NavigateUrl = Replace(UCase(MenuItem(x).NavigateUrl), "DBMIRROR", Session("Server"))

            'Caso OS passa parâmetros no LINK
            If Trim(objDR.Item("Nome").ToString) = "- OS" Then
                MenuItem(x).NavigateUrl = MenuItem(x).NavigateUrl & "?Source=1&Usuario=" & Session("Usuario") & "&Id_Usuario=" & Session("Id_Usuario")
            End If

            'Seta o Target(Alvo do Link) do Item = ao campo Target
            MenuItem(x).Target = Trim(objDR.Item("Target").ToString)

            'Verifica no banco de dados se existem Sub Itens para este Item
            'e se o grupo ao qual o usuário logado pertence, possui
            'permissão para ver
            strSql = "prc_SEL_MenuSubItens1 " & Trim(UCase(Session("Grupo"))) & "," & Trim(objDR.Item("ID").ToString)
            objDRSub1 = Mirror.ExecuteQuery(strSql)

            'Zera o Contador de Sub-Itens
            y = 0

            'Enquanto Houverem Sub-Itens à serem inseridos
            Do While objDRSub1.Read()

                'Cria um novo Sub-Item
                MenuChildItem(y) = New MenuItem

                'Seta o Texto do Sub-Item = ao campo Nome da tabela de SubItens1 do Menu
                MenuChildItem(y).Text = objDRSub1.Item("Nome").ToString

                'Seta o ToolTip(Dica) do Sub-Item = ao campo Descricao
                MenuChildItem(y).ToolTip = Trim(objDRSub1.Item("Descricao").ToString)

                'Seta o Link do Sub-Item = ao campo Link
                MenuChildItem(y).NavigateUrl = Trim(objDRSub1.Item("Link").ToString)

                'Seta o Target(Alvo do Link) do Sub-Item = ao campo Target
                MenuChildItem(y).Target = Trim(objDRSub1.Item("Target").ToString)

                'Verifica no banco de dados se existem Sub-Itens para este Sub-Item
                'e se o grupo ao qual o usuário logado pertence, possui
                'permissão para ver
                strSql = "prc_SEL_MenuSubItens2 " & Trim(UCase(Session("Grupo"))) & "," & Trim(objDRSub1.Item("ID").ToString)
                objDRSub2 = Mirror.ExecuteQuery(strSql)

                'Zera o Contador de Sub-Sub-Itens
                z = 0

                'Enquanto Houverem Sub-Sub-Itens à serem inseridos
                Do While objDRSub2.Read()

                    'Cria um novo Sub-Sub-Item
                    MenuChildChildItem(z) = New MenuItem

                    'Seta o Texto do Sub-Sub-Item = ao campo Nome da tabela de SubItens2 do Menu
                    MenuChildChildItem(z).Text = objDRSub2.Item("Nome").ToString

                    'Seta o ToolTip(Dica) do Sub-Item = ao campo Descricao
                    MenuChildChildItem(z).ToolTip = Trim(objDRSub2.Item("Descricao").ToString)

                    'Seta o Link do Sub-Item = ao campo Link
                    MenuChildChildItem(z).NavigateUrl = Trim(objDRSub2.Item("Link").ToString)

                    'Seta o Target(Alvo do Link) do Sub-Item = ao campo Target
                    MenuChildChildItem(z).Target = Trim(objDRSub2.Item("Target").ToString)

                    'Adiciona o Sub-Sub-Item ao Sub-Item
                    MenuChildItem(y).ChildItems.Add(MenuChildChildItem(z))

                    'Incrementa 1 ao Contador de Sub-Sub-Itens
                    z = z + 1

                    'Próximo Sub-Sub-Item
                Loop

                'Fecha o Leitor de Dados do Sub-Sub-Item
                objDRSub2.Close()

                'Adiciona o Sub-Item com os Sub-Sub-Itens ao Item
                MenuItem(x).ChildItems.Add(MenuChildItem(y))

                'Incrementa 1 ao Contador de Sub-Itens
                y = y + 1

                'Próximo Sub-Item
            Loop

            'Fecha o Leitor de Dados do Sub-Item
            objDRSub1.Close()

            'Adiciona o Item com os Sub-Itens e com os Sub-Sub-Itens ao Menu
            MenuLeft.Items.Add(MenuItem(x))

            'Incrementa 1 ao Contador de Itens
            x = x + 1

            'Próximo Item
        Loop

        'Fecha o Leitor de Dados do Item
        objDR.Close()

        'End If

        'Fim do Carregar Página Padrão
    End Sub

End Class
