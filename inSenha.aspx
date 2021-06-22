<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inSenha.aspx.vb" Inherits="inSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Alterar Senha</title>
</head>
<body bgcolor="#1f3662">
    <form id="form1" runat="server">
    <div>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 392px" align="center">
            <tr>
                <td align="center" colspan="3" valign="middle" style="width: 488px">
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Login_Tit.jpg" /></td>
            </tr>
            <tr>
                <td align="center" colspan="3" rowspan="2" style="width: 488px">
                    <br />
                    <asp:ChangePassword ID="AlteraSenha" runat="server" BackColor="DarkOrange" ChangePasswordButtonText="Alterar Senha"
                        ChangePasswordFailureText="Senha incorreta ou Nova Senha inválida." ChangePasswordTitleText="Altere Sua Senha"
                        ConfirmNewPasswordLabelText="Confirme a Nova Senha:" ConfirmPasswordCompareErrorMessage="Senha não confirmada."
                        ConfirmPasswordRequiredErrorMessage="É necessária a confirmaçãoi da senha." Font-Bold="True"
                        Font-Names="Verdana,Arial" Font-Size="8pt" ForeColor="White" Height="168px" NewPasswordLabelText="Nova Senha:"
                        NewPasswordRegularExpressionErrorMessage="Por favor, entre uma senha diferente."
                        NewPasswordRequiredErrorMessage="É necessario inserir a nova senha." PasswordLabelText="Senha:"
                        PasswordRequiredErrorMessage="É necessário inserir a senha." SuccessText="Senha alterada com sucesso!"
                        SuccessTitleText="Alteração de senha concluída." UserNameLabelText="Usuário:"
                        UserNameRequiredErrorMessage="É necessário inserir o Usuário.">
                        <CancelButtonStyle Font-Names="Verdana,Arial" Font-Size="8pt" />
                        <InstructionTextStyle Font-Names="Verdana,Arial" Font-Size="8pt" />
                        <ChangePasswordButtonStyle Font-Names="Verdana,Arial" Font-Size="8pt" />
                        <FailureTextStyle Font-Bold="True" Font-Names="Verdana,Arial" Font-Size="8pt" ForeColor="Navy" />
                        <SuccessTextStyle Font-Bold="True" Font-Names="Verdana,Arial" ForeColor="White" />
                        <TitleTextStyle Font-Bold="True" />
                        <ValidatorTextStyle Font-Bold="True" ForeColor="ActiveCaption" />
                    </asp:ChangePassword>
                </td>
            </tr>
            <tr>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
