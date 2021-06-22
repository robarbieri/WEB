'Monta a página de aplicativos de acordo com a estrutura de pastas e arquivos no local
'pré-definido no servidor da Intranet
Partial Class inAplicativos
    Inherits System.Web.UI.Page

    'Carregar Página
    Protected Sub formApp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles formApp.Load

        'Variáveis
        Dim nodeGroup As TreeNode
        Dim nodeItem As TreeNode
        Dim strDirIni As String
        Dim strApp(2) As String
        Dim strApp2(2) As String
        Dim objFSO As Scripting.FileSystemObject
        Dim objSubFolder As Scripting.Folder
        Dim objFolder As Scripting.Folder
        Dim objFile As Scripting.File
        Dim x As Integer
        Dim y As Integer

        'Verifica o servidor ao qual deve conectar e seta o padrão caso
        'a variável que o contém esteja em branco
        If Trim(UCase(Session("Server"))) = "" Then Session("Server") = "DBMIRROR"
        'If Trim(UCase(Session("Server"))) = "" Then Session("Server") = "DESENVOLVIMENTO"

        'Define o caminho dos arquivos de aplicativos
        If Trim(UCase(Session("Server"))) <> "DESENVOLVIMENTO" Then
            strDirIni = "D:\Web\Hargos\Aplicativos\"
        Else
            strDirIni = "C:\Inetpub\wwwroot\Aplicativos\"
        End If

        strApp(0) = ""
        strApp(1) = ""
        strApp(2) = ""

        'Limpa a "árvore" dos aplicativos
        TreeAplicativos.Nodes.Clear()

        'Cria nova árvore
        nodeGroup = New TreeNode()

        'Cria objeto de manipuilação de arquivos
        objFSO = New Scripting.FileSystemObject

        'Define a pasta origem
        objFolder = objFSO.GetFolder(strDirIni)

        'Cria o Grupo Sistemas(FIXO) na Àrvore Aplicativos
        With nodeGroup

            .Text = "Sistemas"

        End With

        'Aciona os Sistemas ao grupo Sistema
        TreeAplicativos.Nodes.Add(nodeGroup)
        TreeAplicativos.Nodes(x).SelectAction = TreeNodeSelectAction.None

        strApp(0) = "Modulo X"
        strApp(1) = "x2x"
        strApp(2) = "Proc. Boletos Devolvidos"

        strApp2(0) = "http://" & Session("Server") & "/Modulo_X/publish.htm"
        strApp2(1) = "http://" & Session("Server") & "/x2x/publish.htm"
        strApp2(2) = "http://" & Session("Server") & "/ProcessaBoletosDevolvidos/publish.htm"

        For y = 0 To 2

            nodeItem = New TreeNode()

            With nodeItem

                .Text = strApp(y)

            End With

            TreeAplicativos.Nodes(x).ChildNodes.Add(nodeItem)
            TreeAplicativos.Nodes(x).ChildNodes(y).NavigateUrl = strApp2(y)
            TreeAplicativos.Nodes(x).ChildNodes(y).Target = "_blank"

        Next

        strApp(0) = ""
        strApp(1) = ""
        strApp(2) = ""

        strApp2(0) = ""
        strApp2(1) = ""
        strApp2(2) = ""

        x = x + 1
        y = 0

        'Cria um novo grupo da Àrvore para cada Sub-Pasta da pasta origem
        For Each objSubFolder In objFolder.SubFolders

            nodeGroup = New TreeNode()

            With nodeGroup

                .Text = Trim(objSubFolder.Name)

            End With

            TreeAplicativos.Nodes.Add(nodeGroup)
            TreeAplicativos.Nodes(x).SelectAction = TreeNodeSelectAction.None

            'Cria um novo Item para cada arquivo na Sub-Pasta
            For Each objFile In objSubFolder.Files

                nodeItem = New TreeNode()

                With nodeItem

                    .Text = Trim(objFile.Name)

                End With

                TreeAplicativos.Nodes(x).ChildNodes.Add(nodeItem)
                TreeAplicativos.Nodes(x).ChildNodes(y).NavigateUrl = "http://" & Session("Server") & "/aplicativos/suporte/" & objFile.Name
                TreeAplicativos.Nodes(x).ChildNodes(y).Target = "_top"

                y = y + 1

            Next

            x = x + 1
            y = 0

        Next

    End Sub

End Class
