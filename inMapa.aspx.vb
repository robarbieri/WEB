
Partial Class inMapa
    Inherits System.Web.UI.Page

    Protected strDados As String
    Protected strCPF As String
    Protected strNome As String
    Protected strEndereco As String
    Protected strBairro As String
    Protected strCep As String
    Protected strCidade As String
    Protected strUF As String
    Protected strPais As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strDados = Trim(Replace(" " & Trim(UCase(Request.QueryString("end"))), "ENG ", "ENGENHEIRO "))
        strDados = Trim(Replace(" " & Trim(UCase(strDados)), " RUA ", ""))
        strDados = Trim(Replace(" " & Trim(UCase(strDados)), " AVENIDA ", ""))
        strDados = Trim(Replace(" " & Trim(UCase(strDados)), " R ", ""))
        strDados = Trim(Replace(" " & Trim(UCase(strDados)), " AV ", ""))
        strDados = Trim(Replace(" " & Trim(UCase(strDados)), " GEN ", "GENERAL "))
        strDados = Trim(Replace(" " & Trim(UCase(strDados)), " PE ", "PADRE "))
        strDados = Trim(strDados)

        strCPF = Trim(Request.QueryString("cpf"))
        strNome = Trim(Request.QueryString("nome"))
        strEndereco = Trim(Request.QueryString("endereco"))
        strBairro = Trim(Request.QueryString("bairro"))
        strCep = Trim(Request.QueryString("cep"))
        strCidade = Trim(Request.QueryString("cidade"))
        strUF = Trim(Request.QueryString("uf"))
        strPais = Trim(Request.QueryString("pais"))
    End Sub
End Class
