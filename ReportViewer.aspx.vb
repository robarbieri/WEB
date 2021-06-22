
Partial Class ReportViewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strReport As String

        strReport = Trim(Request.QueryString("ReportPath"))
        If ReportViewerX.ServerReport.ReportPath <> strReport Then _
        ReportViewerX.ServerReport.ReportPath = strReport

    End Sub

End Class
