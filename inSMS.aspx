<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inSMS.aspx.vb" Inherits="inSMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Emissão de SMS</title>
</head>
<body bgcolor="#1f3662" style="font-size: 8pt; color: white; font-family: Verdana, Arial">
    <form id="form1" runat="server">
    <div align="center">
        <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 392px; height: 144px;">
            <tr>
                <td align="center" colspan="4" valign="middle">
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Tit_SMS.jpg" /></td>
            </tr>
            <tr>
                <td align="left" colspan="3" rowspan="2" style="width: 126px; height: 6px" valign="middle" >
                    <br />
                    <asp:Label ID="lblTipoMsg" runat="server" Text="Tipo da Mensagem:      " Width="136px" Font-Bold="True" ForeColor="LightGray"></asp:Label><br />
                </td>
                <td align="left" colspan="1" rowspan="2" style="height: 6px">
                    <br />
                    <asp:DropDownList ID="cboTipoMensagem" runat="server" Width="184px" AutoPostBack="True" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td align="left" colspan="3" rowspan="1" style="width: 126px" >
                    <br />
                    <asp:Label ID="lblContrato" runat="server" Text="Contrato:" Width="112px" Font-Bold="True" ForeColor="LightGray"></asp:Label><br />
                </td>
                <td align="left" colspan="1" rowspan="1" >
                    <br />
                    <asp:TextBox ID="txtContrato" runat="server" MaxLength="30" Width="144px"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <div align=center>
        <%If Trim(Session("Enviar")) <> "" Then%>
            <iFrame id="OKTO" name="OKTOweb" src="<%=Session("URL")%>" frameborder="0" marginwidth="0" marginheight="0" scrolling="no" style="width: 368px; height: 20px"></iFrame>            
        <%
            Session("Enviar") = ""
            Session("URL") = ""
        End If
        %>
        </div>
    
    </div>
    <div align=center>
        <br />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" BackColor="Transparent" BorderColor="White" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="DarkOrange" Font-Bold="True" />&nbsp;<br />
        <br />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 352px; height: 32px">
            <tr>
                <td align="center" colspan="3" rowspan="3">
                    <asp:Label ID="lblPreview" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="LightGray" Height="72px" Width="360px" BackColor="Transparent"></asp:Label></td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
