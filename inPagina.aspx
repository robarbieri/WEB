<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inPagina.aspx.vb" Inherits="_inPagina" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<% 
    If Trim(Session("Usuario")) = "" Then
        Response.Redirect("Login.aspx")
    End If
%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="Pagina" runat="server">
    <div>
    <%
        Dim intGrupo As Integer
        Dim sUsuario As String
        Dim strId As String

        sUsuario = Session("NomeUser")
        intGrupo = Session("Grupo")
        strId = Request("Id")

        If Trim(strId) = "" Then strId = "Home"
        'If Trim(strId) = "" Then strId = "Reports"
        
        Session("Id") = strId
    %>
    <table style="width: 504px; height: 400px" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" rowspan="3" style="width: 193px" align="right" valign="top" background="Images/azul_claro.jpg">
                <img src="Images/Counsultas.jpg" /><br />
                <table border="0" cellpadding="0" cellspacing="0" style="width: 136px; height: 120px;">
                    <tr>
                        <td align="left" colspan="3" rowspan="1" style="font-weight: bold; font-size: 8pt;
                            text-transform: capitalize; color: gainsboro; font-family: Verdana, Arial; height: 20px" valign="top">
                            <asp:Menu ID="MenuLeft" runat="server" Width="136px" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="LightGray" ScrollDownText="Rolar Abaixo" ScrollUpText="Rolar Acima">
                                <StaticMenuItemStyle Font-Names="Verdana,Arial" Font-Size="8pt" ForeColor="LightGray" BackColor="Transparent" HorizontalPadding="5px" ItemSpacing="3px" />
                                <StaticHoverStyle BackColor="DarkOrange" ForeColor="White" />
                                <StaticMenuStyle BackColor="Transparent" />
                                <DynamicHoverStyle BackColor="DarkOrange" Font-Names="verdana,arial" Font-Size="8pt"
                                    ForeColor="White" />
                                <DynamicMenuStyle BackColor="SteelBlue" />
                                <StaticSelectedStyle BackColor="Transparent" Font-Names="Verdana,Arial" Font-Size="8pt"
                                    ForeColor="LightGray" />
                                <DynamicSelectedStyle BackColor="Transparent" Font-Names="verdana,arial" Font-Size="8pt"
                                    ForeColor="LightGray" />
                                <DynamicMenuItemStyle BackColor="SteelBlue" Font-Names="verdana,arial" Font-Size="8pt"
                                    ForeColor="Gainsboro" ItemSpacing="2px" HorizontalPadding="10px" />
                            </asp:Menu>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td style="width: 223px; height: 21px;" background="Images/Back.jpg" valign="top">
                <img src="Images/Tit_<%=strId%>.jpg" />
                <table border="0" cellpadding="0" cellspacing="0" style="width: 216px; height: 88px" align="center">
                    <tr>
                        <td align="center" colspan="2" rowspan="2" style="width: 186px; height: 26px;" valign="middle">
                            <iFrame src="inConteudo.aspx" name="Conteudo" frameborder="0" marginwidth="0" marginheight="0" scrolling="no" style="width: 392px; height: 320px"></iFrame>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 223px; font-weight: bold; font-size: 6pt; color: white; font-family: Verdana, Arial; height: 15px;" align="left" background="Images/Back.jpg" rowspan="2" valign="top">
                &nbsp;&nbsp;
                Usuário: <%=sUsuario%>
            </td>
        </tr>
        <tr>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
