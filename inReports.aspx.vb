'Monta a p�gina de relat�rios de acordo com a estrutura de rel�t�rios publicados no 
'ReportServer do servidor - WebService

Imports System.Web.Services.Protocols
Imports WebReportServer

Partial Class inReports
    Inherits System.Web.UI.Page

    'Carregar p�gina
    Protected Sub formReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles formReports.Load

        'Vari�veis
        Dim Reports As New WebReportServer.ReportingService
        Dim ReportCatalog As CatalogItem()
        Dim ItemCatalog As CatalogItem()
        Dim nodeGroup As TreeNode
        Dim nodeItem As TreeNode
        Dim strDirIni As String
        Dim x As Integer
        Dim y As Integer

        'Define o diretorio Inicial no ReportServer
        strDirIni = "/Hargos Reports"

        'Define o caminho padr�o do Web-Service do SQL Reporting Services 2005
        Reports.Url = "http://" & Session("Server") & "/ReportServer/ReportService.asmx"

        'Passa as credenciais
        Reports.Credentials = System.Net.CredentialCache.DefaultCredentials

        'Adiciona ao cat�logo de relat�rios a estrutura de relat�rios do Report Server
        ReportCatalog = Reports.ListChildren(strDirIni, False)

        'Limpa a "�rvore" relat�rios
        TreeReports.Nodes.Clear()

        'Para cada grupo(pasta) no Cat�logo
        For Each Group As CatalogItem In ReportCatalog

            'S� insere se for diferente de MODULO X REPORTS, 
            'que � o relat�rio usado pelo Modulo X
            If Trim(UCase(Group.Name)) <> "MODULO X REPORTS" Then

                'Cria novo grupo
                nodeGroup = New TreeNode()

                With nodeGroup

                    .Text = Group.Name

                End With

                TreeReports.Nodes.Add(nodeGroup)
                TreeReports.Nodes(x).SelectAction = TreeNodeSelectAction.None

            End If

            'S� insere se for diferente de MODULO X REPORTS, 
            'que � o relat�rio usado pelo Modulo X
            If Trim(UCase(Group.Name)) <> "MODULO X REPORTS" Then

                'Adiciona ao catalogo de Itens os Itens do Grupo
                ItemCatalog = Reports.ListChildren(strDirIni & "/" & Group.Name, False)

                'Para cada Item no Cat�logo de Itens
                For Each Item As CatalogItem In ItemCatalog

                    'S� insere os relat�rios que o final n�o seja TOTAL, pois eles
                    'j� fazem parte dos relat�rios padr�o. Cada rel�t�rio pode conter
                    'um TOTAL dentro dele.
                    If UCase(Mid(Trim(Item.Name), Len(Trim(Item.Name)) - 4)) <> "TOTAL" Then

                        nodeItem = New TreeNode()

                        With nodeItem

                            .Text = Item.Name

                        End With

                        TreeReports.Nodes(x).ChildNodes.Add(nodeItem)
                        'TreeReports.Nodes(x).ChildNodes(y).NavigateUrl = "inCabecalho.aspx?URL=http://" & Session("Server") & "/ReportServer/Pages/ReportViewer.aspx?%2fHargos Reports%2f" & Group.Name & "%2f" & Item.Name
                        'TreeReports.Nodes(x).ChildNodes(y).NavigateUrl = "ReportViewer.aspx?ReportPath=/Hargos Reports/" & Group.Name & "/" & Item.Name
                        If Trim(UCase(Session("Source"))) = "EXTRANET" Then
                            TreeReports.Nodes(x).ChildNodes(y).NavigateUrl = "http://" & Session("Link") & "/ReportServer/Pages/ReportViewer.aspx?%2fHargos Reports%2f" & Group.Name & "%2f" & Item.Name
                        Else
                            TreeReports.Nodes(x).ChildNodes(y).NavigateUrl = "http://" & Session("Server") & "/ReportServer/Pages/ReportViewer.aspx?%2fHargos Reports%2f" & Group.Name & "%2f" & Item.Name
                        End If
                        TreeReports.Nodes(x).ChildNodes(y).Target = "_blank"

                        y = y + 1

                    End If

                Next

                x = x + 1
                y = 0

            End If

        Next

    End Sub

End Class
