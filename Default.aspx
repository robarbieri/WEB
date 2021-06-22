<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=Session("Source")%> - Hargos</title>
</head>
<body background="Images/bgb.gif">
    <form id="Default" runat="server">
    <div>
    <% 
        Dim strPagina As String
        Dim intCabecalho As Short
        
        strPagina = Session("Pagina")
        If Trim(strPagina) = "" Then strPagina = "inPagina"
                    
        intCabecalho = Request("Cabecalho")
        If intCabecalho = 0 Then intCabecalho = Session("Cabecalho")
        If intCabecalho = 0 Then intCabecalho = 1
        
        If Session("Grupo") = 2 Or Session("Grupo") = 3 Or Session("Grupo") = 6 Then intCabecalho = 2
        
        Session("Cabecalho") = intCabecalho
        
    %>
        <table border="1" bordercolor="#ffffff" style="width: 640px; height: 1px;" align="center" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
            <tr>
                <td align="center" style="width: 774px; height: 2px" valign="top">
        <table style="width: 696px; height: 1px" cellpadding="0" cellspacing="0">
            <% If intCabecalho = 1 Then %>
            <tr>
                <td align="center" valign="top" bordercolor="#ffffff" colspan="" style="width: 780px; height: 119px" >
                    <a href="http://<%=Session("Server")%>/intranet/Default.aspx?Pagina=<%=Session("Pagina")%>&Cabecalho=2"><img src="Images\Top_Hargos.jpg" border="0" /></a>
                </td>
            </tr>
            <% End If%>
            <tr>
                <td align="center" style="width: 780px; height: 37px;" valign="top">
                    <a href="http://<%=Session("Server")%>/intranet/Default.aspx?Pagina=<%=Session("Pagina")%>&Cabecalho=1"><img src="Images/Menu_<%=Session("Source")%>_<%=intCabecalho%>.jpg" border="0" /></a>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 780px; height: 78px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 672px; height: 200px">
                        <tr>
                            <td align="center" valign="top" style="height: 390px">
                                <img align="top" src="Images/Left.jpg" /></td>
                            <td style="width: 545px; height: 390px;" align="left" valign="top">
                                <iFrame src="<%=strPagina%>.aspx" name="Conteudo" width="545" height="456" frameborder="0" marginwidth="0" marginheight="0" scrolling="no" style="height: 400px"></iFrame>
                            </td>
                        </tr>
                    </table>
                    <img src="Images/Bottom.jpg" /></td>
            </tr>
        </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
