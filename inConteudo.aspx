<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inConteudo.aspx.vb" Inherits="_inConteudo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<% 
    If Trim(Session("Usuario")) = "" Then
        Response.Redirect("Login.aspx")
    End If
%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body bgcolor="#1f3662">
    <form id="form1" runat="server">
    <% 
        Dim strId As String
        
        strId = Session("Id")
        
        Select Case Trim(UCase(strId))
            
            Case "HOME"
    %>
    <div>
        <br />
        <br />
        <br />
        <br />
        <table border="0" bordercolor="silver" align=center cellpadding="0" cellspacing="0" style="width: 312px; height: 40px">    
             <tr>
                <td align="center" valign=bottom style="width: 500px; height: 200px">
                    <img src="Images/Logo_<%=Session("Source")%>.jpg"/>
                 </td>
            </tr>
        </table>
    </div>
    <%     
            Case "REPORTS"
    %>
    <div>
        <table align=center border="0" bordercolor="silver" cellpadding="0" cellspacing="0">    
            <tr>
                <td>
                    <iFrame src="inReports.aspx" name="Reports" frameborder="0" marginwidth="0" marginheight="0" scrolling="auto" style="width: 330px; height: 400px; background-color: #1f3662; overflow: auto;"></iFrame>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <%
    Case "APLICATIVOS"
    %>
    <div>
        <table align=center border="0" bordercolor="silver" cellpadding="0" cellspacing="0" style="width: 264px;
            height: 40px">    
            <tr>
                <td style="width: 313px">
                    <iFrame src="inAplicativos.aspx" name="Aplicativos" frameborder="0" marginwidth="0" marginheight="0" style="width: 312px; height: 296px; background-color: #1f3662; overflow: auto;"></iFrame>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <%
End Select
    %>
    </form>
</body>
</html>
