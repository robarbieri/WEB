Option Explicit On
Option Strict Off

'Importa referências
Imports System.Web.Services.Protocols
Imports System
Imports System.Xml
Imports System.Web.UI.WebControls
Imports PesquisarWS

'Classe pesquisa
Partial Class Pesquisa
    Inherits System.Web.UI.Page

    'Variáveis
    Private btnLimparCampo(9) As Button
    Private txtCampo(9) As TextBox
    Private blnLimparCampo As Boolean
    Private blnBuscaAV As Boolean
    Private WSPesquisa As New PesquisarWS.Pesquisa

    'Carregar página
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Ajax.Utility.RegisterTypeForAjax(GetType(Pesquisa))

        'Se LimparCampo for verdadeiro saia
        'If blnLimparCampo = True Then Exit Sub

        lblResult.Text = ""
        'Session("HTML") = ""

        Dim x As Short

        On Error Resume Next

        If Trim(Session("NomeUser")) = "" Then
            Response.Redirect("Login.aspx")
        End If

        'If Trim(Session("AuthInfo")) = "" Then
        'Dim WSInfo As New InforMarketing.WEBServiceScore
        'Session("AuthInfo") = WSInfo.getLogin("credicard1", "caneta", "hargos")
        'End If

        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientScript", "<script language=javascript src=Funcoes.js></script>")

        'Verifica se existe usuário logado e redireciona para o Login caso não exista
        'If Trim(Session("UsuarioX")) = "" Or Trim(Session("PasswordX")) = "" Then
        '    'Response.Redirect("Login.aspx?Id=Pesquisa")
        '    Session("UsuarioX") = "credicard1"
        '    Session("PasswordX") = "caneta"
        'End If

        'Carrega a combo de UF caso ela não possua a quantidade correta de registros
        If cboUF.Items.Count < 29 Then
            cboUF.Items.Clear()
            cboUF.Items.Add("AC")
            cboUF.Items.Add("AL")
            cboUF.Items.Add("AP")
            cboUF.Items.Add("AM")
            cboUF.Items.Add("BA")
            cboUF.Items.Add("CE")
            cboUF.Items.Add("DF")
            cboUF.Items.Add("ES")
            cboUF.Items.Add("GO")
            cboUF.Items.Add("MA")
            cboUF.Items.Add("MT")
            cboUF.Items.Add("MS")
            cboUF.Items.Add("MZ")
            cboUF.Items.Add("MG")
            cboUF.Items.Add("NI")
            cboUF.Items.Add("PA")
            cboUF.Items.Add("PB")
            cboUF.Items.Add("PR")
            cboUF.Items.Add("PE")
            cboUF.Items.Add("PI")
            cboUF.Items.Add("RJ")
            cboUF.Items.Add("RN")
            cboUF.Items.Add("RS")
            cboUF.Items.Add("RO")
            cboUF.Items.Add("RR")
            cboUF.Items.Add("SC")
            cboUF.Items.Add("SP")
            cboUF.Items.Add("SE")
            cboUF.Items.Add("TO")

            cboUF.SelectedIndex = 26

            txtCPF.Focus()

        End If

        'Carrega o Array de Botões
        'btnLimparCampo(0) = New Button
        'btnLimparCampo(0) = Button2
        'btnLimparCampo(1) = Button3
        'btnLimparCampo(2) = Button4
        'btnLimparCampo(3) = Button5
        'btnLimparCampo(4) = Button6
        'btnLimparCampo(5) = Button7
        'btnLimparCampo(6) = Button8
        'btnLimparCampo(7) = Button9
        'btnLimparCampo(8) = Button10
        'btnLimparCampo(9) = Button11

        'Carrega o Array de Campos
        txtCampo(0) = txtCPF
        txtCampo(1) = txtNome
        txtCampo(2) = txtDDD
        txtCampo(3) = txtFone
        txtCampo(4) = txtEndereco
        txtCampo(5) = txtNumero
        txtCampo(6) = txtComplemento
        txtCampo(7) = txtBairro
        txtCampo(8) = txtCEP
        txtCampo(9) = txtCidade

        'Formata o texto dos campos para sem espaços e maísculo
        For x = 0 To UBound(txtCampo)

            txtCampo(x).Text = Trim(UCase(txtCampo(x).Text))

        Next x

        'Carrega a combo de Qtde caso ela não possua a quantidade correta de registros
        If cboQtd.Items.Count < 14 Then
            cboQtd.Items.Clear()

            For x = 1 To 9
                cboQtd.Items.Add(x)
            Next x

            For x = 10 To 50 Step 10
                cboQtd.Items.Add(x)
            Next x

            cboQtd.SelectedIndex = 9

        End If

        btnBuscar.Attributes.Add("onclick", _
                                 " this.disabled = true; " + _
                                 " btnProximidades.disabled = true; " + _
                                 " Button1.disabled = true; " + _
                                 " Button2.disabled = true; " + _
                                 " Button3.disabled = true; " + _
                                 " Button4.disabled = true; " + _
                                 " Button5.disabled = true; " + _
                                 " Button6.disabled = true; " + _
                                 " Button7.disabled = true; " + _
                                 " Button8.disabled = true; " + _
                                 " Button9.disabled = true; " + _
                                 " Button10.disabled = true; " + _
                                 " Button11.disabled = true; " + _
                                 " Map.disabled = true; " + _
                                 ClientScript.GetPostBackEventReference(btnBuscar, "") + ";")
        '" lblResult.disabled = true; " + _
        btnProximidades.Attributes.Add("onclick", _
                                       " this.disabled = true; " + _
                                       " btnBuscar.disabled = true; " + _
                                       " Button1.disabled = true; " + _
                                       " Button2.disabled = true; " + _
                                       " Button3.disabled = true; " + _
                                       " Button4.disabled = true; " + _
                                       " Button5.disabled = true; " + _
                                       " Button6.disabled = true; " + _
                                       " Button7.disabled = true; " + _
                                       " Button8.disabled = true; " + _
                                       " Button9.disabled = true; " + _
                                       " Button10.disabled = true; " + _
                                       " Button11.disabled = true; " + _
                                       " Map.disabled = true; " + _
                                       ClientScript.GetPostBackEventReference(btnProximidades, "") + ";")
        '" lblResult.disabled = true; " + _

        'txtMsg.Text = "Usuário: " & Trim(Session("NomeUser"))
        'txtUsuario.Text = Trim(Session("NomeUser"))

    End Sub

    'Ao Clicar em Buscar
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'lblResult.Text = ""
        'Session("HTML") = ""

        If Trim(txtCPF.Text) = "" And _
           Trim(txtFone.Text) = "" And _
           Trim(txtNome.Text) = "" And _
           Trim(txtEndereco.Text) = "" And _
           Trim(txtCEP.Text) = "" Then
            lblResult.ForeColor = Drawing.Color.DarkOrange
            lblResult.Text = "Favor inserir dados para a pesquisa."
            Exit Sub
        End If

        'Chama rotina de busca
        Call Buscar(0)

    End Sub

    'Ao clicar em Proximidades/Vizinhos
    Protected Sub btnProximidades_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProximidades.Click

        lblResult.Text = ""
        'Session("HTML") = ""

        'Verifica se os campos chave estão preenchidos
        If Trim(txtEndereco.Text) = "" Or Trim(txtCidade.Text) = "" Or Trim(txtNumero.Text) = "" Then

            'Caso não, avisa o usuário e sai da rotina
            lblResult.ForeColor = Drawing.Color.DarkOrange
            lblResult.Text = "Preencha os campos endereço, número e cidade para buscar proximidades."

            If Trim(txtEndereco.Text) = "" Then txtEndereco.Focus()
            If Trim(txtCidade.Text) = "" Then txtCidade.Focus()
            If Trim(txtNumero.Text) = "" Then txtNumero.Focus()
            Exit Sub

        End If

        'Caso sim , vá para a rotina de Busca
        Call Buscar(1)

    End Sub

    'Ao Clicar em limpar
    'Protected Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpar.Click

    '    'Limpa campos
    '    txtBairro.Text = ""
    '    txtCep.Text = ""
    '    txtCidade.Text = ""
    '    txtComplemento.Text = ""
    '    txtCPF.Text = ""
    '    txtDDD.Text = ""
    '    txtEndereco.Text = ""
    '    'txtMsg.Text = ""
    '    txtNome.Text = ""
    '    txtNumero.Text = ""
    '    txtFone.Text = ""
    '    cboQtd.SelectedIndex = 9
    '    cboUF.SelectedIndex = 26

    '    'LimparCampo = verdadeiro
    '    blnLimparCampo = True

    'End Sub

    'Rotina de Busca
    '<Ajax.AjaxMethod()> _
    'Public Function Buscar(ByVal intTipoBusca As Short, _
    '                       ByVal txtCPF As String, _
    '                       ByVal txtNome As String, _
    '                       ByVal txtDDD As String, _
    '                       ByVal txtFone As String, _
    '                       ByVal txtCEP As String, _
    '                       ByVal txtEndereco As String, _
    '                       ByVal txtNumero As String, _
    '                       ByVal txtComplemento As String, _
    '                       ByVal txtCidade As String, _
    '                       ByVal txtBairro As String, _
    '                       ByVal intQtde As Integer, _
    '                       ByVal strUF As String, _
    '                       ByVal strUsuario As String) As String

    Public Sub Buscar(ByVal intTipoBusca As Short)

        'Variáveis e objetos
        Dim arrFonts(1) As String
        Dim arrWidth(7) As Short
        Dim strCidade As String
        Dim intArrays As Short
        Dim strUser As String
        Dim strPass As String
        Dim x As Short
        Dim y As Short
        Dim z As Short
        Dim intErro As Short
        Dim intSentido As Short
        Dim blnHigienizar As Boolean
        Dim strBases As String
        Dim strHTML As String
        Dim strUsuario As String
        Dim blnFullAccess As Boolean
        'Dim WSInfo As New InforMarketing.WEBServiceScore
        'Dim strAuthInfo As String

        'Caso erro, vá para tratar erros
        On Error GoTo ErrHandler

        strUsuario = Trim(Session("NomeUser"))

        btnBuscar.Enabled = False
        btnProximidades.Enabled = False

        'strAuthInfo = WSInfo.getLogin("credicard1", "caneta", "hargos")

        'Guarda o usuário e senha em variáveis
        'strUser = Trim(Session("UsuarioX"))
        'strPass = Trim(Session("PasswordX"))
        strUser = "credicard1"
        strPass = "caneta"

        'Caso o campo telefone seja diferente de "BRANCO"
        If Trim(txtFone.Text) <> "" Then

            'Remove os caracteres que não sejam numéricos
            For x = 1 To Len(Trim(UCase(txtFone.Text)))
                If IsNumeric(Mid(Trim(UCase(txtFone.Text)), x, 1)) = False Then
                    txtFone.Text = Trim(Replace(Trim(UCase(txtFone.Text)), Mid(Trim(UCase(txtFone.Text)), x, 1), ""))
                End If
            Next x

            'Arruma a quantidade de caracteres do campo telefone
            If Len(Trim(txtFone.Text)) > 8 Then
                'txtMsg.ForeColor = Drawing.Color.Red
                'txtMsg.Text = "Telefone Inválido. Deve conter 8 dígitos."
                'txtTelefone.Focus()
                'Exit Sub
                txtFone.Text = Left(txtFone.Text, 8)
            End If

            'If InStr("7,8,9,", Left(Trim(txtTelefone.Text), 1) & ",") > 0 Then blnCel = True

            'Caso o campo DDD seja diferente de "BRANCO"
            If Trim(txtDDD.Text) <> "" Then

                'Verifica se o campo DDD possui 2 dígitos numérico
                If Len(Trim(txtDDD.Text)) <> 2 Or IsNumeric(Trim(txtDDD.Text)) = False Then
                    'Caso não, mostra aviso e sai da rotina
                    'txtMsg.ForeColor = Drawing.Color.Red
                    'txtMsg.Text = "DDD Inválido. Deve conter 2 dígitos numéricos."
                    lblResult.ForeColor = Drawing.Color.DarkOrange
                    lblResult.Text = "DDD Inválido. Deve conter 2 dígitos numéricos."
                    Exit Sub
                End If

            End If

        End If

        'Caso o campo CPF seja diferente de "BRANCO"
        If Trim(txtCPF.Text) <> "" Then

            'Remove os caracteres que não sejam numéricos
            For x = 1 To Len(Trim(UCase(txtCPF.Text)))
                If IsNumeric(Mid(Trim(UCase(txtCPF.Text)), x, 1)) = False Then
                    txtCPF.Text = Trim(Replace(Trim(UCase(txtCPF.Text)), Mid(Trim(UCase(txtCPF.Text)), x, 1), ""))
                End If
            Next x

            'Formata o campo com 14 caracteres
            'txtCPF.Text = Trim(Replace(Right(Space(14) & Trim(txtCPF.Text), 14), " ", "0"))

            'Verifica se o campo CPF possui 14 dígitos numérico
            If Len(Trim(Replace(Right(Space(14) & Trim(txtCPF.Text), 14), " ", "0"))) <> 14 Or IsNumeric(Trim(txtCPF.Text)) = False Then
                'Caso não, mostra aviso e sai da rotina
                'txtMsg.ForeColor = Drawing.Color.Red
                'txtMsg.Text = "CPF Inválido."
                lblResult.ForeColor = Drawing.Color.DarkOrange
                lblResult.Text = "CPF Inválido."
                Exit Sub
            End If

        End If

        'Cria objeto de Xml que irá conter os dados de retorno da pesquisa
        intArrays = 0

        'For x = 0 To 1
        '    xmlFinder(x) = New Xml.
        '    intArrays = x
        'Next x

        'x = 0

        'Carrega e arruma em variável a Cidade
        strCidade = Trim(UCase(txtCidade.Text))

        'Carrega e arruma em variável o Endereço
        txtEndereco.Text = Trim(UCase(Replace(Replace(Replace(Replace(Trim(UCase(txtEndereco.Text)), "R.", ""), "AV.", ""), "PCA.", ""), "PÇA", "")))

        'Remove o prefixo do endereço "R.","AV.","PÇA",etc...
        If InStr(txtEndereco.Text, ".") > 0 Then txtEndereco.Text = Trim(UCase(Mid(txtEndereco.Text, InStr(txtEndereco.Text, ".") + 1)))

        'Separa o número e complemento do endereço
        If InStr(txtEndereco.Text, ",") > 0 Then

            txtNumero.Text = Trim(UCase(Mid(txtEndereco.Text, InStr(txtEndereco.Text, ",") + 1)))
            txtEndereco.Text = Trim(UCase(Replace(Left(Trim(UCase(txtEndereco.Text)), InStr(txtEndereco.Text, ",")), ",", "")))

            If InStr(txtNumero.Text, " ") > 0 Then

                txtComplemento.Text = Trim(UCase(Mid(txtNumero.Text, InStr(txtNumero.Text, " ") + 1)))
                txtNumero.Text = Trim(UCase(Left(Trim(UCase(txtNumero.Text)), InStr(txtNumero.Text, " "))))

            End If

        End If

        'Verifica se é para fazer a busca AV - AUT
        'blnBuscaAV = False
        'If chkAV.Checked = True Then blnBuscaAV = True
        blnBuscaAV = True

        'Verifica se é para HIGIENIZAR o resultado
        blnHigienizar = False
        'If chkHigienizar.Checked = True Then blnHigienizar = True

        'Verifica quais bases deve utilizar p/pesquisa
        'strBases = "Fixo/Movel/Satelite"
        'strBases = ""
        'If chkFixo.Checked = True Then strBases = "FIXO"
        'If chkMovel.Checked = True Then strBases = strBases & "MOVEL"
        'If chkSatelite.Checked = True Then strBases = strBases & "SATELITE"
        strBases = "Fixo/Movel"

        'Se der erro, continue
        On Error Resume Next

        'Busque
Find:
        Err.Clear()

        blnFullAccess = False

        With WSPesquisa

            .BuscarLocal = True
            .BuscarCredi = True
            .BuscarAFinder = True
            .BuscarInfo = True
            .BuscarSerasa = True
            .TimeOut = 4000
            If InStr(UCase(Trim(strUsuario)), " IBI") > 0 Or _
               InStr(UCase(Trim(strUsuario)), " CEF") > 0 Or _
               InStr(UCase(Trim(strUsuario)), " SKY") > 0 Or _
               InStr(UCase(Trim(strUsuario)), " CARREFOUR") > 0 Then
                .BuscarInfo = False
                'blnFullAccess = False
                'ElseIf UCase(Trim(strUsuario)) = "ADM" Or Trim(txtCPF.Text) = "" Then
                'ElseIf UCase(Trim(strUsuario)) = "ADM" Then
                '.BuscarLocal = True
                '.BuscarCredi = True
                '.BuscarAFinder = True
                '.BuscarSerasa = True
                '.BuscarInfo = True
                'If Trim(txtCPF.Text) = "" Then .BuscarInfo = False
                'blnFullAccess = False
                'Else
                '    .BuscarLocal = False
                '    .BuscarCredi = False
                '    .BuscarAFinder = False
                '    .BuscarSerasa = False
                '    .BuscarInfo = True
                'blnFullAccess = True
            End If
            If Trim(txtCPF.Text) = "" Then .BuscarInfo = False
            .UserFinder = "credicard1"
            .PassFinder = "caneta"
            .UserCredi = "HARGOS"
            .PassCredi = "HARGOS"
            .Usuario = Trim(strUsuario)
            If Trim(txtDDD.Text) = "" And _
               Trim(txtFone.Text) = "" And _
               Trim(txtCPF.Text) = "" And _
               Trim(txtNome.Text) = "" And _
               (Trim(txtCEP.Text) <> "" Or Trim(txtEndereco.Text) <> "") Then .BuscarLocal = False
            If Trim(txtCPF.Text) = "" And Trim(txtNome.Text) = "" And _
               Trim(txtDDD.Text) = "" And Trim(txtFone.Text) = "" Then
                blnBuscaAV = False
            End If
            If blnBuscaAV = True Then
                .BuscaAut = True
                .Proximidades = False
            End If
            If intTipoBusca = 1 Then
                .Proximidades = True
                .BuscaAut = False
                .BuscarInfo = False
                txtNome.Text = ""
                txtCPF.Text = ""
                txtDDD.Text = ""
                txtFone.Text = ""
            End If
            .UF = Trim(UCase(cboUF.SelectedItem.Value.ToString))
            .Cidade = strCidade
            .Bairro = Trim(UCase(txtBairro.Text))
            .Endereco = Trim(UCase(txtEndereco.Text))
            .Numero = Trim(UCase(txtNumero.Text))
            .Complemento = Trim(UCase(txtComplemento.Text))
            .CEP = Trim(UCase(txtCEP.Text))
            .Nome = Trim(UCase(txtNome.Text))
            .CPF = Trim(UCase(txtCPF.Text))
            .DDD = Trim(UCase(txtDDD.Text))
            .Telefone = Trim(UCase(txtFone.Text))
            .Registros = Trim(cboQtd.SelectedItem.Value.ToString)
            .Higienizar = blnHigienizar
            .Bases = strBases

        End With

        'If Trim(UCase(cboUF.SelectedItem.Value.ToString)) = "SP" Then
        '    WSPesquisa.BuscarInfo = False
        'End If

        strHTML = WSPesquisa.Localizar

        'Caso erro, tenta refazer a busca
        If Err.Number <> 0 Then

            intErro = intErro + 1

            If intErro <= 1 Then
                GoTo Find
            Else
                GoTo ErrHandler
            End If

        End If

        'If Trim(strHTML) = "" And blnFullAccess = True Then

        '    With WSPesquisa

        '        .BuscarLocal = True
        '        .BuscarCredi = True
        '        .BuscarAFinder = True
        '        .BuscarSerasa = True
        '        .BuscarInfo = False

        '    End With

        '    strHTML = WSPesquisa.Localizar

        'End If

        'Caso erro, vá para tratar erros
        On Error GoTo ErrHandler

TryIt:

        On Error GoTo ErrHandler

        If Trim(strHTML) = "" Then
            lblResult.ForeColor = Drawing.Color.DarkOrange
            strHTML = "Não Localizado."
            'strHTML = "Não Localizado."
            'Else
            '    txtMsg.ForeColor = Drawing.Color.DarkOrange
            '    txtMsg.Text = "Localizado."
        End If

        'Session("Result") = strHTML
        lblResult.Enabled = True
        lblResult.Text = strHTML

        btnBuscar.Enabled = True
        btnProximidades.Enabled = True

        Exit Sub

        'Tratar erros
ErrHandler:

        intErro = 0
        lblResult.ForeColor = Drawing.Color.Red
        lblResult.Text = Err.Description
        'Return Err.Description
        Err.Clear()

        btnBuscar.Enabled = True
        btnProximidades.Enabled = True

    End Sub

    ''Ao clicar em LimparCampo
    'Protected Sub LimparCampo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click

    '    Dim x As Short

    '    blnLimparCampo = True

    '    'Limpa apenas o campo que foi clicado
    '    For x = 0 To UBound(btnLimparCampo)

    '        If btnLimparCampo(x).ID = sender.id Then

    '            txtCampo(x).Text = ""
    '            Exit For

    '        End If

    '    Next x

    '    txtCampo(0).Text = ""

    '    ''txtMsg.Text = ""

    'End Sub

End Class

