Imports System.Web.Services.Protocols
Imports WebReportServer

Partial Class _inConteudo
    Inherits System.Web.UI.Page

    'Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

    '    If Trim(UCase(Session("Id"))) = "REPORTS" Then

    '        Dim Reports As New WebReportServer.ReportingService
    '        Dim ReportCatalog As CatalogItem()
    '        Dim x As Integer

    '        Reports.Url = "http://" & Session("Server") & "/ReportServer/ReportService.asmx"

    '        Reports.Credentials = System.Net.CredentialCache.DefaultCredentials

    '        ReportCatalog = Reports.ListChildren("/Hargos Reports", False)

    '        x = 0

    '        Session("Reports") = ""

    '        For Each Item As CatalogItem In ReportCatalog

    '            If Trim(UCase(Item.Name)) <> "MODULO X REPORTS" Then

    '                If x > 0 Then
    '                    Session("Reports") = Session("Reports") & ";"
    '                End If

    '                Session("Reports") = Session("Reports") & Trim(Item.Name)

    '                x = x + 1

    '            End If

    '        Next

    '    End If

    'End Sub

End Class
