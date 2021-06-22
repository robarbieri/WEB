<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inCartaodeCredito.aspx.vb" Inherits="inCartaodeCredito" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Cartão de Crédito</title>
</head>
<body bgcolor="#1f3662" style="font-size: 8pt; font-weight: bold; color: lightgrey; font-family: Verdana, Arial" topmargin="0">
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 488px;
            height: 1px">
            <tr>
                <td align="center" colspan="6" valign="middle" style="height: 49px">
                    <br />
                    <img src="Images/Tit_Cartao.jpg" /></td>
            </tr>
            <tr>
                <td align="center" colspan="5" rowspan="1" style="height: 36px" valign="middle" background="Images/azul_claro.jpg">
                    <font style="font-size: 9pt;">
                        Bandeira</font></td>
                <td bgcolor="#d3d3d3" align="center" colspan="1" rowspan="1" style="width: 3761px; height: 36px" valign="middle">
                    <strong><span style="font-size: 9pt; color: #1f3662;">Dados</span></strong></td>
            </tr>
            <tr>
                <td align="center" colspan="4" rowspan="5" valign="top" bgcolor="#ffffff">
                    <img src="Images/bandeiras_cartoes_sky.jpg" /></td>
                <td align="left" colspan="1" rowspan="4" style="width: 151px; height: 178px" valign="top" background="Images/azul_claro.jpg">
                    <asp:RadioButtonList ID="cboBandeira" runat="server" CellPadding="5" CellSpacing="1"
                        Font-Bold="True" ForeColor="LightGray" AutoPostBack="True" Font-Size="7pt">
                        <asp:ListItem Selected="True" Value="1">VISA</asp:ListItem>
                        <asp:ListItem Value="2">MASTER</asp:ListItem>
                        <asp:ListItem Value="3">DINNERS</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td align="center" colspan="1" rowspan="5" style="width: 3761px;" valign="top" bgcolor="lightgrey">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 304px; height: 208px; color: #1f3662;">
                        <tr>
                            <td colspan="3" rowspan="3" style="width: 296px" align="left" bgcolor="lightgrey">
                                Contrato</td>
                            <td align="left" colspan="1" rowspan="3" style="width: 183px" bgcolor="lightgrey">
                                <asp:TextBox ID="txtContrato" runat="server" MaxLength="19" onKeyDown="javascript:fnFormatContrato();"></asp:TextBox></td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td align="left" colspan="3" rowspan="1" style="width: 296px" bgcolor="lightgrey">
                                Nº do Cartão</td>
                            <td align="left" colspan="1" rowspan="1" style="width: 183px" bgcolor="lightgrey">
                                <asp:TextBox ID="txtCartao" runat="server" MaxLength="19" onKeyDown="javascript:fnFormatCartao();"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3" rowspan="1" style="width: 296px" bgcolor="lightgrey">
                                Cod. Segurança</td>
                            <td align="left" colspan="1" rowspan="1" style="width: 183px" bgcolor="lightgrey">
                                <asp:TextBox ID="txtCodigo" runat="server" Width="48px" MaxLength="8"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3" rowspan="1" style="width: 296px" bgcolor="lightgrey">
                                Titular do Cartão</td>
                            <td align="left" colspan="1" rowspan="1" style="width: 183px" bgcolor="lightgrey">
                                <asp:TextBox ID="txtNome" runat="server" Width="176px" MaxLength="30"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3" rowspan="1" style="width: 296px" bgcolor="lightgrey">
                                Validade (M/A)</td>
                            <td align="left" colspan="1" rowspan="1" style="width: 183px" bgcolor="lightgrey">
                                <asp:DropDownList ID="cboMes" runat="server" Width="56px">
                                </asp:DropDownList>&nbsp;<asp:DropDownList ID="cboAno" runat="server">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3" rowspan="1" style="width: 296px" bgcolor="lightgrey">
                                Qtde. Parcelas</td>
                            <td align="left" colspan="1" rowspan="1" style="width: 183px" bgcolor="lightgrey">
                                <asp:DropDownList ID="cboParcelas" runat="server" Width="56px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3" rowspan="1" style="width: 296px; height: 15px;" bgcolor="lightgrey">
                                Valor Total</td>
                            <td align="left" colspan="1" rowspan="1" style="width: 183px; height: 15px;" bgcolor="lightgrey">
                                <asp:TextBox ID="txtValor" runat="server" onKeyDown="javascript:FormataValor('txtValor',10,event)" onKeyUp="javascript:ReFormataValor('txtValor',10,event)" Width="80px" MaxLength="15"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td align="center" bgcolor="#ffffff" colspan="1" rowspan="1" style="width: 151px;
                    height: 17px" valign="bottom">
                    <img src="Images/Logo_Sky2.jpg" /></td>
            </tr>
        </table>
        <br />
        <div align="center"><asp:Button id="btnRegistrar" runat="server" Font-Bold="True" ForeColor="DarkOrange" Text="Registrar" Font-Names="verdana,arial" BackColor="Transparent" BorderColor="White" Font-Size="8pt"></asp:Button></div>
    </form>
</body>
</html>
