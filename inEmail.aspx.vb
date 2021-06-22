Option Explicit On

Imports XMail
Imports Scripting
Imports ConnectTo
Imports System.Data.SqlClient

Partial Class inEmail
    Inherits System.Web.UI.Page

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Dim eMail As New SendMail
        Dim objFSO As New FileSystemObject
        Dim objText As TextStream
        Dim Neo As New Comando
        Dim strSql As String = ""
        Dim strMail As String = ""
        Dim strNome As String = ""
        Dim strLayout As String = ""
        Dim strFoneRet As String = ""
        Dim strContratante As String = ""
        Dim objDR As SqlDataReader
        Dim objDRMail As SqlDataReader
        Dim ctraId As Integer = 0
        Dim x As Short = 0

        Try

            btnEnviar.Enabled = False

            strFoneRet = "SP: (011) 2171-0300, Demais Localidades: 0800-600-0500"

            If Trim(txtContrato.Text) = "" Then 'Or txtEmail.Text = "" Or InStr(txtEmail.Text, "@") = 0 Or InStr(UCase(txtEmail.Text), ".COM") = 0 Then
                ShowMessage("Preencha corretamente os campos.")
                txtContrato.Text = ""
                txtContrato.Focus()
                btnEnviar.Enabled = True
                Exit Try
            End If

            Neo.Banco = "NEOWEB"

            strSql = "Select D.CONT_RazaoSocial as Empresa, " & _
                     "A.DEVE_Nome as Nome, B.CTRA_Id as CTRA, A.DEVE_CGCCPF as CPF, " & _
                     "A.DEVE_EMAIL as EMail FROM " & _
                     "Devedores A (NOLOCK) Join " & _
                     "Contratos B (NOLOCK) " & _
                     "On B.DEVE_Id = A.DEVE_Id Join " & _
                     "Carteiras C (NOLOCK) " & _
                     "On C.CART_Id = B.CART_Id Join " & _
                     "Contratante D (NOLOCK) " & _
                     "On D.CONT_Id = C.CONT_Id " & _
                     "Where B.CTRA_Numero = '" & SoNumeros(txtContrato.Text) & "'"
            objDR = Neo.ExecuteQuery(strSql)

            If objDR.Read Then
                strNome = UpperTrim(objDR("Nome").ToString)
                strMail = UpperTrim(txtEmail.Text)
                If strMail = "" Then strMail = UpperTrim(objDR("EMail").ToString)
                If strMail = "" Or InStr(strMail, "@") = 0 Or InStr(strMail, ".COM") = 0 Then
                    x = 0
                    Neo.Banco = "MIRRORWEB"
                    strSql = "Select DEVE_EMAIL as MAIL From tb_eMail Where " & _
                             "DEVE_CGCCPF = '" & Trim(objDR("CPF").ToString) & "' " & _
                             "AND DEVE_EMAIL IS NOT NULL AND LTRIM(RTRIM(DEVE_EMAIL)) <> '' " & _
                             "AND CHARINDEX('.COM', UPPER(DEVE_EMAIL)) > 0"
                    objDRMail = Neo.ExecuteQuery(strSql)
                    Do While objDR.Read
                        If x > 0 Then strMail = strMail & ";"
                        strMail = strMail & UpperTrim(objDRMail("MAIL").ToString)
                        x = x + 1
                    Loop
                    Neo.Banco = "NEOWEB"
                    If strMail = "" Or InStr(strMail, "@") = 0 Or InStr(strMail, ".COM") = 0 Then
                        ShowMessage("E-Mail não encontrado no Neo ou inválido. Insira um e-mail válido.")
                        Exit Try
                    End If
                End If
                strContratante = UpperTrim(objDR("Empresa").ToString)
                ctraId = objDR("CTRA").ToString
            Else
                ShowMessage("Contrato não encontrado no Neo.")
                Exit Try
            End If

            strLayout = ""

            'objText = objFSO.OpenTextFile("J:\RB\X\Layouts\E_Mail\Layout2_4.html", IOMode.ForReading, False)
            objText = objFSO.OpenTextFile("C:\Layouts\E_Mail\Layout2_4.html", IOMode.ForReading, False)

            Do While Not objText.AtEndOfStream

                strLayout = strLayout & objText.ReadLine

            Loop

            objText.Close()

            strLayout = Replace(strLayout, "height=60src=", "height=60 src=")
            strLayout = Replace(strLayout, "$NOME_DEVEDOR$", strNome)
            strLayout = Replace(strLayout, "$CONTRATANTE$", strContratante)
            strLayout = Replace(strLayout, "$FONE_RET$", strFoneRet)

            With eMail
                .From = "x_mail@hargos.com.br"
                .Sender = "Hargos"
                .Subject = "Comunicado Urgente!"
                .IsBodyHTML = True
                .HighPriority = True
                .Body = strLayout
                .ToAddress = strMail
                .ToName = strNome
            End With

            eMail.Send()

            Neo.Banco = "MIRRORWEB"
            strSql = "prc_INS_EmailEmissao 13, '" & strMail & "'," & ctraId & "," & Trim(Session("Id_Usuario"))
            Neo.Execute(strSql)

            txtContrato.Text = ""
            txtEmail.Text = ""

            ShowMessage("E-Mail enviado com sucesso!")

        Catch ex As Exception

            ShowMessage("Erro na emissão do X-Mail. Informe o desenvolvimento.!")
            Exit Try

        End Try

        btnEnviar.Enabled = True

    End Sub

    Private Function SoNumeros(ByVal strDado As String) As String

        Dim x As Short = 0

        Try

            For x = 1 To Len(UpperTrim(strDado))
                If IsNumeric(Mid(UpperTrim(strDado), x, 1)) = False Then
                    strDado = Trim(Replace(UpperTrim(strDado), Mid(UpperTrim(strDado), x, 1), ""))
                End If
            Next x

            SoNumeros = strDado

        Catch ex As Exception

            SoNumeros = "Erro"

        End Try

    End Function

    Public Sub ShowMessage(ByVal strMsg As String)

        Dim strScript As String = "<script language=JavaScript>alert('" & strMsg & "');</script>"

        If (Not Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then

            Page.ClientScript.RegisterStartupScript(Me.GetType, "clientScript", strScript)

        End If

    End Sub

    Public Function UpperTrim(ByVal strText As String) As String

        Try

            UpperTrim = Trim(UCase(strText))

        Catch ex As Exception

            UpperTrim = ""

        End Try

    End Function

End Class
