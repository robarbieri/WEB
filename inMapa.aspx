<%@ Page Language="VB" AutoEventWireup="false" CodeFile="inMapa.aspx.vb" Inherits="inMapa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Mapa</title>
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAtUXSxoYM-UQHinWB0w2dexRTyMyJC9u7R5MXYUOucZjx_Bo-VxTlOY_ihREDcspDcKuX-yvBcLWYLQ"
      type="text/javascript"></script>
    <script type="text/javascript">
    var map = null;
    var geocoder = null;

    function load() {
      if (GBrowserIsCompatible()) {
        map = new GMap2(document.getElementById("map"));
		map.addControl(new GSmallMapControl());
		map.addControl(new GMapTypeControl());
//        map.setCenter(new GLatLng(37.4419, -122.1419), 13);
        geocoder = new GClientGeocoder();
		showAddress("<%=strDados%>",
		            "<%=strCPF%>",
		            "<%=strNome%>",
		            "<%=strEndereco%>",
		            "<%=strBairro%>",
		            "<%=strCep%>",
		            "<%=strCidade%>",
		            "<%=strUF%>",
		            "<%=strPais%>");
      }
    }

    function showAddress(address,cpf,nome,end,bairro,cep,cidade,uf,pais) {
      if (geocoder) {
        geocoder.getLatLng(
          address,
          function(point) {
            if (!point) {
              alert(address + " not found");
            } else {
              map.setCenter(point, 13);
//              var infoTabs = [  
//              new GInfoWindowTab("CPF", cpf),  
//              new GInfoWindowTab("Nome", nome),
//              new GInfoWindowTab("End", end),
//              new GInfoWindowTab("Bairro", bairro),
//              new GInfoWindowTab("Cep", cep),
//              new GInfoWindowTab("Cidade", cidade),
//              new GInfoWindowTab("UF", uf),
//              new GInfoWindowTab("País", pais),
//              ];
              var marker = new GMarker(point);
              map.addOverlay(marker);
              marker.openInfoWindowHtml(end);
              
//              GEvent.addListener(marker, "click", function() {  
//              marker.openInfoWindowTabsHtml(infoTabs);
//              });
//              map.addOverlay(marker);
//              marker.openInfoWindowTabsHtml(infoTabs);
              
			  map.zoomIn();
			  map.zoomIn();
            }
          }
        );
      }
    }
    </script>
  </head>
  <body onload="load()" onunload="GUnload()" bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
      <div id="map" style="width: 580px; height: 436px"></div>
  </body>
</html>
