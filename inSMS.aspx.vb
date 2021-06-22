Option Explicit On
Option Strict Off

'Imports aFinder
Imports ConnectTo
Imports WSMS
Imports System
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Web.Services.Protocols

Partial Class inSMS
    Inherits System.Web.UI.Page

    Private Neo As New Comando
    Private Mirror As New Comando
    Private strSql As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objDR As SqlDataReader = Nothing
        Dim x As Short = 0

        Try

            If Trim(lblPreview.Text) = "" Then

                cboTipoMensagem.Items.Clear()

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientScript", "<script language=javascript src=http://DBMIRROR/OSWeb/shared/js/fnFormatContrato.js></script>" & _
                                                                                        "<script language=javascript src=Funcoes.js></script>")

                Mirror.Banco = "MIRRORWEB"
                strSql = "Select LAYO_ID, LAYO_TipoMsg, LAYO_Descricao From tb_FoneSMSLayout"
                objDR = Mirror.ExecuteQuery(strSql)

                x = 0

                Do While objDR.Read

                    If x = 0 Then lblPreview.Text = Trim(objDR("LAYO_Descricao").ToString)
                    cboTipoMensagem.Items.Add(objDR("LAYO_ID").ToString & " - " & objDR("LAYO_TipoMsg").ToString)

                    x = x + 1

                Loop

            End If

        Catch ex As Exception

            ShowMessage("Condição inesperada. Favor comunicar o Desenvolvimento.")
            txtContrato.Text = ""
            btnEnviar.Enabled = True
            Exit Sub

        End Try

    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Dim wSMS As New WebService

        Try

            btnEnviar.Enabled = False

            If Trim(txtContrato.Text) = "" Or Trim(lblPreview.Text) = "" Then
                ShowMessage("Preencha corretamente os campos.")
                txtContrato.Text = ""
                txtContrato.Focus()
                btnEnviar.Enabled = True
                Exit Sub
            End If

            Session("URL") = wSMS.Enviar(SoNumeros(txtContrato.Text), Left(cboTipoMensagem.SelectedItem.ToString, 1), CInt(Trim(Session("Id_Usuario"))))

            If Trim(Session("URL")) = "" Then
                Session("Enviar") = ""
                Session("URL") = ""
                ShowMessage("Celular não localizado ou inválido para este Contrato.")
            Else
                Session("Enviar") = "Sim"
            End If

            txtContrato.Text = ""

            btnEnviar.Enabled = True

        Catch ex As Exception

            ShowMessage("Condição inesperada. Favor comunicar o Desenvolvimento.")
            txtContrato.Text = ""
            btnEnviar.Enabled = True
            Exit Sub

        End Try

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