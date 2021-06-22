<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inEmail.aspx.vb" Inherits="inEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Emissão de X-Mail BV</title>
</head>
<body bgcolor="#1f3662" style="font-size: 8pt; color: white; font-family: Verdana, Arial">
    <form id="form1" runat="server">
    <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 424px;
            height: 144px">
            <tr>
                <td align="center" colspan="4" valign="middle">
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Tit_xMail.jpg" /></td>
            </tr>
            <tr>
                <td align="left" colspan="3" rowspan="2" style="width: 152px; height: 6px" valign="middle">
                    <br />
                    <asp:Label ID="lblTipoMsg" runat="server" Font-Bold="True" ForeColor="LightGray"
                        Text="Layout do E-Mail:      " Width="136px"></asp:Label><br />
                </td>
                <td align="left" colspan="1" rowspan="2" style="height: 6px">
                    <br />
                    <asp:DropDownList ID="cboTipoMensagem" runat="server" AutoPostBack="True" Width="184px">
                        <asp:ListItem Value="1">Padr&#227;o</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td align="left" colspan="3" rowspan="1" style="width: 152px; height: 46px;">
                    <br />
                    <asp:Label ID="lblContrato" runat="server" Font-Bold="True" ForeColor="LightGray"
                        Text="Contrato:" Width="112px"></asp:Label><br />
                </td>
                <td align="left" colspan="1" rowspan="1" style="height: 46px">
                    <br />
                    <asp:TextBox ID="txtContrato" runat="server" MaxLength="30" Width="144px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" colspan="3" rowspan="1" style="width: 152px; height: 46px">
                    <asp:Label ID="lbleMail" runat="server" Font-Bold="True" ForeColor="LightGray" Text="E-Mail"
                        Width="112px"></asp:Label></td>
                <td align="left" colspan="1" rowspan="1" style="height: 46px">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="60" Width="232px"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <div align=center>
        <br />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" BackColor="Transparent" BorderColor="White" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="DarkOrange" Font-Bold="True" />&nbsp;</div>
    </form>
</body>
</html>
