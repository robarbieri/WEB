<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inAplicativos.aspx.vb" Inherits="inAplicativos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<% 
    If Trim(Session("Usuario")) = "" Then
        Response.Redirect("Login.aspx")
    End If
%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Aplicativos</title>
</head>
<body bgcolor="#1f3662" scroll="no">
    <form id="formApp" runat="server">
    <div>
        <table align="left" style="width: 312px; height: 296px; overflow: hidden;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" colspan="3" rowspan="3" style="width: 332px; height: 53px" valign="top">
                    <br />
                    <asp:TreeView ID="TreeAplicativos" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="LightGray" Width="1px" Font-Bold="True" Height="56px" >
                        <HoverNodeStyle BackColor="Transparent" Font-Bold="False" Font-Names="verdana,arial"
                            Font-Size="8pt" ForeColor="White" />
                        <LeafNodeStyle ForeColor="DarkGray" Font-Bold="False" />
                    </asp:TreeView>
                </td>
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
