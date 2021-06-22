<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Pesquisa.aspx.vb" Inherits="Pesquisa" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<LINK TYPE="text/css" REL="STYLESHEET" HREF="style.css">
    <title>Pesquisa X - Hargos</title>
</head>
<body background="Images/bgb.gif">
    <form id="form1" runat="server">
    <div align="center">        
        <asp:ScriptManager ID="ScriptManager" runat="server" AllowCustomErrorsRedirect="False">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
           <% 
               Dim intCabecalho As Short

               intCabecalho = Request("Cabecalho")
               If intCabecalho = 0 Then intCabecalho = Session("Cabecalho")
               If intCabecalho = 0 Then intCabecalho = 1
               Session("Cabecalho") = intCabecalho
               %>

        <table align="center" cellpadding="0" cellspacing="0" style="width: 760px; height: 1px" bgcolor="#ffffff">
        <% If intCabecalho = 1 Then%>
            <tr>
                <td align="center" bordercolor="#ffffff" colspan="1" style="width: 798px; height: 190px" valign="top">
                    <a href="http://<%=Session("Server")%>/intranet/Pesquisa.aspx?Cabecalho=2"><img src="Images\Top_Hargos.jpg" id="IMG1" border=0></a>
                </td>
            </tr>
        <% End If%>
            <tr>
                <td align="center" style="width: 798px; height: 37px" valign="top">
                    <a href="http://<%=Session("Server")%>/intranet/Pesquisa.aspx?Cabecalho=1"><img src="Images/Menu_<%=intCabecalho%>.jpg" border=0></a>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 798px; height: 59px" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 776px; height: 200px" align="center">
                        <tr>
                            <td align="center" bgcolor="white" style="width: 776px;" valign="middle">
                                <asp:Label ID="lblLimpar" runat="server" Font-Names="Verdana,Arial" Font-Size="7pt"
                                    ForeColor="Gray" Text='Clique no "X" ao lado dos campos para limpar...'></asp:Label><br />
                                <table align="center" border="0" bordercolor="gainsboro" cellpadding="5" cellspacing="0"
                                    style="width: 100%">
                                    <tr>
                                        <td align="center" bgcolor="gainsboro" colspan="14" rowspan="1">
                                            <asp:Label ID="lblCPF" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="CPF" Font-Bold="True"></asp:Label>
                                            <asp:TextBox ID="txtCPF" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="30" TabIndex="1" Width="136px"></asp:TextBox>&nbsp;
                                            <Button id="Button1" onclick="javascript:Clear('txtCPF','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">X</Button>
                                            &nbsp;
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblNome" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="Nome"></asp:Label>
                                            <asp:TextBox ID="txtNome" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="40" TabIndex="2" Width="160px"></asp:TextBox>&nbsp;<Button id="Button2" onclick="javascript:Clear('txtNome','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">X</button>
                                            &nbsp;&nbsp;
                                            <asp:Label ID="Label5" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="Qtd"></asp:Label>
                                            <asp:DropDownList ID="cboQtd" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                TabIndex="3" Width="56px">
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:HyperLink ID="linkHelp" runat="server" NavigateUrl="Help_Pesquisa.htm" Target="_blank">? Help</asp:HyperLink></td>
                                    </tr>
                                    <tr style="font-size: 12pt; font-family: Times New Roman">
                                        <td align="center" bgcolor="white" colspan="14" rowspan="1">
                                            &nbsp;&nbsp;
                                            <asp:Label ID="lblDDD" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="DDD"></asp:Label>
                                            <asp:TextBox ID="txtDDD" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="2" TabIndex="4" Width="32px"></asp:TextBox>
                                            &nbsp;<Button id="Button3" onclick="javascript:Clear('txtDDD','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">X</button>
                                            &nbsp; &nbsp; &nbsp;
                                            &nbsp; &nbsp;
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblFone" runat="server" Font-Names="Verdana,Arial"
                                                Font-Size="8pt" ForeColor="Black" Text="Fone"></asp:Label>
                                            <asp:TextBox ID="txtFone" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="15" TabIndex="5" Width="96px"></asp:TextBox>&nbsp;<Button id="Button4" onclick="javascript:Clear('txtFone','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">
                                                    X</button></td>
                                    </tr>
                                    <tr style="font-size: 12pt; font-family: Times New Roman">
                                        <td align="center" bgcolor="gainsboro" colspan="14" rowspan="1">
                                            &nbsp; &nbsp;
                                            <asp:Label ID="lblEndereco" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="Endereço" Width="56px"></asp:Label>
                                            <asp:TextBox ID="txtEndereco" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="40" TabIndex="6" Width="192px"></asp:TextBox>
                                            <Button id="Button5" onclick="javascript:Clear('txtEndereco','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">X</button>
                                            &nbsp;&nbsp;
                                            <asp:Label ID="lblNumero" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="Nº" Width="16px"></asp:Label>
                                            <asp:TextBox ID="txtNumero" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="10" TabIndex="7" Width="56px"></asp:TextBox>
                                            <Button id="Button6" onclick="javascript:Clear('txtNumero','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">X</button>
                                            &nbsp;&nbsp;
                                            <asp:Label ID="lblComplemento" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="Compl." Width="16px"></asp:Label>
                                            <asp:TextBox ID="txtComplemento" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="20" TabIndex="8" Width="72px"></asp:TextBox>
                                            <Button id="Button7" onclick="javascript:Clear('txtComplemento','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">X</button>
                                            &nbsp; &nbsp;
                                            <asp:button runat="server" ID="btnProximidades" Text="Proximidades" Font-Size="7pt" Font-Names="Verdana,Arial" Height="17px" Font-Bold="true" TabIndex="14"></asp:button>&nbsp;
                                            <button id="Map" onclick="CarregarMapa()" style="font-weight: bold; font-size: 7pt;
                                                font-family: Verdana,Arial; height: 17px" type="button" tabindex="15">
                                                M</button>&nbsp;</td>
                                    </tr>
                                    <tr style="font-size: 12pt; font-family: Times New Roman">
                                        <td align="center" bgcolor="gainsboro" colspan="14" rowspan="1">
                                            &nbsp; &nbsp; &nbsp;
                                            <asp:Label ID="lblBairro" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="Bairro" Width="16px"></asp:Label>
                                            <asp:TextBox ID="txtBairro" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="30" TabIndex="9" Width="144px"></asp:TextBox>
                                            &nbsp;<Button id="Button8" onclick="javascript:Clear('txtBairro','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">X</button>
                                            &nbsp;&nbsp;
                                            <asp:Label ID="lblCEP" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="CEP" Width="16px"></asp:Label>
                                            <asp:TextBox ID="txtCEP" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="14" TabIndex="10" Width="72px"></asp:TextBox>&nbsp;<Button id="Button9" onclick="javascript:Clear('txtCEP','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">
                                                    X</button></td>
                                    </tr>
                                    <tr style="font-size: 12pt; font-family: Times New Roman">
                                        <td align="center" bgcolor="gainsboro" colspan="14" rowspan="1">
                                            <asp:Label ID="lblCidade" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Black" Text="Cidade"></asp:Label>
                                            <asp:TextBox ID="txtCidade" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="#404040" MaxLength="30" TabIndex="11" Width="96px"></asp:TextBox>
                                            <Button id="Button10" onclick="javascript:Clear('txtCidade','')" style="height:16px;width:16px;font-family:Verdana,Arial;font-size:6pt">X</button>
                                            &nbsp;&nbsp; &nbsp;
                                            &nbsp;<asp:Label ID="Label2" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                ForeColor="Red" Text="UF" Font-Bold="True"></asp:Label>&nbsp;<asp:DropDownList ID="cboUF" runat="server" Font-Names="Verdana,Arial" Font-Size="8pt"
                                                TabIndex="12">
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                    <tr style="font-size: 12pt; font-family: Times New Roman">
                                        <td align="right" bgcolor="white" colspan="13" rowspan="1" style="width: 2088px">
                                        <asp:button ID="btnBuscar" Text="Buscar" runat="server" Height="20px" Font-Size="8pt" Font-Bold="true" Font-Names="Verdana,Arial" OnClick="btnBuscar_Click" TabIndex="13"></asp:button>
                                            &nbsp; &nbsp;
                                            <button id="Button11" onclick="javascript:ClearAll()" style="font-size: 8pt;
                                                font-family: Verdana,Arial; height: 20px" type="button" tabindex="16">Limpar</button>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td align="right" bgcolor="white" colspan="1" rowspan="1" style="width: 313px">
                                            <div style="width: 184px; height: 40px">
                                            <asp:CheckBox ID="chkAV" runat="server" Font-Names="Verdana,Arial"
                                                Font-Size="7pt" ForeColor="Black" Text="Busca AUT" Width="72px" Font-Bold="False" Font-Italic="True" Checked="True" Enabled="False" />
                                            &nbsp;/
                                            <asp:CheckBox ID="chkHigienizar" runat="server" Font-Names="Verdana,Arial"
                                                Font-Size="7pt" ForeColor="Black" Text="Higienizar" Width="1px" Font-Bold="False" Font-Italic="True" Height="16px" Enabled="False" /><br />
                                            <asp:CheckBox ID="chkFixo" runat="server" Checked="True" Font-Names="Verdana,Arial"
                                                Font-Size="7pt" ForeColor="Black" Text="Fixo" Width="1px" Font-Bold="False" Font-Italic="True" Enabled="False" />
                                                /<asp:CheckBox ID="chkMovel" runat="server" Font-Names="Verdana,Arial"
                                                Font-Size="7pt" ForeColor="Black" Text="Móvel" Width="1px" Font-Bold="False" Font-Italic="True" Checked="True" Enabled="False" />
                                            &nbsp; /<asp:CheckBox ID="chkSatelite" runat="server" Font-Names="Verdana,Arial"
                                                Font-Size="7pt" ForeColor="Black" Text="Satélite" Width="1px" Font-Bold="False" Font-Italic="True" Enabled="False" /></div>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" bgcolor="white" border="0" cellpadding="0" cellspacing="0"
                                    style="font-size: 12pt; width: 100%; font-family: Times New Roman">
                                    <tr>
                                        <td align="center" colspan="3" rowspan="3" style="width: 796px;" valign="top">
                                            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel"
                                                DisplayAfter="1">
                                                <ProgressTemplate>
                                                <div ID="Progress" style="font-size: 7pt; font-family: Verdana,Arial; color:DarkOrange">
                                                   <img src="Images/Loading3.gif"/>&nbsp;
                                                     Carregando...
                                                 </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:Label ID="lblResult" runat="server" Font-Names="verdana,arial" Font-Size="7pt"
                                                ForeColor="DarkOrange" Text="Result"></asp:Label></td>
                                    </tr>
                                    <tr>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <a href="http://<%=Session("Server")%>/intranet/Default.aspx"><img src="Images/Bottom.jpg" style="font-size: 12pt; font-family: Times New Roman" id="IMG3" border=0></a>
                    </td>
            </tr>
        </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>

</body>
</html>
