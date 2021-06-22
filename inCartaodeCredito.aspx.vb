Option Strict Off
Option Explicit Off

Imports XMail
Imports ConnectTo
Imports System.Data.SqlClient

Partial Class inCartaodeCredito
    Inherits System.Web.UI.Page

    Protected eMail As New XMail.SendMail

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim x As Integer = 0
        Dim y As Integer = 0

        Try
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientScript", "<script language=javascript src=Funcoes.js></script>")

            If cboMes.Items.Count <> 12 Then

                cboMes.Items.Clear()
                For x = 1 To 12
                    cboMes.Items.Add(x)
                Next x

                cboAno.Items.Clear()
                For x = Right(Year(Now), 1) To Right(Year(Now), 1) + 10
                    y = 3
                    If Len(CStr(x)) > 1 Then y = 2
                    cboAno.Items.Add(Left(Year(Now), y) & x)
                Next x

            End If

            If cboParcelas.Items.Count = 0 Then

                cboParcelas.Items.Clear()
                If cboBandeira.SelectedItem.Value = 1 Then

                    For x = 1 To 10
                        cboParcelas.Items.Add(x & "x")
                    Next x

                Else

                    For x = 1 To 6
                        cboParcelas.Items.Add(x & "x")
                    Next x

                End If

            Else

                If Trim(cboParcelas.SelectedItem.Value) = "1x" Then

                    'MASTER E DINNERS 6x / VISA EM 10x
                    cboParcelas.Items.Clear()
                    If cboBandeira.SelectedItem.Value = 1 Then

                        For x = 1 To 10
                            cboParcelas.Items.Add(x & "x")
                        Next x

                    Else

                        For x = 1 To 6
                            cboParcelas.Items.Add(x & "x")
                        Next x

                    End If

                End If

            End If

        Catch ex As Exception
            SendMailErro("Erro ao carregar pagamento com cartão de crédito." & Chr(13) & Chr(13) & "Número: " & Err.Number & Chr(13) & "Source: " & Err.Source & Chr(13) & "Descrição: " & Err.Description & Chr(13) & "Help: " & Chr(13) & Err.HelpFile & Chr(13) & Err.HelpContext & Chr(13) & Err.LastDllError)
            ShowMenssage("Intranet - Erro ao carregar rotina de pagamento com cartão de crédito." & Chr(13) & "Um relatório com a descrição do erro foi enviado ao suporte." & Chr(13) & Chr(13) & "Número: " & Err.Number & Chr(13) & "Source: " & Err.Source & Chr(13) & "Descrição: " & Err.Description & Chr(13) & "Help: " & Chr(13) & Err.HelpFile & Chr(13) & Err.HelpContext & Chr(13) & Err.LastDllError)
        End Try

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        Dim strSql As String = ""
        Dim strReturn As String = ""
        Dim strNomDevedor As String = ""
        dim strExtrato as String  = ""
        Dim Conn As New Comando
        Dim objDR As SqlDataReader = Nothing
        Dim strDescricao As String = ""

        Try

            btnRegistrar.Enabled = False

            strReturn = Trim(VerificarContrato(txtContrato.Text, 150))
            If strReturn = "erro" Then
                SendMailErro("Erro ao validar contrato." & Chr(13) & Chr(13) & "Número: " & Err.Number & Chr(13) & "Source: " & Err.Source & Chr(13) & "Descrição: " & Err.Description & Chr(13) & "Help: " & Chr(13) & Err.HelpFile & Chr(13) & Err.HelpContext & Chr(13) & Err.LastDllError)
                ShowMenssage("Intranet - Erro ao registrar pagamento com cartão de crédito.") ' & Chr(13) & "Um relatório com a descrição do erro foi enviado ao suporte." & Chr(13) & Chr(13) & "Número: " & Err.Number & Chr(13) & "Source: " & Err.Source & Chr(13) & "Descrição: " & Err.Description & Chr(13) & "Help: " & Chr(13) & Err.HelpFile & Chr(13) & Err.HelpContext & Chr(13) & Err.LastDllError)
                btnRegistrar.Enabled = True
            ElseIf strReturn = "" Then
                ShowMenssage("Contrato não localizado para este Contratante.")
                txtContrato.Focus()
                btnRegistrar.Enabled = True
                Exit Try
            End If

            If ValidarCartaodeCredito(SoNumeros(txtCartao.Text)) = False Then
                ShowMenssage("Cartão de crédito inválido, verifique o número digitado.")
                txtCartao.Focus()
                btnRegistrar.Enabled = True
                Exit Try
            End If

            If SoNumeros(txtCodigo.Text) = "" Then
                ShowMenssage("Preencha corretamente o Código de Segurança.")
                txtCodigo.Focus()
                btnRegistrar.Enabled = True
                Exit Try
            End If

            If Trim(txtNome.Text) = "" Then
                ShowMenssage("Preencha corretamente o campo Nome.")
                txtNome.Focus()
                btnRegistrar.Enabled = True
                Exit Try
            End If

            If SoNumeros(txtValor.Text) = "" Then
                ShowMenssage("Preencha corretamente o campo Valor Total.")
                txtValor.Focus()
                btnRegistrar.Enabled = True
                Exit Try
            End If

            strSql = "Select A.DEVE_Nome as Nome, C.TRAN_NumTitulo as Extrato " & _
                     "From Devedores A (NOLOCK) Join Contratos B (NOLOCK) On B.DEVE_Id = A.DEVE_Id " & _
                     "Join Transacoes C (NOLOCK) On C.CTRA_Id = B.CTRA_Id " & _
                     "Where B.CTRA_Numero = '" & SoNumeros(txtContrato.Text) & "'"
            objDR = Conn.ExecuteQuery(strSql)

            If Not objDR.Read Then
                ShowMenssage("Dados do contrato não localizado.")
                SendMailErro("Dados do contrato não localizado no pagamento com cartão de crédito." & Chr(13) & Chr(13) & "Contrato: " & SoNumeros(txtContrato.Text) & Chr(13) & "Query: " & Chr(13) & strSql)
                txtContrato.Focus()
                btnRegistrar.Enabled = True
                Exit Try
            End If

            strNomDevedor = UpperTrim(objDR("Nome").ToString)
            strExtrato = Trim(objDR("Extrato").ToString)

            If Trim(Session("Id_Usuario")) = "" Or Trim(Session("NomeUser")) = "" Then
                ShowMenssage("Sessão expirada. Logue novamente no sistema.")
                Exit Try
            End If

            Conn.Banco = "MIRRORWEB"

            strSql = "prc_INS_TransacaoCartao '" & SoNumeros(txtContrato.Text) & "','" & _
                                                   Trim(strExtrato) & "'," & _
                                                   cboBandeira.SelectedItem.Value & ",'" & _
                                                   SoNumeros(txtCartao.Text) & "','" & _
                                                   SoNumeros(txtCodigo.Text) & "','" & _
                                                   Trim(cboMes.SelectedItem.Text) & "/" & _
                                                   Trim(cboAno.SelectedItem.Text) & "','" & _
                                                   UpperTrim(txtNome.Text) & "','" & _
                                                   UpperTrim(strNomDevedor) & "'," & _
                                                   SoNumeros(cboParcelas.SelectedItem.Text) & "," & _
                                                   Replace(Replace(txtValor.Text, ".", ""), ",", ".") & "," & _
                                                   Trim(Session("Id_Usuario")) & ",'" & _
                                                   UpperTrim(Session("NomeUser")) & "'"
            Conn.Execute(strSql)

            strSql = "prc_SEL_TransacaoCartao '" & SoNumeros(txtContrato.Text) & "'"
            objDR = Conn.ExecuteQuery(strSql)

            If Not objDR.Read Then
                ShowMenssage("Id da transação não localizada.")
                SendMailErro("Id da transação não localizada no pagamento com cartão de crédito." & Chr(13) & Chr(13) & "Contrato: " & SoNumeros(txtContrato.Text) & Chr(13) & "Query: " & Chr(13) & strSql)
                btnRegistrar.Enabled = True
                Exit Try
            End If

            'strDescricao = "<br><b>Id Transação: </b>" & SoNumeros(objDR("ID")) & "." & _
            '               "<br><b>Contrato: </b>" & Incremente(SoNumeros(Trim(txtContrato.Text)), 4, ".", True) & _
            '               "<br><b>Nome Devedor: </b>" & strNomDevedor & _
            '               "<br><b>Extrato/Título: </b>" & Trim(strExtrato) & _
            '               "<br><b>Bandeira: </b>" & Trim(Replace(cboBandeira.SelectedItem.Text, "MASTER", "MASTERCARD")) & _
            '               "<br><b>Nº Cartão: </b>" & Trim(Incremente(Replace(txtCartao.Text, " ", ""), 4, " ", True)) & _
            '               "<br><b>Nome no Cartão: </b>" & UpperTrim(txtNome.Text) & _
            '               "<br><b>Cód.Segurança: </b>" & Trim(txtCodigo.Text) & _
            '               "<br><b>Validade: </b>" & Trim(cboMes.SelectedItem.Text) & "/" & Trim(cboAno.SelectedItem.Text) & _
            '               "<br><b>Valor Total: </b>R$" & Trim(txtValor.Text) & _
            '               "<br><b>Qtd Parcelas: </b>" & SoNumeros(cboParcelas.SelectedItem.Text) & "<br><br>"

            strDescricao = "<br><b>Id Transação: </b>" & SoNumeros(objDR("ID")) & "." & _
                           "<br><b>Contrato: </b>" & Incremente(SoNumeros(Trim(txtContrato.Text)), 4, ".", True) & _
                           "<br><b>Nome Devedor: </b>" & strNomDevedor & _
                           "<br><b>Extrato/Título: </b>" & Trim(strExtrato) & _
                           "<br><b>Valor Total: </b>R$" & Trim(txtValor.Text) & _
                           "<br><b>Qtd Parcelas: </b>" & SoNumeros(cboParcelas.SelectedItem.Text) & "<br><br>"

            Conn.Banco = "OSWEB"

            'strSql = "Select ID_Cliente From Clientes Where Cod_Cliente = 150"
            'objDR = Conn.ExecuteQuery(strSql)
            'objDR.Read()

            strSql = "OS_S_CADASTRO " & _
                     28 & "," & _
                     22 & ",'" & _
                     SoNumeros(txtContrato.Text) & "'"
            objDR = Conn.ExecuteQuery(strSql)

            If Not objDR.Read Then

                strSql = "Select TOP 1 ID_Usuario From Usuarios Where Upper(LTrim(RTrim(Nom_Usuario))) = '" & UpperTrim(Session("NomeUser")) & "'"
                objDR = Conn.ExecuteQuery(strSql)
                If Not objDR.Read Then
                    ShowMenssage("Id do usuário " & UpperTrim(Session("NomeUser")) & " não localizado.")
                    SendMailErro("Id do usuário não localizado no pagamento com cartão de crédito." & Chr(13) & Chr(13) & "Contrato: " & SoNumeros(txtContrato.Text) & Chr(13) & "Query: " & Chr(13) & strSql)
                    btnRegistrar.Enabled = True
                    Exit Try
                End If

                strSql = "OS_IU " & _
                         "0" & "," & _
                         28 & "," & _
                         22 & "," & _
                         Trim(objDR("ID_Usuario").ToString) & "," & _
                         457 & "," & _
                         "'" & "1 - Alta" & "','" & _
                         strDescricao & "'"
                Conn.Execute(strSql)

            End If

            ShowMenssage("Transação registrada com sucesso!")
            ClearScreen()
            btnRegistrar.Enabled = True

        Catch ex As Exception
            SendMailErro("Erro ao registrar pagamento com cartão de crédito." & Chr(13) & Chr(13) & "Número: " & Err.Number & Chr(13) & "Source: " & Err.Source & Chr(13) & "Descrição: " & Err.Description & Chr(13) & "Help: " & Chr(13) & Err.HelpFile & Chr(13) & Err.HelpContext & Chr(13) & Err.LastDllError & Chr(13) & "Query: " & strSql)
            ShowMenssage("Intranet - Erro ao registrar pagamento com cartão de crédito.") '& Chr(13) & "Um relatório com a descrição do erro foi enviado ao suporte." & Chr(13) & Chr(13) & "Número: " & Err.Number & Chr(13) & "Source: " & Err.Source & Chr(13) & "Descrição: " & Err.Description & Chr(13) & "Help: " & Chr(13) & Err.HelpFile & Chr(13) & Err.HelpContext & Chr(13) & Err.LastDllError)
            btnRegistrar.Enabled = True
        End Try

    End Sub

    Protected Function SoNumeros(ByVal strDado As String) As String

        Dim x As Short = 0

        Try

            If Trim(strDado) = "" Then Exit Try

            For x = 1 To Len(Trim(strDado))
                If IsNumeric(Mid(UpperTrim(strDado), x, 1)) = False Then
                    strDado = Trim(Replace(UpperTrim(strDado), Mid(UpperTrim(strDado), x, 1), ""))
                End If
            Next x

            SoNumeros = strDado

        Catch ex As Exception

            SoNumeros = "Erro"

        End Try

    End Function

    Protected Function UpperTrim(ByVal strText As String) As String

        Try

            UpperTrim = Trim(UCase(strText))

        Catch ex As Exception

            UpperTrim = ""

        End Try

    End Function

    Protected Function Incremente(ByRef strTexto As Object, ByRef intCada As Short, ByRef strIncremente As String, ByRef blnRemoverUltimo As Boolean) As Object

        Dim x As Short
        Dim strResult As String = ""

        If InStr(strTexto, strIncremente) = 0 Then

            strTexto = Trim(strTexto)

            For x = 1 To Len(strTexto)

                strResult = strResult & Mid(strTexto, x, 1)

                If InStr(CStr(x / intCada), ",") = 0 Then

                    If x = Len(strTexto) Then
                        If blnRemoverUltimo = False Then
                            strResult = strResult & "."
                        End If
                    Else
                        strResult = strResult & "."
                    End If

                End If

            Next x

            Incremente = Trim(strResult)

        Else

            Incremente = strTexto

        End If

    End Function

    Protected Sub ClearScreen()
        txtContrato.Text = ""
        txtCartao.Text = ""
        txtNome.Text = ""
        txtCodigo.Text = ""
        txtValor.Text = ""
        cboParcelas.SelectedIndex = 0
        cboMes.SelectedIndex = 0
        cboAno.SelectedIndex = 0
    End Sub

    Protected Sub SendMailErro(ByVal strDescricao As String)

        With eMail
            .From = "x_mail@hargos.com.br"
            .Sender = "Pagamento com Cartão de Crédito"
            .ToAddress = "rodrigo.barbieri@hargos.com.br"
            .ToName = "Rodrigo Barbieri - Hargos"
            .IsBodyHTML = False
            .Subject = "Erro no Registro de Pagamento com Cartão de Crédito."
            .Body = Trim(strDescricao)
        End With
        eMail.Send()

    End Sub

    Protected Sub ShowMenssage(ByVal strMsg As String)

        Dim strScript As String = "<script language=JavaScript>alert('" & strMsg & "');</script>"

        If (Not Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then

            Page.ClientScript.RegisterStartupScript(Me.GetType, "clientScript", strScript)

        End If

    End Sub

    Private Function VerificarContrato(ByVal strContrato As String, ByVal intContratante As Integer) As String

        Dim Conn As New Comando
        Dim objDR As SqlDataReader = Nothing
        Dim objDROS As SqlDataReader = Nothing
        Dim strSql As String = ""
        Dim x As Short = 0

        Try

            strContrato = SoNumeros(strContrato)

            Conn.Banco = "NEOWEB"

            strSql = "Select TOP 1 A.DEVE_Nome From Devedores A WITH(NOLOCK) " & _
                     "Join Contratos B WITH(NOLOCK) On " & _
                     "B.DEVE_ID = A.DEVE_ID " & _
                     "Join Carteiras C WITH(NOLOCK) On " & _
                     "C.CART_ID = B.CART_ID " & _
                     "Join Contratante D WITH(NOLOCK) On " & _
                     "D.CONT_ID = C.CONT_ID " & _
                     "Where D.CONT_ID = " & intContratante & " AND " & _
                     "B.CTRA_Numero = '" & strContrato & "'"
            objDR = Conn.ExecuteQuery(strSql)

            VerificarContrato = ""

            If objDR.Read Then VerificarContrato = Trim(objDR("DEVE_Nome").ToString)

        Catch ex As Exception

            VerificarContrato = "erro"

        End Try

    End Function

    Protected Function ValidarCartaodeCredito(ByVal strNumero As String) As Boolean

        Dim x As Integer = 0
        Dim intDV As Integer = 0
        Dim intDiv As Integer = 0
        Dim intNum As Integer = 0
        Dim intPeso As Integer = 0
        Dim strDV As String = ""

        Try

            strNumero = Trim(StrReverse(strNumero))
            intDiv = 10

            For x = 1 To Len(strNumero)

                intNum = Mid(strNumero, x, 1)

                If x Mod 2 = 0 Then
                    intPeso = 2
                Else
                    intPeso = 1
                End If

                strDV = strDV & CStr(intNum * intPeso)

            Next x

            For x = 1 To Len(strDV)

                intDV = intDV + Mid(strDV, x, 1)

            Next x

            If intDV Mod intDiv = 0 Then
                ValidarCartaodeCredito = True
            Else
                ValidarCartaodeCredito = False
            End If

        Catch ex As Exception
            ValidarCartaodeCredito = False
            SendMailErro("Erro ao validar cartão de crédito." & Chr(13) & Chr(13) & "Número: " & Err.Number & Chr(13) & "Source: " & Err.Source & Chr(13) & "Descrição: " & Err.Description & Chr(13) & "Help: " & Chr(13) & Err.HelpFile & Chr(13) & Err.HelpContext & Chr(13) & Err.LastDllError)
            ShowMenssage("Intranet - Erro ao validar cartão de crédito." & Chr(13) & "Um relatório com a descrição do erro foi enviado ao suporte." & Chr(13) & Chr(13) & "Número: " & Err.Number & Chr(13) & "Source: " & Err.Source & Chr(13) & "Descrição: " & Err.Description & Chr(13) & "Help: " & Chr(13) & Err.HelpFile & Chr(13) & Err.HelpContext & Chr(13) & Err.LastDllError)
        End Try

    End Function

End Class
