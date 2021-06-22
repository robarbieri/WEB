<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login - Hargos <%=Session("Source")%></title>
</head>
<body background="Images/bgb.gif">
    <form id="form1" runat="server">
    <div>
        <% 
            Dim intCabecalho As Short
            
            intCabecalho = Request("Cabecalho")
            If intCabecalho = 0 Then intCabecalho = Session("Cabecalho")
            If intCabecalho = 0 Then intCabecalho = 1
            Session.Timeout = 60
            Session("Cabecalho") = intCabecalho
            
        %>
        <table align="center" bgcolor="#ffffff" border="1" bordercolor="#ffffff" cellpadding="0"
            cellspacing="0" style="width: 640px; height: 1px">
            <tr>
                <td align="center" style="width: 774px; height: 2px" valign="top">
                    <table cellpadding="0" cellspacing="0" style="width: 696px; height: 1px">
                        <% If intCabecalho = 1 Then%>
                        <tr>
                            <td align="center" bordercolor="#ffffff" colspan="1" style="width: 780px; height: 184px" valign="top">
                                <a href="http://<%=Session("Server")%>/intranet/Login.aspx?Cabecalho=2"><img src="Images\Top_Hargos.jpg" border="0"/></a>
                            </td>
                        </tr>
                        <% End If%>
                        <tr>
                            <td align="center" style="width: 780px; height: 37px" valign="top">
                                <a href="http://<%=Session("Server")%>/intranet/Login.aspx?Cabecalho=1"><img src="Images/Menu_<%=Session("Source")%>_<%=intCabecalho%>.jpg" border=0></a>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 780px; height: 78px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 776px; height: 200px">
                                    <tr>
                                        <td align="left" style="width: 13px; height: 259px" valign="top">
                                            <img align="top" src="Images/Left.jpg" /></td>
                                        <td align="center" style="width: 521px; color: white;
                                            height: 259px; font-weight: bold;" valign="top" bgcolor="#1f3662">
                                            <br />
                                            <br />
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Login_Tit.jpg" /><br />
                                            <br />
                                                            <asp:Login ID="Login" runat="server" BackColor="DarkOrange" FailureText="Login Inválido." Font-Names="Verdana,Arial" Font-Size="8pt" LoginButtonText="Entrar" PasswordLabelText="Senha:" PasswordRequiredErrorMessage="É preciso digitar uma senha." RememberMeText="Salvar as minhas informações neste computador." TitleText="" UserNameLabelText="Usuário:" UserNameRequiredErrorMessage="É preciso digitar um usuário." BorderColor="White">
                                                                <LoginButtonStyle Font-Names="Verdana,Arial" Font-Size="8pt" />
                                                                <ValidatorTextStyle ForeColor="Navy" />
                                                                <FailureTextStyle ForeColor="Navy" />
                                                                <TextBoxStyle Width="150px" />
                                                            </asp:Login>
                                            <br />
                                            <br />
                                            <br />
                                            <img src="Images/Ajax.jpg" /></td>
                                    </tr>
                                </table>
                                <img src="Images/Bottom.jpg" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
