<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inCabecalho.aspx.vb" Inherits="inCabecalho" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Intranet Hargos</title>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <div>
    <%
        Dim strURL As String
        
        strURL = Request("URL")
    %>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 1%;">
            <tr>
                <td bgcolor="#1f3662" style="width: 1px; height: 1px" align="left">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Logo_Cabecalho.jpg" /></td>
                <td colspan="2" style="width: 99%; height: 1px" align="right" bgcolor="#1f3662" valign="top">
                    <asp:Menu ID="MenuTop" runat="server" Font-Names="verdana,arial" Font-Size="8pt"
                        ForeColor="LightGray" Orientation="Horizontal" ScrollDownText="Rolar Abaixo"
                        ScrollUpText="Rolar Acima" Width="136px" BackColor="Transparent" DynamicHorizontalOffset="2" Font-Bold="True" StaticSubMenuIndent="10px">
                        <StaticMenuStyle BackColor="Transparent" BorderColor="Transparent" HorizontalPadding="5px" VerticalPadding="8px" />
                        <StaticMenuItemStyle BackColor="Transparent"
                            ForeColor="LightGray" HorizontalPadding="5px" ItemSpacing="10px" VerticalPadding="2px" />
                        <DynamicHoverStyle BackColor="DarkOrange"
                            ForeColor="White" />
                        <DynamicMenuStyle BackColor="SteelBlue" />
                        <StaticSelectedStyle BackColor="SteelBlue"
                            ForeColor="LightGray" ItemSpacing="2px" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <Items>
                            <asp:MenuItem NavigateUrl="Default.aspx" Target="_parent" Text="Home" ToolTip="P&#225;gina Inicial"
                                Value="Home"></asp:MenuItem>
                            <asp:MenuItem Text="Sistemas     " Value="Sistemas">
                                <asp:MenuItem NavigateUrl="http://neo/" Target="frame" Text="Cobranca" ToolTip="Neo"
                                    Value="Cobranca"></asp:MenuItem>
                                <asp:MenuItem Text="Pesquisa" Value="Pesquisa">
                                    <asp:MenuItem NavigateUrl="Pesquisa.aspx" Target="_blank" Text="Pesquisa X" ToolTip="Pesquisa X"
                                        Value="Pesquisa X"></asp:MenuItem>
                                    <asp:MenuItem NavigateUrl="http://www.afinder.com.br" Target="_blank" Text="@finder"
                                        ToolTip="@finder - Pesquisa Cadastral" Value="@finder"></asp:MenuItem>
                                    <asp:MenuItem NavigateUrl="http://www.informarketing.net/infobusca/" Target="_blank"
                                        Text="InforMarketing" ToolTip="InforMarketing - Pesquisa Cadastral" Value="InforMarketing"></asp:MenuItem>
                                    <asp:MenuItem NavigateUrl="inCabecalho.aspx?URL=http://www.correios.com.br" Target="_parent"
                                        Text="Correios" ToolTip="Pesquisa de Endere&#231;o" Value="Correios"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="http://200.190.61.202/mgroups/" Target="frame" Text="Emiss&#227;o de SMS"
                                    ToolTip="OKTO" Value="Emiss&#227;o de SMS"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Help" ToolTip="Ajuda" Value="Help">
                                <asp:MenuItem Text="Aplicativos" Value="Aplicativos">
                                    <asp:MenuItem NavigateUrl="J:\RB\X\Help\Modulo_X.htm" Target="frame" Text="Modulo X"
                                        Value="Modulo X"></asp:MenuItem>
                                    <asp:MenuItem Selectable="False" Text="x2x" Value="x2x"></asp:MenuItem>
                                </asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="http://www.hargos.com.br" Target="_blank" Text="Web Site"
                                Value="Web Site"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="Login.aspx" Target="_parent" Text="Sair" ToolTip="Logout"
                                Value="Sair"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="DarkOrange" ForeColor="WhiteSmoke" />
                    </asp:Menu>
                </td>
            </tr>
        </table>
    </div>
        <iframe frameborder="0" src="<%=strURL%>" marginheight="0" marginwidth="0" name="frame" style="overflow: auto; width: 100%; height: 100%" tabindex="800"></iframe>
    </form>
</body>
</html>
